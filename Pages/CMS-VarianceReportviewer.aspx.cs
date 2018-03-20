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


public partial class Pages_CMS_VarianceReportviewer : System.Web.UI.Page
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
        path = Server.MapPath("~/Report/CMSVariance.rpt");
        rptStudent.Load(path);
        rptStudent.SetParameterValue("@Fromdate", Request.QueryString["A"].ToString());
        rptStudent.SetParameterValue("@Todate", Request.QueryString["B"].ToString());
        rptStudent.SetParameterValue("@TermId", 0);
        rptStudent.SetParameterValue("@DegreeType", 0);
        rptStudent.SetParameterValue("@AYYear", "");

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
        catch
        {
            //Response.Redirect("login.aspx", false);
        }
    }
}