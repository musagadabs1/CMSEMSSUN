using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;


public partial class Pages_ATSearch : System.Web.UI.Page
{
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string examtype;
                Session["EMPID1"] = Session["EMPID"].ToString();

                if (chkall.Checked == false)
                    Session["EMPID1"] = Session["EMPID"].ToString();
                else
                    Session["EMPID1"] = "0";
                if (rdoexternal.Checked == true)
                    examtype = "exter";
                else
                    examtype = "inter";
                Session["examtype"] = examtype;
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

               int index = Convert.ToInt32(e.CommandArgument);

               // Retrieve the row that contains the button 
               // from the Rows collection.
               GridViewRow row = gvDetails.Rows[index];
               
               HiddenField hn1 = (HiddenField)gvDetails.Rows[index].FindControl("hdnlink");
               HiddenField hn2 = (HiddenField)gvDetails.Rows[index].FindControl("hdnstatus");
               HiddenField hn3 = (HiddenField)gvDetails.Rows[index].FindControl("hdnexam");  
               
                Response.Redirect("ATDetails.aspx?Id="+hn1.Value+"&type="+hn3.Value+"&status="+hn2.Value);
                      }

        }
        catch (Exception ex)
        {
            
        }
    }

 
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;

    }
    protected void chkall_checkedchanged(object sender, EventArgs e)
    {
        //string examtype;
        //if (chkall.Checked == false)
        //    Session["EMPID1"] = Session["EMPID"].ToString();
        //else
        //    Session["EMPID1"] = "0";

        //dsDetails.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();
        //if (rdoexternal.Checked==true)
        //    examtype = "exter";
        //else
        //    examtype = "inter";
        //Session["examtype"]=examtype;

        //dsDetails.UpdateParameters["examtype"].DefaultValue =  Session["examtype"].ToString();
        //dsDetails.Update();

        SearchString = txtSearch.Text;

    }
    protected void rdointernal_CheckedChanged(object sender, EventArgs e)
    {
        Session["examtype"] = "inter";


    }
    protected void rdoexternal_CheckedChanged(object sender, EventArgs e)
    {
        Session["examtype"] = "exter";

    }
}
