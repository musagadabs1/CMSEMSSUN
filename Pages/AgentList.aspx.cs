using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_AgentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            LoadNationality();
            Clear();
            bindgrid();
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        }
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL a = new StudentRegistrationDAL();
            int Country = Convert.ToInt32(ddlNationality.SelectedValue);
            //string State = ddlState.SelectedItem.Text.ToString();
            string State = txtState.Text;
            int Result = a.InsertAgentDetails(txtAgencyName.Text, txtAgentName.Text, State, Country, txtRemarks.Text, txtPhone.Text,
                txtEmail.Text, txtWebsite.Text, txtDateOfAgreement.Text, txtValidity.Text, Convert.ToInt32(txtTarget.Text), Convert.ToInt32(Session["EmpId"].ToString()));
            if (Result > 0)
            {
                lblMesag.Text = "Successfully Added!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                LoadNationality();
                Clear();
                btnUpdate.Visible = false;
                btnAdd.Visible = true; ;
                bindgrid();
            }
            else
            {
                lblMesag.Text = "Please Try Again!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Try Again!";
        }
    }
    public void bindgrid()
    {

        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvStudentList.DataSource = s.GetAgentDetails(0, "SELECTALL");
        gvStudentList.DataBind();
    }
    public void LoadNationality()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlNationality.DataSource = s.GetMediaSource(0,"", "SelectForAgent");
        ddlNationality.DataTextField = "MediaSource";
        ddlNationality.DataValueField = "Id";
        ddlNationality.DataBind();
        ddlNationality.Items.Insert(0,new ListItem("SELECT","0"));
    }

    //public void LoadState(string CountryCode)
    //{
    //    StudentRegistrationDAL s = new StudentRegistrationDAL();
    //    ddlState.DataSource = s.SetState(CountryCode);
    //    ddlState.DataTextField = "State";
    //    ddlState.DataValueField = "CountryCode";
    //    ddlState.DataBind();
    //}
    public void Clear()
    {
        txthdn_Id.Text = "";
        txtAgencyName.Text = "";
        txtAgentName.Text = "";
        ddlNationality.SelectedIndex = 0;
        //ddlState.SelectedIndex = 0;
        txtState.Text = "";
        txtRemarks.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtWebsite.Text = "";
        txtDateOfAgreement.Text = "";
        txtValidity.Text = "";
        txtTarget.Text = "";
        lblMesag.Text = "";
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("EditDetails"))
            {

                int Id = Convert.ToInt32(e.CommandArgument);
                StudentRegistrationDAL c = new StudentRegistrationDAL();
                DataTable dt = c.GetAgentDetails(Id, "SELECT");
                foreach (DataRow ro in dt.Rows)
                {
                    txtAgencyName.Text = ro["AgencyName"].ToString();
                    txthdn_Id.Text = ro["AgentId"].ToString();
                    txtAgentName.Text = ro["AgentName"].ToString();
                    ddlNationality.SelectedValue = ro["Country"].ToString();
                    //ddlState.SelectedItem.Text = ro["State"].ToString();
                    txtState.Text = ro["State"].ToString();
                    txtRemarks.Text = ro["Remarks"].ToString();
                    txtPhone.Text = ro["Phone"].ToString();
                    txtEmail.Text = ro["Email"].ToString();
                    txtWebsite.Text = ro["Website"].ToString();
                    if (!string.IsNullOrEmpty(ro["DateofAgreement"].ToString()))
                    {
                        txtDateOfAgreement.Text = (DateTime.Parse(ro["DateofAgreement"].ToString())).Day + "/" + (DateTime.Parse(ro["DateofAgreement"].ToString())).Month + "/" + (DateTime.Parse(ro["DateofAgreement"].ToString())).Year;
                    }
                    if (!string.IsNullOrEmpty(ro["Validity"].ToString()))
                    {
                        txtValidity.Text = (DateTime.Parse(ro["Validity"].ToString())).Day + "/" + (DateTime.Parse(ro["Validity"].ToString())).Month + "/" + (DateTime.Parse(ro["Validity"].ToString())).Year;
                    }
                          txtTarget.Text = ro["Target"].ToString();
                    lblMesag.Text = "";
                    btnUpdate.Visible = true;
                    btnAdd.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        //try
        //{
            int Country = Convert.ToInt32(ddlNationality.SelectedValue);
            //string State = ddlState.SelectedItem.Text.ToString();
            string State = txtState.Text;
            int AgentId = Convert.ToInt32(txthdn_Id.Text);
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            int Result = s.UpdateAgentDetails(AgentId, txtAgencyName.Text, txtAgentName.Text, State, Country, txtRemarks.Text, txtPhone.Text,
                            txtEmail.Text, txtWebsite.Text, txtDateOfAgreement.Text, txtValidity.Text, Convert.ToInt32(txtTarget.Text), Convert.ToInt32(Session["EmpId"].ToString()), "Update");
            Clear();
            btnUpdate.Visible = false;
            btnAdd.Visible = true; ;
            bindgrid();


            if (Result > 0)
            {
                lblMesag.Text = "Successfully Updated!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMesag.Text = "Please Try Again!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        //}
        //catch
        //{
        //    lblMesag.Text = "Please Try Again!";
        //    lblMesag.ForeColor = System.Drawing.Color.Red;
        //}
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Clear();
        btnUpdate.Visible = false;
        btnAdd.Visible = true;
    }
    protected void BtnViewReport_Click1(object sender, EventArgs e)
    {
        Response.Redirect("PrintOtherReport.aspx?E=39", false);
    }
    
    //protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LoadState(ddlNationality.SelectedValue);
    //}

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvStudentList.PageIndex = e.NewPageIndex;
        bindgrid();
    }

}

