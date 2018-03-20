using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CancelPospond : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rdbName.Focus();
        if (!IsPostBack)
        {
            rdbName.Checked = true;
            gvStudentList.DataSource = "";
            gvStudentList.DataBind();
            LoadDropdown();
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //ddlCallerCategory.DataSource = s.SetDropdownListCDB(8);
        //ddlCallerCategory.DataTextField = "CCName";
        //ddlCallerCategory.DataValueField = "CCId";
        //ddlCallerCategory.DataBind();
    }
    private void FillGridView()
    {
        lblMesag.Text = "";
        try
        {
            string FilterBy = "All";
            if (rdbNumber.Checked == true)
                FilterBy = "Number";
            if (rdbEmail.Checked == true)
                FilterBy = "Email";
            if (rdbName.Checked == true)
                FilterBy = "Name";
            if (rdbCancel.Checked == true)
                FilterBy = "Cancel";
            if (rdbPospond.Checked == true)
                FilterBy = "Postponed";
            if (rdbRejected.Checked == true)
                FilterBy = "Rejected";
            int NonRegistered = 0;
            if (chkNonRegister.Checked == true)
                NonRegistered = 1;
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.GetCancelList(FilterBy, txtFilterValue.Text, NonRegistered);
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Fill Correct Information!";
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
            Label lblDegree = (Label)e.Row.FindControl("lblDegree");
            try
            {
                if (int.Parse(lblDegree.Text) == 1)
                    lblDegree.Text = "BBA";
                else if (int.Parse(lblDegree.Text) == 6)
                    lblDegree.Text = "MBA";
                else if (int.Parse(lblDegree.Text) == 7)
                    lblDegree.Text = "BBA Weekend";
                else if (int.Parse(lblDegree.Text) == 8)
                    lblDegree.Text = "MBA Weekend";
                else if (int.Parse(lblDegree.Text) == 9)
                    lblDegree.Text = "Short Course";
                if (int.Parse(lblDegree.Text) == 0)
                    lblDegree.Text = "";
            }
            catch
            {
            }
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                //Response.Redirect(string.Format("StudentRegistration.aspx?Id={0}", Id), false);
                Response.Redirect(string.Format("CancelDetails.aspx?Id=" + Id + "&Flag=" + chkNonRegister.Checked), false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillGridView();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelDetails.aspx", false);
    }
}