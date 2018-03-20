using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
public partial class Pages_printexportreport : System.Web.UI.Page
{
    ReportDocument rptExcel = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {


      
          
                     
            rptExcel.Load(Server.MapPath("~/Report/STUDENTLIST.rpt"));
            rptExcel.SetParameterValue("@TERMID", Request.QueryString["A"].ToString());
            rptExcel.SetParameterValue("@groupcode", Request.QueryString["B"].ToString());
            rptExcel.SetParameterValue("@degreetypeid", Request.QueryString["D"].ToString());
            rptExcel.SetDatabaseLogon("software", "DelFirMENA$idea");
            CrystalReportViewer1.ReportSource = rptExcel;
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