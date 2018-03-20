using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_BBAGraduateAnalysisReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         StudentRegistrationDAL s = new StudentRegistrationDAL();
         if (!IsPostBack)
         {

             drpfromyear.DataSource = s.SetDropdownListCDB(128);
             drpfromyear.DataTextField = "AcadYear_Desc";
             drpfromyear.DataValueField = "AcadYear_Desc";
             drpfromyear.DataBind();

             drptoyear.DataSource = s.SetDropdownListCDB(128);
             drptoyear.DataTextField = "AcadYear_Desc";
             drptoyear.DataValueField = "AcadYear_Desc";
             drptoyear.DataBind();


         }

    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string EmpID = Session["EMPID"].ToString();
        Response.Redirect("PrintOtherReport.aspx?A=" + EmpID + "&B=" + drpfromyear.SelectedValue + "&C=" + drptoyear.SelectedValue  + "&E=41", false);
    }



}