using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_PolicySetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAcademicSemester.Focus();
            LoadDropdown();
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlAcademicSemester.DataSource = s.SetDropdownListCDB(36);
        ddlAcademicSemester.DataTextField = "Semester";
        ddlAcademicSemester.DataValueField = "Id";
        ddlAcademicSemester.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Policy p = new Policy();
            string Result = p.InsertPolicySetup(txtPolicyCode.Text,txtPolicyDescription.Text,int.Parse(ddlAcademicSemester.SelectedValue),chkIsMand.Checked,chkIsActive.Checked,int.Parse(Session["EMPID"].ToString()));
            lblMesag.Text = "Successfully Saved!!!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
        catch
        {
            lblMesag.Text = "Please Try Again!!!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
}