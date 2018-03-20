using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

public partial class Pages_CPDCourseschedulereport : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/Report/CPDCourseSheduleReport.rpt");
        rptStudent.Load(path);
        rptStudent.SetParameterValue("@Acad_year", Request.QueryString["A"].ToString());
        //rptStudent.SetParameterValue("@Degreeid", Request.QueryString["B"].ToString());
        //rptStudent.SetParameterValue("@Type", Request.QueryString["C"].ToString());
        rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
        CrystalReportViewer1.ReportSource = rptStudent;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.BackColor = System.Drawing.Color.White;

        //to pdf conversion starts from here 
        //ExportOptions ex = rptStudent.ExportOptions;
        //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
        //ExportRequestContext x = new ExportRequestContext();
        //x.ExportInfo = ex;
        //stream1 = (System.IO.MemoryStream)rptStudent.FormatEngine.ExportToStream(x);
        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.BinaryWrite(stream1.ToArray());
        //Response.End();
        //stream1.Close();


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
}