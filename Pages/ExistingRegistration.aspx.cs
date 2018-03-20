using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pages_ExistingRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtRegNo.Text = GeTRegNo();
                txtAttendedBy.Text = Session["Name"].ToString();
                txtCallDate.Text = (DateTime.Now).ToString();
                pnlStudentReg.Visible = false;
                LoadDropdown();
                txtRegNo.Focus();
                SetData();
            }
            catch
            {
                Response.Redirect("Login.aspx", false);
            }
            try
            {
                txtLinkId.Text = Request.QueryString["Id"].ToString();
                txtLinkId_TextChanged(sender, e);
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                txtAttendedBy.Text = s.GetRegisteredBy(txtLinkId.Text);
                if (txtAttendedBy.Text == "")
                {
                    txtAttendedBy.Text = Session["Name"].ToString();
                }
            }
            catch
            {
                btnSave.Visible = true;
            }
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
            RegNo = (int.Parse(ro[0].ToString()) + 1).ToString();
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
                int LinkId = int.Parse(Request.QueryString["Id"].ToString());
                lblMesag.Text = "";
                if (txtRegNo.Text == GeTRegNo())
                {
                    DateTime Dob = DateTime.Now;
                    if (txtDobDate.Text != "")
                        Dob = DateTime.Parse(txtDobYear.Text + "/" + txtDobMonth.Text + "/" + txtDobDate.Text);
                    string RegisterNo = s.InsertExistingStudentDetailsnew(LinkId, txtRegNo.Text, DateTime.Parse(txtCallDate.Text),
                        int.Parse(ddlGender.SelectedValue), int.Parse(ddlTitle.SelectedValue), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtArabicFirstName.Text,
                        txtArabicMiddleName.Text, txtArabicLastName.Text, ddlNationality.SelectedValue, Session["EMPID"].ToString(), "0",
                        "0", "", "Existing Registration", "2", "4", "", txtMobileNo.Text,
                        txtEmailID.Text, "0", "0", "0", Session["EmpId"].ToString(), "", "", txtPhoneNo.Text, "",
                        "", "", "", "", "", "", "", "", "1", txtMotherTongue.Text, ddlProficiencyInEnglish.SelectedValue, Dob, ddlBloodGroup.SelectedValue, "0", ddlInternationalStudent.SelectedItem.Text);
                   
                    lblMesag.Text = "Sucessfully Submitted!!!";
                    lblMesag.ForeColor = System.Drawing.Color.Blue;
                    if (RegisterNo == "")
                    {
                        lblMesag.Text = "Please Try Again!!!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    LinkId = int.Parse(RegisterNo);
                    SMSCAPI obj = new SMSCAPI();
                    string strPostResponse;
                    //strPostResponse = obj.SendSMS("", "", "+" + txtMobileNo.Text, "Thank you for Enrolling with SUC. For further assistance feel free to contact us ");
                    btnSave.Enabled = false;
                    if (LinkId == 0)
                    {
                        DataTable dt = s.GetLinkId(0);
                        foreach (DataRow ro in dt.Rows)
                        {
                            LinkId = int.Parse(ro["Id"].ToString());
                        }
                    }
                    Response.Redirect(string.Format("StudentRegistration.aspx?Id=" + LinkId + "&F=1"), false);
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
    public void SetData()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetRegStudentDetails(int.Parse(txtLinkId.Text));
            foreach (DataRow ro in dt.Rows)
            {
                //txtCallDate.Text = ro["CallDate"].ToString();
                txtCallDate.Text = (DateTime.Now).ToString(); ;
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
    protected void txtLinkId_TextChanged(object sender, EventArgs e)
    {
        SetData();
    }
}