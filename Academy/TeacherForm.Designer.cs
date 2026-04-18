namespace Academy
{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpWorkSince = new System.Windows.Forms.DateTimePicker();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.labelWorkSince = new System.Windows.Forms.Label();
            this.labelRate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(474, 452);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(647, 452);
            // 
            // labelID
            // 
            this.labelID.Location = new System.Drawing.Point(23, 436);
            // 
            // dtpWorkSince
            // 
            this.dtpWorkSince.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dtpWorkSince.CustomFormat = "yyyy.MMMM.dd";
            this.dtpWorkSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dtpWorkSince.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWorkSince.Location = new System.Drawing.Point(474, 335);
            this.dtpWorkSince.Name = "dtpWorkSince";
            this.dtpWorkSince.Size = new System.Drawing.Size(330, 39);
            this.dtpWorkSince.TabIndex = 18;
            // 
            // textBoxRate
            // 
            this.textBoxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxRate.Location = new System.Drawing.Point(474, 391);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(190, 39);
            this.textBoxRate.TabIndex = 19;
            // 
            // labelWorkSince
            // 
            this.labelWorkSince.AutoSize = true;
            this.labelWorkSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelWorkSince.Location = new System.Drawing.Point(130, 335);
            this.labelWorkSince.Name = "labelWorkSince";
            this.labelWorkSince.Size = new System.Drawing.Size(320, 37);
            this.labelWorkSince.TabIndex = 20;
            this.labelWorkSince.Text = "Дата начала работы:";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelRate.Location = new System.Drawing.Point(295, 391);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(164, 37);
            this.labelRate.TabIndex = 21;
            this.labelRate.Text = "Зарплата:";
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 510);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.labelWorkSince);
            this.Controls.Add(this.textBoxRate);
            this.Controls.Add(this.dtpWorkSince);
            this.Name = "TeacherForm";
            this.Text = "TeacherForm";
            this.Controls.SetChildIndex(this.labelLastName, 0);
            this.Controls.SetChildIndex(this.labelFirstName, 0);
            this.Controls.SetChildIndex(this.labelMidleName, 0);
            this.Controls.SetChildIndex(this.labelBirthDate, 0);
            this.Controls.SetChildIndex(this.labelEmail, 0);
            this.Controls.SetChildIndex(this.labelPhone, 0);
            this.Controls.SetChildIndex(this.textBoxLastName, 0);
            this.Controls.SetChildIndex(this.textBoxFirstName, 0);
            this.Controls.SetChildIndex(this.textBoxMidleName, 0);
            this.Controls.SetChildIndex(this.textBoxEmail, 0);
            this.Controls.SetChildIndex(this.textBoxPhone, 0);
            this.Controls.SetChildIndex(this.dtpBirthDate, 0);
            this.Controls.SetChildIndex(this.pictureBoxPhoto, 0);
            this.Controls.SetChildIndex(this.buttonBrowse, 0);
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.labelID, 0);
            this.Controls.SetChildIndex(this.dtpWorkSince, 0);
            this.Controls.SetChildIndex(this.textBoxRate, 0);
            this.Controls.SetChildIndex(this.labelWorkSince, 0);
            this.Controls.SetChildIndex(this.labelRate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpWorkSince;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.Label labelWorkSince;
        private System.Windows.Forms.Label labelRate;
    }
}