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
        string EmpId;
       if (context.Request.QueryString["EmpId"] != null)
           EmpId = (context.Request.QueryString["EmpId"]).ToString();
       else
            throw new ArgumentException("No parameter specified");
       Stream strm = ShowImage(EmpId);
       byte[] buffer = new byte[4096];
       int byteSeq = strm.Read(buffer, 0, 4096);
 
       while (byteSeq > 0)
       {
           context.Response.OutputStream.Write(buffer, 0, byteSeq);
           byteSeq = strm.Read(buffer, 0, 4096);
       }       
       //context.Response.BinaryWrite(buffer);
    }

    public Stream ShowImage(string EmpId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
        string sql = "select EMPImage from View_Faculty_Online_Attendance where EMPID= @EmpId";
        SqlCommand cmd = new SqlCommand(sql,connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@EmpId", EmpId);
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