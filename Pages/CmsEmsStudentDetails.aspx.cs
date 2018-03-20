using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CmsEmsStudentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                ddlDegreeType.DataSource = s.SetDropdownListCDB(14);
                ddlDegreeType.DataTextField = "Description";
                ddlDegreeType.DataValueField = "Id";
                ddlDegreeType.DataBind();
                ddlCourseType.DataSource = s.SetDropdownListCDB(15);
                ddlCourseType.DataTextField = "Description";
                ddlCourseType.DataValueField = "Id";
                ddlCourseType.DataBind(); 
                ddlTerm.DataSource = s.SetDropdownListCDB(59);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermId";
                ddlTerm.DataBind();
                pnlReportViwer.Visible = false; 
                try
                {
                    string LinkID = (Request.QueryString["LinkId"].ToString());
                    txtRegNo.Text = s.GetNameByLinkID(LinkID);
                }
                catch
                {
                }
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
    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1, int.Parse(ddlDegreeType.SelectedValue));
        ddlCourseType.DataTextField = "Description";
        ddlCourseType.DataValueField = "Id";
        ddlCourseType.DataBind();
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string LinkId = "";
        if (txtRegNo.Text != "")
            LinkId = Request.QueryString["LinkId"].ToString();
        else
            LinkId = "0";
        if (LinkId == "")
            LinkId = "0";
        //Response.Redirect("PrintOtherReport.aspx?A=" + LinkId + "&B=" + ddlTerm.SelectedValue + "&F=" + ddlCountry.SelectedValue + "&C=" + ddlDegreeType.SelectedValue + "&D=" + ddlCourseType.SelectedValue + "&E=11", false);
        Response.Redirect("studentviewreport.aspx?A=" + LinkId + "&B=" + ddlTerm.SelectedValue + "&F=" + ddlCountry.SelectedValue + "&C=" + ddlDegreeType.SelectedValue + "&D=" + ddlCourseType.SelectedValue + "&E=11", false);


    }
    protected void btnRegNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentListForResult1.aspx?A=1", false);
    }
}