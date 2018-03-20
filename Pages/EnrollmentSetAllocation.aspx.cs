using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_EnrollmentSetAllocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                ddlTerm.DataSource = s.SetDropdownListCDB(59);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermId";
                ddlTerm.DataBind();
                pnlReportViwer.Visible = false;
            }
            if (IsPostBack)
            {
                //btnSubmit_Click(sender, e);
            }
        }
        catch
        {
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string EmpID = Session["EMPID"].ToString();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Term = "0";
        if (ddlTerm.SelectedIndex != 0)
            Term = ddlTerm.SelectedValue;
        Response.Redirect("PrintOtherReport.aspx?D=" + Term + "&E=7", false);
    }
}