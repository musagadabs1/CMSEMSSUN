using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EmpId"].ToString() == "" || Session["EmpId"].ToString() == null)
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
            lblDate.Text = (DateTime.Now).ToString();
            lblThougt.Text = Thoughts;

            // For Pie Chart For Form Status
            //DataTable dtChart = new DataTable();
            //StudentRegistrationDAL s = new StudentRegistrationDAL();
            //dtChart = s.GetMyCallList(Session["EmpId"].ToString());
            //int TotalProspect = 0;
            //int TotalRegistered = 0;
            //int TotalSuspended = 0;
            //int TotalDropOut = 0;
            //foreach (DataRow ro in dtChart.Rows)
            //{
            //    TotalProspect = int.Parse(ro["TotalProspect"].ToString());
            //    TotalRegistered = int.Parse(ro["TotalRegistered"].ToString());
            //    TotalSuspended = int.Parse(ro["TotalSuspended"].ToString());
            //    TotalDropOut = int.Parse(ro["TotalDropOut"].ToString());
            //}

            //Series series1 = Chart1.Series[0];
            //int ptIdx;
            //DataPoint pt;

            //ptIdx = Chart1.Series["Series1"].Points.AddXY("1", TotalProspect);
            //Chart1.Series["Series1"].Points[ptIdx].Url = "MyCall.aspx?Val=21";
            //pt = Chart1.Series["Series1"].Points[ptIdx];
            //pt.LegendUrl = "MyCall.aspx?Val=21";
            //pt.LegendText = "Prospect";

            //ptIdx = Chart1.Series["Series1"].Points.AddXY("2", TotalRegistered);
            //Chart1.Series["Series1"].Points[ptIdx].Url = "MyCall.aspx?Val=22";
            //pt = Chart1.Series["Series1"].Points[ptIdx];
            //pt.LegendUrl = "MyCall.aspx?Val=22";
            //pt.LegendText = "Registered";

            //ptIdx = Chart1.Series["Series1"].Points.AddXY("3", TotalSuspended);
            //Chart1.Series["Series1"].Points[ptIdx].Url = "MyCall.aspx?Val=24";
            //pt = Chart1.Series["Series1"].Points[ptIdx];
            //pt.LegendUrl = "MyCall.aspx?Val=24";
            //pt.LegendText = "Suspended";

            //ptIdx = Chart1.Series["Series1"].Points.AddXY("4", TotalDropOut);
            //Chart1.Series["Series1"].Points[ptIdx].Url = "MyCall.aspx?Val=23";
            //pt = Chart1.Series["Series1"].Points[ptIdx];
            //pt.LegendUrl = "MyCall.aspx?Val=23";
            //pt.LegendText = "DropOut";
            
            //// For Pie Chart For Visitor
            //dtChart = s.GetMyStudentStatus(Session["EmpId"].ToString());
            //int Visitor = 0;
            //int Caller = 0;
            //int FollowUp = 0;
            //int Converted = 0;
            //foreach (DataRow ro in dtChart.Rows)
            //{
            //    Visitor = int.Parse(ro["Visitor"].ToString());
            //    Caller = int.Parse(ro["Caller"].ToString());
            //    FollowUp = int.Parse(ro["FollowUp"].ToString());
            //    Converted = int.Parse(ro["Converted"].ToString());
            //}

            //Series series2 = Chart2.Series[0];
            //int ptIdx1;
            //DataPoint pt1;
            //ptIdx1 = Chart2.Series["Series2"].Points.AddXY("1", Visitor);
            //Chart2.Series["Series2"].Points[ptIdx1].Url = "MyCall.aspx?Val=11";
            //pt1 = Chart2.Series["Series2"].Points[ptIdx1];
            //pt1.LegendUrl = "MyCall.aspx?Val=11";
            //pt1.LegendText = "Visitor";

            //ptIdx1 = Chart2.Series["Series2"].Points.AddXY("2", Caller);
            //Chart2.Series["Series2"].Points[ptIdx1].Url = "MyCall.aspx?Val=12";
            //pt1 = Chart2.Series["Series2"].Points[ptIdx1];
            //pt1.LegendUrl = "MyCall.aspx?Val=12";
            //pt1.LegendText = "Caller";

            //ptIdx1 = Chart2.Series["Series2"].Points.AddXY("3", FollowUp);
            //Chart2.Series["Series2"].Points[ptIdx1].Url = "MyCall.aspx?Val=13";
            //pt1 = Chart2.Series["Series2"].Points[ptIdx1];
            //pt1.LegendUrl = "MyCall.aspx?Val=13";
            //pt1.LegendText = "FollowUp";

            //ptIdx1 = Chart2.Series["Series2"].Points.AddXY("4", Converted);
            //Chart2.Series["Series2"].Points[ptIdx1].Url = "MyCall.aspx?Val=14";
            //pt1 = Chart2.Series["Series2"].Points[ptIdx1];
            //pt1.LegendUrl = "MyCall.aspx?Val=14";
            //pt1.LegendText = "Converted";
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
                Session["fcount"] = fCount;
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




        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }
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