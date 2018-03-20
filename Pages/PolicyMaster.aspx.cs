using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_PolicyMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFormName.Focus();
            LoadDropDown();
            BindGrid();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    public void BindGrid()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvPolicyList.DataSource = s.SetDropdownListCDB(93);
        gvPolicyList.DataBind();
    }
    public void LoadDropDown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlFormName.DataSource = s.SetDropdownListCDB(88);
        ddlFormName.DataTextField = "FormName";
        ddlFormName.DataValueField = "Id";
        ddlFormName.DataBind();

        ddlProgram.DataSource = s.SetDropdownListCDB(89);
        ddlProgram.DataTextField = "Program";
        ddlProgram.DataValueField = "Id";
        ddlProgram.DataBind();

        ddlFormType.DataSource = s.SetDropdownListCDB(90);
        ddlFormType.DataTextField = "FormType";
        ddlFormType.DataValueField = "Id";
        ddlFormType.DataBind();

        ddlAcademicYear.DataSource = s.SetDropdownListCDB(91);
        ddlAcademicYear.DataTextField = "FNAME";
        ddlAcademicYear.DataValueField = "Id";
        ddlAcademicYear.DataBind();

        ddlFeeGroup.DataSource = s.SetDropdownListCDB(92);
        ddlFeeGroup.DataTextField = "FeeWaiverType";
        ddlFeeGroup.DataValueField = "Id";
        ddlFeeGroup.DataBind();
    }
    protected void chkIsFinance_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsFinance.Checked == true)
            pnlFeeGroup.Visible = true;
        else
            pnlFeeGroup.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Policy p = new Policy();
            string Result = p.InsertPolicyMaster(1, 0, int.Parse(ddlFormName.SelectedValue), int.Parse(ddlProgram.SelectedValue), int.Parse(ddlFormType.SelectedValue), txtMinValue.Text, txtMaxValue.Text, int.Parse(ddlAcademicYear.SelectedValue), chkIsActive.Checked, chkIsFinance.Checked, int.Parse(ddlFeeGroup.SelectedValue), txtRemarks.Text, bool.Parse("False"), int.Parse(Session["EMPID"].ToString()));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Successfully Saved!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                BindGrid();
                txtMinValue.Text = "";
                txtMaxValue.Text = "";
                txtRemarks.Text = "";
                ddlFormName.SelectedIndex = 0;
                ddlFormType.SelectedIndex = 0;
                ddlProgram.SelectedIndex = 0;
                ddlFeeGroup.SelectedIndex = 0;
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Policy p = new Policy();
            string Result = p.InsertPolicyMaster(2, int.Parse(hdId.Value), int.Parse(ddlFormName.SelectedValue), int.Parse(ddlProgram.SelectedValue), int.Parse(ddlFormType.SelectedValue), txtMinValue.Text, txtMaxValue.Text, int.Parse(ddlAcademicYear.SelectedValue), chkIsActive.Checked, chkIsFinance.Checked, int.Parse(ddlFeeGroup.SelectedValue), txtRemarks.Text, bool.Parse("False"), int.Parse(Session["EMPID"].ToString()));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Successfully Updated!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                BindGrid();
                txtMinValue.Text = "";
                txtMaxValue.Text = "";
                txtRemarks.Text = "";
                ddlFormName.SelectedIndex = 0;
                ddlFormType.SelectedIndex = 0;
                ddlProgram.SelectedIndex = 0;
                ddlFeeGroup.SelectedIndex = 0;
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            Policy p = new Policy();
            string Result = p.InsertPolicyMaster(3, int.Parse(hdId.Value), int.Parse(ddlFormName.SelectedValue), int.Parse(ddlProgram.SelectedValue), int.Parse(ddlFormType.SelectedValue), txtMinValue.Text, txtMaxValue.Text, int.Parse(ddlAcademicYear.SelectedValue), chkIsActive.Checked, chkIsFinance.Checked, int.Parse(ddlFeeGroup.SelectedValue), txtRemarks.Text, bool.Parse("False"), int.Parse(Session["EMPID"].ToString()));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Successfully Deleted!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                BindGrid();
                txtMinValue.Text = "";
                txtMaxValue.Text = "";
                txtRemarks.Text = "";
                ddlFormName.SelectedIndex = 0;
                ddlFormType.SelectedIndex = 0;
                ddlProgram.SelectedIndex = 0;
                ddlFeeGroup.SelectedIndex = 0;
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvPolicyList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Policy p = new Policy();
        if (e.CommandName.Equals("Update"))
        {
            string Id = e.CommandArgument.ToString();
            hdId.Value = Id.ToString();
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            DataTable dt = new DataTable();
            dt = p.SetPolicy(int.Parse(hdId.Value));
            foreach (DataRow ro in dt.Rows)
            {
                ddlFeeGroup.SelectedValue = ro["FeeGroup"].ToString();
                ddlFormName.SelectedValue = ro["FormName"].ToString();
                ddlFormType.SelectedValue = ro["FormType"].ToString();
                ddlProgram.SelectedValue = ro["Program"].ToString();
                ddlAcademicYear.SelectedValue = ro["AcademicYear"].ToString();
                txtMaxValue.Text = ro["MaxValue"].ToString();
                txtMinValue.Text = ro["MinValue"].ToString();
                txtRemarks.Text = ro["Remarks"].ToString();
                chkIsActive.Checked = bool.Parse(ro["IsActive"].ToString());
                chkIsFinance.Checked = bool.Parse(ro["IsFinance"].ToString());
                if (chkIsFinance.Checked == true)
                    pnlFeeGroup.Visible = true;
                else
                    pnlFeeGroup.Visible = false;
            }
        }
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            hdId.Value = Id.ToString();
            string Result = p.InsertPolicyMaster(4, int.Parse(hdId.Value), 0, 0, 0, "", "", 0, bool.Parse("False"), bool.Parse("False"), 0, "", bool.Parse("True"), int.Parse(Session["EMPID"].ToString()));
            if (Result == "Sucess")
            {
                lblMesag.Text = "Successfully Activated!!!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                BindGrid();
                txtMinValue.Text = "";
                txtMaxValue.Text = "";
                txtRemarks.Text = "";
                ddlFormName.SelectedIndex = 0;
                ddlFormType.SelectedIndex = 0;
                ddlProgram.SelectedIndex = 0;
                ddlFeeGroup.SelectedIndex = 0;
            }
            else
            {
                lblMesag.Text = "Please Try Again!!!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void gvPolicyList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvPolicyList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}