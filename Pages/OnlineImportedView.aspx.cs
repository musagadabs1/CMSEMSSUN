using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

public partial class OnlineImportedView : System.Web.UI.Page
{

    //  Create a String to store our search results
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["EMPID1"] = Session["EMPID"].ToString();
                Session["option1"] = "1".ToString();
                if (chkall.Checked == false)
                    Session["EMPID1"] = Session["EMPID"].ToString();
                else
                    Session["EMPID1"] = "0";
                //dsDetails.SelectParameters.Add("empid", Session["EMPID1"].ToString());               
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

    }



    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
        RegExp.Replace("/", "");
        // Highlight keywords by calling the 
        //delegate each time a keyword is found.
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
    }

    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //  Set the value of the SearchString so it gets
        SearchString = txtSearch.Text;
    }

  
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        txtSearch.Text = "";
        SearchString = "";
        gvDetails.DataBind();
    }

    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                Response.Redirect(string.Format("FollowUp.aspx?Id={0}", Id), false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                Response.Redirect(string.Format("FollowUp.aspx?Id={0}", Id), false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewCaller.aspx", false);
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;

    }
    protected void chkall_checkedchanged(object sender, EventArgs e)
    {
        if (chkall.Checked == false)
            Session["EMPID1"] = Session["EMPID"].ToString();
        else
            Session["EMPID1"] = "0";

        dsDetails.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();

        dsDetails.Update();


    }
    protected void popup_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        string ids = gvDetails.DataKeys[gRow.RowIndex].Value.ToString();
        grdids.DataSource = s.GetOnlinedetailsIndividual(ids);
        grdids.DataBind();

        this.ModalPopupExtender1.Show();
    }
}