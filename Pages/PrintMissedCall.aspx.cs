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
using CrystalDecisions.Shared;

public partial class Pages_PrintMissedCall : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string Type= Request.QueryString["C"].ToString();

        if (Type != "z")
        {
            string path = "";
            //path = Server.MapPath("~/Report/CMS_MISSEDCALLNEW_REPORT.rpt");
            path = Server.MapPath("~/Report/MissedCallSummaryReport1.rpt");
            rptStudent.Load(path);
            string EMPID = Session["EMPID"].ToString();
            rptStudent.SetParameterValue("@fromdate1", Request.QueryString["A"].ToString());
            rptStudent.SetParameterValue("@todate1", Request.QueryString["B"].ToString());
            rptStudent.SetParameterValue("@empid", EMPID);
            rptStudent.SetParameterValue("@GROUPCODE", Request.QueryString["D"].ToString());
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
            CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.Visible = true;
        }
        else
        {
            string path = "";
            path = Server.MapPath("~/Report/MissedCallSummaryReport.rpt");
            rptStudent.Load(path);
            string EMPID = Session["EMPID"].ToString();
            rptStudent.SetParameterValue("@fromdate1", Request.QueryString["A"].ToString());
            rptStudent.SetParameterValue("@todate1", Request.QueryString["B"].ToString());
            rptStudent.SetParameterValue("@empid", EMPID);
            rptStudent.SetParameterValue("@GROUPCODE", Request.QueryString["D"].ToString());
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
}