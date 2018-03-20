using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
//using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
//using Microsoft.Office.Tools.Excel;
using System.Collections;


public partial class Page_Mom_Agenda : System.Web.UI.Page
{
    DBHandler DBH = new DBHandler();
    // DataTable Dtb = new DataTable();
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
            BindDropDown();
            PopulateEvents();
            RadMom.Checked = true;
            //txtStrtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
   

    protected void BindDropDown()
    {
        StudentRegistrationDAL P = new StudentRegistrationDAL();

        DrpCalendar.DataSource = P.BindCalenderDropdown("CalName", Convert.ToInt32(Session["EMPID"]), "", 0, "");
        DrpCalendar.DataTextField = "Cal_Name";
        DrpCalendar.DataValueField = "Cal_Name";
        DrpCalendar.DataBind();
    }

    protected void PopulateEvents()
    {

       String Date="";
        if (txtStrtDate.Text.ToString() != "")
        {
            string[] date = new string[3];
            date = txtStrtDate.Text.Trim().Split('/');
            Date = date[2] + date[1]+ date[0];
        }
        else
        {
            Date = "19900101";
        }
        StudentRegistrationDAL P = new StudentRegistrationDAL();
        drpEvent.DataSource = P.BindCalenderDropdown("Mom Events", Convert.ToInt32(Session["EMPID"]), DrpCalendar.SelectedValue, Convert.ToInt32(DrpAcademicYear.SelectedValue), Date);
        drpEvent.DataTextField = "EventTitle";
        drpEvent.DataValueField = "EventTitle";
        drpEvent.DataBind();
        drpEvent.Items.Insert(0, new ListItem("Select", ""));

    }
    protected void DrpCalendar_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateEvents();
    }

    protected void btnLOad_Click(object sender, EventArgs e)
    {

        try
        {

            if (drpEvent.SelectedValue == "")
            {
                lblMessage.Text = "Please select Event";
                return;
            }

            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
            DateTime start = new DateTime();
            string Path = "";
            if (txtStrtDate.Text.ToString() != "")
            {
                string[] date = new string[3];
                date = txtStrtDate.Text.Trim().Split('/');
                start = new DateTime(Convert.ToInt16(date[2]), Convert.ToInt16(date[1]), Convert.ToInt16(date[0]));
            }

            if (RadMom.Checked == true)
            {
                Path = Server.MapPath("MOM.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\MOM.rpt";
            }
            else if (RadAgenda.Checked == true)
            {
                Path = Server.MapPath("Agenda.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\Agenda.rpt";

            }
            myReportDocument.Load(Path);
            myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "LAPTOP-RECM1EAA\\SQLEXPRESS", "DB_SkylineCalendarEvents");
            if (txtStrtDate.Text.ToString() != "")
            {
                myReportDocument.SetParameterValue("@Date", start);
            }
            if (RadMom.Checked == true)
            {
                myReportDocument.SetParameterValue("@DecisionStatus", DDLDecisionStatus.SelectedValue.ToString());
            }

            myReportDocument.SetParameterValue("@CalenderName", DrpCalendar.SelectedValue);
            myReportDocument.SetParameterValue("@CalederEventTitle", drpEvent.SelectedValue);


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
            //LogFile L = new LogFile();
            //L.LogError("MOM_Agenda.aspx");
            //L.LogError(Ex.Message.ToString());            
            //L.LogError(Session["User"].ToString());
            //Response.Write(Ex.Message);

         }
        
    }



    protected void DrpAcademicYear_SelectedIndexChanged1(object sender, EventArgs e)
    {
        PopulateEvents();
    }

    public void BindDropDownList()
    {
        try
        {
            StudentRegistrationDAL S = new StudentRegistrationDAL();
            DrpAcademicYear.DataSource = S.SetDropdownListCDB(114); ;
            DrpAcademicYear.DataTextField = "AcadYear_Desc";
            DrpAcademicYear.DataValueField = "AcadYear_ID";
            DrpAcademicYear.DataBind();
            DrpAcademicYear.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception Ex) { }
    }
    protected void txtStrtDate_TextChanged(object sender, EventArgs e)
    {
        PopulateEvents(); 
    }
}
