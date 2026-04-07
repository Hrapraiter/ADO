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

            //connector.Insert("DELETE FROM Directors WHERE director_id > 9");
            connector.Update("UPDATE Directors SET last_name=N'Tagtgren' WHERE director_id = 8");
            connector.Update("");
            connector.Select("*", "Directors");
            //connector.Insert($"DELETE FROM Directors WHERE director_id = {connector.GetLastPrimaryKey("Directors")}");

            connector.Select
                (
                    "title,release_date,first_name , last_name",
                    "Movies , Directors",
                    "director = director_id"
                );
            Connector connectorAcademy = new Connector(ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString);
            connectorAcademy.Select("*", "Disciplines");
        }
    }
}
