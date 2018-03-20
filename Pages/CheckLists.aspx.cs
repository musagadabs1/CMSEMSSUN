using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_CheckLists : System.Web.UI.Page
{
    string Caption = "";
    int i = 0;
    int j = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.FillGridView();
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                lblUserName.Text = "Student Name : " + s.GetName(int.Parse(Request.QueryString["Id"].ToString()));
                lblUserName.Text = lblUserName.Text.ToUpper();
                lblDate.Text = "Registration No : " + s.GetRegNo(Request.QueryString["Id"].ToString());
                lblUserName.ForeColor = System.Drawing.Color.Blue;
                lblDate.ForeColor = System.Drawing.Color.Blue;
                int Count = s.IsMissedCall(int.Parse(Session["EmpId"].ToString()));
                if (Count > 0)
                {
                    imgRequest.ImageUrl = "~/Icons/notifcation-message.png";
                    lblCount.Visible = true;
                    div1.Visible = true;
                    lblCount.Text = Count.ToString();
                }
                else
                {
                    imgRequest.ImageUrl = "~/Icons/notification-on.png";
                    lblCount.Visible = false;
                    div1.Visible = false;
                }
            }
            catch
            {
            }
        }
    }
    private void FillGridView()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
         DataTable dt = s.GetCheckLIstValue(int.Parse(Request.QueryString["Id"].ToString()), 12345);
         try
         {

             string categoryname = s.Getstudentcategory(int.Parse(Request.QueryString["Id"].ToString()));
             Lblcategory.Text = categoryname;
         }
            catch
            {
            }
          try
          {

            foreach (DataRow ro in dt.Rows)
            {
                txtRemarks.Text = ro["mktRemarks"].ToString();
                txtremarkscoec.Text = ro["coecRemarks"].ToString();
                txtremarksfin.Text = ro["finRemarks"].ToString();
                txtremarksiro.Text = ro["iroRemarks"].ToString();
                txtremarksadm.Text = ro["admRemarks"].ToString();
            }
         }
            catch
         {
            }


            int Count = 0;
            if (Session["DepId"].ToString() == "4")
            {
              
                Count = s.CountAdminCheckList(Request.QueryString["Id"].ToString());
                if (Count == 0)
                {
                    lblMesag.Text = "Marketting should fill the checklist first!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                txtremarksadm.Enabled = true;

                                         
            }
            if (Session["DepId"].ToString() == "2")
            {
               
                Count = s.CountFinanceCheckList(Request.QueryString["Id"].ToString());
                if (Count == 0)
                {
                    lblMesag.Text = "Admin should fill the checklist first!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                txtremarksfin.Enabled = true;
            }
            if (Session["DepId"].ToString() == "18")
            {
                Count = s.CountIroCheckList(Request.QueryString["Id"].ToString());
                if (Count == 0)
                {
                    lblMesag.Text = "Finance should fill the checklist first!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                txtremarksiro.Enabled = true;
            }


            if (Session["DepId"].ToString() == "32")
            {
                Count = s.CountIroCheckList(Request.QueryString["Id"].ToString());
                if (Count == 0)
                {
                    lblMesag.Text = "Finance should fill the checklist first!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                txtremarkscoec.Enabled = true;
            }

            DataTable dt1 = s.GetCheckList(int.Parse(Session["EMPID"].ToString()), int.Parse(Request.QueryString["Id"].ToString()));
            if (dt1.Rows.Count != 0)
            {
                gvStudentList.DataSource = dt1;
                gvStudentList.DataBind();
            }
            else
            {
                gvStudentList.DataSource = null;
                gvStudentList.DataBind();
            }
        }
        catch (Exception ex)
        {
            gvStudentList.DataSource = null;
            gvStudentList.DataBind();
            //lblMesag.Text = "Please Fill Correct Information!";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int EmpId = int.Parse(Session["EMPID"].ToString());
            string LinkId = Request.QueryString["Id"].ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();            
            foreach (GridViewRow row in gvStudentList.Rows)
            {
                Label lblId = (Label)row.FindControl("lblId");
                Label lblDepId = (Label)row.FindControl("lblDepId");
                CheckBox chkMarketting = (CheckBox)row.FindControl("chkMarketting");
                CheckBox chkAdmin = (CheckBox)row.FindControl("chkAdmin");
                CheckBox chkFinance = (CheckBox)row.FindControl("chkFinance");
                CheckBox chkIro = (CheckBox)row.FindControl("chkIro");
                CheckBox chkCOEC = (CheckBox)row.FindControl("chkcoec");
                TextBox txtMarketting = (TextBox)row.FindControl("txtMarketting");
                TextBox txtAdmin = (TextBox)row.FindControl("txtAdmin");
                TextBox txtFinance = (TextBox)row.FindControl("txtFinance");
                TextBox txtIRO = (TextBox)row.FindControl("txtIRO");
                TextBox   txtcoec = (TextBox)row.FindControl("txtcoec");

                HiddenField txtMArkettingDate = (HiddenField)row.FindControl("txtMArkettingDate");
                HiddenField txtAdminDate = (HiddenField)row.FindControl("txtAdminDate");
                HiddenField txtFinanceDate = (HiddenField)row.FindControl("txtFinanceDate");
                HiddenField txtIRODate = (HiddenField)row.FindControl("txtIRODate");
                HiddenField txtcoecDate = (HiddenField)row.FindControl("txtcoecDate");

                if (txtMarketting.Text == "")
                      txtMarketting.Text = "0";
                if (txtAdmin.Text == "")
                    txtAdmin.Text = "0";
                if (txtFinance.Text == "")
                    txtFinance.Text = "0";
                if (txtIRO.Text == "")
                    txtIRO.Text = "0";
                if (txtcoec.Text == "")
                    txtcoec.Text = "0";

              
             

                Label lblMrktCreatedBy = (Label)row.FindControl("lblMrktCreatedBy");
                Label lblAdmCreatedBy = (Label)row.FindControl("lblAdmCreatedBy");
                Label lblFinCreatedBy = (Label)row.FindControl("lblFinCreatedBy");
                Label lblIroCreatedBy = (Label)row.FindControl("lblIroCreatedBy");
                Label lblCOECCreatedBy = (Label)row.FindControl("lblCOECCreatedBy");


                if (lblDepId.Text == "1")
                    lblMrktCreatedBy.Text = EmpId.ToString();
                if (lblDepId.Text == "2")
                    lblAdmCreatedBy.Text = EmpId.ToString();
                if (lblDepId.Text == "3")
                    lblFinCreatedBy.Text = EmpId.ToString();
                if (lblDepId.Text == "4")
                    lblIroCreatedBy.Text = EmpId.ToString();
                if (lblDepId.Text == "5")
                    lblCOECCreatedBy.Text = EmpId.ToString();
                if (lblMrktCreatedBy.Text == "")
                    lblMrktCreatedBy.Text = "0";
                if (lblAdmCreatedBy.Text == "")
                    lblAdmCreatedBy.Text = "0";
                if (lblFinCreatedBy.Text == "")
                    lblFinCreatedBy.Text = "0";
                if (lblIroCreatedBy.Text == "")
                    lblIroCreatedBy.Text = "0";
                if (lblCOECCreatedBy.Text == "")
                    lblCOECCreatedBy.Text = "0";

                s.InsertChecklistValues1(LinkId, int.Parse(lblId.Text));
                DateTime? MarkettingDate = null;
                if (txtMArkettingDate.Value != "")
                    MarkettingDate = DateTime.Parse(txtMArkettingDate.Value);
                DateTime? AdminDate = null;
                if (txtAdminDate.Value != "")
                    AdminDate = DateTime.Parse(txtAdminDate.Value);
                DateTime? FinanceDate = null;
                if (txtFinanceDate.Value != "")
                    FinanceDate = DateTime.Parse(txtFinanceDate.Value);
                DateTime? IRODate = null;
                if (txtIRODate.Value != "")
                    IRODate = DateTime.Parse(txtIRODate.Value);

                DateTime? COECDate = null;
                if (txtcoecDate.Value != "")
                    COECDate = DateTime.Parse(txtcoecDate.Value);


                if (lblDepId.Text == "1")
                    MarkettingDate = DateTime.Now;
                if (lblDepId.Text == "2")
                    AdminDate = DateTime.Now;
                if (lblDepId.Text == "3")
                    FinanceDate = DateTime.Now;
                if (lblDepId.Text == "4")
                    IRODate = DateTime.Now;
                if (lblDepId.Text == "5")
                    COECDate = DateTime.Now;


                string Result = s.InsertChecklistValues(int.Parse(lblId.Text), LinkId, chkMarketting.Checked, chkAdmin.Checked, chkFinance.Checked, chkIro.Checked, chkCOEC.Checked, txtMarketting.Text, txtAdmin.Text, txtFinance.Text, txtIRO.Text, txtcoec.Text, int.Parse(lblMrktCreatedBy.Text), int.Parse(lblAdmCreatedBy.Text), int.Parse(lblFinCreatedBy.Text), int.Parse(lblIroCreatedBy.Text), int.Parse(lblCOECCreatedBy.Text), txtRemarks.Text, MarkettingDate, AdminDate, FinanceDate, IRODate, COECDate,txtremarksadm.Text,txtremarksfin.Text,txtremarksiro.Text,txtremarkscoec.Text);
                if (Result == "Sucess")
                {
                    lblMesag.Text = "Sucessfully Submitted!";
                    lblMesag.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lblMesag.Text = "Please Try Again!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                }
            }
            //Response.Redirect("StudentList.aspx", false);
        }
        catch
        {
            lblMesag.Text = "Please Try Again!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            //Added by Saravanakumar-To avoid the Slowness
            GridViewRow row = e.Row;
            row.Attributes["id"] = gvStudentList.DataKeys[e.Row.RowIndex].Value.ToString();


            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
            Label lblCaption = (Label)e.Row.FindControl("lblCaption");
            if (Caption == lblCaption.Text)
            {
                lblCaption.Text = "";
                j++;
            }
            else
            {
                lblCaption.Font.Bold = true;
                i = 0;
            }
            if (i == 0)
            {
                Caption = lblCaption.Text;
                i++;
            } 
            string LinkId = Request.QueryString["Id"].ToString();
            Label lblId = (Label)e.Row.FindControl("lblId");
            Label lblDepId = (Label)e.Row.FindControl("lblDepId");
            CheckBox chkMarketting = (CheckBox)e.Row.FindControl("chkMarketting");
            CheckBox chkAdmin = (CheckBox)e.Row.FindControl("chkAdmin");
            CheckBox chkFinance = (CheckBox)e.Row.FindControl("chkFinance");
            CheckBox chkIro = (CheckBox)e.Row.FindControl("chkIro");
            CheckBox chkCOEC = (CheckBox)e.Row.FindControl("chkcoec");

            TextBox txtMarketting = (TextBox)e.Row.FindControl("txtMarketting");
            TextBox txtAdmin = (TextBox)e.Row.FindControl("txtAdmin");
            TextBox txtFinance = (TextBox)e.Row.FindControl("txtFinance");
            TextBox txtIRO = (TextBox)e.Row.FindControl("txtIRO");
            TextBox txtcoec = (TextBox)e.Row.FindControl("txtcoec");


            Label lblMrktCreatedBy = (Label)e.Row.FindControl("lblMrktCreatedBy");
            Label lblAdmCreatedBy = (Label)e.Row.FindControl("lblAdmCreatedBy");
            Label lblFinCreatedBy = (Label)e.Row.FindControl("lblFinCreatedBy");
            Label lblIroCreatedBy = (Label)e.Row.FindControl("lblIroCreatedBy");
            Label lblCOECCreatedBy = (Label)e.Row.FindControl("lblCOECCreatedBy");


           
            HiddenField txtMArkettingDate = (HiddenField)e.Row.FindControl("txtMArkettingDate");
            HiddenField txtAdminDate = (HiddenField)e.Row.FindControl("txtAdminDate");
            HiddenField txtFinanceDate = (HiddenField)e.Row.FindControl("txtFinanceDate");
            HiddenField txtIRODate = (HiddenField)e.Row.FindControl("txtIRODate");

            HiddenField txtcoecDate = (HiddenField)e.Row.FindControl("txtcoecDate");

           

            if (lblDepId.Text == "1")
            {
                chkMarketting.Enabled = true;
                chkAdmin.Enabled = false;
                chkFinance.Enabled = false;
                chkIro.Enabled = false;
                txtMarketting.Enabled = true;
                txtAdmin.Enabled = false;
                txtFinance.Enabled = false;
                txtIRO.Enabled = false;
                txtcoec.Enabled = false;
                txtRemarks.Enabled = true;
                txtMarketting.BackColor = System.Drawing.Color.Aqua;
            }
            if (lblDepId.Text == "2")
            {
                chkMarketting.Enabled = false;
                chkAdmin.Enabled = true;
                chkFinance.Enabled = false;
                chkIro.Enabled = false;
                txtMarketting.Enabled = false;
                txtAdmin.Enabled = true;
                txtFinance.Enabled = false;
                txtIRO.Enabled = false;
                txtcoec.Enabled = false;
                txtremarksadm.Enabled = true;
                txtAdmin.BackColor = System.Drawing.Color.Aqua;
            }
            if (lblDepId.Text == "3")
            {
                chkMarketting.Enabled = false;
                chkAdmin.Enabled = false;
                chkFinance.Enabled = true;
                chkIro.Enabled = false;
                txtMarketting.Enabled = false;
                txtAdmin.Enabled = false;
                txtFinance.Enabled = true;
                txtIRO.Enabled = false;
                txtcoec.Enabled = false;
                txtremarksfin.Enabled = true;
                txtFinance.BackColor = System.Drawing.Color.Aqua;
            }
            if (lblDepId.Text == "4")
            {
                chkMarketting.Enabled = false;
                chkAdmin.Enabled = false;
                chkFinance.Enabled = false;
                chkIro.Enabled = true;
                txtMarketting.Enabled = false;
                txtAdmin.Enabled = false;
                txtFinance.Enabled = false;
                txtIRO.Enabled = true;
                txtcoec.Enabled = false;
                txtremarksiro.Enabled = true;
                txtIRO.BackColor = System.Drawing.Color.Aqua;
            }


            if (lblDepId.Text == "5")
            {
                chkMarketting.Enabled = false;
                chkAdmin.Enabled = false;
                chkFinance.Enabled = false;
                chkIro.Enabled = true;
                txtMarketting.Enabled = false;
                txtAdmin.Enabled = false;
                txtFinance.Enabled = false;
                txtIRO.Enabled = false;
                txtcoec.Enabled = true;
                txtremarkscoec.Enabled = true;
                txtcoec.BackColor = System.Drawing.Color.Aqua;
            }

            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.GetCheckLIstValue(int.Parse(LinkId), int.Parse(lblId.Text));
            foreach (DataRow ro in dt.Rows)
            {
                chkMarketting.Checked = bool.Parse(ro["MktSubmitted"].ToString());
                chkAdmin.Checked = bool.Parse(ro["AdmSubmitted"].ToString());
                chkFinance.Checked = bool.Parse(ro["FInSubmitted"].ToString());
                chkIro.Checked = bool.Parse(ro["IroSubmitted"].ToString());
                txtMarketting.Text = ro["MktValue"].ToString();
                txtAdmin.Text = ro["AdmValue"].ToString();
                txtFinance.Text = ro["FinValue"].ToString();
                txtIRO.Text = ro["IroValue"].ToString();
                txtcoec.Text = ro["coecValue"].ToString();


                lblMrktCreatedBy.Text = ro["MrktCreatedBy"].ToString();
                lblAdmCreatedBy.Text = ro["AdmCreatedBy"].ToString();
                lblFinCreatedBy.Text = ro["FinCreatedBy"].ToString();
                lblIroCreatedBy.Text = ro["IroCreatedBy"].ToString();
                lblCOECCreatedBy.Text = ro["coecCreatedBy"].ToString();


              
                txtMArkettingDate.Value = ro["MCreatedDate"].ToString();
                txtAdminDate.Value = ro["ACreatedDate"].ToString();
                txtFinanceDate.Value = ro["FCreatedDate"].ToString();
                txtIRODate.Value = ro["ICreatedDate"].ToString();
                txtcoecDate.Value = ro["ICreatedDate"].ToString();

            }
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //DataTable objDataTable = new DataTable();
        //objDataTable.Columns.Add("");
        //objDataTable.Columns.Add("QID");
        //objDataTable.Columns.Add("Rating1");
        //objDataTable.Columns.Add("feed");
        //objDataTable.Columns.Add("eventinformed");
        //objDataTable.Columns.Add("eventknow");
        //objDataTable.Columns.Add("overallevent");
        //foreach (GridViewRow row in gvStudentList.Rows)
        //{

            //RadioButtonList rbl1 = (RadioButtonList)row.FindControl("rblFirstChoose");
            //string Qid = gvStudentList.DataKeys(row.RowIndex)(0).ToString();
            // objDataTable.Rows.Add(new string[] {rbl1.checked});
            //{
            //     Int16 i = objDataTable.Rows.Count;
            //     BulkCopy(objDataTable);
            // }
            //         }
            //     Public Sub BulkCopy(ByVal table As DataTable)
            //         SQLcon.Open()
            //         Using bc As New SqlBulkCopy(CType(SQLcon, SqlConnection))
            //             bc.DestinationTableName = "tb_DYNAMIC_Question_Answer_events"
            //             bc.WriteToServer(table)
            //             bc.Close()
            //         End Using
            //         SQLcon.Close()
            //     End Sub
        //}
    }
    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            int Count = s.IsMissedCall(int.Parse(Session["EmpId"].ToString()));
            if (Count > 0)
            {
                imgRequest.ImageUrl = "~/Icons/notifcation-message.png";
                lblCount.Visible = true;
                div1.Visible = true;
                lblCount.Text = Count.ToString();
            }
            else
            {
                imgRequest.ImageUrl = "~/Icons/notification-on.png";
                lblCount.Visible = false;
                div1.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrintOtherReport.aspx?A=" + Request.QueryString["Id"].ToString() + "&E=13", false);
    }

    protected void TimerTick(object sender, EventArgs e)
    {
        this.FillGridView();
        Timer1.Enabled = false;
        
    }
}