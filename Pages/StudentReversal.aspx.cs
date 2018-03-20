using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

public partial class Pages_StudentReversal : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtCallDate.Text = (DateTime.Now).ToString();

                if (int.Parse(Session["EMPID"].ToString()) != 918)
                {
                    lblMesag.Text = "ACCESS DENIED";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnl1.Visible = false;
                    return;
                }
                else
                {
                    if (Request.QueryString["Id"].ToString() == null)
                    {
                        Response.Redirect("login.aspx", false);
                    }

                    else
                        pnl1.Visible = true;
                }
            
            }
               
            catch
            {
                Response.Redirect("login.aspx", false);

            }

        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
               try
        {
            int id=int.Parse(Request.QueryString["Id"].ToString());
            StudentRegistrationDAL s = new StudentRegistrationDAL();
             DataTable res=s.InsertStudentreversal(id,txtRemarks.Text, int.Parse(Session["EMPID"].ToString()));

             if (res.Rows[0][0].ToString() == "1".ToString())
             {
                 lblMesag.Text = "Succesfully Reversed!!! Kindly Go to Registration Process again";
                 lblMesag.ForeColor = System.Drawing.Color.Blue;
             }
             else
                 lblMesag.Text = "Contact IT Department ";


        }

        catch
        {

        }

    }

}