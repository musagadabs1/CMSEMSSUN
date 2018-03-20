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

public partial class Pages_CPDChecklist : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EMPID"].ToString() != "918")
            {
                btn_finalize.Visible = false;
            }

            ddl_acadyear.DataSource = s.GetYear();
            ddl_acadyear.DataTextField = "TermYear";
            ddl_acadyear.DataValueField = "YearId";
            ddl_acadyear.DataBind();

           

            ddl_Sched.DataSource = s.getcpdcourseSchedule();
            ddl_Sched.DataTextField = "Degree_desc";
            ddl_Sched.DataValueField = "Degree_Id";
            ddl_Sched.DataBind();           
           
            for (int i = 0; i < 60; i++)
            {
                if (i <= 23)
                {
                    cbo_hh.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
                }
                cbo_mm.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
            }

            for (int i = 0; i < 60; i++)
            {
                if (i <= 23)
                {
                    cbo_th.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
                }
                cbo_tm.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
            }
            bindgrid();
        }

    }
   
      
    protected void btn_Add(object sender, EventArgs e)
    {        
            string course_Schedule = Convert.ToString(ddl_Sched.SelectedItem.Text);
          //  DateTime fromdate      = Convert.ToDateTime(txt_fromdate.Text);
            DateTime fromdate = DateTime.ParseExact(txt_fromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
          //  DateTime Todate        = Convert.ToDateTime(txt_ToDate.Text);
            DateTime Todate   = DateTime.ParseExact(txt_ToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string FromTime        = Convert.ToString(cbo_hh.Text) + ":" + Convert.ToString(cbo_mm.Text);
            string ToTime          = Convert.ToString(cbo_th.Text) + ":" + Convert.ToString(cbo_tm.Text);
            bool sunday            = chk_Sun.Checked;
            bool Monday            = chk_Mon.Checked;
            bool tuesday           = chk_Tue.Checked;
            bool Wednesday         = chk_Wed.Checked;
            bool Thursday          = chk_Thu.Checked;
            bool friday            = chk_fri.Checked;
            bool saturday          = chk_Sat.Checked;
            bool finalize;
            finalize = false;
            string Createdby = Session["EMPID"].ToString();
            DateTime CreatedDate =Convert.ToDateTime(DateTime.Now.ToString());
            string CreatedIp = GetMacAddress();
            string Remarks  = txt_remarks.Text;
            string ayear    = Convert.ToString(ddl_acadyear.SelectedItem.Value);
            int semesterId  = Convert.ToInt16(ddl_Semester.SelectedItem.Value);
            int termid = Convert.ToInt16(ddl_termname.SelectedItem.Value);
            s.InsertCpdCourseCalendar(course_Schedule, fromdate, Todate, FromTime, ToTime, sunday, Monday, tuesday, Wednesday, Thursday, friday, saturday, finalize, Createdby, CreatedDate, CreatedIp, Remarks, ayear, semesterId,termid);
            bindgrid();          
            chk_Sun.Checked = false;
            chk_Mon.Checked = false;
            chk_Tue.Checked = false;
            chk_Wed.Checked = false;
            chk_Thu.Checked = false;
            chk_fri.Checked = false;
            chk_Sat.Checked = false;
            lbl_msg.Visible = false;
      
    }
    protected void btn_Update(object sender, EventArgs e)
    {
        string course_Schedule = Convert.ToString(ddl_Sched.SelectedItem.Text);
        DateTime fromdate = DateTime.ParseExact(txt_fromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime Todate = DateTime.ParseExact(txt_ToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string FromTime = Convert.ToString(cbo_hh.Text) + ":" + Convert.ToString(cbo_mm.Text);
        string ToTime   = Convert.ToString(cbo_th.Text) + ":" + Convert.ToString(cbo_tm.Text);
        bool sunday     = chk_Sun.Checked;
        bool Monday     = chk_Mon.Checked;
        bool tuesday    = chk_Tue.Checked;
        bool Wednesday  = chk_Wed.Checked;
        bool Thursday   = chk_Thu.Checked;
        bool friday     = chk_fri.Checked;
        bool saturday   = chk_Sat.Checked;
        bool finalize;
        finalize = false;
        string Createdby = Session["EMPID"].ToString();
        DateTime CreatedDate = DateTime.Parse(DateTime.Now.ToString());
        string CreatedIp = GetMacAddress();
        string Remarks = Convert.ToString(txt_remarks.Text);
        int calendarid = Convert.ToInt16(HiddenField1.Value);
        string Ayear = ddl_acadyear.SelectedItem.Text;
        int semesterId = Convert.ToInt16(ddl_Semester.SelectedItem.Value);
        int termid = Convert.ToInt16(ddl_termname.SelectedItem.Value);
        s.UpdateCpdCourseCalendar(calendarid, course_Schedule, fromdate, Todate, FromTime, ToTime, sunday, Monday, tuesday, Wednesday, Thursday, friday, saturday, finalize, Createdby, CreatedDate, CreatedIp, Remarks, Ayear, semesterId, termid);
        bindgrid();
        btn_plus.Visible = true;
        btn_update.Visible = false;
        lbl_msg.Visible = false;

    }
    protected void GvTOC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();       
    
        HiddenField1.Value = Convert.ToString(e.CommandArgument);
        int Calid = Convert.ToInt32(HiddenField1.Value);
        if (e.CommandName == "EditRow")
        {
            DataTable dt = s.getcalendarcourseshed(Calid);
            if (dt.Rows.Count > 0)
            {
                HiddenField1.Value = dt.Rows[0]["calendarId"].ToString();
                ddl_acadyear.SelectedItem.Text = dt.Rows[0]["Ayear"].ToString();
                ddl_termname.DataSource = s.getTermName(Convert.ToString(ddl_acadyear.SelectedItem.Value));
                ddl_termname.DataTextField = "TermNAme";
                ddl_termname.DataValueField = "TermId";
                ddl_termname.DataBind();
                ddl_termname.SelectedItem.Value = dt.Rows[0]["TermId"].ToString();

                ddl_Semester.SelectedItem.Value = dt.Rows[0]["SEMESTER_ID"].ToString();
                ddl_Sched.SelectedItem.Text = dt.Rows[0]["Course_Schedule"].ToString();
                DateTime sfromdate = DateTime.Parse(dt.Rows[0]["cs_Fromdate"].ToString());
                txt_fromdate.Text = sfromdate.ToString("dd/MM/yyyy");
                DateTime sToDate   = DateTime.Parse(dt.Rows[0]["cs_Todate"].ToString());
                txt_ToDate.Text = sToDate.ToString("dd/MM/yyyy");

                string fromtime = dt.Rows[0]["fromtime"].ToString();
                string[] words  = fromtime.Split(':');
                cbo_hh.SelectedItem.Value = words[0];
                cbo_hh.SelectedItem.Text  = words[0];
                cbo_mm.SelectedItem.Value = words[1];
                cbo_mm.SelectedItem.Text  = words[1];

                string Totime = dt.Rows[0]["Totime"].ToString();
                string[] twords = Totime.Split(':');
                cbo_th.SelectedItem.Value = twords[0];
                cbo_th.SelectedItem.Text  = twords[0];
                cbo_tm.SelectedItem.Value = twords[1];
                cbo_tm.SelectedItem.Text  = twords[1];
                
                string dd = dt.Rows[0]["Wednesday"].ToString();

                if (dt.Rows[0]["Sunday"].ToString() == "True")
                {
                    chk_Sun.Checked = true;
                }
                else
                {
                    chk_Sun.Checked = false;
                }

                if (dt.Rows[0]["Moday"].ToString() == "True")
                {
                    chk_Mon.Checked = true;
                }
                else
                {
                    chk_Mon.Checked = false;
                }

                if (dt.Rows[0]["Tuesday"].ToString() == "True")
                {
                    chk_Tue.Checked = true;
                }
                else
                {
                    chk_Tue.Checked = false;
                }

                if (dt.Rows[0]["Wednesday"].ToString() == "True")
                {
                    chk_Wed.Checked = true;
                }
                else
                {
                    chk_Wed.Checked = false;
                }

                if (dt.Rows[0]["Thursday"].ToString() == "True")
                {
                    chk_Thu.Checked = true;
                }
                else
                {
                    chk_Thu.Checked = false;
                }

                if (dt.Rows[0]["Friday"].ToString() == "True")
                {
                    chk_fri.Checked = true;
                }
                else
                {
                    chk_fri.Checked = false;
                }

                if (dt.Rows[0]["Saturday"].ToString() == "True")
                {
                    chk_Sat.Checked = true;
                }
                else
                {
                    chk_Sat.Checked = false;
                }

                txt_remarks.Text = dt.Rows[0]["Remarks"].ToString();
                btn_update.Visible = true;
                btn_plus.Visible = false;
            }
        }
        if (e.CommandName == "DeleteRow")
        {            
            HiddenField1.Value = Convert.ToString(e.CommandArgument);
            s.Remove_CalendarScheduleCourse(Calid);           
        }
        bindgrid();
    }     

    protected void btn_removecoursesched(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid_tab.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidsnovalue = (HiddenField)row.FindControl("hid_cId");
                int hidid = Convert.ToInt16(hidsnovalue.Value);
                if (((CheckBox)row.FindControl("chk_approval")).Checked)
                {
                    s.Remove_CalendarScheduleCourse(hidid);
                }
            }
        }

        bindgrid();
    }
    protected void ddl_acyearSelectedIndexChanged(object sender, EventArgs e)
    {

        //Added by Shihab on 08/08/2017 to maintain the selection
        ddl_termname.DataSource = s.getTermName(Convert.ToString(ddl_acadyear.SelectedItem.Value));
        ddl_termname.DataTextField = "termname";
        ddl_termname.DataValueField = "ID";
        ddl_termname.DataBind();

        ddl_Semester.DataSource = s.GetSemester(Convert.ToString(ddl_acadyear.SelectedItem.Value));
        ddl_Semester.DataTextField = "Semester_Desc";
        ddl_Semester.DataValueField = "Semester_refID";
        ddl_Semester.DataBind();
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
    public void bindgrid()
    {
        grid_tab.DataSource = s.getcpdCourseCalendardetails(ddl_Sched.SelectedItem.Text);
        grid_tab.DataBind();
        lbl_msg.Visible = false;
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        ddl_acadyear.SelectedItem.Value = "---Select---";
        ddl_Semester.SelectedItem.Value = "0";
        ddl_Sched.SelectedItem.Value = "0";
        string ggg = ddl_Sched.SelectedItem.Text;
        txt_fromdate.Text = "";
        txt_ToDate.Text = "";
        cbo_hh.SelectedIndex = -1;
        cbo_mm.SelectedIndex = -1;
        cbo_th.SelectedIndex = -1;
        cbo_tm.SelectedIndex = -1;
        chk_Sun.Checked = false;
        chk_Mon.Checked = false;
        chk_Tue.Checked = false;
        chk_Wed.Checked = false;
        chk_Thu.Checked = false;
        chk_fri.Checked = false;
        chk_Sat.Checked = false;
        txt_remarks.Text = "";
        lbl_msg.Visible = false;
        bindgrid();
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CPDcourseschedulereport.aspx?A=" + ddl_Sched.SelectedItem.Value, false);
        Response.Redirect("CPDcourseschedulereport.aspx?A=" + ddl_acadyear.SelectedItem.Value, false);
        lbl_msg.Visible = false;
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
                    if (((CheckBox)row.FindControl("chk_approval")).Checked)
                    {
                        s.Finalize_CalendarScheduleCourse(hidid);
                        lbl_msg.Visible = false;
                    }
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
            HiddenField  HIdId = (HiddenField)e.Row.FindControl("Hid_Finalize");
            LinkButton linkbtn = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkdelete = (LinkButton)e.Row.FindControl("lnkdelete");
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            CheckBox chkapp = (CheckBox)e.Row.FindControl("chk_approval");
            if (HIdId.Value == "True")
            {
                e.Row.BackColor   = System.Drawing.Color.LightBlue;
                chkapp.Visible    = false;
                linkbtn.Visible   = false;
                lnkdelete.Visible = false;
            }
        }
    }


    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {

    }
}