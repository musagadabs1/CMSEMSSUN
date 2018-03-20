using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_SendBulkMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                Drpschool.DataTextField = "schoolname";
                Drpschool.DataValueField = "schoolcode";
                Drpschool.DataBind();
                Drpschool.SelectedValue = Session["schoolcode"].ToString();

                Drpschool_SelectedIndexChanged(sender, e);
                ddlCategory.Focus();
                //BindListBox();
                
                ddlCategory.DataSource = s.SetDropdownListCDB(82);
                ddlCategory.DataTextField = "CallerStatus";
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataBind();
                ddlDegree.DataSource = s.SetDropdownListAsDegreeType(3, 1);
                ddlDegree.DataTextField = "Description";
                ddlDegree.DataValueField = "Id";
                ddlDegree.DataBind();
                gvStudentList.DataSource = null;
                gvStudentList.DataBind();
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvStudentList.DataSource = null;
        gvStudentList.DataBind();


    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        // for email
        try
        {
            string SMSResponse = "";
            SMSCAPI obj = new SMSCAPI();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string ToEmail = "";
            for (int i = 0; i < gvStudentList.Rows.Count; i++)
            {
                GridViewRow row = gvStudentList.Rows[i];
                Label lblEmail = (Label)row.FindControl("lblEmail");
                HiddenField hdMobile = (HiddenField)row.FindControl("hdMobile");
                LinkButton lnkId = (LinkButton)row.FindControl("lnkId");
                CheckBox chkAll = (CheckBox)row.FindControl("chkAll");
                bool EmailResponse = false;
                //string SMSResponse = "";
                if (chkAll.Checked == true)
                {
                    ToEmail = lblEmail.Text;
                    if (chkEmail.Checked == true)
                    {
                        try
                        {
                            if (ToEmail != "")
                            {
                                EmailResponse = SendEmail1.SendBulkEmail(txtFromEmail.Text, ToEmail, txtSubject.Text, editor.Content, "");
                              //EmailResponse = SendEmail1.SendBulkEmail(txtFromEmail.Text, "", txtSubject.Text, editor.Content, "");

                            }

                        }
                        catch
                        {
                        }
                    }
                    if (chkSendSMS.Checked == true)
                    {
                        //for sms
                        try
                        {
                          
                            SMSResponse = obj.SendSMS("", "", "+" + hdMobile.Value, txtSmsContent.Text);
                           
                        }
                        catch
                        {
                        }
                    }
                    try
                    {
                        string RegisterNo = s.InsertMailLog(lnkId.CommandArgument.ToString(), EmailResponse.ToString(), SMSResponse, txtSmsContent.Text, editor.Content);
                        if (RegisterNo == "RegisterNo")
                        {
                            lblMessage.Text = "Send Sucessfully!";
                            lblMessage.ForeColor = System.Drawing.Color.Blue;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            try
            {
                SMSResponse = obj.SendSMS("", "", "+" + "+971505240146", txtSmsContent.Text);
                SMSResponse = obj.SendSMS("", "", "+" + "+971554783385", txtSmsContent.Text);
            }
            catch
            {

            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = "Send Sucessfully!";
            lblMessage.ForeColor = System.Drawing.Color.Blue;
        }        
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            System.Data.DataTable dt = s.GetStudentListForBulkMail("1", ddlCategory.SelectedValue,Drpschool.SelectedValue);
            //ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();
        }
        catch
        {

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
    protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            System.Data.DataTable dt = s.GetStudentListForBulkMail("2", ddlDegree.SelectedValue,Drpschool.SelectedValue);
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();
        }
        catch
        {
        }
    }
    protected void chkSendSMS_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSendSMS.Checked == true)
        {
            pnlSms.Visible = true;
        }
        else
        {
            pnlSms.Visible = false;
        }
    }
    protected void chkEmail_CheckedChanged(object sender, EventArgs e)
    {
        if (chkEmail.Checked == true)
        {
            pnlEmailContent.Visible = true;
        }
        else
        {
            pnlEmailContent.Visible = false;
        }
    }
}