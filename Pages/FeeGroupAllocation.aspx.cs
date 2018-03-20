using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FeeGroupAllocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFeeWaiverType.Focus();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            ddlFeeWaiverType.DataSource = s.SetDropdownListCDB(7);
            ddlFeeWaiverType.DataTextField = "FeeWaiverType";
            ddlFeeWaiverType.DataValueField = "Id";
            ddlFeeWaiverType.DataBind();
            ddlFeeWaiverGroup.DataSource = s.SetDropdownListCDB(60);
            ddlFeeWaiverGroup.DataTextField = "Fees_Description";
            ddlFeeWaiverGroup.DataValueField = "Fees_Items_Id";
            ddlFeeWaiverGroup.DataBind();
            BindGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = s.InsertFeeWaiverFeeGroup(ddlFeeWaiverType.SelectedValue, chkIsActive.Checked, int.Parse(ddlFeeWaiverGroup.SelectedValue));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Sucessfully Saved!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                BindGrid();
            }
            else
            {
                lblMesag.Text = "Please check Entry!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
        }
        catch
        {
            lblMesag.Text = "Please check Entry!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
    }
    public void BindGrid()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvStudentList.DataSource = s.SetDropdownListCDB(58);
        gvStudentList.DataBind();
    }
}