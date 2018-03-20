using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_FollowupCancelandPost : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //drpayyear.DataSource = s.SetDropdownwithparam(2, "0");
            //drpayyear.DataTextField = "Accadyear_Desc";
            //drpayyear.DataValueField = "acyear_id";
            //drpayyear.DataBind();
        }
    }
    
  protected void drpayyear_SelectedIndexChanged(object sender, EventArgs e)
    {

       
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            //ddlTerm.Items.Clear();

            //ddlTerm.DataSource = null;
            //ddlTerm.DataBind();
            //ddlTerm.DataSource = s.SetDropdownwithparam(1, drpayyear.SelectedValue);


            //ddlTerm.DataTextField = "TermName";
            //ddlTerm.DataValueField = "TermID";
            //ddlTerm.DataBind();
        
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //string Acyear = Convert.ToString(drpayyear.SelectedItem.Text);
        //int termid = Convert.ToInt16(ddlTerm.SelectedValue);
        string FromDate;
        string ToDate;
        try
        {
            FromDate = (DateTime.Parse(txtFromDate.Text)).ToShortDateString();
        }
        catch
        {
            FromDate = DateTime.Now.ToShortDateString();
        }
        try
        {
            ToDate = (DateTime.Parse(txtToDate.Text)).ToShortDateString();
        }
        catch
        {
            ToDate = DateTime.Now.ToShortDateString();
        }

        Response.Redirect("canpostreportviewer.aspx?FromDate=" + FromDate + "&ToDate=" + ToDate, false);        
    }
}