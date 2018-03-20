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

public partial class Pages_PrintTermWise : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = "";
        path = Server.MapPath("~/Report/DAILYMKTREPORT.rpt");
        rptStudent.Load(path);
        rptStudent.SetParameterValue("@empid", Request.QueryString["A"].ToString());
        rptStudent.SetParameterValue("@date1", Request.QueryString["B"].ToString());
        rptStudent.SetParameterValue("@date2", Request.QueryString["C"].ToString());
        rptStudent.SetParameterValue("@groupcode", Request.QueryString["D"].ToString());
        rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
        CrystalReportViewer1.ReportSource = rptStudent;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrilldownTabs = false;
        CrystalReportViewer1.HasDrillUpButton = false;
        CrystalReportViewer1.HasExportButton = true;
        CrystalReportViewer1.HasGotoPageButton = true;
        CrystalReportViewer1.HasPageNavigationButtons = true;
        CrystalReportViewer1.HasPrintButton = true;

        CrystalReportViewer1.HasSearchButton = false;
        CrystalReportViewer1.HasToggleGroupTreeButton = false;

        CrystalReportViewer1.DisplayToolbar = true;

        CrystalReportViewer1.BackColor = System.Drawing.Color.White;
    }
}