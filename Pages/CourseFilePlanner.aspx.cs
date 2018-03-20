using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;

public partial class Pages_CourseFilePlanner : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!Page.IsPostBack)
        {
            SetInitialRow();
        }          
       
    }
    protected void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] ="Week"+1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dt.Rows.Add(dr);
        dr = dt.NewRow();

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        grid_tab.DataSource = dt;
        grid_tab.DataBind();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grid_tab.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)grid_tab.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                    TextBox box4 = (TextBox)grid_tab.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                    TextBox box5 = (TextBox)grid_tab.Rows[rowIndex].Cells[5].FindControl("TextBox5");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grid_tab.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)grid_tab.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                    TextBox box4 = (TextBox)grid_tab.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                    TextBox box5 = (TextBox)grid_tab.Rows[rowIndex].Cells[5].FindControl("TextBox5");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] ="Week"+ (i + 1);

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;

                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                grid_tab.DataSource = dtCurrentTable;
                grid_tab.DataBind();

            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //Set Previous Data on Postbacks
        SetPreviousData();
    } 
    protected void btn_plus_click(object sender, EventArgs e)
    {      
        AddNewRowToGrid();
    }
    int result2 = 0;
    protected void btn_save_click(object sender, EventArgs e)
    {
        int result = 0; int count = 0;
        string txtshed = txt_sched.Text;
        string facname = txt_fac.Text;
        string fdate = txtFromDate.Text;
        string tdate = txtToDate.Text;       
       
        result = StudentRegistrationDAL.getId(txtshed,facname,fdate,tdate);

        string enteredby=   Session["Name"].ToString();
        string entereddate = (DateTime.Now).ToString();

        foreach (GridViewRow gr in grid_tab.Rows)
        {
            TextBox txtcont = (TextBox)grid_tab.Rows[count].FindControl("TextBox1");
            TextBox txtope = (TextBox)grid_tab.Rows[count].FindControl("TextBox2");
            TextBox txtacademic = (TextBox)grid_tab.Rows[count].FindControl("TextBox3");
            TextBox txttrans = (TextBox)grid_tab.Rows[count].FindControl("TextBox4");
            TextBox txtwkpln = (TextBox)grid_tab.Rows[count].FindControl("TextBox5");
            result2 = StudentRegistrationDAL.Insert_course_fileplanner(result, txtshed, facname, txtcont.Text, txtope.Text, txtacademic.Text, txttrans.Text, fdate, tdate, enteredby, entereddate, txtwkpln.Text);
            count = count + 1; 
        }

        lbl_msg.Text = "Saved Successfully";
        btn_report.Visible = true;
        bindgrid();

    }
    public void bindgrid()
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_course_file_planner";

        cmd.Parameters.AddWithValue("@Shed_course", txt_sched.Text);
        cmd.Parameters.AddWithValue("@Fac_name", txt_fac.Text);
        cmd.Parameters.AddWithValue("@Fromdate", txtFromDate.Text);
        cmd.Parameters.AddWithValue("@Todate", txtToDate.Text);
        cmd.Connection = conn;
        try
        {
            conn.Open();
            GridView1.EmptyDataText = "No Records Found";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }
    protected void btn_clear_click(object sender, EventArgs e)
    {
        txt_sched.Text = "";
        txt_fac.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        lbl_msg.Text = "";
      //  ddl_types.SelectedValue = "0";
        grid_tab.DataSource = null;
        grid_tab.DataBind();
        SetInitialRow();
        GridView1.DataSource = null;
        GridView1.DataBind();


    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        string path = "";
        string courseid = txt_sched.Text;
        string facname = txt_fac.Text;
        path = Server.MapPath("~/Report/Coursefileplanner.rpt");
        myReportDocument.Load(path);
        myReportDocument.SetParameterValue("@courseschedule", courseid);
        myReportDocument.SetParameterValue("@facnme", facname);
        myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrilldownTabs = false;
        CrystalReportViewer1.HasDrillUpButton = false;
        CrystalReportViewer1.HasExportButton = true;
        CrystalReportViewer1.HasGotoPageButton = true;
        CrystalReportViewer1.HasPageNavigationButtons = true;
        CrystalReportViewer1.HasPrintButton = true;
        CrystalReportViewer1.HasSearchButton = false;
        CrystalReportViewer1.HasToggleGroupTreeButton = false;
        CrystalReportViewer1.DisplayToolbar = true;
        CrystalReportViewer1.BackColor = System.Drawing.Color.White;
    }
   
}