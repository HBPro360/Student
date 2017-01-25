namespace StudentWindowsApp
{
    partial class frmStudent
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpStudents = new System.Windows.Forms.TabPage();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tpStudentPhones = new System.Windows.Forms.TabPage();
            this.dgvStudentPhone = new System.Windows.Forms.DataGridView();
            this.Phones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tpStudentEmails = new System.Windows.Forms.TabPage();
            this.dgvStudentEmail = new System.Windows.Forms.DataGridView();
            this.Emails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Types = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tpStudentAddresses = new System.Windows.Forms.TabPage();
            this.dgvStudentAddress = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdTypes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.tpStudentPhones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentPhone)).BeginInit();
            this.tpStudentEmails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentEmail)).BeginInit();
            this.tpStudentAddresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentAddress)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpStudents);
            this.tabControl1.Controls.Add(this.tpStudentPhones);
            this.tabControl1.Controls.Add(this.tpStudentEmails);
            this.tabControl1.Controls.Add(this.tpStudentAddresses);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 515);
            this.tabControl1.TabIndex = 0;
            // 
            // tpStudents
            // 
            this.tpStudents.Controls.Add(this.dgvStudent);
            this.tpStudents.Location = new System.Drawing.Point(4, 22);
            this.tpStudents.Name = "tpStudents";
            this.tpStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudents.Size = new System.Drawing.Size(592, 513);
            this.tpStudents.TabIndex = 0;
            this.tpStudents.Text = "Students";
            this.tpStudents.UseVisualStyleBackColor = true;
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.Email,
            this.Password,
            this.ProgramID});
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(3, 3);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.Size = new System.Drawing.Size(586, 507);
            this.dgvStudent.TabIndex = 0;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Name";
            this.FullName.Name = "FullName";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // ProgramID
            // 
            this.ProgramID.DataPropertyName = "ProgramId";
            this.ProgramID.HeaderText = "Program";
            this.ProgramID.Name = "ProgramID";
            // 
            // tpStudentPhones
            // 
            this.tpStudentPhones.Controls.Add(this.dgvStudentPhone);
            this.tpStudentPhones.Location = new System.Drawing.Point(4, 22);
            this.tpStudentPhones.Name = "tpStudentPhones";
            this.tpStudentPhones.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudentPhones.Size = new System.Drawing.Size(592, 513);
            this.tpStudentPhones.TabIndex = 1;
            this.tpStudentPhones.Text = "Student Phones";
            this.tpStudentPhones.UseVisualStyleBackColor = true;
            // 
            // dgvStudentPhone
            // 
            this.dgvStudentPhone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentPhone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Phones,
            this.Type});
            this.dgvStudentPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentPhone.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dgvStudentPhone.Location = new System.Drawing.Point(3, 3);
            this.dgvStudentPhone.Name = "dgvStudentPhone";
            this.dgvStudentPhone.Size = new System.Drawing.Size(586, 507);
            this.dgvStudentPhone.TabIndex = 0;
            // 
            // Phones
            // 
            this.Phones.DataPropertyName = "Phone";
            this.Phones.HeaderText = "Number";
            this.Phones.Name = "Phones";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "phoneTypeID";
            this.Type.HeaderText = "Phone Type";
            this.Type.Name = "Type";
            // 
            // tpStudentEmails
            // 
            this.tpStudentEmails.Controls.Add(this.dgvStudentEmail);
            this.tpStudentEmails.Location = new System.Drawing.Point(4, 22);
            this.tpStudentEmails.Name = "tpStudentEmails";
            this.tpStudentEmails.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudentEmails.Size = new System.Drawing.Size(592, 513);
            this.tpStudentEmails.TabIndex = 2;
            this.tpStudentEmails.Text = "Student Emails";
            this.tpStudentEmails.UseVisualStyleBackColor = true;
            // 
            // dgvStudentEmail
            // 
            this.dgvStudentEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Emails,
            this.Types});
            this.dgvStudentEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentEmail.Location = new System.Drawing.Point(3, 3);
            this.dgvStudentEmail.Name = "dgvStudentEmail";
            this.dgvStudentEmail.Size = new System.Drawing.Size(586, 507);
            this.dgvStudentEmail.TabIndex = 0;
            // 
            // Emails
            // 
            this.Emails.DataPropertyName = "Email";
            this.Emails.HeaderText = "Address";
            this.Emails.Name = "Emails";
            // 
            // Types
            // 
            this.Types.DataPropertyName = "EmailTypeID";
            this.Types.HeaderText = "Email Type";
            this.Types.Name = "Types";
            // 
            // tpStudentAddresses
            // 
            this.tpStudentAddresses.Controls.Add(this.dgvStudentAddress);
            this.tpStudentAddresses.Location = new System.Drawing.Point(4, 22);
            this.tpStudentAddresses.Name = "tpStudentAddresses";
            this.tpStudentAddresses.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudentAddresses.Size = new System.Drawing.Size(592, 489);
            this.tpStudentAddresses.TabIndex = 3;
            this.tpStudentAddresses.Text = "Student Addresses";
            this.tpStudentAddresses.UseVisualStyleBackColor = true;
            // 
            // dgvStudentAddress
            // 
            this.dgvStudentAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.City,
            this.State,
            this.ZipCode,
            this.AdTypes});
            this.dgvStudentAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentAddress.Location = new System.Drawing.Point(3, 3);
            this.dgvStudentAddress.Name = "dgvStudentAddress";
            this.dgvStudentAddress.Size = new System.Drawing.Size(586, 483);
            this.dgvStudentAddress.TabIndex = 0;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // ZipCode
            // 
            this.ZipCode.DataPropertyName = "ZipCode";
            this.ZipCode.HeaderText = "Zip Code";
            this.ZipCode.Name = "ZipCode";
            // 
            // AdTypes
            // 
            this.AdTypes.DataPropertyName = "AddressTypeID";
            this.AdTypes.HeaderText = "Address Type";
            this.AdTypes.Name = "AdTypes";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(152, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 539);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmStudent";
            this.Text = "Student Information";
            this.Load += new System.EventHandler(this.frmStudent_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.tpStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.tpStudentPhones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentPhone)).EndInit();
            this.tpStudentEmails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentEmail)).EndInit();
            this.tpStudentAddresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentAddress)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpStudents;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.TabPage tpStudentPhones;
        private System.Windows.Forms.DataGridView dgvStudentPhone;
        private System.Windows.Forms.TabPage tpStudentEmails;
        private System.Windows.Forms.DataGridView dgvStudentEmail;
        private System.Windows.Forms.TabPage tpStudentAddresses;
        private System.Windows.Forms.DataGridView dgvStudentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProgramID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phones;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emails;
        private System.Windows.Forms.DataGridViewComboBoxColumn Types;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn AdTypes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
    }
}

