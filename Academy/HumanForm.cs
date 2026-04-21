using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
    public partial class HumanForm : Form
    {
        internal Models.Human human;
        public HumanForm()
        {
            InitializeComponent();
        }
        protected virtual void Compress() 
        {
            human = new Models.Human
                (
                   Convert.ToInt32(labelID.Text == "" ? "0" : labelID.Text.Split(':').Last()),
                   textBoxLastName.Text,
                   textBoxFirstName.Text,
                   textBoxMidleName.Text,
                   $"{dtpBirthDate.Value.Year}-{dtpBirthDate.Value.Month}-{dtpBirthDate.Value.Day}",//dtpBirthDate.Value.ToString("yyyy-mm-dd"), no working
                   textBoxEmail.Text,
                   textBoxPhone.Text,
                   pictureBoxPhoto.Image
                );
        }
        protected virtual void Extract() 
        {
            labelID.Text = $"ID:{human.id}";
            textBoxLastName.Text = human.last_name;
            textBoxFirstName.Text = human.first_name;
            textBoxMidleName.Text = human.middle_name;
            dtpBirthDate.Value = Convert.ToDateTime(human.birth_date);
            textBoxEmail.Text = human.email;
            textBoxPhone.Text = human.phone;
            pictureBoxPhoto.Image = human.photo;
        }
        protected virtual void buttonOk_Click(object sender, EventArgs e)
        {
            Compress();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG files|*.jpg|PNG files|*.png|All image files|*.png;*.jpg;*.jpeg;*.bmp;*.ico|All files|*.*";
            if(dialog.ShowDialog() == DialogResult.OK)
                pictureBoxPhoto.Image = Image.FromFile(dialog.FileName);
        }
    }
}
