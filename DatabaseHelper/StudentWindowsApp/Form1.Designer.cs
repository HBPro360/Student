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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowErrors = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbStudentClasses = new System.Windows.Forms.TabPage();
            this.tpStudentAddresses = new System.Windows.Forms.TabPage();
            this.dgvStudentAddress = new System.Windows.Forms.DataGridView();
            this.AdTypes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ZipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpStudentEmails = new System.Windows.Forms.TabPage();
            this.dgvStudentEmail = new System.Windows.Forms.DataGridView();
            this.Types = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Emails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpStudentPhones = new System.Windows.Forms.TabPage();
            this.dgvStudentPhone = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Phones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpStudents = new System.Windows.Forms.TabPage();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.ProgramID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cboSearch2 = new System.Windows.Forms.ComboBox();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Program = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tbStudentClasses.SuspendLayout();
            this.tpStudentAddresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentAddress)).BeginInit();
            this.tpStudentEmails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentEmail)).BeginInit();
            this.tpStudentPhones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentPhone)).BeginInit();
            this.tpStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.mnuSave,
            this.mnuShowErrors});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(136, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuShowErrors
            // 
            this.mnuShowErrors.Name = "mnuShowErrors";
            this.mnuShowErrors.Size = new System.Drawing.Size(136, 22);
            this.mnuShowErrors.Text = "Show Errors";
            this.mnuShowErrors.Click += new System.EventHandler(this.mnuShowErrors_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboSearch2);
            this.tabPage2.Controls.Add(this.cboSearch);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.txtSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 489);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbStudentClasses
            // 
            this.tbStudentClasses.Controls.Add(this.dataGridView1);
            this.tbStudentClasses.Location = new System.Drawing.Point(4, 22);
            this.tbStudentClasses.Name = "tbStudentClasses";
            this.tbStudentClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tbStudentClasses.Size = new System.Drawing.Size(592, 489);
            this.tbStudentClasses.TabIndex = 4;
            this.tbStudentClasses.Text = "Student Classes";
            this.tbStudentClasses.UseVisualStyleBackColor = true;
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
            // AdTypes
            // 
            this.AdTypes.DataPropertyName = "AddressTypeID";
            this.AdTypes.HeaderText = "Address Type";
            this.AdTypes.Name = "AdTypes";
            // 
            // ZipCode
            // 
            this.ZipCode.DataPropertyName = "ZipCode";
            this.ZipCode.HeaderText = "Zip Code";
            this.ZipCode.Name = "ZipCode";
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // tpStudentEmails
            // 
            this.tpStudentEmails.Controls.Add(this.dgvStudentEmail);
            this.tpStudentEmails.Location = new System.Drawing.Point(4, 22);
            this.tpStudentEmails.Name = "tpStudentEmails";
            this.tpStudentEmails.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudentEmails.Size = new System.Drawing.Size(592, 489);
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
            this.dgvStudentEmail.Size = new System.Drawing.Size(586, 483);
            this.dgvStudentEmail.TabIndex = 0;
            // 
            // Types
            // 
            this.Types.DataPropertyName = "EmailTypeID";
            this.Types.HeaderText = "Email Type";
            this.Types.Name = "Types";
            // 
            // Emails
            // 
            this.Emails.DataPropertyName = "Email";
            this.Emails.HeaderText = "Address";
            this.Emails.Name = "Emails";
            // 
            // tpStudentPhones
            // 
            this.tpStudentPhones.Controls.Add(this.dgvStudentPhone);
            this.tpStudentPhones.Location = new System.Drawing.Point(4, 22);
            this.tpStudentPhones.Name = "tpStudentPhones";
            this.tpStudentPhones.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudentPhones.Size = new System.Drawing.Size(592, 489);
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
            this.dgvStudentPhone.Size = new System.Drawing.Size(586, 483);
            this.dgvStudentPhone.TabIndex = 0;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "phoneTypeID";
            this.Type.HeaderText = "Phone Type";
            this.Type.Name = "Type";
            // 
            // Phones
            // 
            this.Phones.DataPropertyName = "Phone";
            this.Phones.HeaderText = "Number";
            this.Phones.Name = "Phones";
            // 
            // tpStudents
            // 
            this.tpStudents.Controls.Add(this.dgvStudent);
            this.tpStudents.Location = new System.Drawing.Point(4, 22);
            this.tpStudents.Name = "tpStudents";
            this.tpStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudents.Size = new System.Drawing.Size(592, 489);
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
            this.dgvStudent.Size = new System.Drawing.Size(586, 483);
            this.dgvStudent.TabIndex = 0;
            // 
            // ProgramID
            // 
            this.ProgramID.DataPropertyName = "ProgramId";
            this.ProgramID.HeaderText = "Program";
            this.ProgramID.Name = "ProgramID";
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Name";
            this.FullName.Name = "FullName";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpStudents);
            this.tabControl1.Controls.Add(this.tpStudentPhones);
            this.tabControl1.Controls.Add(this.tpStudentEmails);
            this.tabControl1.Controls.Add(this.tpStudentAddresses);
            this.tabControl1.Controls.Add(this.tbStudentClasses);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 515);
            this.tabControl1.TabIndex = 0;
            // 
            // cboSearch2
            // 
            this.cboSearch2.FormattingEnabled = true;
            this.cboSearch2.Location = new System.Drawing.Point(165, 52);
            this.cboSearch2.Name = "cboSearch2";
            this.cboSearch2.Size = new System.Drawing.Size(121, 21);
            this.cboSearch2.TabIndex = 8;
            // 
            // cboSearch
            // 
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(16, 25);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(121, 21);
            this.cboSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(318, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(176, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Class,
            this.Program});
            this.dataGridView1.Location = new System.Drawing.Point(-4, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Class
            // 
            this.Class.DataPropertyName = "Class";
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            // 
            // Program
            // 
            this.Program.DataPropertyName = "Program";
            this.Program.HeaderText = "Program";
            this.Program.Name = "Program";
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tbStudentClasses.ResumeLayout(false);
            this.tpStudentAddresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentAddress)).EndInit();
            this.tpStudentEmails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentEmail)).EndInit();
            this.tpStudentPhones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentPhone)).EndInit();
            this.tpStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuShowErrors;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboSearch2;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabPage tbStudentClasses;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewComboBoxColumn Program;
        private System.Windows.Forms.TabPage tpStudentAddresses;
        private System.Windows.Forms.DataGridView dgvStudentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn AdTypes;
        private System.Windows.Forms.TabPage tpStudentEmails;
        private System.Windows.Forms.DataGridView dgvStudentEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emails;
        private System.Windows.Forms.DataGridViewComboBoxColumn Types;
        private System.Windows.Forms.TabPage tpStudentPhones;
        private System.Windows.Forms.DataGridView dgvStudentPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phones;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.TabPage tpStudents;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProgramID;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

