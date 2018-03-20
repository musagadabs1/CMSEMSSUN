using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Reporting;
using CrystalDecisions;
using System.Data.SqlClient;
using System.Text;

public partial class Pages_ConsolidatedFollowUp : System.Web.UI.Page
{
    ReportDocument rptDoc = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
        string path = "";

              rptDoc.Load(Server.MapPath("../Report/FollowUp.rpt"));
                //rptDoc.SetParameterValue("@Year", TxtYear.Text);
                //rptDoc.SetParameterValue("@Month", TxtMonth.Text);

              if (txtFromDate.Text != "")
              {

                  rptDoc.SetParameterValue("@fromate", null);
              }
              else
              {
                  string[] Date = new string[3];
                  if (txtFromDate.Text != "")
                  {
                      Date = txtFromDate.Text.Split('/');
                  }
                  else
                  {
                      Date = Convert.ToString("01-01-1990").Split('/');
                  }
                  rptDoc.SetParameterValue("@fromate", txtFromDate.Text);
              }

              if (txtToDate.Text != "")
              {

                  rptDoc.SetParameterValue("@todate", null);
              }
              else
              {
                  string[] Date1 = new string[3];
                  if (txtToDate.Text != "")
                  {
                      Date1 = txtToDate.Text.Split('/');
                  }
                  else
                  {
                      Date1 = Convert.ToString("01-01-1990").Split('/');
                  }
                  rptDoc.SetParameterValue("@todate", txtToDate);
              }

               rptDoc.SetDatabaseLogon("software", "DelFirMENA$idea");
               CrystalReportViewer1.Visible = false;
               CrystalReportViewer1.ReportSource = rptDoc;
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
               //ExportOptions ex = rptDoc.ExportOptions;
               //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
               //ExportRequestContext x = new ExportRequestContext();
               //x.ExportInfo = ex;
               //stream1 = (System.IO.MemoryStream)rptDoc.FormatEngine.ExportToStream(x);
               //Response.Clear();
               //Response.ContentType = "application/pdf";
               //Response.BinaryWrite(stream1.ToArray());
               //Response.End();
               //stream1.Close();

               System.IO.Stream oStream = null;
               byte[] byteArray = null;
               oStream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
               byteArray = new byte[oStream.Length];
               oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
               Response.ClearContent();
               Response.ClearHeaders();
               Response.ContentType = "application/pdf";
               Response.BinaryWrite(byteArray);
               Response.Flush();
               Response.Close();
               rptDoc.Close();
               rptDoc.Dispose();
    }
}