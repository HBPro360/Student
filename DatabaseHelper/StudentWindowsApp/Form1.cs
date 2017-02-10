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
using System.Reflection;

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
            cboSearch.SelectedIndexChanged += CboSearch_SelectedIndexChanged;
            cboSearch2.SelectedIndexChanged += CboSearch2_SelectedIndexChanged;
        }

        private void CboSearch2_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentList = new StudentList();
            studentList.Program = cboSearch2.SelectedValue.ToString();
        }

        private void CboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearch.Text == "Program")
            {
                cboSearch2.ValueMember = "ID";
                cboSearch2.DisplayMember = "Name";
                cboSearch2.DataSource = programList.List;

               
            }


        }

        private void DgvStudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            student = studentList.List[e.RowIndex];
            this.Text = student.FullName;
        }

        private void StudentList_Savable(SavableEventArgs e)
        {           
            mnuSave.Enabled = e.Savable;
            mnuShowErrors.Enabled = !e.Savable;
            if (e.Savable == false)
            {
                student.IsSavable();
                // mnuShowErrors.PerformClick();
            }
            
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

            mnuSave.Enabled = false;
            mnuShowErrors.Enabled = false;
            cboSearch.DataSource = StudentList.GetSearchList();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            student.Save();
            mnuSave.Enabled = false;
            mnuShowErrors.Enabled = false;
        }

        private void mnuShowErrors_Click(object sender, EventArgs e)
        {
            if (student.BrokenRules.List.Count > 0)
            {
                frmBrokenRules frm = new frmBrokenRules();
                frm.Show();
                frm.BrokenRules = student.BrokenRules.List;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            if (cboSearch.Text == "FirstName")
            {
                studentList = new StudentList();
                studentList.FirstName = txtSearch.Text;
                studentList = studentList.Search();
            }
            else if (cboSearch.Text == "LastName")
            {
                studentList = new StudentList();
                studentList.LastName = txtSearch.Text;
                studentList = studentList.Search();
            }
            else if (cboSearch.Text == "Phone")
            {
                studentList = new StudentList();
                studentList.Phone = txtSearch.Text;
                studentList = studentList.SearchPhoneList();
            }
            else if (cboSearch.Text == "Email")
            {
                studentList = new StudentList();
                studentList.Email = txtSearch.Text;
                studentList = studentList.SearchEmailList();
            }
            else if (cboSearch.Text == "Address")
            {
                studentList = new StudentList();
                studentList.Address = txtSearch.Text;
                studentList = studentList.SearchAddressList();
            }
            else if (cboSearch.Text == "City")
            {
                studentList = new StudentList();
                studentList.City = txtSearch.Text;
                studentList = studentList.SearchAddressList();
            }
            else if (cboSearch.Text == "State")
            {
                studentList = new StudentList();
                studentList.State = txtSearch.Text;
                studentList = studentList.SearchAddressList();
            }
            else if (cboSearch.Text == "ZipCode")
            {
                studentList = new StudentList();
                studentList.ZipCode = txtSearch.Text;
                studentList = studentList.SearchAddressList();
            }
            else if (cboSearch.Text == "Program")
            {
                studentList = studentList.Search(cboSearch2.SelectedItem.ToString());
            }

            studentList.Savable += StudentList_Savable;
            dgvStudent.DataSource = studentList.List;
        }
       

    }
}
