using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

public partial class Pages_DeletePermanently : System.Web.UI.Page
{
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["EMPID1"] = Session["EMPID"].ToString();

            if (chkall.Checked == false)
                Session["EMPID1"] = Session["EMPID"].ToString();
            else
                Session["EMPID1"] = "0";
            //dsDetails.SelectParameters.Add("empid", Session["EMPID1"].ToString());

        }


        lblMesagesp.Text = "";
    }
    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
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
                hdnplink.Value = Id;
                ModalPopupExtender2.Show();
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
    protected void btnpsave_Click(object sender, EventArgs e)
    {


        lblMesagesp.Text = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string RegisterNo = s.DeletePermanent(Session["EMPID"].ToString(), int.Parse(hdnplink.Value), txtpremarks.Text);
        if (RegisterNo == "0")
        {
            lblMesagesp.Text = "Try again!!!";
            lblMesagesp.ForeColor = System.Drawing.Color.Red;

        }
        else
        {
            lblMesagesp.Text = "Data Deleted Successfully!!!";
            lblMesagesp.ForeColor = System.Drawing.Color.Blue;
        }
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
}