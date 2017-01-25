using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace StudentApplication
{
    public partial class PhoneTypeTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvPhoneType.RowDeleting += GvPhoneType_RowDeleting;
            gvPhoneType.RowEditing += GvPhoneType_RowEditing;
            gvPhoneType.RowUpdating += GvPhoneType_RowUpdating;
            gvPhoneType.RowCancelingEdit += GvPhoneType_RowCancelingEdit;

            if (IsPostBack == false)
            {
                RefreshPhoneType();
            }
        }

        private void GvPhoneType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PhoneTypeList phonetypes;
            if (Session["PhoneTypes"] != null)
            {
                phonetypes = (PhoneTypeList)Session["PhoneTypes"];
            }
            else
            {
                phonetypes = new PhoneTypeList();
            }

            phonetypes.List[e.RowIndex].Deleted = true;
            phonetypes.Save();
            RefreshPhoneType();
        }
        private void GvPhoneType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneType.EditIndex = e.NewEditIndex;
            RefreshPhoneType();

            for (int i = 0; i < gvPhoneType.Rows.Count; i++)
            {
                LinkButton lnkEdit = (LinkButton)gvPhoneType.Rows[i].FindControl("btnedit");
                if (lnkEdit != null)
                {
                    lnkEdit.Visible = false;
                }
            }
        }
        private void GvPhoneType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtType = (TextBox)gvPhoneType.Rows[e.RowIndex].FindControl("txtType");

            PhoneTypeList phonetypes;
            if (Session["PhoneTypes"] != null)
            {
                phonetypes = (PhoneTypeList)Session["PhoneTypes"];
            }
            else
            {
                phonetypes = new PhoneTypeList();
            }

            phonetypes.List[e.RowIndex].Type = txtType.Text;
            phonetypes.Save();
            gvPhoneType.EditIndex = -1;
            RefreshPhoneType();
        }
        private void GvPhoneType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneType.EditIndex = -1;
            RefreshPhoneType();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PhoneType phonetype = new PhoneType();
            phonetype.Type = txtType.Text;
            PhoneTypeList phonetypes;
            if (Session["PhoneTypes"] != null)
            {
                phonetypes = (PhoneTypeList)Session["PhoneTypes"];
            }
            else
            {
                phonetypes = new PhoneTypeList();
            }
            phonetypes.List.Add(phonetype);

            phonetypes.Save();

            txtType.Text = "";

            RefreshPhoneType();
        }

        private void RefreshPhoneType()
        {
            PhoneTypeList phonetypes = new PhoneTypeList();
            phonetypes = phonetypes.GetAll();
            this.gvPhoneType.DataSource = phonetypes.List;
            this.gvPhoneType.DataBind();
            Session["PhoneTypes"] = phonetypes;
        }
    }
}