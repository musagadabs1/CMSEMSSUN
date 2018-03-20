using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;

/// <summary>
/// Summary description for alertmessage
/// </summary>
public class alertmessage
{
	
    public static void Show(string message)
    {
       
        string cleanMessage = message.Replace("'", "\\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
               
        Page page = HttpContext.Current.CurrentHandler as Page;
               
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(alertmessage), "alert", script);
        }
    }    
}
