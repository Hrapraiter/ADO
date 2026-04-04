using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection.Emit;

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
        public void Select(string cmd , int interval = 4)
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
            Console.WriteLine($"\n{new string('-' , output[0].Sum(str => str.Length))}");

            for (int i = 1; i < output.Length;++i)
            {
                foreach (string line in output[i])
                    Console.Write(line);
                Console.WriteLine();
            }
            Console.WriteLine('\n');
        }
        public void Select(string fields , string tables , string condition = "" , int interval = 4)
        {
            string cmd = $"SELECT {fields} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            Select(cmd , interval);
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

            return Scalar(cmd).ToString();
        }
        public int GetLastPrimaryKey(string table_name) =>
            (int)Scalar($"SELECT MAX({GetPrimaryKeyColumnName(table_name)}) FROM {table_name}");
        public int GetNextPrimaryKey(string table_name) =>
            GetLastPrimaryKey(table_name) + 1;
            
        
        public void Insert(string cmd) 
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(string table , string fields , string values) 
        {
            string[] split_fields = fields.Split(',');
            string[] split_values = values.Split(',');
            if (split_fields.Length != split_values.Length) return;
            string condition = "";
            
            for(int i = 1; i < split_fields.Length; ++i) 
            {
                condition += $"{split_fields[i]} = {split_values[i]}";
                if (i != split_values.Length - 1) condition += " AND ";
            }
            if (Scalar($"SELECT {GetPrimaryKeyColumnName(table)} FROM {table} WHERE {condition}") == null)
                Insert($"Insert {table}({fields}) VALUES({values})");    
            
        }
        
    }
}
