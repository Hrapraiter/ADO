namespace Academy
{
    partial class StudentForm
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
            this.cbStudentsGroups = new System.Windows.Forms.ComboBox();
            this.labelGroup = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStudentsGroups
            // 
            this.cbStudentsGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentsGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbStudentsGroups.FormattingEnabled = true;
            this.cbStudentsGroups.Location = new System.Drawing.Point(474, 335);
            this.cbStudentsGroups.Name = "cbStudentsGroups";
            this.cbStudentsGroups.Size = new System.Drawing.Size(330, 40);
            this.cbStudentsGroups.TabIndex = 18;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelGroup.Location = new System.Drawing.Point(336, 338);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(123, 37);
            this.labelGroup.TabIndex = 19;
            this.labelGroup.Text = "Группа:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 448);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.cbStudentsGroups);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
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
            this.Controls.SetChildIndex(this.labelID, 0);
            this.Controls.SetChildIndex(this.cbStudentsGroups, 0);
            this.Controls.SetChildIndex(this.labelGroup, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStudentsGroups;
        private System.Windows.Forms.Label labelGroup;
    }
}