using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Pages_Toctrack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                //ddlDegreeType.DataSource = s.SetDropdownListCDB(14);
                //ddlDegreeType.DataTextField = "Description";
                //ddlDegreeType.DataValueField = "Id";
                //ddlDegreeType.DataBind();


                ddlTerm.DataSource = s.SetDropdownListCDB(116);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();

                
                Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                Drpschool.DataTextField = "schoolname";
                Drpschool.DataValueField = "schoolcode";
                Drpschool.DataBind();
                Drpschool.SelectedValue = Session["schoolcode"].ToString();

                Drpschool_SelectedIndexChanged(sender, e);

            }
        }
        catch
        {

            Response.Redirect("Login.aspx");

        }
    }
    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlDegreeType.DataSource = s.SetDropdownListCDB(14, Drpschool.SelectedValue);
        ddlDegreeType.DataTextField = "Description";
        ddlDegreeType.DataValueField = "Id";
        ddlDegreeType.DataBind();
        ddlDegreeType.SelectedIndex = 1;
       


    }
    protected void btnSaveProgrammore_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    public void bindgrid()
    {
               StudentRegistrationDAL s = new StudentRegistrationDAL();
               if (chkstud.Checked == true)
               {
                   gvStudentList.DataSource = s.GetTOCdetailsbystud(txtstud.Text);
                   gvStudentList.DataBind();
               }
               else
               {

                   gvStudentList.DataSource = s.GetTOCdetails(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue),Drpschool.SelectedValue);
                   gvStudentList.DataBind();
               }

    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvStudentList.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void btnViewTOC_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //Response.Redirect("http://LAPTOP-RECM1EAA\SQLEXPRESS1/adminexam/page/Toc_Report.aspx?id=" + s.GetRegNo(Request.QueryString["Id"].ToString()), false);
    }


    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("View"))
            {

                int Id = Convert.ToInt32(e.CommandArgument);
                StudentRegistrationDAL c = new StudentRegistrationDAL();
                Response.Redirect("http://LAPTOP-RECM1EAA\\SQLEXPRESS1/adminexam/page/Toc_Report.aspx?id=" + Id, false);
                
            }
       
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }

}