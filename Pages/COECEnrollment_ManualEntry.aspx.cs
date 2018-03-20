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
using com.vectramind.mobile;
using System.Text;

public partial class Pages_COECEnrollment_ManualEntry : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }

        if ((Session["EMPID"].ToString() == "1636") || (Session["EMPID"].ToString() == "918"))
        {
        }
        else
        {
            Response.Redirect("login.aspx");

        }
        
    }

    private void FillGridView1()
    {
      

        try
        {
            lblmess.Text = "";
            if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }

            if (ddlTerm.SelectedValue == "0")
            {
                lblmess.Text = "Select Term";
                lblmess.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (txtFromDate.Text == "")
            {
                lblmess.Text = "Select Date";
                lblmess.ForeColor = System.Drawing.Color.Red;
                return;
            }


            lblmess.Text = "";
            gvStudentList.DataSource = s.InsertCOECnationwise_Tilldatesummery(0, 0, 0, 0, 0, txtFromDate.Text, 0, "DISPLAY", ddlTerm.SelectedValue); 
            gvStudentList.DataBind();

        }
        catch (Exception ex)
        {

        }
    }




    protected void btnsave_Click(object sender, EventArgs e)
    {
        lblmess.Text = "";
        if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (ddlTerm.SelectedValue=="0")
        {
            lblmess.Text = "Select Term";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (txtFromDate.Text=="")
        {
            lblmess.Text = "Select Date";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;
        }
         DataTable dt=null;
        try
        {
        foreach (GridViewRow gr in gvStudentList.Rows)
        {
          
            Label lblyear = (Label)gr.FindControl("lblyear");
            TextBox txtbbaweekday = (TextBox)gr.FindControl("txtbbaweekday");
            TextBox txtbbaweekend = (TextBox)gr.FindControl("txtbbaweekend");
            TextBox txtmbaweekday = (TextBox)gr.FindControl("txtmbaweekday");
            TextBox txtmbaweekend = (TextBox)gr.FindControl("txtmbaweekend");

           dt=s.InsertCOECnationwise_Tilldatesummery(int.Parse(lblyear.Text), int.Parse(txtbbaweekday.Text), int.Parse(txtbbaweekend.Text), int.Parse(txtmbaweekday.Text), int.Parse(txtmbaweekend.Text), txtFromDate.Text, int.Parse(Session["EmpId"].ToString()), "INSERT", ddlTerm.SelectedValue); 
            
        }

        if (dt.Rows[0][0].ToString() == "1".ToString())
        {
            lblmess.Text = "Saved Successfully";
            lblmess.ForeColor = System.Drawing.Color.Blue;
            return;
        }
        else
        {
            lblmess.Text = "Try Again";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;
        }
        }
        catch
        {
            lblmess.Text = "Try Again";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;


        }
       
    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridView1();
    }

    protected void txtFromDate_changed(object sender, EventArgs e)
    {
        FillGridView1();
    }
    protected void btnload_Click(object sender, EventArgs e)
    {
        FillGridView1();
    }
}