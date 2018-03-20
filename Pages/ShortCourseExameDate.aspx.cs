using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_ShortCourseExameDate : System.Web.UI.Page
{
    string value = "";
    protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack)
         {
             if ((Session["EMPID"].ToString() == "11049") || (Session["EMPID"].ToString() == "69") || (Session["EMPID"].ToString() == "225"))

            {
             
             StudentRegistrationDAL s = new StudentRegistrationDAL();
             lblMesag.Text = "";
             //rbtIlets.Checked = true;
             drpentrancetesttype.DataSource = s.SetDropdownListCDB(107);
             drpentrancetesttype.DataTextField = "TestType";
             drpentrancetesttype.DataValueField = "code";
             drpentrancetesttype.DataBind();



             bindgrid();
             btnUpdate.Visible = false;
             btnAdd.Visible = true;
            }
            else

            {Response.Redirect("login.aspx");

            }
         }
     }
    protected void btnAdd_Click1(object sender, EventArgs e)
     {
         try
         {
            value=drpentrancetesttype.SelectedValue;
                    
             StudentRegistrationDAL a = new StudentRegistrationDAL();
             if (txtExamDate.Text == "")
             {
                 lblMesag.Text = "Entrance Date Required!";
                 lblMesag.ForeColor = System.Drawing.Color.Red;
                 return;
             }

             string Result = a.InsertCourseExam(txtExamDate.Text, txtEngExFrom.Text, txtEngExTo0.Text, txtMathExFrom.Text, txtMathExTo.Text, value, chk.Checked);
             if (Result == "EntranceDate")
             {
                 lblMesag.Text = "Successfully Added!";
                 lblMesag.ForeColor = System.Drawing.Color.Blue;
                 txtExamDate.Text = "";
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
        gvStudentList.DataSource = s.GetExamDate();
        gvStudentList.DataBind();
    }
    protected void changStatus(object sender, EventArgs e)
    {
        if (chk.Checked)
        { 
        
        }
    }
    public void abc()
    { 
    
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       try
       {
           StudentRegistrationDAL c = new StudentRegistrationDAL();

            drpentrancetesttype.DataSource = c.SetDropdownListCDB(107);
            drpentrancetesttype.DataTextField = "TestType";
            drpentrancetesttype.DataValueField = "code";
            drpentrancetesttype.DataBind();

            if (e.CommandName.Equals("Details"))
            {
               
                txthdn_Field.Text = e.CommandArgument.ToString();
                
                DataTable dt = c.SetExamDate(Convert.ToInt32(txthdn_Field.Text));
                foreach (DataRow ro in dt.Rows)
                {
                    //drpentrancetesttype.SelectedValue = ro["Type"].ToString();
                    //txthdn_Field.Text = ro["EntranceID"].ToString();
                    //txtEngExFrom.Text = ro["ENGFrom"].ToString();
                    //txtEngExTo0.Text = ro["ENGTo"].ToString();
                    //txtMathExFrom.Text = ro["MATFrom"].ToString();
                    //txtMathExTo.Text = ro["MATTo"].ToString();
                    //txtExamDate.Text = (DateTime.Parse(ro["EntranceDate"].ToString())).Day + "/" + (DateTime.Parse(ro["EntranceDate"].ToString())).Month + "/" + (DateTime.Parse(ro["EntranceDate"].ToString())).Year;
                    //btnUpdate.Visible = true;
                    //btnAdd.Visible = false;

                    drpentrancetesttype.SelectedValue = ro["Type"].ToString().Trim();
                    txthdn_Field.Text = ro["EntranceID"].ToString();
                    txtEngExFrom.Text = ro["ENGFrom"].ToString();
                    txtEngExTo0.Text = ro["ENGTo"].ToString();
                    txtMathExFrom.Text = ro["MATFrom"].ToString();
                    txtMathExTo.Text = ro["MATTo"].ToString();
                    txtExamDate.Text = (DateTime.Parse(ro["EntranceDate"].ToString())).Day + "/" + (DateTime.Parse(ro["EntranceDate"].ToString())).Month + "/" + (DateTime.Parse(ro["EntranceDate"].ToString())).Year;
                    chk.Checked = bool.Parse(ro["isactive"].ToString());
                    btnUpdate.Visible = true;
                    btnAdd.Visible = false;


                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
            LinkButton lblName = (LinkButton)e.Row.FindControl("lblName");
            lblName.Text = (DateTime.Parse(lblName.Text)).ToString("dd/MM/yyyy");
        }
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            value = drpentrancetesttype.SelectedValue;
            if (txtExamDate.Text == "")
            {
                lblMesag.Text = "Entrance Date Required!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = s.UpdateCourseExam(Convert.ToInt32(txthdn_Field.Text), txtExamDate.Text, txtEngExFrom.Text, txtEngExTo0.Text, txtMathExFrom.Text, txtMathExTo.Text, value, chk.Checked);
            
            txtExamDate.Text = "";
            txtEngExFrom.Text = "";
            txtEngExTo0.Text = "";
            txtMathExFrom.Text = "";
            txtMathExTo.Text = "";
            btnUpdate.Visible = false;
            btnAdd.Visible = true; ;
            bindgrid();


            if (Result == "EntranceDate")
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
        catch
        {
            lblMesag.Text = "Please Try Again!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
 
  
    protected void drpentrancetesttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpentrancetesttype.SelectedValue == "P")
        {
            txtMathExFrom.Enabled = false;
            txtMathExTo.Enabled = false;
        }
        else
        {
            txtMathExFrom.Enabled = true;
            txtMathExTo.Enabled = true;
        }
        if (drpentrancetesttype.SelectedValue == "C")
        {
            txtMathExFrom.Enabled = false;
            txtMathExTo.Enabled = false;
        }
        else
        {
            txtMathExFrom.Enabled = true;
            txtMathExTo.Enabled = true;
        }

        if (drpentrancetesttype.SelectedValue != "I")
        {
            txtMathExFrom.Enabled = false;
            txtMathExTo.Enabled = false;
        }
        else
        {
            txtMathExFrom.Enabled = true;
            txtMathExTo.Enabled = true;
        }


        if (drpentrancetesttype.SelectedValue!="T")
        {
            txtMathExFrom.Enabled = false;
            txtMathExTo.Enabled = false;
        }
        else
        {
            txtMathExFrom.Enabled = true;
            txtMathExTo.Enabled = true;
        }

    }
}

