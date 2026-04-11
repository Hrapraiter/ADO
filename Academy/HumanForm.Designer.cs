namespace Academy
{
    partial class HumanForm
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
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelMidleName = new System.Windows.Forms.Label();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxMidleName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelLastName.Location = new System.Drawing.Point(315, 9);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(153, 37);
            this.labelLastName.TabIndex = 0;
            this.labelLastName.Text = "Фамилия:";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelFirstName.Location = new System.Drawing.Point(391, 63);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(87, 37);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "Имя:";
            // 
            // labelMidleName
            // 
            this.labelMidleName.AutoSize = true;
            this.labelMidleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelMidleName.Location = new System.Drawing.Point(315, 119);
            this.labelMidleName.Name = "labelMidleName";
            this.labelMidleName.Size = new System.Drawing.Size(160, 37);
            this.labelMidleName.TabIndex = 2;
            this.labelMidleName.Text = "Отчество:";
            // 
            // labelBirthDate
            // 
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelBirthDate.Location = new System.Drawing.Point(222, 171);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(246, 37);
            this.labelBirthDate.TabIndex = 3;
            this.labelBirthDate.Text = "Дата рождения:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelEmail.Location = new System.Drawing.Point(362, 227);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(116, 37);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "E-mail:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelPhone.Location = new System.Drawing.Point(318, 279);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(150, 37);
            this.labelPhone.TabIndex = 5;
            this.labelPhone.Text = "Телефон:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxLastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxLastName.Location = new System.Drawing.Point(474, 9);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(330, 39);
            this.textBoxLastName.TabIndex = 6;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxFirstName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxFirstName.Location = new System.Drawing.Point(474, 63);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(330, 39);
            this.textBoxFirstName.TabIndex = 7;
            // 
            // textBoxMidleName
            // 
            this.textBoxMidleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxMidleName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxMidleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxMidleName.Location = new System.Drawing.Point(474, 117);
            this.textBoxMidleName.Name = "textBoxMidleName";
            this.textBoxMidleName.Size = new System.Drawing.Size(330, 39);
            this.textBoxMidleName.TabIndex = 8;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxEmail.Location = new System.Drawing.Point(474, 225);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(330, 39);
            this.textBoxEmail.TabIndex = 10;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxPhone.Location = new System.Drawing.Point(474, 279);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(330, 39);
            this.textBoxPhone.TabIndex = 11;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dtpBirthDate.CustomFormat = "yyyy.MMMM.dd";
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(474, 171);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(330, 39);
            this.dtpBirthDate.TabIndex = 12;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(16, 9);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(191, 160);
            this.pictureBoxPhoto.TabIndex = 13;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonBrowse.Location = new System.Drawing.Point(15, 178);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(192, 46);
            this.buttonBrowse.TabIndex = 14;
            this.buttonBrowse.Text = "Обзор";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonOk.Location = new System.Drawing.Point(474, 395);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(157, 46);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonCancel.Location = new System.Drawing.Point(647, 395);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(157, 46);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelID.Location = new System.Drawing.Point(427, 432);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 37);
            this.labelID.TabIndex = 17;
            // 
            // HumanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 446);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxMidleName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelBirthDate);
            this.Controls.Add(this.labelMidleName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.labelLastName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HumanForm";
            this.Text = "HumanForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelMidleName;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxMidleName;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelID;
    }
}