using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using DBtools;

namespace DLLcheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Connector connector = new Connector(ConfigurationManager.ConnectionStrings["Movies_PV_522"].ConnectionString);
            connector.Insert("Directors", "director_id , first_name , last_name",
              $"{connector.GetNextPrimaryKey("Directors")} , N'Test_F' , N'Test_L'");

            connector.Update
                (
                    "Directors",
                    "first_name = N'DONE Test_F' , last_name = N'DONE Test_L'",
                    $"director_id = {connector.GetLastPrimaryKey("Directors")}"
                );

            connector.Select("*", "Directors");
            //connector.Insert($"DELETE FROM Directors WHERE director_id = {connector.GetLastPrimaryKey("Directors")}");

            connector.Select
                (
                    "title,release_date,first_name , last_name",
                    "Movies , Directors",
                    "director = director_id"
                );
            Connector connectorAcademy = new Connector(ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString);
            connectorAcademy.Select("*" , "Disciplines");
        }
    }
}
