using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;

using System.Text;


public partial class Pages_Airticket : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }

        if ((Session["EMPID"].ToString() == "1636") || (Session["EMPID"].ToString() == "918"))
        {

            if (!IsPostBack)
            {
                try
                {

                    StudentRegistrationDAL s = new StudentRegistrationDAL();
                    LoadNationality();
                    Clear();
                    bindgrid();
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                    hdnviewreport.NavigateUrl = "PrintOtherReport.aspx?E=40&id=" + ddlNationality.SelectedValue;                   
                }
                catch
                {
                    Response.Redirect("Login.aspx", false);
                }

            }
        }

        else
        {
            Response.Redirect("login.aspx");

        }

    }
    public void LoadNationality()
    {
        ddlNationality.DataSource = s.SetDropdownListCDB(117);
        ddlNationality.DataTextField = "NationalityName";
        ddlNationality.DataValueField = "Id";
        ddlNationality.DataBind();
    }
    public void Clear()
    {
        txthdn_Id.Text = "";
      
        ddlNationality.SelectedIndex = 0;
        //ddlState.SelectedIndex = 0;
        Txtmax.Text = "0";
        Txtmin.Text = "0";
        txtRemarks.Text = "";
        txtamount.Text = "0";
        Txtfromdate.Text="";
            TxtTodate.Text="";
        lblMesag.Text = "";
    }

    public void bindgrid()
    {

        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvStudentList.DataSource = s.GetAirticketDetails(0, "SELECTALL");
        gvStudentList.DataBind();
    }
   
    protected void btnAdd_Click1(object sender, EventArgs e)
    {

        if (ddlNationality.SelectedValue == "0")
        {
            lblMesag.Text = "Select Nationality";
            return;
        }

        if (Txtmin.Text == "")
        {

         Txtmin.Text = "0";
        }

        if (Txtmax.Text == "")
        {

            Txtmax.Text = "0";
        }
        if (Txtmin.Text == "0")
        {
            lblMesag.Text = "Select MinNo";
            return;
        }
        if (Txtmax.Text == "0")
        {
            lblMesag.Text = "Select MaxNo";
            return;
        }

        if ( txtamount.Text == "0")
        {
            lblMesag.Text = "Select Amount";
            return;
        }
        int Result1 = s.InsertUpdateAirticketDetails(0, int.Parse(ddlNationality.SelectedValue), "AED", double.Parse(txtamount.Text), Txtfromdate.Text, TxtTodate.Text, int.Parse(Txtmin.Text), int.Parse(Txtmax.Text),
             txtRemarks.Text, Convert.ToInt32(Session["EmpId"].ToString()), "Checkdt");
        if (Result1<=0)
       
        {

            lblMesag.Text = "Fromdate should be less than Todate ";
            return;
        }

        if (int.Parse(Txtmin.Text) > int.Parse(Txtmax.Text))
        {
            lblMesag.Text = "Minimim Number should leass than or equal to Maximum Number";
            return;
        }

        int Result = s.InsertUpdateAirticketDetails(0, int.Parse(ddlNationality.SelectedValue), "AED", double.Parse(txtamount.Text), Txtfromdate.Text, TxtTodate.Text, int.Parse(Txtmin.Text), int.Parse(Txtmax.Text),
              txtRemarks.Text, Convert.ToInt32(Session["EmpId"].ToString()), "Insert");
       
       


        if (Result > 0)
        {
            lblMesag.Text = "Successfully Added!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
           
            btnUpdate.Visible = false;
            btnAdd.Visible = true; ;
            bindgrid();
        }
        else if (Result ==-1) 
        


            {
            lblMesag.Text = "Already Inserted!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblMesag.Text = "Please Try Again!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void btnUpdate_Click1(object sender, EventArgs e)
    {


        if (ddlNationality.SelectedValue == "0")
        {
            lblMesag.Text = "Select Nationality";
            return;
        }

        if (Txtmin.Text == "")
        {

            Txtmin.Text = "0";
        }

        if (Txtmax.Text == "")
        {

            Txtmax.Text = "0";
        }
        if (Txtmin.Text == "0")
        {
            lblMesag.Text = "Select MinNo";
            return;
        }
        if (Txtmax.Text == "0")
        {
            lblMesag.Text = "Select MaxNo";
            return;
        }

        if (txtamount.Text == "0")
        {
            lblMesag.Text = "Select Amount";
            return;
        }
        int Result1 = s.InsertUpdateAirticketDetails(0, int.Parse(ddlNationality.SelectedValue), "AED", double.Parse(txtamount.Text), Txtfromdate.Text, TxtTodate.Text, int.Parse(Txtmin.Text), int.Parse(Txtmax.Text),
             txtRemarks.Text, Convert.ToInt32(Session["EmpId"].ToString()), "Checkdt");
        if (Result1 == 0)
        {

            lblMesag.Text = "Fromdate should be less than Todate ";
            return;
        }

        if (int.Parse(Txtmin.Text) > int.Parse(Txtmax.Text))
        {
            lblMesag.Text = "Minimim Number should leass than or equal to Maximum Number";
            return;
        }



        int AirId = Convert.ToInt32(txthdn_Id.Text);
       
      int Result = s.InsertUpdateAirticketDetails(AirId, int.Parse(ddlNationality.SelectedValue), "AED", double.Parse(txtamount.Text), Txtfromdate.Text, TxtTodate.Text, int.Parse(Txtmin.Text), int.Parse(Txtmax.Text),
            txtRemarks.Text, Convert.ToInt32(Session["EmpId"].ToString()), "Update");
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
                DataTable dt = c.GetAirticketDetails(Id, "SELECT");
                foreach (DataRow ro in dt.Rows)
                {

                    ddlNationality.SelectedValue = ro["nationalityid"].ToString();
                    txtamount.Text = ro["amount"].ToString();
                    Txtfromdate.Text = ro["fromdate"].ToString();
                    Txtmin.Text = ro["minno"].ToString();
                    Txtmax.Text = ro["maxno"].ToString();
                    TxtTodate.Text = ro["todate"].ToString();
                    txtRemarks.Text = ro["remarks"].ToString();
                    txthdn_Id.Text = ro["airid"].ToString();
                    lblMesag.Text = "";
                    btnUpdate.Visible = true;
                    btnAdd.Visible = false;
                }
            }

            if (e.CommandName.Equals("DeleteDetails"))
            {

                int Id = Convert.ToInt32(e.CommandArgument);
                StudentRegistrationDAL c = new StudentRegistrationDAL();
                DataTable dt = c.GetAirticketDetails(Id, "Delete");
               lblMesag.Text = "Deleted Succssfully";
               bindgrid();
               Clear();


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

    protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnviewreport.NavigateUrl = "PrintOtherReport.aspx?E=40&id=" + ddlNationality.SelectedValue; 
    }
}