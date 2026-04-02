using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace ADO
{
    public class Connector 
    {
        private SqlConnection connection;
        
        //public Connector(SqlConnection _connection) { connection = _connection; }
        //public Connector(ref SqlConnection _connection) { connection = _connection; }
        public Connector(string connection_string) 
        {
            connection = new SqlConnection(connection_string);
            Console.WriteLine(connection_string);
        }
        public string[][] Select(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string[][] output = new string[1][];
            output[0] = new string[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
                output[0][i] = $"[ {reader.GetName(i)} ]";
            /*
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write($"[ {reader.GetName(i)} ]\t");
            Console.WriteLine();
            */
            while (reader.Read())
            {
                output = output.Append(new string[reader.FieldCount]).ToArray();
                for (int i = 0; i < reader.FieldCount; i++)
                    output[output.Length - 1][i] = reader[i].ToString();
            }
            reader.Close();
            connection.Close();

            return output;
        }
        public void VoidSelect(string cmd , int interval = 4) =>
            PrintOutputSelect(Select(cmd), interval);
        
        public void VoidSelect(string fields , string tables , string condition = "" , int interval = 4)
        {
            string cmd = $"SELECT {fields} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            PrintOutputSelect(Select(cmd));
        }
        void PrintOutputSelect(string[][] output , int interval = 4) 
        {
            for (int i = 0; i < output[0].Length; ++i)
            {
                int max_size_str = 0;
                for (int j = 0; j < output.Length; ++j)
                    if (max_size_str < output[j][i].Length) max_size_str = output[j][i].Length;

                for (int j = 0; j < output.Length; ++j)
                    output[j][i] = output[j][i].PadRight(max_size_str + interval);//+= new string(' ', max_size_str - output[j][i].Length + interval);
            }
            for (int i = 0; i < output[0].Length; ++i)
                Console.Write(output[0][i]);
            Console.WriteLine($"\n{new string('-', output[0].Sum(str => str.Length))}");

            for (int i = 1; i < output.Length; ++i)
            {
                foreach (string line in output[i])
                    Console.Write(line);
                Console.WriteLine();
            }
            Console.WriteLine('\n');
        }
        
        public object Scalar(string cmd)
        {
            object value = null;
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            value = command.ExecuteScalar();
            connection.Close();
            return value;
        }
        public string GetPrimaryKeyColumnName(string table_name) 
        {
            string cmd = $@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
                            WHERE CONSTRAINT_NAME=
                            (
                            SELECT	CONSTRAINT_NAME 
                            FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                            WHERE	TABLE_NAME= N'{table_name}'
                            AND		CONSTRAINT_TYPE = N'PRIMARY KEY'
                            );";

            return (string)Scalar(cmd);
        }
        public int GetLastPrimaryKey(string table_name) =>
            (int)Scalar($"SELECT MAX({GetPrimaryKeyColumnName(table_name)}) FROM {table_name}");
        public int GetNextPrimaryKey(string table_name) =>
            GetLastPrimaryKey(table_name) + 1;
            
        
        public void Insert(string cmd) 
        {
            if (!InsertFilter(cmd))
            {
                Console.WriteLine("\x1b[33mYour value don't append they in the base\x1b[0m");
                return;
            }
            
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        bool InsertFilter(string cmd)
        {
            int temp_index = -1;
            string table_name = cmd.Substring(temp_index = cmd.IndexOf("INSERT") + 7, cmd.IndexOf('(') - temp_index);
            List<string> row_names = cmd.Substring(temp_index = cmd.IndexOf('(') + 1, cmd.IndexOf(')') - temp_index).Split(',').ToList();
            List<List<string>> append_values = cmd.Substring(temp_index = cmd.IndexOf("VALUES") + 6, cmd.Length - temp_index)
                                           .Split('(')
                                           .Select(str => str.Substring(0, (temp_index = str.IndexOf(')')) <= 0 ? str.Length: temp_index).Split(',').ToList())
                                           .Where(array => array.Count == row_names.Count)
                                           .ToList();
            
            //Console.WriteLine(table_name);
            string primary_key = GetPrimaryKeyColumnName(table_name);
            
            for(int i = 0 ;i < row_names.Count; ++i) 
            {
                if (row_names[i].IndexOf(primary_key) > -1)
                {
                    temp_index = i;
                    //Console.WriteLine(i);
                    //Console.WriteLine(primary_key);
                    row_names.Remove(row_names[i]);
                    break;
                }
            }
            foreach (List<string> values in append_values)
                values.Remove(values[temp_index]);

            //foreach(string row_name in row_names) 
            //    Console.WriteLine(row_name);
            
            //foreach (List<string> values in append_values)
            //{
            //    foreach (string value in values)
            //        Console.Write($"{value} | ");
            //    Console.WriteLine();
            //}
            for (int i = 0; i < append_values.Count; i++) 
                if (isBase(table_name, row_names.ToArray(), append_values[i].ToArray()))
                    return false;
            
            return true;
        }
        public bool isBase(string table_name,string[] row_names , string[] append_values) 
        {
            if (row_names.Length != append_values.Length) throw new ArgumentException("isBase method rows_names.Length != append_values.Length");
            string output_condition = "";
            for(int i = 0; i < row_names.Length-1; ++i) 
            {
                output_condition += row_names[i] + "=" + append_values[i] + " AND ";
            }
            output_condition += row_names.Last() + "=" + append_values.Last();
            //return output_condition;
            return Select($"SELECT * FROM {table_name} WHERE {output_condition}").Length > 1;
        }
    }
}
