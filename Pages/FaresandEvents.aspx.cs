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
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;


public partial class Pages_FaresandEvents : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["EMPID"].ToString() != "918")
            //{
            //    btn_save.Visible = false;
            //}

            ddl_AcYear.DataSource = s.GetAcYear();
            ddl_AcYear.DataTextField = "YEAR";
            ddl_AcYear.DataValueField = "YEAR";
            ddl_AcYear.DataBind();

            ddl_month.DataSource = s.GetMonthName();
            ddl_month.DataTextField = "MonthName";
            ddl_month.DataValueField = "ID";
            ddl_month.DataBind();

            ddlRepresentative.DataSource = s.GetEmp();
            ddlRepresentative.DataTextField ="Name";
            ddlRepresentative.DataValueField ="EmpNumber";
            ddlRepresentative.DataBind();
           // bindgrid();

            Fillgridview();

        }

    }
    protected void ddl_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadExhibition();
    }

    private void LoadExhibition()
    {
        ddl_Title .DataSource = s.GetExhibition(ddl_AcYear.SelectedValue, Convert.ToInt32(ddl_month.SelectedValue));
        ddl_Title.DataTextField = "EventTitle";
        ddl_Title.DataValueField = "Cal_UniqueID";
        ddl_Title.DataBind();
    }
    protected void ddl_Title_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable Dt = s.GetExbhibitionDatetime(Convert.ToInt32(ddl_Title .SelectedValue));
        txt_StartDate.Text = Dt.Rows[0]["StartDate"].ToString();
        txt_EndDate.Text = Dt.Rows[0]["EndDate"].ToString();
        txt_Fromtime.Text = Dt.Rows[0]["Starttime"].ToString();
        txt_totime.Text = Dt.Rows[0]["Endtime"].ToString();
    }

    protected void Save_form(object sender, EventArgs e)
    {
        
        int ID = Convert.ToInt16(Hid_Id.Value) ;
        string ENTRYTYPE="";
        if(Radbut1.Checked )
        {
        ENTRYTYPE="1";
        }
        else
        {
        ENTRYTYPE="2";
        }
        string ACADYEAR= Convert.ToString(ddl_AcYear.SelectedItem.Value); 
        string MONTH= Convert.ToString(ddl_month.SelectedItem.Value);
        string TITLE = "";
        if (Radbut1.Checked)
        {
            TITLE = Convert.ToString(ddl_Title.SelectedItem.Value);

        }
        else
        {
            TITLE = Convert.ToString(txt_title.Text);
        }

        DateTime STARTDATE = Convert.ToDateTime(txt_StartDate.Text);
        DateTime ENDDATE = Convert.ToDateTime(txt_EndDate.Text);
        string FROMTIME = Convert.ToString(txt_Fromtime.Text);
        string TOTIME = Convert.ToString(txt_totime.Text);
            string EVENT_TYPE = Convert.ToString(txt_type.Text);
            string REMARKS = Convert.ToString(txt_Remarks.Text);
            string PARTICIPATION_FEE = Convert.ToString(txt_Participationfee.Text);
            string PAYMENT_STATUS = Convert.ToString(txt_Paymentsts.Text);
            string LOCATION = Convert.ToString(txt_Location.Text);
            string REPRESENTATIVE = Convert.ToString(ddlRepresentative.SelectedItem.Value);
            string FORMS_COLLECTOR = Convert.ToString(txt_Formscollector.Text);

            string REPORT_SUBMISSION = "";
            if (Rad_Submit.Checked)
            {
                REPORT_SUBMISSION = "Submitted";
            }
            else
            {
                REPORT_SUBMISSION = "Pending";
            }
            string SUBMISSION_REMARKS = Convert.ToString(txt_FinalRemarks.Text);
            string OPERATION = "INSERT";
            string CREATEDBY = Convert.ToString(Session["EmpId"].ToString());
            string CREATEDIP = GetMacAddress();


            s.INSERT_FARESANDEVENTS(ID, ENTRYTYPE, ACADYEAR, MONTH, TITLE, STARTDATE, ENDDATE, FROMTIME, TOTIME, EVENT_TYPE, REMARKS, PARTICIPATION_FEE,
                PAYMENT_STATUS, LOCATION, REPRESENTATIVE, FORMS_COLLECTOR, REPORT_SUBMISSION, SUBMISSION_REMARKS, OPERATION, CREATEDBY, CREATEDIP);
     


        lblmsg.Visible = true;


        if (ID == 0)
        {
            lblmsg.Text = "Successfully Inserted!!!";
        }
        else
        {
            lblmsg.Text = "Successfully Updated!!!";
        }
        lblmsg.Style.Add("color", "Green");
        lblmsg.Style.Add("Font-size", "10px");
        lblmsg.Style.Add("font-weight", "bold");

        Fillgridview();
        //Bindgrid();
        //btnupdate.Visible = false;
        //txt_af.Enabled = true;
    }


    

    public string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                nic.OperationalStatus == OperationalStatus.Up)
            {
                return Convert.ToString(nic.GetPhysicalAddress());
            }
        }
        return null;
    }


    protected void Fillgridview()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        System.Data.DataTable dt = s.GetFaresandEvents();
       // ViewState["_ds_grid"] = dt;
        gvFaresandevents.DataSource = dt;
        gvFaresandevents.DataBind();
    }


    protected void GvFaresandEvents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRow")
        {
            btn_Save.Text = "UPDATE";
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            Hid_Id.Value = Convert.ToString(arg[0]);

            DataTable dt = s.GETFARESANDEVENTS(Convert.ToInt32(Hid_Id.Value));

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ENTRYTYPE"].ToString() == "1")
                {
                    Radbut1.Checked = true;
                    txt_title.Visible = false;
                }
                else
                {
                    Radbut2.Checked = true;
                    txt_title.Visible = true;
                    ddl_Title.Visible = false;
                }

                ddl_AcYear.Items.Clear();
                ddl_AcYear.DataSource = s.GetAcYear();
                ddl_AcYear.DataTextField = "YEAR";
                ddl_AcYear.DataValueField = "YEAR";
                ddl_AcYear.DataBind();
                ddl_AcYear.SelectedValue = dt.Rows[0]["Acadyear"].ToString();


                ddl_month.Items.Clear();
                ddl_month.DataSource = s.GetMonthName();
                ddl_month.DataTextField = "MonthName";
                ddl_month.DataValueField = "ID";
                ddl_month.DataBind();
                ddl_month.SelectedValue = dt.Rows[0]["Month"].ToString();

                if (dt.Rows[0]["ENTRYTYPE"].ToString() == "1")
                {
                    ddl_Title.Items.Clear();
                    ddl_Title.DataSource = s.GetExhibition(ddl_AcYear.SelectedValue, Convert.ToInt32(ddl_month.SelectedValue));
                    ddl_Title.DataTextField = "EventTitle";
                    ddl_Title.DataValueField = "Cal_UniqueID";
                    ddl_Title.DataBind();
                    ddl_Title.SelectedValue = dt.Rows[0]["TITLE"].ToString();
                }
                else
                {
                    txt_title.Text = dt.Rows[0]["TITLE"].ToString();
                }

                
                txt_StartDate.Text =  dt.Rows[0]["STARTDATE"].ToString();
                txt_EndDate.Text = dt.Rows[0]["ENDDATE"].ToString();
                txt_Fromtime.Text = dt.Rows[0]["FROMTIME"].ToString();
                txt_totime.Text = dt.Rows[0]["TOTIME"].ToString();
                txt_type.Text = dt.Rows[0]["EVENT_TYPE"].ToString();
                txt_Remarks.Text = dt.Rows[0]["REMARKS"].ToString();
                txt_Participationfee.Text = dt.Rows[0]["PARTICIPATION_FEE"].ToString();
                txt_Paymentsts.Text = dt.Rows[0]["PAYMENT_STATUS"].ToString();
                txt_Location.Text = dt.Rows[0]["PAYMENT_STATUS"].ToString();

                ddlRepresentative.Items.Clear();
                ddlRepresentative.DataSource = s.GetEmp();
                ddlRepresentative.DataTextField = "Name";
                ddlRepresentative.DataValueField = "EmpNumber";
                ddlRepresentative.DataBind();
                ddlRepresentative.SelectedItem.Text = dt.Rows[0]["REPRESENTATIVE"].ToString();


                txt_Formscollector.Text = dt.Rows[0]["FORMS_COLLECTOR"].ToString();
                if (dt.Rows[0]["Report_Submission"].ToString() == "Submitted")
                {
                    Rad_Submit.Checked = true;
                }
                else
                {
                    Rad_Pending.Checked = true;
                }
                txt_FinalRemarks.Text = dt.Rows[0]["SUBMISSION_REMARKS"].ToString();
            }             
           
        }
      
    }

}



