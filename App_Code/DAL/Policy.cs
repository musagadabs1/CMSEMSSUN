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

public class Policy
{
	public Policy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string InsertPolicySetup(string PolicyCode,string PolicyDesc,int AcademicSemester,bool IsActive,bool IsMandatory,int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertPolicySetup", conn);
            cmd.CommandType = CommandType.StoredProcedure;           
	        cmd.Parameters.AddWithValue("@PolicyCode", PolicyCode);
            cmd.Parameters.AddWithValue("@PolicyDesc", PolicyDesc);
            cmd.Parameters.AddWithValue("@AcademicSemester", AcademicSemester);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsMandatory", IsMandatory);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "RegisterNo";
        }
        catch
        {
            return "error";
        }
    }
    public string InsertPrerequisite(string PreReqCode,string PreReqDetails,string CourseCode,bool IsActive,int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertPrerequisiteMaster", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PreReqCode", PreReqCode);
            cmd.Parameters.AddWithValue("@PreReqDetails", PreReqDetails);
            cmd.Parameters.AddWithValue("@CourseCode", CourseCode);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "RegisterNo";
        }
        catch
        {
            return "error";
        }
    }
    public string InsertPolicyPrerequisite(string PolicyCode, string PrereqCode, string MinimumVal, string MaximumValue, int OrPolicyId, string MinSkillValue1, string MaxSkillValue1, string Skill1, string MinSkillValue2, string MaxSkillValue2,
        string Skill2, string MinSkillValue3, string MaxSkillValue3, string Skill3, string MinSkillValue4, string MaxSkillValue4, string Skill14, bool UnderTakingDetails, string UnderTakingDocument, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertPolicy", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PolicyCode", PolicyCode);
            cmd.Parameters.AddWithValue("@PrereqCode", PrereqCode);
            cmd.Parameters.AddWithValue("@MinimumVal", MinimumVal);
            cmd.Parameters.AddWithValue("@MaximumValue", MaximumValue);
            cmd.Parameters.AddWithValue("@OrPolicyId", OrPolicyId);
            cmd.Parameters.AddWithValue("@MinSkillValue1", MinSkillValue1);
            cmd.Parameters.AddWithValue("@MaxSkillValue1", MaxSkillValue1);
            cmd.Parameters.AddWithValue("@Skill1", Skill1);
            cmd.Parameters.AddWithValue("@MinSkillValue2", MinSkillValue2);
            cmd.Parameters.AddWithValue("@MaxSkillValue2", MaxSkillValue2);
            cmd.Parameters.AddWithValue("@Skill2", Skill2);
            cmd.Parameters.AddWithValue("@MinSkillValue3", MinSkillValue3);
            cmd.Parameters.AddWithValue("@MaxSkillValue3", MaxSkillValue3);
            cmd.Parameters.AddWithValue("@Skill3", Skill3);
            cmd.Parameters.AddWithValue("@MinSkillValue4", MinSkillValue4);
            cmd.Parameters.AddWithValue("@MaxSkillValue4", MaxSkillValue4);
            cmd.Parameters.AddWithValue("@Skill14", Skill14);
            cmd.Parameters.AddWithValue("@UnderTakingDetails", UnderTakingDetails);
            cmd.Parameters.AddWithValue("@UnderTakingDocument", UnderTakingDocument);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "RegisterNo";
        }
        catch
        {
            return "error";
        }
    }
    //Newly Added

    public string InsertPolicyMaster(int Flag, int Id, int FormName, int Program, int FormType,string MinValue, string MaxValue, int AcademicYear, bool IsActive, bool IsFinance, int Feegroup, string Remarks, bool Activated, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertPolicyMaster", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", Flag);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@FormName", FormName);
            cmd.Parameters.AddWithValue("@Program", Program);
            cmd.Parameters.AddWithValue("@FormType", FormType);
            cmd.Parameters.AddWithValue("@MinValue", MinValue);
            cmd.Parameters.AddWithValue("@MaxValue", MaxValue);
            cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsFinance", IsFinance);
            cmd.Parameters.AddWithValue("@Feegroup", Feegroup);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Activated", Activated);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "Sucess";
        }
        catch
        {
            return "error";
        }
    }
    public DataTable SetPolicy(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetPolicy]");
        return ds.Tables[0];
    }
}