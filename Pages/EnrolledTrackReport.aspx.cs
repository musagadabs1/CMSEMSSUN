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

public partial class Pages_EnrolledTrackReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
                      ddlDegreeType.DataSource = s.SetDropdownListCDB(14);
                    ddlDegreeType.DataTextField = "Description";
                    ddlDegreeType.DataValueField = "Id";
                    ddlDegreeType.DataBind();

                    ddlStudentStatus.DataSource = s.SetDropdownListCDB(77);
                    ddlStudentStatus.DataTextField = "CallerStatus";
                    ddlStudentStatus.DataValueField = "Id";
                    ddlStudentStatus.DataBind();

                    ddlTerm.DataSource = s.SetDropdownListCDB(59);
                    ddlTerm.DataTextField = "Term";
                    ddlTerm.DataValueField = "TermID";
                    ddlTerm.DataBind();

                    ddlMediasource.DataSource = s.SetDropdownListCDB(122);
                    ddlMediasource.DataTextField = "Description";
                    ddlMediasource.DataValueField = "Description";
                    ddlMediasource.DataBind();


                    ddlStudentStatus.SelectedValue = "0";

                }



                }

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string online = "0";
        if (chkonline.Checked == true)
            online = "O";
        else
            online = "0";
        Response.Redirect("PrintConsolidated.aspx?A=" + ddlTerm.SelectedValue + "&B=" + ddlStudentStatus.SelectedValue + "&C=" + "2" + "&D=" + ddlDegreeType.SelectedValue + "&E=33&F=" + Drpstatus.SelectedValue + "&G=" + online + "&H=" + ddlMediasource.SelectedValue, false);        


    }
}