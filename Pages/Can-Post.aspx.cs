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

public partial class Pages_Can_Post : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
         StudentRegistrationDAL s = new StudentRegistrationDAL();
         if (!IsPostBack)
         {
             ddlDegreeType.DataSource = s.filldegreeName();
             ddlDegreeType.DataTextField = "DegreeType_Desc";
             ddlDegreeType.DataValueField = "DegreeType_ID";
             ddlDegreeType.DataBind();

             ddlTerm.DataSource = s.fillTermname();
             ddlTerm.DataTextField = "termname";
             ddlTerm.DataValueField = "Termid";
             ddlTerm.DataBind();
         }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //string path = Server.MapPath("~/Report/Can-Post.rpt");
        //rptStudent.Load(path);
        //rptStudent.SetParameterValue("@TermId", ddlTerm.SelectedItem.Value);
        //rptStudent.SetParameterValue("@Degreeid", ddlDegreeType.SelectedItem.Value);
        //rptStudent.SetParameterValue("@Type", ddltype.SelectedItem.Value);
        //rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
        //CrystalReportViewer1.ReportSource = rptStudent;
        //CrystalReportViewer1.DataBind();
        //CrystalReportViewer1.BackColor = System.Drawing.Color.White;

        //int term = 0;
        //if (ddlTerm.SelectedItem.Value == "0")
        //{
        //    term = 0;
        //}
        //else
        //{
        //    term = Convert.ToInt16(ddlTerm.SelectedItem.Value);
        //}
        //int degreeid = 0;
        //if (ddlDegreeType.SelectedItem.Value == "0")
        //{
        //    degreeid = 0;
        //}
        //else
        //{
        //    degreeid = Convert.ToInt16(ddlDegreeType.SelectedItem.Value);
        //}
        Response.Redirect("Canpostreport.aspx?A=" + ddlTerm.SelectedItem.Value + "&B=" + ddlDegreeType.SelectedItem.Value + "&C=" + ddltype.SelectedItem.Value, false);
    }
}