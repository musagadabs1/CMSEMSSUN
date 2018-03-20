using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
public partial class Pages_Onlinechat : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["EmpId"].ToString() == "")
                    Response.Redirect("Login.aspx", false);
                if (Session["EmpId"].ToString() == null)
                    Response.Redirect("Login.aspx", false);
            }
            catch
            {
            }
        }

        if (IsPostBack)
        {
            btnPrint_Click(sender, e);
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
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
            string path = "";
            path = Server.MapPath("~/Report/Enquirychat.rpt");
            rptStudent.Load(path);
            //string EMPID = Session["EMPID"].ToString();
            rptStudent.SetParameterValue("@fromdate1", FromDate);
            rptStudent.SetParameterValue("@todate1", ToDate);
            
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
        catch
        {
        }
    }
}