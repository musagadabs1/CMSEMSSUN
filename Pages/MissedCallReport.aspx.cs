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

public partial class Pages_MissedCallReport : System.Web.UI.Page
{
    int flag;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                flag = 0;
                if (Session["GroupName"].ToString() != "UAE")
                {
                    ddlCountry.SelectedValue = Session["GroupName"].ToString();
                    ddlCountry.Enabled = false;
                }
                //ddlCountry.DataSource = s.SetDropdownListCDB(2);
                //ddlCountry.DataTextField = "NationalityName";
                //ddlCountry.DataValueField = "NationalityCode";
                //ddlCountry.DataBind();
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
        //if (ChkSta.Checked == false)
        //{
        flag = 2;

        if (rdbstat.Checked == true)
        {
            flag = 1;

        }
       
        if (rdbdet.Checked == true)
        {
            flag = 3;
        }
      


        if(flag==2)
        {
            if (ddlCountry.SelectedIndex == 0)
            {   
                Lblerror.Text = "Please Select Country!!!";
                Lblerror.ForeColor =  System.Drawing.Color.Red;
              return;
            }
            else
                
            Lblerror.Text = "";

        }


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
        Lblerror.Text = "";
        //if (ChkSta.Checked == false)
        //{
          if(flag==2)
        {
            Response.Redirect("PrintMissedCall.aspx?A=" + FromDate + "&B=" + ToDate + "&D=" + ddlCountry.SelectedValue + "&C=" + ddlCountry.SelectedItem.Text, false);
        }
          else if (flag == 1)
          {
              Response.Redirect("PrintMissedCall.aspx?A=" + FromDate + "&B=" + ToDate + "&D=" + ddlCountry.SelectedValue + "&C=z", false);
          }
          else
          {
              Response.Redirect("PrintMissedCall.aspx?A=" + FromDate + "&B=" + ToDate + "&D=" + ddlCountry.SelectedValue + "&C=x", false);
          }
    
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (ddlCountry.SelectedIndex != 0)
             Lblerror.Text = "";
    }
   
}