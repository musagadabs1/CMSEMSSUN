using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Reporting;
using CrystalDecisions;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class Pages_StudentLedger : System.Web.UI.Page
{
    ReportDocument rptDoc = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptDoc.Close();
        GC.Collect();
        rptDoc.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            try
            {
                System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                string RegNo = Request.QueryString["RegNo"].ToString();
                //s.GetRegNoOrg(Request.QueryString["RegNo"].ToString());


                rptDoc.Load(Server.MapPath("~/Report/StudentLedger.rpt"));

                rptDoc.SetParameterValue("@studentid", RegNo);
                //rptDoc.SetDatabaseLogon("software", "DelFirMENA$idea");
                //SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["TPSCON"].ToString());

                //r.ptDocSetDatabaseLogon("", "");
                rptDoc.SetDatabaseLogon("software", "DelFirMENA$idea");
                //SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SkyLineErp"].ToString());
                //string ServerName = SqlConnectionStringBuilder.DataSource;
                //string DatabaseName = SqlConnectionStringBuilder.InitialCatalog;
                //Boolean IntegratedSecurity = SqlConnectionStringBuilder.IntegratedSecurity;
                //string UserID = SqlConnectionStringBuilder.UserID;
                //string Password = SqlConnectionStringBuilder.Password;

                //ConnectionInfo con = new ConnectionInfo();
                //con.ServerName = ServerName;
                //con.DatabaseName = DatabaseName;
                //if (IntegratedSecurity != true)
                //{
                //    con.UserID = UserID;
                //    con.Password = Password;
                //}


                //rptviewer_DepSmmryRpt.DisplayGroupTree = false;
                rptviewer_DepSmmryRpt.ReportSource = rptDoc;
                rptviewer_DepSmmryRpt.DataBind();


                //foreach (TableLogOnInfo tlf in rptviewer_DepSmmryRpt.LogOnInfo)
                //{
                //    tlf.ConnectionInfo = con;
                //}
                rptviewer_DepSmmryRpt.Visible = false;
                //stream1 = null;
                //ExportOptions ex = rptDoc.ExportOptions;
                //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                //ExportRequestContext x = new ExportRequestContext();
                //x.ExportInfo = ex;
                //stream1 = (System.IO.MemoryStream)rptDoc.FormatEngine.ExportToStream(x);
                //Response.Clear();
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(stream1.ToArray());
                //Response.End();
                //stream1.Close();
                System.IO.Stream oStream = null;
                byte[] byteArray = null;
                oStream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rptDoc.Close();
                rptDoc.Dispose();


            }
            catch( Exception ex )
            {
                Response.Write(ex.ToString());

            }
        }
        catch
        {
        }
    }
}