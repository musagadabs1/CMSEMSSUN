using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Indexreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            ddlTerm.DataSource = s.SetDropdownListCDB(59);
            ddlTerm.DataTextField = "Term";
            ddlTerm.DataValueField = "TermID";
            ddlTerm.DataBind();
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrintOtherReport.aspx?A=" + ddlTerm.SelectedValue + "&E=14", false);
    }
}