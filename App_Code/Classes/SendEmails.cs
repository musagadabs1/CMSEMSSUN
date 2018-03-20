using System;
using System.Net.Mail;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

/// <summary>
/// Summary description for SendEmails
/// </summary>
public class SendEmails
{
    public SendEmails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static bool SendEmail(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
    {
        try
        {


          
                pGmailEmail = "admissions@skylineuniversity.ac.ae";
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\admissions@skylineuniversity.ac.ae", "Mark205");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "86.96.198.37";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions@skylineuniversity.ac.ae", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != "")
                mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);

            mail.Body = mailbody.ToString();
          // SmtpServer.Send(mail);
            return true;


        }
        catch (Exception ex)
        {
            throw;
        }
    }
   
    public static bool SendEmail2(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
    {
        try
        {
            
                pGmailEmail = "admissions@skylineuniversity.ac.ae";
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\admissions@skylineuniversity.ac.ae", "Mark205");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;

            //SmtpServer.Port = 25;
            //SmtpServer.Host = "86.96.198.37";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions@skylineuniversity.ac.ae", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;


            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != "")
                mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);

            mail.Body = mailbody.ToString();
           // SmtpServer.Send(mail);
            return true;


        }
        catch (Exception ex)
        {
            return false;
        }
    }
}