using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_StudentListForEntranceUpdate : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            rdbName.Focus();
            if (!IsPostBack)
            {
                if ((Session["EMPID"].ToString() == "11049") || (Session["EMPID"].ToString() == "69") || (Session["EMPID"].ToString() == "10019") || (Session["EMPID"].ToString() == "225"))
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
                else
                {
                    Response.Redirect("login.aspx");

                }
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvStudentList.DataSource = "";
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
            System.Data.DataTable dt = s.GetStudentDetails(FilterBy, txtFilterValue.Text, NonRegistered, EmpId,Drpschool.SelectedValue);
            ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
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
                Response.Redirect(string.Format("EntranceResult.aspx?LinkId=" + Id), false);
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
    protected void gvStudentList_Sorted(object sender, EventArgs e)
    {
        try
        {
            string _expression = ViewState["_expression"].ToString();
            string _direction = ViewState["_direction"].ToString();

            System.Data.DataTable _ds = (System.Data.DataTable)ViewState["_ds_grid"];

            _ds.DefaultView.Sort = _expression + " " + _direction;

            gvStudentList.DataSource = _ds.DefaultView;
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvStudentList_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string _expression = e.SortExpression;
            string _direction = e.SortDirection.ToString();

            if (ViewState["_expression"] == null) { ViewState["_expression"] = ""; }
            if (ViewState["_direction"] == null) { ViewState["_direction"] = ""; }

            string _old_expression = ViewState["_expression"].ToString();
            string _old_direction = ViewState["_direction"].ToString();

            if (_expression == _old_expression)
            {
                if (_old_direction == "Asc")
                {
                    ViewState["_direction"] = "Desc";
                }
                else
                {
                    ViewState["_direction"] = "Asc";
                }
            }
            else
            {
                ViewState["_direction"] = "Asc";
                ViewState["_expression"] = _expression;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}