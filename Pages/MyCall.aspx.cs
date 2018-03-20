using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_MyCall : System.Web.UI.Page
{
    enum PageNav { First, Previous, Next, Last, None }
    private int iPageRecords;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        try
        {
            Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
            Drpschool.DataTextField = "schoolname";
            Drpschool.DataValueField = "schoolcode";
            Drpschool.DataBind();
            Drpschool.SelectedValue = Session["schoolcode"].ToString();
       
        Drpschool_SelectedIndexChanged(sender, e);
        iPageRecords = 20;
        if (!IsPostBack)
        {
           
            ddlPrevStudentStatus.Enabled = false;
            rdbNumber.Focus();
            LoadDropdown();
            try
            {
                int Val = int.Parse(Request.QueryString["Val"].ToString());
                ddlCallType.SelectedValue = Val.ToString();
            }
            catch
            {
                //Response.Redirect("Login.aspx", false);
            }
            this.FillGridView(1, iPageRecords);      
          //  rdbName.Checked = true;
        }
        }
        catch
        {
            //Response.Redirect("login.aspx");
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
        ddlCallType.DataSource = s.SetDropdownListCDB(35);
        ddlCallType.DataTextField = "Status";
        ddlCallType.DataValueField = "Id";
        ddlCallType.DataBind();

        ddlNationality.DataSource = s.SetDropdownListCDB(2);
        ddlNationality.DataTextField = "NationalityName";
        ddlNationality.DataValueField = "NationalityCode";
        ddlNationality.DataBind();
        try
        {
            if (Session["GroupName"].ToString() == "UAE")
            {
                ddlForwardedTo.DataSource = s.SetDropdownListCDB(51);
                ddlForwardedTo.DataTextField = "Name";
                ddlForwardedTo.DataValueField = "EMPID";
                ddlForwardedTo.DataBind();
            }
            else
            {
                ddlForwardedTo.DataSource = s.SetDropdownListCDB(62);
                ddlForwardedTo.DataTextField = "Name";
                ddlForwardedTo.DataValueField = "EMPID";
                ddlForwardedTo.DataBind();
            }
        }
        catch
        {
        }
        
        ddlPrevStudentStatus.DataSource = s.SetDropdownListCDB(8);
        ddlPrevStudentStatus.DataTextField = "CallerStatus";
        ddlPrevStudentStatus.DataValueField = "Id";
        ddlPrevStudentStatus.DataBind();

        ddlPrevStudentStatus.DataSource = s.SetDropdownListCDB(8);
        ddlPrevStudentStatus.DataTextField = "CallerStatus";
        ddlPrevStudentStatus.DataValueField = "Id";
        ddlPrevStudentStatus.DataBind();

        ddlProspectSstatus.DataSource = s.SetDropdownListCDB(10);
        ddlProspectSstatus.DataTextField = "ProspectStatus";
        ddlProspectSstatus.DataValueField = "Id";
        ddlProspectSstatus.DataBind();

        ddlReferredBy.DataSource = s.SetDropdownListCDB(11);
        ddlReferredBy.DataTextField = "RefferedBy";
        ddlReferredBy.DataValueField = "Id";
        ddlReferredBy.DataBind();

        ddlTitle.DataSource = s.SetDropdownListCDB(12);
        ddlTitle.DataTextField = "Title";
        ddlTitle.DataValueField = "Id";
        ddlTitle.DataBind();

        ddlIndustry.DataSource = s.SetDropdownListCDB(13);
        ddlIndustry.DataTextField = "Industry";
        ddlIndustry.DataValueField = "Id";
        ddlIndustry.DataBind();

        ddlDegreeType.DataSource = s.SetDropdownListCDB(14);
        ddlDegreeType.DataTextField = "Description";
        ddlDegreeType.DataValueField = "Id";
        ddlDegreeType.DataBind();

        //ddlCourseType.DataSource = s.SetDropdownListCDB(15);
        //ddlCourseType.DataTextField = "Description";
        //ddlCourseType.DataValueField = "Id";
        //ddlCourseType.DataBind();
        ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1, int.Parse(ddlDegreeType.SelectedValue));
        ddlCourseType.DataTextField = "Description";
        ddlCourseType.DataValueField = "Id";
        ddlCourseType.DataBind();

        lbMediaSource.DataSource = s.SetDropdownListCDB(16);
        lbMediaSource.DataTextField = "MediaSource";
        lbMediaSource.DataValueField = "Id";
        lbMediaSource.DataBind();

        ddlCallerCategory.DataSource = s.SetDropdownListCDB(20);
        ddlCallerCategory.DataTextField = "CCName";
        ddlCallerCategory.DataValueField = "Id";
        ddlCallerCategory.DataBind();

        ddlReligion.DataSource = s.SetDropdownListCDB(34);
        ddlReligion.DataTextField = "Religion";
        ddlReligion.DataValueField = "Id";
        ddlReligion.DataBind();
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
           
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = s.GetMyCallList(Session["EmpId"].ToString(), FilterBy, txtFilterValue.Text, ddlCallType.SelectedValue, iPageNo, iPageRecords,Drpschool.SelectedValue);

            ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();

            try
            {
                if (!IsPostBack)
                {
                    int iPageCount;
                    DataTable dt1 = new DataTable();
                    dt1 = s.GetMyCallListRowcount(Session["EmpId"].ToString(), FilterBy, txtFilterValue.Text, ddlCallType.SelectedValue, iPageNo, iPageRecords,Drpschool.SelectedValue);
                  
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
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                txtLinkId.Text = Id;
                txtLinkId_TextChanged(sender, e);
                btnUpdate.Enabled = true;
                lblMesages.Text = "";
                try
                {
                    
                    Response.Redirect(string.Format("EditNewcaller.aspx?Id={0}", Id), false);
                }

                catch
                {

                }
                //ModalPopupExtender1.Show();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }


     


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillGridView(1,iPageRecords);
    }
    protected void txtLinkId_TextChanged(object sender, EventArgs e)
    {
        SetData();
    }
    public void SetData()
    {
        try
        {
            ddlPrevStudentStatus.Enabled = true;
            txtCallPrevDate.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtMiddleName.Enabled = true;
            ddlTitle.Enabled = true;
            ddlNationality.Enabled = true;
            txtAttendedBy.Enabled = true;
            txtEmailID.Enabled = true;
            txtMobileNo.Enabled = true;
            ddlDegreeType.Enabled = true;
            ddlCourseType.Enabled = true;
            ddlPrevStudentStatus.Enabled = true;
            txtPrevRemarks.Enabled = true;
            ddlReferredBy.Enabled = true;
            ddlForwardedTo.Enabled = true;
            txtSchool.Enabled = true;
            ddlArabNonArab.Enabled = true;
            txtTelephone.Enabled = true;
            ddlCurrentlyEmployee.Enabled = true;
            ddlCallerCategory.Enabled = true;
            ddlProspectSstatus.Enabled = true;
            txtCompanyName.Enabled = true;
            txtDesignation.Enabled = true;
            ddlReligion.Enabled = true;
            ddlNationality.Enabled = true;
            ddlIndustry.Enabled = true;
            txtWebsite.Enabled = true;
            txtFax.Enabled = true;
            txtPoBox.Enabled = true;
            txtAddress.Enabled = true;
            txtCity.Enabled = true;
            lbMediaSource.Enabled = true;
            btnUpdate.Visible = true;
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetStudentMycallDetails(int.Parse(txtLinkId.Text));
            foreach (DataRow ro in dt.Rows)
            {
                txtCallPrevDate.Text = ro["CallDate"].ToString();
                txtFirstName.Text = ro["FirstName"].ToString();
                txtLastName.Text = ro["LastName"].ToString();
                txtMiddleName.Text = ro["MiddleName"].ToString();
                ddlTitle.SelectedValue = ro["Title"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                txtAttendedBy.Text = Session["Name"].ToString();
                txtEmailID.Text = ro["EmailID"].ToString();
                txtMobileNo.Text = ro["MobileNo"].ToString();
                ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
                ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1, int.Parse(ddlDegreeType.SelectedValue));
                ddlCourseType.DataTextField = "Description";
                ddlCourseType.DataValueField = "Id";
                ddlCourseType.DataBind();

                try
                {
                    ddlCourseType.SelectedValue = ro["CourseType"].ToString();
                }
                catch
                {
                }
                ddlPrevStudentStatus.SelectedValue = ro["StudentStatus"].ToString();
                txtPrevRemarks.Text = ro["Remarks"].ToString();
                ddlReferredBy.SelectedItem.Text = ro["RefferedBy"].ToString();
                ddlForwardedTo.SelectedValue = ro["ForwardedTo"].ToString();
                txtSchool.Text = ro["SchoolUniversity"].ToString();
                ddlArabNonArab.SelectedItem.Text = ro["ArabNonArab"].ToString();
                txtTelephone.Text = ro["Telephone"].ToString();
                ddlCurrentlyEmployee.SelectedItem.Text = ro["IsEmployeed"].ToString();
                ddlCallerCategory.SelectedValue = ro["CallerCategoryId"].ToString();
                ddlProspectSstatus.SelectedValue = ro["ProspectStatus"].ToString();
                ModalPopupExtender1.Show();

                txtCompanyName.Text = ro["CompanyName"].ToString();
                txtDesignation.Text = ro["Designation"].ToString();
                ddlReligion.SelectedValue = ro["Religion"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                ddlIndustry.SelectedValue = ro["Industry"].ToString();
                txtWebsite.Text = ro["Website"].ToString();
                txtFax.Text = ro["Fax"].ToString();
                txtPoBox.Text = ro["PoBox"].ToString();
                txtAddress.Text = ro["Address"].ToString();
                txtCity.Text = ro["City"].ToString();
                if (ddlPrevStudentStatus.SelectedItem.Text == "Enrolled")
                {
                    ddlPrevStudentStatus.Enabled = false;
                    txtCallPrevDate.Enabled = false;
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtMiddleName.Enabled = false;
                    ddlTitle.Enabled = false;
                    ddlNationality.Enabled = false;
                    txtAttendedBy.Enabled = false;
                    txtEmailID.Enabled = false;
                    txtMobileNo.Enabled = false;
                    ddlDegreeType.Enabled = false;
                    ddlCourseType.Enabled = false;
                    ddlPrevStudentStatus.Enabled = false;
                    txtPrevRemarks.Enabled = false;
                    ddlReferredBy.Enabled = false;
                    ddlForwardedTo.Enabled = false;
                    txtSchool.Enabled = false;
                    ddlArabNonArab.Enabled = false;
                    txtTelephone.Enabled = false;
                    ddlCurrentlyEmployee.Enabled = false;
                    ddlCallerCategory.Enabled = false;
                    ddlProspectSstatus.Enabled = false;
                    txtCompanyName.Enabled = false;
                    txtDesignation.Enabled = false;
                    ddlReligion.Enabled = false;
                    ddlNationality.Enabled = false;
                    ddlIndustry.Enabled = false;
                    txtWebsite.Enabled = false;
                    txtFax.Enabled = false;
                    txtPoBox.Enabled = false;
                    txtAddress.Enabled = false;
                    txtCity.Enabled = false;
                    btnUpdate.Visible = false;
                    txtLinkId.Enabled = false;
                }
                try
                {
                    for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
                    {
                        string[] words = ro["MediaSource"].ToString().Split(',');
                        foreach (string word in words)
                        {
                            if (lbMediaSource.Items[i].Text == word)
                            {
                                lbMediaSource.Items[i].Selected = true;
                            }
                        }
                    }
                    lbMediaSource.Enabled = false;
                }
                catch
                {
                }
                LoadDisplayCaller();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("FollowupIndividual.aspx?Id=" + txtLinkId.Text, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblMesag.Text = "";
            string MediaSource = "";
            for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
            {
                if (lbMediaSource.Items[i].Selected == true)
                {
                    MediaSource = MediaSource + lbMediaSource.Items[i].Text + ",";
                }
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string RegisterNo = s.UpdateStudentDetailsMyCall(int.Parse(txtLinkId.Text), "", DateTime.Parse(txtCallPrevDate.Text),
                0, int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, "",
                "", "", ddlNationality.SelectedValue, Session["EMPID"].ToString(), ddlForwardedTo.SelectedValue,
                ddlProspectSstatus.SelectedValue, "", txtPrevRemarks.Text, "1", ddlPrevStudentStatus.SelectedValue, ddlReferredBy.SelectedItem.Text, txtMobileNo.Text,
                txtEmailID.Text, ddlCourseType.SelectedValue, ddlDegreeType.SelectedValue, MediaSource, Session["EmpId"].ToString(), txtCompanyName.Text, txtDesignation.Text, txtTelephone.Text, txtFax.Text,
                txtPoBox.Text, ddlArabNonArab.SelectedItem.Text, ddlCurrentlyEmployee.SelectedItem.Text, txtSchool.Text, ddlIndustry.SelectedValue, txtWebsite.Text, txtAddress.Text, txtCity.Text, ddlCallerCategory.SelectedValue, "", "", DateTime.Now, "", ddlReligion.SelectedValue,"No");
            lblMesages.Text = "Data Update Successfully!!!";
            lblMesages.ForeColor = System.Drawing.Color.Blue;
            //alertmessage.Show("Data Update Successfully!");
            btnUpdate.Enabled = false;
            FillGridView(1,iPageRecords);
            //ModalPopupExtender1.Hide();
        }
        catch
        {
            lblMesages.Text = "Please Try Again!!!";
            lblMesages.ForeColor = System.Drawing.Color.Red;
            //alertmessage.Show("Data Saved Updated!");
        }
    }
    protected void ddlCallerCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCallerCategory.SelectedItem.Text != "Student")
        {
            pnlForStudent.Visible = false;
            pnlForVendor1.Visible = false;
            pnlForVendor2.Visible = true;
            pnlForVendor4.Visible = true;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(82);
            rfCourseType.ControlToValidate = "txtCompanyName";
            rfCourseType.ErrorMessage = "Company Name Required!";
            rfReligion.InitialValue = "0";
            rfCourseType.InitialValue = "";
        }
        else
        {
            pnlForStudent.Visible = true;
            pnlForVendor1.Visible = true;
            pnlForVendor2.Visible = false;
            pnlForVendor4.Visible = false;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(77);
            rfCourseType.ControlToValidate = "ddlCourseType";
            rfCourseType.ErrorMessage = "Please Select Course Type!";
            rfReligion.InitialValue = "9999";
            rfCourseType.InitialValue = "0";
        }
        ModalPopupExtender1.Show();               
    }
    public void LoadDisplayCaller()
    {
        if (ddlCallerCategory.SelectedItem.Text != "Student")
        {
            pnlForStudent.Visible = false;
            pnlForVendor1.Visible = false;
            pnlForVendor2.Visible = true;
            pnlForVendor4.Visible = true;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(82);
            rfCourseType.ControlToValidate = "txtCompanyName";
            rfCourseType.ErrorMessage = "Company Name Required!";
            rfReligion.InitialValue = "0";
            rfCourseType.InitialValue = "";
        }
        else
        {
            pnlForStudent.Visible = true;
            pnlForVendor1.Visible = true;
            pnlForVendor2.Visible = false;
            pnlForVendor4.Visible = false;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(77);
            rfCourseType.ControlToValidate = "ddlCourseType";
            rfCourseType.ErrorMessage = "Please Select Course Type!";
            rfReligion.InitialValue = "9999";
            rfCourseType.InitialValue = "0";
        }
        ModalPopupExtender1.Show();    
    }
    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1, int.Parse(ddlDegreeType.SelectedValue));
        ddlCourseType.DataTextField = "Description";
        ddlCourseType.DataValueField = "Id";
        ddlCourseType.DataBind();
        ModalPopupExtender1.Show();               
    }


    private void PageChange(int currentPage, PageNav pg)
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