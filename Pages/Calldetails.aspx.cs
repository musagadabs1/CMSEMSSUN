using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
public partial class Pages_Calldetails : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void LoadReport()
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

        try
        {
            string Path = Server.MapPath("CALLDETAILS001.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Report\\CALLDETAILS001.rpt";
            DS_BILL DS = new DS_BILL();
          //DS .Tables["bill"]=

            DataTable DBH = new DataTable();
            
            myReportDocument.SetDataSource(DS);
            myReportDocument.Load(Path);
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.168.208", "CDB");
            //myReportDocument.SetParameterValue("@Gender", ddl_list.SelectedValue);
            //myReportDocument.SetParameterValue("@Empid", drpFaculty.SelectedValue);
            //myReportDocument.SetParameterValue("@batchcode", drp_Batch.SelectedItem.Text);

            //stream1 = null;
            //ExportOptions ex = myReportDocument.ExportOptions;
            //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
            //ExportRequestContext x = new ExportRequestContext();
            //x.ExportInfo = ex;
            //stream1 = (System.IO.MemoryStream)myReportDocument.FormatEngine.ExportToStream(x);
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.BinaryWrite(stream1.ToArray());
            //// Response.End();
            //stream1.Close();

            System.IO.Stream oStream = null;
            byte[] byteArray = null;
            oStream = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(byteArray);
            Response.Flush();
            Response.Close();
            myReportDocument.Close();
            myReportDocument.Dispose();


        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);
        }

        finally
        {
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
}