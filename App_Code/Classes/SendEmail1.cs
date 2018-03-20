using System;
using System.Net.Mail;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

/// <summary>
/// Summary description for SendEmail1
/// </summary>
public class SendEmail1
{
	public SendEmail1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool SendEmail(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
    {
        try
        {

          
                pGmailEmail="admissions@skylineuniversity.ac.ae";


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
    public static bool SendEmail11(string pGmailEmail, string pTo, string pSubject, string pBody, string cc, string pAttachmentPath)
    {
        try
        {
           
                pGmailEmail = "admissions@skylineuniversity.ac.ae";
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "86.96.198.37";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\admissions@skylineuniversity.ac.ae", "Mark205");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;


            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != "")
                mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);
            if (pAttachmentPath.Trim() != "")
            {
                try
                {
                    System.Web.Mail.MailAttachment MyAttachment = new System.Web.Mail.MailAttachment(pAttachmentPath);
                    //mail.Attachments.Add(MyAttachment);
                    //mail.Priority = System.Web.Mail.MailPriority.High;
                }
                catch
                {
                }
            }
            mail.Body = mailbody.ToString();
           // SmtpServer.Send(mail);
            return true;


        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public static bool SendBulkEmail(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
    {
        try
        {
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "192.168.167.3";
            //SmtpServer.Credentials = new NetworkCredential("192.168.167.3\\admissions", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
         
                pGmailEmail = "admissions@skylineuniversity.ac.ae";


            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\admissions@skylineuniversity.ac.ae", "Mark205");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;

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

    public static bool SendEmailwithAttach(string pGmailEmail, string pTo, string pSubject, string pBody, string cc, string[] attachment,int attlength)
    {
        try
        {

            pGmailEmail = "admissions@skylineuniversity.ac.ae";
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "86.96.198.37";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\admissions@skylineuniversity.ac.ae", "Mark205");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;


            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != "")
                mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);

            for (int i = 0; i < attlength; i++)
            {
                mail.Attachments.Add(new Attachment(attachment[i]));
            }



            //mail.Attachments.Add(new Attachment(bbaweekend));

            //mail.Priority = System.Web.Mail.MailPriority.High;



            mail.Body = mailbody.ToString();
           // SmtpServer.Send(mail);

            return true;


        }
        catch (Exception ex)
        {
            return false;
        }
    }



    public static bool SendEmailwithAttachCPD(string pGmailEmail, string pTo, string pSubject, string pBody, string cc, string[] attachment, int attlength)
    {
        try
        {

            pGmailEmail = "cpd@skylineuniversity.ac.ae";
            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "86.96.198.37";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\cpd@skylineuniversity.ac.ae", "Mark205");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;


            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != "")
                mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);

            for (int i = 0; i < attlength; i++)
            {
                mail.Attachments.Add(new Attachment(attachment[i]));
            }



            //mail.Attachments.Add(new Attachment(bbaweekend));

            //mail.Priority = System.Web.Mail.MailPriority.High;



            mail.Body = mailbody.ToString();
            //SmtpServer.Send(mail);

            return true;


        }
        catch (Exception ex)
        {
            return false;
        }
    }



}