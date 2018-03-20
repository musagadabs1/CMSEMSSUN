using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_StudentListForCheckList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            rdbName.Focus();
            if (!IsPostBack)
            {
                rdbName.Checked = true;
                gvStudentList.DataSource = "";
                gvStudentList.DataBind();
                LoadDropdown();
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
            int NonRegistered = 0;
            if (chkNonRegister.Checked == true)
                NonRegistered = 1;
            string EmpId = "";
            EmpId = Session["EmpId"].ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.GetStudentDetailsCHECKLIST(FilterBy, txtFilterValue.Text, NonRegistered, EmpId,Drpschool.SelectedValue);
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
                Response.Redirect(string.Format("CheckLists.aspx?Id=" + Id + "&Flag=" + chkNonRegister.Checked), false);




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
        Response.Redirect("NewRegistrant.aspx", false);
    }
}