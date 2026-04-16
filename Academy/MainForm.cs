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
using Academy.Models;

namespace Academy
{
    public partial class MainForm : Form
    {
        Connector connector;
        DataGridView[] tables;
        Query[] queries =
            {
                new Query
                (
                    "stud_id , last_name , first_name , middle_name ,birth_date, group_name , direction_name",
                    "Students, Groups , Directions",
                    "[group] = group_id AND direction = direction_id"
                ),
                new Query
                (
                    "group_id,group_name,start_date,start_time,learning_days,direction_name",
                    "Groups,Directions",
                    "direction = direction_id"
                ),
                new Query("*" , "Directions"),
                new Query("*" , "Disciplines"),
                new Query("*" , "Teachers")
            };
        public MainForm()
        {
            InitializeComponent();
            connector = new Connector(ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString);
            dgvDirections.DataSource = connector.Select("SELECT * FROM Directions");
            tables = new DataGridView[]
            {
                dgvStudents,
                dgvGroups,
                dgvDirections,
                dgvDisciplines,
                dgvTeachers
            };
            tabControl_SelectedIndexChanged(tabControl, null);

            cbGroupsDirection.DataSource = connector.Load("SELECT * FROM Directions");
            cbGroupsDirection.DisplayMember = "direction_name";
            cbGroupsDirection.ValueMember = "direction_id";

            
        }

        private void labelUpdate(int indexTable) => toolStripStatusLabel.Text = $"Колличество записей: {tables[indexTable].RowCount - 1}";
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = (sender as TabControl).SelectedIndex;
            tables[i].DataSource = connector.Load(queries[i].ToString());
            labelUpdate(i);
        }

        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelUpdate(1);
        }
        private void cbGroupsDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvGroups.DataSource = connector.Load(queries[1].ToString() + $" AND direction={cbGroupsDirection.SelectedValue}");
            labelUpdate(1);
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            StudentForm human = new StudentForm();
            if (human.ShowDialog() == DialogResult.OK) 
                tabControl_SelectedIndexChanged(tabControl, null);
            
        }

        private void dgvStudents_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int stud_id = (int)dgvStudents.CurrentRow.Cells[0].Value;
            object[] values = connector.Load
                ($"SELECT first_name , middle_name , last_name , birth_date , email , phone , photo , [group]" +
                $"  FROM Students WHERE stud_id = {stud_id}").Rows[0].ItemArray;
            DateTime birth_date = (DateTime)values[3];

            Student student = new Student
                (
                    stud_id,
                    (string)values[0],
                    Convert.IsDBNull(values[1]) ? null : (string)values[1],
                    (string)values[2],
                    $"{birth_date.Year}-{birth_date.Month}-{birth_date.Day}",
                    Convert.IsDBNull(values[4]) ? null : (string)values[4],
                    Convert.IsDBNull(values[5]) ? null : (string)values[5],
                    Convert.IsDBNull(values[6]) ? null : (Image)values[6],
                    Convert.IsDBNull(values[7]) ? 0    : (int)values[7]
                );
            StudentForm studentForm = new StudentForm(StudentForm.CallStatus.Update);
            studentForm.SetStudetAndGUIValues(student);

            if (studentForm.ShowDialog() == DialogResult.OK)
                tabControl_SelectedIndexChanged(tabControl, null);


        }
    }
}
