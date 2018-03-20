using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AptitudeTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
             
               
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
       
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
        Response.Redirect("PrintOtherReport.aspx?B=" + FromDate + "&C=" + ToDate +"&E=21", false);
    }
}