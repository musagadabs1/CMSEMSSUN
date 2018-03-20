using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for Attendance
/// </summary>
public class Attendance
{
	public Attendance()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAttendance(string BatchCode, string Subject, DateTime TodayDate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@BatchCode", BatchCode);
        param[1] = new SqlParameter("@Subject", Subject);
        param[2] = new SqlParameter("@TodayDate", TodayDate);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAttendance]");
        return ds.Tables[0];
    }
    public DataTable GetBatchCode(int EmpId, string Subjects)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@EmpId", EmpId);
        param[1] = new SqlParameter("@Subjects", Subjects);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetBatchCode]");
        return ds.Tables[0];
    }
    public DataTable GetSubject(int EmpId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpId", EmpId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetSubject]");
        return ds.Tables[0];
    }
    public DataTable GetUserDetails(string UserName,string Password)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserName", UserName);
        param[1] = new SqlParameter("@Password", Password);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetUserDetails]");
        return ds.Tables[0];
    }
    public DataTable GetWeek(int EmpId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpId", EmpId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetWeek]");
        return ds.Tables[0];
    }
    public string InsertAttendance(string StudentId,string Session,bool IsPresent,string Week)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertAttendance", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            cmd.Parameters.AddWithValue("@SessionId", Session);
            cmd.Parameters.AddWithValue("@IsPresent", IsPresent);
            cmd.Parameters.AddWithValue("@Week", Week);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "Successfully Updated!!!";
        }
        catch
        {
            return "Please Try Again!!!";
        }
    }
    public DataTable GetLevel()
    {
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam("[GetLevels]");
        return ds.Tables[0];
    }
    public DataTable GetAllBatches(string Level,string Shift, string EmpId)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Level", Level);
        param[1] = new SqlParameter("@Timming", Shift);
        param[2] = new SqlParameter("@EmpId", EmpId);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAllBatches]");
        return ds.Tables[0];
    }
    public DataTable GetEmailId(string BatchCode)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@BatchCode", BatchCode);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[GetAllEmailId]");
        return ds.Tables[0];
    }
    public DataTable GetEnrollDates(int EmpId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpId", EmpId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_GetEnrollDates]");
        return ds.Tables[0];
    }

    //Added by Shihab on 05/08/2017

    public DataTable GetCommencementCalender(string Intaketype = "", int TermId = 0, int Degreetype = 0)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Intaketype", Intaketype);
        param[1] = new SqlParameter("@TermId", TermId);
        param[2] = new SqlParameter("@Degreetype", Degreetype);
        DataSet ds = da.getDataByParam(param, "[Sp_Get_CommencementCalender]");
        return ds.Tables[0];
    }

    public DataTable OrientationAttendence(int Id = 0, string Intaketype = "", int TermId = 0, int Degreetype = 0, int ShiftId = 0, string AttendenceDate = ""
                                            , int CreatedBy = 0, string Operation = "", DataTable Details = null)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@Intake", Intaketype);
        param[1] = new SqlParameter("@TermId", TermId);
        param[2] = new SqlParameter("@Degreetype", Degreetype);
        param[3] = new SqlParameter("@AttendenceDate", AttendenceDate);
        param[4] = new SqlParameter("@CreatedBy", CreatedBy);
        param[5] = new SqlParameter("@Operation", Operation);
        param[6] = new SqlParameter("@Details", Details);
        param[7] = new SqlParameter("@Id", Id);
        param[8] = new SqlParameter("@Shift_ID", ShiftId);
        DataSet ds = da.getDataByParam(param, "[Sp_OrientationAttendence]");
        return ds.Tables[0];
    }
}