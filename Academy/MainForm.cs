using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Configuration;
using DBtools;

namespace Academy
{
    public partial class MainForm : Form
    {
        Connector connector;
        public MainForm()
        {
            InitializeComponent();
            connector = new Connector(ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString);
            
            Func<string, DataTable> casheSelect = table_name => connector.Select($"SELECT * FROM {table_name}");
            
            dgvStudents     .DataSource   = casheSelect("Students");
            dgvGroups       .DataSource   = casheSelect("Groups");
            dgvDirections   .DataSource   = casheSelect("Directions");
            dgvDiscipliens  .DataSource   = casheSelect("Disciplines");
            dgvTeachers     .DataSource   = casheSelect("Teachers");


        }
    }
}
