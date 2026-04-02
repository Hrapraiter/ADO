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

            //movies_PV_522.Select("SELECT * FROM Directors");
            //movies_PV_522.Select("title,first_name,last_name" , "Movies,Directors","director = director_id");
            
            Console.WriteLine("\x1b[31m-------До вставки-----\x1b[0m\n");
            movies_PV_522.Select("SELECT * FROM Directors");

            int last_index = (int)movies_PV_522.Scalar("SELECT MAX(director_id) FROM Directors");
            movies_PV_522.Insert
                     (
                     "Directors", "director_id , first_name , last_name",

                     $"{++last_index} , N'Johnny' , N'Cage' ",
                     $"{++last_index} , N'Lara' , N'Croft' "

                     );
            Console.WriteLine("\x1b[32m-------После Вставки------\x1b[0m\n");
            movies_PV_522.Select("SELECT * FROM Directors");

            movies_PV_522.Delete("Directors" , "director_id > 6");
            
            ConsolePause();
        }
        static void ConsolePause() 
        {
            Console.Write(" Press any Key to continue . . .");
            Console.ReadKey();
        }
    }
}
