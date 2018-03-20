using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ExamSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                //ddlTerm.DataSource = s.SetDropdownListCDB(108);
                //ddlTerm.DataTextField = "Term";
                //ddlTerm.DataValueField = "Term";
                //ddlTerm.DataBind();
                ddlAcademicYear.DataSource = s.SetDropdownListCDB(114);
                ddlAcademicYear.DataTextField = "AcadYear_Desc";
                ddlAcademicYear.DataValueField = "AcadYear_Desc";
                ddlAcademicYear.DataBind();
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
    private void button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string Term = "0";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (ddlAcademicYear.SelectedIndex != 0)
            Term = ddlAcademicYear.SelectedValue;
        Response.Redirect("PrintOtherReport.aspx?A=" + ddlAcademicYear.SelectedValue + "&B=" + ddlType.SelectedValue + "&E=22", false);
    }
}