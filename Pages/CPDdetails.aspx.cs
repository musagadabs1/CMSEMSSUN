using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Reporting;
using CrystalDecisions;
using System.Net.NetworkInformation;
using System.Configuration;


public partial class Pages_CPDdetails : System.Web.UI.Page
{
   // static Table tableResult;
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    ReportDocument rptDoc = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {         

            if (!Page.IsPostBack)
            {
                ddl_acyear.DataSource     = s.GetYear();
                ddl_acyear.DataTextField  = "TermYear";
                ddl_acyear.DataValueField = "YearId";
                ddl_acyear.DataBind(); 

                //ddl_semester.DataSource     = s.GetSemester();
                //ddl_semester.DataTextField  = "Semester_Desc";
                //ddl_semester.DataValueField = "Semester_refID";
                //ddl_semester.DataBind();

                ddl_types.DataSource = s.getCPDTypes();
                ddl_types.DataTextField = "CPD_types";
                ddl_types.DataValueField = "Type_id";
                ddl_types.DataBind();

                bindMastergrid();
            }           
       
    }

    protected void ddl_acyearSelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_termname.DataSource = s.getTermName(Convert.ToString(ddl_acyear.SelectedItem.Value));
        ddl_termname.DataTextField = "termname";
        ddl_termname.DataValueField = "ID";
        ddl_termname.DataBind();

        //Added by Shihab on 08/08/2017 to maintain the selection
        ddl_semester.DataSource = s.GetSemester(Convert.ToString(ddl_acyear.SelectedValue));
        ddl_semester.DataTextField = "Semester_Desc";
        ddl_semester.DataValueField = "Semester_refID";
        ddl_semester.DataBind();
    }

    protected void ddl_semester_selectedindex_changed(object sender, EventArgs e)
    {
        ddl_shed_course.DataSource      = s.getschedulecourse(Convert.ToInt16(ddl_semester.SelectedItem.Value));
        ddl_shed_course.DataTextField   = "Course_Schedule";
        ddl_shed_course.DataValueField  = "Degree_Id";
        ddl_shed_course.DataBind();

        ddl_Faculty.DataSource      = s.getFaculty(Convert.ToInt16(ddl_semester.SelectedItem.Value));
        ddl_Faculty.DataTextField   = "Faculty_Name";
        ddl_Faculty.DataValueField  = "Faculty_id";
        ddl_Faculty.DataBind();
    }

    protected void ddl_type_SelectedindexChanged(object sender, EventArgs e)
    {
        bindgrid();
        btn_plus.Visible = false;
        lbl_acknow.Visible = false;
    }


    protected void ddl_schedcourse_selectedindex_changed(object sender, EventArgs e)
    {        

        DataTable dt = s.getMaxStudents(Convert.ToInt16(ddl_termname.SelectedItem.Value), Convert.ToString(ddl_shed_course.SelectedItem.Text));
         if (dt.Rows.Count > 0)
         {
             txt_Maxseat.Text = dt.Rows[0]["seat"].ToString();            
         }

         DataTable dt1 = s.getMinStudents(Convert.ToInt16(ddl_termname.SelectedItem.Value), Convert.ToString(ddl_shed_course.SelectedItem.Text));
         if (dt1.Rows.Count > 0)
         {
             txt_Minseat.Text = dt1.Rows[0]["seat"].ToString();
         }

    }  


    protected void btn_plus_click(object sender, EventArgs e)
     {
       // AddNewRowToGrid();        
        string acadyearid    = Convert.ToString(ddl_acyear.SelectedItem.Value);
        int termid           = Convert.ToInt16(ddl_termname.SelectedItem.Value);
        int semesterId       = Convert.ToInt16(ddl_semester.SelectedItem.Value);
        int courseId         = Convert.ToInt16(ddl_shed_course.SelectedItem.Value);
        int FacultyId        = Convert.ToInt16(ddl_Faculty.SelectedItem.Value);
        int targetstudents   = Convert.ToInt16(txt_Maxseat.Text);
        int achievedstudents = Convert.ToInt16(txt_Minseat.Text);
        int typeid           = Convert.ToInt16(ddl_types.SelectedItem.Value);

        int Result           = StudentRegistrationDAL.Insertcpdmasterdetails(acadyearid, termid, semesterId, courseId, FacultyId, targetstudents, achievedstudents);
        int submasterId = 0; int count = 0;

        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label activity = (Label)GridView1.Rows[count].FindControl("txt_Activities");
            DropDownList status1 = (DropDownList)GridView1.Rows[count].FindControl("ddl_status");
            DropDownList Responsibility = (DropDownList)GridView1.Rows[count].FindControl("ddl_res");
          
            string activities = Convert.ToString(activity.Text);
            int statusid = Convert.ToInt16(status1.SelectedItem.Value);
            int ResponseId = Convert.ToInt16(Responsibility.SelectedItem.Value);
            string empid = Session["EMPID"].ToString();
            submasterId = StudentRegistrationDAL.InsertCpdSubmasterDetails(Convert.ToInt32(Result), activities, statusid, ResponseId, empid, GetMacAddress(),Convert.ToInt16(typeid));
            count = count + 1;
        }
        int aa = Result;
        lbl_acknow.Visible = true;
        lbl_acknow.Text = "Saved Successfully";
        bindMastergrid();

    }

    protected void gridview1_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlCPDStatus = (e.Row.FindControl("ddl_status") as DropDownList);
            ddlCPDStatus.DataSource = s.ShowCPDStatus();
            ddlCPDStatus.DataTextField = "status_desc";
            ddlCPDStatus.DataValueField = "statusid";
            ddlCPDStatus.DataBind();

            DropDownList ddlresponse = (e.Row.FindControl("ddl_res") as DropDownList);
            ddlresponse.DataSource = s.ShowCPDResponsibility();
            ddlresponse.DataTextField = "Responsibility";
            ddlresponse.DataValueField = "ResId";
            ddlresponse.DataBind();

        }
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


    protected void ddl_types_selectedindexchanged(object sender, EventArgs e)
    {
        if (ddl_types.SelectedValue == "1")
        {
            lbl_types.Text = "Pre-Course";
        }
        else if (ddl_types.SelectedValue == "2")
        {
            lbl_types.Text = "During the Course";
        }
        else if (ddl_types.SelectedValue == "3")
        {
            lbl_types.Text = "Following Days";
        }
        else if (ddl_types.SelectedValue == "4")
        {
            lbl_types.Text = "Post Compilation Course";
        }
        else
        {
            lbl_types.Text = "CPD Details";
        }      

    }
    protected void btn_clear_click(object sender, EventArgs e)
    {
     
        ddl_types.SelectedValue = "0";       
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    

    public void bindgrid()
    {

        int typeid = Convert.ToInt16(ddl_types.SelectedItem.Value);

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
       
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_SHOW_CPDACTIVITIES";
        cmd.Parameters.AddWithValue("@type_Id", typeid);
  
        cmd.Connection = conn;
        try
        {
            conn.Open();
            GridView1.EmptyDataText = "No Records Found";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

    }


    protected void btn_print_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

      //  foreach (GridViewRow row in GridView2.Rows)
       // {
           // if (row.RowType == DataControlRowType.DataRow)
          //  {   

                    HiddenField hidacyearId = (HiddenField)row.FindControl("hid_acadid");
                    string acadyearid = Convert.ToString(hidacyearId.Value);

                    HiddenField hidtermid = (HiddenField)row.FindControl("hid_termid");
                    int  Termid = Convert.ToInt16(hidtermid.Value);

                    HiddenField hidsemid = (HiddenField)row.FindControl("hid_Semid");
                    int semid = Convert.ToInt16(hidsemid.Value);

                    HiddenField hiddegId = (HiddenField)row.FindControl("hid_degreeid");
                    int degreeid = Convert.ToInt16(hiddegId.Value);

                    HiddenField hidfacid = (HiddenField)row.FindControl("hid_Facid");
                    int facid = Convert.ToInt16(hidfacid.Value);

                    HiddenField hidtypeid = (HiddenField)row.FindControl("hid_typeid");
                    int MasterId = Convert.ToInt16(hidtypeid.Value);

                    Response.Redirect("precourse.aspx?A=" + MasterId, false);                                 
                
           // }
      //  }
    }

    public void bindMastergrid()
    {
        GridView2.DataSource = s.getcpdmasterdetailsgrid();
        GridView2.DataBind();        
    }

    protected void ddl_termname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_semester.DataSource = s.GetSemesterCPD(ddl_acyear.SelectedValue.ToString());
        ddl_semester.DataTextField = "Semester_Desc";
        ddl_semester.DataValueField = "Semester_refID";
        ddl_semester.DataBind();
    }
}