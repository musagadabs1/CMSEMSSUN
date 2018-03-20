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

public partial class Pages_CpdEventsReport : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
    string path = "";
    protected void Page_Load(object sender, EventArgs e)    
    {

        string gg = Request.QueryString["B"].ToString();

        //if (gg == "CTH Diploma in Air Cargo")
        //{
        //    gg = "CTH Diploma in Air Cargo & Logistics Management";
        //}

        //if (gg == "IATA-UFTAA Foundation and EBT")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport2.rpt");
        //}
        //else if (gg == "IATA-UFTAA Management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport3.rpt");
        //}
        //else if (gg  == "IATA-UFTAA Consultant")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport4.rpt");
        //}
        //else if (gg == "IATA-FIATA Cargo Introductory Course")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport5.rpt");
        //}
        //else if (gg == "IATA Airport operation course")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport6.rpt");
        //}
        //else if (gg == "IATA-FIATA Dangerous Goods Regulations - Recurrent")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport7.rpt");
        //}
        //else if (gg == "IATA-FIATA Dangerous Goods Regulations - Initial")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport8.rpt");
        //}
        //else if (gg == "Skyline Dangerous Goods Regulations - Refresher")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport9.rpt");
        //}
        //else if (gg == "Skyline Dangerous Goods Regulations - Basic")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport10.rpt");
        //}
        //else if (gg == "CTH Diploma in Travel and Tourism Management, UK")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport11.rpt");
        //}
        //else if (gg == "Diploma in Event Management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport12.rpt");
        //}
        //else if (gg == "CTH Diploma in Air Cargo and Logistics Management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport13.rpt");
        //}
        //else if (gg == "CTH Certificate in Travel and Tourism Management, UK")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport14.rpt");
        //}
        //else if (gg == "CTH Certificate in Hospitality Management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport15.rpt");
        //}
        //else if (gg == "CTH Certificate in Front Office management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport16.rpt");
        //}
        //else if (gg == "certificate in Event Management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport17.rpt");
        //}
        //else if (gg == "CTH - Basic Ramp Handling")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport18.rpt");
        //}
        //else if (gg == "CTH - Basic Load Control")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport19.rpt");
        //}
        //else if (gg == "Certificate in JAVA")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport20.rpt");
        //}
        //else if (gg == "Certificate in Human Resource Management")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport21.rpt");
        //}
        //else if (gg == "Certificate in Finance and Banking")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport22.rpt");
        //}
        //else if (gg == "ACCA")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport23.rpt");
        //}
        //else if (gg == "CTH - Airline Customer Service")
        //{
        //    path = Server.MapPath("~/Report/CpdEventsReport24.rpt");
        //}       
            
        //else 
       // {
            path = Server.MapPath("~/Report/CpdEventsReportmain.rpt");
       // }
        rptStudent.Load(path);
        rptStudent.SetParameterValue("@AcadYear", Request.QueryString["A"].ToString());
        rptStudent.SetParameterValue("@Shed_Course", Request.QueryString["B"].ToString());
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