using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;

namespace StudentWindowsApp
{
    public partial class frmStudent : Form
    {
        StudentList studentList;
        ProgramList programList;
        PhoneTypeList phoneTypeList;
        EmailTypeList emailTypeList;
        AddressTypeList addressTypeList;
        Student student;

        public frmStudent()
        {
            InitializeComponent();
            dgvStudent.RowHeaderMouseDoubleClick += DgvStudent_RowHeaderMouseDoubleClick;
            dgvStudent.CellFormatting += DgvStudent_CellFormatting;
            dgvStudentPhone.CellFormatting += DgvStudentPhone_CellFormatting;
            dgvStudentEmail.CellFormatting += DgvStudentEmail_CellFormatting;
            dgvStudentAddress.CellFormatting += DgvStudentAddress_CellFormatting;
            dgvStudentAddress.CellValueChanged += DgvStudentAddress_CellValueChanged;
            dgvStudent.DataError += DgvStudent_DataError;
            dgvStudentPhone.DataError += DgvStudentPhone_DataError;
            dgvStudentEmail.DataError += DgvStudentEmail_DataError;
            dgvStudentAddress.DataError += DgvStudentAddress_DataError;
            dgvStudent.CellMouseClick += DgvStudent_CellMouseClick;
        }

        private void DgvStudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            student = studentList.List[e.RowIndex];
            this.Text = student.FullName;
        }

        private void StudentList_Savable(SavableEventArgs e)
        {
            mnuSave.Enabled = e.Savable;
        }

        private void DgvStudentAddress_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvStudentAddress.Refresh();
        }

        private void DgvStudent_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            student = studentList.List[e.RowIndex];
            dgvStudentPhone.DataSource = student.Phones.List;
            dgvStudentEmail.DataSource = student.Emails.List;
            dgvStudentAddress.DataSource = student.Addresses.List;
            this.Text = student.FullName;
            

        }

        private void DgvStudent_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Ignore error
        }

        private void DgvStudent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                BindProgramList((DataGridViewComboBoxColumn)dgvStudent.Columns[e.ColumnIndex]);
            }
        }
        
        private void BindProgramList(DataGridViewComboBoxColumn column)
        {
            if (column.DataSource == null)
            {
                column.DisplayMember = "Name";
                column.ValueMember = "ID";
                column.DataSource = programList.List;
            }            
        }

        private void DgvStudentPhone_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                BindPhoneTypeList((DataGridViewComboBoxColumn)dgvStudentPhone.Columns[e.ColumnIndex]);
            }
        }

        private void BindPhoneTypeList(DataGridViewComboBoxColumn column)
        {
            if (column.DataSource == null)
            {
                column.DisplayMember = "Type";
                column.ValueMember = "ID";
                column.DataSource = phoneTypeList.List;
            }
        }

        private void DgvStudentPhone_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Ignore Error
        }

        private void DgvStudentEmail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                BindEmailTypeList((DataGridViewComboBoxColumn)dgvStudentEmail.Columns[e.ColumnIndex]);
            }
        }

        private void BindEmailTypeList(DataGridViewComboBoxColumn column)
        {
            if (column.DataSource == null)
            {
                column.DisplayMember = "Type";
                column.ValueMember = "ID";
                column.DataSource = emailTypeList.List;
            }
        }

        private void DgvStudentEmail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Ignore Error
        }

        private void BindAddressTypeList(DataGridViewComboBoxColumn column)
        {
            if (column.DataSource == null)
            {
                column.DisplayMember = "Type";
                column.ValueMember = "ID";
                column.DataSource = addressTypeList.List;
            }
        }

        private void DgvStudentAddress_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                BindAddressTypeList((DataGridViewComboBoxColumn)dgvStudentAddress.Columns[e.ColumnIndex]);
            }
        }

        private void DgvStudentAddress_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Ignore Error
        }


        private void frmStudent_Load_1(object sender, EventArgs e)
        {
            dgvStudent.AutoGenerateColumns = false;
            dgvStudentAddress.AutoGenerateColumns = false;
            dgvStudentEmail.AutoGenerateColumns = false;
            dgvStudentPhone.AutoGenerateColumns = false;
            programList = new ProgramList();
            programList = programList.GetAll();
            phoneTypeList = new PhoneTypeList();
            phoneTypeList = phoneTypeList.GetAll();
            emailTypeList = new EmailTypeList();
            emailTypeList = emailTypeList.GetAll();
            addressTypeList = new AddressTypeList();
            addressTypeList = addressTypeList.GetAll();
            studentList = new StudentList();
            studentList = studentList.GetAll();
            studentList.Savable += StudentList_Savable;
            dgvStudent.DataSource = studentList.List;
            mnuSave.Enabled = false;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            student.Save();
            mnuSave.Enabled = false;
        }
    }
}
