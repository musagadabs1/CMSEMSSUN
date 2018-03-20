using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SeatAllocationStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int Id = int.Parse(Request.QueryString["Id"].ToString());
                int CourseType = int.Parse(Request.QueryString["CId"].ToString());
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                gvStudentList.DataSource = s.SetDropdownListAsDegreeType(Id, CourseType);
                gvStudentList.DataBind();
            }
            catch
            {
            }
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
}