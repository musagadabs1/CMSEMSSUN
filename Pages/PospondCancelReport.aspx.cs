using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Pages_PospondCancelReport : System.Web.UI.Page
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
        Response.Redirect("PrintCalcelPospondReport.aspx?A=" + txtFromDate.Text + "&B=" + txtToDate.Text + "&C=" + ddlTerm.SelectedValue + "&D=" + ddlStatus.SelectedValue, false);
    }
}