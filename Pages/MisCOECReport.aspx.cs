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

public partial class Pages_MisCOECReport : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    ReportDocument myReportDocument = new ReportDocument();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLAyear.DataSource = s.GetAcYear();
            DDLAyear.DataTextField = "YEAR";
            DDLAyear.DataValueField = "YEAR";
            DDLAyear.DataBind();
            DDLAyear.Items.Insert(0, new ListItem("SELECT", "0"));
            LoadMonth();
            PopulateFromYear();
            PopulateToYear();
        }

    }
    protected void DDLAyear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void LoadMonth()
    {
        DDFMonth.DataSource = s.GetMonthName();
        DDFMonth.DataTextField = "MonthName";
        DDFMonth.DataValueField = "ID";
        DDFMonth.DataBind();

        DDLTMonth.DataSource = s.GetMonthName();
        DDLTMonth.DataTextField = "MonthName";
        DDLTMonth.DataValueField = "ID";
        DDLTMonth.DataBind();
        
    }

    protected void PopulateFromYear()
    {
        Int32 Currentyear;

        Currentyear = DateTime.Now.Year;
        for (Int32 s = Currentyear - 10; s <= Currentyear + 10; s++)
        {
            DrpFromYear.Items.Add(new ListItem((s).ToString(), (s).ToString()));
        }
        DrpFromYear.DataBind();
        DrpFromYear.SelectedValue = Convert.ToString(Currentyear);
    }
    protected void PopulateToYear()
    {
        Int32 Currentyear;

        Currentyear = DateTime.Now.Year;
        for (Int32 s = Currentyear - 10; s <= Currentyear + 10; s++)
        {
            DrpToYear.Items.Add(new ListItem((s).ToString(), (s).ToString()));
        }
        DrpToYear.DataBind();
        DrpToYear.SelectedValue = Convert.ToString(Currentyear);
    }

    protected void LoadReport()
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
        string Path = "";
        if (DDLReport.SelectedValue == "Exhibition")
        {
            Path = Server.MapPath("Exhibition.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Report\\Exhibition.rpt";
            
        }
        else if (DDLReport.SelectedValue == "Farirs&Events")
        {
            Path = Server.MapPath("Fairs-Events.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Report\\Fairs-Events.rpt";
            
        }
        else if (DDLReport.SelectedValue == "MKTVisits")
        {
            Path = Server.MapPath("MKTVisitsCMS.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Report\\MKTVisitsCMS.rpt";

        }
        else if (DDLReport.SelectedValue == "Events&Workshop")
        {
            Path = Server.MapPath("EventsandWorkshop.rpt");
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path.Substring(0, Path.LastIndexOf('\\'));
            Path = Path + "\\Report\\EventsandWorkshop.rpt";

        }
        myReportDocument.Load(Path);
        myReportDocument.Load(Path);
        myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        myReportDocument.SetParameterValue("@frommonth", DDFMonth.SelectedValue);
        myReportDocument.SetParameterValue("@fromyear", DrpFromYear.SelectedValue);
        myReportDocument.SetParameterValue("@tomonth", DDLTMonth.SelectedValue);
        myReportDocument.SetParameterValue("@toyear", DrpToYear.SelectedValue);
        myReportDocument.SetParameterValue("@ayflag", DDLAyear.SelectedValue!="0" ? 1:0);
        myReportDocument.SetParameterValue("@ayyear", DDLAyear.SelectedValue);


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
    protected void BtnReport_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
}