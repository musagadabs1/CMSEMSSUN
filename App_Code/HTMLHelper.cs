using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HTMLHelper
/// </summary>
public class HTMLHelper
{
    public static void jsAlertAndRedirect(System.Web.UI.Page instance, string Message, string url)
    {
        instance.Response.Write(@"<script language='javascript'>alert('" + Message + "');document.location.href='" + url + "'; </script>");
    }
}