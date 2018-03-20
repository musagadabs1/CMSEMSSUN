using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MissedCall : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       try
       {
           if (!IsPostBack)
           {
               this.FillGridView();
               StudentRegistrationDAL s = new StudentRegistrationDAL();
               Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
               Drpschool.DataTextField = "schoolname";
               Drpschool.DataValueField = "schoolcode";
               Drpschool.DataBind();
               Drpschool.SelectedValue = Session["schoolcode"].ToString();

               Drpschool_SelectedIndexChanged(sender, e);
           }
       }
           catch
       {
   Response.Redirect("Login.aspx");

           }
            }

    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvStudentList.DataSource = null;
        gvStudentList.DataBind();

    }
    private void FillGridView()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.GetMissCalledList(int.Parse(Session["EmpId"].ToString()),Drpschool.SelectedValue);
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                //string Result = s.InsertAttendCall(Id);
                //Response.Redirect(string.Format("FollowUp.aspx?Id={0}", Id), false);
                Response.Redirect("FollowUp.aspx?Id=" + Id + "&A=" + "M", false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}