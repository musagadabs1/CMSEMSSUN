using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_IndexSetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlIndex.Focus();

            StudentRegistrationDAL s = new StudentRegistrationDAL();
            ddlIndex.DataSource = s.SetDropdownListCDB(55);
            ddlIndex.DataTextField = "Description";
            ddlIndex.DataValueField = "Id";
            ddlIndex.DataBind();
            ddlDegree.DataSource = s.SetDropdownListCDB(14);
            ddlDegree.DataTextField = "Description";
            ddlDegree.DataValueField = "Id";
            ddlDegree.DataBind();
            ddlTerm.DataSource = s.SetDropdownListCDB(59);
            ddlTerm.DataTextField = "Term";
            ddlTerm.DataValueField = "TermID";
            ddlTerm.DataBind();
            ddlApprovedBy.DataSource = s.SetDropdownListCDB(57);
            ddlApprovedBy.DataTextField = "FIRSTANME";
            ddlApprovedBy.DataValueField = "EMPID";
            ddlApprovedBy.DataBind();
            ddlRevisedBy.DataSource = s.SetDropdownListCDB(57);
            ddlRevisedBy.DataTextField = "FIRSTANME";
            ddlRevisedBy.DataValueField = "EMPID";
            ddlRevisedBy.DataBind();
            BindGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Schedule = "";
            if (rdbScheduleTypeDay.Checked == true)
                Schedule = "D";
            if (rdbScheduleTypeMonth.Checked == true)
                Schedule = "M";
            if (rdbScheduleTypeYear.Checked == true)
                Schedule = "Y";
            DateTime? RevisedDate = null;
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            if (txtRevisedDate.Text != "")
            {
                string RevisedDate1 = Convert.ToDateTime(txtRevisedDate.Text, ci.DateTimeFormat).ToString("d");
                RevisedDate = DateTime.Parse(RevisedDate1);
            }
            txtApprovedDate.Text = Convert.ToDateTime(txtApprovedDate.Text, ci.DateTimeFormat).ToString("d");
            txtNextVerificationDate.Text = Convert.ToDateTime(txtNextVerificationDate.Text, ci.DateTimeFormat).ToString("d");
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = s.InsertIndexSetup(ddlIndex.SelectedValue, ddlDegree.SelectedValue, ddlTerm.SelectedValue, Schedule, int.Parse(txtSchedule.Text), int.Parse(ddlApprovedBy.SelectedValue), DateTime.Parse(txtApprovedDate.Text), int.Parse(ddlRevisedBy.SelectedValue), RevisedDate, txtRemarks.Text, int.Parse(Session["EmpId"].ToString()), chkIsActive.Checked, DateTime.Parse(txtNextVerificationDate.Text));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Sucessfully Saved!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                BindGrid();
            }
            else
            {
                lblMesag.Text = "Please check Entry!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
        }
        catch
        {
            lblMesag.Text = "Please check Entry!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
    }
    public void BindGrid()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvStudentList.DataSource = s.SetDropdownListCDB(56);
        gvStudentList.DataBind();
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMesag.Text = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        Session["IId"] = e.CommandArgument.ToString();
        DataTable dt = new DataTable();
        dt = s.GetIndexDetails(int.Parse(e.CommandArgument.ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            try
            {
                ddlIndex.SelectedValue = ro["MasterId"].ToString();
                ddlDegree.SelectedValue = ro["DegreeId"].ToString();
                ddlTerm.SelectedValue = ro["TermId"].ToString();
                ddlApprovedBy.SelectedValue = ro["ApprovedBy"].ToString();
                ddlRevisedBy.SelectedValue = ro["RevisedBy"].ToString();
                txtRemarks.Text = ro["Remarks"].ToString();
                chkIsActive.Checked = bool.Parse(ro["Status"].ToString());

                if (ro["ScheduleType"].ToString() == "D")
                {
                    rdbScheduleTypeDay.Checked = true;
                    rdbScheduleTypeMonth.Checked = false;
                    rdbScheduleTypeYear.Checked = false;
                }
                if (ro["ScheduleType"].ToString() == "M")
                {
                    rdbScheduleTypeMonth.Checked = true;
                    rdbScheduleTypeDay.Checked = false;
                    rdbScheduleTypeYear.Checked = false;
                }
                if (ro["ScheduleType"].ToString() == "Y")
                {
                    rdbScheduleTypeYear.Checked = true;
                    rdbScheduleTypeMonth.Checked = false;
                    rdbScheduleTypeDay.Checked = false;
                }

                txtSchedule.Text = ro["ScheduleDate"].ToString();
                txtApprovedDate.Text = ro["AppDate"].ToString();
                txtNextVerificationDate.Text = ro["NextDate"].ToString();
                txtRevisedDate.Text = ro["RevDate"].ToString();
            }
            catch
            {

            }
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string Schedule = "";
            if (rdbScheduleTypeDay.Checked == true)
                Schedule = "D";
            if (rdbScheduleTypeMonth.Checked == true)
                Schedule = "M";
            if (rdbScheduleTypeYear.Checked == true)
                Schedule = "Y";
            DateTime? RevisedDate = null;
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            if (txtRevisedDate.Text != "")
            {
                string RevisedDate1 = Convert.ToDateTime(txtRevisedDate.Text, ci.DateTimeFormat).ToString("d");
                RevisedDate = DateTime.Parse(RevisedDate1);
            }
            txtApprovedDate.Text = Convert.ToDateTime(txtApprovedDate.Text, ci.DateTimeFormat).ToString("d");
            txtNextVerificationDate.Text = Convert.ToDateTime(txtNextVerificationDate.Text, ci.DateTimeFormat).ToString("d");
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = s.UpdateIndexSetup(int.Parse(Session["IId"].ToString()), ddlIndex.SelectedValue, ddlDegree.SelectedValue, ddlTerm.SelectedValue, Schedule, int.Parse(txtSchedule.Text), int.Parse(ddlApprovedBy.SelectedValue), DateTime.Parse(txtApprovedDate.Text), int.Parse(ddlRevisedBy.SelectedValue), RevisedDate, txtRemarks.Text, int.Parse(Session["EmpId"].ToString()), chkIsActive.Checked, DateTime.Parse(txtNextVerificationDate.Text));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Data Updated Sucessfully!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                BindGrid();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                lblMesag.Text = "Please check Entry!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
        }
        catch
        {
            lblMesag.Text = "Please check Entry!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
    }
}