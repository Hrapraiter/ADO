using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
        
    }
}
