using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_CancelDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ddlTerm.Enabled = false;
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                txtCallDate.Text = (DateTime.Now).ToString();
                string Id = Request.QueryString["Id"].ToString();
                SetData(Id);
                ddlTerm.DataSource = s.SetDropdownListCDB(52);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();
            }
            catch
            {
                Response.Redirect("FollowUpReport.aspx", false);
            }
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
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
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            if (txtRemarks.Text != "")
            {
                try
                {
                    StudentRegistrationDAL d = new StudentRegistrationDAL();
                    string RegNo = d.GetRegNo1(Request.QueryString["Id"].ToString());
                    if (Session["DepId"].ToString() != "4")
                    {
                        DataTable dt = d.GetCheckEmails(RegNo);
                        bool IsPresent = false;
                        if (dt.Rows.Count == 1)
                            IsPresent = true;
                        if (IsPresent == true)
                        {
                            lblMesag.Text = "Please contact Admin for Cancellation or postponed";
                            lblMesag.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                    string Result = s.InsertIpdateStatus(Request.QueryString["Id"].ToString(), DateTime.Parse(txtCallDate.Text), ddlStudentStatus.SelectedValue, txtRemarks.Text, int.Parse(Session["EMPID"].ToString()), int.Parse(ddlTerm.SelectedValue));
                    if (Result == "RegisterNo")
                    {
                        DataSet ds = s.ProcSetProgramForCancel(Request.QueryString["Id"].ToString(), Session["EMPID"].ToString()); 
                        DataTable dtStudentDetails = ds.Tables[0];
                        DataTable dtEmail = ds.Tables[1];
                        string FromEmail = dtEmail.Rows[0]["OFFICEEMAID"].ToString();
                        string ToEmail = "administration@skylineuniversity.ac.ae";
                        string Subject = "Postponed / Cancel / Active Student Detail";
                        string CC = "ssd@skylineuniversity.ac.ae,admissions@skylineuniversity.ac.ae";
                        string Message = "";
                        Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                        Message = Message + "<tr><td colspan=2><h3><font size=5>Postpond / Cancel / Actiive Student Detail</font></h3>";
                        Message = Message + "</td></tr><tr><td>REF NO </td><td>" + RegNo.ToUpper();
                        Message = Message + "</td></tr><tr><td>DATE </td><td>" + txtCallDate.Text.ToUpper();
                        Message = Message + "</td></tr><tr><td>NAME</td><td>" + txtName.Text.ToUpper();
                        Message = Message + "</td></tr><tr><td>PROCESSED BY</td><td>" + Session["Name"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REMARKS</td><td>" + txtRemarks.Text.ToUpper();
                        Message = Message + "</td></tr><tr><td>STATUS</td><td>" + ddlStudentStatus.SelectedItem.Text.ToUpper();
                        Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + dtStudentDetails.Rows[0]["DegreeCode"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + dtStudentDetails.Rows[0]["Shift"].ToString().ToUpper();

                        if (ddlStudentStatus.SelectedValue == "P")
                        {
                            Message = Message + "</td></tr><tr><td>CURRENT TERM</td><td>" + dtStudentDetails.Rows[0]["TermName"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>POSTPONED TERM</td><td>" + ddlTerm.SelectedItem.Text.ToUpper();
                        }
                        else
                        {
                            Message = Message + "</td></tr><tr><td>TERM</td><td>" + dtStudentDetails.Rows[0]["TermName"].ToString().ToUpper();
                        }
                        Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                        ToEmail = "administration@skylineuniversity.ac.ae";
                        SendEmails.SendEmail(FromEmail, ToEmail, Subject, Message, CC);
                        lblMesag.Text = "Sucessfully Updated!!!";
                        lblMesag.ForeColor = System.Drawing.Color.Blue;

                    }
                    else
                    {
                        lblMesag.Text = "Try Again";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                catch
                {
                    lblMesag.Text = "Try Again";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
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
            lblMesag.Text = "Try Again!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = s.GetCheckStudent(Request.QueryString["Id"].ToString());
        if (dt.Rows.Count == 1)
        {
            if (ddlStudentStatus.SelectedValue == "A")
            {
                lblMesag.Text = "Student is Active!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                btnUpdate.Enabled = false;
                return;
            }
            else
            {
                btnUpdate.Enabled = true;
                lblMesag.Text = "";
            }
        }
        else
        {
            btnUpdate.Enabled = true;
            lblMesag.Text = "";
        }
        if (ddlStudentStatus.SelectedValue == "P")
        {
            ddlTerm.Enabled = true;
        }
        else
        {
            ddlTerm.Enabled = false;
        }
    }
}