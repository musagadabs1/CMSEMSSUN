﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_EnrollmentReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                pnlReportViwer.Visible = false;
            }
            if (IsPostBack)
            {
                //btnSubmit_Click(sender, e);
            }
        }
        catch
        {
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string EmpID = Session["EMPID"].ToString();
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
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Degree = "0";
        //if (ddlDegree.SelectedValue == "9")
        //    Degree = "9";

            Degree = ddlDegree.SelectedValue; 
        Response.Redirect("PrintOtherReport.aspx?A=" + ddlCountry.SelectedValue + "&B=" + FromDate + "&C=" + ToDate + "&D=" + Degree + "&E=6", false);
    }
}