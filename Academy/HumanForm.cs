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
        void Compress() 
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
        protected virtual void buttonOk_Click(object sender, EventArgs e)
        {
            Compress();
        }
    }
}
