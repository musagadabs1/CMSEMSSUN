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
public partial class Pages_EnrolledStudent : System.Web.UI.Page
{
    
    protected void Page_UnLoad(object sender, EventArgs e)
    {
       
        //GC.Collect();
      
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                ddlTerm.DataSource = s.SetDropdownListCDB(59);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermId";
                ddlTerm.DataBind();
                pnlReportViwer.Visible = false;

                   






            }
            if (IsPostBack)
            {
                //btnSubmit_Click(sender, e);
            }
        }
        catch
        {
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string EmpID = Session["EMPID"].ToString();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Degree = "0";
        if (ddlDegree.SelectedValue == "9")
            Degree = "9";
        string Term = "0";
        if (ddlTerm.SelectedIndex != 0)
            Term = ddlTerm.SelectedValue;
        Response.Redirect("PrintOtherReport.aspx?A=" + Term + "&B=" + ddlCountry.SelectedValue + "&D=" + Degree + "&E=8", false);
   
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        ReportDocument rptExcel = new ReportDocument();
                   string Degree = "0";
            if (ddlDegree.SelectedValue == "9")
                Degree = "9";
            string Term = "0";
            if (ddlTerm.SelectedIndex != 0)
                Term = ddlTerm.SelectedValue;
            string connection;
            SqlConnection con = null;
             connection = ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString();
            con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SP_STUDENTMASTERFILE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TERMID",Term);
            cmd.Parameters.Add("@degreetypeid", Degree);
            cmd.Parameters.Add("@groupcode", ddlCountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.CommandTimeout = 300;
            Server.ScriptTimeout = 3000000;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            string strExportFile=Server.MapPath(".")+"/StudentMasterfile.xls";
            rptExcel.Load(Server.MapPath("~/Report/STUDENTLIST.rpt"));
            rptExcel.SetDataSource(datatable);
            rptExcel.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            rptExcel.ExportOptions.ExportFormatType = ExportFormatType.Excel;
            ExcelFormatOptions objExcelOptions = new ExcelFormatOptions();
            objExcelOptions.ExcelUseConstantColumnWidth = false;
            rptExcel.ExportOptions.FormatOptions = objExcelOptions;
            DiskFileDestinationOptions objOptions = new DiskFileDestinationOptions();
            objOptions.DiskFileName = strExportFile;
            rptExcel.ExportOptions.DestinationOptions = objOptions;
            rptExcel.SetDatabaseLogon("software", "DelFirMENA$idea");
            rptExcel.Export();
            objOptions = null;
            rptExcel = null;
            Response.Redirect("StudentMasterfile.xls");





           


    }
}