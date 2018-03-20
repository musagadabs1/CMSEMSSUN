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

public partial class Pages_PrintConsolidated : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
    }


    //public String DateConversion(String Date)
    //{
    //    String CfromDate = "";
    //    string[] Cfrom = new string[3];
    //    if (Date != "")
    //    {
    //        Cfrom = Date.ToString().Split('/');
    //        CfromDate = Convert.ToInt32(Cfrom[2]) + "-" + Convert.ToInt32(Cfrom[1]) + "-" + Convert.ToInt32(Cfrom[0]);

    //    }
    //    return CfromDate;

    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = "";
        if (Session["EMPID"] == null || Session["EMPID"] == "")
        {
            Response.Redirect("login.aspx");
        }
        
        if (Request.QueryString["C"].ToString() == "1")
        {
            if (Request.QueryString["E"].ToString() == "4")
            {
                path = Server.MapPath("~/Report/CMS_STUDENTSTATUSENROLL_REPORT.rpt");

            }

            else if (Request.QueryString["E"].ToString() == "3")
            {
                path = Server.MapPath("~/Report/CMS_FOLLOWUP_REPORT.rpt");

            }
            else if (Request.QueryString["E"].ToString() == "31")
            {
                path = Server.MapPath("~/Report/CMS_FOLLOWUP_REPORT_EXISTING.rpt");

            }
            else if (Request.QueryString["E"].ToString() == "32")
            {
                path = Server.MapPath("~/Report/CMS_FOLLOWUP_REPORT_GRADUATES.rpt");

            }
            else if (Request.QueryString["E"].ToString() == "37")
            {
                path = Server.MapPath("~/Report/CMS_STUDENTSTATUS_REPORT-ONLINE.rpt");

            }
            else
            {
                path = Server.MapPath("~/Report/CMS_STUDENTSTATUS_REPORT.rpt");
            }


        }
        else   if (Request.QueryString["C"].ToString() == "2")
        {
            if (Request.QueryString["E"].ToString() == "33")
            {
                path = Server.MapPath("~/Report/COECStudentEnrolledTrack.rpt");

            }


            if (Request.QueryString["E"].ToString() == "34")
            {
                path = Server.MapPath("~/Report/COECStudentNation_Consoildated_OnlineTrack.rpt");

            }


            if (Request.QueryString["E"].ToString() == "35")
            {
                path = Server.MapPath("~/Report/COECStudentNationwise_OnlineTrack.rpt");

            }
            if (Request.QueryString["E"].ToString() == "36")
            {
                path = Server.MapPath("~/Report/COECStudent_MKTuserwise_OnlineTrack.rpt");

            }
            if (Request.QueryString["E"].ToString() == "37")
            {
                path = Server.MapPath("~/Report/COEC_Online_Enquiry_All.rpt");

            }



               }



        else
        {
            path = Server.MapPath("~/Report/CMS_STATUS_REPORT.rpt");
        }
        rptStudent.Load(path);
        string EMPID1, EMPID;
        EMPID = Session["EMPID"].ToString();

        try{
        if (Request.QueryString["empid"].ToString() == "")
        {
           EMPID1 = Session["EMPID"].ToString();

        }
        else
        {
            EMPID1 = Request.QueryString["empid"].ToString(); 
        }
        }
        catch
        {
            EMPID1= Session["EMPID"].ToString();

        }

        if ((Request.QueryString["E"].ToString() == "3") || (Request.QueryString["E"].ToString() == "31") || (Request.QueryString["E"].ToString() == "32")) 
        {

            rptStudent.SetParameterValue("@degreetype", Request.QueryString["D"].ToString());
            rptStudent.SetParameterValue("@fromdate", Request.QueryString["A"].ToString());
            rptStudent.SetParameterValue("@todate", Request.QueryString["B"].ToString());
            rptStudent.SetParameterValue("@createdby", EMPID);
            rptStudent.SetParameterValue("@GROUPCODE", Request.QueryString["G"].ToString());
            rptStudent.SetParameterValue("@empidaccess", EMPID1);
                       
        }
        else  if (Request.QueryString["E"].ToString() == "33")         {

            rptStudent.SetParameterValue("@termid", Request.QueryString["A"].ToString());
            rptStudent.SetParameterValue("@regid", "0");
            rptStudent.SetParameterValue("@mobileno", "0");
            rptStudent.SetParameterValue("@program",  Request.QueryString["D"].ToString());
            rptStudent.SetParameterValue("@callerstatus", Request.QueryString["B"].ToString());
            rptStudent.SetParameterValue("@enrolled",  Request.QueryString["F"].ToString());
             rptStudent.SetParameterValue("@onlineflag", Request.QueryString["G"].ToString());
            rptStudent.SetParameterValue("@mediasource",  Request.QueryString["H"].ToString());

                       
        }
        else if ((Request.QueryString["E"].ToString() == "34") || (Request.QueryString["E"].ToString() == "35") || (Request.QueryString["E"].ToString() == "36") || (Request.QueryString["E"].ToString() == "37"))
        {

            rptStudent.SetParameterValue("@todate", ( Request.QueryString["A"].ToString()));
            if (!String.IsNullOrEmpty(Request.QueryString["B"].ToString()))
            {
                // Query string value is there so now use it
                rptStudent.SetParameterValue("@currentdate", (Request.QueryString["B"].ToString()));
                //rptStudent.SetParameterValue("@currentdate", DateTime.Now.ToString());
            }
            
            rptStudent.SetParameterValue("@cflag", "false");
          


        }
        else{
            
            rptStudent.SetParameterValue("@callerstatus", Request.QueryString["E"].ToString());
            rptStudent.SetParameterValue("@fromdate", Request.QueryString["A"].ToString());
            rptStudent.SetParameterValue("@todate", Request.QueryString["B"].ToString());
            rptStudent.SetParameterValue("@createdby", EMPID);
            rptStudent.SetParameterValue("@callercategory", Request.QueryString["C"].ToString());
            rptStudent.SetParameterValue("@formstatus", Request.QueryString["G"].ToString());
            rptStudent.SetParameterValue("@degreetype", Request.QueryString["D"].ToString());
            rptStudent.SetParameterValue("@flag", Request.QueryString["F"].ToString());
            rptStudent.SetParameterValue("@empid", EMPID1);
        }
        rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
        CrystalReportViewer1.ReportSource = rptStudent;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.HasCrystalLogo =false;
        CrystalReportViewer1.HasDrilldownTabs = false;
        CrystalReportViewer1.HasDrillUpButton = false;
        CrystalReportViewer1.HasExportButton = true;
        CrystalReportViewer1.HasGotoPageButton = true;
        CrystalReportViewer1.HasPageNavigationButtons =true;
        CrystalReportViewer1.HasPrintButton = true;     
        CrystalReportViewer1.HasSearchButton =false;
        CrystalReportViewer1.HasToggleGroupTreeButton = false;      
        CrystalReportViewer1.DisplayToolbar =true;
        CrystalReportViewer1.BackColor = System.Drawing.Color.White;

        System.IO.Stream oStream = null;
        byte[] byteArray = null;
        oStream = rptStudent.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        byteArray = new byte[oStream.Length];
        oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(byteArray);
        Response.Flush();
        Response.Close();
        rptStudent.Close();
        rptStudent.Dispose();
    }
}