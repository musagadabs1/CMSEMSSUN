using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SeatAllocations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvBba.DataSource = s.SetDropdownListCDB(43);
            gvBba.DataBind();
            gvMba.DataSource = s.SetDropdownListCDB(44);
            gvMba.DataBind();
            gvBbaWeakend.DataSource = s.SetDropdownListCDB(45);
            gvBbaWeakend.DataBind();
            gvMbaWeakend.DataSource = s.SetDropdownListCDB(46);
            gvMbaWeakend.DataBind();
            gvShortCourse.DataSource = s.SetDropdownListCDB(47);
            gvShortCourse.DataBind();
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
}