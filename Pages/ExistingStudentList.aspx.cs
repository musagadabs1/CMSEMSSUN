﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Pages_ExistingStudentList : System.Web.UI.Page
{
    enum PageNav { First, Previous, Next, Last, None }
    private int iPageRecords;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            iPageRecords = 20;
            rdbName.Focus();
            if (!IsPostBack)
            {
                //rdbName.Checked = true;
                StudentRegistrationDAL s = new StudentRegistrationDAL();

                Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                Drpschool.DataTextField = "schoolname";
                Drpschool.DataValueField = "schoolcode";
                Drpschool.DataBind();
                Drpschool.SelectedValue = Session["schoolcode"].ToString();
                Drpschool_SelectedIndexChanged(sender, e);
                gvStudentList.DataSource = "";
                gvStudentList.DataBind();
                LoadDropdown();
                FillGridView(1, iPageRecords);
            }
        }
        catch
        {
            Response.Redirect("login.aspx");
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
    }
    private void FillGridView(int iPageNo, int iPageRecords)
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
            string EmpId = "";
            EmpId = Session["EmpId"].ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            System.Data.DataTable dt = s.GetExistingStudentDetails11(FilterBy, txtFilterValue.Text, NonRegistered, EmpId, iPageNo, iPageRecords,Drpschool.SelectedValue);
            ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();
            try
            {
                if (!IsPostBack)
                {
                    int iPageCount;
                    DataTable dt1 = new DataTable();
                    dt1 = s.Getrecordcount(FilterBy, txtFilterValue.Text, NonRegistered, EmpId, iPageNo, iPageRecords, Drpschool.SelectedValue);
                    iPageCount = Convert.ToInt32(dt1.Rows[0][0]);
                    if (iPageCount == 0)
                    {
                        rvPageNo.MaximumValue = "1";
                        iPageCount = 1;
                    }
                    else
                        rvPageNo.MaximumValue = iPageCount.ToString();
                    ViewState["PageCount"] = iPageCount;
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                    ViewState["currentPage"] = "1";
                }
                txtPageNo.Text = iPageNo.ToString();
                lblPages.Text = ViewState["PageCount"].ToString();
                lblStatus.Text = "Displaying Page : " + iPageNo.ToString() + " of " + ViewState["PageCount"].ToString();
            }
            catch
            {
            }
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
                Response.Redirect(string.Format("ExistingRegistration.aspx?Id=" + Id), false);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillGridView(1, iPageRecords);
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
            string _direction  = e.SortDirection.ToString();

            if (ViewState["_expression"] == null) { ViewState["_expression"] = ""; }
            if (ViewState["_direction"] == null)  { ViewState["_direction"]  = ""; }

            string _old_expression = ViewState["_expression"].ToString();
            string _old_direction  = ViewState["_direction"].ToString();

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
    private   void PageChange(int currentPage, PageNav pg)
    {
        int pageCount;
        pageCount = Convert.ToInt32(ViewState["PageCount"]);
        btnFirst.Enabled = true;
        btnPrev.Enabled = true;
        btnNext.Enabled = true;
        btnLast.Enabled = true;
        switch (pg)
        {
            case PageNav.First:
                currentPage = 1;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                break;
            case PageNav.Previous:
                if (currentPage == 2)
                {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
                currentPage--;
                break;
            case PageNav.Next:
                if (currentPage == pageCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                currentPage++;
                break;
            case PageNav.Last:
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                currentPage = Convert.ToInt32(ViewState["PageCount"]);
                break;
            case PageNav.None:
                if (currentPage == 1)
                {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
                else if (currentPage == pageCount)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                break;

        }
        FillGridView(currentPage, 20);
        ViewState["currentPage"] = currentPage;
    }
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        PageChange(Convert.ToInt32(ViewState["currentPage"]), PageNav.First);
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        PageChange(Convert.ToInt32(ViewState["currentPage"]), PageNav.Previous);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        PageChange(Convert.ToInt32(ViewState["currentPage"]), PageNav.Next);
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        PageChange(Convert.ToInt32(ViewState["currentPage"]), PageNav.Last);
    }
}