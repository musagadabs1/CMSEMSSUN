using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Mediawise_Call_visit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
       // string EmpID = Session["EMPID"].ToString();
        string FromDate;
        string ToDate;
        try
        {
         //   FromDate = (DateTime.Parse(txtFromDate.Text)).ToShortDateString();
              FromDate = Convert.ToString(txtFromDate.Text);
        }
        catch
        {
            FromDate = DateTime.Now.ToString();
        }
        try
        {
           // ToDate = (DateTime.Parse(txtToDate.Text)).ToShortDateString();
              ToDate = Convert.ToString(txtToDate.Text);
        }
        catch
        {
            ToDate = DateTime.Now.ToString();
        }
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        Response.Redirect("PrintOtherReport.aspx?A=" + rad_but.SelectedItem.Value+"&B=" + FromDate + "&C=" + ToDate + "&E=27", false);
    }
}