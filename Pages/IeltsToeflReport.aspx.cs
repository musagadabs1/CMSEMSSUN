using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_IeltsToeflReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {
                ddlExamStatus.DataSource = s.SetDropdownListCDB(64);
                ddlExamStatus.DataTextField = "Status";
                ddlExamStatus.DataValueField = "Id";
                ddlExamStatus.DataBind();

                ddlTestType.DataSource = s.SetDropdownListCDB(65);
                ddlTestType.DataTextField = "TestType";
                ddlTestType.DataValueField = "Id";
                ddlTestType.DataBind();

                pnlReportViwer.Visible = false;
                try
                {
                    string LinkID = (Request.QueryString["LinkId"].ToString());
                    txtRegNo.Text = s.GetRegNo(LinkID);
                }
                catch
                {
                }
            }
            if (IsPostBack)
            {
                //btnSubmit_Click(sender, e);
            }
        }
        catch
        {
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string LinkId = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (txtRegNo.Text != "")
            LinkId = s.GetLinkIdByRegNo(txtRegNo.Text);
        else
            LinkId = "0";
        if (LinkId == "")
            LinkId = "0";
        string FromDate;
        string ToDate;
       
            FromDate = "1990-01-01";
        try
        {
            FromDate = (DateTime.Parse(txtFromDate.Text)).ToShortDateString();
        }
        catch
        {
            //FromDate = DateTime.Now.ToShortDateString();
            FromDate = "1990-01-01";
        }
        try
        {
            ToDate = (DateTime.Parse(txtToDate.Text)).ToShortDateString();
        }
        catch
        {
            ToDate = DateTime.Now.ToShortDateString();
        }
        Response.Redirect("PrintExamDate.aspx?A=" + LinkId + "&B=" + FromDate + "&C=" + ToDate + "&D=" + ddlExamStatus.SelectedValue + "&E=" + ddlTestType.SelectedValue, false);
    }
    protected void btnRegNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentListForResult.aspx", false);
    }
}