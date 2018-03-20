using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pages_NewRegistrant : System.Web.UI.Page
{
    int userid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();    
            try
            {
                
                txtRegNo.Text = GeTRegNo();
                txtAttendedBy.Text = Session["Name"].ToString();
                txtCallDate.Text = (DateTime.Now).ToString();
                pnlStudentReg.Visible = false;
                LoadDropdown();
                txtRegNo.Focus();
          

            }
            catch
            {
                Response.Redirect("Login.aspx", false);
            }
            try
            {
                txtLinkId.Text = Request.QueryString["Id"].ToString();
                txtLinkId_TextChanged(sender, e);
                if(txtRegNo.Text == "")
                    txtRegNo.Text = GeTRegNo();
                btnSave.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnDetails.Visible = true;
               
                txtAttendedBy.Text = s.GetRegisteredBy(txtLinkId.Text);
                if (txtAttendedBy.Text == "")
                {
                    txtAttendedBy.Text = Session["Name"].ToString();
                }
            }
            catch
            {
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            try
            {
               // StudentRegistrationDAL s = new StudentRegistrationDAL();
                string RegNo = s.GetRegNo(Request.QueryString["Id"].ToString());
                int Status = s.GetFinalStudentStatus(RegNo);
                if (Session["DepId"].ToString() != "4")
                {
                    if (Status != 0)
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Dear User, Kindly be informed that you are not authorized to edit the details of student - ENROLLED ALREADY DONE BY ADMIN & EXAM. However you need any further clarification contact Admin & Exam Dept!!!!!!!!')</script>");
                        btnAddNew.Visible = false;
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = false;
                        btnUpdate.Visible = false;
                        btnFind.Visible = false;
                        btnDetails.Text = "Do you want to View the Details";
                    }
                }
                btnViewReport.Visible = true;
            }
            catch
            {
            }
        }
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            userid = int.Parse(Session["EMPID"].ToString());
            DataTable RegisterNo1 = s.InsertStudentMailVerifyLogs(int.Parse(Request.QueryString["Id"].ToString()), int.Parse(Session["EMPID"].ToString()), txtEmailID.Text, "INSCHECK");
            if (RegisterNo1.Rows[0][0].ToString().Contains("1") == true)
            {
                
                btnverifyemail.Enabled = false;
            }
            else
            {
                btnverifyemail.Enabled = true;
            }

        }
        catch
        {

        }
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            userid = int.Parse(Session["EMPID"].ToString());
            DataTable RegisterNo1 = s.InsertStudentMailVerifyLogs(int.Parse(Request.QueryString["Id"].ToString()), int.Parse(Session["EMPID"].ToString()), txtEmailID.Text, "UPCHECK");
            if (RegisterNo1.Rows[0][0].ToString().Contains("1") == true)
            {

                btnverifyreplyemail.Enabled = false;
            }
            else
            {
                btnverifyreplyemail.Enabled = true;
            }

        }
        catch
        {

        }

    }
    public string GeTRegNo()
    {
        DataTable dt = new DataTable();
        string RegNo = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.GetRegNo();
        foreach (DataRow ro in dt.Rows)
        {
            //RegNo = "RS" +"-"+ DateTime.Now.Year.ToString()+"-"+ (int.Parse(ro[0].ToString().Substring(8))+1).ToString();
            RegNo = (int.Parse(ro[0].ToString()) + 1).ToString();
        }
        return RegNo;
    }
    public string GeTLastRegNo()
    {
        DataTable dt = new DataTable();
        string RegNo = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.GetRegNo();
        foreach (DataRow ro in dt.Rows)
        {
            //RegNo = "RS" + "-" + DateTime.Now.Year.ToString() + "-" + (int.Parse(ro[0].ToString().Substring(8))).ToString();
            RegNo = (int.Parse(ro[0].ToString())).ToString();
        }
        return RegNo;
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlTitle.DataSource = s.SetDropdownListCDB(12);
        ddlTitle.DataTextField = "Title";
        ddlTitle.DataValueField = "Id";
        ddlTitle.DataBind();

        ddlBloodGroup.DataSource = s.SetDropdownListCDB(17);
        ddlBloodGroup.DataTextField = "BloodGroup";
        ddlBloodGroup.DataValueField = "Id";
        ddlBloodGroup.DataBind();

        ddlProficiencyInEnglish.DataSource = s.SetDropdownListCDB(18);
        ddlProficiencyInEnglish.DataTextField = "ProficiencyInEnglish";
        ddlProficiencyInEnglish.DataValueField = "Id";
        ddlProficiencyInEnglish.DataBind();

        ddlGender.DataSource = s.SetDropdownListCDB(19);
        ddlGender.DataTextField = "Gender";
        ddlGender.DataValueField = "Id";
        ddlGender.DataBind();

        ddlNationality.DataSource = s.SetDropdownListCDB(2);
        ddlNationality.DataTextField = "NationalityName";
        ddlNationality.DataValueField = "NationalityCode";
        ddlNationality.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (s.IsRegNoUsed(txtRegNo.Text) == 0)
            {
                int LinkId = 0;
                try
                {
                    LinkId = int.Parse(Request.QueryString["Id"].ToString());
                }
                catch
                {
                }
                lblMesag.Text = "";
                if (!IsMobileNoUsed())
                {
                    if (txtRegNo.Text != GeTLastRegNo())
                    {


                        if (ddlNationality.SelectedValue == "0".ToString())

                        {
                            lblMesag.Text = "Nationality required";
                            lblMesag.ForeColor = System.Drawing.Color.Red;
                            return;
                        } 
                        DateTime Dob = DateTime.Now;
                        if (txtDobDate.Text != "")
                            Dob = DateTime.Parse(txtDobYear.Text + "/" + txtDobMonth.Text + "/" + txtDobDate.Text);
                        string RegisterNo = s.InsertStudentDetails(LinkId, txtRegNo.Text, DateTime.Parse(txtCallDate.Text),
                            int.Parse(ddlGender.SelectedValue), int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtArabicFirstName.Text,
                            txtArabicMiddleName.Text, txtArabicLastName.Text, ddlNationality.SelectedValue, Session["EMPID"].ToString(), "0",
                            "0", "", "New Registration", "1", "4", "", txtMobileNo.Text,
                            txtEmailID.Text, "0", "0", "0", Session["EmpId"].ToString(), "", "", txtPhoneNo.Text, "",
                            "", "", "", "", "", "", "", "", "1", txtMotherTongue.Text, ddlProficiencyInEnglish.SelectedValue, Dob, ddlBloodGroup.SelectedValue, "0", ddlInternationalStudent.SelectedItem.Text,"0",chkaptitude.Checked);
                       
                         

                        
                        lblMesag.Text = "Sucessfully Submitted!!!";
                        lblMesag.ForeColor = System.Drawing.Color.Blue;
                        if (RegisterNo == "")
                        {
                            lblMesag.Text = "Please Try Again!!!";
                            lblMesag.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        SMSCAPI obj = new SMSCAPI();
                        string strPostResponse;
                        //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for Enrolling with SUC. For further assistance feel free to contact us +97165441155");
                        //Response.Redirect("StudentRegistration.aspx", false);
                        //ResetField();
                        //this.FillGridViewAll();
                        btnSave.Enabled = false;
                        btnCancel.Visible = true;
                        btnDetails.Visible = true;
                        if (LinkId == 0)
                        {
                            DataTable dt = s.GetLinkId(0);
                            foreach (DataRow ro in dt.Rows)
                            {
                                LinkId = int.Parse(ro["Id"].ToString());
                            }
                        }
                        Response.Redirect(string.Format("StudentRegistration.aspx?Id={0}", LinkId), false);
                    }
                    else
                    {
                        lblMesag.Text = txtRegNo.Text + " is booked by other User Plz Submit Again!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        txtRegNo.Text = GeTRegNo();
                    }
                }
                else
                {
                    lblMesag.Text = "This Mobile No is already Registered!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMesag.Text = txtRegNo.Text + " is booked by other User Plz Submit Again!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                txtRegNo.Text = GeTRegNo();
            }
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMesag.Text = "";
        btnDetails.Visible = false;
        NewLoad();
    }
    public void ResetField()
    {
        txtArabicFirstName.Text = "";
        txtArabicLastName.Text = "";
        txtArabicMiddleName.Text = "";
        ddlTitle.SelectedIndex = 0;
        txtEmailID.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtMobileNo.Text = "";
        txtCallDate.Text = (DateTime.Today).ToShortDateString();
        txtLinkId.Text = "";
    }
    public void ResetField1()
    {
        txtCallDate.Text = (DateTime.Now).ToString();
        txtLinkId.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            try
            {
                if (bool.Parse(Request.QueryString["Flag"].ToString()) == true)
                {
                    if (s.IsRegNoUsed(txtRegNo.Text) == 0)
                    {

                    }
                    else
                    {
                        lblMesag.Text = txtRegNo.Text + " is booked by other User Plz Submit Again!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        txtRegNo.Text = GeTRegNo();
                        return;
                    }
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


            if (ddlNationality.SelectedValue == "0".ToString())
            {
                lblMesag.Text = "Nationality required";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            } 


            DateTime Dob = DateTime.Now;
            if (txtDobDate.Text != "")
                Dob = DateTime.Parse(txtDobYear.Text + "/" + txtDobMonth.Text + "/" + txtDobDate.Text);
            string RegisterNo = s.UpdateStudentDetails(Id, txtRegNo.Text, DateTime.Parse(txtCallDate.Text),
                    int.Parse(ddlGender.SelectedValue), int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtArabicFirstName.Text,
                    txtArabicMiddleName.Text, txtArabicLastName.Text, ddlNationality.SelectedValue, Session["EMPID"].ToString(), "0",
                    "0", "", "New Registration", "1", "4", "", txtMobileNo.Text,
                    txtEmailID.Text, "0", "0", "0", Session["EmpId"].ToString(), "", "", txtPhoneNo.Text, "",
                    "", "", "", "", "", "", "", "", "1", txtMotherTongue.Text, ddlProficiencyInEnglish.SelectedValue, Dob, ddlBloodGroup.SelectedValue, "0", ddlInternationalStudent.SelectedItem.Text,"0",chkaptitude.Checked);
            //NewLoad();
            string Name = Session["Name"].ToString();
            string EMPID = Session["EMPID"].ToString();
            //Session.Clear();
            Session["Name"] = Name;
            Session["EMPID"] = EMPID;

            lblMesag.Text = "Sucessfully Updated!!!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
            //ResetField();
            btnUpdate.Enabled = false;
            btnDelete.Visible = false;
            //pnlStudentReg.Visible = true;
            //pnlCallingDetails.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnDetails.Visible = true;
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
        }
    }
    protected void btnDetail_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            Response.Redirect(string.Format("StudentRegistration.aspx?Id={0}", Id), false);
            Session["M"] = txtMobileNo.Text;
            Session["E"] = txtEmailID.Text;
            Session["N"] = ddlNationality.SelectedValue;
        }
        catch
        {
        }
    }

    protected void btnverifyemail_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            int userid1 = 0;
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            try
            {
                userid1 = int.Parse(Session["EMPID"].ToString());

            }
            catch
            {

                userid1 = userid;

            }

            DataTable RegisterNo1 = s.InsertStudentMailVerifyLogs(int.Parse(Id), userid1, txtEmailID.Text, "INSCHECK");
            if (RegisterNo1.Rows[0][0].ToString().Contains("1") == true)
            {
                lblMesag.Text = "Mail Already send on  -" + RegisterNo1.Rows[0][1].ToString();
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
          
            string FromEmail = "admissions@skylineuniversity.ac.ae"; // tblEmpMaster from Session EmapId >> Emp Email Address
            string mailids=txtEmailID.Text;
            mailids = mailids + "," + Session["Emailid"].ToString(); 
            string ToEmail = mailids;
            string Subject = "Registration Details";
            string Body = "";
            //string CC = txtEmailID.Text;
            string CC = "";
            string Message = "";
            Subject = "Welcome to Skyline University College";
            Message = "<table> <tbody>";
            Message = Message + "<tr><td colspan=2>Welcome to Skyline University College!!!</td>";
            Message = Message + "</tr><tr><td colspan=2><br /></td>";
            Message = Message + "</tr><tr><td colspan=2>Kindly reply on this email to confirm your email id for official correspondence with Skyline University College in future.</td>";
            Message = Message + "</tr><tr><td colspan=2><br /></td>";
                 
            Message = Message + "<tr><td colspan=2>" + "Best Regards," + "</td></tr>";
            Message = Message + "<tr><td colspan=2>" + "Skyline University College" + "</td></tr>";
            Message = Message + "<tr><td colspan=2>" + "University City of Sharjah, Sharjah" + "</td></tr>";
            Message = Message + "<tr><td colspan=2>" + "P.O. Box: 1797, Sharjah, U.A.E" + "</td></tr>";
            Message = Message + "<tr><td colspan=2>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166" + "</td></tr>";
            Message = Message + "<tr><td colspan=2>" + "Email: admissions@skylineuniversity.ac.ae" + "</td></tr>";
            Message = Message + "</td></tr></tbody></table>";
            Body = Message;
                      
          
            try
            {
                DataTable RegisterNo = s.InsertStudentMailVerifyLogs(int.Parse(Id), userid1, txtEmailID.Text, "INSERT");
                if (RegisterNo.Rows[0][0].ToString().Contains("1")==true)
                {
                    try
                    {
                        SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                        lblMesag.Text = "Verification Mail send to Student";
                        lblMesag.ForeColor = System.Drawing.Color.Green;
                    }

                    catch
                    {
                        //DataTable RegisterNo1 = s.InsertStudentMailVerifyLogs(int.Parse(Id), int.Parse(Session["EMPID"].ToString()), txtEmailID.Text, "DELETE");
                        lblMesag.Text = "Mail not send.";
                        lblMesag.ForeColor = System.Drawing.Color.Red;

                    }
                }
            }
            catch
            {
                lblMesag.Text = "Mail not send.";
                lblMesag.ForeColor = System.Drawing.Color.Red;


            }

        }
        catch
        {
        }
    }


    protected void btnverifyreplyemail_Click(object sender, EventArgs e)
    {
        try
        {



            string Id = Request.QueryString["Id"].ToString();
            int userid1 = 0;
                        try
            {
                userid1 = int.Parse(Session["EMPID"].ToString());

            }
            catch
            {

                userid1 = userid;

            }



            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable RegisterNo1 = s.InsertStudentMailVerifyLogs(int.Parse(Id), userid1, txtEmailID.Text, "UPCHECK");
            if (RegisterNo1.Rows[0][0].ToString().Contains("1") == true)
            {
                lblMesag.Text = "Record Already Updated on  -" + RegisterNo1.Rows[0][1].ToString();
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }





            DataTable RegisterNo = s.InsertStudentMailVerifyLogs(int.Parse(Id), userid1, txtEmailID.Text, "EDIT");
            if (RegisterNo.Rows[0][0].ToString().Contains("1") == true)
            {
                try
                {
                    lblMesag.Text = "Record Updated Succesfully";
                    lblMesag.ForeColor = System.Drawing.Color.Green;
                }

                catch
                {
                    lblMesag.Text = "Try again.";
                    lblMesag.ForeColor = System.Drawing.Color.Red;

                }
            }
        }
        catch
        {
            lblMesag.Text = "Try again.";
            lblMesag.ForeColor = System.Drawing.Color.Red;

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
            DataTable dt = s.SetRegStudentDetails(int.Parse(txtLinkId.Text));
            foreach (DataRow ro in dt.Rows)
            {
                txtRegNo.Text = ro["RegistrationNo"].ToString();
                txtCallDate.Text = ro["CallDate"].ToString();
                txtFirstName.Text = ro["FirstName"].ToString();
                txtLastName.Text = ro["LastName"].ToString();
                txtMiddleName.Text = ro["MiddleName"].ToString();
                ddlGender.SelectedValue = ro["Gender"].ToString();
                ddlTitle.SelectedValue = ro["Title"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                txtAttendedBy.Text = Session["Name"].ToString();
                txtEmailID.Text = ro["EmailID"].ToString();
                txtMobileNo.Text = ro["MobileNo"].ToString();

                txtArabicFirstName.Text = ro["ArabicFirstName"].ToString();
                txtArabicMiddleName.Text = ro["ArabicMiddleName"].ToString();
                txtArabicLastName.Text = ro["ArabicLastName"].ToString();
                txtDobMonth.Text = DateTime.Parse(ro["DOB"].ToString()).Month.ToString();
                txtDobDate.Text = DateTime.Parse(ro["DOB"].ToString()).Day.ToString();
                txtDobYear.Text = DateTime.Parse(ro["DOB"].ToString()).Year.ToString();
                txtMotherTongue.Text = ro["MotherTongue"].ToString();
                ddlProficiencyInEnglish.Text = ro["ProficiencyInEnglish"].ToString();
                ddlBloodGroup.Text = ro["BloodGroup"].ToString();
                txtPhoneNo.Text = ro["Telephone"].ToString();
                ddlInternationalStudent.SelectedValue = ro["IsInternationalStudent"].ToString();
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
                txtRegNo.Text = ro["RegistrationNo"].ToString();
                txtCallDate.Text = ro["CallDate"].ToString();
                txtFirstName.Text = ro["FirstName"].ToString();
                txtLastName.Text = ro["LastName"].ToString();
                txtMiddleName.Text = ro["MiddleName"].ToString();
                ddlGender.SelectedValue = ro["Gender"].ToString();
                ddlTitle.SelectedValue = ro["Title"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                txtAttendedBy.Text = Session["Name"].ToString();
                txtEmailID.Text = ro["EmailID"].ToString();
                txtMobileNo.Text = ro["MobileNo"].ToString();
                ddlNationality.SelectedValue = ro["Nationality"].ToString();
                ddlInternationalStudent.SelectedValue = ro["IsInternationalStudent"].ToString();
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
                //Response.Redirect(string.Format("StudentRegistration.aspx?Id={0}", Id), false);
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                //pnlStudentReg.Visible = true;
                //pnlCallingDetails.Visible = true;
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
    protected void txtLinkId_TextChanged(object sender, EventArgs e)
    {
        SetData();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentList.aspx", false);
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("StudentLedger.aspx?RegNo=" + txtRegNo.Text, false);
        }
        catch
        {
        }
    }
}