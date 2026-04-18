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
    public partial class TeacherForm : HumanForm
    {
        Models.Teacher teacher;
        public TeacherForm()
        {
            InitializeComponent();
        }
        public TeacherForm(int id) : this()
        {
            object[] values = DataBase.Connector.Load($"SELECT * FROM Teachers WHERE teacher_id = {id}").Rows[0].ItemArray;
            teacher = new Models.Teacher(values);
            human = teacher;
            Extract();
        }
        protected override void Extract()
        {
            base.Extract();
            dtpWorkSince.Value = Convert.ToDateTime(teacher.work_since);
            textBoxRate.Text = teacher.rate.ToString();
        }
        protected override void buttonOk_Click(object sender, EventArgs e) 
        {
            base.buttonOk_Click(sender, e);

            decimal valid_decimal = Convert.ToDecimal
                (
                    (valid_decimal = textBoxRate.Text.IndexOf(',')) != -1
                    ? textBoxRate.Text.Substring(0, (int)valid_decimal)
                    : textBoxRate.Text
                );

            teacher = new Models.Teacher(human,dtpWorkSince.Value.ToString("yyyy-MM-dd") ,valid_decimal);
            if (teacher.id == 0)
                teacher.id = Convert.ToInt32(DataBase.Connector.Scalar($"INSERT Teachers(teacher_id,{teacher.GetNames()})" +
                    $" VALUES ((SELECT MAX(teacher_id)+1 FROM Teachers),{teacher.GetValues()});SELECT MAX(teacher_id) FROM Teachers"));
            else 
                DataBase.Connector.Update($"UPDATE Teachers SET {teacher.GetUpdateString()} WHERE teacher_id = {teacher.id}");
        }
    }
}
