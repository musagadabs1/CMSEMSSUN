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
//using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
//using Microsoft.Office.Tools.Excel;
using System.Collections;

public partial class Page_DisplayCalendar : System.Web.UI.Page
{
    DBHandler DBH = new DBHandler();
   // DataTable Dtb = new DataTable();
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            StudentRegistrationDAL P = new StudentRegistrationDAL();
            DrpCalendar.DataSource = P.BindCalenderDropdown("CalName", Convert.ToInt32(Session["EMPID"]), "", 0, "");
            DrpCalendar.DataTextField = "Cal_Name";
            DrpCalendar.DataValueField = "Cal_Name";
            DrpCalendar.DataBind();
            if (Convert.ToInt32(Session["UserId"])==1619)
                DrpCalendar.Items.Insert(0, new ListItem("Select", ""));

            PopulateCat();
            PopulateEvents();

            DataTable dt = new DataTable();
            DBH.CreateDataTable_TPS(dt, "SELECT  Cal_Name=ltrim(rtrim(Cal_Name)) ,Department=ltrim(rtrim(Department)) ,Category1=ltrim(rtrim(Category1)),Category2=ltrim(rtrim(Category2)) ,EventTitle=ltrim(rtrim(EventTitle)),ItemType=ltrim(rtrim(ItemType)),Year=ltrim(rtrim(Year)),Semester=ltrim(rtrim(Semester))  FROM [DB_SkylineCalendarEvents].[dbo].[Cal_Master] ");

            //DrpCalendar.DataSource = dt.DefaultView.ToTable(true, "Cal_Name");
            //DrpCalendar.DataTextField = "Cal_Name";
            //DrpCalendar.DataValueField = "Cal_Name";
            //DrpCalendar.DataBind();
            //DrpCalendar.Items.Insert(0, new ListItem("Select", ""));


            //DrpCat1.DataSource = dt.DefaultView.ToTable(true, "Category1");
            //DrpCat1.DataTextField = "Category1";
            //DrpCat1.DataValueField = "Category1";
            //DrpCat1.DataBind();
            //DrpCat1.Items.Insert(0, new ListItem("Select", ""));

            drpCat2.DataSource = dt.DefaultView.ToTable(true, "Category2");
            drpCat2.DataTextField = "Category2";
            drpCat2.DataValueField = "Category2";
            drpCat2.DataBind();
            drpCat2.Items.Insert(0, new ListItem("Select", ""));

            //drpEvent.DataSource = dt.DefaultView.ToTable(true, "EventTitle");
            //drpEvent.DataTextField = "EventTitle";
            //drpEvent.DataValueField = "EventTitle";
            //drpEvent.DataBind();
            //drpEvent.Items.Insert(0, new ListItem("Select", ""));

            DrpType.DataSource = dt.DefaultView.ToTable(true, "ItemType");
            DrpType.DataTextField = "ItemType";
            DrpType.DataValueField = "ItemType";
            DrpType.DataBind();
            DrpType.Items.Insert(0, new ListItem("Select", ""));

            drpYear.DataSource = dt.DefaultView.ToTable(true, "Year");
            drpYear.DataTextField = "Year";
            drpYear.DataValueField = "Year";
            drpYear.DataBind();
            drpYear.Items.Insert(0, new ListItem("Select", ""));

            drpSem.DataSource = dt.DefaultView.ToTable(true, "Semester");
            drpSem.DataTextField = "Semester";
            drpSem.DataValueField = "Semester";
            drpSem.DataBind();
            drpSem.Items.Insert(0, new ListItem("Select", ""));

            if (Convert.ToString(Session["Role"]) == "Dean" || Convert.ToString(Session["Role"]) == "COEC" ||  Convert.ToString(Session["Role"]) == "Admin")
            {
                PnlConsolidate.Visible = true;
            }
        }
    }
  
    protected void PopulateCat()
    {
        StudentRegistrationDAL P = new StudentRegistrationDAL();
        DrpCat1.DataSource = P.BindCalenderDropdown("Category1", Convert.ToInt32(Session["UserId"]), DrpCalendar.SelectedValue.Trim(),0,"");
        DrpCat1.DataTextField = "Category1";
        DrpCat1.DataValueField = "Category1";
        DrpCat1.DataBind();
        DrpCat1.Items.Insert(0, new ListItem("Select", ""));

    }

    protected void PopulateEvents()
    {
        StudentRegistrationDAL P = new StudentRegistrationDAL();
        drpEvent.DataSource = P.BindCalenderDropdown("Events", Convert.ToInt32(Session["UserId"]), DrpCat1.SelectedValue.Trim(),0,"");
        drpEvent.DataTextField = "EventTitle";
        drpEvent.DataValueField = "EventTitle";
        drpEvent.DataBind();
        drpEvent.Items.Insert(0, new ListItem("Select", ""));

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

       
        DateTime start = new DateTime();
        DateTime Enddate = new DateTime();
        try
        {


            if (txtStrtDate.Text.ToString() != "")
            {
                string[] date = new string[3];
                date = txtStrtDate.Text.Trim().Split('/');
                start = new DateTime(Convert.ToInt16(date[2]), Convert.ToInt16(date[1]), Convert.ToInt16(date[0]));
            }
            if (txtEndDate.Text.ToString() != "")
            {
                string[] enddate = new string[3];
                enddate = txtEndDate.Text.Trim().Split('/');
                Enddate = new DateTime(Convert.ToInt16(enddate[2]), Convert.ToInt16(enddate[1]), Convert.ToInt16(enddate[0]));
            }

            if (ChkExportExcel.Checked == true)
            {
                ArrayList pa = new ArrayList();
                ArrayList pv = new ArrayList();
                pa.Add("@EventTitle");
                pa.Add("@Category1");
                pa.Add("@Category2");
                pa.Add("@Year");
                pa.Add("@semester");
                pa.Add("@ItemType");
                pa.Add("@CalName");
                pa.Add("@StartDate");
                pa.Add("@EndDate");
                pv.Add(drpEvent.SelectedValue);
                pv.Add(DrpCat1.SelectedValue);
                pv.Add(drpCat2.SelectedValue);
                pv.Add(drpYear.SelectedValue);
                pv.Add(drpSem.SelectedValue);
                pv.Add(DrpType.SelectedValue);
                pv.Add(DrpCalendar.SelectedValue);
                pv.Add(txtStrtDate.Text.ToString() != "" ? start.ToString("yyyy/MM/dd") : "");
                pv.Add(txtStrtDate.Text.ToString() != "" ? Enddate.ToString("yyyy/MM/dd") : "");
                DataTable Dtb1 = new DataTable();
                DBH.CreateDataTableCalender(Dtb1, "SP_DeptwiseEvent", true, pa, pv);
                ExportToExcel(Dtb1);



            }
            else
            {

                string Path = Server.MapPath("DeptWiseCalendar.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\DeptWiseCalendar.rpt";
                myReportDocument.Load(Path);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
                myReportDocument.SetParameterValue("@DeptName",DrpCalendar.SelectedItem.Text);
                if (txtStrtDate.Text.ToString() != "")
                {
                    myReportDocument.SetParameterValue("@StartDate", start.ToString("yyyy/MM/dd"));
                }
                else
                {
                    myReportDocument.SetParameterValue("@StartDate", "");
                }
                if (txtStrtDate.Text.ToString() != "")
                {
                    myReportDocument.SetParameterValue("@EndDate", Enddate.ToString("yyyy/MM/dd"));
                }
                else
                {
                    myReportDocument.SetParameterValue("@EndDate", "");
                }

                myReportDocument.SetParameterValue("@EventTitle", drpEvent.SelectedValue);
                myReportDocument.SetParameterValue("@Category1", DrpCat1.SelectedValue);
                myReportDocument.SetParameterValue("@Category2", drpCat2.SelectedValue);
                myReportDocument.SetParameterValue("@Year", drpYear.SelectedValue);
                myReportDocument.SetParameterValue("@semester", drpSem.SelectedValue);
                myReportDocument.SetParameterValue("@ItemType", DrpType.SelectedValue);
                myReportDocument.SetParameterValue("@CalName", DrpCalendar.SelectedValue);

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
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);

        }

        finally
        {

        }
    }

    protected void btnDate_Click(object sender, EventArgs e)
    {
        DateTime start = new DateTime();
        DateTime Enddate = new DateTime();
        if (txtStrtDate.Text.ToString() != "")
        {
            string[] date = new string[3];
            date = txtStrtDate.Text.Trim().Split('/');
            start = new DateTime(Convert.ToInt16(date[2]), Convert.ToInt16(date[1]), Convert.ToInt16(date[0]));
        }
        if (txtEndDate.Text.ToString() != "")
        {
            string[] enddate = new string[3];
            enddate = txtEndDate.Text.Trim().Split('/');
            Enddate = new DateTime(Convert.ToInt16(enddate[2]), Convert.ToInt16(enddate[1]), Convert.ToInt16(enddate[0]));
        }

        if (ChkExportExcel.Checked == true)
        {
            ArrayList pa = new ArrayList();
            ArrayList pv = new ArrayList();
            pa.Add("@EventTitle");
            pa.Add("@Category1");
            pa.Add("@Category2");
            pa.Add("@Year");
            pa.Add("@semester");
            pa.Add("@ItemType");
            pa.Add("@CalName");
            pa.Add("@StartDate");
            pa.Add("@EndDate");
            pv.Add(drpEvent.SelectedValue);
            pv.Add(DrpCat1.SelectedValue);
            pv.Add(drpCat2.SelectedValue);
            pv.Add(drpYear.SelectedValue);
            pv.Add(drpSem.SelectedValue);
            pv.Add(DrpType.SelectedValue);
            pv.Add(DrpCalendar.SelectedValue);
            pv.Add(txtStrtDate.Text.ToString() != "" ? start.ToString("yyyy/MM/dd"): "");
            pv.Add(txtStrtDate.Text.ToString() != "" ? Enddate.ToString("yyyy/MM/dd"):"");
            DataTable Dtb1 = new DataTable();
            DBH.CreateDataTableCalender(Dtb1, "SP_DeptwiseEvent", true, pa, pv);
            ExportToExcel(Dtb1);

          

        }
        else
        {
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

  
          
            try
            {
                

                string Path = Server.MapPath("DeptWiseCalendar1.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\DeptWiseCalendar1.rpt";
                myReportDocument.Load(Path);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
                myReportDocument.SetParameterValue("@DeptName", DrpCalendar.SelectedItem.Text);
                if (txtStrtDate.Text.ToString() != "")
                {
                    myReportDocument.SetParameterValue("@StartDate", start.ToString("yyyy/MM/dd"));
                }
                else
                {
                    myReportDocument.SetParameterValue("@StartDate", "");
                }
                if (txtStrtDate.Text.ToString() != "")
                {
                    myReportDocument.SetParameterValue("@EndDate", Enddate.ToString("yyyy/MM/dd"));
                }
                else
                {
                    myReportDocument.SetParameterValue("@EndDate", "");
                }

                myReportDocument.SetParameterValue("@EventTitle", drpEvent.SelectedValue);
                myReportDocument.SetParameterValue("@Category1", DrpCat1.SelectedValue);
                myReportDocument.SetParameterValue("@Category2", drpCat2.SelectedValue);
                myReportDocument.SetParameterValue("@Year", drpYear.SelectedValue);
                myReportDocument.SetParameterValue("@semester", drpSem.SelectedValue);
                myReportDocument.SetParameterValue("@ItemType", DrpType.SelectedValue);
                myReportDocument.SetParameterValue("@CalName", DrpCalendar.SelectedValue);


               
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
    }

    protected void btnAcademic_Click(object sender, EventArgs e)
    {
        if (ChkExportExcel.Checked == true)
        {
            DataTable Dtb1 = new DataTable();
            ArrayList Pa = new ArrayList();
            ArrayList Pv = new ArrayList();
            Pa.Add("@year");
            Pv.Add(drpYear.SelectedItem.Text);
            DBH.CreateDataTableCalender(Dtb1, "SP_DisplayCalendar", true, Pa, Pv);
            ExportToExcel(Dtb1);
        }
        else
        {

            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
            
            try
            {

                string Path = Server.MapPath("DisplayCalendar.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\DisplayCalendar.rpt";
                myReportDocument.Load(Path);
                myReportDocument.SetParameterValue("@year", drpYear.SelectedItem.Text);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");



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
    }
    protected void BtnStatitics_Click(object sender, EventArgs e)
    {


        if (ChkExportExcel.Checked == true)
        {
            DataTable Dtb1 = new DataTable();
            ArrayList Pa = new ArrayList();
           ArrayList Pv=new ArrayList();
           Pa.Add("@year");
           Pv.Add(drpYear.SelectedItem.Text);
            DBH.CreateDataTableCalender(Dtb1, "Sp_CalenderStatistics_Details", true, Pa, Pv);
            ExportToExcel(Dtb1);
        }
        else
        {

            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

    

            try
            {

                string Path = Server.MapPath("CalenderStatistics.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\CalenderStatistics.rpt";

                myReportDocument.Load(Path);
                myReportDocument.SetParameterValue("@year", drpYear.SelectedItem.Text);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");


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
       }



    //private void ExportToExcel(DataTable Dtb)
    //{

    //    GrvGrid.DataSource = Dtb;
    //    GrvGrid.DataBind();

    //    string result = ExcelUtility.ToExcel(GrvGrid.DataSource);
    //    ExcelUtility.ExportToExcel(result);


    //}
    private void ExportToExcel(DataTable Dtb)
    {

        GrvGrid.DataSource = Dtb;
        GrvGrid.DataBind();

        string result = ExcelUtility.ToExcel(GrvGrid.DataSource);
        DataTable Dt = (DataTable)GrvGrid.DataSource;
        ExcelUtility.ExportToExcel1(Dt);


    }


    protected void DrpCalendar_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();
        //if (DrpCalendar.SelectedIndex > 0)
        //{
        //    DBH.CreateDataTable_TPS(dt, "SELECT  distinct Category1=ltrim(rtrim(Category1))    FROM [DB_SkylineCalendarEvents].[dbo].[Cal_Master] where Cal_Name='" + DrpCalendar.SelectedValue + "'");
        //}
        //else
        //{
        //    DBH.CreateDataTable_TPS(dt, "SELECT  distinct Category1=ltrim(rtrim(Category1))    FROM [DB_SkylineCalendarEvents].[dbo].[Cal_Master] ");
   
        //}

        //DrpCat1.DataSource = dt;
        //DrpCat1.DataTextField = "Category1";
        //DrpCat1.DataValueField = "Category1";
        //DrpCat1.DataBind();
        //DrpCat1.Items.Insert(0, new ListItem("Select", ""));

        PopulateCat();
    }


    protected void DrpCat1_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateEvents();
    }
    protected void BtnConsolidateRpt_Click(object sender, EventArgs e)
    {

        DateTime start = new DateTime();
        DateTime Enddate = new DateTime();
        if (txtStrtDate.Text.ToString() != "")
        {
            string[] date = new string[3];
            date = txtStrtDate.Text.Trim().Split('/');
            start = new DateTime(Convert.ToInt16(date[2]), Convert.ToInt16(date[1]), Convert.ToInt16(date[0]));
        }
        if (txtEndDate.Text.ToString() != "")
        {
            string[] enddate = new string[3];
            enddate = txtEndDate.Text.Trim().Split('/');
            Enddate = new DateTime(Convert.ToInt16(enddate[2]), Convert.ToInt16(enddate[1]), Convert.ToInt16(enddate[0]));
        }

        if (ChkExportExcel.Checked == true)
        {
            DataTable Dtb1 = new DataTable();
            ArrayList Pa = new ArrayList();
            ArrayList Pv = new ArrayList();
            Pa.Add("@StartDate");
            Pa.Add("@EndDate");
            Pv.Add(txtStrtDate.Text.ToString() != "" ? start.ToString("yyyy/MM/dd") : "");
            Pv.Add(txtEndDate.Text.ToString() != "" ? Enddate.ToString("yyyy/MM/dd") : "");
            DBH.CreateDataTableCalender(Dtb1, "SP_ConSolidatedCalenderReports1", true, Pa, Pv);
            ExportToExcel(Dtb1);
        }
        else
        {

            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

           

            try
            {


                string Path = Server.MapPath("DeptWiseCalendarConsolidated.rpt");
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\DeptWiseCalendarConsolidated.rpt";
                myReportDocument.Load(Path);
                //myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea", "192.168.167.207", "DB_SkylineCalendarEvents");
                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
           
                if (txtStrtDate.Text.ToString() != "")
                {
                    myReportDocument.SetParameterValue("@StartDate", start.ToString("yyyy/MM/dd"));
                }
                else
                {
                    myReportDocument.SetParameterValue("@StartDate", "");
                }
                if (txtStrtDate.Text.ToString() != "")
                {
                    myReportDocument.SetParameterValue("@EndDate", Enddate.ToString("yyyy/MM/dd"));
                }
                else
                {
                    myReportDocument.SetParameterValue("@EndDate", "");
                }


                //stream1 = null;
                //ExportOptions ex = myReportDocument.ExportOptions;
                //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                //ExportRequestContext x = new ExportRequestContext();
                //x.ExportInfo = ex;
                //stream1 = (System.IO.MemoryStream)myReportDocument.FormatEngine.ExportToStream(x);
                //Response.Clear();
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(stream1.ToArray());
                //Response.End();
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
            //    LogFile L = new LogFile();
            //    L.LogError("DisplayCalendar.aspx");
            //    L.LogError(Ex.Message.ToString());
            //    L.LogError(Session["User"].ToString());
            //    Response.Write(Ex.Message);
            }
            finally
            {

            }
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        myReportDocument.Close();
        myReportDocument.Dispose();
        GC.Collect();
    }
}