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
using System.IO;
using CrystalDecisions.Shared;

public partial class Pages_PrintOtherReport : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        GC.Collect();
        rptStudent.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
            string path = "";
            if (Request.QueryString["E"].ToString() == "1")
            {
               
                
                   if (Request.QueryString["D"].ToString() == "UAE")
                   path = Server.MapPath("~/Report/DAILYCMSREPORT.rpt");
                   else
                       path = Server.MapPath("~/Report/DAILYCMSREPORTNG.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "2")
            {
                path = Server.MapPath("~/Report/COECDAILYFollowupreport.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "3")
            {
                path = Server.MapPath("~/Report/COECWEEKLYFollowupreport.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "4")
            {
                if (Request.QueryString["D"].ToString() == "NG")
                    path = Server.MapPath("~/Report/DAILYMKTREPORTNG.rpt");
                else
                    path = Server.MapPath("~/Report/DAILYMKTREPORT.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@empid", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@date1", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@date2", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "5")
            {
                path = Server.MapPath("~/Report/COECWEEKLYSUMMARY.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "6")
            {
                path = Server.MapPath("~/Report/COECEnrolreport.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@DEGID", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "7")
            {
                path = Server.MapPath("~/Report/COECSEATALLOCTIONREPORT.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@termid", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "8")
            {
                path = Server.MapPath("~/Report/STUDENTLIST.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@TERMID", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@degreetypeid", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "9")
            {
                path = Server.MapPath("~/Report/COECStudentdetails.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@AcadYearId", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@CategoryText", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@SubCategoryText", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@DegreeId", Request.QueryString["D"].ToString());
                rptStudent.SetParameterValue("@Percentage", Request.QueryString["F"].ToString());
                rptStudent.SetParameterValue("@termId", Request.QueryString["G"].ToString());
                rptStudent.SetParameterValue("@MOU", Request.QueryString["H"].ToString());

            }
            if (Request.QueryString["E"].ToString() == "10")
            {
                path = Server.MapPath("~/Report/COECnationwise.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@nationID", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@TERM", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@DEGREE", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@COURSE", Request.QueryString["D"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "11")
            {
                path = Server.MapPath("~/Report/MKTSTUDENTDETAILS.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@LINKID", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@TERM", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@DEGREE", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@COURSE", Request.QueryString["D"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["F"].ToString());
            }
            if (Request.QueryString["E"].ToString() == "12")
            {
                path = Server.MapPath("~/Report/NGPAYREPORT.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@term", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@paymode", Request.QueryString["D"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "13")
            {
                path = Server.MapPath("~/Report/ADMINCHECKLIST.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@linkid", Request.QueryString["A"].ToString());
             
            }
            if (Request.QueryString["E"].ToString() == "14")
            {
                path = Server.MapPath("~/Report/CMS_INDEX_SETUP_REPORT.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@Termid", Request.QueryString["A"].ToString());

            }
            if (Request.QueryString["E"].ToString() == "15")
            {
                path = Server.MapPath("~/Report/rptAptitudeResult.rpt");
                rptStudent.Load(path);
              rptStudent.SetParameterValue("@test_code", Request.QueryString["A"].ToString());
                       }
          
            if (Request.QueryString["E"].ToString() == "16")
            {
               
                path = Server.MapPath("~/Report/DAILYCPDREPORT.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@empid", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@flag", Request.QueryString["F"].ToString());
                rptStudent.SetParameterValue("@date1", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@date2", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "17")
            {
                path = Server.MapPath("~/Report/CPDReportCoursewise.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@empid", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@flag", Request.QueryString["F"].ToString());
                rptStudent.SetParameterValue("@date1", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@date2", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "18")
            {
                path = Server.MapPath("~/Report/CPDReportFollowup.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@empid", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@flag", Request.QueryString["F"].ToString());
                rptStudent.SetParameterValue("@date1", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@date2", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }


            if (Request.QueryString["E"].ToString() == "19")
            {
                path = Server.MapPath("~/Report/CPDReportstat.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@empid", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@flag", Request.QueryString["F"].ToString());
                rptStudent.SetParameterValue("@date1", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@date2", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
            }


            if (Request.QueryString["E"].ToString() == "20")
            {
                path = Server.MapPath("~/Report/CMS_SEAT_ALLOCATION_REPORT.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@termid", Request.QueryString["D"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "21")
            {
                path = Server.MapPath("~/Report/AptitudeTestUser.rpt");
                rptStudent.Load(path);

                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString());
                rptStudent.SetParameterValue("@fromdate", Request.QueryString["B"].ToString(), "Summary");
                rptStudent.SetParameterValue("@todate", Request.QueryString["C"].ToString(), "Summary");
            }

            if (Request.QueryString["E"].ToString() == "22")
            {
                path = Server.MapPath("~/Report/Ieltsexamschedule.rpt");
                rptStudent.Load(path);

                rptStudent.SetParameterValue("@Acyear", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@Type", Request.QueryString["B"].ToString());
            }


            if (Request.QueryString["E"].ToString() == "23")
            {
                path = Server.MapPath("~/Report/MOUAuditnew.rpt");
                rptStudent.Load(path);

                rptStudent.SetParameterValue("@ayyear", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue("@termid", Request.QueryString["B"].ToString());
            }


            if (Request.QueryString["E"].ToString() == "24")
            {
                path = Server.MapPath("~/Report/MISSCALLATEST.rpt");
                rptStudent.Load(path);

                rptStudent.SetParameterValue("@FromDate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@ToDate", Request.QueryString["C"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "25")
            {
                path = Server.MapPath("~/Report/MISSCALLATESTSUMMARY.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@FromDate", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@ToDate", Request.QueryString["C"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "26")
            {
                path = Server.MapPath("~/Report/moufudalloted.rpt");
                rptStudent.Load(path);

                rptStudent.SetParameterValue("@ayyear", Request.QueryString["A"].ToString());
                rptStudent.SetParameterValue( "@degreedesc", Request.QueryString["B"].ToString());
            }

            if (Request.QueryString["E"].ToString() == "27")
            {
                if (Request.QueryString["A"].ToString() == "C")
                {
                    path = Server.MapPath("~/Report/Media_visit_Call.rpt");
                    rptStudent.Load(path);

                    rptStudent.SetParameterValue("@startdate", Request.QueryString["B"].ToString());
                    rptStudent.SetParameterValue("@enddate", Request.QueryString["C"].ToString());
                }
                else
                {
                    path = Server.MapPath("~/Report/Media_Enrollment.rpt");
                    rptStudent.Load(path);

                    rptStudent.SetParameterValue("@startdate", Request.QueryString["B"].ToString());
                    rptStudent.SetParameterValue("@enddate", Request.QueryString["C"].ToString());
                }
            }

            if (Request.QueryString["E"].ToString() == "39")
            {
                path = Server.MapPath("~/Report/AgentListReport.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@Id", 0);
                rptStudent.SetParameterValue("@Operation", "Report");
            }

            if (Request.QueryString["E"].ToString() == "40")
            {
                path = Server.MapPath("~/Report/AirticketMasterList.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@Id", int.Parse(Request.QueryString["id"].ToString()));
                rptStudent.SetParameterValue("@Operation", "Report");
            }


            if (Request.QueryString["E"].ToString() == "OFFER")
            {
                path = Server.MapPath("~/Report/MIS_COEC_Offer_Letter.rpt");
                rptStudent.Load(path);

                rptStudent.SetParameterValue("@Operation", "Consolidated");
                rptStudent.SetParameterValue("@Term", int.Parse(Request.QueryString["D"].ToString()));
                rptStudent.SetParameterValue("@Operation", "AnalysisDetails", rptStudent.Subreports[0].Name.ToString());
                rptStudent.SetParameterValue("@Operation", "Detailed", rptStudent.Subreports[1].Name.ToString());
                rptStudent.SetParameterValue("@Operation", "EmailDetails", rptStudent.Subreports[2].Name.ToString());

            }


            if (Request.QueryString["E"].ToString() == "41")
            {
                path = Server.MapPath("~/Report/MIS_COEC_BBAtoMBA_Statistics.rpt");
                rptStudent.Load(path);
                rptStudent.SetParameterValue("@FromAyear", Request.QueryString["B"].ToString());
                rptStudent.SetParameterValue("@ToYear", Request.QueryString["C"].ToString());
            }


            rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
            CrystalReportViewer1.Visible = false;
            CrystalReportViewer1.ReportSource = rptStudent;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.HasCrystalLogo = false;
            //CrystalReportViewer1.HasDrilldownTabs = false;
            CrystalReportViewer1.HasDrillUpButton = false;
            CrystalReportViewer1.HasExportButton = true;
            CrystalReportViewer1.HasGotoPageButton = true;
            CrystalReportViewer1.HasPageNavigationButtons = true;
            CrystalReportViewer1.HasPrintButton = true;
            CrystalReportViewer1.HasSearchButton = false;
            CrystalReportViewer1.HasToggleGroupTreeButton = false;
            CrystalReportViewer1.DisplayToolbar = true;
            CrystalReportViewer1.BackColor = System.Drawing.Color.White;

            //stream1 = null;
            //ExportOptions ex = rptStudent.ExportOptions;
            //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
            //ExportRequestContext x = new ExportRequestContext();
            //x.ExportInfo = ex;
            //stream1 = (System.IO.MemoryStream)rptStudent.FormatEngine.ExportToStream(x);
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.BinaryWrite(stream1.ToArray());
            //Response.End();
            //stream1.Close();

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
        catch ( Exception ex)
        {
            //Response.Redirect("login.aspx", false);
        }
    }
    
}