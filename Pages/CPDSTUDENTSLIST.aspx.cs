using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class Pages_CPDSTUDENTSLIST : System.Web.UI.Page
{
    string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)    
    {
        if (!IsPostBack)
        {
          //  LoadGrid();
        }
    }

    public void LoadGrid()
    {
       // StudentRegistrationDAL s = new StudentRegistrationDAL();
       // System.Data.DataTable dt = s.GetExistingCPDStudentDetails();
       // gvStudDetails.DataSource = dt;
        gvStudDetails.DataBind();
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;

    }

    protected void button_search(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        txtSearch.Text = "";
        SearchString = "";
        LoadGrid();
    }
    
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudDetails.PageIndex = e.NewPageIndex;
        LoadGrid();
    }

    protected void gvTOC_OnSorting(object sender, EventArgs e)
    {
        divGridView.Page.SetFocus(gvStudDetails);
    }

    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Replace("(", "|").Replace(")", "|").Trim(), RegexOptions.IgnoreCase);
        RegExp.Replace("/", "");
        // Highlight keywords by calling the 
        //delegate each time a keyword is found.
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
    }

    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }

}