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




public partial class Pages_DiscountStudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {


                ddl_Acadyr.DataSource = s.GetAcademicYear();
                ddl_Acadyr.DataTextField = "Accadyear_Desc";
                ddl_Acadyr.DataValueField = "acyear_id";
                ddl_Acadyr.DataBind();

                ddl_category.DataSource = s.getcategory("O");
                ddl_category.DataTextField = "Category";
                ddl_category.DataValueField = "id";
                ddl_category.DataBind();


                ddlTerm.DataSource = s.SetDropdownListCDB(59);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermId";
                ddlTerm.DataBind();

                //ddlscholership.DataSource = s.SetDropdownListCDB(104);
                //ddlscholership.DataTextField = "Feewaiver";
                //ddlscholership.DataValueField = "Id";
                //ddlscholership.DataBind();

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

    protected void ddlcategory_selectedindexchanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            {
                int catid = Convert.ToInt16(ddl_category.SelectedItem.Value);
                ddl_subcat.DataSource = s.getscat(catid);
                ddl_subcat.DataTextField = "Subcategory";
                ddl_subcat.DataValueField = "id";
                ddl_subcat.DataBind();
            }
        }
        catch
        {
        }
    }



    protected void ddldegree_selectedindex_changed(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            {
                int acyrid = Convert.ToInt16(ddl_Acadyr.SelectedItem.Value);
                int degid = Convert.ToInt16(ddlDegree.SelectedItem.Value);
                ddl_percentage.DataSource = s.getpercentage(acyrid, degid);
                ddl_percentage.DataTextField = "Percentage";
                ddl_percentage.DataValueField = "Percentage";
                ddl_percentage.DataBind();
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
        string acad_yr_Id = ddl_Acadyr.SelectedItem.Value;
        string cattext = ddl_category.SelectedItem.Text;
        string subcattext = ddl_subcat.SelectedItem.Text;
        string degId = ddlDegree.SelectedItem.Value;
        string percen = ddl_percentage.SelectedItem.Value;
        int term = Convert.ToInt32(ddlTerm.SelectedItem.Value);
        int MOU = Convert.ToInt32(Rad_1.SelectedItem.Value);


        Response.Redirect("PrintOtherReport.aspx?A=" + acad_yr_Id + "&B=" + cattext + "&C=" + subcattext + "&D=" + degId + "&F=" + percen + "&G=" + term + "&H=" + MOU + "&E=9", false);

       // string EmpID = Session["EMPID"].ToString();
       // StudentRegistrationDAL s = new StudentRegistrationDAL();
       // string Degree = "0";
       // if (ddlDegree.SelectedValue == "9")
       //    Degree = "9";
       //string Term = "0";
       //  if (ddlTerm.SelectedIndex != 0)
          //  Term = ddlTerm.SelectedValue;
       // Response.Redirect("PrintOtherReport.aspx?A=" + Term + "&B=" + ddlCountry.SelectedValue + "&C=" + ddlscholership.SelectedValue + "&D=" + Degree + "&E=9", false);
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        ReportDocument rptExcel = new ReportDocument();
       // string Degree = "0";
       // if (ddlDegree.SelectedValue == "9")
       //     Degree = "9";
       // string Term = "0";
       //// if (ddlTerm.SelectedIndex != 0)
       //  //   Term = ddlTerm.SelectedValue;

        string acad_yr_Id = ddl_Acadyr.SelectedItem.Value;
        string cattext = ddl_category.SelectedItem.Text;
        string subcattext = ddl_subcat.SelectedItem.Text;
        string degId = ddlDegree.SelectedItem.Value;
        string percen = ddl_percentage.SelectedItem.Value;
        int term = Convert.ToInt32(ddlTerm.SelectedItem.Value);
        int MOU = Convert.ToInt32(Rad_1.SelectedItem.Value);

        string connection;
        SqlConnection con = null;

       
        connection = ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString();
        con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand("SP_SCHOLARSHIP_STUD_DETAILS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@AcadYearId", acad_yr_Id);
        cmd.Parameters.Add("@CategoryText", cattext);
        cmd.Parameters.Add("@SubCategoryText", subcattext);
        cmd.Parameters.Add("@DegreeId", degId);
        cmd.Parameters.Add("@Percentage", percen);
        cmd.Parameters.Add("@termId", term);
        cmd.Parameters.Add("@MOU", MOU);
      //  cmd.Parameters.Add("@scholer", ddlscholership.SelectedValue);
      //  cmd.Parameters.Add("@groupcode", ddlCountry.SelectedValue);
      //  cmd.Parameters.Add("@DEGID", Degree);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable datatable = new DataTable();
        da.Fill(datatable);
        string strExportFile = Server.MapPath(".") + "/discount.xls";
        rptExcel.Load(Server.MapPath("~/Report/COECStudentdetails.rpt"));
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
        Response.Redirect("Discount.xls");


    }
}