﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;

public partial class Pages_FollowupIndividual : System.Web.UI.Page
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
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                pnlReportViwer.Visible = false;
                txtRegistrationNo.Text = Request.QueryString["Id"].ToString();
                btnSubmit_Click(sender, e);
            }
        }
        catch
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        pnlReportViwer.Visible = true;
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string LinkId = s.GetLinkId(txtRegistrationNo.Text);
        //DataSet dt = s.PrintReport(ddlDegreeType.SelectedValue, ddlStudentStatus.SelectedValue, FromDate, ToDate, Session["EMPID"].ToString(), "0", "0", "CSS");
        string path = "";
        path = Server.MapPath("~/Report/CMS_FOLLOWUP_REPORT_INDIVIDUAL.rpt");
        rptStudent.Load(path);
        rptStudent.SetParameterValue("@linkid", LinkId);
        rptStudent.SetParameterValue("@fromdate", DateTime.Now);
        rptStudent.SetParameterValue("@todate", DateTime.Now);

        rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");

        //rptStudent.Database.Tables[0].SetDataSource(dt);
        CrystalReportViewer1.ReportSource = rptStudent;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.HasExportButton = true;
        CrystalReportViewer1.HasPrintButton = true;
        CrystalReportViewer1.HasSearchButton = true;
        CrystalReportViewer1.HasToggleGroupTreeButton = false;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
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
        Response.Redirect("PrintSummary.aspx?A=" + FromDate + "&B=" + ToDate + "&C=" + txtRegistrationNo.Text, false);
    }
    public static string DefaultPrinterName()
    {
        string functionReturnValue = null;
        System.Drawing.Printing.PrinterSettings oPS = new System.Drawing.Printing.PrinterSettings();
        try
        {
            functionReturnValue = oPS.PrinterName;
        }
        catch (System.Exception ex)
        {
            functionReturnValue = "";
        }
        finally
        {
            oPS = null;
        }
        return functionReturnValue;
    }
}