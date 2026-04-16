using DBtools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
    public partial class StudentForm : HumanForm
    {
        public enum CallStatus 
        {
            Insert,
            Update
        };
        public CallStatus status { get; }
        internal Models.Student student;
        
        public StudentForm(CallStatus status = CallStatus.Insert)
        {
            InitializeComponent();
            
            this.status = status;

            cbStudentsGroups.DataSource = DataBase.Connector.Load("SELECT * FROM Groups");
            cbStudentsGroups.DisplayMember = "group_name";
            cbStudentsGroups.ValueMember = "group_id";
        }
        internal void SetStudetAndGUIValues(Models.Student _student) 
        {
            student = _student;
            base.textBoxFirstName.Text = student.first_name;
            base.textBoxMidleName.Text = student.middle_name;
            base.textBoxLastName.Text = student.last_name;
            base.textBoxEmail.Text = student.email;
            base.textBoxPhone.Text = student.phone;
            //this.cbStudentsGroups = student.group;

            base.dtpBirthDate.Value = DateTime.Parse(student.birth_date);

            base.pictureBoxPhoto.Image = student.photo;

        }
        protected override void buttonOk_Click(object sender, EventArgs e)
        {

            base.labelID.Text = student.id.ToString();
            base.buttonOk_Click(sender, e);
            student = new Models.Student(human, (int)cbStudentsGroups.SelectedValue);

            switch (status) 
            {
                case CallStatus.Insert:
                    {
                        if (student.id == 0) student.id =
                        Convert.ToInt32(DataBase.Connector.Scalar
                        (
                            $"INSERT Students({student.GetNames()}) VALUES ({student.GetValues()});SELECT SCOPE_IDENTITY();"
                        ));
                    }
                break;
                case CallStatus.Update:
                    
                    //MessageBox.Show($"Students\n {student.GetNames()}\n {student.GetValues()}\n stud_id = {student.id}");
                    DataBase.Connector.Update("Students" , student.GetNames() , student.GetValues() , $"stud_id = {student.id}");
                break;
            }
            
        }
    }
}
