using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_PrerequisiteSetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtprerequisiteCode.Focus();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Policy p = new Policy();
            string Result = p.InsertPrerequisite(txtprerequisiteCode.Text, txtprerequisiteDtl.Text, txtCourseCod.Text, chkIsActive.Checked, int.Parse(Session["EMPID"].ToString()));
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