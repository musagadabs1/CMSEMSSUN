using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_OfferLetter : System.Web.UI.Page
{
    DataTable DT1 = new DataTable();
    System.Data.DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        rdbEmail.Focus();
        if (!IsPostBack)
        {
            //rdbName.Checked = true;
            rdbEmail.Checked = true;
            //gvStudentList.DataSource = "";
            //gvStudentList.DataBind();
            LoadDropdown();
        }
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //ddlCallerCategory.DataSource = s.SetDropdownListCDB(8);
        //ddlCallerCategory.DataTextField = "CCName";
        //ddlCallerCategory.DataValueField = "CCId";
        //ddlCallerCategory.DataBind();
    }
    private void FillGridView()
    {
        lblMesag.Text = "";
        try
        {
            string FilterBy = "All";
            if (rdbNumber.Checked == true)
                FilterBy = "Number";
            if (rdbEmail.Checked == true)
                FilterBy = "Email";
            if (rdbName.Checked == true)
                FilterBy = "Name";
            int NonRegistered = 0;
            if (chkNonRegister.Checked == true)
                NonRegistered = 1;
            string EmpId = "";
            EmpId = Session["EmpId"].ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
             dt = s.GetStudentDetails_Offer(FilterBy, txtFilterValue.Text, NonRegistered, EmpId);
            ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Fill Correct Information!";
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                CheckBox ChkApplicationReceived = (CheckBox)e.Row.FindControl("ChkApplicationReceived");
                CheckBox ChkMail = (CheckBox)e.Row.FindControl("ChkMail");
                RadioButton RadApproved = (RadioButton)e.Row.FindControl("RadApproved");
                RadioButton RadCancelled = (RadioButton)e.Row.FindControl("RadCancelled");
                RadioButton RadApprovedRadProcessing = (RadioButton)e.Row.FindControl("RadProcessing");
                DropDownList DDLTerm = (DropDownList)e.Row.FindControl("DDLTerm");
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                DDLTerm.DataSource = s.GetTerm();
                DDLTerm.DataTextField = "Term";
                DDLTerm.DataValueField = "TermID";
                DDLTerm.DataBind();
               
                try
                {
                    RadCancelled.Checked = false;
                    RadApproved.Checked = false;
                    RadApprovedRadProcessing.Checked  = false;
                    if (Convert.ToString(dt.Rows[e.Row.RowIndex]["ApplicationReceived"]) != "0")
                    {
                        ChkApplicationReceived.Checked = true ;
                    }
                    if (Convert.ToString(dt.Rows[e.Row.RowIndex]["MailSend"]) != "False")
                    {
                        ChkMail.Checked = true;
                    }
                    if (Convert.ToString(dt.Rows[e.Row.RowIndex]["ApplicationStatus"]) == "1")
                    {
                        RadApproved.Checked = true;
                    }
                    if (Convert.ToString(dt.Rows[e.Row.RowIndex]["ApplicationStatus"]) == "2")
                    {
                        RadCancelled.Checked = true;
                    }
                    if (Convert.ToString(dt.Rows[e.Row.RowIndex]["ApplicationStatus"]) == "3")
                    {
                        RadApprovedRadProcessing.Checked = true;
                    }
                     if (Convert.ToString(dt.Rows[e.Row.RowIndex]["Term"]) != "0")
                    {
                        DDLTerm.SelectedValue = Convert.ToString(dt.Rows[e.Row.RowIndex]["Term"]);
                    }

                }
                catch
                {
                }
            }
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      //  try
        //{
        //    if (e.CommandName.Equals("Modify"))
        //    {
        //        string Id = e.CommandArgument.ToString();
        //        //Response.Redirect(string.Format("StudentRegistration.aspx?Id={0}", Id), false);
        //        Response.Redirect(string.Format("NewRegistrant.aspx?Id=" + Id + "&Flag=" + chkNonRegister.Checked), false);
        //    }

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillGridView();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewRegistrant.aspx", false);
    }
    protected void gvStudentList_Sorted(object sender, EventArgs e)
    {
        try
        {
            string _expression = ViewState["_expression"].ToString();
            string _direction = ViewState["_direction"].ToString();

            System.Data.DataTable _ds = (System.Data.DataTable)ViewState["_ds_grid"];

            _ds.DefaultView.Sort = _expression + " " + _direction;

            gvStudentList.DataSource = _ds.DefaultView;
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvStudentList_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string _expression = e.SortExpression;
            string _direction = e.SortDirection.ToString();

            if (ViewState["_expression"] == null) { ViewState["_expression"] = ""; }
            if (ViewState["_direction"] == null) { ViewState["_direction"] = ""; }

            string _old_expression = ViewState["_expression"].ToString();
            string _old_direction = ViewState["_direction"].ToString();

            if (_expression == _old_expression)
            {
                if (_old_direction == "Asc")
                {
                    ViewState["_direction"] = "Desc";
                }
                else
                {
                    ViewState["_direction"] = "Asc";
                }
            }
            else
            {
                ViewState["_direction"] = "Asc";
                ViewState["_expression"] = _expression;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvStudentList_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvStudentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        gvStudentList.PageIndex = e.NewPageIndex;
        FillGridView();


    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        DT1.Columns.Add("ID");
        DT1.Columns.Add("LinkID");
        DT1.Columns.Add("ApplicationReceived");
        DT1.Columns.Add("Status");
        DT1.Columns.Add("CreatedBy");
        DT1.Columns.Add("Term");
        DT1.Columns.Add("Mail");
      
           
             int row_Count = gvStudentList.Rows.Count;
             int Status = 0;
             for (int i = 0; i < row_Count; i++)
             {
                 try
                 {
                     Label LblLinkID = (Label)gvStudentList.Rows[i].FindControl("LblLinkID");
                     Label LblID = (Label)gvStudentList.Rows[i].FindControl("LblID");
                     CheckBox ChkSave = (CheckBox)gvStudentList.Rows[i].FindControl("ChkSave");
                     CheckBox ChkApplicationReceived = (CheckBox)gvStudentList.Rows[i].FindControl("ChkApplicationReceived");
                     RadioButton RadApproved = (RadioButton)gvStudentList.Rows[i].FindControl("RadApproved");
                     RadioButton RadCancelled = (RadioButton)gvStudentList.Rows[i].FindControl("RadCancelled");
                     RadioButton RadApprovedRadProcessing = (RadioButton)gvStudentList.Rows[i].FindControl("RadProcessing");
                     DropDownList DDLTerm = (DropDownList)gvStudentList.Rows[i].FindControl("DDLTerm");
                     CheckBox ChkMail = (CheckBox)gvStudentList.Rows[i].FindControl("ChkMail");
                 

                     if (ChkSave.Checked == true)
                     {
                         DataRow dr = DT1.NewRow();
                         dr["ID"] = LblID.Text;
                         dr["LinkID"] = LblLinkID.Text;
                         if (RadApproved.Checked == true)
                         {
                             Status = 1;
                         }
                         if (RadCancelled.Checked == true)
                         {
                             Status = 2;
                         }
                         if (RadApprovedRadProcessing.Checked == true)
                         {
                             Status = 3;
                         }
                         dr["Status"] = Status;
                         dr["ApplicationReceived"] = ChkApplicationReceived.Checked ;
                         dr["CreatedBy"] = Convert.ToInt32(Session["EmpId"]);
                         dr["Term"] = DDLTerm.SelectedValue.ToString();
                         dr["Mail"] = ChkMail.Checked;
                         DT1.Rows.Add(dr);
                     }
                 }
                 catch (Exception Ex)
                 {
                 }
             }

            
        string Result="";
        if (DT1.Rows.Count > 0)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            Result = s.InsertOfferLetter(DT1);
            

        }
        if (Result != "RegisterNo")
        {
            Response.Write("<script>alert('Error-Please try again');</script>");
        }
        else
        {
            Response.Write("<script>alert('Successfully saved');</script>");
        }


        btnSearch_Click(sender, e);
    }
}