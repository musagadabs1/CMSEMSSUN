using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using com.vectramind.mobile;

public partial class Pages_NewCaller : System.Web.UI.Page
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

            }
            catch
            {
                //Console.WriteLine(ex.Message);
                Response.Redirect("Login.aspx", false);
            }
            try
            {
                txtLinkId.Text = Request.QueryString["Id"].ToString();
                txtLinkId_TextChanged(sender, e);
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAddNew.Visible = true;
                pnlCallingDetails.Visible = true;
            }
            catch
            {
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                pnlCallingDetails.Visible = false;
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

        Drpschool.DataSource = s.SetDropdownListAsDegreeType(50,1,Session["schoolcode"].ToString());
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsMobileNoUsed())
            {
                if (ddlForwardedTo.SelectedItem.Text == txtAttendedBy.Text)
                {
                    lblMesag.Text = "You can't forward call to yourself!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                int LinkId = 0;
                try
                {
                    LinkId = int.Parse(Request.QueryString["Id"].ToString());
                }
                catch
                {
                }
                lblMesag.Text = "";
                string MediaSource = "";

                if (ddlCourseType.SelectedIndex == -1)
                {
                    lblMesag.Text = "Please Select CourseType!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }

               
                //for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
                //{
                //    if (lbMediaSource.Items[i].Selected == true)
                //    {
                //        MediaSource = MediaSource + lbMediaSource.Items[i].Text + ",";
                //        try
                //        {
                //            if ((lbMediaSource.Items[i].Text == "SELECT") || (lbMediaSource.Items[i].Text.Contains("Select"))) 
                //            {
                //                lblMesag.Text = "Please Select Media Source!!!";
                //                lblMesag.ForeColor = System.Drawing.Color.Red;
                //                return;
                //            }
                //        }
                //        catch
                //        {
                //        }


                //    }
                //}


                if (ddlCallerCategory.SelectedValue == "1")
                {
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
                }

                try
                {
                    if ((txtcityname.Text == "") ||(txtcityname.Text == " ") || (txtcityname.Text == "SELECT")||(txtcityname.Text == "Select"))
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

                StudentRegistrationDAL s = new StudentRegistrationDAL();
                string RegisterNo = s.InsertStudentDetailsCMSNEW(LinkId, "", DateTime.Parse(txtCallDate.Text),
                    0, int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, "",
                    "", "", ddlNationality.SelectedValue, Session["EMPID"].ToString(), ddlForwardedTo.SelectedValue,
                    ddlProspectSstatus.SelectedValue, "", txtRemarks.Text, "23", ddlStudentStatus.SelectedValue, ddlReferredBy.SelectedItem.Text, txtMobileNo.Text,
                    txtEmailID.Text, ddlCourseType.SelectedValue, ddlDegreeType.SelectedValue, MediaSource, Session["EmpId"].ToString(), txtCompanyName.Text, txtDesignation.Text, txtTelephone.Text, txtFax.Text,
                    txtPoBox.Text, ddlArabNonArab.SelectedItem.Text, ddlCurrentlyEmployee.SelectedItem.Text, txtSchool.Text, ddlIndustry.SelectedValue,
                    txtWebsite.Text, txtAddress.Text, txtCity.Text, ddlCallerCategory.SelectedValue, "", "", DateTime.Now, "", ddlReligion.SelectedValue, "No",
                    rdotype.SelectedValue.ToString(), bool.Parse("False".ToString()), txtcityname.Text,
                    DrpCOR.SelectedValue, ddlExhibition.SelectedValue, chkTOC.Checked, int.Parse(ddlAcademicYear.SelectedValue),
                    txtGrade.Text,Drpschool.SelectedValue);
                
              
                    try
                    {
                        LinkId = int.Parse(RegisterNo);
                    }
                    catch
                    {
                        LinkId = 0;

                    } 
                  
                if (RegisterNo == "error".ToString())
                {
                    lblMesag.Text = "Try again or Contact IT Department!!!";
                    return;
                }
                else
                {


                   // SendEmail();
                    if ((rdotype.SelectedIndex == 1) || (rdotype.SelectedIndex == 2))
                    {
                        //SendMailStaffFac();
                    }
                    lblMesag.Text = "Sucessfully Submitted!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Blue;
                    //alertmessage.Show("Data Saved Successfully!");
                    //btnSave.Enabled = false;
                    ResetField();
                }
            }
            else
            {
                lblMesag.Text = "This Mobile No is already Registered!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
            alertmessage.Show("Please Try Again!");
        }
    }
    public bool IsMobileNoUsed()
    {
        bool Result = false;
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.IsMObileUsed(txtMobileNo.Text);
        foreach (DataRow ro in dt.Rows)
        {
            if (int.Parse(ro[0].ToString()) == 0)
                Result = false;
            else
                Result = true;
        }
        return Result;
    }
    public void SendEmail()
    {
        //For Email
        string ToEmail = txtEmailID.Text;
        string Name = txtFirstName.Text + ",";
        string Mesag = "";
        SMSCAPI obj = new SMSCAPI();
        string strPostResponse;
        if (ddlStudentStatus.SelectedValue == "2")
        {
            Mesag = "<table>";
            Mesag = Mesag + "<tr><td>" + "Dear " + ddlTitle.SelectedItem.Text + " " + Name;
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>Greetings from Skyline University College (SUC)! ";
            Mesag = Mesag + "</td></tr><tr><td>";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for calling Skyline University College, we hope that you were able to get all necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor, if you need further information kindly feel free to get in touch with " + txtAttendedBy.Text + ". Looking forward to seeing you at the University";
            Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for calling us. We hope that you were able to get all necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with" + txtAttendedBy.Text+" Looking forward to seeing you at the University.";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>Visit our website www.skylineuniversity.ac.ae for more info";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
            //Mesag = Mesag + "</td></tr><tr><td>" + txtAttendedBy.Text;
            Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
            Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
            //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
            //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@kylineuniversity.ac.ae"; 
            Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";
            SendEmails.SendEmail2("admissions@skylineuniversity.ac.ae", ToEmail, "Skyline", Mesag, "");
           SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Skyline", Mesag, "");
          //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for enquiring about our Programs at SUC. For more information, please visit us between 9:30am and  9:30pm or visit  www.skylineuniversity.ac.ae");
            //strPostResponse = obj.SendSMS("", "", "+971556460999" , "Thank you for enquiring about our Programs at SUC. For more information, please visit us between 9:30am and  9:30pm or visit  www.skylineuniversity.ac.ae");        

        }
        if (ddlStudentStatus.SelectedValue == "1")
        {
            string eventname = "";
            Mesag = "<table>";
            Mesag = Mesag + "<tr><td>" + "Dear " + ddlTitle.SelectedItem.Text + " " + Name;
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr> <tr><td>Greetings from Skyline University College (SUC)!";
            Mesag = Mesag + "</td></tr><tr><td>";
            eventname = ddlExhibition.SelectedItem.Text;
            try
            {
                if ((eventname == "SELECT") || (eventname == "Select"))
                {
                    Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at our campus. We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with" + txtAttendedBy.Text;
                }
                else
                {
                    Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at " + eventname + " . We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with" + txtAttendedBy.Text;
                }
            }
            catch
            {
                Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at our campus. We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with" + txtAttendedBy.Text;
            }
            //Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at our campus. We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with" + txtAttendedBy.Text;
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>Visit our website www.skylineuniversity.ac.ae for more info";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
            Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
            Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
            //Mesag = Mesag + "</td></tr><tr><td>" + txtAttendedBy.Text;
            //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
            //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
            //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
            Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";
            SendEmails.SendEmail2("admissions@skylineuniversity.ac.ae", ToEmail, "Skyline", Mesag, "");
            //SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Skyline", Mesag, "");
            try
            {
                if ((eventname == "SELECT") || (eventname == "Select"))
                {
                    //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for visiting us at "+ eventname +". For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");
                }
                else
                {
                    //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for enquiring about our Programs at `SUC. For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");
                }
            }
            catch
            {
                //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for enquiring about our Programs at `SUC. For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");
            }
           
            //strPostResponse = obj.SendSMS("", "", "+971556460999", "Thank you for enquiring about our Programs at SUC. For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");        
        }


        if (ddlStudentStatus.SelectedValue == "9")
        {
            string eventname = "";
            Mesag = "<table>";
            Mesag = Mesag + "<tr><td>" + "Dear " + ddlTitle.SelectedItem.Text + " " + Name;
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr> <tr><td>Greetings from Skyline University College (SUC)!";
            Mesag = Mesag + "</td></tr><tr><td>";
            eventname = ddlExhibition.SelectedItem.Text;
            try
            {
               
               
                    Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at " + eventname + " . We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with " + txtAttendedBy.Text;
                
            }
            catch
            {
                Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at our campus. We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with " + txtAttendedBy.Text;
            }
            //Mesag = Mesag + "</td></tr><tr><td>" + "Thank you for visiting us at our campus. We hope that you were able to get all the necessary information on your requirements from " + txtAttendedBy.Text + ", your admission counselor. If you need further information kindly feel free to get in touch with" + txtAttendedBy.Text;
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>Visit our website www.skylineuniversity.ac.ae for more info";
            Mesag = Mesag + "</td></tr><tr><td>";
            Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
            Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
            Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
            //Mesag = Mesag + "</td></tr><tr><td>" + txtAttendedBy.Text;
            //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
            //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
            //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
            Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";
            SendEmails.SendEmail2("admissions@skylineuniversity.ac.ae", ToEmail, "Skyline", Mesag, "");
            //SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Skyline", Mesag, "");
            try
            {

                //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for visiting us at " + eventname + ". For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");

            }
            catch
            {
                //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for enquiring about our Programs at `SUC. For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");
            }

            //strPostResponse = obj.SendSMS("", "", "+971556460999", "Thank you for enquiring about our Programs at SUC. For clarifications please contact the advising officer on +97165441155 or visit  www.skylineuniversity.ac.ae.");        
        }

        
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMesag.Text = "";
        NewLoad();
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
                if (txtcityname.Text == "")
                {
                    lblMesag.Text = "Please Enter City/State Name!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;

                }

            }

            catch
            {


            }





            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string RegisterNo = s.UpdateStudentDetails(Id,"",DateTime.Parse(txtCallDate.Text),
                0,int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, "",
                "", "", ddlNationality.SelectedValue, Session["EMPID"].ToString(), ddlForwardedTo.SelectedValue,
                ddlProspectSstatus.SelectedValue, "", txtRemarks.Text, "1", ddlStudentStatus.SelectedValue, ddlReferredBy.SelectedItem.Text,
                txtMobileNo.Text, txtEmailID.Text, ddlCourseType.SelectedValue, ddlDegreeType.SelectedValue, MediaSource, Session["EmpId"].ToString(), txtCompanyName.Text, txtDesignation.Text, txtTelephone.Text, txtFax.Text, txtPoBox.Text,
                ddlArabNonArab.SelectedItem.Text, ddlCurrentlyEmployee.SelectedItem.Text, txtSchool.Text, ddlIndustry.SelectedValue, txtWebsite.Text, txtAddress.Text, txtCity.Text, ddlCallerCategory.SelectedValue, "", "", DateTime.Now, "", ddlReligion.SelectedValue,"No",rdotype.SelectedValue.ToString(),bool.Parse("False".ToString()));
            //NewLoad();

            try
            {
                s.InertStudentCityDetails(Id, txtcityname.Text,DrpCOR.SelectedValue);
            }
            catch
            {

            }
            
            
            
            
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
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                //pnlStudentReg.Visible = true;
                //pnlCallingDetails.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnAddNew.Visible = true;
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            this.FillGridViewAll();
            ResetField1();
            lblMesag.Text = "";
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }
        catch
        {
        }
    }
    public void NewLoad()
    {
        btnSave.Visible = true;
        btnCancel.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        ResetField();
        Response.Redirect("NewCaller.aspx", false);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            try
            {
                Id = int.Parse(Session["ID"].ToString());
            }
            catch
            {
                Id = int.Parse(Request.QueryString["Id"].ToString());
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string RegisterNo = s.DeleteStudentDetails(Id);
            string Name = Session["Name"].ToString();
            string EMPID = Session["EMPID"].ToString();
            Session.Clear();
            NewLoad();
            Session["Name"] = Name;
            Session["EMPID"] = EMPID;
            lblMesag.Text = "Sucessfully Removed!!!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
            //ResetField();
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
                txtAttendedBy.Text = ro["AttendedBy"].ToString();
                txtEmailID.Text = ro["EmailID"].ToString();
                txtMobileNo.Text = ro["MobileNo"].ToString();
                ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
                ddlCourseType.SelectedValue = ro["CourseType"].ToString();
                ddlStudentStatus.SelectedValue = ro["StudentStatus"].ToString();
                //ddlFormStatus.SelectedValue = ro["FormStatus"].ToString();
                txtRemarks.Text = ro["Remarks"].ToString();
                ddlReferredBy.SelectedItem.Text = ro["RefferedBy"].ToString();
                ddlForwardedTo.SelectedValue = ro["ForwardedTo"].ToString();
                try
                {
                    lbMediaSource.SelectedItem.Text = ro["MediaSource"].ToString();
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void SetData1()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetStudentDetails1(int.Parse(txtLinkId.Text));
            foreach (DataRow ro in dt.Rows)
            {
                txtCallDate.Text = ro["CallDate"].ToString();
                txtFirstName.Text = ro["FirstName"].ToString();
                txtLastName.Text = ro["LastName"].ToString();
                txtMiddleName.Text = ro["MiddleName"].ToString();
                ddlTitle.SelectedValue = ro["Title"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                txtAttendedBy.Text = ro["AttendedBy"].ToString();
                txtEmailID.Text = ro["EmailID"].ToString();
                txtMobileNo.Text = ro["MobileNo"].ToString();
                ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
                ddlCourseType.SelectedValue = ro["CourseType"].ToString();
                ddlStudentStatus.SelectedValue = ro["StudentStatus"].ToString();
                //ddlFormStatus.SelectedValue = ro["FormStatus"].ToString();
                txtRemarks.Text = ro["Remarks"].ToString();
                ddlReferredBy.SelectedItem.Text = ro["RefferedBy"].ToString();
                ddlForwardedTo.SelectedValue = ro["ForwardedTo"].ToString();
                try
                {
                    lbMediaSource.SelectedItem.Text = ro["MediaSource"].ToString();
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void FillGridViewAll()
    {
        lblMesag.Text = "";
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.BindGridAll(int.Parse(txtLinkId.Text));
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Fill Correct Information!";
        }
    }
    private void FillGridView()
    {
        lblMesag.Text = "";
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvStudentList.DataSource = s.BindGrid(int.Parse(txtLinkId.Text));
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
            LinkButton lnkSN = (LinkButton)e.Row.FindControl("lnkSN");
            lnkSN.Text = (e.Row.RowIndex + 1).ToString();
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            lblDate.Text = (DateTime.Parse(lblDate.Text)).ToShortDateString();
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                Session["ID"] = Id.ToString();
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                txtLinkId.Text = Id.ToString();
                SetData1();
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnAddNew.Visible = false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
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

    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlDegreeType.DataSource = s.SetDropdownListCDB(14,Drpschool.SelectedValue);
        ddlDegreeType.DataTextField = "Description";
        ddlDegreeType.DataValueField = "Id";
        ddlDegreeType.DataBind();
        ddlDegreeType.SelectedIndex = 1;
        ddlDegreeType_SelectedIndexChanged(sender, e);
       
    }

    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
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
       txtcityname.Text=drpcityname.SelectedValue;
    }


    protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
    {
        //StudentRegistrationDAL s = new StudentRegistrationDAL();
        //string Arab = s.GetArabNonArab(ddlNationality.SelectedValue);
        //if (Arab.ToUpper() == "Arab".ToUpper())
        //{
        //    ddlArabNonArab.SelectedValue = "1";
        //}
        //else
        //{
        //    ddlArabNonArab.SelectedValue = "2";
        //}
        
        


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

    protected void SendMailStaffFac()
    {

        string Mesag = "";
        Mesag = Mesag + "<table style='font-family:Verdana;font-size:16px;font-Weight:Bold;'><tr><td>Missed Call Notification Details</td></tr><tr><td><br/></td></tr></table>";

        Mesag = Mesag + "<br/><table style='font-family:Verdana;font-size:12px;'><tr><td>Dear Sir/Madam,</td></tr><tr><td><br/></td></tr></table>";

        Mesag = Mesag + "<br/><table style='font-family:Verdana;font-size:12px;'><tr><td>Kindly be informed that you have missed call notification in your AdminExam Module.</td></tr><tr><td><br/></td></tr></table>";

        Mesag = Mesag + "<br/><table>";
        Mesag = Mesag + "<table border='1' bgcolor='#f0eace' style='font-family:Verdana;font-size:12px;'>";
        Mesag = Mesag + "<tr><td colspan='2' align='center' style='font-size:14px'>Missed Call Notification Details</td></tr>";

        Mesag = Mesag + "<tr><td>Caller Category</td><td>" + ddlCallerCategory.SelectedItem.Text + "</td></tr>";       
        Mesag = Mesag + "<tr><td>First Name</td><td>" + ddlTitle.SelectedItem.Text + "." + txtFirstName.Text.ToUpper() + "</td></tr>";
        Mesag = Mesag + "<tr><td>Middle Name</td><td>" + txtMiddleName.Text.ToUpper() + "</td></tr>";
        Mesag = Mesag + "<tr><td>Last Name</td><td>" + txtLastName.Text.ToUpper() + "</td></tr>";
        Mesag = Mesag + "<tr><td>Date</td><td>" + txtCallDate.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Message for Whom</td><td>" + ddlForwardedTo.SelectedItem.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Remarks</td><td>" + txtRemarks.Text.ToUpper() + "</td></tr></table>";

        Mesag = Mesag + "<br/><br/><table style='font-family:Verdana;font-size:12px;'><tr><td>Thanks & Regards</td></tr>";
        Mesag = Mesag + "<tr><td style='font-family:Verdana;font-size:11px;'>" + Session["Name"].ToString().ToUpper() + "</td></tr></table>";

        String Str_FromMail = "";
        String Str_ToMail = "";
        DataSet ds;

        AttendanceDataAcessLayer AD = new AttendanceDataAcessLayer();
        ds = new DataSet();

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ToId", Convert.ToInt32(ddlForwardedTo.SelectedValue));
        param[1] = new SqlParameter("@FromId", Session["EmpId"].ToString());

        ds = AD.getDataByParam(param, "Sp_ViewMailId");

        if (ds.Tables[0].Rows.Count > 0)
        {
            Str_ToMail = ds.Tables[0].Rows[0]["ToMail"].ToString().ToLower();
            Str_FromMail = ds.Tables[0].Rows[0]["FromMail"].ToString().ToLower();
        }
        SendEmails.SendEmail2(Str_FromMail, Str_ToMail, "Missed Call Notification Details", Mesag, Str_FromMail);
        //SendEmails.SendEmail2("software@skylineuniversity.ac.ae", "software@skylineuniversity.ac.ae", "Missed Call Notification Details", Mesag, "");
    }
}
