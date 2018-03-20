using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_COECReport : System.Web.UI.Page
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
        string Term = "0";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (ddlTerm.SelectedIndex != 0)
            Term = ddlTerm.SelectedValue;
        Response.Redirect("PrintCOECReport.aspx?A=" + Term, false);
    }
}