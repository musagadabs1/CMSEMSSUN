using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FundSetup : System.Web.UI.Page
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
            ddlTerm.DataSource = s.SetDropdownListCDB(59);
            ddlTerm.DataTextField = "Term";
            ddlTerm.DataValueField = "TermID";
            ddlTerm.DataBind();
            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(20, 1);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
            BindGrid();
        }
    }
    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlFeeWaiverType.DataSource = s.SetDropdownListAsDegreeType(19, int.Parse(ddlDegreeType.SelectedValue));
        ddlFeeWaiverType.DataTextField = "FeeWaiverType";
        ddlFeeWaiverType.DataValueField = "Id";
        ddlFeeWaiverType.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = s.UpdateFeeWaiver(ddlFeeWaiverType.SelectedValue, decimal.Parse(txtFundAllocated.Text), decimal.Parse(txtFundExceed.Text), txtRemarks.Text, int.Parse(Session["EmpId"].ToString()), chkIsActive.Checked, int.Parse(ddlTerm.SelectedValue));
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
        gvStudentList.DataSource = s.SetDropdownListCDB(54);
        gvStudentList.DataBind();
    }
}