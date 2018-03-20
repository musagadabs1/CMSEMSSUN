using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_EntranceResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtRegistrationNo.Focus(); 
                txtSpeaking.Enabled = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                LoadDropdown();
                LoadGrid();
                try
                {
                    StudentRegistrationDAL d = new StudentRegistrationDAL();
                    string LinkId = Request.QueryString["LinkId"].ToString();
                    txtRegistrationNo.Text = d.GetRegNo(LinkId);
                    DataSet dt = d.SetMath2(int.Parse(LinkId));
                    BindGrid();
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        gvMath.DataSource = dt.Tables[0];
                        gvMath.DataBind();
                        pnlMath.Visible = true;
                    }
                    DataSet dt1 = d.SetToefl2(int.Parse(LinkId));
                    if (dt1.Tables[0].Rows.Count != 0)
                    {
                        GvToefl.DataSource = dt1.Tables[0];
                        GvToefl.DataBind();
                        pnlToefl.Visible = true;
                    }
                }
                catch
                {
                }
            }
            catch
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlTestType.DataSource = s.SetDropdownListCDB(65);
        ddlTestType.DataTextField = "TestType";
        ddlTestType.DataValueField = "Id";
        ddlTestType.DataBind();
        ddlStatus.DataSource = s.SetDropdownListCDB(64);
        ddlStatus.DataTextField = "Status";
        ddlStatus.DataValueField = "Id";
        ddlStatus.DataBind();
        ddlFoundation.DataSource = s.SetDropdownListCDB(63);
        ddlFoundation.DataTextField = "DegreeCode";
        ddlFoundation.DataValueField = "Id";
        ddlFoundation.DataBind();
        ddlExamDate.DataSource = s.SetDropdownListCDB(71);
        ddlExamDate.DataTextField = "Date";
        ddlExamDate.DataValueField = "Id";
        ddlExamDate.DataBind();
        ddlExamTime.DataSource = s.SetDropdownListCDB(72);
        ddlExamTime.DataTextField = "Date";
        ddlExamTime.DataValueField = "Id";
        ddlExamTime.DataBind();
    }
    public void LoadGrid()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvEntranceResult.DataSource = s.SetDropdownListAsDegreeType(23, int.Parse(Request.QueryString["LinkId"].ToString()));
        gvEntranceResult.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtListening.Text == "")
                txtListening.Text = "0";
            if (txtReading.Text == "")
                txtReading.Text = "0";
            if (txtSpeaking.Text == "")
                txtSpeaking.Text = "0";
            if (txtWriting.Text == "")
                txtWriting.Text = "0";
            string LinkId = Request.QueryString["LinkId"].ToString();
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertExamResult(LinkId, int.Parse(ddlTestType.SelectedValue), decimal.Parse(txtListening.Text), decimal.Parse(txtReading.Text), decimal.Parse(txtSpeaking.Text), decimal.Parse(txtWriting.Text), decimal.Parse(txtMarks.Text), int.Parse(ddlFoundation.SelectedValue), int.Parse(ddlStatus.SelectedValue), chkRetest.Checked, int.Parse(ddlExamDate.SelectedValue), int.Parse(ddlExamTime.SelectedValue), txtRemarks.Text, int.Parse(Session["EMPID"].ToString()));
            if (Result == "RegisterNo")
            {
                lblMesag.Text = "Data Saved Successfully.";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                LoadGrid();
                ClearField();
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtListening.Text == "")
                txtListening.Text = "0";
            if (txtReading.Text == "")
                txtReading.Text = "0";
            if (txtSpeaking.Text == "")
                txtSpeaking.Text = "0";
            if (txtWriting.Text == "")
                txtWriting.Text = "0";
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.UpdateExamResult(Session["TId"].ToString(), int.Parse(ddlTestType.SelectedValue), decimal.Parse(txtListening.Text), decimal.Parse(txtReading.Text), decimal.Parse(txtSpeaking.Text), decimal.Parse(txtWriting.Text), decimal.Parse(txtMarks.Text), int.Parse(ddlFoundation.SelectedValue), int.Parse(ddlStatus.SelectedValue), chkRetest.Checked, int.Parse(ddlExamDate.SelectedValue), int.Parse(ddlExamTime.SelectedValue), txtRemarks.Text, int.Parse(Session["EMPID"].ToString()));
            if (Result == "RegisterNo")
            {
                lblMesag.Text = "Data Updated Successfully.";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                LoadGrid();
                ClearField();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
    }
    protected void gvEntranceResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void ClearField()
    {
        ddlTestType.SelectedIndex = 0;
        txtListening.Text = "";
        txtReading.Text = "";
        txtSpeaking.Text = "";
        txtWriting.Text = "";
        txtMarks.Text = "";
        ddlFoundation.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        txtRemarks.Text = "";
        ddlExamDate.SelectedIndex = 0;
        ddlExamTime.SelectedIndex = 0;
        chkRetest.Checked = false;
    }
    protected void gvEntranceResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                Session["TId"] = Id;
                SetTextbox(int.Parse(Id));
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SetTextbox(int Id)
    {
        StudentRegistrationDAL d = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = d.SetDropdownListAsDegreeType(22, Id);
        foreach (DataRow ro in dt.Rows)
        {
            ddlTestType.SelectedValue = ro["TestType"].ToString();
            txtListening.Text = ro["Listening"].ToString();
            txtReading.Text = ro["Reading"].ToString();
            txtSpeaking.Text = ro["Speaking"].ToString();
            txtWriting.Text = ro["Writing"].ToString();
            txtMarks.Text = ro["Marks"].ToString();
            ddlFoundation.SelectedValue = ro["Foundation"].ToString();
            ddlStatus.SelectedValue = ro["ExamStatus"].ToString();
            txtRemarks.Text = ro["Remarks"].ToString();
            try
            {
                chkRetest.Checked = bool.Parse(ro["ReTest"].ToString());
                ddlExamDate.SelectedValue = ro["ExamDate"].ToString();
                ddlExamTime.SelectedValue = ro["ExamTime"].ToString();
            }
            catch
            {
            }
            if (ddlTestType.SelectedItem.Text == "MATH")
            {
                pnlHide.Visible = false;
            }
            else
            {
                pnlHide.Visible = true;
            }
        }
    }
    protected void ddlTestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTestType.SelectedItem.Text == "MATH")
        {
            pnlHide.Visible = false;
        }
        else
        {
            pnlHide.Visible = true;
        } 
        if (ddlTestType.SelectedItem.Text == "IELTS")
        {
            txtSpeaking.Enabled = true;
        }
        else
        {
            txtSpeaking.Enabled = false;
        }
        if (ddlTestType.SelectedItem.Text == "CHALLENGE EXAM")
        {
            pnlChallengeExam.Visible = true;
        }
        else
        {
            pnlChallengeExam.Visible = false;
        }
          
    }
    protected void gvMath_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("DownLoad"))
        {
            string FileName = e.CommandArgument.ToString();
            if (FileName != "")
                Response.Redirect("../Documents/" + Request.QueryString["LinkId"].ToString() + "/" + FileName + "", false);
        }
    }
    protected void gvMath_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDownLoad = (LinkButton)e.Row.FindControl("lnkDownLoad");
            HiddenField hdFNo = (HiddenField)e.Row.FindControl("hdFNo");
            if (hdFNo.Value == "")
                lnkDownLoad.Enabled = false;
        }
    }
    protected void GvToefl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDownLoad = (LinkButton)e.Row.FindControl("lnkDownLoad");
            HiddenField hdFNo = (HiddenField)e.Row.FindControl("hdFNo");
            if (hdFNo.Value == "")
                lnkDownLoad.Enabled = false;
        }
    }
    protected void GvToefl_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("DownLoad"))
        {
            string FileName = e.CommandArgument.ToString();
            if (FileName != "")
                Response.Redirect("../Documents/" + Request.QueryString["LinkId"].ToString() + "/" + FileName + "", false);
        }
    }
    protected void btnSendSMS_Click(object sender, EventArgs e)
    {
        try
        {
            SMSCAPI obj = new SMSCAPI();
            string strPostResponse;
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            //strPostResponse = obj.SendSMS("", "", "+" + d.GetCheckMobileContact(Request.QueryString["LinkId"].ToString()), "Dear Student, The result of the placement exam is published and can be checked through the student portal.");
            SendEmail1.SendEmail("examination@skylineuniversity.ac.ae", d.GetCheckMailContact(Request.QueryString["LinkId"].ToString()), "Placement Result", "Dear Student, The result of the placement exam is published and can be checked through the student portal.", "");
        }
        catch
        {
        }                        
    }
    protected void txtMarks_TextChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            DataTable dt = new DataTable();
            dt = d.SetDropdownListAsDegreeType(27, int.Parse(Request.QueryString["LinkId"].ToString()));
            if (dt.Rows[0][0].ToString() == "1" || dt.Rows[0][0].ToString() == "7")
            {
                if (ddlTestType.SelectedValue == "2")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 4) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("4.5")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    }
                    if ((decimal.Parse(txtMarks.Text) >= 3) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("3.5")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    } 
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("2.5")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "1")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 425) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("499")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    } 
                    if ((decimal.Parse(txtMarks.Text) >= 350) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("424")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("349")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "3")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 39) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("60")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    } 
                    if ((decimal.Parse(txtMarks.Text) >= 21) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("38")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    } 
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("20")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "4")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 117) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("170")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    } 
                    if ((decimal.Parse(txtMarks.Text) >= 67) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("116")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("63")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "6")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 29) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("35")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    } 
                    if ((decimal.Parse(txtMarks.Text) >= 24) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("28")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("23")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
            }
            if (dt.Rows[0][0].ToString() == "6" || dt.Rows[0][0].ToString() == "8")
            {
                if (ddlTestType.SelectedValue == "2")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 4) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("5.5")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    }
                    if ((decimal.Parse(txtMarks.Text) >= 3) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("3.5")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("2.5")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "1")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 425) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("499")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    }
                    if ((decimal.Parse(txtMarks.Text) >= 350) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("424")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("349")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "3")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 39) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("78")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    }
                    if ((decimal.Parse(txtMarks.Text) >= 21) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("38")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("20")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "4")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 117) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("210")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    }
                    if ((decimal.Parse(txtMarks.Text) >= 67) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("116")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("63")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
                if (ddlTestType.SelectedValue == "6")
                {
                    if ((decimal.Parse(txtMarks.Text) >= 29) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("35")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "28";
                    }
                    if ((decimal.Parse(txtMarks.Text) >= 24) & (decimal.Parse(txtMarks.Text) <= decimal.Parse("28")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "29";
                    }
                    if ((decimal.Parse(txtMarks.Text) <= decimal.Parse("23")))
                    {
                        ddlStatus.SelectedValue = "2";
                        ddlFoundation.SelectedValue = "64";
                    }
                }
            }
        }
        catch
        {
        }
    }
    protected void btnMailToMkt_Click(object sender, EventArgs e)
    {
        //SendEmail1.SendEmail11("examination@skylineuniversity.ac.ae", "ToMail", "Placement Result", "Placement exam is published and can be checked through the student portal.", "", "Attachment");
    }
    public DataTable CreateTable()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("LinkID");
            dt.Columns.Add("Subject");
            dt.Columns.Add("Date"); 
            dt.Columns.Add("Present"); 
            dt.Columns.Add("Marks");
            dt.Columns.Add("Grade");
            dt.Columns.Add("ExamDate");
            dt.Columns.Add("ChallengeID");
            dt.AcceptChanges();
            ViewState["User"] = dt;
            return dt;
        }
        catch (Exception Ex)
        {
            return null;
        }
    }
    public void BindGrid()
    {

        int count = 0;
        int count1 = 0;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        StudentRegistrationDAL d = new StudentRegistrationDAL();
        string LinkId = Request.QueryString["LinkId"].ToString();
        DataTable dt = d.GetChallengeDetails(Convert.ToInt32(LinkId));
        gdvChallengeExam.DataSource = null;
        gdvChallengeExam.DataBind();
        dt2 = d.GetChallengeExamResults(Convert.ToInt32(LinkId));

        if (dt2.Rows.Count > 0)
        {
            txtRemarksCh.Text = Convert.ToString(dt2.Rows[0]["Remarks"]);
        }
        if (dt.Rows.Count > 0)
        {
            dt1 = CreateTable();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt1.NewRow();
                dr1[0] = Convert.ToString(dt.Rows[count][0]);
                dr1[1] = Request.QueryString["LinkId"].ToString();
                // 
                if (Convert.ToString(dt.Rows[count][1]) == "Subject1")
                {
                    dr1[2] = "ACC5001-ACCOUNTING PRINCIPLES & PRACTICE";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present1"];
                        dr1[5] = dt2.Rows[0]["Marks1"];
                        dr1[6] = dt2.Rows[0]["Grade1"];
                        dr1[7] = dt2.Rows[0]["ExamDate1"];
                    }
                }
                if (Convert.ToString(dt.Rows[count][1]) == "Subject2")
                {
                    dr1[2] = "ECO5002-ECONOMICS PRINCIPLES & PRACTICE";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present2"];
                        dr1[5] = dt2.Rows[0]["Marks2"];
                        dr1[6] = dt2.Rows[0]["Grade2"];
                        dr1[7] = dt2.Rows[0]["ExamDate2"];
                    }
                }
                if (Convert.ToString(dt.Rows[count][1]) == "Subject3")
                {
                    dr1[2] = "MAT5003-FUNDAMENTALS OF QUANTITATIVE METHODS";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present3"];
                        dr1[5] = dt2.Rows[0]["Marks3"];
                        dr1[6] = dt2.Rows[0]["Grade3"];
                        dr1[7] = dt2.Rows[0]["ExamDate3"];
                    }
                }
                if (Convert.ToString(dt.Rows[count][1]) == "Subject4")
                {
                    dr1[2] = "FIN5004-PRINCIPLES OF FINANCE";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present4"];
                        dr1[5] = dt2.Rows[0]["Marks4"];
                        dr1[6] = dt2.Rows[0]["Grade4"];
                        dr1[7] = dt2.Rows[0]["ExamDate4"];
                    }
                }
                if (Convert.ToString(dt.Rows[count][1]) == "Subject5")
                {
                    dr1[2] = "MGM5005-PERSPECTIVE ON MANAGEMENT";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present5"];
                        dr1[5] = dt2.Rows[0]["Marks5"];
                        dr1[6] = dt2.Rows[0]["Grade5"];
                        dr1[7] = dt2.Rows[0]["ExamDate5"];
                    }
                }
                if (Convert.ToString(dt.Rows[count][1]) == "Subject6")
                {
                    dr1[2] = "MKT5006-PRINCIPLES OF MARKETING";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present6"];
                        dr1[5] = dt2.Rows[0]["Marks6"];
                        dr1[6] = dt2.Rows[0]["Grade6"];
                        dr1[7] = dt2.Rows[0]["ExamDate6"];
                    }
                }
                if (Convert.ToString(dt.Rows[count][1]) == "Subject7")
                {
                    dr1[2] = "MGM5007-OPERATIONS MANAGEMENT";
                    if (dt2.Rows.Count > 0)
                    {
                        dr1[4] = dt2.Rows[0]["Present7"];
                        dr1[5] = dt2.Rows[0]["Marks7"];
                        dr1[6] = dt2.Rows[0]["Grade7"];
                        dr1[7] = dt2.Rows[0]["ExamDate7"];
                    }
                }
                dr1[3] = Convert.ToString(dt.Rows[count][2]);
                dr1[8] = Convert.ToString(dt.Rows[count][3]);

                dt1.Rows.Add(dr1);
                count = count + 1;
            }
        }
        try
        {
            gdvChallengeExam.DataSource = dt1;
            gdvChallengeExam.DataBind();
            foreach (GridViewRow row in gdvChallengeExam.Rows)
            {

                CheckBox Present = (CheckBox)row.FindControl("chkPresent");
                TextBox txtMarks = (TextBox)row.FindControl("txtMarks");
                TextBox txtGrade = (TextBox)row.FindControl("txtGrade");
                TextBox txtExamDate = (TextBox)row.FindControl("txtExamDate");
                if (Present.Checked)
                {
                    txtMarks.Enabled = true;
                    txtGrade.Enabled = true;
                    txtExamDate.Enabled = true;
                }
                else
                {
                    txtMarks.Enabled = false;
                    txtGrade.Enabled = false;
                    txtExamDate.Enabled = false;
                    //txtMarks.Text  = "";
                    //txtGrade.Text = "";
                    //txtExamDate.Text = "";
                }

            }  
        }
        catch (Exception E)
        {
        }
        // BindGrid();
    }
    protected void btnSaveChallenge_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL d = new StudentRegistrationDAL();
        try
        {

            foreach (GridViewRow row in gdvChallengeExam.Rows)
            {
                Label LinkID = (Label)row.FindControl("lblLinkID");
                Label ID = (Label)row.FindControl("lblId");
                Label ChID = (Label)row.FindControl("lblChallengeId");
                TextBox txtMarks = (TextBox)row.FindControl("txtMarks");
                TextBox txtGrade = (TextBox)row.FindControl("txtGrade");
                TextBox txtExamDate = (TextBox)row.FindControl("txtExamDate");
                CheckBox Present = (CheckBox)row.FindControl("chkPresent");

                dt = d.CheckExists(Convert.ToInt32(LinkID.Text));
                if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                {
                    if (Present.Checked)
                    {
                        d.UpdateChallengeExamResult(1, Convert.ToInt32(LinkID.Text), Convert.ToInt32(ChID.Text), Convert.ToDateTime(txtExamDate.Text), Convert.ToDecimal(txtMarks.Text), txtGrade.Text, int.Parse(Session["EMPID"].ToString()), Convert.ToInt32(ID.Text), Present.Checked, txtRemarksCh.Text);
                    }
                    }
                else
                {
                    if (Present.Checked)
                    {
                        d.InsertChallengeExamResult(1, Convert.ToInt32(LinkID.Text), Convert.ToInt32(ChID.Text), Convert.ToDateTime(txtExamDate.Text), Convert.ToDecimal(txtMarks.Text), txtGrade.Text, int.Parse(Session["EMPID"].ToString()), Convert.ToInt32(ID.Text), Present.Checked, txtRemarksCh.Text);
                    }
                    }
            }
            Label1.Text = "Data Saved Successfully";

        }
        catch (Exception Ex)
        {
            Label1.Text = "Error..Try again Later";
        }
    }
    protected void chkPresent_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow gr = (GridViewRow)((DataControlFieldCell)((CheckBox)sender).Parent).Parent;
        CheckBox chkPresent = (CheckBox)gr.FindControl("chkPresent");
        TextBox txtMarks = (TextBox)gr.FindControl("txtMarks");
        TextBox txtGrade = (TextBox)gr.FindControl("txtGrade");
        TextBox txtExamDate = (TextBox)gr.FindControl("txtExamDate");
        if (chkPresent.Checked)
        {
            txtMarks.Enabled = true;
            txtGrade.Enabled = true;
            txtExamDate.Enabled = true;
        }
        else
        {
            txtMarks.Enabled = false;
            txtGrade.Enabled = false;
            txtExamDate.Enabled = false;
            //txtMarks.Text  = "";
            //txtGrade.Text = "";
            //txtExamDate.Text = "";
        }
    }
}