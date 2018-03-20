using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Pages_moufundalloted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            drpayyear.DataSource = s.SetDropdownwithparam(2, "0");
            drpayyear.DataTextField = "Accadyear_Desc";
            drpayyear.DataValueField = "acyear_id";
            drpayyear.DataBind();
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrintOtherReport.aspx?B=" + ddlprogram.SelectedValue + "&A=" + drpayyear.SelectedValue + "&E=26", false);
    }
   
}