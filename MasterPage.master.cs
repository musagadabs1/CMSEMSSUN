using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EmpId"].ToString() == "")
               Response.Redirect("Login.aspx", false);
            if (Session["EmpId"].ToString() == null)
               Response.Redirect("Login.aspx", false);
            //if (Session["EmpId"].ToString() == "10069")
            //{
               MasterTab.Visible = true;
            //}
            string Thoughts = "";
            DataTable dt = new DataTable();
            Attendance a = new Attendance();
            dt = a.GetWeek(int.Parse(Session["EmpId"].ToString()));
            foreach (DataRow ro in dt.Rows)
            {
                Thoughts = ro[0].ToString();
            }
            lblUserName.Text = "Welcome " + Session["Name"].ToString() + " !";
            lblDate.Text = (DateTime.Now).ToString("dd/MM/yyyy");
            lblThougt.Text = Thoughts;

            DataTable dt1 = new DataTable();
            try
            {
                dt1 = a.GetEnrollDates(int.Parse(Session["EmpId"].ToString()));
                string enroll = "";
                foreach (DataRow ro in dt1.Rows)
                {
                    enroll = enroll + " " + ro[0].ToString();
                }
                Lbldates.Text = "ENROLLMENT DEADLINE: " + enroll;
            }
            catch
            {

            }
            
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            int Count = s.IsMissedCall(int.Parse(Session["EmpId"].ToString()));
            if (Count > 0)
            {
                imgRequest.ImageUrl = "~/Icons/notifcation-message.png";
                lblCount.Visible = true;
                div1.Visible = true;
                lblCount.Text = Count.ToString();
            }
            else
            {
                imgRequest.ImageUrl = "~/Icons/notification-on.png";
                lblCount.Visible = false;
                div1.Visible = false;
            }



            int fCount = s.IsFollowupschedule(int.Parse(Session["EmpId"].ToString()));
            if (fCount > 0)
            {
                imgRequest1.ImageUrl = "~/Icons/notifcation-message.png";
                lblCount1.Visible = true;
                div2.Visible = true;
                lblCount1.Text = fCount.ToString();
            }
            else
            {
                imgRequest1.ImageUrl = "~/Icons/notification-on.png";
                lblCount1.Visible = false;
                div2.Visible = false;
            }


            try
            {
                int vCount = s.IsVisitschedule(int.Parse(Session["EmpId"].ToString()));
                if (vCount > 0)
                {
                    Image1.ImageUrl = "~/Icons/notifcation-message.png";
                    Lblvisit.Visible = true;
                    div3.Visible = true;
                    Lblvisit.Text = vCount.ToString();
                    Session["vcount"] = vCount;
                }
                else
                {
                    Image1.ImageUrl = "~/Icons/notification-on.png";
                    Lblvisit.Visible = false;
                    div3.Visible = false;
                }

            }

            catch
            {


            }

            if (Session["EmpId"].ToString() == "918")
            {
                pnl_mark.Visible = true;
            }
            else
            {
                pnl_mark.Visible = false;
            }

            //gvBba.DataSource = s.SetDropdownListCDB(43);
            //gvBba.DataBind();
            //gvMba.DataSource = s.SetDropdownListCDB(44);
            //gvMba.DataBind();
            //gvBbaWeakend.DataSource = s.SetDropdownListCDB(45);
            //gvBbaWeakend.DataBind();
            //gvMbaWeakend.DataSource = s.SetDropdownListCDB(46);
            //gvMbaWeakend.DataBind();
            //gvShortCourse.DataSource = s.SetDropdownListCDB(47);
            //gvShortCourse.DataBind();

            if (Session["GroupName"].ToString() == "UAE")
                dvHide.Visible = true;
            else
                dvHide.Visible = false;
        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }
    }
    protected void gvBBA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("SeatAllocationStatus.aspx?Id=14&CId=" + e.CommandArgument.ToString(), false);
    }
    protected void gvMBA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("SeatAllocationStatus.aspx?Id=15&CId=" + e.CommandArgument.ToString(), false);
    }
    protected void gvBBAWeekend_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("SeatAllocationStatus.aspx?Id=16&CId=" + e.CommandArgument.ToString(), false);
    }
    protected void gvMBAWeakend_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("SeatAllocationStatus.aspx?Id=17&CId=" + e.CommandArgument.ToString(), false);
    }
    protected void gvShortCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("SeatAllocationStatus.aspx?Id=18&CId=" + e.CommandArgument.ToString(), false);
    }
    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            int Count = s.IsMissedCall(int.Parse(Session["EmpId"].ToString()));
            if (Count > 0)
            {
                imgRequest.ImageUrl = "~/Icons/notifcation-message.png";
                lblCount.Visible = true;
                div1.Visible = true;
                lblCount.Text = Count.ToString();
            }
            else
            {
                imgRequest.ImageUrl = "~/Icons/notification-on.png";
                lblCount.Visible = false;
                div1.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
}
