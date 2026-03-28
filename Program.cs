using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADO
{
    class Program
    {
        //static SqlConnection connection;
        static void Main(string[] args)
        {
            const string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_PV_522;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            Console.WriteLine(connection_string);
            T_SQL.connection = new SqlConnection(connection_string);
            
            string cmd = "SELECT * FROM Directors";
            T_SQL.Select(cmd);
            Console.WriteLine($"Колличество записей: {T_SQL.Scalar("SELECT COUNT(*) FROM Directors")}");
            T_SQL.Select("SELECT " +
                    "title , date = release_date , first_name , last_name " +
                    "FROM Movies , Directors " +
                    "WHERE director_id = director");
        }
        /*
        static void Select(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write($"[ {reader.GetName(i)} ]\t");
            Console.WriteLine();
            while (reader.Read())
            {
                string output_line = "";
                for(int i = 0; i < reader.FieldCount; ++i) 
                    output_line += reader[i].ToString() + '\t';
                Console.WriteLine(output_line);

                //Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
                //Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader.FieldCount}");
            }
            reader.Close();
            connection.Close();
        }
        static object Scalar(string cmd)
        {
            object value = null;
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            value = command.ExecuteScalar();
            connection.Close();
            return value;
        }
        */
    }
}
