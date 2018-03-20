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

public partial class Pages_ViewInvoice : System.Web.UI.Page
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
            string RegNo = Request.QueryString["Id"].ToString();
            path = "~/Report/ProformaInvoice.rpt";
            path = Server.MapPath(path);
            rptStudent.Load(path);
            rptStudent.SetParameterValue("@studentid", RegNo);
            rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
            CrystalReportViewer1.ReportSource = rptStudent;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.HasExportButton = true;
            CrystalReportViewer1.HasPrintButton = true;
            CrystalReportViewer1.HasSearchButton = true;
            CrystalReportViewer1.HasToggleGroupTreeButton = false;
        }
        catch
        {
        }
    }
}