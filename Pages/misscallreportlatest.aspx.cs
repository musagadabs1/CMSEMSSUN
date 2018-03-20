using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_misscallreportlatest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        Response.Redirect("PrintOtherReport.aspx?B=" + FromDate + "&C=" + ToDate + "&E=24", false);
    }
}