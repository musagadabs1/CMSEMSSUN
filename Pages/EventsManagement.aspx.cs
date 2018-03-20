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



public partial class Pages_EventsManagement : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EMPID"].ToString() != "918")
            {
                btn_save.Visible = false;
            }

            ddl_Sched.DataSource = s.getcpdcourseSchedule();
            ddl_Sched.DataTextField = "Degree_desc";
            ddl_Sched.DataValueField = "Degree_Id";
            ddl_Sched.DataBind();

            ddl_Fyr.DataSource       = s.GetAcademicYear();
            ddl_Fyr.DataTextField    = "Accadyear_Desc";
            ddl_Fyr.DataValueField   = "acyear_id";
            ddl_Fyr.DataBind();         

            bindgrid();

        }
    }

    protected void Acyear_selectedindex_changed(object sender, EventArgs e)
    {
        ddl_Course_fee.DataSource = s.GetCourseFee(ddl_Fyr.SelectedItem.Value);
        ddl_Course_fee.DataTextField   = "Item";
        ddl_Course_fee.DataValueField  = "DetailsId";
        ddl_Course_fee.DataBind();
    }


    protected void CourseFee_Selectedindex_changed(object sender, EventArgs e)
    {
        DataTable dt = s.getCourseFeeDetails(Convert.ToInt16(ddl_Course_fee.SelectedItem.Value));
          if (dt.Rows.Count > 0)
          {
              txt_course_fee.Text = dt.Rows[0]["TotalFees"].ToString();
          }
    }
      

    protected void btn_Add(object sender, EventArgs e)
    {

        string Acadyear          = Convert.ToString(ddl_Fyr.SelectedItem.Text);
        string about             = Convert.ToString(txt_about.Text);
        string CourseIntro       = Convert.ToString(txt_crse_intro.Text);
        string minqualification  = Convert.ToString(txt_amqli.Text);
        string CarrerOpp = Convert.ToString(txt_co.Text);
        string Coursecontents    = Convert.ToString(txt_con.Text); 
        string course_schedule   = Convert.ToString(ddl_Sched.SelectedItem.Text);
        string Examination       = Convert.ToString(txt_exam.Text);
        string Course_fee        = Convert.ToString(txt_course_fee.Text);
       // DateTime RegisterDate  = Convert.ToDateTime(txt_regdate.Text); 
        //DateTime RegisterDate    = DateTime.ParseExact(txt_regdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string RegisterDate = txt_regdate.Text;
        string admission_req     = Convert.ToString(txt_ad_req.Text);
        string Refund_policy     = Convert.ToString(txt_refund_policy.Text);
        string General_terms     = Convert.ToString(txt_gt_con.Text);
        string schedulecourse    = Convert.ToString(txt_course_schedule.Text);
        string datedetails       = Convert.ToString(txt_datedetails.Text);
        string tpscoursefee      = Convert.ToString(ddl_Course_fee.SelectedItem.Text);
        int courseshedId         = Convert.ToInt16(ddl_Sched.SelectedItem.Value);
        int courseFeeId          = Convert.ToInt16(ddl_Course_fee.SelectedItem.Value);
       
         string Createdby = Session["EMPID"].ToString();
         DateTime CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
         string CreatedIp = GetMacAddress();
         s.InsertCpdcoursemangement(Acadyear, about, CourseIntro, minqualification, CarrerOpp, Coursecontents, course_schedule, Examination, Course_fee, RegisterDate, admission_req, Refund_policy, General_terms, Createdby, CreatedDate, CreatedIp, schedulecourse, datedetails, tpscoursefee, courseshedId, courseFeeId);
         bindgrid();
         ddl_Fyr.SelectedIndex = 0;
         ddl_Sched.SelectedIndex = 0;
         txt_about.Text = "";
         txt_crse_intro.Text = "";
         txt_amqli.Text = "";
         txt_co.Text = "";
         txt_con.Text = "";
         txt_exam.Text = "";
         txt_course_fee.Text = "";
         txt_regdate.Text = "";
         txt_ad_req.Text = "";
         txt_refund_policy.Text = "";
         txt_gt_con.Text = "";
         txt_course_schedule.Text = "";
         txt_datedetails.Text = "";

    }
    protected void GvTOC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();

        HiddenField1.Value = Convert.ToString(e.CommandArgument);
        int CPDid = Convert.ToInt32(HiddenField1.Value);
        if (e.CommandName == "EditRow")
        {
            DataTable dt = s.getCPDEdit(CPDid);
            if (dt.Rows.Count > 0)
            {
                HiddenField1.Value = dt.Rows[0]["CPDid"].ToString();

                ddl_Fyr.DataSource = s.GetAcademicYear();
                ddl_Fyr.DataTextField = "Accadyear_Desc";
                ddl_Fyr.DataValueField = "acyear_id";
                ddl_Fyr.DataBind();   

                ddl_Fyr.SelectedItem.Text = dt.Rows[0]["academicyear"].ToString();
                txt_about.Text = dt.Rows[0]["about"].ToString();
                txt_crse_intro.Text = dt.Rows[0]["course_intro"].ToString();
                txt_amqli.Text = dt.Rows[0]["aud_min_Qualify"].ToString();
                txt_co.Text = dt.Rows[0]["carrer_opp"].ToString();
                txt_con.Text = dt.Rows[0]["course_contents"].ToString();

                ddl_Sched.DataSource  =s.getcpdcourseSchedule();
                ddl_Sched.DataTextField = "Degree_desc";
                ddl_Sched.DataValueField = "Degree_Id";
                ddl_Sched.DataBind();

                ddl_Sched.SelectedItem.Text = dt.Rows[0]["course_schedule"].ToString();
                ddl_Sched.SelectedItem.Value = dt.Rows[0]["courseshedId"].ToString();

                txt_exam.Text = dt.Rows[0]["examination"].ToString();
                txt_course_fee.Text = dt.Rows[0]["course_fee"].ToString();
                DateTime regdate = DateTime.Parse(dt.Rows[0]["Register_date"].ToString());
                txt_regdate.Text = regdate.ToString("dd/MM/yyyy");
                txt_ad_req.Text = dt.Rows[0]["admission_req"].ToString();
                txt_refund_policy.Text = dt.Rows[0]["Refund_policy"].ToString();
                txt_gt_con.Text = dt.Rows[0]["General_terms"].ToString();
                txt_course_schedule.Text = dt.Rows[0]["schedulecourse"].ToString();
                txt_datedetails.Text = dt.Rows[0]["Datedetails"].ToString();

                ddl_Course_fee.DataSource = s.GetCourseFee(ddl_Fyr.SelectedItem.Value);
                ddl_Course_fee.DataTextField = "Item";
                ddl_Course_fee.DataValueField = "DetailsId";
                ddl_Course_fee.DataBind();

                ddl_Course_fee.SelectedItem.Text  = dt.Rows[0]["tpscoursefee"].ToString();
                //dl_Course_fee.SelectedItem.Value = dt.Rows[0]["courseFeeId"].ToString();
                btn_update.Visible = true;
                btn_plus.Visible = false;
            }
        }
        if (e.CommandName == "DeleteRow")
        {
            HiddenField1.Value = Convert.ToString(e.CommandArgument);
            s.Remove_CourseManagement(CPDid);
        }
        bindgrid();
    }
    protected void btn_Update(object sender, EventArgs e)
    {
        int CPDid = Convert.ToInt16(HiddenField1.Value);    
        string Acadyear = Convert.ToString(ddl_Fyr.SelectedItem.Text);
        string about = Convert.ToString(txt_about.Text);
        string CourseIntro = Convert.ToString(txt_crse_intro.Text);
        string minqualification = Convert.ToString(txt_amqli.Text);
        string CarrerOpp = Convert.ToString(txt_co.Text);
        string Coursecontents = Convert.ToString(txt_con.Text);

        string course_schedule = Convert.ToString(ddl_Sched.SelectedItem.Text);
        int courseshedId       = Convert.ToInt16(ddl_Sched.SelectedItem.Value);

        string Examination = Convert.ToString(txt_exam.Text);
        string Course_fee = Convert.ToString(txt_course_fee.Text);
       // DateTime RegisterDate = Convert.ToDateTime(txt_regdate.Text);
       // DateTime RegisterDate = DateTime.ParseExact(txt_regdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string RegisterDate = txt_regdate.Text;
        string[] CTo = new string[3];
        DateTime CToDate = DateTime.Now;
        if (txt_regdate.Text != "")
        {
            CTo = txt_regdate.Text.Split('/');
            CToDate = new DateTime(Convert.ToInt32(CTo[2]), Convert.ToInt32(CTo[1]), Convert.ToInt32(CTo[0]));
        }
        string admission_req  = Convert.ToString(txt_ad_req.Text);
        string Refund_policy  = Convert.ToString(txt_refund_policy.Text);
        string General_terms  = Convert.ToString(txt_gt_con.Text);
        string schedulecourse = Convert.ToString(txt_course_schedule.Text);
        string Datedetails    = Convert.ToString(txt_datedetails.Text);

        string tpscoursefee   = Convert.ToString(ddl_Course_fee.SelectedItem.Text); 
        int courseFeeId       = Convert.ToInt16(ddl_Course_fee.SelectedItem.Value);

        string Createdby = Session["EMPID"].ToString();
        DateTime CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
        string CreatedIp = GetMacAddress();
        s.UpdateCpdManagement(CPDid, Acadyear, about, CourseIntro, minqualification, CarrerOpp, Coursecontents, course_schedule, Examination, Course_fee, CToDate, admission_req, Refund_policy, General_terms, Createdby, CreatedDate, CreatedIp, schedulecourse, Datedetails, tpscoursefee, courseshedId, courseFeeId);
              

        ddl_Fyr.SelectedItem.Text = "---Select---";
        ddl_Sched.SelectedItem.Text = "---Select---";
        txt_about.Text = "";
        txt_crse_intro.Text = "";
        txt_amqli.Text = "";
        txt_co.Text = "";
        txt_con.Text = "";       
        txt_exam.Text = "";
        txt_course_fee.Text = "";
        txt_regdate.Text = "";
        txt_ad_req.Text = "";
        txt_refund_policy.Text = "";
        txt_gt_con.Text = "";
        txt_course_schedule.Text = "";
        txt_datedetails.Text = "";        
        bindgrid();
        btn_plus.Visible = true;
        btn_update.Visible = false;
        lbl_msg.Visible = false;     

    }
    public void bindgrid()
    {
        grid_tab.DataSource = s.getcpdCoursemanagement();
        grid_tab.DataBind();
        lbl_msg.Visible = false;
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
    protected void clear(object sender,  EventArgs e)
    {
        ddl_Fyr.SelectedItem.Text = "---Select---";
        ddl_Sched.SelectedItem.Text = "---Select---";
        txt_about.Text = "";
        txt_crse_intro.Text = "";
        txt_amqli.Text = "";
        txt_co.Text = "";
        txt_con.Text = "";
        txt_exam.Text = "";
        txt_course_fee.Text = "";
        txt_regdate.Text = "";
        txt_ad_req.Text = "";
        txt_refund_policy.Text = "";
        txt_gt_con.Text = "";
        txt_course_schedule.Text = "";
        txt_datedetails.Text = "";

    }
    protected void btn_finalize_click(object sender, EventArgs E)
    {
        foreach (GridViewRow row in grid_tab.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (((CheckBox)row.FindControl("chk_approval")).Checked)
                {
                    HiddenField hidsnovalue = (HiddenField)row.FindControl("hid_cId");
                    int hidid = Convert.ToInt16(hidsnovalue.Value);
                   // if (((CheckBox)row.FindControl("chk_approval")).Checked)
                   // {
                        s.Finalize_CPDManagement(hidid);
                        lbl_msg.Visible = false;
                   // }
                }
                else
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Style.Add("Color", "Red");
                }
            }
        }
        bindgrid();
    }
    protected void grid_tab_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField HIdId    = (HiddenField)e.Row.FindControl("Hid_Finalize");
            LinkButton linkbtn   = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkdelete = (LinkButton)e.Row.FindControl("lnkdelete");
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            CheckBox chkapp = (CheckBox)e.Row.FindControl("chk_approval");
            if (HIdId.Value == "1")
            {
                e.Row.BackColor = System.Drawing.Color.LightBlue;              
                linkbtn.Visible = false;
                lnkdelete.Visible = false;
            }
        }
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid_tab.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (((CheckBox)row.FindControl("chk_approval")).Checked)
                {
                    Label Lbl_year = (Label)row.FindControl("lbl_sc");
                    string acadyear = Convert.ToString(Lbl_year.Text);

                    Label lbl_schedulecourse = (Label)row.FindControl("lbl_shedcourse");
                    string lblsc = Convert.ToString(lbl_schedulecourse.Text);

                    HiddenField hid_shedcourseId = (HiddenField)row.FindControl("shedcourse_id");
                    int shedId = Convert.ToInt16(hid_shedcourseId.Value);

                    Response.Redirect("CpdEventsReport.aspx?A=" + acadyear + "&B=" + shedId, false);
                    lbl_msg.Visible = false;
                }
                else
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Please Choose the Title to print";                    
                }
            }
        }
    }

    protected void btn_print_Summary(object sender, EventArgs e)
    {
       Response.Redirect("CPDFLYERS.aspx", false);
       lbl_msg.Visible = false;
    }


}