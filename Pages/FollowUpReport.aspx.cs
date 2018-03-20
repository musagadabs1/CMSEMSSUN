﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;


public partial class Pages_FollowUpReport : System.Web.UI.Page
{

    //  Create a String to store our search results
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
               
                      //dsDetails.SelectParameters.Add("empid", Session["EMPID1"].ToString());   
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                Drpschool.DataTextField = "schoolname";
                Drpschool.DataValueField = "schoolcode";
                Drpschool.DataBind();
                Drpschool.SelectedValue = Session["schoolcode"].ToString();
                Drpschool_SelectedIndexChanged(sender, e);
                Session["EMPID1"] = Session["EMPID"].ToString();
                Session["schoolcode1"] = Drpschool.SelectedValue;
                Session["option1"] = "1".ToString();
                if (chkall.Checked == false)
                    Session["EMPID1"] = Session["EMPID"].ToString();
                else
                    Session["EMPID1"] = "0";

            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
       
    }

    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        gvDetails.DataSource = null;
        gvDetails.DataBind();
        Session["schoolcode1"] = Drpschool.SelectedValue;
       

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

    protected void Imgcancel_Click(object sender, ImageClickEventArgs e)
    {
       
        getpanel("1");


    }
    protected void Imgpost_Click(object sender, ImageClickEventArgs e)
    {
        getpanel("2");
    }
    protected void getpanel(string opt)
    {
        pnlgeneral.Visible = false;
        Panel1.Visible = true;
        Session["option1"] = opt;
        if (chkall.Checked == false)
            Session["EMPID1"] = Session["EMPID"].ToString();
        else
            Session["EMPID1"] = "0";
       SqlDataSource1.UpdateParameters["option"].DefaultValue = Session["option1"].ToString();
       SqlDataSource1.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();
         SqlDataSource1.UpdateParameters["schoolcode"].DefaultValue = Session["schoolcode1"].ToString();
     

       SqlDataSource1.Update();
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
        dsDetails.UpdateParameters["schoolcode"].DefaultValue = Session["schoolcode1"].ToString();
                dsDetails.Update();


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataView dv = (DataView)dsDetails.Select(DataSourceSelectArguments.Empty);
            DataTable dt = new DataTable();
            dt = dv.ToTable();

            string result = ExcelUtility.ToExcel(dt);
            ExcelUtility.ExportToExcel(result);
        }
        catch
        {
            // lbl_ack.Visible = true;
            // lbl_ack.Text = "Please check Excel configuration !!!";
        }
    }
    protected void dsDetails_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 0;
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 0;
    }
}
