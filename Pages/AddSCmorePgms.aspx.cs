using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Pages_AddSCmorePgms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(43, 1);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();

            ddlTerm.Items.Clear();
            ddlTerm.DataSource = s.SetDropdownListCDB(600);
            ddlTerm.DataTextField = "Term";
            ddlTerm.DataValueField = "TermID";
            ddlTerm.DataBind();


            ddlDegreeType.SelectedIndex = 1;
            ddlDegreeType_SelectedIndexChanged(sender, e);

            ddlDiscountType.DataSource = s.SetDropdownListCDB(96);
            ddlDiscountType.DataTextField = "FeeWaiverType";
            ddlDiscountType.DataValueField = "Id";
            ddlDiscountType.DataBind();

            ddlType.DataSource = s.SetDropdownListCDB(95);
            ddlType.DataTextField = "FeeWaiverType";
            ddlType.DataValueField = "Id";
            ddlType.DataBind();


            try
            {
                ddlPercentage.Items.Clear();
                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                if (ddlType.SelectedValue != "134")
                {
                    ddlPercentage.Items.Add(new ListItem("5", "5"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                }
            }
            catch
            {
            }
            bindgrid();
            ProgramRegular();
           // 
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblProgramMesag.Text = "";
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetDropdownListAsDegreeType(24, int.Parse(ddlType.SelectedValue));
            ddlDiscountType.DataSource = dt;
            ddlDiscountType.DataTextField = "Description";
            ddlDiscountType.DataValueField = "id";
            ddlDiscountType.DataBind();
            //txtFees.Text = (s.GetBudget(int.Parse(ddlType.SelectedValue))).ToString("0.00");
            
                         ddlPercentage.Items.Clear();
                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                if (ddlType.SelectedValue != "134")
                {
                    ddlPercentage.Items.Add(new ListItem("5", "5"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                }
           
            
        }
        catch
        {
        }
    }

    protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            try
            {

               
                if (ddlType.SelectedValue != "134")
                {
                    DataTable dt = s.SetDropdownListAsDegreeTypeperc(int.Parse(ddlTerm.SelectedValue), int.Parse(ddlCourseType.SelectedValue));
                    ddlPercentage.DataSource = dt;
                    ddlPercentage.DataTextField = "Description";
                    ddlPercentage.DataValueField = "id";
                    ddlPercentage.DataBind();
                }
                   
                
            }
            catch
            {
                ddlPercentage.Items.Clear();
                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                if (ddlType.SelectedValue != "134")
                {
                    ddlPercentage.Items.Add(new ListItem("5", "5"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                }

            }

            ddlPercentage_SelectedIndexChanged(sender, e);


          
        }
        catch
        {
        }
    }



    protected void ddlPercentage_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        try
        {

            DataTable dt = s.GetMouFund(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue), double.Parse(ddlPercentage.SelectedValue));
            try
            {
                txtFees.Text = dt.Rows[0][0].ToString();

                if (txtFees.Text == "0")
                    txtFees.Text = "0";
            }
            catch
            {
                txtFees.Text = "0";
            }
           
          
            try
            {
               
                txtDiscount.Text = ((decimal.Parse(txtTotalFees.Text) * decimal.Parse(ddlPercentage.SelectedValue)) / 100).ToString();
                if (txtDiscount.Text == "")
                    txtDiscount.Text = "0";
            }
            catch
            {
                txtDiscount.Text = "0";
               lblMesag.Text = "Fee Waiver is not assigned Please select other Option!";
                return;

            }

            txtNetFees.Text = (decimal.Parse(txtTotalFees.Text) - decimal.Parse(txtDiscount.Text)).ToString();
        }
        catch
        {
        }


      
    }




    protected void btnSaveProgrammore_Click(object sender, EventArgs e)
    {
        btnSaveProgrammore.Enabled = true;
       
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        if (ddlCourseType.SelectedValue == "0")
        {
            lblProgramMesag.Text = "Course Required!!!";
            return;
        }
        try
        {
            string Program = "Weekend";
            if (rdbProgramRegular.Checked == true)
                Program = "Week Day";
            DateTime dtFromDate;
            DateTime dtToDate;
            try
            {
                dtFromDate = DateTime.Parse(txtSCFromYear.Text + "/" + txtSCFromMonth.Text + "/" + txtSCFromDay.Text);
            }
            catch
            {
                lblProgramMesag.Text = "Date Required!!!";
                return;
            }
            try
            {
                dtToDate = DateTime.Parse(txtSCToYear.Text + "/" + txtSCToMonth.Text + "/" + txtSCToDay.Text);
            }
            catch
            {
                lblProgramMesag.Text = "Date Required!!!";
                return;
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();

           DataTable  Result = d.InsertProgrammoreSC(LinkId, Program, ddlDegreeType.SelectedValue, ddlCourseType.SelectedValue, ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlPercentage.SelectedValue.ToString(), ddlDiscountType.SelectedValue.ToString(), double.Parse(txtTotalFees.Text), double.Parse(txtNetFees.Text),int.Parse(Session["EmpId"].ToString() ));

            if (int.Parse(Result.Rows[0][0].ToString())>0 )
            {
               
                lblProgramMesag.Text = "Successfully Updated!!!";
                clear();
               
                try
                {
                    InsertFeeGroup(int.Parse(Result.Rows[0][0].ToString()));
                    bindgrid();

                }
                catch
                {
                    lblProgramMesag.Text = "Please Try Again!!!";
                }
            }
            else
            {
                lblProgramMesag.Text = "Please Try Again!!!";
            }
            ;
        }
        catch
        {
            lblProgramMesag.Text = "Please Try Again!!!";
        }
    }
    public void clear()
    {
        txtTotalFees.Text = "0";
        txtNetFees.Text = "0";
        txtDiscount.Text = "";
        ddlType.SelectedIndex = -1;
        ddlDiscountType.SelectedIndex = -1;
        ddlCourseType.SelectedIndex = -1;

    
    }
    public void bindgrid()
    {
        lblMesag.Text = "";
         

        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //gvStudentList.DataSource = s.Getmorescdetails(0, "SELECTALL");
        //gvStudentList.DataBind();

        gvStudentList.DataSource = s.Getmorescdetails(int.Parse(Request.QueryString["Id"].ToString()), "SELECTALL");
        gvStudentList.DataBind();

        gvAddedFeeGroup.DataSource = s.GetFeesItems(0, int.Parse(Request.QueryString["Id"].ToString()));
        gvAddedFeeGroup.DataBind();
        try
        {
            DataTable tt = s.Getmorescdetails(int.Parse(Request.QueryString["Id"].ToString()), "Get");
            lblreg.Text = tt.Rows[0][0].ToString();
        }
        catch
        {
            Response.Redirect("Login.aspx", false);
        }


    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvStudentList.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("EditDetails"))
            {

                int Id = Convert.ToInt32(e.CommandArgument);
                StudentRegistrationDAL c = new StudentRegistrationDAL();
                SetPrograms(Id);
            }

            if (e.CommandName.Equals("DeleteDetails"))
            {

                int Id = Convert.ToInt32(e.CommandArgument);
                StudentRegistrationDAL c = new StudentRegistrationDAL();
                DataTable dt = c.Getmorescdetails(Id, "Delete");
                lblProgramMesag.Text = "Deleted Succssfully";
                bindgrid();

              

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

    public void InsertFeeGroup(int id)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //s.InsertAddedFeeGroup(Request.QueryString["Id"].ToString(), FeeGroupId, TypeId);
        s.InsertFeeGroupSCmore(Request.QueryString["Id"].ToString(), "StudentRegistration.aspx",id);
        gvAddedFeeGroup.DataSource = s.GetFeesItems(0, int.Parse(Request.QueryString["Id"].ToString()));
        gvAddedFeeGroup.DataBind();
       
    }
    public void LoadCourse()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(110, int.Parse(ddlDegreeType.SelectedValue));
            ddlCourseType.DataTextField = "Description";
            ddlCourseType.DataValueField = "Id";
            ddlCourseType.DataBind();

            //ddlDiscountType.DataSource = s.SetDropdownListAsDegreeType(2, int.Parse(ddlDegreeType.SelectedValue));
            //ddlDiscountType.DataTextField = "FeeWaiverType";
            //ddlDiscountType.DataValueField = "Id";
            //ddlDiscountType.DataBind();

          
        }
        catch
        {
        }
    }

    public void ProgramWekends()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (rdbProgramWeekend.Checked == true)
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 1);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(43, 2);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
        }
        else
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 2);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlShift.SelectedValue = "1";
            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(43, 1);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
        }
    }
    public void ProgramRegular()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (rdbProgramWeekend.Checked == true)
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 1);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(43, 2);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
        }
        else
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 2);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlShift.SelectedValue = "1";
            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(43, 1);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
        }
    }

    public void SetPrograms( int id)
    {

        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        try
        {
            dt = s.SetProgramSC(id);

        }
        catch
        {

        }
        try
        {
            foreach (DataRow ro in dt.Tables[1].Rows)
            {
                ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
                LoadCourse();
                ddlCourseType.SelectedValue = ro["CourseType"].ToString();
            }
        }
        catch
        {
        }
        foreach (DataRow ro in dt.Tables[0].Rows)
        {
            if (ro["ProgramType"].ToString() == "Weekend")
            {
                rdbProgramWeekend.Checked = true;
                rdbProgramRegular.Checked = false;
                ProgramWekends();
            }
            else
            {
                rdbProgramWeekend.Checked = false;
                rdbProgramRegular.Checked = true;
                ProgramRegular();
            }
            ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
            LoadCourse();
            ddlCourseType.SelectedValue = ro["CourseType"].ToString();

            try
            {
                ddlTerm.SelectedValue = ro["Term"].ToString();
            }
            catch
            {
                ddlTerm.Items.Clear();
                ddlTerm.DataSource = s.SetDropdownListCDB(6);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();
                ddlTerm.SelectedValue = ro["Term"].ToString();
            }

            ddlShift.SelectedValue = ro["Shift"].ToString();
            txtSCFromYear.Text = (DateTime.Parse(ro["ShortFromDate"].ToString())).Year.ToString();
            txtSCFromMonth.Text = (DateTime.Parse(ro["ShortFromDate"].ToString())).Month.ToString();
            txtSCFromDay.Text = (DateTime.Parse(ro["ShortFromDate"].ToString())).Day.ToString();
            txtSCToYear.Text = (DateTime.Parse(ro["ShortToDate"].ToString())).Year.ToString();
            txtSCToMonth.Text = (DateTime.Parse(ro["ShortToDate"].ToString())).Month.ToString();
            txtSCToDay.Text = (DateTime.Parse(ro["ShortToDate"].ToString())).Day.ToString();

           


        }
        try
        {
            foreach (DataRow ro in dt.Tables[2].Rows)
            {
                //ddlListening.SelectedItem.Text = ro["Listening"].ToString();
                //ddlReading.SelectedItem.Text = ro["Reading"].ToString();
                //ddlWriting.SelectedItem.Text = ro["Writing"].ToString();
                //ddlSpeaking.SelectedItem.Text = ro["Speaking"].ToString();
                 txtTotalFees.Text= ro["fees"].ToString();
                 txtNetFees.Text = ro["netfees"].ToString();
                txtDiscount.Text = ro["discount"].ToString();

                try
                {
                    ddlDiscountType.DataSource = s.SetDropdownListCDB(96);
                    ddlDiscountType.DataTextField = "FeeWaiverType";
                    ddlDiscountType.DataValueField = "Id";
                    ddlDiscountType.DataBind();

                }
                catch
                {
                    ddlType.DataSource = s.SetDropdownListCDB(95);
                    ddlType.DataTextField = "FeeWaiverType";
                    ddlType.DataValueField = "Id";
                    ddlType.DataBind();
                }


                try
                {
                    ddlPercentage.Items.Clear();
                    ddlPercentage.Items.Add(new ListItem("Select", "0"));
                    if (ddlType.SelectedValue != "134")
                    {
                        ddlPercentage.Items.Add(new ListItem("5", "5"));
                        ddlPercentage.Items.Add(new ListItem("10", "10"));
                        ddlPercentage.Items.Add(new ListItem("15", "15"));
                    }
                }
                catch
                {
                }


                ddlDiscountType.SelectedValue = ro["cat"].ToString();
                ddlPercentage.SelectedValue = ro["percentage"].ToString();
                if (ro["percentage"].ToString() == "0")
                {
                    ddlType.SelectedIndex = 2;
                }
                else
                {
                    ddlType.SelectedIndex = 1;

                }

            }

        }
        catch
        {
        }
       
      

    }

    protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            ddlType.SelectedIndex = -1;
            ddlDiscountType.SelectedIndex = -1;
            ddlPercentage.SelectedIndex = -1;
            string Course = ddlCourseType.SelectedItem.Text;
            try
            {
                StudentRegistrationDAL ss = new StudentRegistrationDAL();

                 DataTable schoolcode=new DataTable();
                schoolcode=ss.Getmorescdetails(int.Parse(Request.QueryString["Id"].ToString()), "SCODE");


                DataTable dt = new DataTable();
              
                    dt = ss.GetFinalFees(int.Parse(ddlCourseType.SelectedValue), ddlTerm.SelectedValue,schoolcode.Rows[0][0].ToString());
                txtTotalFees.Text = (dt.Rows[0][0].ToString()).ToString();
                txtDiscount.Text = "0";
                txtNetFees.Text = "0";
            }
            catch
            {
            }
         
        }
        catch
        {
        }
    }
    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMesag.Text = "";
        LoadCourse();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
       
                 ddlTerm.Items.Clear();
                ddlTerm.DataSource = s.SetDropdownListCDB(100);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();
                ddlTerm.Enabled = true;
            
      
       
    }


    decimal Total = 0;
    protected void gvAddedFeeGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Total = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            if (lblAmount.Text != "")
            {
                Total = Total + decimal.Parse(lblAmount.Text);
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFooterUName = (Label)e.Row.FindControl("lblFooterUNamea");
            lblFooterUName.Text = Total.ToString();
        }
    }

    protected void rdbProgramRegular_CheckedChanged(object sender, EventArgs e)
    {
        ProgramRegular();
    }
    protected void rdbProgramWeekend_CheckedChanged(object sender, EventArgs e)
    {
        ProgramWekends();
    }
    protected void btnfinalise_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Student_Id = "";
            DataTable tt = s.Getmorescdetails(int.Parse(Request.QueryString["Id"].ToString()), "Regno");
            Student_Id = tt.Rows[0][0].ToString();
            s.InsertFeeGroupSCmoreDebits(Student_Id);
            lblProgramMesag.Text = "Debited Successfully";
        }
        catch
        {
            lblProgramMesag.Text = "Try again ";
        }

    }
}