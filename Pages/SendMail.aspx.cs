using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using com.vectramind.mobile;
using System.Data;


public partial class Pages_SendMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Focus();
            //BindListBox();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        // for email
        try
        {
           
            Attendance a = new Attendance();
            SendEmsil s = new SendEmsil();
            DataTable dt = (System.Data.DataTable)Session["dtBatch"];
            DataTable dtEmail = new DataTable();
            string Batch = "";
            string ToEmail = "";
            foreach (DataRow ro in dt.Rows)
            {
                Batch = ro["Batch"].ToString();
                try
                {
                    dtEmail = a.GetEmailId(Batch);
                    foreach (DataRow ron in dtEmail.Rows)
                    {
                        ToEmail = ron["EmailId"].ToString();
                        SendEmsil.SendEmail(txtFrom.Text, txtPassword.Text, ToEmail, "Message From Skyline", txtMessage.Text, System.Web.Mail.MailFormat.Text, "");
                    }
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
           
        }

        //for sms

        //string result;
        //string senderusername = "dpsshj";
        //string senderpassword = "dp55h1";
        //string senderid = "dpsshj";
        //com.vectramind.mobile.Service sms = new Service();
        //result = sms.SendTextMessage(senderusername, senderpassword, "Hi", 0, senderid, "971528474173", 0);        
    }  
}