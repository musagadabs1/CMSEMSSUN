using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Pages_PolicyPrerequisite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtPolicyCode.Focus(); 
            LoadDropdown();
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlOrpID.DataSource = s.SetDropdownListCDB(33);
        ddlOrpID.DataTextField = "Policy";
        ddlOrpID.DataValueField = "Id";
        ddlOrpID.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string UnderTakingDocument = "";
            if (fuUnderTakingDocument.PostedFile != null && fuUnderTakingDocument.PostedFile.ContentLength > 0)
            {
                UnderTakingDocument = Path.GetFileName(fuUnderTakingDocument.PostedFile.FileName);
                string folder = Server.MapPath("~/UnderTakingForPolicy/");
                Directory.CreateDirectory(folder);
                fuUnderTakingDocument.PostedFile.SaveAs(Path.Combine(folder, UnderTakingDocument));
            }

            Policy p = new Policy();
            string Result = p.InsertPolicyPrerequisite(txtPolicyCode.Text,txtPrereqCode.Text,txtMinVal.Text,txtMaxVal.Text,int.Parse(ddlOrpID.SelectedValue),txtMinSkillVal1.Text,
            txtMaxSkillVal1.Text,txtSkill1Lbl.Text,txtMinSkillVal2.Text,txtMaxSkillVal2.Text,txtSkill2Lbl.Text,txtMinSkillVal3.Text,txtMaxSkillVal3.Text,txtSkill3Lbl.Text,
            txtMinSkillVal4.Text,txtMaxSkillVal4.Text,txtSkill4Lbl.Text,chkUndertakingDesired.Checked,UnderTakingDocument,int.Parse(Session["EMPID"].ToString()));
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