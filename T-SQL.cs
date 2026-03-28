using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public static class T_SQL
    {
        public static SqlConnection connection;
        public static void Select(string cmd)
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
                /*
                string output_line = "";
                for(int i = 0; i < reader.FieldCount; ++i) 
                    output_line += reader[i].ToString() + '\t';
                Console.WriteLine(output_line);
                */
                //Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
                //Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader.FieldCount}");
            }
            reader.Close();
            connection.Close();
            for (int i = 0; i < output[0].Length; ++i)
            {
                int max_size_str = 0;
                for (int j = 0; j < output.Length; ++j)
                    if (max_size_str < output[j][i].Length) max_size_str = output[j][i].Length;


                for (int j = 0; j < output.Length; ++j)
                    output[j][i] += new string(' ', max_size_str - output[j][i].Length + 4);
            }
            foreach (string[] line in output)
            {
                foreach (string str in line)
                    Console.Write(str);
                Console.WriteLine();
            }
        }
        
        public static object Scalar(string cmd)
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
