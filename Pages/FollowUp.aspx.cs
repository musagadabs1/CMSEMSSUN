using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_FollowUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtCallDate.Text = (DateTime.Now).ToString();
                string Id = Request.QueryString["Id"].ToString();
                SetData(Id);
                this.FillGridView();
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                try
                {
                    string regno = "";
                    regno = s.GetRegNo1(Id);
                    lblregno.Text = "Registration No : " + regno;

                }
                catch
                {
                    lblregno.Text = "";
                }              
                ddlStudentStatus.DataSource = s.SetDropdownListCDB(123);
                ddlStudentStatus.DataTextField = "CallerStatus";
                ddlStudentStatus.DataValueField = "Id";
                ddlStudentStatus.DataBind();

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
             
                ddlAcademicYear.DataSource = s.SetDropdownListCDB(83);
                ddlAcademicYear.DataTextField = "FNAME";
                ddlAcademicYear.DataValueField = "Id";
                ddlAcademicYear.DataBind();

                DrpNQ.DataSource = s.SetDropdownListCDB(121);
                DrpNQ.DataTextField = "Description";
                DrpNQ.DataValueField = "Id";
                DrpNQ.DataBind();



                if (Session["GroupName"].ToString() == "UAE")
                {
                    ddlForwardedTo1.DataSource = s.SetDropdownListCDB(51);
                    ddlForwardedTo1.DataTextField = "Name";
                    ddlForwardedTo1.DataValueField = "EMPID";
                    ddlForwardedTo1.DataBind();
                }
                else
                {
                    ddlForwardedTo1.DataSource = s.SetDropdownListCDB(62);
                    ddlForwardedTo1.DataTextField = "Name";
                    ddlForwardedTo1.DataValueField = "EMPID";
                    ddlForwardedTo1.DataBind();
                    pnlNigeria1.Visible = true;
                    pnlNigeria2.Visible = true;
                }
                LoadDropdown();
                pnlnq.Visible = false;
                txtLinkId.Text =Request.QueryString["Id"].ToString();
                txtLinkId_TextChanged(sender, e);
                if (ddlCallerCategory.SelectedValue == "2")
                {
                    ddlStudentStatus.Enabled = false;
                    ddlStudentStatus.SelectedIndex = 0;
                    RequiredFieldValidator7.ControlToValidate = "txtCallDate";
                }
                ddlStudentStatus.SelectedIndex = 1;
                ddlStudentStatus.SelectedValue= "3";
            }


            catch
            {
                Response.Redirect("FollowUpReport.aspx", false);
            }

            try
            {
                if (Request.QueryString["A"].ToString() == "M")
                {
                    ddlStudentStatus.Enabled = false;
                    ddlStudentStatus.SelectedValue = "2";
                                }
                else
                {
                    ddlStudentStatus.Enabled = true;
                  
                }
            }
            catch
            {
                ddlStudentStatus.Enabled = true;
            }

            if (ddlStudentStatus.SelectedValue == "3")
            {
                pnlfollowup.Visible = true;
            }

            if (ddlStudentStatus.SelectedValue == "1")
            {
                pnlvisit.Visible = true;
            }

        }
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
    protected void txtLinkId_TextChanged(object sender, EventArgs e)
    {
        SetData();
    }
    public void SetData()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataSet dt = s.SetStudentDetailsUpdate(int.Parse(txtLinkId.Text));
            string events ="";
            foreach (DataRow ro in dt.Tables[0].Rows)
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
                events=ro["event"].ToString();

               


                try
                {
                 
                    ddlCourseType.SelectedValue = ro["CourseType"].ToString();
                       if(events=="1")
                     
                    {
                        ddlExhibition.DataSource = s.SetDropdownListCDB(53);
                        ddlExhibition.DataTextField = "Event";
                        ddlExhibition.DataValueField = "Id";
                        ddlExhibition.DataBind();
                    }



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

                foreach (DataRow ro1 in dt.Tables[1].Rows)
                {
                    try
                    {

                        txtGrade.Text = ro1["Grade"].ToString();
                        ddlAcademicYear.SelectedValue = ro1["academicyear"].ToString();
                        ddlExhibition.SelectedValue = ro1["event"].ToString();
                        chkTOC.Checked = bool.Parse(ro1["TOC"].ToString());

                    }
                    catch
                    {
                    }

                }

                Button2.Enabled = true;
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
                    Button2.Enabled = false;
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
            //pnlForStudent.Visible = false;
            pnlForVendor1.Visible = false;
            pnlForVendor2.Visible = true;
            pnlForVendor4.Visible = true;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(82);
            rfReligion.InitialValue = "0";
        }
        else
        {
            //pnlForStudent.Visible = true;
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
            rdotype.Enabled = true;
            ddlForwardedTo.DataSource = s.SetDropdownListnnew(rdotype.SelectedValue.ToString());
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

        try
        {
            ddlStudentStatus.Items.Clear();
            if (Request.QueryString["A"].ToString() == "M")
            {

                ddlStudentStatus.DataSource = s.SetDropdownListCDB(102);
                ddlStudentStatus.DataTextField = "CallerStatus";
                ddlStudentStatus.DataValueField = "Id";
                ddlStudentStatus.DataBind();
            }
            else
              
                {

                    ddlStudentStatus.DataSource = s.SetDropdownListCDB(123);
                    ddlStudentStatus.DataTextField = "CallerStatus";
                    ddlStudentStatus.DataValueField = "Id";
                    ddlStudentStatus.DataBind();
                }

        }
        catch
        {
            ddlStudentStatus.DataSource = s.SetDropdownListCDB(123);
            ddlStudentStatus.DataTextField = "CallerStatus";
            ddlStudentStatus.DataValueField = "Id";
            ddlStudentStatus.DataBind();
        }

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

        ddlCallerCategory.DataSource = s.SetDropdownListCDB(20);
        ddlCallerCategory.DataTextField = "CCName";
        ddlCallerCategory.DataValueField = "Id";
        ddlCallerCategory.DataBind();

        ddlReligion.DataSource = s.SetDropdownListCDB(34);
        ddlReligion.DataTextField = "Religion";
        ddlReligion.DataValueField = "Id";
        ddlReligion.DataBind();

        try
        {
            if (Request.QueryString["A"].ToString() == "M")
            {
                ddlStudentStatus.SelectedValue = "2";
                ddlStudentStatus.Enabled = false;
               

            }
            else
            {
                ddlStudentStatus.Enabled = true;
               
            }
        }
        catch
        {
            ddlStudentStatus.Enabled = true;
        }


    }
    private void FillGridView()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.GetFollowUpDetails("0", Request.QueryString["Id"].ToString(), "0","0");
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
    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        StudentRegistrationDAL s = new StudentRegistrationDAL();
    //        string Result = s.InsertFollowUp(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), ddlStudentStatus.SelectedValue, ddlForwardedTo1.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()));

    //        try
    //        {
    //            string MissedCall = Request.QueryString["A"].ToString();
    //            if (MissedCall == "M")
    //            {
    //                s.InsertAttendCall(Request.QueryString["Id"].ToString());
    //            }
    //        }
    //        catch
    //        {
    //        }
    //        lblMesag.Text = "Sucessfully Updated!!!";
    //        lblMesag.ForeColor = System.Drawing.Color.Blue;
    //        //alertmessage.Show("Data Updated Successfully!");
    //        //Response.Redirect("FollowUpReport.aspx", false);
    //        FillGridView();
    //    }
    //    catch
    //    {
    //        //alertmessage.Show("Please Try Again!");
    //        lblMesag.Text = "Try Again!";
    //        lblMesag.ForeColor = System.Drawing.Color.Red;
    //    }
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (int.Parse(ddlPrevStudentStatus.SelectedValue) == 4)
            {
                lblMesag.Text = "Enrolled Status Update not Allowed!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;

            }
            if (ddlNationality.SelectedIndex == 0)
            {

                lblMesag.Text = "Please Update Nationality!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlProspectSstatus.SelectedIndex == 0)
            {

                lblMesag.Text = "Please Update Prospect Status!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
            lblMesag.Text = "";
            string MediaSource = "";
            for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
            {
                if (lbMediaSource.Items[i].Selected == true)
                {
                    MediaSource = MediaSource + lbMediaSource.Items[i].Text + ",";
                    try
                    {
                        if ((lbMediaSource.Items[i].Text == "SELECT") || (lbMediaSource.Items[i].Text.Contains("Select")))
                        {
                            lblMesag.Text = "Please Select Media Source!!!";
                            lblMesag.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string LinkId = s.GetLinkIdById(int.Parse(txtLinkId.Text));
            string RegisterNo = s.UpdateStudentDetailsMyCallnew(int.Parse(LinkId), "", DateTime.Parse(txtCallPrevDate.Text),
                0, int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, "",
                "", "", ddlNationality.SelectedValue, Session["EMPID"].ToString(), ddlForwardedTo.SelectedValue,
                ddlProspectSstatus.SelectedValue, "", txtPrevRemarks.Text, "1", ddlPrevStudentStatus.SelectedValue, ddlReferredBy.SelectedItem.Text, txtMobileNo.Text,
                txtEmailID.Text, ddlCourseType.SelectedValue, ddlDegreeType.SelectedValue, MediaSource, Session["EmpId"].ToString(), txtCompanyName.Text, txtDesignation.Text, txtTelephone.Text, txtFax.Text,
                txtPoBox.Text, ddlArabNonArab.SelectedItem.Text, ddlCurrentlyEmployee.SelectedItem.Text, txtSchool.Text, ddlIndustry.SelectedValue, txtWebsite.Text, txtAddress.Text, txtCity.Text, ddlCallerCategory.SelectedValue, "", "", DateTime.Now, "", ddlReligion.SelectedValue, "No",
              ddlExhibition.SelectedValue, chkTOC.Checked, int.Parse(ddlAcademicYear.SelectedValue), txtGrade.Text);
            
            if (RegisterNo == "RegisterNo")
            {
                lblMesag.Text = "Data Update Successfully!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                //alertmessage.Show("Data Update Successfully!");
                //btnUpdate.Enabled = false;
                FillGridView();
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }           
            //alertmessage.Show("Data Update Successfully!");         
            //ModalPopupExtender1.Hide();
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
            //alertmessage.Show("Data Saved Updated!");
        }
    }
    //modified by meena
  
    protected void chkEmail_changed(object sender, EventArgs e)
    {
        try
        {
            if (chkEmail.Checked == true)
            {
                chkEmail1.Checked = false;
            }

        }
        catch
        {

        }
    }

    protected void chkEmail1_changed(object sender, EventArgs e)
    {
        try
        {
            if (chkEmail1.Checked == true)
            {
                chkEmail.Checked = false;
            }

        }
        catch
        {

        }
    }


    protected void chksms1_changed(object sender, EventArgs e)
    {
        try
        {   if (chkSms1.Checked == true)
            {
               chkSms.Checked = false;
       }

                   }
        catch
        {

        }
    }
    protected void chksms_changed(object sender, EventArgs e)
    {
        try
        {
            if (chkSms.Checked == true)
            {
                chkSms1.Checked = false;
            }

        }
        catch
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Result1 = "";
        int submenuid = 0;
        try
        {


            try
            {
                if (int.Parse(ddlStudentStatus.SelectedValue) == 6)
                {
                    if (int.Parse(DrpNQ.SelectedValue) == 0)
                    {
                        lblMesag.Text = "Please Select  Not Interested Reason!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        return;

                    }
                    else
                    submenuid = int.Parse(DrpNQ.SelectedValue);
                }
                else
                {
                    submenuid = 0;
                }

            }

            catch
            {
                submenuid = 0;
            }
            //pnlForStudent.Visible = true;
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if(ddlNationality.SelectedIndex == 0)
            {
                
                lblMesag.Text = "Please Update Nationality!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlProspectSstatus.SelectedIndex == 0)
            {
                //pnlForStudent.Visible = true;
                lblMesag.Text = "Please Update Prospect Status!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (txtRemarks.Text != "")
            {
                try
                {
                    if (Request.QueryString["A"] != null)
                    {
                        string MissedCall = Request.QueryString["A"].ToString();
                        if (MissedCall == "M")
                        {
                            s.InsertAttendCall(Request.QueryString["Id"].ToString());
                            string Result = s.InsertAttendFollowUp(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), "2", ddlForwardedTo1.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()));
                        }

                        try
                        {
                            if (MissedCall == "F")
                            {
                                string Result = s.UpdateFollowUpschedule(Request.QueryString["Id"].ToString());
                                Result1 = s.InsertFollowUp(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), ddlStudentStatus.SelectedValue, ddlForwardedTo1.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()),submenuid);
                    
                            }
                        }
                        catch
                        {
                        }


                        try
                        {
                            if (MissedCall == "V")
                            {
                                string Result = s.UpdateVisitschedule(Request.QueryString["Id"].ToString());
                                Result1 = s.InsertFollowUp(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), ddlStudentStatus.SelectedValue, ddlForwardedTo1.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()), submenuid);

                            }
                        }
                        catch
                        {
                        }


                    }

                    else
                    {
                         Result1 = s.InsertFollowUp(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), ddlStudentStatus.SelectedValue, ddlForwardedTo1.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()),submenuid);
                    }
                    try
                    {
                        s.InsertOtherFollowup(int.Parse(Request.QueryString["Id"].ToString()), chkPaymentMode.Checked, chkProvCerticate.Checked, int.Parse(Session["EmpId"].ToString()));
                       // s.InsertFollowupschedule(int.Parse(Request.QueryString["Id"].ToString()), txtFromDate.Text, int.Parse(Session["EmpId"].ToString()));
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (int.Parse(ddlStudentStatus.SelectedValue)==3)
                       // s.InsertOtherFollowup(int.Parse(Request.QueryString["Id"].ToString()), chkPaymentMode.Checked, chkProvCerticate.Checked, int.Parse(Session["EmpId"].ToString()));
                        s.InsertFollowupschedule(int.Parse(Result1), txtFromDate.Text, int.Parse(Session["EmpId"].ToString()));
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (int.Parse(ddlStudentStatus.SelectedValue) == 1)
                        s.InsertVisitschedule(int.Parse(Result1), txtVisitDate.Text, int.Parse(Session["EmpId"].ToString()));
                    }
                    catch
                    {
                    }


                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Yes")
                    {

                         if (ddlStudentStatus.SelectedValue == "6")
                         {
                             if (chkEmail.Checked == true)
                             {
                                 string ToEmail = txtEmailID.Text;
                                 string Name = txtFirstName.Text + ",";
                                 string Mesag = "";
                                 Mesag = "<table>";
                                 Mesag = Mesag + "<tr><td>" + "Dear " + ddlTitle.SelectedItem.Text + " " + Name;
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr> <tr><td> Greetings from Skyline University College (SUC)!";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for your interest in SUC programs. You may contact us in future for any guidance or queries related to higher education.";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>Visit our website www.skylineuniversity.ac.ae for more info";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + txtAttendedBy.Text;
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
                                 Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";

                                SendEmails.SendEmail2("admissions@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
                                SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
                             }
                             if (chkSms.Checked == true)
                             {
                                 SMSCAPI obj = new SMSCAPI();
                                 string strPostResponse;
                                //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for your time to attend " + txtAttendedBy.Text + "'s call. . For any future guidance please call us or visit www.skylineuniversity.ac.ae for more info.");
                                 //strPostResponse = obj.SendSMS("", "", "+971556460999", "Thank you for your time to attend " + txtAttendedBy.Text + "'s call. . For any future guidance please call us or visit www.skylineuniversity.ac.ae for more info.");
                             }
                         }
                         if (ddlStudentStatus.SelectedValue == "3")
                         {
                             if (chkEmail.Checked == true)
                             {
                                 string ToEmail = txtEmailID.Text;
                                 string Name = txtFirstName.Text + ",";
                                 string Mesag = "";
                                 Mesag = "<table>";
                                 Mesag = Mesag + "<tr><td>" + "Dear " + ddlTitle.SelectedItem.Text + " " + Name;
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr> <tr><td> Greetings from Skyline University College (SUC)!";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for sparing your time for the follow up call made by  " + txtAttendedBy.Text + "your admission counselor from SUC. We hope that all your queries have been answered. We look forward to receiving you at the university for further guidance on your pursuit of higher education.";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>Visit our website www.skylineuniversity.ac.ae for more info";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + txtAttendedBy.Text;
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
                                 Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";

                                 SendEmails.SendEmail2("admissions@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
                                 SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
                             }


                             if (chkEmail1.Checked == true)
                             {
                                 string ToEmail = txtEmailID.Text;
                                 string Name = txtFirstName.Text + ",";
                                 string Mesag = "";
                                 Mesag = "<table>";
                                 Mesag = Mesag + "<tr><td>" + "Dear " + ddlTitle.SelectedItem.Text + " " + Name;
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr> <tr><td> Greetings from Skyline University College (SUC)!";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "we were unable to reach you and follow up on your admission query. Kindly feel free to contact us for any clarification. Call +97165441155 Thank you";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>Visit our website www.skylineuniversity.ac.ae for more info";
                                 Mesag = Mesag + "</td></tr><tr><td>";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
                                 Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + txtAttendedBy.Text;
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
                                 //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
                                 Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";
                                SendEmails.SendEmail2("admissions@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
                             }



                             if (chkSms.Checked == true)
                             {
                                 SMSCAPI obj = new SMSCAPI();
                                 string strPostResponse;
                                 //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for attending " + txtAttendedBy.Text + "'s call. We are glad to guide you further.  Visit  www.skylineuniversity.ac.ae for more information.");
                                 //strPostResponse = obj.SendSMS("", "", "+971556460999", "Thank you for attending " + txtAttendedBy.Text + "'s call. We are glad to guide you further.  Visit  www.skylineuniversity.ac.ae for more information.");        
                             }

                             if (chkSms1.Checked == true)
                             {
                                 string Name = txtFirstName.Text + ",";
                                 SMSCAPI obj = new SMSCAPI();
                                 string strPostResponse;
                                  /*strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, " We were unable to reach you and follow up on your admission query. Kindly feel free to contact us for any clarification. Call +97165441155 Thank you..Visit  www.skylineuniversity.ac.ae for more information.")*/;
                                 //strPostResponse = obj.SendSMS("", "", "+971503530812", "we were unable to reach you and follow up on your admission query. Kindly feel free to contact us for any clarification. Call +97165441155 Thank you.Visit  www.skylineuniversity.ac.ae for more information.");        
                             }


                         }
                     }


                }
                catch
                {

                }
                lblMesag.Text = "Sucessfully Updated!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                //alertmessage.Show("Data Updated Successfully!");
                //Response.Redirect("FollowUpReport.aspx", false);
                FillGridView();
            }
            else
            {
                lblMesag.Text = "Remarks Required";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }


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
            //pnlForStudent.Visible = false;
            pnlForVendor1.Visible = false;
            pnlForVendor2.Visible = true;
            pnlForVendor4.Visible = true;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(82);
            rfReligion.InitialValue = "0";
        }
        else
        {
            //pnlForStudent.Visible = true;
            pnlForVendor1.Visible = true;
            pnlForVendor2.Visible = false;
            pnlForVendor4.Visible = false;
            txtPrevRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(77);
            rfReligion.InitialValue = "9999";
        }
        ModalPopupExtender1.Show();
    }
    protected void ddlStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlnq.Visible = false;
        PopCalendar1.Enabled = true;
        txtFromDate.Enabled = true;


        if (ddlStudentStatus.SelectedValue == "2")
        {
            ddlForwardedTo.Enabled = true;
            rdotype.Enabled = true;
        }
        else
        {
            ddlForwardedTo.Enabled = false;
            rdotype.Enabled = false;
            rdotype.SelectedIndex = -1;
        }
        
     
        
        if (ddlStudentStatus.SelectedValue == "6")
        {
            chkEmail.Enabled = true;
            chkSms.Enabled = true;
            pnlnq.Visible = true;
        }
        
        if (ddlStudentStatus.SelectedValue == "3")
        {
            chkEmail.Enabled = true;
            pnlfollowup.Visible = true;
            
        }
        else
        {
            pnlfollowup.Visible = false;
        }

        if (ddlStudentStatus.SelectedValue == "1")
        {
            pnlvisit.Visible = true;
        }
        else
        {
            pnlvisit.Visible = false;
        }


        if (ddlStudentStatus.SelectedValue == "24")
        {
            
            chkEmail.Checked = false;
            chkSms.Checked = false;
            chkEmail1.Checked = false;
            chkSms1.Checked = false;
            chkEmail.Enabled = false;
            chkEmail1.Enabled = false;
            chkSms.Enabled = false;
            chkSms1.Enabled = false;
            PopCalendar1.Enabled = false;
            txtFromDate.Enabled = false;


        }



       
    }

    protected void rdotype_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (Session["GroupName"].ToString() == "UAE")
        {
            rdotype.Enabled = true;
            ddlForwardedTo.DataSource = s.SetDropdownListnnew(rdotype.SelectedValue.ToString());
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
    protected void ddlPrevStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();


        if (ddlPrevStudentStatus.SelectedValue == "9")
        {
            ddlExhibition.Enabled = true;
            ddlExhibition.SelectedIndex = 0;
            ddlExhibition.DataSource = s.SetDropdownListCDB(53);
            ddlExhibition.DataTextField = "Event";
            ddlExhibition.DataValueField = "Id";
            ddlExhibition.DataBind();
            lblEvents.Text = "Events";
        }
        else if (ddlPrevStudentStatus.SelectedValue == "12")
        {
            ddlExhibition.DataSource = s.SetDropdownListCDB(84);
            ddlExhibition.DataTextField = "SchoolName";
            ddlExhibition.DataValueField = "Id";
            ddlExhibition.DataBind();

            ddlExhibition.Enabled = true;
            ddlExhibition.SelectedIndex = 0;
            lblEvents.Text = "Schools";
        }
        else
        {
            ddlExhibition.Enabled = false;
        }

        ModalPopupExtender1.Show();

    }


    protected void btneditdetails_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            Response.Redirect(string.Format("EditNewcaller.aspx?Id={0}", Id), false);
        }

        catch
        {

        }

    }






}