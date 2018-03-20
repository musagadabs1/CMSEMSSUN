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

public partial class Pages_studentviewreport : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //rptStudent.Close();
        //GC.Collect();
        //rptStudent.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/Report/MKTSTUDENTDETAILS.rpt");
        rptStudent.Load(path);
        rptStudent.SetParameterValue("@LINKID", Request.QueryString["A"].ToString());
        rptStudent.SetParameterValue("@TERM", Request.QueryString["B"].ToString());
        rptStudent.SetParameterValue("@DEGREE", Request.QueryString["C"].ToString());
        rptStudent.SetParameterValue("@COURSE", Request.QueryString["D"].ToString());
        rptStudent.SetParameterValue("@groupcode", Request.QueryString["F"].ToString());

        rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
        CrystalReportViewer1.ReportSource = rptStudent;
        CrystalReportViewer1.DataBind();
      
        CrystalReportViewer1.BackColor = System.Drawing.Color.White;
    }
}