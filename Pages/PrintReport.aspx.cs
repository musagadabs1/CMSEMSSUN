using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Pages_PrintReport : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
               
                if (Session["EMPID"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    ddlemp.DataSource = s.SetDropdownListAsDegreeType(38, int.Parse(Session["EMPID"].ToString()));
                    ddlemp.DataTextField = "Name";
                    ddlemp.DataValueField = "empid";
                    ddlemp.DataBind();
                    try
                    {
                        if (ddlemp.Items.FindByValue(Session["EMPID"].ToString()) != null)

                        ddlemp.SelectedValue = Session["EMPID"].ToString();
                       else
                           ddlemp.SelectedValue = "0";



                    }
                    catch
                    {
                        ddlemp.SelectedValue = "0";
                    }
                    ddlDegreeType.DataSource = s.SetDropdownListCDB(14);
                    ddlDegreeType.DataTextField = "Description";
                    ddlDegreeType.DataValueField = "Id";
                    ddlDegreeType.DataBind();

                    ddlStudentStatus.DataSource = s.SetDropdownListCDB(113);
                    ddlStudentStatus.DataTextField = "CallerStatus";
                    ddlStudentStatus.DataValueField = "Id";
                    ddlStudentStatus.DataBind();

                    ddlCallerCategory.DataSource = s.SetDropdownListCDB(20);
                    ddlCallerCategory.DataTextField = "CCName";
                    ddlCallerCategory.DataValueField = "Id";
                    ddlCallerCategory.DataBind();
                    pnlReportViwer.Visible = false;

                    ddlCallerCategory.SelectedValue = "1";
                    ddlStudentStatus.SelectedValue = "2";

                    //ddlCountry.DataSource = s.SetDropdownListCDB(2);
                    //ddlCountry.DataTextField = "NationalityName";
                    //ddlCountry.DataValueField = "NationalityCode";
                    //ddlCountry.DataBind();
                    if (Session["GroupName"].ToString() != "UAE")
                    {
                        ddlCountry.SelectedValue = Session["GroupName"].ToString();
                        ddlCountry.Enabled = false;
                    }
                }
                if (IsPostBack)
                {
                    //btnSubmit_Click(sender, e);
                }
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
        string FromDate;
        string ToDate;
        string DegreeType = "";
        string Flag = "";
        if (ddlStudentStatus.SelectedValue == "0")
        {
            Response.Write("<script type=\"text/javascript\">alert('Caller Status Required');</script>");
            return;
        }
        try
        {
            FromDate =  (DateTime.Parse(txtFromDate.Text)).ToShortDateString();
        }
        catch
        {
            FromDate = DateTime.Now.ToShortDateString();
        }
        try
        {
            ToDate =  (DateTime.Parse(txtToDate.Text)).ToShortDateString();
        }
        catch
        {
            ToDate = DateTime.Now.ToShortDateString();
        }

        if (ddlStudentStatus.SelectedValue != "0" && ddlCallerCategory.SelectedIndex == 1)
        {
            if (ddlDegreeType.SelectedIndex == 0)
            {
                Flag = "CS";
                DegreeType = "0";
            }
            else
            {
                Flag = "CS";
                DegreeType = ddlDegreeType.SelectedValue;
            }
        }
        else
        {

        }
        if (ddlCallerCategory.SelectedIndex != 0 && ddlStudentStatus.SelectedValue == "0")
        {
            if (ddlDegreeType.SelectedIndex == 0)
            {
                Flag = "CC";
                DegreeType = "0";
            }
            else
            {
                Flag = "CC";
                DegreeType = ddlDegreeType.SelectedValue;
            }
        }
        if (ddlCallerCategory.SelectedIndex != 0 && ddlStudentStatus.SelectedValue != "0" && Flag != "CS")
        {
            if (ddlDegreeType.SelectedIndex == 0)
            {
                Flag = "CSC";
                DegreeType = "0";
            }
            else
            {
                Flag = "CSS";
                DegreeType = ddlDegreeType.SelectedValue;
            }
        }
        try
        {

            if (ddlCallerCategory.SelectedIndex != 0 && ddlStudentStatus.SelectedValue=="37")
            {
                if (ddlDegreeType.SelectedIndex == 0)
                {
                    Flag = "OS";
                    DegreeType = "0";
                }
                else
                {
                    Flag = "OS";
                    DegreeType = ddlDegreeType.SelectedValue;
                }
            }
        }

        catch
        {

        }
        Response.Redirect("PrintConsolidated.aspx?A=" + FromDate + "&B=" + ToDate + "&C=" + ddlCallerCategory.SelectedIndex + "&D=" + DegreeType + "&E=" + ddlStudentStatus.SelectedValue + "&F=" + Flag + "&G=" + ddlCountry.SelectedValue +"&empid=" + ddlemp.SelectedValue, false);        
    }
}