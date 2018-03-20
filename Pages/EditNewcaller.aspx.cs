using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Pages_EditNewcaller : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                pnltxtcity.Visible = true;
                pnldrpcity.Visible = false;
                txtAttendedBy.Text = Session["Name"].ToString();
                txtCallDate.Text = (DateTime.Now).ToString();
                ddlStudentStatus.Focus();
                pnlStudentReg.Visible = false;
                LoadDropdown();
                lbMediaSource.SelectedIndex = 0;
                ddlExhibition.Enabled = false;

                Drpschool.SelectedValue = Session["schoolcode"].ToString();
                Drpschool_SelectedIndexChanged(sender, e);




                try{
               string id=Request.QueryString["Id"];
               txtLinkId.Text = id;
               SetData();
               try
               {
                   DrpCOR_SelectedIndexChanged(sender, e);

               }
               catch
               {

               }
                     try
               {

                   ddlNationality_SelectedIndexChanged(sender, e);
                   ddlStudentStatus_SelectedIndexChanged(sender, e);
                   ddlCallerCategory_SelectedIndexChanged(sender, e);
                   ddlDegreeType_SelectedIndexChanged(sender, e);
                   drpcityname_SelectedIndexChanged(sender, e);

                     }
                    catch{

                    }


                }
                catch{
                    Response.Redirect("Login.aspx", false);

                }
            }
            catch
            {
                Response.Redirect("Login.aspx", false);
            }
            try
            {
                txtLinkId.Text = Request.QueryString["Id"].ToString();
                txtLinkId_TextChanged(sender, e);
              
               
                btnUpdate.Visible = true;
               
                
            }
            catch
            {
               
               
                btnUpdate.Visible = false;
                
               
            }
        }

    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();

        ddlNationality.DataSource = s.SetDropdownListCDB(2);
        ddlNationality.DataTextField = "NationalityName";
        ddlNationality.DataValueField = "NationalityCode";
        ddlNationality.DataBind();

        Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
        Drpschool.DataTextField = "schoolname";
        Drpschool.DataValueField = "schoolcode";
        Drpschool.DataBind();

        DrpCOR.DataSource = s.SetDropdownListCDB(2);
        DrpCOR.DataTextField = "NationalityName";
        DrpCOR.DataValueField = "NationalityCode";
        DrpCOR.DataBind();


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
        ddlStudentStatus.DataSource = s.SetDropdownListCDB(77);
        ddlStudentStatus.DataTextField = "CallerStatus";
        ddlStudentStatus.DataValueField = "Id";
        ddlStudentStatus.DataBind();

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

        //ddlDegreeType.DataSource = s.SetDropdownListCDB(14);
        //ddlDegreeType.DataTextField = "Description";
        //ddlDegreeType.DataValueField = "Id";
        //ddlDegreeType.DataBind();

        //ddlCourseType.DataSource = s.SetDropdownListCDB(15);
        //ddlCourseType.DataTextField = "Description";
        //ddlCourseType.DataValueField = "Id";
        //ddlCourseType.DataBind();

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

        ddlExhibition.DataSource = s.SetDropdownListCDB(53);
        ddlExhibition.DataTextField = "Event";
        ddlExhibition.DataValueField = "Id";
        ddlExhibition.DataBind();

        ddlAcademicYear.DataSource = s.SetDropdownListCDB(83);
        ddlAcademicYear.DataTextField = "FNAME";
        ddlAcademicYear.DataValueField = "Id";
        ddlAcademicYear.DataBind();
    }

    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlDegreeType.DataSource = s.SetDropdownListCDB(14, Drpschool.SelectedValue);
        ddlDegreeType.DataTextField = "Description";
        ddlDegreeType.DataValueField = "Id";
        ddlDegreeType.DataBind();
        ddlDegreeType.SelectedIndex = 1;
        ddlDegreeType_SelectedIndexChanged(sender, e);

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMesag.Text = "";
        
    }
    public void ResetField()
    {
        lbMediaSource.SelectedIndex = 0;
        //ddlFormStatus.SelectedIndex = 0;
        ddlForwardedTo.SelectedIndex = 0;
        ddlReferredBy.SelectedIndex = 0;
        ddlProspectSstatus.SelectedIndex = 0;
        txtRemarks.Text = "";
        ddlTitle.SelectedIndex = 0;
        ddlCourseType.SelectedIndex = 0;
        ddlDegreeType.SelectedIndex = 0;
        txtEmailID.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtMobileNo.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtCompanyName.Text = "";
        txtDesignation.Text = "";
        txtFax.Text = "";
        txtPoBox.Text = "";
        txtRemarks.Text = "";
        txtSchool.Text = "";
        txtTelephone.Text = "";
        txtWebsite.Text = "";
        txtCallDate.Text = (DateTime.Today).ToShortDateString();
        txtLinkId.Text = "";
        ddlStudentStatus.SelectedIndex = 0;
        lbMediaSource.SelectedIndex = 0;
        txtcityname.Text = "";
    }
    public void ResetField1()
    {
        //ddlFormStatus.SelectedIndex = 0;
        ddlForwardedTo.SelectedIndex = 0;
        ddlReferredBy.SelectedIndex = 0;
        ddlProspectSstatus.SelectedIndex = 0;
        txtRemarks.Text = "";
        ddlCourseType.SelectedIndex = 0;
        ddlDegreeType.SelectedIndex = 0;
        txtCallDate.Text = (DateTime.Now).ToString();
        txtLinkId.Text = "";
        ddlStudentStatus.SelectedIndex = 0;
        lbMediaSource.SelectedIndex = 0;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {


            try
            {
                if (ddlCourseType.SelectedIndex ==-1)
                {
                    lblMesag.Text = "Please Select CourseType!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch
            {

            }



            int Id = 0;
            try
            {
                Id = int.Parse(Session["ID"].ToString());
            }
            catch
            {
                Id = int.Parse(Request.QueryString["Id"].ToString());
            }
            string MediaSource = "";
            for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
            {
                if (lbMediaSource.Items[i].Selected == true)
                {
                    MediaSource = MediaSource + lbMediaSource.Items[i].Text + ",";
                }
            }


            try
            {
                if ((txtcityname.Text == "") || (txtcityname.Text == " ") || (txtcityname.Text == "SELECT") || (txtcityname.Text == "Select"))
                {
                    lblMesag.Text = "Please Enter City/State Name!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;

                }

            }

            catch
            {


            }

            try
            {
                if (ddlStudentStatus.SelectedValue == "4")
                {

                    lblMesag.Text = "You cannot assign status Enrolled in non Registered student ";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;

                }
            }

            catch
            {

            }

            try
            {
                if (DrpCOR.SelectedValue == "0")
                {
                    lblMesag.Text = "Please Select Country of residence!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch
            {

            }

            int LinkId=0;


            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string RegisterNo = s.UpdateStudentDetailsnew(Id, "", DateTime.Parse(txtCallDate.Text),
                0, int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, "",
                "", "", ddlNationality.SelectedValue, Session["EMPID"].ToString(), ddlForwardedTo.SelectedValue,
                ddlProspectSstatus.SelectedValue, "", txtRemarks.Text, "1", ddlStudentStatus.SelectedValue, ddlReferredBy.SelectedItem.Text,
                txtMobileNo.Text, txtEmailID.Text, ddlCourseType.SelectedValue, ddlDegreeType.SelectedValue, MediaSource, Session["EmpId"].ToString(), txtCompanyName.Text, txtDesignation.Text, txtTelephone.Text, txtFax.Text, txtPoBox.Text,
                ddlArabNonArab.SelectedItem.Text, ddlCurrentlyEmployee.SelectedItem.Text, txtSchool.Text, 
                ddlIndustry.SelectedValue, txtWebsite.Text, txtAddress.Text, txtCity.Text, 
                ddlCallerCategory.SelectedValue, "", "", DateTime.Now, "", ddlReligion.SelectedValue,
                "No", rdotype.SelectedValue.ToString(), bool.Parse("False".ToString()), txtcityname.Text, DrpCOR.SelectedValue
                , ddlExhibition.SelectedValue, chkTOC.Checked, int.Parse(ddlAcademicYear.SelectedValue), txtGrade.Text, Drpschool.SelectedValue);
                
            //NewLoad();

            try
            {
                LinkId = int.Parse(RegisterNo);
            }
            catch
            {
                LinkId = 0;

            } 

              // s.InertStudentCityDetails(LinkId, txtcityname.Text, DrpCOR.SelectedValue);
           
          //  s.InsertOtherDetails(LinkId, ddlExhibition.SelectedValue, chkTOC.Checked, int.Parse(Session["EmpId"].ToString()), int.Parse(ddlAcademicYear.SelectedValue), txtGrade.Text);
           


            string Name = Session["Name"].ToString();
            string EMPID = Session["EMPID"].ToString();
            Session.Clear();
            Session["Name"] = Name;
            Session["EMPID"] = EMPID;
            if (RegisterNo == "error".ToString())
            {
                lblMesag.Text = "Try again or Contact IT Department!!!";
                return;
            }
            else
            {
                lblMesag.Text = "Sucessfully Updated!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                //ResetField();
              
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
        }
    }
   
    
    public void SetData()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetStudentDetails(int.Parse(txtLinkId.Text));
            foreach (DataRow ro in dt.Rows)
            {
                txtCallDate.Text = ro["CallDate"].ToString();
                txtFirstName.Text = ro["FirstName"].ToString();
                txtLastName.Text = ro["LastName"].ToString();
                txtMiddleName.Text = ro["MiddleName"].ToString();
                ddlTitle.SelectedValue = ro["Title"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                txtAttendedBy.Text = ro["empname"].ToString();
                txtEmailID.Text = ro["EmailID"].ToString();
                txtMobileNo.Text = ro["MobileNo"].ToString();
                ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
                ddlCourseType.SelectedValue = ro["CourseType"].ToString();
                ddlStudentStatus.SelectedValue = ro["StudentStatus"].ToString();
                ddlCallerCategory.SelectedValue = ro["callercategoryid"].ToString();
                //ddlFormStatus.SelectedValue = ro["FormStatus"].ToString();
                txtRemarks.Text = ro["Remarks"].ToString();
                ddlReferredBy.SelectedItem.Text = ro["RefferedBy"].ToString();
                ddlForwardedTo.SelectedValue = ro["ForwardedTo"].ToString();
                txtcityname.Text = ro["cityname"].ToString();
                try
                {
                    lbMediaSource.SelectedItem.Text = ro["MediaSource"].ToString();
                }
                catch
                {
                }

                try
                {
                    Drpschool.SelectedValue = ro["schoolcode"].ToString();
                }
                catch
                {
                    lblMesag.Text = "School code is not Mapped contact IT";

                    return;
                }



                try
                {
                   
                    DrpCOR.SelectedValue = ro["Countryofresidence"].ToString();
                    

                }
                catch
                {

                }
                try
                {
                           drpcityname.SelectedValue =ro["cityname"].ToString();
                }
                catch
                {

                }


                 DataTable dt1 = s.SetStudentDetailsother(int.Parse(txtLinkId.Text));
                 foreach (DataRow ro1 in dt1.Rows)
                 {
                   try
                   {
                     chkTOC.Checked=bool.Parse(ro1["TOC"].ToString());
                     }
                       catch{

                       }
                   try
                   {
                       ddlAcademicYear.SelectedValue =ro1["AcademicYear"].ToString();
                   }
                   catch
                   {

                   }


                   try
                   {
                       ddlExhibition.SelectedValue = ro1["Event"].ToString();
                   }
                   catch
                   {

                   }

                   try
                   {
                       txtGrade.Text = ro1["grade"].ToString();
                   }
                   catch
                   {

                   }
                 }


            }


        }
        catch (Exception ex)
        {
        }
    }
   
    protected void ddlFormStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlFormStatus.SelectedValue == "R")
        //{
        //    ddlProspectSstatus.SelectedValue = "100";
        //}
        //else
        //{
        //    ddlProspectSstatus.SelectedValue = "10";
        //}
    }
    protected void txtLinkId_TextChanged(object sender, EventArgs e)
    {
        SetData();
    }
    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //StudentRegistrationDAL s = new StudentRegistrationDAL();
        //ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1111, int.Parse(ddlDegreeType.SelectedValue));
        //ddlCourseType.DataTextField = "Description";
        //ddlCourseType.DataValueField = "Id";
        //ddlCourseType.DataBind();
        ddlCourseType.Items.Clear();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1111, int.Parse(ddlDegreeType.SelectedValue), Drpschool.SelectedValue);
        ddlCourseType.DataTextField = "Description";
        ddlCourseType.DataValueField = "Id";
        ddlCourseType.DataBind();
    }
    protected void ddlCallerCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (ddlCallerCategory.SelectedItem.Text != "Student")
        {
            pnlForStudent.Visible = false;
            pnlForVendor1.Visible = false;
            pnlForVendor2.Visible = true;
            pnlForVendor4.Visible = true;
            txtRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(76);
            rfCourseType.ControlToValidate = "txtCompanyName";
            rfCourseType.ErrorMessage = "Company Name Required!";
            rfDegreeType.ControlToValidate = "txtDesignation";
            rfDegreeType.ErrorMessage = "Designation Required!";
            rfReligion.InitialValue = "0";
            rfCourseType.InitialValue = "";
            rfDegreeType.InitialValue = "";

            ddlStudentStatus.DataSource = s.SetDropdownListCDB(40);
            ddlStudentStatus.DataTextField = "CallerStatus";
            ddlStudentStatus.DataValueField = "Id";
            ddlStudentStatus.DataBind();
        }
        else
        {
            pnlForStudent.Visible = true;
            pnlForVendor1.Visible = true;
            pnlForVendor2.Visible = false;
            pnlForVendor4.Visible = false;
            txtRemarks.Height = System.Web.UI.WebControls.Unit.Pixel(34);
            lbMediaSource.Height = System.Web.UI.WebControls.Unit.Pixel(64);
            rfCourseType.ControlToValidate = "ddlCourseType";
            rfCourseType.ErrorMessage = "Please Select Course Type!";
            rfDegreeType.ControlToValidate = "ddlDegreeType";
            rfDegreeType.ErrorMessage = "Please Select Degree Type!";
            rfReligion.InitialValue = "9999";
            rfCourseType.InitialValue = "0";
            rfDegreeType.InitialValue = "0";

            ddlStudentStatus.DataSource = s.SetDropdownListCDB(77);
            ddlStudentStatus.DataTextField = "CallerStatus";
            ddlStudentStatus.DataValueField = "Id";
            ddlStudentStatus.DataBind();
        }
    }
    protected void ddlStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();

        
        if (ddlStudentStatus.SelectedValue == "9")
        {
            ddlExhibition.Enabled = true;
            ddlExhibition.SelectedIndex = 0;
            ddlExhibition.DataSource = s.SetDropdownListCDB(53);
            ddlExhibition.DataTextField = "Event";
            ddlExhibition.DataValueField = "Id";
            ddlExhibition.DataBind();
            lblEvents.Text = "Events";
        }
        else if (ddlStudentStatus.SelectedValue == "12")
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
    }


    protected void drpcityname_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtcityname.Text = drpcityname.SelectedValue;
    }


    protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Arab = s.GetArabNonArab(ddlNationality.SelectedValue);
        if (Arab.ToUpper() == "Arab".ToUpper())
        {
            ddlArabNonArab.SelectedValue = "1";
        }
        else
        {
            ddlArabNonArab.SelectedValue = "2";
        }




    }


    protected void DrpCOR_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();

        try
        {
            if ((DrpCOR.SelectedValue == "UAE") || (DrpCOR.SelectedValue == "NG") || (DrpCOR.SelectedValue == "PK") || (DrpCOR.SelectedValue == "MA"))
            {
                pnltxtcity.Visible = false;
                pnldrpcity.Visible = true;

                drpcityname.DataSource = s.SetDropdownwithparam(3, DrpCOR.SelectedValue);
                drpcityname.DataTextField = "statename";
                drpcityname.DataValueField = "statename";
                drpcityname.DataBind();
            }
            else
            {
                pnltxtcity.Visible = true;
                pnldrpcity.Visible = false;

            }
        }
        catch
        {

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

  
}
