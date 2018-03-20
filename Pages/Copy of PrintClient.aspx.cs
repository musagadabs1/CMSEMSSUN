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

public partial class Pages_PrintClient : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string path = "";
            //string UName = Session["UName"].ToString();
            string LinkId = Session["LinkId"].ToString();
            string UName = Request.QueryString["UName"].ToString();
            if (UName.Contains(".pdf"))
            {
                Response.Redirect("PrintableDocument/" + UName, false);
            }
            else
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                string RegNo = s.GetRegNo(LinkId);

                path = "~/Report/" + UName + ".rpt";
                path = Server.MapPath(path);
                rptStudent.Load(path);
                if (UName == "ENROLLMENTFORM")
                    rptStudent.SetParameterValue("@LinkId", LinkId);
                else
                    rptStudent.SetParameterValue("@registerid", LinkId);
                rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
                CrystalReportViewer1.ReportSource = rptStudent;
                CrystalReportViewer1.DataBind();
                CrystalReportViewer1.HasCrystalLogo = false;
                CrystalReportViewer1.HasDrilldownTabs = false;
                CrystalReportViewer1.HasDrillUpButton = false;
                CrystalReportViewer1.HasExportButton = false;
                CrystalReportViewer1.HasGotoPageButton = false;
                CrystalReportViewer1.HasPageNavigationButtons = false;
                CrystalReportViewer1.HasPrintButton = false;
                CrystalReportViewer1.HasRefreshButton = false;
                CrystalReportViewer1.HasSearchButton = false;
                CrystalReportViewer1.HasToggleGroupTreeButton = false;
                CrystalReportViewer1.HasToggleParameterPanelButton = false;
                CrystalReportViewer1.HasZoomFactorList = false;
                CrystalReportViewer1.DisplayToolbar = false;
                CrystalReportViewer1.EnableDrillDown = false;
                CrystalReportViewer1.BestFitPage = true;
                CrystalReportViewer1.BackColor = System.Drawing.Color.White;
                CrystalReportViewer1.SeparatePages = false;
                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                CrystalReportViewer1.Height = 200;
                CrystalReportViewer1.Width = 500;
            }
        }
        catch
        {
        }
    }

}
   