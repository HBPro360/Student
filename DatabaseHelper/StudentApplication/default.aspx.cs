using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace StudentApplication
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvProgram.RowEditing += GvProgram_RowEditing;
            gvProgram.RowCancelingEdit += GvProgram_RowCancelingEdit;
            gvProgram.RowUpdating += GvProgram_RowUpdating;
            gvProgram.RowDeleting += GvProgram_RowDeleting;
            gvStudent.RowCommand += GvStudent_RowCommand;
            gvStudent.RowEditing += GvStudent_RowEditing;
            gvStudent.RowCancelingEdit += GvStudent_RowCancelingEdit;
            gvStudent.RowUpdating += GvStudent_RowUpdating;
            gvStudent.RowDeleting += GvStudent_RowDeleting;
            gvStudent.RowDataBound += GvStudent_RowDataBound;
            gvStudentPhones.RowDataBound += GvStudentPhones_RowDataBound;
            gvStudentEmails.RowDataBound += GvStudentEmails_RowDataBound;

            if (IsPostBack == false)
            {
                RefreshPrograms();
                RefreshStudents();
                RefreshPhoneType();
                RefreshEmailType();
            }
        }

        private void GvStudentPhones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlPhoneType");
                    
                PhoneTypeList phoneTypes;
                if (Session["PhoneTypes"] != null)
                {
                    phoneTypes = (PhoneTypeList)Session["PhoneTypes"];
                }
                else
                {
                    phoneTypes = new PhoneTypeList();
                }

                ddl.DataSource = phoneTypes.List;
                ddl.DataBind();

                StudentList students;
                if (Session["Students"] != null)
                {
                    students = (StudentList)Session["Students"];
                }
                else
                {
                    students = new StudentList();
                }

                int Rowindex = (int)Session["StudentRowIndex"];

                Student student = students.List[Rowindex];
                ddl.SelectedValue = student.Phones.List[e.Row.RowIndex].PhoneTypeID.ToString();
            }
        }

        private void GvStudentEmails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlEmailType");

                EmailTypeList emailTypes;
                if (Session["EmailTypes"] != null)
                {
                    emailTypes = (EmailTypeList)Session["EmailTypes"];
                }
                else
                {
                    emailTypes = new EmailTypeList();
                }

                ddl.DataSource = emailTypes.List;
                ddl.DataBind();

                StudentList students;
                if (Session["Students"] != null)
                {
                    students = (StudentList)Session["Students"];
                }
                else
                {
                    students = new StudentList();
                }

                int Rowindex = (int)Session["StudentRowIndex"];

                Student student = students.List[Rowindex];
                ddl.SelectedValue = student.Emails.List[e.Row.RowIndex].EmailTypeID.ToString();
            }
        }


        #region Student

        private void GvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Phone
            if (e.CommandName == "AddPhone")
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                StudentList students;
                if (Session["Students"] != null)
                {
                    students = (StudentList)Session["Students"];
                }
                else
                {
                    students = new StudentList();
                }
                Student student = students.List[gvr.RowIndex];

                StudentPhone studentPhone = new StudentPhone();
                studentPhone.PhoneTypeID = new Guid(ddlPhoneType.SelectedValue);
                studentPhone.Phone = txtNumber.Text;

                student.Phones.List.Add(studentPhone);
                student.Save();
            }

            if (e.CommandName == "ShowPhone")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                Session.Add("StudentRowIndex", rowIndex);
                StudentList students;
                if (Session["Students"] != null)
                {
                    students = (StudentList)Session["Students"];
                }
                else
                {
                    students = new StudentList();
                }
                Student student = students.List[rowIndex];

                gvStudentPhones.DataSource = student.Phones.List;
                gvStudentPhones.DataBind();
                
            }
            #endregion
            if (e.CommandName == "AddEmail")
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                StudentList students;
                if (Session["Students"] != null)
                {
                    students = (StudentList)Session["Students"];
                }
                else
                {
                    students = new StudentList();
                }
                Student student = students.List[gvr.RowIndex];                    

                StudentEmail studentEmail = new StudentEmail();
                studentEmail.EmailTypeID = new Guid(ddlEmailType.SelectedValue);
                studentEmail.Email = txtEmail.Text;

                student.Emails.List.Add(studentEmail);
                student.Save();
            }

            else if (e.CommandName == "ShowEmail")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                Session.Add("StudentRowIndex", rowIndex);
                StudentList students;
                if (Session["Students"] != null)
                {
                    students = (StudentList)Session["Students"];
                }
                else
                {
                    students = new StudentList();
                }
                Student student = students.List[rowIndex];

                gvStudentEmails.DataSource = student.Emails.List;
                gvStudentEmails.DataBind();

            }
        }

        private void GvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlprograms");
                ProgramList programs;
                if (Session["Programs"] != null)
                {
                    programs = (ProgramList)Session["Programs"];
                }
                else
                {
                    programs = new ProgramList();
                }

                Student student = (Student)e.Row.DataItem;

                ddl.SelectedValue = student.ProgramID.ToString();
                ddl.DataSource = programs.List;
                ddl.DataBind();
            }
        }

        private void GvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            StudentList students;
            if (Session["Students"] != null)
            {
                students = (StudentList)Session["Students"];
            }
            else
            {
                students = new StudentList();
            }

            students.List[e.RowIndex].Deleted = true;
            students.Save();
            RefreshStudents();
        }

        private void GvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtFirstName = (TextBox)gvStudent.Rows[e.RowIndex].FindControl("txtFirstName");
            TextBox txtLastName = (TextBox)gvStudent.Rows[e.RowIndex].FindControl("txtLastName");
            TextBox txtEmail = (TextBox)gvStudent.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox txtPassword = (TextBox)gvStudent.Rows[e.RowIndex].FindControl("txtPassword");
            DropDownList ddlPrograms = (DropDownList)gvStudent.Rows[e.RowIndex].FindControl("ddlPrograms");

            StudentList students;
            if (Session["Students"] != null)
            {
                students = (StudentList)Session["Students"];
            }
            else
            {
                students = new StudentList();
            }

            students.List[e.RowIndex].FirstName = txtFirstName.Text;
            students.List[e.RowIndex].LastName = txtLastName.Text;
            students.List[e.RowIndex].Email = txtEmail.Text;
            students.List[e.RowIndex].Password = txtPassword.Text;
            students.List[e.RowIndex].ProgramID = new Guid(ddlPrograms.SelectedValue);
            students.Save();
            gvStudent.EditIndex = -1;
            RefreshStudents();
        }

        private void GvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudent.EditIndex = -1;
            RefreshStudents();
        }

        private void GvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudent.EditIndex = e.NewEditIndex;
            RefreshStudents();

            for (int i = 0; i < gvStudent.Rows.Count; i++)
            {
                LinkButton lnkEdit = (LinkButton)gvStudent.Rows[i].FindControl("btnedit");
                if (lnkEdit != null)
                {
                    lnkEdit.Visible = false;
                }
                LinkButton lnkDelete = (LinkButton)gvStudent.Rows[i].FindControl("btndelete");
                lnkDelete.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.FirstName = txtFirstName.Text;
            student.LastName = txtLastName.Text;
            student.Password = txtPassword.Text;
            student.Email = txtEmail.Text;
            StudentEmail studentEmail = new StudentEmail();
            studentEmail.Email = txtEmail.Text;
            studentEmail.EmailTypeID = new Guid(ddlEmailType.SelectedValue);
            student.Emails.List.Add(studentEmail);
            StudentPhone studentPhone = new StudentPhone();
            studentPhone.Phone = txtNumber.Text;
            studentPhone.PhoneTypeID = new Guid(ddlPhoneType.SelectedValue);
            student.Phones.List.Add(studentPhone);
            if (student.IsSavable() == true)
            {
                student.Save();
                RefreshStudents();
            }
        }
        private void RefreshStudents()
        {
            StudentList students = new StudentList();
            students = students.GetAll();
            this.gvStudent.DataSource = students.List;
            this.gvStudent.DataBind();
            Session["Students"] = students;
        }
        #endregion

        #region Program

        private void GvProgram_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProgramList programs;
            if (Session["Programs"] != null)
            {
                programs = (ProgramList)Session["Programs"];
            }
            else
            {
                programs = new ProgramList();
            }

            programs.List[e.RowIndex].Deleted = true;
            programs.Save();
            RefreshPrograms();
        }

        private void GvProgram_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtName = (TextBox)gvProgram.Rows[e.RowIndex].FindControl("txtName");

            ProgramList programs;
            if (Session["Programs"] != null)
            {
                programs = (ProgramList)Session["Programs"];
            }
            else
            {
                programs = new ProgramList();
            }

            programs.List[e.RowIndex].Name = txtName.Text;
            programs.Save();
            gvProgram.EditIndex = -1;
            RefreshPrograms();
        }

        private void GvProgram_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProgram.EditIndex = -1;
            RefreshPrograms();
        }

        private void GvProgram_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProgram.EditIndex = e.NewEditIndex;
            RefreshPrograms();

            for (int i = 0; i < gvProgram.Rows.Count; i++)
            {
                LinkButton lnkEdit = (LinkButton)gvProgram.Rows[i].FindControl("btnedit");
                if (lnkEdit != null)
                {
                    lnkEdit.Visible = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Program program = new Program();
            //program.Name = txtName.Text;
            //if (program.IsSavable() == true)
            //{
            //    program.Save();
            //    RefreshPrograms();
            //}
            Program program = new Program();
            program.Name = txtName.Text;
            ProgramList programs;
            if (Session["Programs"] != null)
            {
                programs = (ProgramList)Session["Programs"];
            }
            else
            {
                programs = new ProgramList();
            }
            programs.List.Add(program);

            programs.Save();

            RefreshPrograms();
        }
        private void RefreshPrograms()
        {
            ProgramList programs = new ProgramList();
            programs = programs.GetAll();
            this.gvProgram.DataSource = programs.List;
            this.gvProgram.DataBind();
            Session["Programs"] = programs;
        }

        #endregion

        private void RefreshPhoneType()
        {
            PhoneTypeList phonetypes = new PhoneTypeList();
            phonetypes = phonetypes.GetAll();
            this.ddlPhoneType.DataSource = phonetypes.List;
            this.ddlPhoneType.DataBind();
            Session["PhoneTypes"] = phonetypes;
        }

        private void RefreshEmailType()
        {
            EmailTypeList emailtypes = new EmailTypeList();
            emailtypes = emailtypes.GetAll();
            this.ddlEmailType.DataSource = emailtypes.List;
            this.ddlEmailType.DataBind();
            Session["EmailTypes"] = emailtypes;
        }

        protected void gvStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}