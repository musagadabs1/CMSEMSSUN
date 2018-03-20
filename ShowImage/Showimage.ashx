<%@ WebHandler Language="C#" Class="Showimage" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
 
public class Showimage : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string LinkId;
        if (context.Request.QueryString["LinkId"] != null)
            LinkId = (context.Request.QueryString["LinkId"]).ToString();
       else
            throw new ArgumentException("No parameter specified");
        Stream strm = ShowImage(LinkId);
       byte[] buffer = new byte[4096];
       int byteSeq = strm.Read(buffer, 0, 4096);
 
       while (byteSeq > 0)
       {
           context.Response.OutputStream.Write(buffer, 0, byteSeq);
           byteSeq = strm.Read(buffer, 0, 4096);
       }       
       //context.Response.BinaryWrite(buffer);
    }

    public Stream ShowImage(string LinkId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
        string sql = "select Photo from tblContact where linkId = @LinkId";
        SqlCommand cmd = new SqlCommand(sql,connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@LinkId", LinkId);
        connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
        {
            connection.Close();
        }
    }
 
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
 
 
}