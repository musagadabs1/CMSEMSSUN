using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_NigeriyaOffice : System.Web.UI.Page
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
        string FromDate;
        string ToDate;
        try
        {
            FromDate = (DateTime.Parse(txtFromDate.Text)).ToShortDateString();
        }
        catch
        {
            FromDate = DateTime.Now.ToShortDateString();
        }
        try
        {
            ToDate = (DateTime.Parse(txtToDate.Text)).ToShortDateString();
        }
        catch
        {
            ToDate = DateTime.Now.ToShortDateString();
        }
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Pr = "0";
        if (rdbPr.Checked == true)
            Pr = "1";
        else
            Pr = "2";
        Response.Redirect("PrintOtherReport.aspx?A=" + ddlTerm.SelectedValue + "&B=" + FromDate + "&C=" + ToDate + "&D=" + Pr + "&E=12", false);
    }
}