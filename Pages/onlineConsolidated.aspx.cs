using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Pages_onlineConsolidated : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblerror.Text = "";
        CalendarExtender1.StartDate = DateTime.Parse("2017-07-15");
        ceFromDate.StartDate = DateTime.Parse("2017-07-15");
       
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        lblerror.Text="";
         
        string FromDate;
        string ToDate;
        DateTime d1;
        DateTime d2;
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
        Int32 total=0;
        if (txtToDate.Text=="")
        {
            lblerror.Text="Select To Date to display Todays pending in Report";
            return;
               
        }


         if (txtFromDate.Text=="")
        {
            lblerror.Text = "Select From  Date to display Totalreceived in Report";
            return;
               
        }

         try
         {

            
         }

         catch
         {

         }

 
        //total=(DateTime.Parse(txtFromDate.Text)-DateTime.Parse(txtToDate.Text)).Days;
        if (rdoconsolidated.Checked==true)
            Response.Redirect("PrintConsolidated.aspx?A=" + FromDate + "&B=" + ToDate + "&C=" + "2" + "&D=" +"0" + "&E=37&F=" + "0"+ "&G=" +"0" + "&H=" + "0", false);
        else if (rdomkt.Checked == true)
            Response.Redirect("PrintConsolidated.aspx?A=" + FromDate + "&B=" + ToDate + "&C=" + "2" + "&D=" + "0" + "&E=36&F=" + "0" + "&G=" + "0" + "&H=" + "0", false);
        else if (rdonationconsol.Checked == true)
            Response.Redirect("PrintConsolidated.aspx?A=" + FromDate + "&B=" + ToDate + "&C=" + "2" + "&D=" + "0" + "&E=34&F=" + "0" + "&G=" + "0" + "&H=" + "0", false);
        
        else
  Response.Redirect("PrintConsolidated.aspx?A=" + FromDate + "&B=" + ToDate + "&C=" + "2" + "&D=" +"0" + "&E=35&F=" + "0"+ "&G=" +"0" + "&H=" + "0", false);        
               
    
    }



    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
           // CalendarExtender1.StartDate = DateTime.ParseExact(txtFromDate.Text,"dd-MM-yyyy", null);
            DateTime dt = DateTime.Parse(txtFromDate.Text,CultureInfo.InvariantCulture);
            CalendarExtender1.StartDate = dt;
        }

        catch ( Exception ex)
        {

        }
    }
}