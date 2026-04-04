using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;

namespace ADO
{
    class Program
    {
        //private const string movies_PV_522_connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_PV_522;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        static string connection_string = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
        static Connector movies_PV_522 = new Connector(connection_string);
        
        static void Main(string[] args)
        {
            Console.WriteLine(movies_PV_522.GetPrimaryKeyColumnName("Movies"));
            Console.WriteLine(movies_PV_522.GetNextPrimaryKey("Movies"));

            movies_PV_522.Insert
                (
                    "Directors",
                    "director_id , first_name , last_name",
                    $"{movies_PV_522.GetNextPrimaryKey("Directors")} ,N'James' , N'Cameron'"
                );
            movies_PV_522.Insert
                (
                    "Directors",
                    "director_id , first_name , last_name",
                    $"{movies_PV_522.GetNextPrimaryKey("Directors")} ,N'Sheldon' , N'Letich'"
                );
            
            movies_PV_522.Select("SELECT * FROM Directors");
            movies_PV_522.Select("title,first_name,last_name" , "Movies,Directors","director = director_id");

            
            ConsolePause();
        }
        static void ConsolePause() 
        {
            Console.Write(" Press any Key to continue . . .");
            Console.ReadKey();
        }
    }
}
