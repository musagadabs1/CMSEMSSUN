using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;


public partial class Pages_CourseandWrkshpdet : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialRow();
            Fillmonth();
            btnprint.Visible = false;
            Panel1.Visible = false;
        }

    }
    protected void btn_plus_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));
        dt.Columns.Add(new DataColumn("Column8", typeof(string)));
        dt.Columns.Add(new DataColumn("Column9", typeof(string)));
        dt.Columns.Add(new DataColumn("Column10", typeof(string)));
        dt.Columns.Add(new DataColumn("Column11", typeof(string)));
        dt.Columns.Add(new DataColumn("Column12", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dr["Column7"] = string.Empty;
        dr["Column8"] = string.Empty;
        dr["Column9"] = string.Empty;
        dr["Column10"] = string.Empty;
        dr["Column11"] = string.Empty;
        dr["Column12"] = string.Empty;
        dt.Rows.Add(dr);
        //dr = dt.NewRow();

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
                    TextBox box1 = (TextBox)grid_tab.Rows[rowIndex].Cells[1].FindControl("txtcrsenme");
                    TextBox box2 = (TextBox)grid_tab.Rows[rowIndex].Cells[2].FindControl("txtexmshedle");
                    TextBox box3 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtexmsch");
                    TextBox box4 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtbatch");
                    TextBox box5 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtsessions");
                    TextBox box6 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtdays");
                    TextBox box7 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtcourse");
                    TextBox box8 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txttimngs");
                    TextBox box9 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txttargt");
                    TextBox box10 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtsms");
                    TextBox box11 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtemail");
                    TextBox box12 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtaud");


                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();
                    box6.Text = dt.Rows[i]["Column6"].ToString();
                    box7.Text = dt.Rows[i]["Column7"].ToString();
                    box8.Text = dt.Rows[i]["Column8"].ToString();
                    box9.Text = dt.Rows[i]["Column9"].ToString();
                    box10.Text = dt.Rows[i]["Column10"].ToString();
                    box11.Text = dt.Rows[i]["Column11"].ToString();
                    box12.Text = dt.Rows[i]["Column12"].ToString();


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
                    TextBox box1 = (TextBox)grid_tab.Rows[rowIndex].Cells[1].FindControl("txtcrsenme");
                    TextBox box2 = (TextBox)grid_tab.Rows[rowIndex].Cells[2].FindControl("txtexmshedle");
                    TextBox box3 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtexmsch");
                    TextBox box4 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtbatch");
                    TextBox box5 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtsessions");
                    TextBox box6 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtdays");
                    TextBox box7 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtcourse");
                    TextBox box8 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txttimngs");
                    TextBox box9 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txttargt");
                    TextBox box10 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtsms");
                    TextBox box11 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtemail");
                    TextBox box12 = (TextBox)grid_tab.Rows[rowIndex].Cells[3].FindControl("txtaud");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column5"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column6"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column7"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column8"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column9"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column10"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column11"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column12"] = box3.Text;

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
    protected void drpmonth_selectedindex_changed(object sender, EventArgs e)
    {
        grid_tab.DataSource = null;
        grid_tab.DataBind();
        SetInitialRow();
    }
    public void bindgrid()
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "[sp_Cdb_viewcourseandworkshop]";

        cmd.Parameters.AddWithValue("@Gyear", DrpYear.SelectedValue);
      
        // cmd.Parameters.AddWithValue("@ddl_type", ddl_types.SelectedValue);
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

    protected void btn_minus_Click(object sender, EventArgs e)
    {

    }

    private void Fillmonth()
    {
        StudentRegistrationDAL ds = new StudentRegistrationDAL();
        drpmonth.DataSource = ds.viewmonth();
        drpmonth.DataTextField = "monthname";
        drpmonth.DataValueField = "mnid";
        drpmonth.DataBind();
        if (drpmonth.Items.Count > 0)
        {
            drpmonth.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
        {
            drpmonth.Items.Add(new ListItem("Select", "0"));
        }

    }
    int result = 0;
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            btnprint.Visible = true;
            string txtshed = txt_sched.Text;
            string facname = txt_fac.Text;
            string Gyear = drpmonth.SelectedItem.Text;
            string Gmonth = DrpYear.SelectedValue;       

            string enteredby = Session["Name"].ToString();
            string entereddate = (DateTime.Now).ToString();

            result = StudentRegistrationDAL.GetScope(txt_sched.Text, txt_fac.Text, Convert.ToInt32(drpmonth.SelectedItem.Value));
            int count = 0; int result2 = 0;
            foreach (GridViewRow gr in grid_tab.Rows)
            {

                TextBox activity = (TextBox)grid_tab.Rows[count].FindControl("txtcrsenme");
                TextBox status1 = (TextBox)grid_tab.Rows[count].FindControl("txtexmshedle");
                TextBox Responsibility = (TextBox)grid_tab.Rows[count].FindControl("txtexmsch");
                TextBox txtbatch = (TextBox)grid_tab.Rows[count].FindControl("txtbatch");
                TextBox txtsessions = (TextBox)grid_tab.Rows[count].FindControl("txtsessions");
                TextBox txtdays = (TextBox)grid_tab.Rows[count].FindControl("txtdays");
                TextBox txtcourse = (TextBox)grid_tab.Rows[count].FindControl("txtcourse");
                TextBox txttimngs = (TextBox)grid_tab.Rows[count].FindControl("txttimngs");
                TextBox txttargt = (TextBox)grid_tab.Rows[count].FindControl("txttargt");
                TextBox txtsms = (TextBox)grid_tab.Rows[count].FindControl("txtsms");
                TextBox txtemail = (TextBox)grid_tab.Rows[count].FindControl("txtemail");
                TextBox txtaud = (TextBox)grid_tab.Rows[count].FindControl("txtaud");

                //result2 = StudentRegistrationDAL.insert_precourse_details();

                result2 = StudentRegistrationDAL.insertcourseandworkshopdetails(result, txtshed, facname, Gyear, Gmonth, activity.Text, status1.Text, Responsibility.Text,
                    txtbatch.Text, txtsessions.Text, txtdays.Text, txtcourse.Text, txttimngs.Text, txttargt.Text, txtsms.Text, txtemail.Text, txtaud.Text, enteredby, entereddate);
                count = count + 1;
            }

            lbl_msg.Text = "Saved successfully";
            bindgrid();

        }

        catch (Exception ex)
        {
            HttpContext.Current.ClearError();
        }
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_sched.Text = "";
        txt_fac.Text = "";
        drpmonth.SelectedValue = "0";
        DrpYear.SelectedValue = "0";
        grid_tab.DataSource = null;
        grid_tab.DataBind();
        SetInitialRow();
        GridView1.DataSource = null;
        GridView1.DataBind();
        Panel1.Visible = false;
        lbl_msg.Text = "";

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        string path = "";
        //string courseid = txt_sched.Text;
        //string facname = txt_fac.Text;
        path = Server.MapPath("~/Report/courseandworked.rpt");
        myReportDocument.Load(path);
        //myReportDocument.SetParameterValue("@courseschedule", courseid);
        //myReportDocument.SetParameterValue("@facnme", facname);
        myReportDocument.SetParameterValue("@Gyear", DrpYear.SelectedValue);
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