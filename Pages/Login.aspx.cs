using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUserName.Focus();
            Session.Clear();
            Session.Abandon();
        }
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        try
        {
            Attendance a = new Attendance();
            DataTable dt = a.GetUserDetails(txtUserName.Text, txtPassword.Text);
            if (dt.Rows.Count == 0)
            {
                lblMesag.Text = "Username or Password incorrect!";
                //lblMesag.Text = "Under Maintenance";
            }
            else
            {
                foreach (DataRow ro in dt.Rows)
                {
                    Session["Name"]      = ro["Name"].ToString();
                    Session["EMPID"]     = ro["EmpId"].ToString();
                    Session["DepId"]     = ro["DEPTID"].ToString();
                    Session["GroupName"] = ro["GroupName"].ToString();
                    Session["Emailid"] = ro["Emailid"].ToString();
                    Session["EmpId"]= ro["EmpId"].ToString();
                    Session["schoolcode"] = ro["schoolcode"].ToString();
                } 
                Response.Redirect("Default.aspx", false);
            }
        }
        catch
        {
            lblMesag.Text = "Username or Password incorrect!";
        }
    }
}