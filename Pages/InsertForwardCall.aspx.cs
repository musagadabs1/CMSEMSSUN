using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_InsertForwardCall : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtCallDate.Text = (DateTime.Now).ToString();
                string Id = Request.QueryString["Id"].ToString();
                string sid = Request.QueryString["sid"].ToString();
                SetData(Id);
                this.FillGridView();
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ddlStudentStatus.DataSource = s.SetDropdownListCDB(8);
                ddlStudentStatus.DataTextField = "CallerStatus";
                ddlStudentStatus.DataValueField = "Id";
                ddlStudentStatus.DataBind();

                if (Session["GroupName"].ToString() == "UAE")
                {
                    ddlForwardedTo1.DataSource = s.SetDropdownListCDB(51,sid);
                    ddlForwardedTo1.DataTextField = "Name";
                    ddlForwardedTo1.DataValueField = "EMPID";
                    ddlForwardedTo1.DataBind();
                }
                else
                {
                    ddlForwardedTo1.DataSource = s.SetDropdownListCDB(62,sid);
                    ddlForwardedTo1.DataTextField = "Name";
                    ddlForwardedTo1.DataValueField = "EMPID";
                    ddlForwardedTo1.DataBind();
                }

                LoadDropdown();
                txtLinkId.Text = Request.QueryString["Id"].ToString();
                txtLinkId_TextChanged(sender, e);
            }
            catch
            {
                Response.Redirect("FollowUpReport.aspx", false);
            }
        }
    }
    protected void txtLinkId_TextChanged(object sender, EventArgs e)
    {
        SetData();
    }
    public void SetData()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetStudentDetails(int.Parse(txtLinkId.Text));
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
                ddlCourseType.SelectedValue = ro["CourseType"].ToString();
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

                if (ddlPrevStudentStatus.SelectedValue == "4")
                {
                    btnUpdate.Visible = false;
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
    public void LoadDisplayCaller()
    {
        if (ddlCallerCategory.SelectedItem.Text != "Student")
        {
            pnlForStudent.Visible = false;
            pnlForVendor1.Visible = false;
            pnlForVendor2.Visible = true;
            pnlForVendor4.Visible = true;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(82);
            rfReligion.InitialValue = "0";
        }
        else
        {
            pnlForStudent.Visible = true;
            pnlForVendor1.Visible = true;
            pnlForVendor2.Visible = false;
            pnlForVendor4.Visible = false;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(77);
            rfReligion.InitialValue = "9999";
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();

        ddlNationality.DataSource = s.SetDropdownListCDB(2);
        ddlNationality.DataTextField = "NationalityName";
        ddlNationality.DataValueField = "NationalityCode";
        ddlNationality.DataBind();

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

        ddlStudentStatus.DataSource = s.SetDropdownListCDB(8);
        ddlStudentStatus.DataTextField = "CallerStatus";
        ddlStudentStatus.DataValueField = "Id";
        ddlStudentStatus.DataBind();

        ddlPrevStudentStatus.DataSource = s.SetDropdownListCDB(8);
        ddlPrevStudentStatus.DataTextField = "CallerStatus";
        ddlPrevStudentStatus.DataValueField = "Id";
        ddlPrevStudentStatus.DataBind();

        //ddlFormStatus.DataSource = s.SetDropdownListCDB(9);
        //ddlFormStatus.DataTextField = "FormStatus";
        //ddlFormStatus.DataValueField = "Id";
        //ddlFormStatus.DataBind();

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

        ddlCourseType.DataSource = s.SetDropdownListCDB(15);
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
    private void FillGridView()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.GetFollowUpDetails("0", Request.QueryString["Id"].ToString(), "0","0");
            gvStudentList.DataBind();
            gvForwardedTo.DataSource = s.GetForwardedHistory(Request.QueryString["Id"].ToString());
            gvForwardedTo.DataBind();
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
    protected void gvForwardedTo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
            try
            {
                Label lblEntryDate = (Label)e.Row.FindControl("lblEntryDate");
                Label lblForwardedTo3 = (Label)e.Row.FindControl("lblForwardedTo");
                if (lblEntryDate.Text == (DateTime.Now.ToString("MM/dd/yyyy")))
                {
                    lblForwardedMessage.Text = "Recently this Call is forwarded to " + lblForwardedTo3.Text + "!";
                }
            }
            catch
            {

            }

        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    public void SetData(string Id)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.GetCaller(Id);
        foreach (DataRow ro in dt.Rows)
        {
            txtName.Text = ro["Name"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                if (Session["Name"].ToString() == ddlForwardedTo1.SelectedItem.Text)
                {
                    lblMesag.Text = "You can n't forward to Yourself!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            catch
            {
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            s.InsertFollowUp(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), "2", ddlForwardedTo1.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()));
            lblMesag.Text = "Sucessfully Updated!!!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
            //alertmessage.Show("Data Updated Successfully!");
            //Response.Redirect("FollowUpReport.aspx", false);
            FillGridView();
        }
        catch
        {
            //alertmessage.Show("Please Try Again!");
            lblMesag.Text = "Try Again!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
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
            rfReligion.InitialValue = "0";
        }
        else
        {
            pnlForStudent.Visible = true;
            pnlForVendor1.Visible = true;
            pnlForVendor2.Visible = false;
            pnlForVendor4.Visible = false;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(77);
            rfReligion.InitialValue = "9999";
        }
        ModalPopupExtender1.Show();
    }
}