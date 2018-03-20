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
using System.Net.NetworkInformation;

/// <summary>
/// Summary description for StudentRegistrationDAL
/// </summary>
public class StudentRegistrationDAL
{
	public StudentRegistrationDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static int GetScope(string schedule_Course, string Faculty, int month)
    {

        try
        {

            Int32 newCPDID = 0;
            string sql = " Insert into tbl_crseandwrkshpdetmaster(course,fname,monthid) values " +
                        "  (@corse,@fname,@month);" +
                        "  SELECT CAST(scope_identity() AS int)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@corse", schedule_Course);
            cmd.Parameters.Add("@fname", Faculty);
            cmd.Parameters.Add("@month", Convert.ToInt16(month));
            newCPDID = (Int32)cmd.ExecuteScalar();
            return (int)newCPDID;

        }
        catch (Exception e)
        {
            return 0;
        }
    }
    public static int insertcourseandworkshopdetails(int result, string Courseshed, string facname, string Gyear, string Gmonth, string course, string exm, string responsible, string batch, string noofsessions, string day, string coursefee, string classtime, string target, string sms, string email, string aud, string enteredby, string entereddate)
    {
        int newPreCourseID;
        try
        {
            string sql = "Insert into tbl_crseandwrkshpdetails(result, Shed_course, Fac_Name, Getyear, Getmonth,course,exmdetails,responsibilty,batch,noofsessions,days,coursefee,classtimngs,target,sms,email,aud,Entered_by,Entered_date) values " +
                "  (@reslt, @Shedcourse, @Fac_Name, @Getyear, @Getmonth,@crse,@exmdet,@resp,@btch,@noofsess,@days,@crsefee,@classtmngs,@target,@sms,@email,@aud,@Enteredby,@entereddate);" +
                "  SELECT CAST(scope_identity() AS int)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@reslt", result);
            cmd.Parameters.Add("@Shedcourse", Courseshed);
            cmd.Parameters.Add("@Fac_Name", facname);
            cmd.Parameters.Add("@Getyear", Gyear);
            cmd.Parameters.Add("@Getmonth", Gmonth);
            cmd.Parameters.Add("@crse", course);
            cmd.Parameters.Add("@exmdet", exm);
            cmd.Parameters.Add("@resp", responsible);
            cmd.Parameters.Add("@btch", batch);
            cmd.Parameters.Add("@noofsess", noofsessions);
            cmd.Parameters.Add("@days", day);
            cmd.Parameters.Add("@crsefee", coursefee);
            cmd.Parameters.Add("@classtmngs", classtime);
            cmd.Parameters.Add("@target", target);
            cmd.Parameters.Add("@sms", sms);
            cmd.Parameters.Add("@email", email);
            cmd.Parameters.Add("@aud", aud);
            cmd.Parameters.Add("@Enteredby", enteredby);
            cmd.Parameters.Add("@entereddate", entereddate);
            newPreCourseID = (Int32)cmd.ExecuteScalar();
            return (int)newPreCourseID;

        }
        catch (Exception e)
        {
            return 0;
        }
    }    
    public DataTable viewmonth()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("[sp_viemonth]");
        return ds.Tables[0];
    }    
    public static int getId(string schedName, string faculty, string fromdate, string Todate)
    {

        try
        {

            Int32 newCPDID = 0;
            string sql = " Insert into tbl_courseplaner_main(shed_name,fac_name,From_date,To_date) values " +
               "  (@Schedule,@faculty_id,@fromdate,@todate);" +
               "  SELECT CAST(scope_identity() AS int)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Schedule", schedName);
            cmd.Parameters.Add("@faculty_id", faculty);
            cmd.Parameters.Add("@fromdate", Convert.ToString(fromdate));
            cmd.Parameters.Add("@todate", Convert.ToString(Todate));
            newCPDID = (Int32)cmd.ExecuteScalar();
            return (int)newCPDID;

        }
        catch (Exception e)
        {
            return 0;
        }
    }
    public static int Insert_course_fileplanner(int planId, string schedule_Course, string Faculty, string content, string Operational, string Academic, string Transportation, string fromdate, string Todate, string enteredby, string entereddate, string Weekplan)
    {
        try
        {

            Int32 newCPDID = 0;
            string sql = "  Insert into tbl_Course_file_planner(plan_id, course_shed,Faculty_name,Content,Operational,Academic,Transportation,Fromdate,Todate, Entered_by, Entered_date,WeekPlan) values " +
                         "  (@planid, @Schedule,@faculty_id,@Content,@Operational, @Academic,@Transportation,@Fromdate,@Todate,@enteredby,@entereddate,@Weekplan);" +
                         "  SELECT CAST(scope_identity() AS int)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@planid", planId);
            cmd.Parameters.Add("@Schedule", schedule_Course);
            cmd.Parameters.Add("@faculty_id", Faculty);
            //cmd.Parameters.Add("@Dayplan", Dayplan );
            cmd.Parameters.Add("@Content", content);
            cmd.Parameters.Add("@Operational", Operational);
            cmd.Parameters.Add("@Academic", Academic);
            cmd.Parameters.Add("@Transportation", Transportation);
            cmd.Parameters.Add("@Fromdate", fromdate);
            cmd.Parameters.Add("@Todate", Todate);
            cmd.Parameters.Add("@enteredby", enteredby);
            cmd.Parameters.Add("@entereddate", entereddate);
            cmd.Parameters.Add("@Weekplan", Weekplan);
            newCPDID = (Int32)cmd.ExecuteScalar();
            return (int)newCPDID;

        }
        catch (Exception e)
        {
            return 0;
        }
    }
    public static int GetScopeIdentity(string schedule_Course, string Faculty, string target, string noachived, string enteredby, string entereddate)
    {
        try
        {
            Int32 newCPDID = 0;
            string sql = " Insert into tbl_cdb_main_master(Schedule_course,Faculty_id,Target_No,No_achieved,Entered_by,Entered_date) values " +
               "  (@Schedule,@faculty_id,@target_no,@NoAchived,@Entered_by,@Entered_date );" +
               "  SELECT CAST(scope_identity() AS int)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Schedule", schedule_Course);
            cmd.Parameters.Add("@faculty_id", Faculty);
            cmd.Parameters.Add("@target_no", Convert.ToInt16(target));
            cmd.Parameters.Add("@NoAchived", Convert.ToInt16(noachived));
            cmd.Parameters.Add("@Entered_by", enteredby);
            cmd.Parameters.Add("@Entered_date", entereddate);
            newCPDID = (Int32)cmd.ExecuteScalar();
            return (int)newCPDID;

        }
        catch (Exception e)
        {
            return 0;
        }
    }
    public static int insert_precourse_details(int cpdid, string course_shed, string facName, string activity, string status, string response, string e_Type, string target, string noachived, string enteredby, string entereddate, int type_value)
    {

        int newPreCourseID;
        try
        {
            string sql = " Insert into tbl_Pre_course_details(cpd_id,course_schedule,faculty_name,activities,status,responsibility,Entered_type,no_target,no_aciv,enteredby,entered_date, type_value) values " +
                "  (@cpdid,@CourseShed,@facName,@activity,@status,@response,@Entered_type,@target_no,@NoAchived,@Entered_by,@Entered_date,@type_value);" +
                "  SELECT CAST(scope_identity() AS int)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cpdid", cpdid);
            cmd.Parameters.Add("@CourseShed", course_shed);
            cmd.Parameters.Add("@facName", facName);
            cmd.Parameters.Add("@activity", activity);
            cmd.Parameters.Add("@status", status);
            cmd.Parameters.Add("@response", response);
            cmd.Parameters.Add("@Entered_type", e_Type);
            cmd.Parameters.Add("@target_no", Convert.ToInt16(target));
            cmd.Parameters.Add("@NoAchived", Convert.ToInt16(noachived));
            cmd.Parameters.Add("@Entered_by", enteredby);
            cmd.Parameters.Add("@Entered_date", entereddate);
            cmd.Parameters.Add("@type_value", type_value);
            newPreCourseID = (Int32)cmd.ExecuteScalar();
            return (int)newPreCourseID;

        }
        catch (Exception e)
        {
            return 0;
        }
    }  
    public DataTable GetCpdCourseDetails(string CourseName, string FacultyId, int Type)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Sched_course", CourseName);
            param[1] = new SqlParameter("@Faculty_id", FacultyId);
            param[2] = new SqlParameter("@ddl_type", Type);
            // param[3] = new SqlParameter("@EmpId", EmpId);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[sp_cpd_course_details]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }




    public string InsertStudentDetails(int LinkId,string RegNo, DateTime CallDate,int Gender, int Title, string FirstName,
        string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
        string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
        string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
        string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
        string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion, string IsInternationalStudent, string forwardtype, bool aptitude)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Linkid", LinkId);
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            cmd.Parameters.AddWithValue("@CallDate", CallDate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@ArabicFirstName", ArabicFisrtName);
            cmd.Parameters.AddWithValue("@ArabicMiddleName", ArabicMiddleName);
            cmd.Parameters.AddWithValue("@ArabicLastName", ArabicLastName);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@FormStatus", FormStatus);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@Comment", Comment);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ProspectStatus", ProspectStatus);
            cmd.Parameters.AddWithValue("@RefferedBy", RefferedBy);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", Email);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@PoBox", PoBox);
            cmd.Parameters.AddWithValue("@ArabNonArab", ArabNonArab);
            cmd.Parameters.AddWithValue("@ISEmployeed", ISEmployeed);
            cmd.Parameters.AddWithValue("@SchoolUniversity", SchoolUniversity);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@CallerCategory", CallerCategory);
            cmd.Parameters.AddWithValue("@MotherTongue", MotherTounge);
            cmd.Parameters.AddWithValue("@ProficiencyInEnglish", ProficiencyInEnglish);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@IsInternationalStudent", IsInternationalStudent);
            cmd.Parameters.AddWithValue("@forwardtype", forwardtype);
            cmd.Parameters.AddWithValue("@aptitude", aptitude);
            cmd.Parameters.AddWithValue("@ip", GetMacAddress());
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "RegisterNo";
        }
        catch(Exception ex)
        {
            return "";
        }
    }
    public string UpdateStudentDetails(int Id, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
        string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
        string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
        string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
        string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
        string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion, string IsInternationalStudent, string forwardtype, bool aptitude)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            cmd.Parameters.AddWithValue("@CallDate", CallDate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@ArabicFirstName", ArabicFisrtName);
            cmd.Parameters.AddWithValue("@ArabicMiddleName", ArabicMiddleName);
            cmd.Parameters.AddWithValue("@ArabicLastName", ArabicLastName);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@FormStatus", FormStatus);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@Comment", Comment);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ProspectStatus", ProspectStatus);
            cmd.Parameters.AddWithValue("@RefferedBy", RefferedBy);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", Email);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@PoBox", PoBox);
            cmd.Parameters.AddWithValue("@ArabNonArab", ArabNonArab);
            cmd.Parameters.AddWithValue("@ISEmployeed", ISEmployeed);
            cmd.Parameters.AddWithValue("@SchoolUniversity", SchoolUniversity);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@CallerCategory", CallerCategory);
            cmd.Parameters.AddWithValue("@MotherTongue", MotherTounge);
            cmd.Parameters.AddWithValue("@ProficiencyInEnglish", ProficiencyInEnglish);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@IsInternationalStudent", IsInternationalStudent);
            cmd.Parameters.AddWithValue("@forward", forwardtype);
            cmd.Parameters.AddWithValue("@aptitude", aptitude);
            cmd.Parameters.AddWithValue("@ip", GetMacAddress());
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
    public string UpdateStudentDetailsMyCall(int Id, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
        string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
        string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
        string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
        string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
        string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion, string IsInternationalStudent)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateStudentMyCall", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            cmd.Parameters.AddWithValue("@CallDate", CallDate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@ArabicFirstName", ArabicFisrtName);
            cmd.Parameters.AddWithValue("@ArabicMiddleName", ArabicMiddleName);
            cmd.Parameters.AddWithValue("@ArabicLastName", ArabicLastName);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@FormStatus", FormStatus);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@Comment", Comment);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ProspectStatus", ProspectStatus);
            cmd.Parameters.AddWithValue("@RefferedBy", RefferedBy);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", Email);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@PoBox", PoBox);
            cmd.Parameters.AddWithValue("@ArabNonArab", ArabNonArab);
            cmd.Parameters.AddWithValue("@ISEmployeed", ISEmployeed);
            cmd.Parameters.AddWithValue("@SchoolUniversity", SchoolUniversity);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@CallerCategory", CallerCategory);
            cmd.Parameters.AddWithValue("@MotherTongue", MotherTounge);
            cmd.Parameters.AddWithValue("@ProficiencyInEnglish", ProficiencyInEnglish);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@IsInternationalStudent", IsInternationalStudent);
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

    public string InsertInSkyErp(string RegId, string RegNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
           // SqlCommand cmd = new SqlCommand("Insert Into students_login (login_id,password,student_id,studenttype) values (@login_id,@password,@student_id,@studenttype)", conn);
            SqlCommand cmd = new SqlCommand("ProcInsertLogindetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@login_id", RegId);
            cmd.Parameters.AddWithValue("@password", RegId);
            cmd.Parameters.AddWithValue("@student_id", RegNo);
            cmd.Parameters.AddWithValue("@studenttype", "T");
            cmd.Parameters.AddWithValue("@ip", GetMacAddress());
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
    public string InsertInFocus(string RegId, string StudentName)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Focus"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into tb_student (StudentName,RegisterId,posted) values (@StudentName,@RegisterId,@posted)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@StudentName", StudentName);
            cmd.Parameters.AddWithValue("@RegisterId", RegId);
            cmd.Parameters.AddWithValue("@posted", "0");
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
    public string DeleteStudentDetails(int Id)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcDeleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
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
    public DataTable GetStudentDetails(string FilterBy, string FilterValue, int Type, string EmpId,string schoolcode)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@schoolcode", schoolcode);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcGetStudent]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }

    public DataTable GetStudentDetailsAptitude(string linkid, string examtype)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@linkid", linkid);
            param[1] = new SqlParameter("@examtype", examtype);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcGetStudentapptitude1]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }
    public DataTable GetStudentDetailsAptitudeResult(string FilterBy, string FilterValue, int Type, string EmpId, string FromDate, string ToDate, string examtype, int pageno, int pagerow)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@FromDate", FromDate);
            param[5] = new SqlParameter("@ToDate", ToDate);
            param[6] = new SqlParameter("@examtype", examtype);
            param[7] = new SqlParameter("@iPageNo", pageno);
            param[8] = new SqlParameter("@iPageRecords", pagerow);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcGetStudentapptitudeStudents1]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }

    public DataTable GetStudentDetailsAptitudeResultcount(string FilterBy, string FilterValue, int Type, string EmpId, string FromDate, string ToDate, string examtype, int pageno, int pagerow)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@FromDate", FromDate);
            param[5] = new SqlParameter("@ToDate", ToDate);
            param[6] = new SqlParameter("@examtype", examtype);
            param[7] = new SqlParameter("@iPageNo", pageno);
            param[8] = new SqlParameter("@iPageRecords", pagerow);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcGetStudentapptitudeStudents1Count]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }



    public string ActivateAptitude(int LinkId, int status, int createdBy,string createdip)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_ActivateAptitude", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@linkid", LinkId);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@createdBy", createdBy);
            cmd.Parameters.AddWithValue("@createdIp", createdip);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "1";
        }
        catch
        {
            return "error";
        }
    }



    public DataTable GetStudentDetailsCHECKLIST(string FilterBy, string FilterValue, int Type, string EmpId, string schoolcode)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@schoolcode", schoolcode);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcGetStudentCHECKLIST]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }

    public DataTable GetExistingStudentDetails(string FilterBy, string FilterValue, int Type, string EmpId, int pageno, int pagerow)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@iPageNo", pageno);
            param[5] = new SqlParameter("@iPageRecords", pagerow);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcExistingGetStudent1]");
            return ds.Tables[0];
        }
        catch
        { return null; }
    }

    public DataTable GetExistingStudentDetails11(string FilterBy, string FilterValue, int Type, string EmpId, int pageno, int pagerow,string schoolcode)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@iPageNo", pageno);
            param[5] = new SqlParameter("@iPageRecords", pagerow);
            param[6] = new SqlParameter("@schoolcode", pagerow);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcExistingGetStudent1]");
            return ds.Tables[0];
        }
        catch
        {
            return null;
        }
    }

    public DataTable GetStudentDetailsAptitudecount(string FilterBy, string FilterValue, int Type, string EmpId, string FromDate, string ToDate, string examtype, int pageno, int pagerow)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@FromDate", FromDate);
            param[5] = new SqlParameter("@ToDate", ToDate);
            param[6] = new SqlParameter("@examtype", examtype);
            param[7] = new SqlParameter("@iPageNo", pageno);
            param[8] = new SqlParameter("@iPageRecords", pagerow);

            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcGetStudentapptitudegetcount]");
            return ds.Tables[0];
        }
        catch
        {
            return null;
        }
    }

    public DataTable Getrecordcount(string FilterBy, string FilterValue, int Type, string EmpId, int pageno, int pagerow,string schoolcode)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@EmpId", EmpId);
            param[4] = new SqlParameter("@iPageNo", pageno);
            param[5] = new SqlParameter("@iPageRecords", pagerow);
            param[6] = new SqlParameter("@schoolcode", schoolcode);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[ProcExistinggetcountrecord]");
            return ds.Tables[0];
        }
        catch
        {
            return null;
        }
    }

    public DataTable GetStudentDetails2(string FilterBy, string FilterValue, int Type, string EmpId, string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@Type", Type);
        param[3] = new SqlParameter("@EmpId", EmpId);
        param[4] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetStudent2]");
        return ds.Tables[0];
    }
    public DataTable GetStudentDetails1(string FilterBy, string FilterValue, string EmpId,string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@EmpId", EmpId);
        param[3] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetStudent1]");
        return ds.Tables[0];
    }
    public DataTable GetFollowUpDetails(string FilterBy, string FilterValue, string EmpId,string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@EmpId", EmpId);
        param[3] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetFollowUpList]");
        return ds.Tables[0];
    }
    public DataTable GetForwardedHistory(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetForwardedHistory]");
        return ds.Tables[0];
    }
    public DataTable GetFollowUpDetails1(string FilterBy, string FilterValue, string EmpId, string FromDate, string ToDate, int pageno, int pagerow,string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@EmpId", EmpId);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@iPageNo", pageno);
        param[6] = new SqlParameter("@iPageRecords", pagerow);
        param[7] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetFollowUpListGetIntialRow]");
        return ds.Tables[0];
    }



    public DataTable GetFollowUpDetails2(string FilterBy, string FilterValue, string EmpId, string FromDate, string ToDate, int pageno, int pagerow,string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@EmpId", EmpId);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@iPageNo", pageno);
        param[6] = new SqlParameter("@iPageRecords", pagerow);
        param[7] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetFollowUpList2closedcall]");
        return ds.Tables[0];
    }


    public DataTable SetStudentDetails(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetStudent]");
        return ds.Tables[0];
    }

    public DataTable SetStudentDetailsother(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetStudent_other]");
        return ds.Tables[0];
    }

    public DataTable SetStudentMycallDetails(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetStudententrance]");
        return ds.Tables[0];
    }
    public DataTable SetRegStudentDetails(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetRegStudent]");
        return ds.Tables[0];
    }
    public DataTable SetStudentDetails1(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetStudent1]");
        return ds.Tables[0];
    }
    public DataTable BindGrid(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetStudentDetailsgv]");
        return ds.Tables[0];
    }
    public DataTable BindGridAll(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetStudentDetailsgvAll]");
        return ds.Tables[0];
    }
    public string InsertContact(string LinkId, string PresentCity, string PresentStreet, string PresentAdd1, string PresentAdd2, string PostBoxNo, string Country, string Emirates,
        string PlaceOfBirth, string Nation, string PhoneRes, string PhoneOff, string Mobile, string Email, string FaxNo, string MaritalStatus,string PermanentCity,string PermanentStreet,
        string PermanentCountry, string PermanentAdd1, string PermanentAdd2, byte[] Photo, string StudentType)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertContact", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@PresentCity", PresentCity);
            cmd.Parameters.AddWithValue("@PresentStreet", PresentStreet);
            cmd.Parameters.AddWithValue("@PresentAdd1", PresentAdd1);
            cmd.Parameters.AddWithValue("@PresentAdd2", PresentAdd2);
            cmd.Parameters.AddWithValue("@PostBoxNo", PostBoxNo);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Emirates", Emirates);
            cmd.Parameters.AddWithValue("@PlaceOfBirth", PlaceOfBirth);
            cmd.Parameters.AddWithValue("@Nation", Nation);
            cmd.Parameters.AddWithValue("@PhoneRes", PhoneRes);
            cmd.Parameters.AddWithValue("@PhoneOff", PhoneOff);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@FaxNo", FaxNo);
            cmd.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
            cmd.Parameters.AddWithValue("@PermanentCity", PermanentCity);
            cmd.Parameters.AddWithValue("@PermanentStreet", PermanentStreet);
            cmd.Parameters.AddWithValue("@PermanentCountry", PermanentCountry);
            cmd.Parameters.AddWithValue("@PermanentAdd1", PermanentAdd1);
            cmd.Parameters.AddWithValue("@PermanentAdd2", PermanentAdd2);
            cmd.Parameters.AddWithValue("@Photo", Photo);
            cmd.Parameters.AddWithValue("@StudentType", StudentType);
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
    public DataTable GetLinkId(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetLinkId]");
        return ds.Tables[0];
    }

    // New Changed Starts Here
    public string InsertParents(string LinkId,string GName,string RelationShip,string Profession,string Organization,string Email,string Mobile,string ResPhone,string OffPhone,
        string Address,string Website,string PName,string PRelationShip,string PProfession,string POrganization,string PEmail,string PMobile,string PResPhone,string POffPhone,
        string PAddress,string PWebsite)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertParents", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@GName", GName);
            cmd.Parameters.AddWithValue("@RelationShip", RelationShip);
            cmd.Parameters.AddWithValue("@Profession", Profession);
            cmd.Parameters.AddWithValue("@Organization", Organization);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@ResPhone", ResPhone);
            cmd.Parameters.AddWithValue("@OffPhone", OffPhone);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@PName", PName);
            cmd.Parameters.AddWithValue("@PRelationShip", PRelationShip);
            cmd.Parameters.AddWithValue("@PProfession", PProfession);
            cmd.Parameters.AddWithValue("@POrganization", POrganization);
            cmd.Parameters.AddWithValue("@PEmail", PEmail);
            cmd.Parameters.AddWithValue("@PMobile", PMobile);
            cmd.Parameters.AddWithValue("@PResPhone", PResPhone);
            cmd.Parameters.AddWithValue("@POffPhone", POffPhone);
            cmd.Parameters.AddWithValue("@PAddress", PAddress);
            cmd.Parameters.AddWithValue("@PWebsite", PWebsite);
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
    public string InsertVisa(string LinkId,bool IsSkylineVisa, bool VisaLetter, string StudentStatus,string VisaType,DateTime VisaExpireOn,bool UrgentVisaRequired,string FatherName,string AbroadMobileNo,
            string AbroadResNo,string MotherName,string PlaceOfBirthCity,string Country,string PlaceOfBirthPlace,string MaritialStatus,string PortOfLastEntry,string PrevNationality,
            DateTime DateOfLastEntry,string Religion,string SpokenLanguage,string NativeLanguage,string Address1,string Address2,string POBOX,string OfficeAddress,string City,
            string State,string Emirates,string Nationality,string GuardianPassportNo,string PassportValidity,string VisaStatus,string NationalIdCardNo,string IdCardFileName,
            string VisaPage,string VisaPageFileName,string TenancyContact,string TenancyFileName,string VisaNo,string SponsorName)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertVisa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@IsSkylineVisa", IsSkylineVisa);
            cmd.Parameters.AddWithValue("@VisaLetter", VisaLetter);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@VisaType", VisaType);
            cmd.Parameters.AddWithValue("@VisaExpireOn", VisaExpireOn);
            cmd.Parameters.AddWithValue("@UrgentVisaRequired", UrgentVisaRequired);
            cmd.Parameters.AddWithValue("@FatherName", FatherName);
            cmd.Parameters.AddWithValue("@AbroadMobileNo", AbroadMobileNo);
            cmd.Parameters.AddWithValue("@AbroadResNo", AbroadResNo);
            cmd.Parameters.AddWithValue("@MotherName", MotherName);
            cmd.Parameters.AddWithValue("@PlaceOfBirthCity", PlaceOfBirthCity);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@PlaceOfBirthPlace", PlaceOfBirthPlace);
            cmd.Parameters.AddWithValue("@MaritialStatus", MaritialStatus);
            cmd.Parameters.AddWithValue("@PortOfLastEntry", PortOfLastEntry);
            cmd.Parameters.AddWithValue("@PrevNationality", PrevNationality);
            cmd.Parameters.AddWithValue("@DateOfLastEntry", DateOfLastEntry);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@SpokenLanguage", SpokenLanguage);
            cmd.Parameters.AddWithValue("@NativeLanguage", NativeLanguage);
            cmd.Parameters.AddWithValue("@Address1", Address1);
            cmd.Parameters.AddWithValue("@Address2", Address2);
            cmd.Parameters.AddWithValue("@POBOX", POBOX);
            cmd.Parameters.AddWithValue("@OfficeAddress", OfficeAddress);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Emirates", Emirates);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@GuardianPassportNo", GuardianPassportNo);
            cmd.Parameters.AddWithValue("@PassportValidity", PassportValidity);
            cmd.Parameters.AddWithValue("@VisaStatus", VisaStatus);
            cmd.Parameters.AddWithValue("@NationalIdCardNo", NationalIdCardNo);
            cmd.Parameters.AddWithValue("@IdCardFileName", IdCardFileName);
            cmd.Parameters.AddWithValue("@VisaPage", VisaPage);
            cmd.Parameters.AddWithValue("@VisaPageFileName", VisaPageFileName);
            cmd.Parameters.AddWithValue("@TenancyContact", TenancyContact);
            cmd.Parameters.AddWithValue("@TenancyFileName", TenancyFileName);
            cmd.Parameters.AddWithValue("@VisaNo", VisaNo);
            cmd.Parameters.AddWithValue("@SponsorName", SponsorName);
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
    public string InsertQualification(string LinkId, string Qualification, string Specilization, string UniversityName, string BoardName, string City, string Country,
        string YearOfPass, string Percentage, string IsBusiness, string BusinessCourse, bool IsCertificate, decimal CGPA, string Subject, bool Approval, string Remarks, string FileName, bool IsMilitary)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertQualification1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@Specilization", Specilization);
            cmd.Parameters.AddWithValue("@UniversityName", UniversityName);
            cmd.Parameters.AddWithValue("@BoardName", BoardName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@YearOfPass", YearOfPass);
            cmd.Parameters.AddWithValue("@Percentage", Percentage);
            cmd.Parameters.AddWithValue("@IsBusiness", IsBusiness);
            cmd.Parameters.AddWithValue("@BusinessCourse", BusinessCourse);
            cmd.Parameters.AddWithValue("@IsCertificate", IsCertificate);
            cmd.Parameters.AddWithValue("@CGPA", CGPA);
            cmd.Parameters.AddWithValue("@Subject", Subject);
            cmd.Parameters.AddWithValue("@Approval", Approval);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@Ismilitary", IsMilitary);
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
    public string UpdateQualification(string Id, string Qualification, string Specilization, string UniversityName, string BoardName, string City, string Country,
        string YearOfPass, string Percentage, string IsBusiness, string BusinessCourse, bool IsCertificate, decimal CGPA, string Subject, bool Approval, string Remarks, string FileName, bool IsMilitary)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateQualification1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@Specilization", Specilization);
            cmd.Parameters.AddWithValue("@UniversityName", UniversityName);
            cmd.Parameters.AddWithValue("@BoardName", BoardName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@YearOfPass", YearOfPass);
            cmd.Parameters.AddWithValue("@Percentage", Percentage);
            cmd.Parameters.AddWithValue("@IsBusiness", IsBusiness);
            cmd.Parameters.AddWithValue("@BusinessCourse", BusinessCourse);
            cmd.Parameters.AddWithValue("@IsCertificate", IsCertificate);
            cmd.Parameters.AddWithValue("@CGPA", CGPA);
            cmd.Parameters.AddWithValue("@Subject", Subject);
            cmd.Parameters.AddWithValue("@Approval", Approval);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@Ismilitary", IsMilitary);
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
    public string InsertExperience(string LinkId,bool IsWorkExperience,string Organization,string Designation,string Location,string City,string JobSector,string JobType,
        string JobProfile,string FromMonth,string FromDate,string ToMonth,string ToDate)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertExperience", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@IsWorkExperience", IsWorkExperience);
            cmd.Parameters.AddWithValue("@Organization", Organization);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Location", Location);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@JobSector", JobSector);
            cmd.Parameters.AddWithValue("@JobType", JobType);
            cmd.Parameters.AddWithValue("@JobProfile", JobProfile);
            cmd.Parameters.AddWithValue("@FromMonth", FromMonth);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToMonth", ToMonth);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
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
    public string UpdateExperience(string Id, bool IsWorkExperience, string Organization, string Designation, string Location, string City, string JobSector, string JobType,
        string JobProfile, string FromMonth, string FromDate, string ToMonth, string ToDate)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateExperience", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@IsWorkExperience", IsWorkExperience);
            cmd.Parameters.AddWithValue("@Organization", Organization);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Location", Location);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@JobSector", JobSector);
            cmd.Parameters.AddWithValue("@JobType", JobType);
            cmd.Parameters.AddWithValue("@JobProfile", JobProfile);
            cmd.Parameters.AddWithValue("@FromMonth", FromMonth);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToMonth", ToMonth);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
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
    public string InsertVisaInfo(string LinkId, string DocumentType, string TypeOfVisa, string Sponsor, string CardNo, string PlaceOfIssue, DateTime DateOfIssue, DateTime DateOfExpiry, string CountryOfIssue, string FileName)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertVisaInfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("DocumentType", DocumentType);
            cmd.Parameters.AddWithValue("TypeOfVisa", TypeOfVisa);
            cmd.Parameters.AddWithValue("Sponsor", Sponsor);
            cmd.Parameters.AddWithValue("CardNo", CardNo);
            cmd.Parameters.AddWithValue("PlaceOfIssue", PlaceOfIssue);
            cmd.Parameters.AddWithValue("DateOfIssue", DateOfIssue);
            cmd.Parameters.AddWithValue("DateOfExpiry", DateOfExpiry);
            cmd.Parameters.AddWithValue("CountryOfIssue", CountryOfIssue);
            cmd.Parameters.AddWithValue("FileName", FileName);
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
    public string UpdateVisaInfo(string Id, string DocumentType, string TypeOfVisa, string Sponsor, string CardNo, string PlaceOfIssue, DateTime DateOfIssue, DateTime DateOfExpiry, string CountryOfIssue, string FileName)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateVisaInfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("DocumentType", DocumentType);
            cmd.Parameters.AddWithValue("TypeOfVisa", TypeOfVisa);
            cmd.Parameters.AddWithValue("Sponsor", Sponsor);
            cmd.Parameters.AddWithValue("CardNo", CardNo);
            cmd.Parameters.AddWithValue("PlaceOfIssue", PlaceOfIssue);
            cmd.Parameters.AddWithValue("DateOfIssue", DateOfIssue);
            cmd.Parameters.AddWithValue("DateOfExpiry", DateOfExpiry);
            cmd.Parameters.AddWithValue("CountryOfIssue", CountryOfIssue);
            cmd.Parameters.AddWithValue("FileName", FileName);
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
    public string InsertFitness(string LinkId, bool IsDisablity, string Disablity, bool IsChronicDisease, string ChronicDeasease, bool IsPoliceClearance, string PoliceClearance,
        bool IsMedicalCertificate, string MedicalCertificate, string MedicalCertificateFileName, bool Visual, bool Learning, bool Difficulty)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertFitness", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@IsDisablity", IsDisablity);
            cmd.Parameters.AddWithValue("@Disablity", Disablity);
            cmd.Parameters.AddWithValue("@IsChronicDisease", IsChronicDisease);
            cmd.Parameters.AddWithValue("@ChronicDeasease", ChronicDeasease);
            cmd.Parameters.AddWithValue("@IsPoliceClearance", IsPoliceClearance);
            cmd.Parameters.AddWithValue("@PoliceClearance", PoliceClearance);
            cmd.Parameters.AddWithValue("@IsMedicalCertificate", IsMedicalCertificate);
            cmd.Parameters.AddWithValue("@MedicalCertificate", MedicalCertificate);
            cmd.Parameters.AddWithValue("@MedicalCertificateFileName", MedicalCertificateFileName);
            cmd.Parameters.AddWithValue("@Visual", Visual);
            cmd.Parameters.AddWithValue("@Learning", Learning);
            cmd.Parameters.AddWithValue("@Difficulty", Difficulty);
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
    public string InsertToefl(string LinkId, bool EnglishSpeaker, bool Toefl, int ToefelExamDateType, string ExamDateToefl, string ExamTimeToefl, 
        string ExamDateIelts, string ExamTimeIelts, string TestType, string ExamPassedOn, string EnglishMark, string StatusOfExam, string Listening,
        string Reading, string Writing, string Speaking, string ResultSubmited, string Result, int EntryType, int ToeflOrtDate, int ToeflOrtTime,
        int IeltsOrtDate, int IeltsOrtTime, bool Books, bool outside, bool statuschange, string userid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertToeflnew", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@EnglishSpeaker", EnglishSpeaker);
            cmd.Parameters.AddWithValue("@Toefl", Toefl);
            cmd.Parameters.AddWithValue("@ToefelExamDateType", ToefelExamDateType);
            cmd.Parameters.AddWithValue("@ExamDateToefl", ExamDateToefl);
            cmd.Parameters.AddWithValue("@ExamTimeToefl", ExamTimeToefl);
            cmd.Parameters.AddWithValue("@ExamDateIelts", ExamDateIelts);
            cmd.Parameters.AddWithValue("@ExamTimeIelts", ExamTimeIelts);
            cmd.Parameters.AddWithValue("@TestType", TestType);
            cmd.Parameters.AddWithValue("@ExamPassedOn", ExamPassedOn);
            cmd.Parameters.AddWithValue("@EnglishMark", EnglishMark);
            cmd.Parameters.AddWithValue("@StatusOfExam", StatusOfExam);
            cmd.Parameters.AddWithValue("@Listening", Listening);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@ResultSubmited", ResultSubmited);
            cmd.Parameters.AddWithValue("@Result", Result);
            cmd.Parameters.AddWithValue("@EntryType", EntryType);
            cmd.Parameters.AddWithValue("@ToeflOrtDate", ToeflOrtDate);
            cmd.Parameters.AddWithValue("@ToeflOrtTime", ToeflOrtTime);
            cmd.Parameters.AddWithValue("@IeltsOrtDate", IeltsOrtDate);
            cmd.Parameters.AddWithValue("@IeltsOrtTime", IeltsOrtTime);
            cmd.Parameters.AddWithValue("@Books", Books);
            cmd.Parameters.AddWithValue("@outsidesuc", outside);
            cmd.Parameters.AddWithValue("@statuschange", statuschange);
            cmd.Parameters.AddWithValue("@createdip", GetMacAddress());
            cmd.Parameters.AddWithValue("@createdid", userid);
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
    public string UpdateToefl(string Id,string LinkId, bool EnglishSpeaker, bool Toefl, int ToefelExamDateType, string ExamDateToefl, string ExamTimeToefl, 
        string ExamDateIelts, string ExamTimeIelts, string TestType, string ExamPassedOn, string EnglishMark, string StatusOfExam, string Listening, 
        string Reading, string Writing, string Speaking, string ResultSubmited, string Result, int EntryType, int ToeflOrtDate, int ToeflOrtTime,
        int IeltsOrtDate, int IeltsOrtTime, bool Books, bool outside, bool statuschange, string userid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateToeflnew", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@EnglishSpeaker", EnglishSpeaker);
            cmd.Parameters.AddWithValue("@Toefl", Toefl);
            cmd.Parameters.AddWithValue("@ToefelExamDateType", ToefelExamDateType);
            cmd.Parameters.AddWithValue("@ExamDateToefl", ExamDateToefl);
            cmd.Parameters.AddWithValue("@ExamTimeToefl", ExamTimeToefl);
            cmd.Parameters.AddWithValue("@ExamDateIelts", ExamDateIelts);
            cmd.Parameters.AddWithValue("@ExamTimeIelts", ExamTimeIelts);
            cmd.Parameters.AddWithValue("@TestType", TestType);
            cmd.Parameters.AddWithValue("@ExamPassedOn", ExamPassedOn);
            cmd.Parameters.AddWithValue("@EnglishMark", EnglishMark);
            cmd.Parameters.AddWithValue("@StatusOfExam", StatusOfExam);
            cmd.Parameters.AddWithValue("@Listening", Listening);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@ResultSubmited", ResultSubmited);
            cmd.Parameters.AddWithValue("@Result", Result);
            cmd.Parameters.AddWithValue("@EntryType", EntryType);
            cmd.Parameters.AddWithValue("@ToeflOrtDate", ToeflOrtDate);
            cmd.Parameters.AddWithValue("@ToeflOrtTime", ToeflOrtTime);
            cmd.Parameters.AddWithValue("@IeltsOrtDate", IeltsOrtDate);
            cmd.Parameters.AddWithValue("@IeltsOrtTime", IeltsOrtTime);
            cmd.Parameters.AddWithValue("@Books", Books);
            cmd.Parameters.AddWithValue("@outsidesuc", outside);
            cmd.Parameters.AddWithValue("@statuschange", statuschange);
            cmd.Parameters.AddWithValue("@createdip", GetMacAddress());
            cmd.Parameters.AddWithValue("@createdid", userid);

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
    public string InsertMath(string LinkId, bool HavingSat, string MathExamDate, string MathExamTime, string MathMark, string StatusOfExamMath, string ExamPassedOnMath, string ResultSubmittedMath, string ResultMath, string Remarks)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertMath", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@HavingSat", HavingSat);
            cmd.Parameters.AddWithValue("@MathExamDate", MathExamDate);
            cmd.Parameters.AddWithValue("@MathExamTime", MathExamTime);
            cmd.Parameters.AddWithValue("@MathMark", MathMark);
            cmd.Parameters.AddWithValue("@StatusOfExamMath", StatusOfExamMath);
            cmd.Parameters.AddWithValue("@ExamPassedOnMath", ExamPassedOnMath);
            cmd.Parameters.AddWithValue("@ResultSubmittedMath", ResultSubmittedMath);
            cmd.Parameters.AddWithValue("@ResultMath", ResultMath);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
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
    public string InsertRemarks(string LinkId, string RemarksType, string Remarks)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertRemarks", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@RemarksType", RemarksType);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
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
    public string UpdateRemarks(string Id, string RemarksType, string Remarks)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateRemarks", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@RemarksType", RemarksType);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
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
    public string UpdateTOC(string Id, string TOCCase, string DocumentProcess, string UniversityName, string TotalNoOfCourse, string UnderTaking, string UniversityAttended,
        DateTime FollowDate, string FinaceDetails, string FeesPaid, string ReceiptNo, DateTime Date, decimal CGPA, string FileName,bool CDD, bool Transcript, bool Letter,bool mqptoc)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateTOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@TOCCase", TOCCase);
            cmd.Parameters.AddWithValue("@DocumentProcess", DocumentProcess);
            cmd.Parameters.AddWithValue("@UniversityName", UniversityName);
            cmd.Parameters.AddWithValue("@TotalNoOfCourse", TotalNoOfCourse);
            cmd.Parameters.AddWithValue("@UnderTaking", UnderTaking);
            cmd.Parameters.AddWithValue("@UniversityAttended", UniversityAttended);
            cmd.Parameters.AddWithValue("@FollowDate", FollowDate);
            cmd.Parameters.AddWithValue("@FinaceDetails", FinaceDetails);
            cmd.Parameters.AddWithValue("@FeesPaid", FeesPaid);
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@CGPA", CGPA);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@CDD", CDD);
            cmd.Parameters.AddWithValue("@Transcript", Transcript);
            cmd.Parameters.AddWithValue("@Letter", Letter);
            cmd.Parameters.AddWithValue("@mqptoc", mqptoc);

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
    public string InsertUndertaking(string LinkId, string UName, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertStudentUndertaking", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@UName", UName);
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
    public string UpdateUndertaking(int linkid,string UName, string FileName,int userid,string udate)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateStudentUndertaking", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@linkid",linkid);
            cmd.Parameters.AddWithValue("@UName", UName);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@submittedby", userid);
            cmd.Parameters.AddWithValue("@submitteddate", udate);
            cmd.Parameters.AddWithValue("@submittedip", GetMacAddress());
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
    public string UpdateUndertaking(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tblStudentUndertaking set Status = 'False' where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
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
    public string InsertTransportation(string LinkId, bool TransportationRequired, string Transportation, string ExactLocation)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertTransportation", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@TransportationRequired", TransportationRequired);
            cmd.Parameters.AddWithValue("@Transportation", Transportation);
            cmd.Parameters.AddWithValue("@ExactLocation", ExactLocation);
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
    public string InsertMediaSource(string LinkId, string MediaSource,string agentid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertMediaSource", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@Agentid", agentid);
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
    public string InsertHostel(string LinkId, bool IsHostelRequired, string NameofHostel, string PhoneNo, decimal FeePaid, string ReceiptNo, DateTime Date, DateTime ToDate, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertHostel1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@IsHostelRequired", IsHostelRequired);
            cmd.Parameters.AddWithValue("@NameofHostel", NameofHostel);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@FeePaid", FeePaid);
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
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
    public string InsertMedicalHitory(string LinkId, DateTime MedicalHistoryDate, string MedicalHistory, string MedicalHistoryFileName, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertMedicalHistory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@MedicalHistoryDate", MedicalHistoryDate);
            cmd.Parameters.AddWithValue("@MedicalHistory", MedicalHistory);
            cmd.Parameters.AddWithValue("@MedicalHistoryFileName", MedicalHistoryFileName);
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
    public string InsertProgram(string LinkId, string ProgramType, string DegreeType, string CourseType, string Term, string Shift, DateTime ShortFromDate,
        DateTime ShortToDate, string Reading, string Writing, string Listing, string Speaking,string nextshift,bool integrated,int empid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertProgram", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ProgramType", ProgramType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@Term", Term);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@ShortFromDate", ShortFromDate);
            cmd.Parameters.AddWithValue("@ShortToDate", ShortToDate);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Listing", Listing);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@nextShift", nextshift);
            cmd.Parameters.AddWithValue("@isintegrated", integrated);
            cmd.Parameters.AddWithValue("@createdby", empid);
            cmd.Parameters.AddWithValue("@createdip",GetMacAddress());
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
    public string InsertProgram1(string LinkId, string ProgramType, string DegreeType, string CourseType, string Term, string Shift, DateTime ShortFromDate,
        DateTime ShortToDate, string Reading, string Writing, string Listing, string Speaking,string nextshift)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertProgram1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ProgramType", ProgramType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@Term", Term);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@ShortFromDate", ShortFromDate);
            cmd.Parameters.AddWithValue("@ShortToDate", ShortToDate);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Listing", Listing);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@nextShift", nextshift);
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

    public string InsertProgram2(string LinkId, string ProgramType, string DegreeType, string CourseType, string Term, string Shift, DateTime ShortFromDate,
        DateTime ShortToDate, string Reading, string Writing, string Listing, string Speaking, string NewDegree,string newshift)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertProgram2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ProgramType", ProgramType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@Term", Term);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@ShortFromDate", ShortFromDate);
            cmd.Parameters.AddWithValue("@ShortToDate", ShortToDate);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Listing", Listing);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@NewDegree", NewDegree);
            cmd.Parameters.AddWithValue("@newshift", newshift);

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
    public string InsertTOC(string LinkId,string TOCCase,string DocumentProcess,string UniversityName,string TotalNoOfCourse,string UnderTaking,string UniversityAttended,
        DateTime FollowDate, string FinaceDetails, string FeesPaid, string ReceiptNo, DateTime Date, decimal CGPA, string FileName, bool CDD, bool Transcript, bool Letter,bool mqptoc)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertTOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@TOCCase", TOCCase);
            cmd.Parameters.AddWithValue("@DocumentProcess", DocumentProcess);
            cmd.Parameters.AddWithValue("@UniversityName", UniversityName);
            cmd.Parameters.AddWithValue("@TotalNoOfCourse", TotalNoOfCourse);
            cmd.Parameters.AddWithValue("@UnderTaking", UnderTaking);
            cmd.Parameters.AddWithValue("@UniversityAttended", UniversityAttended);
            cmd.Parameters.AddWithValue("@FollowDate", FollowDate);
            cmd.Parameters.AddWithValue("@FinaceDetails", FinaceDetails);
            cmd.Parameters.AddWithValue("@FeesPaid", FeesPaid);
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@CGPA", CGPA);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@CDD", CDD);
            cmd.Parameters.AddWithValue("@Transcript", Transcript);
            cmd.Parameters.AddWithValue("@Letter", Letter);
            cmd.Parameters.AddWithValue("@mqptoc", mqptoc);
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
    //public string InsertFinace(string LinkId, string FeeWaiverType, decimal Fees, decimal FeeWaiver, decimal TotalFees, string Remarks, bool LetterSubmitted, int FeeCategory, string Percentage, bool NAU)
    //{
    //    try
    //    {
    //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand("ProcInsertFinace1", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@LinkId", LinkId);            
    //        cmd.Parameters.AddWithValue("@FeeWaiverType", FeeWaiverType);
    //        cmd.Parameters.AddWithValue("@Fees", Fees);
    //        cmd.Parameters.AddWithValue("@FeeWaiver", FeeWaiver);
    //        cmd.Parameters.AddWithValue("@TotalFees", TotalFees);
    //        cmd.Parameters.AddWithValue("@Remarks", Remarks);
    //        cmd.Parameters.AddWithValue("@LetterSubmitted", LetterSubmitted);
    //        cmd.Parameters.AddWithValue("@FeeCategory", FeeCategory);
    //        cmd.Parameters.AddWithValue("@Percentage", Percentage);
    //        cmd.Parameters.AddWithValue("@NAU", NAU);
    //        using (conn)
    //            cmd.ExecuteNonQuery();
    //        conn.Close();
    //        return "RegisterNo";
    //    }
    //    catch
    //    {
    //        return "error";
    //    }
    //}

    public string InsertFinace(string LinkId, string FeeWaiverType, decimal Fees, decimal FeeWaiver, decimal TotalFees, string Remarks, bool LetterSubmitted, int FeeCategory, string Percentage, bool NAU, string special, string studid, string choice, string relation, int shjhrd, bool isairticket)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertFinace1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@FeeWaiverType", FeeWaiverType);
            cmd.Parameters.AddWithValue("@Fees", Fees);
            cmd.Parameters.AddWithValue("@FeeWaiver", FeeWaiver);
            cmd.Parameters.AddWithValue("@TotalFees", TotalFees);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@LetterSubmitted", LetterSubmitted);
            cmd.Parameters.AddWithValue("@FeeCategory", FeeCategory);
            cmd.Parameters.AddWithValue("@Percentage", Percentage);
            cmd.Parameters.AddWithValue("@NAU", NAU);
            cmd.Parameters.AddWithValue("@special", special);
            cmd.Parameters.AddWithValue("@studid", studid);
            cmd.Parameters.AddWithValue("@choice", choice);
            cmd.Parameters.AddWithValue("@relation", relation);
            cmd.Parameters.AddWithValue("@SHJ_HRDID", shjhrd);
            cmd.Parameters.AddWithValue("@isairticket", isairticket);
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


    public DataTable SetContact(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetContact]");
        return ds.Tables[0];
    }
    public DataTable SetFitness(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetFitness]");
        return ds.Tables[0];
    }
    public DataTable SetParents(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetParents]");
        return ds.Tables[0];
    }
    public DataTable SetMediaSource(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetMediaSource]");
        return ds.Tables[0];
    }
    public DataTable SetTOC(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetTOC]");
        return ds.Tables[0];
    }
    public DataTable SetFinance(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetFinance]");
        return ds.Tables[0];
    }
    public DataSet SetProgram(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetProgram]");
        return ds;
    }
    public DataTable SetVisa(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetVisa]");
        return ds.Tables[0];
    }
    public DataTable SetSkylineVisa(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetSkylineVisa]");
        return ds.Tables[0];
    }
    public DataTable SetQualification(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetQualification]");
        return ds.Tables[0];
    }
    public DataTable SetExperience(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetExperience]");
        return ds.Tables[0];
    }
    public DataSet SetToefl(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetToefl]");
        return ds;
    }
    public DataSet SetToefl1(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetToefl1]");
        return ds;
    }
    public DataSet SetToefl2(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetToefl2]");
        return ds;
    }
    public DataSet SetMath(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetMath]");
        return ds;
    }
    public DataSet SetMath1(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetMath1]");
        return ds;
    }
    public DataSet SetMath2(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetMath2]");
        return ds;
    }
    public DataSet SetRemarks(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetRemarks]");
        return ds;
    }
    public DataSet SetMedicalHistory(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetMedicalHistory]");
        return ds;
    }
    public DataSet SetUndertaking(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetUndertaking]");
        return ds;
    }
    public DataTable SetTransportation(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetTransportation]");
        return ds.Tables[0];
    }
    public DataTable SetHostel(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetHostel]");
        return ds.Tables[0];
    }
    public DataTable GetReportList(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetReportList]");
        return ds.Tables[0];
    }
    public DataTable SetDropdownList(int Flag, string schoolcode = "SAMS")
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@schoolcode", schoolcode);
        AttendanceDataAcessLayer da = new AttendanceDataAcessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetDropdown]");
        return ds.Tables[0];
    }
    public DataTable SetDropdownListCDB(int Flag,string schoolcode="SAS")
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetDropdown]");
        return ds.Tables[0];
    }

    public DataTable LoadCaller()
    {
        SqlParameter[] param = new SqlParameter[0];       
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[SP_LoadCaller]");
        return ds.Tables[0];
    }

    public DataTable fillTermname()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("sp_getTerm");
        return ds.Tables[0];
    }

    public DataTable filldegreeName()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("Sp_getdegree");
        return ds.Tables[0];
    }

    public DataTable SetDropdownListnnew(string Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetDropdownMissed]");
        return ds.Tables[0];
    }


    public DataTable GetUndertakingByDegree(string LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetUndertakingByDegree]");
        return ds.Tables[0];
    }
    public DataTable SetDropdownListAsDegreeType(int Flag, int Id, string schoolcode="SAS")
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Id", Id);
        param[2] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetDropdownAsDegreeType]");
        return ds.Tables[0];
    }

    public DataTable GetMyCallList(string Id, string FilterBy, string FilterValue, string CallType, int pageno, int pagerow, string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Id", Id);
        param[1] = new SqlParameter("@FilterBy", FilterBy);
        param[2] = new SqlParameter("@FilterValue", FilterValue);
        param[3] = new SqlParameter("@CallType", CallType);
        param[4] = new SqlParameter("@iPageNo", pageno);
        param[5] = new SqlParameter("@iPageRecords", pagerow);
        param[6] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMyCallList2]");
        return ds.Tables[0];
    }

    public DataTable GetMyCallListRowcount(string Id, string FilterBy, string FilterValue, string CallType, int pageno, int pagerow, string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Id", Id);
        param[1] = new SqlParameter("@FilterBy", FilterBy);
        param[2] = new SqlParameter("@FilterValue", FilterValue);
        param[3] = new SqlParameter("@CallType", CallType);
        param[4] = new SqlParameter("@iPageNo", pageno);
        param[5] = new SqlParameter("@iPageRecords", pagerow);
        param[6] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMyCallList1]");
        return ds.Tables[0];
    }

    public DataTable GetMyCallList(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcCountCall]");
        return ds.Tables[0];
    }
    public DataTable GetMyStudentStatus(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcCountStudentStatus]");
        return ds.Tables[0];
    }
    public DataTable GetCaller(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetCaller]");
        return ds.Tables[0];
    }
    public string InsertFollowUp(string LinkId, DateTime Date, string Status, string ForwardedTo, string Remarks, int AttendedBy, int submenuid=0)
    {
        try
        {
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("ProcInsertFollowUp", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@LinkId", LinkId);
        //    cmd.Parameters.AddWithValue("@Date", Date);
        //    cmd.Parameters.AddWithValue("@Status", Status);
        //    cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
        //    cmd.Parameters.AddWithValue("@Remarks", Remarks);
        //    cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
        //    using (conn)
        //        cmd.ExecuteNonQuery();
        //    conn.Close();
        //    return "RegisterNo";
        //}

            string s1;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertFollowUp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@submenuid", submenuid);
            using (conn)
                s1 = cmd.ExecuteScalar().ToString();
            conn.Close();
            return s1;
        }

        catch
        {
            return "error";
        }
    }

    public string InsertFollowUpExisting(string LinkId, DateTime Date, string Status, string ForwardedTo, string Remarks, int AttendedBy,int submenuid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertFollowUpexisting", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@createdby", AttendedBy);
            cmd.Parameters.AddWithValue("@createdip", GetMacAddress());
            cmd.Parameters.AddWithValue("@submenuid", submenuid);
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


    public string InsertMissedcallExisting(string LinkId, DateTime Date, string Status, string ForwardedTo, string Remarks, int AttendedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertMissedcallexisting", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", LinkId);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@createdip", GetMacAddress());
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


    // newly added by meena
    public string InsertAttendFollowUp(string LinkId, DateTime Date, string Status, string ForwardedTo, string Remarks, int AttendedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertFollowUpAttend", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
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
    // end 
    
    public string InsertPolicy(string AdpCode,string AdpDesc,int ProgramId,int AccSemId,bool Sub1B,string Sub1Code,string Sub1Value,string Sub1Label,bool Sub2B,string Sub2Code,string Sub2Value,
        string Sub2Label,bool Sub3B,string Sub3Code,string Sub3Value,string Sub3Label,bool Sub4B,string Sub4Code,string Sub4Value,string Sub4Label,bool Sub5B,string Sub5Code,
        string Sub5Value,string Sub5Label,bool Sub6B,string Sub6Code,string Sub6Value,string Sub6Label,bool Sub7B,string Sub7Code,string Sub7Value,string Sub7Label,bool Sub8B,
        string Sub8Code,string Sub8Value,string Sub8Label,bool Sub9B,string Sub9Code,string Sub9Value,string Sub9Label,bool Sub10B,string Sub10Code,string Sub10Value,string Sub10Label,
        bool Sub11B,string Sub11Code,string Sub11Value,string Sub11Label,bool Sub12B,string Sub12Code,string Sub12Value,string Sub12Label,bool Sub13B,string Sub13Code,string Sub13Value,
        string Sub13Label,bool Sub14B,string Sub14Code,string Sub14Value,string Sub14Label,bool Sub15B,string Sub15Code,string Sub15Value,string Sub15Label,string Rules,int CreatedBy,
        string HostName,bool Status)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[ProcInsertAdmissionPolicyBase]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AdpCode", AdpCode);
            cmd.Parameters.AddWithValue("@AdpDesc", AdpDesc);
            cmd.Parameters.AddWithValue("@ProgramId", ProgramId);
            cmd.Parameters.AddWithValue("@AccSemId", AccSemId);
            cmd.Parameters.AddWithValue("@Sub1B", Sub1B);
            cmd.Parameters.AddWithValue("@Sub1Code", Sub1Code);
            cmd.Parameters.AddWithValue("@Sub1Value", Sub1Value);
            cmd.Parameters.AddWithValue("@Sub1Label", Sub1Label);
            cmd.Parameters.AddWithValue("@Sub2B", Sub2B);
            cmd.Parameters.AddWithValue("@Sub2Code", Sub2Code);
            cmd.Parameters.AddWithValue("@Sub2Value", Sub2Value);
            cmd.Parameters.AddWithValue("@Sub2Label", Sub2Label);
            cmd.Parameters.AddWithValue("@Sub3B", Sub3B);
            cmd.Parameters.AddWithValue("@Sub3Code", Sub3Code);
            cmd.Parameters.AddWithValue("@Sub3Value", Sub3Value);
            cmd.Parameters.AddWithValue("@Sub3Label", Sub3Label);
            cmd.Parameters.AddWithValue("@Sub4B", Sub4B);
            cmd.Parameters.AddWithValue("@Sub4Code", Sub4Code);
            cmd.Parameters.AddWithValue("@Sub4Value", Sub4Value);
            cmd.Parameters.AddWithValue("@Sub4Label", Sub4Label);
            cmd.Parameters.AddWithValue("@Sub5B", Sub5B);
            cmd.Parameters.AddWithValue("@Sub5Code", Sub5Code);
            cmd.Parameters.AddWithValue("@Sub5Value", Sub5Value);
            cmd.Parameters.AddWithValue("@Sub5Label", Sub5Label);
            cmd.Parameters.AddWithValue("@Sub6B", Sub6B);
            cmd.Parameters.AddWithValue("@Sub6Code", Sub6Code);
            cmd.Parameters.AddWithValue("@Sub6Value", Sub6Value);
            cmd.Parameters.AddWithValue("@Sub6Label", Sub6Label);
            cmd.Parameters.AddWithValue("@Sub7B", Sub7B);
            cmd.Parameters.AddWithValue("@Sub7Code", Sub7Code);
            cmd.Parameters.AddWithValue("@Sub7Value", Sub7Value);
            cmd.Parameters.AddWithValue("@Sub7Label", Sub7Label);
            cmd.Parameters.AddWithValue("@Sub8B", Sub8B);
            cmd.Parameters.AddWithValue("@Sub8Code", Sub8Code);
            cmd.Parameters.AddWithValue("@Sub8Value", Sub8Value);
            cmd.Parameters.AddWithValue("@Sub8Label", Sub8Label);
            cmd.Parameters.AddWithValue("@Sub9B", Sub9B);
            cmd.Parameters.AddWithValue("@Sub9Code", Sub9Code);
            cmd.Parameters.AddWithValue("@Sub9Value", Sub9Value);
            cmd.Parameters.AddWithValue("@Sub9Label", Sub9Label);
            cmd.Parameters.AddWithValue("@Sub10B", Sub10B);
            cmd.Parameters.AddWithValue("@Sub10Code", Sub10Code);
            cmd.Parameters.AddWithValue("@Sub10Value", Sub10Value);
            cmd.Parameters.AddWithValue("@Sub10Label", Sub10Label);
            cmd.Parameters.AddWithValue("@Sub11B", Sub11B);
            cmd.Parameters.AddWithValue("@Sub11Code", Sub11Code);
            cmd.Parameters.AddWithValue("@Sub11Value", Sub11Value);
            cmd.Parameters.AddWithValue("@Sub11Label", Sub11Label);
            cmd.Parameters.AddWithValue("@Sub12B", Sub12B);
            cmd.Parameters.AddWithValue("@Sub12Code", Sub12Code);
            cmd.Parameters.AddWithValue("@Sub12Value", Sub12Value);
            cmd.Parameters.AddWithValue("@Sub12Label", Sub12Label);
            cmd.Parameters.AddWithValue("@Sub13B", Sub13B);
            cmd.Parameters.AddWithValue("@Sub13Code", Sub13Code);
            cmd.Parameters.AddWithValue("@Sub13Value", Sub13Value);
            cmd.Parameters.AddWithValue("@Sub13Label", Sub13Label);
            cmd.Parameters.AddWithValue("@Sub14B", Sub14B);
            cmd.Parameters.AddWithValue("@Sub14Code", Sub14Code);
            cmd.Parameters.AddWithValue("@Sub14Value", Sub14Value);
            cmd.Parameters.AddWithValue("@Sub14Label", Sub14Label);
            cmd.Parameters.AddWithValue("@Sub15B", Sub15B);
            cmd.Parameters.AddWithValue("@Sub15Code", Sub15Code);
            cmd.Parameters.AddWithValue("@Sub15Value", Sub15Value);
            cmd.Parameters.AddWithValue("@Sub15Label", Sub15Label);
            cmd.Parameters.AddWithValue("@Rules", Rules);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@HostName", HostName);
            cmd.Parameters.AddWithValue("@Status", Status);
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
    public DataTable GetRegNo()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", "0");
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetregNo]");
        return ds.Tables[0];
    }

    public int GetTOCAPPLICABLE(int linkid)
    {
        int Count = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", linkid);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGettocApplicable]");
        foreach (DataRow ro in ds.Tables[0].Rows)
        {
            Count = int.Parse(ro[0].ToString());
        }
        return Count;
    }
    public int IsRegNoUsed(string RegNo)
    {
        int Count = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@RegistrationNo", RegNo);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcIsRegNoUsed]");
        foreach (DataRow ro in ds.Tables[0].Rows)
        {
            Count = int.Parse(ro[0].ToString());
        }
        return Count;
    }
    public DataTable IsMObileUsed(string MobileNo)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@MobileNo", MobileNo);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcIsMObileUsed]");
        return ds.Tables[0];
    }
    public int IsMissedCall(int Id)
    {
        int RemainingToCheck = 0;

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            SqlCommand cmd = new SqlCommand("[GetCountMissedCall]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", Id);

            SqlDataReader dr = null;

            using (conn)
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        RemainingToCheck = dr.GetInt32(0);
                    }
                }
            }

        }
        catch
        {

        }
        return RemainingToCheck;
    }
    public DataTable GetMissCalledList(int EmpId, string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Id", EmpId);
        param[1] = new SqlParameter("@schoolcode", EmpId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetMissedCallList]");
        return ds.Tables[0];
    }
    public string InsertAttendCall(string Id)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertAttendCall", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
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
    public DataSet PrintReport(string degreetype, string callerstatus, string fromdate, string todate, string createdby, string callercategory, string formstatus, string flag)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@degreetype", degreetype);
        param[1] = new SqlParameter("@callerstatus", callerstatus);
        param[2] = new SqlParameter("@fromdate", fromdate);
        param[3] = new SqlParameter("@todate", todate);
        param[4] = new SqlParameter("@createdby", createdby);
        param[5] = new SqlParameter("@callercategory", callercategory);
        param[6] = new SqlParameter("@formstatus", formstatus);
        param[7] = new SqlParameter("@flag", flag);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[Proc_cms_report]");
        return ds;
    }
    public string GetRegNo(string LinkId)
    {
        string RegNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) RegistrationNo from tblStudent where LinkId=@LinkId and Status='True' and RegistrationNo is not null", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RegNo = dr[0].ToString();
            }
            conn.Close();
            return RegNo;
        }
        catch
        {
            return RegNo;
        }
    }
    public string GetNameByLinkID(string LinkId)
    {
        string RegNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) FirstName+' '+MiddleName+' '+LastName as [Name] from tblStudent where LinkId=@LinkId and Status='True' and RegistrationNo is not null", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RegNo = dr[0].ToString();
            }
            conn.Close();
            return RegNo;
        }
        catch
        {
            return RegNo;
        }
    }
    public string GetRegNo1(string Id)
    {
        string RegNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) RegistrationNo from tblStudent where Id=@Id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RegNo = dr[0].ToString();
            }
            conn.Close();
            return RegNo;
        }
        catch
        {
            return RegNo;
        }
    }
    public string GetLinkId(string RegNo)
    {
        string LinkId = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) LinkId from tblStudent where RegistrationNo=@RegNo and Status='True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LinkId = dr[0].ToString();
            }
            conn.Close();
            return LinkId;
        }
        catch
        {
            return LinkId;
        }
    }
    public string GetLinkIdById(int Id)
    {
        string LinkId = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) LinkId from tblStudent where Id=@Id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LinkId = dr[0].ToString();
            }
            conn.Close();
            return LinkId;
        }
        catch
        {
            return LinkId;
        }
    }
    public DataSet GetEmailDetails(string EmpId, string LinkId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@EmpId", EmpId);
        param[1] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetEmailDetails1]");
        return ds;
    }
    public string InsertFinalize(string LinkId,string empid, string FileNumber)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into tblFinalize (LinkId,registerby,FileNumber) values (@LinkId,@empid,@FileNumber)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@FileNumber", FileNumber);
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
    public string UpdateFinalize(string LinkId, string FileNumber)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tblFinalize set FileNumber=@FileNumber,FileAddedDate=getdate() where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@FileNumber", FileNumber);
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
    public string DeleteFinalize(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from tblFinalize where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
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
    public int GetIsNewUndertaking(string LinkId)
    {
        int DegreeType = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) DegreeType from tblStudent where linkId = @LinkId and Status = 'True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DegreeType = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return DegreeType;
        }
        catch
        {
            return DegreeType;
        }
    }
    public int GetIsProgramSelected(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblProgram where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public string GetCheckMailContact(string LinkId)
    {
        string Email = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Email from tblContact where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Email = dr[0].ToString();
            }
            conn.Close();
            return Email;
        }
        catch
        {
            return Email;
        }
    }
    public string GetCheckMobileContact(string LinkId)
    {
        string Email = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Mobile from tblContact where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Email = dr[0].ToString();
            }
            conn.Close();
            return Email;
        }
        catch
        {
            return Email;
        }
    }
    public string GetCheckMailGuardian(string LinkId)
    {
        string Email = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Email from tblParents where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Email = dr[0].ToString();
            }
            conn.Close();
            return Email;
        }
        catch
        {
            return Email;
        }
    }
    public string GetCheckMailParent(string LinkId)
    {
        string Email = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select PEmail from tblParents where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Email = dr[0].ToString();
            }
            conn.Close();
            return Email;
        }
        catch
        {
            return Email;
        }
    }
    public int GetIsQualificationSelected(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblQualification where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public int GetIsPassport(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblVisaInfo where LinkId=@LinkId and DocumentType='National ID Card'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public DataTable GetCheckFinalize(int Flag, string LinkId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcFinalizeCheck]");
        return ds.Tables[0];
    }
    public string GetRegisteredBy(string LinkId)
    {
        string AttendedBy = "";

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            SqlCommand cmd = new SqlCommand("select distinct a.FIRSTANME+' '+a.MIDDILENAME+' '+a.LASTNAME as 'Name' from tblStudent inner join tblEmpmaster as a on a.EmpId=tblStudent.CreatedBy where RegistrationNo<>'' and LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);

            SqlDataReader dr = null;

            using (conn)
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        AttendedBy = dr[0].ToString();
                    }
                }
            }

        }
        catch
        {

        }
        return AttendedBy;
    }
    public DataTable SetState(string Code)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Code", Code);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetState]");
        return ds.Tables[0];
    }
    public string GetQualification(string LinkId,int Flag)
    {
        string AttendedBy = "";

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            SqlCommand cmd;
            if(Flag == 1)
                cmd = new SqlCommand("select count(*) from tblQualification where LinkId=@LinkId and (Qualification = 'High School Certificate' or Qualification ='Higher National Diploma' or Qualification ='12th Standard from UAE Secondary School Certificate' or Qualification ='12th Standard from Private Institution in the UAE' or Qualification ='12th Standard from Abroad')", conn);
            else
                cmd = new SqlCommand("select count(*) from tblQualification where LinkId=@LinkId and Qualification ='Bachelor Degree'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);

            SqlDataReader dr = null;

            using (conn)
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        AttendedBy = dr[0].ToString();
                    }
                }
            }

        }
        catch
        {

        }
        return AttendedBy;
    }
    public int GetisFinalized(string LinkId)
    {
        int Count = 0;

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblFinalize where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);

            SqlDataReader dr = null;

            using (conn)
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Count = int.Parse(dr[0].ToString());
                    }
                }
            }

        }
        catch
        {

        }
        return Count;
    }
    public DataTable GetCheckList(int EmpId, int LinkId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@EmpId", EmpId);
        param[1] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetCheckList]");
        return ds.Tables[0];
    }
    public string InsertChecklistValues(int ChkDetailId, string ChkStudentId, bool MktSubmitted, bool AdmSubmitted, bool FInSubmitted, bool IroSubmitted,bool coecSubmitted, string MktValue, string AdmValue, string  FinValue,
        string IroValue, string coecValue, int MrktCreatedBy, int AdmCreatedBy, int FinCreatedBy, int IroCreatedBy, int coecCreatedBy, string Remarks, DateTime? MCreatedDate, DateTime? ACreatedDate, DateTime? FCreatedDate, DateTime? ICreatedDate, DateTime? coecreatedDate,string admremarks,string finremarks,string iroremarks,string coecremarks)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertChecklistValues", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ChkDetailId", ChkDetailId);
            cmd.Parameters.AddWithValue("@ChkStudentId", ChkStudentId);
            cmd.Parameters.AddWithValue("@MktSubmitted", MktSubmitted);
            cmd.Parameters.AddWithValue("@AdmSubmitted", AdmSubmitted);
            cmd.Parameters.AddWithValue("@FInSubmitted", FInSubmitted);
            cmd.Parameters.AddWithValue("@IroSubmitted", IroSubmitted);
            cmd.Parameters.AddWithValue("@coecSubmitted", coecSubmitted);
            cmd.Parameters.AddWithValue("@MktValue", MktValue);
            cmd.Parameters.AddWithValue("@AdmValue", AdmValue);
            cmd.Parameters.AddWithValue("@FinValue", FinValue);
            cmd.Parameters.AddWithValue("@IroValue", IroValue);
            cmd.Parameters.AddWithValue("@coecValue", coecValue);
            cmd.Parameters.AddWithValue("@MrktCreatedBy", MrktCreatedBy);
            cmd.Parameters.AddWithValue("@AdmCreatedBy", AdmCreatedBy);
            cmd.Parameters.AddWithValue("@FinCreatedBy", FinCreatedBy);
            cmd.Parameters.AddWithValue("@IroCreatedBy", IroCreatedBy);
            cmd.Parameters.AddWithValue("@coecCreatedBy", coecCreatedBy);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@MCreatedDate", MCreatedDate);
            cmd.Parameters.AddWithValue("@ACreatedDate", ACreatedDate);
            cmd.Parameters.AddWithValue("@FCreatedDate", FCreatedDate);
            cmd.Parameters.AddWithValue("@ICreatedDate", ICreatedDate);
            cmd.Parameters.AddWithValue("@coecCreatedDate", coecreatedDate);
            cmd.Parameters.AddWithValue("@admremarks", admremarks);
            cmd.Parameters.AddWithValue("@finremarks", finremarks);
            cmd.Parameters.AddWithValue("@iroremarks", iroremarks);
            cmd.Parameters.AddWithValue("@coecremarks", coecremarks);

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
    public string InsertChecklistValues1(string ChkStudentId, int chkDetailId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertChecklistValues1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ChkStudentId", ChkStudentId);
            cmd.Parameters.AddWithValue("@chkDetailId", chkDetailId);
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
    public DataTable GetCheckLIstValue(int LinkId, int ChkDetailId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@LinkId", LinkId);
        param[1] = new SqlParameter("@ChkDetailId", ChkDetailId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetCheckLIstValue]");
        return ds.Tables[0];
    }

    public string Getstudentcategory(int LinkId)
    {
        string category = null;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
        conn.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("select dbo.getstudentprogramcategory(@LinkId)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            category = cmd.ExecuteScalar().ToString();
            conn.Close();
            return category;

        }
        catch
        {    conn.Close();
           return category;
          }
        
    }


    public string InsertIpdateStatus(string LinkId, DateTime Date, string Status, string Remarks, int AttendedBy, int TermId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertCancelPospond", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@TermId", TermId);
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
    public DataTable GetCancelList(string FilterBy, string FilterValue, int Type)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@Type", Type);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetCancelList]");
        if (ds.Tables[0].Rows.Count != 0)
        {
            return ds.Tables[0];
        }
        else
        {
            return null;
        }
    }
    public DataTable GetCheckEmails(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer1 da = new DataAccessLayer1();
        DataSet ds = da.getDataByParam(param, "[GetCheckEmails]");
        return ds.Tables[0];
    }
    public DataTable GetCheckStudent(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetCheckStudent]");
        return ds.Tables[0];
    }
    public DataSet ProcSetProgramForCancel(string Id,string EmpId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Id", Id);
        param[1] = new SqlParameter("@EmpId", EmpId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetProgramForCancel]");
        return ds;
    }
    public DataTable GetCGPA(string LinkId, string Bachelor, decimal CGPA, string grade1, string Courses1, string Year, int Course)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@LinkId", LinkId);
        param[1] = new SqlParameter("@Bachelor", Bachelor);
        param[2] = new SqlParameter("@CGPA", CGPA);
        param[3] = new SqlParameter("@grade1", grade1);
        param[4] = new SqlParameter("@Courses1", Courses1);
        param[5] = new SqlParameter("@Year", Year);
        param[6] = new SqlParameter("@Course", Course);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetCGPA1]");
        return ds.Tables[0];
    }

    public DataTable GetMilitaryReq(string LinkId, string Year)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@LinkId", LinkId);
        param[1] = new SqlParameter("@Year", Year);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_CheckMilitaryReq]");
        return ds.Tables[0];
    }

    public DataTable GetMilitaryReqmet(string LinkId, string Year)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@LinkId", LinkId);
        param[1] = new SqlParameter("@Year", Year);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_CheckMilitaryReqmet]");
        return ds.Tables[0];
    }



    public DataTable CheckSeats(int Course, int Term, string Shift)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Course", Course);
        param[1] = new SqlParameter("@Term", Term);
        param[2] = new SqlParameter("@Shift", Shift);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcCheckSeats]");
        return ds.Tables[0];
    }
    public DataSet GetEntranceDateCondition(int Course, int Term, int Shift, int LinkID, string Types)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Course", Course);
        param[1] = new SqlParameter("@Term", Term);
        param[2] = new SqlParameter("@Shift", Shift);
        param[3] = new SqlParameter("@LinkID", LinkID);
        param[4] = new SqlParameter("@Type", Types);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetEntranceDateCondition]");
        return ds;
    }
    public DataTable GetFeesItems(int Flag, int LinkId)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@LinkId", LinkId);
        param[1] = new SqlParameter("@Flag", Flag);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetFeesItems]");
        return ds.Tables[0];
    }
    public string InsertAddedFeeGroup(string LinkId, int FeeGroupId, int TypeId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertAddedFeeGroup", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@FeeGroupId", FeeGroupId);
            cmd.Parameters.AddWithValue("@TypeId", TypeId);
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
    public string UpdateAddedFeeGroup(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateAddedFeeGroup", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
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
    public bool CheckAddGroup(string LinkId)
    {
        bool IsProceed = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) IsProceed from tblAddedFeeGroup where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IsProceed = bool.Parse(dr[0].ToString());
            }
            conn.Close();
            return IsProceed;
        }
        catch
        {
            return IsProceed;
        }
    }
    public string GetLinkIdByRegNo(string RegNo)
    {
        string LinkId = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) LinkId from tblStudent where RegistrationNo=@RegNo", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LinkId = dr[0].ToString();
            }
            conn.Close();
            return LinkId;
        }
        catch
        {
            return LinkId;
        }
    }
    public string UpdateRejectedStudent(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tblStudent set StudStatus='R' where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
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
    public string GetRejectedStatus(string LinkId)
    {
        string Status = "A";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select StudStatus from tblStudent where linkId = @LinkId and Status = 'True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Status = dr[0].ToString();
            }
            conn.Close();
            return Status;
        }
        catch
        {
            return Status;
        }
    }
    // Entrance Date Setup

    public string InsertCourseExam(string ExamDate, string EngExamFrm, string EngExamTo, string MathExamfrm, string MathExamTo, string Course, bool IsActive)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[InsertExamDate]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EntranceDate", ExamDate);
            cmd.Parameters.AddWithValue("@ENGFrom", EngExamFrm);
            cmd.Parameters.AddWithValue("@ENGTo", EngExamTo);
            cmd.Parameters.AddWithValue("@MATFrom", MathExamfrm);
            cmd.Parameters.AddWithValue("@MATTo", MathExamTo);
            cmd.Parameters.AddWithValue("@Type", Course);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "EntranceDate";
        }
        catch
        {
            return "error";
        }
    }
    public string UpdateCourseExam(int EntrenceId, string ExamDate, string EngExamFrm, string EngExamTo, string MathExamfrm, string MathExamTo, string Course, bool IsActive)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[UpdateCourseExam]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntranceID", EntrenceId);
            cmd.Parameters.AddWithValue("@EntranceDate", ExamDate);
            cmd.Parameters.AddWithValue("@ENGFrom", EngExamFrm);
            cmd.Parameters.AddWithValue("@ENGTo", EngExamTo);
            cmd.Parameters.AddWithValue("@MATFrom", MathExamfrm);
            cmd.Parameters.AddWithValue("@MATTo", MathExamTo);
            cmd.Parameters.AddWithValue("@Type", Course);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "EntranceDate";
        }
        catch
        {
            return "error";
        }
    }
    //Get And set
    public DataTable GetExamDate()
    {
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam("[GetExamDate1]");
        return ds.Tables[0];
    }
    public DataTable SetExamDate(int ID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@EntranceID", ID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetExamDate]");
        return ds.Tables[0];
    }
    public string InsertOtherDetails(int LinkId, string Event, bool TOC, int CreatedBy, int AcademicYear, string Grade)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tblotherdetails set status='false' where linkid=@Linkid  and TransactionType ='CMS'  Insert Into tblOtherDetails (LinkId,Event,TOC,CreatedBy,CreatedDate,Status,TransactionType,AcademicYear,Grade) values (@LinkId,@Event,@TOC,@CreatedBy,getdate(),'True','CMS',@AcademicYear,@Grade)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Linkid", LinkId);
            cmd.Parameters.AddWithValue("@Event", Event);
            cmd.Parameters.AddWithValue("@TOC", TOC);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
            cmd.Parameters.AddWithValue("@Grade", Grade);
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
    public string UpdateFeeWaiver(string FeeWaiverType, decimal FundAllocated, decimal FundExceed, string Remarks, int UserId, bool Status, int Term)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tblFeesWaiver set FundAllocated=@FundAllocated,FundExceed=@FundExceed,Remarks=@Remarks,ApprovedBy=@ApprovedBy,FundCreatedDate=GETDATE(),IsActive=@Status,TermId=@Term where Id=@FeeWaiverType", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FeeWaiverType", FeeWaiverType);
            cmd.Parameters.AddWithValue("@FundAllocated", FundAllocated);
            cmd.Parameters.AddWithValue("@FundExceed", FundExceed);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ApprovedBy", UserId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Term", Term);
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
    public string InsertFeeWaiverFeeGroup(string FeeWaiverType, bool Status, int FeeGroupId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into tblFeeWaiverFeeGroup (FeeWeiverId,FeeGroupId,IsActive) values (@FeeWaiverType,@FeeGroupId,@Status)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FeeWaiverType", FeeWaiverType);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@FeeGroupId", FeeGroupId);
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
    public string InsertIndexSetup(string Index, string Degree, string Term, string Schedule, int ScheduleDate, int ApprovedBy, DateTime ApprovedDate, int RevisedBy, DateTime? RevisedDate, string Remarks, int CreatedBy, bool Status, DateTime NextVerificationDate)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into tblIndexSetup (MasterId,ScheduleType,ScheduleDate,TermId,DegreeId,ApprovedBy,ApprovedDate,RevisedBy,RevisedDate,Remarks,CreatedBy,Status,NextVerified) values (@MasterId,@ScheduleType,@ScheduleDate,@TermId,@DegreeId,@ApprovedBy,@ApprovedDate,@RevisedBy,@RevisedDate,@Remarks,@CreatedBy,@Status,@NextVerified)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MasterId", Index);
            cmd.Parameters.AddWithValue("@DegreeId", Degree);
            cmd.Parameters.AddWithValue("@TermId", Term);
            cmd.Parameters.AddWithValue("@ScheduleType", Schedule);
            cmd.Parameters.AddWithValue("@ScheduleDate", ScheduleDate);
            cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy);
            cmd.Parameters.AddWithValue("@ApprovedDate", ApprovedDate);
            cmd.Parameters.AddWithValue("@RevisedBy", RevisedBy);
            cmd.Parameters.AddWithValue("@RevisedDate", RevisedDate);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@NextVerified", NextVerificationDate);
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
    public string GetName(int LinkId)
    {
        string Name = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) FirstName+' '+MiddleName+' '+LastName as 'Name' from tblStudent where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Name = dr[0].ToString();
            }
            conn.Close();
            return Name;
        }
        catch
        {
            return Name;
        }
    }
    public DataTable CheckSeatForProgram(int CourseType, int Term, int Shift)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@CourseType", CourseType);
        param[1] = new SqlParameter("@Term", Term);
        param[2] = new SqlParameter("@Shift", Shift);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetDropdown]");
        return ds.Tables[0];
    }
    public int GetIsFeeWaiverSelected(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblFinance where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public string GetFileNo(string LinkId)
    {
        string FileNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select FileNumber from tblFinalize  where LinkId=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FileNo = dr[0].ToString();
            }
            conn.Close();
            return FileNo;
        }
        catch
        {
            return FileNo;
        }
    }
    public string GetFileNoMax()
    {
        string FileNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MAX(isnull(convert(int,FileNumber),0))+1  from tblFinalize", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FileNo = dr[0].ToString();
            }
            conn.Close();
            return FileNo;
        }
        catch
        {
            return FileNo;
        }
    }
    // For Entrance Result
    public string InsertExamResult(string LinkId, int TestType, decimal Listening, decimal Reading, decimal Speaking, decimal Writing, decimal Marks, int Foundation, int ExamStatus, bool ReTest, int ExamDate, int ExamTime, string Remarks, int Createdby)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertExamResult", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@TestType", TestType);
            cmd.Parameters.AddWithValue("@Listening", Listening);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Marks", Marks);
            cmd.Parameters.AddWithValue("@Foundation", Foundation);
            cmd.Parameters.AddWithValue("@ExamStatus", ExamStatus);
            cmd.Parameters.AddWithValue("@ReTest", ReTest);
            cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
            cmd.Parameters.AddWithValue("@ExamTime", ExamTime);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
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
    public string UpdateExamResult(string Id, int TestType, decimal Listening, decimal Reading, decimal Speaking, decimal Writing, decimal Marks, int Foundation, int ExamStatus, bool ReTest, int ExamDate, int ExamTime, string Remarks, int Createdby)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateExamResult", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@TestType", TestType);
            cmd.Parameters.AddWithValue("@Listening", Listening);
            cmd.Parameters.AddWithValue("@Reading", Reading);
            cmd.Parameters.AddWithValue("@Speaking", Speaking);
            cmd.Parameters.AddWithValue("@Writing", Writing);
            cmd.Parameters.AddWithValue("@Marks", Marks);
            cmd.Parameters.AddWithValue("@Foundation", Foundation);
            cmd.Parameters.AddWithValue("@ExamStatus", ExamStatus);
            cmd.Parameters.AddWithValue("@ReTest", ReTest);
            cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
            cmd.Parameters.AddWithValue("@ExamTime", ExamTime);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
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
    public string InsertEMSCMSPI(int Type_Id, string Student_Id, int Term, int FeeGroup, string Description, int Createdby, int FeeCategoryId,int detailsid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[InsertEMSCMSPI]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Type_Id", Type_Id);
            cmd.Parameters.AddWithValue("@Student_Id", Student_Id);
            cmd.Parameters.AddWithValue("@Term", Term);
            cmd.Parameters.AddWithValue("@FeeGroup", FeeGroup);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
            cmd.Parameters.AddWithValue("@FeeCategoryId", FeeCategoryId);
            cmd.Parameters.AddWithValue("@detailsid", detailsid);
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


    public string InsertEMSCMSPIbulk( string Student_Id)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertEMSCMSPIstudentwise", conn);
            cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@Student_Id", Student_Id);
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


    // For Fee Group
    public int GetVisaFeeGroup(string LinkId)
    {
        int FeeGroupType = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Fees_Group_Id from TPS..tblFeeGroupAllocation	where AttributeId = case (select top(1) IsInternationalStudent from tblStudent where LinkId=@LinkId) when 'Yes' then 1 else 4 end", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FeeGroupType = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return FeeGroupType;
        }
        catch
        {
            return FeeGroupType;
        }
    }
    //public string InsertOtherVisaDetails(string LinkId, bool VisaLetter, bool EmbassyLetter)
    //{
    //    try
    //    {
    //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand("Insert Into tblOtherDetails (LinkId,VisaLetter,EmbasyLetter,TransactionType) values (@LinkId,@VisaLetter,@EmbasyLetter,'V')", conn);
    //        cmd.CommandType = CommandType.Text;
    //        cmd.Parameters.AddWithValue("@LinkId", LinkId);
    //        cmd.Parameters.AddWithValue("@VisaLetter", VisaLetter);
    //        cmd.Parameters.AddWithValue("@EmbasyLetter", EmbassyLetter);
    //        using (conn)
    //            cmd.ExecuteNonQuery();
    //        conn.Close();
    //        return "RegisterNo";
    //    }
    //    catch
    //    {
    //        return "error";
    //    }
    //}

    public string InsertOtherVisaDetails(string LinkId, bool VisaLetter, bool EmbassyLetter)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(" update  tblOtherDetails set status='false' where linkid=@LinkId and TransactionType='V'  Insert Into tblOtherDetails (LinkId,VisaLetter,EmbasyLetter,TransactionType) values (@LinkId,@VisaLetter,@EmbasyLetter,'V')", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@VisaLetter", VisaLetter);
            cmd.Parameters.AddWithValue("@EmbasyLetter", EmbassyLetter);
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


    public string InsertOtherQualification(string LinkId, int ExamDate, int ExamTime)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            //SqlCommand cmd = new SqlCommand("Insert Into tblOtherDetails (LinkId,ExamDate,ExamTime,TransactionType) values (@LinkId,@ExamDate,@ExamTime,'Q')", conn);
            //cmd.CommandType = CommandType.Text;
            SqlCommand cmd = new SqlCommand("procInsertPersonal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
            cmd.Parameters.AddWithValue("@ExamTime", ExamTime);
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
    public string UpdateOtherQualification(string LinkId, int ExamDate, int ExamTime)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            //SqlCommand cmd = new SqlCommand("Update tblOtherDetails set ExamDate=@ExamDate,ExamTime=@ExamTime where LinkId=@LinkId", conn);
            //cmd.CommandType = CommandType.Text;
            SqlCommand cmd = new SqlCommand("procInsertPersonal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
            cmd.Parameters.AddWithValue("@ExamTime", ExamTime);
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
    public int GetFinalStudentStatus(string RegNo)
    {
        int Status = 0;
        try
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineErp"].ToString());
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from adminexam..studentview where RegisterId=@RegNo and Stud_Course_Status in ('A','T')", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Status = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Status;
        }
        catch
        {
            return Status;
        }
    }
    public int GetEntranceResult(string LinkId)
    {
        int Status = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblentranceresult where Linkid=@LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Status = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Status;
        }
        catch
        {
            return Status;
        }
    }
    public DateTime GetDOB(string LinkId)
    {
        DateTime DOB = DateTime.Now.AddYears(-15);
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) DOB from tblStudent where LinkId=@LinkId and Status='True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DOB = DateTime.Parse(dr[0].ToString());
            }
            conn.Close();
            return DOB;
        }
        catch
        {
            return DOB;
        }
    }
    public String GetIpAddress()
     {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                nic.OperationalStatus == OperationalStatus.Up)
            {
                return Convert.ToString(nic.GetPhysicalAddress());
            }
        }
        return null;
    }
    public int GetBachelorDegreeYear(string LinkId)
    {
        int BachelorPassedYear = 100;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select isnull(MIN(YearOfPass),100) from tblQualification where LinkId=@LinkId and Qualification='Bachelor degree'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BachelorPassedYear = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return BachelorPassedYear;
        }
        catch
        {
            return BachelorPassedYear;
        }
    }
    public int CountAdminCheckList(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblChecklistValues where ChkStudentId=@LinkId and MrktCreatedBy<>0", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public int CountFinanceCheckList(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblChecklistValues where ChkStudentId=@LinkId and AdmSubmitted<>0", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public int CountIroCheckList(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblChecklistValues where ChkStudentId=@LinkId and AdmSubmitted<>0", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public string InsertFeeGroup(string LinkId, string ObjectName)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFeeGroup", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ObjectName", ObjectName);
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
    public string UpdateIndexSetup(int IndexId, string MasterId, string Degree, string Term, string Schedule, int ScheduleDate, int ApprovedBy, DateTime ApprovedDate, int RevisedBy, DateTime? RevisedDate, string Remarks, int CreatedBy, bool Status, DateTime NextVerificationDate)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update tblIndexSetup set MasterId=@MasterId,ScheduleType=@ScheduleType,ScheduleDate=@ScheduleDate,TermId=@TermId,DegreeId=@DegreeId,ApprovedBy=@ApprovedBy,ApprovedDate=@ApprovedDate,RevisedBy=@RevisedBy,RevisedDate=@RevisedDate,Remarks=@Remarks,CreatedBy=@CreatedBy,Status=@Status,NextVerified=@NextVerified Where IndexId=@IndexId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IndexId", IndexId);
            cmd.Parameters.AddWithValue("@MasterId", MasterId);
            cmd.Parameters.AddWithValue("@DegreeId", Degree);
            cmd.Parameters.AddWithValue("@TermId", Term);
            cmd.Parameters.AddWithValue("@ScheduleType", Schedule);
            cmd.Parameters.AddWithValue("@ScheduleDate", ScheduleDate);
            cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy);
            cmd.Parameters.AddWithValue("@ApprovedDate", ApprovedDate);
            cmd.Parameters.AddWithValue("@RevisedBy", RevisedBy);
            cmd.Parameters.AddWithValue("@RevisedDate", RevisedDate);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@NextVerified", NextVerificationDate);
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
    public DataTable GetIndexDetails(int IndexId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@IndexId", IndexId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetIndexDetails]");
        return ds.Tables[0];
    }
    public string InsertOtherFollowup(int Id, bool PayMode, bool ProvCerificate, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into tblOtherDetails (LinkId,PayMode,ProvCerificate,CreatedBy,CreatedDate,Status,TransactionType) values ((select max (linkId) as LinkID from tblstudent Where Id=@Id),@PayMode,@ProvCerificate,@CreatedBy,getdate(),'True','FollowUp')", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@PayMode", PayMode);
            cmd.Parameters.AddWithValue("@ProvCerificate", ProvCerificate);
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
    public string InsertFollowupschedule(int Id, string day1,int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertFollowupschedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@followupdate", day1);
          
            cmd.Parameters.AddWithValue("@createdby", CreatedBy);
            cmd.Parameters.AddWithValue("@createdip", GetIpAddress());
          
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

    public string InsertVisitschedule(int Id, string day1, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnectionAttendance"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertVisitschedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@followupdate", day1);

            cmd.Parameters.AddWithValue("@createdby", CreatedBy);
            cmd.Parameters.AddWithValue("@createdip", GetIpAddress());

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

  

    public string GetArabNonArab(string CountryCode)
    {
        string ArabNonArab = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Category from tblNationality where NationalityCode=@CountryCode", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CountryCode", CountryCode);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ArabNonArab = dr[0].ToString();
            }
            conn.Close();
            return ArabNonArab;
        }
        catch
        {
            return ArabNonArab;
        }
    }
    public string GetRegNoOrg(string RegNo)
    {
        string RegNoOrg = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineErp"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) stud_id from adminexam..studentview where RegisterId=@RegNo", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RegNoOrg = dr[0].ToString();
            }
            conn.Close();
            return RegNoOrg;
        }
        catch
        {
            return RegNoOrg;
        }
    }
    public string GetPassword(string RegNo)
    {
        string RegNoOrg = "";
        try
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineErp"].ToString());
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) password from portal..students_login where login_id==@RegNo", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RegNoOrg = dr[0].ToString();
            }
            conn.Close();
            return RegNoOrg;
        }
        catch
        {
            return RegNoOrg;
        }
    }
    public DataSet GetUndertakingDetails(string LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetUndertakingDetails]");
        return ds;
    }
    public DataTable GetOrtDate(int Flag, string Value)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Value", Value);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetOrtDate]");
        return ds.Tables[0];
    }
    public DataTable GetStudentListForBulkMail(string FilterBy, string FilterValue,string schoolcode)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FilterBy", FilterBy);
            param[1] = new SqlParameter("@FilterValue", FilterValue);
            param[2] = new SqlParameter("@schoolcode", schoolcode);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[GetStudentListForBulkMail]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }
    public string UpdateChallengeExamResult(int sno, int LinkId, int Challenge_Ex_Id, DateTime ExamDate, decimal Marks, string Grade, int Createdby, int Id, Boolean Present, string Remarks)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateChallengeExamResult", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sno", sno);
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Challenge_Ex_Id", Challenge_Ex_Id);
            cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
            cmd.Parameters.AddWithValue("@Marks", Marks);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
            cmd.Parameters.AddWithValue("@Createddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Present", Present);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
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


    public DataTable CheckExists(int LinkID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkID", LinkID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[CheckChallenge]");
        return ds.Tables[0];
    }
    public string InsertChallengeExamResult(int sno, int LinkId, int Challenge_Ex_Id, DateTime ExamDate, decimal Marks, string Grade, int Createdby, int ID, Boolean Present, string Remarks)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertChallengeExamResult", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sno", sno);
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Challenge_Ex_Id", Challenge_Ex_Id);
            cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
            cmd.Parameters.AddWithValue("@Marks", Marks);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Createdby", Createdby);
            cmd.Parameters.AddWithValue("@Createddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Present", Present);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
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
    public string GetCMSMedia(string LinkId)
    {
        string CMSMedia = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MediaSource from tblStudent where linkId = @LinkId and Status = 'True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CMSMedia = dr[0].ToString();
            }
            conn.Close();
            return CMSMedia;
        }
        catch
        {
            return CMSMedia;
        }
    }
    public DataTable GetChallengeDetails(int LinkID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkID", LinkID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetChallengeDetails]");
        return ds.Tables[0];
    }
    public DataTable GetChallengeExamResults(int LinkID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkID", LinkID);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetChallengeExamResults]");
        return ds.Tables[0];
    }
    public string InsertMailLog(string LinkId, string MailStatus, string SMSStatus,string sms,string email)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertMailLog", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@MailStatus", MailStatus);
            cmd.Parameters.AddWithValue("@SMSStatus", SMSStatus);
            cmd.Parameters.AddWithValue("@sms", sms);
            cmd.Parameters.AddWithValue("@email", email);
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
    public int GetRegisterStudent(string MobileNo)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from tblStudent where MobileNo=@MobileNo and StudentStatus=4 and Status='True' and RegistrationNo is not null", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public int GetInterNationStudent(string LinkId)
    {
        int Count = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from tblstudent where LinkId=@LinkId and IsInternationalStudent='Yes'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Count = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return Count;
        }
        catch
        {
            return Count;
        }
    }
    public string InsertExistingStudentDetails(int LinkId, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
       string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
       string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
       string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
       string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
       string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion, string IsInternationalStudent)
    {
        try
        {
             string newlinkid;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertExistingStudentDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Linkid", LinkId);
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            cmd.Parameters.AddWithValue("@CallDate", CallDate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@ArabicFirstName", ArabicFisrtName);
            cmd.Parameters.AddWithValue("@ArabicMiddleName", ArabicMiddleName);
            cmd.Parameters.AddWithValue("@ArabicLastName", ArabicLastName);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@FormStatus", FormStatus);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@Comment", Comment);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ProspectStatus", ProspectStatus);
            cmd.Parameters.AddWithValue("@RefferedBy", RefferedBy);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", Email);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@PoBox", PoBox);
            cmd.Parameters.AddWithValue("@ArabNonArab", ArabNonArab);
            cmd.Parameters.AddWithValue("@ISEmployeed", ISEmployeed);
            cmd.Parameters.AddWithValue("@SchoolUniversity", SchoolUniversity);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@CallerCategory", CallerCategory);
            cmd.Parameters.AddWithValue("@MotherTongue", MotherTounge);
            cmd.Parameters.AddWithValue("@ProficiencyInEnglish", ProficiencyInEnglish);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@IsInternationalStudent", IsInternationalStudent);
            using (conn)
               cmd.ExecuteNonQuery();
            conn.Close();
            return "RegisterNo";
        }
        catch (Exception ex)
        {
            return "";
        }
    }


    public string InsertExistingStudentDetailsnew(int LinkId, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
   string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
   string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
   string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
   string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
   string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion, string IsInternationalStudent)
    {
        try
        {
            string newlinkid;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertExistingStudentDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Linkid", LinkId);
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            cmd.Parameters.AddWithValue("@CallDate", CallDate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@ArabicFirstName", ArabicFisrtName);
            cmd.Parameters.AddWithValue("@ArabicMiddleName", ArabicMiddleName);
            cmd.Parameters.AddWithValue("@ArabicLastName", ArabicLastName);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@FormStatus", FormStatus);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@Comment", Comment);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ProspectStatus", ProspectStatus);
            cmd.Parameters.AddWithValue("@RefferedBy", RefferedBy);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", Email);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@PoBox", PoBox);
            cmd.Parameters.AddWithValue("@ArabNonArab", ArabNonArab);
            cmd.Parameters.AddWithValue("@ISEmployeed", ISEmployeed);
            cmd.Parameters.AddWithValue("@SchoolUniversity", SchoolUniversity);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@CallerCategory", CallerCategory);
            cmd.Parameters.AddWithValue("@MotherTongue", MotherTounge);
            cmd.Parameters.AddWithValue("@ProficiencyInEnglish", ProficiencyInEnglish);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@IsInternationalStudent", IsInternationalStudent);
            using (conn)
                newlinkid = cmd.ExecuteScalar().ToString();
            conn.Close();
            return newlinkid;
        }
        catch (Exception ex)
        {
            return "";
        }
    }




    public decimal GetBudget(int CategoryId)
    {
        decimal Budget = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Budget from Tps..Fees_Category where Fees_Category_id=@CategoryId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Budget = decimal.Parse(dr[0].ToString());
            }
            conn.Close();
            return Budget;
        }
        catch
        {
            return Budget;
        }
    }
    public decimal GetFeesAmount(int FeeGroupId)
    {
        decimal FeesAmount = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select isnull(sum(Fees_Amount),0) as Fees_Amount from TPS..tbl_Fees_Group_Details where Fees_Group_Id=@FeeGroupId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FeeGroupId", FeeGroupId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FeesAmount = decimal.Parse(dr[0].ToString());
            }
            conn.Close();
            return FeesAmount;
        }
        catch
        {
            return FeesAmount;
        }
    }
    public decimal GetUsedFees(int CategoryId)
    {
        decimal UsedFees = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select isnull(sum(FeeWaiver),0) as FeeWaiver from tblFinance where FeeCategory=@CategoryId and IsTPS='True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UsedFees = decimal.Parse(dr[0].ToString());
            }
            conn.Close();
            return UsedFees;
        }
        catch
        {
            return UsedFees;
        }
    }
    public string InsertMultiStudentDetails(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertMultiStudentDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
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
    public string InsertMultiStudentDetails2(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertMultiStudentDetails2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
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
    public string DeleteTable(int Id, int Flag)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcDeleteProc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Flag", Flag);
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
    public string GetMobile(int LinkId)
    {
        string MobileNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MobileNo from tblstudent where LinkId=@LinkId and [Status]='True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MobileNo = dr[0].ToString();
            }
            conn.Close();
            return MobileNo;
        }
        catch
        {
            return MobileNo;
        }
    }
    public string GetEmail(int LinkId)
    {
        string MobileNo = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select EmailId from tblstudent where LinkId=@LinkId and [Status]='True'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MobileNo = dr[0].ToString();
            }
            conn.Close();
            return MobileNo;
        }
        catch
        {
            return MobileNo;
        }
    }
    // Changed for MQP Subject
    public string InsertMQPSubject(string LinkId, bool Subject1, bool Subject2, bool Subject3, bool Subject4, bool Subject5, bool Subject6, bool Subject7, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertMQPSubject", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Subject1", Subject1);
            cmd.Parameters.AddWithValue("@Subject2", Subject2);
            cmd.Parameters.AddWithValue("@Subject3", Subject3);
            cmd.Parameters.AddWithValue("@Subject4", Subject4);
            cmd.Parameters.AddWithValue("@Subject5", Subject5);
            cmd.Parameters.AddWithValue("@Subject6", Subject6);
            cmd.Parameters.AddWithValue("@Subject7", Subject7);
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
    public DataSet SetMQPSubject(int LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetMQPSubject]");
        return ds;
    }
    public string DeleteToefl(string Id)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from tblToefl where Id=@Id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "sucess";
        }
        catch
        {
            return "error";
        }
    }
    public string DeleteMath(string Id)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from tblMath where Id=@Id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "sucess";
        }
        catch
        {
            return "error";
        }
    }
    public string InsertMQPSubjectQ(string LinkId, bool Subject1, bool Subject2, bool Subject3, bool Subject4, bool Subject5, bool Subject6, bool Subject7, string Date1, string Date2, string Date3, string Date4, string Date5, string Date6, string Date7, string Time1, string Time2, string Time3, string Time4, string Time5, string Time6, string Time7, int CreatedBy)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcInsertMQPSubjectQ", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@Subject1", Subject1);
            cmd.Parameters.AddWithValue("@Subject2", Subject2);
            cmd.Parameters.AddWithValue("@Subject3", Subject3);
            cmd.Parameters.AddWithValue("@Subject4", Subject4);
            cmd.Parameters.AddWithValue("@Subject5", Subject5);
            cmd.Parameters.AddWithValue("@Subject6", Subject6);
            cmd.Parameters.AddWithValue("@Subject7", Subject7);
            cmd.Parameters.AddWithValue("@Date1", Date1);
            cmd.Parameters.AddWithValue("@Date2", Date2);
            cmd.Parameters.AddWithValue("@Date3", Date3);
            cmd.Parameters.AddWithValue("@Date4", Date4);
            cmd.Parameters.AddWithValue("@Date5", Date5);
            cmd.Parameters.AddWithValue("@Date6", Date6);
            cmd.Parameters.AddWithValue("@Date7", Date7);
            cmd.Parameters.AddWithValue("@Time1", Time1);
            cmd.Parameters.AddWithValue("@Time2", Time2);
            cmd.Parameters.AddWithValue("@Time3", Time3);
            cmd.Parameters.AddWithValue("@Time4", Time4);
            cmd.Parameters.AddWithValue("@Time5", Time5);
            cmd.Parameters.AddWithValue("@Time6", Time6);
            cmd.Parameters.AddWithValue("@Time7", Time7);
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
    public string InsertFS(string LinkId)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec GetFS @LinkId", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "sucess";
        }
        catch
        {
            return "error";
        }
    }
    public DataSet GetStudentDetails1(string LinkId)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", LinkId);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[GetStudentDetails1]");
        return ds;
    }
    public string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                nic.OperationalStatus == OperationalStatus.Up)
            {
                return Convert.ToString(nic.GetPhysicalAddress());
            }
        }
        return null;
    }
    public string InsertAdminCheckList(string LinkId, string ExamType, string ExamScore, string MathScore, string MathCrashCourse, string MathCrashCourseScore, string AIPC, string AIPCResult, bool IELP,
        string IELPResult, string FeeWaiverType, bool FeeWaiverProof, string FeeWaiverProofType, string FeeWaiverAmount, string TOC, string TOCAmount, string NoOfCourses, string VisaStatus,
        string HostelStatus, string AdminRemarks, string FinanceRemarks, string GeneralRemarks, int CreatedBy, string LoginIp)
    {
        try
        {
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("update [tblAdminCheckListLogs] set status='false' where linkid= @LinkId", conn1);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.AddWithValue("@LinkId", LinkId);
            using (conn1)
            cmd1.ExecuteNonQuery();
            conn1.Close();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into [tblAdminCheckListLogs] (LinkId, ExamType, ExamScore, MathScore, MathCrashCourse, MathCrashCourseScore, AIPC, AIPCResult, IELP, IELPResult, FeeWaiverType, FeeWaiverProof, FeeWaiverProofType, FeeWaiverAmount, TOC, TOCAmount, NoOfCourses, VisaStatus, HostelStatus,AdminRemarks,FinanceRemarks,GeneralRemarks,CreatedBy,CreatedDate,Status,LoginIP) values (@LinkId, @ExamType, @ExamScore, @MathScore, @MathCrashCourse, @MathCrashCourseScore, @AIPC, @AIPCResult, @IELP, @IELPResult, @FeeWaiverType, @FeeWaiverProof, @FeeWaiverProofType, @FeeWaiverAmount, @TOC, @TOCAmount, @NoOfCourses, @VisaStatus, @HostelStatus, @AdminRemarks, @FinanceRemarks, @GeneralRemarks, @CreatedBy, getdate(),'True',@LoginIP)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@LinkId", LinkId);
            cmd.Parameters.AddWithValue("@ExamType", ExamType);
            cmd.Parameters.AddWithValue("@ExamScore", ExamScore);
            cmd.Parameters.AddWithValue("@MathScore", MathScore);
            cmd.Parameters.AddWithValue("@MathCrashCourse", MathCrashCourse);
            cmd.Parameters.AddWithValue("@MathCrashCourseScore", MathCrashCourseScore);
            cmd.Parameters.AddWithValue("@AIPC", AIPC);
            cmd.Parameters.AddWithValue("@AIPCResult", AIPCResult);
            cmd.Parameters.AddWithValue("@IELP", IELP);
            cmd.Parameters.AddWithValue("@IELPResult", IELPResult);
            cmd.Parameters.AddWithValue("@FeeWaiverType", FeeWaiverType);
            cmd.Parameters.AddWithValue("@FeeWaiverProof", FeeWaiverProof);
            cmd.Parameters.AddWithValue("@FeeWaiverProofType", FeeWaiverProofType);
            cmd.Parameters.AddWithValue("@FeeWaiverAmount", FeeWaiverAmount);
            cmd.Parameters.AddWithValue("@TOC", TOC);
            cmd.Parameters.AddWithValue("@TOCAmount", TOCAmount);
            cmd.Parameters.AddWithValue("@NoOfCourses", NoOfCourses);
            cmd.Parameters.AddWithValue("@VisaStatus", VisaStatus);
            cmd.Parameters.AddWithValue("@HostelStatus", HostelStatus);
            cmd.Parameters.AddWithValue("@AdminRemarks", AdminRemarks);
            cmd.Parameters.AddWithValue("@FinanceRemarks", FinanceRemarks);
            cmd.Parameters.AddWithValue("@GeneralRemarks", GeneralRemarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@LoginIp", GetMacAddress());
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
    public string GetFileName(string UName)
    {
        string UDesc = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select top(1) FileName from tblUndertaking where UName=@UName", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UName", UName);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UDesc = dr[0].ToString();
            }
            conn.Close();
            return UDesc;
        }
        catch
        {
            return UDesc;
        }
    }
    public DataTable GetMouPercentage(int DegreeId, int TermId, int CategoryId)
    {
        DataTable MouPercentage = new DataTable();
        try
        {
            if (DegreeId == 8)
            {
                DegreeId = 6;
            }

            if (DegreeId == 7)
            {
                DegreeId = 1;
            } 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("  select 0 as 'SN','Select' as  FeeWaiverType,'0' as pp,'0' as ApprovedFund  union all select distinct 1 as 'SN', '0' as FeeWaiverType,'0' as pp,'0' as ApprovedFund union all select distinct 1 as 'SN', cast(gg.Percentage as varchar(16)) as FeeWaiverType, gg.Percentage as PP,ApproveFund from tblMOUCategoryFund gg inner join [TPS].[dbo].[tbl_Fee_Percentage_Master]cc on cc.Termid='" + TermId + "' and cc.Degreeid='" + DegreeId + "' and cc.Percentage=gg.Percentage   and Isintegratedonly='false' where CategoryId='" + CategoryId + "' and ayyear in ( select termyear from tblterm where termid='" + TermId + "') and gg.DegreeId='" + DegreeId + "' order by  SN,pp asc", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = null;
            da = new SqlDataAdapter(cmd.CommandText, conn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(MouPercentage);
            conn.Close();
            return MouPercentage;
        }
        catch
        {
            return MouPercentage;
        }
    }


    public DataTable GetMouPercentageintegrate(int DegreeId, int TermId, int CategoryId)
    {
        DataTable MouPercentage = new DataTable();
        try
        {
            if (DegreeId == 8)
            {
                DegreeId = 6;
            }

            if (DegreeId == 7)
            {
                DegreeId = 1;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
           // SqlCommand cmd = new SqlCommand("  select 0 as 'SN','Select' as  FeeWaiverType,'0' as pp,'0' as ApprovedFund union all select distinct 1 as 'SN', cast(Percentage as varchar(16)) as FeeWaiverType, Percentage as PP,ApproveFund from tblMOUCategoryFund where CategoryId='" + CategoryId + "' and ayyear in ( select termyear from tblterm where termid='" + TermId + "') and DegreeId=1 and   order by  SN,pp asc", conn);
            SqlCommand cmd = new SqlCommand("  select 0 as 'SN','Select' as  FeeWaiverType,'0' as pp,'0' as ApprovedFund  union all select distinct 1 as 'SN', '0' as FeeWaiverType,'0' as pp,'0' as ApprovedFund union all select distinct 1 as 'SN', cast(gg.Percentage as varchar(16)) as FeeWaiverType, gg.Percentage as PP,ApproveFund from tblMOUCategoryFund gg inner join [TPS].[dbo].[tbl_Fee_Percentage_Master]cc on cc.Termid='" + TermId + "' and cc.Degreeid= 1 and cc.Percentage=gg.Percentage   and Isintegratedonly='true' where CategoryId='" + CategoryId + "' and ayyear in ( select termyear from tblterm where termid='" + TermId + "') and gg.DegreeId='" + DegreeId + "' order by  SN,pp asc", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = null;
            da = new SqlDataAdapter(cmd.CommandText, conn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(MouPercentage);
            conn.Close();
            return MouPercentage;
        }
        catch
        {
            return MouPercentage;
        }
    }


    //public DataTable GetMouFund(int DegreeId, int TermId, int CategoryId, double Percentage)
    //{
    //    DataTable GetMouFund = new DataTable();
    //    try
    //    {
    //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand("select ApproveFund,dbo.[GETAVAILABLEFUND]('" + CategoryId + "','" + TermId + "','" + DegreeId + "','" + Percentage + "') from tblMOUCategoryFund where CategoryId='" + CategoryId + "' and TermId='" + TermId + "' and DegreeId='" + DegreeId + "' and Percentage='" + Percentage + "'", conn);
    //        cmd.CommandType = CommandType.Text;
    //        SqlDataAdapter da = null;
    //        da = new SqlDataAdapter(cmd.CommandText, conn);
    //        da.SelectCommand.ExecuteNonQuery();
    //        da.Fill(GetMouFund);
    //        conn.Close();
    //        return GetMouFund;
    //    }
    //    catch
    //    {
    //        return GetMouFund;
    //    }
    //}
    //modified by meena


    public DataTable GetMouFund(int DegreeId, int TermId, int CategoryId, double Percentage)
    {
        DataTable GetMouFund = new DataTable();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ApproveFund,dbo.[GETAVAILABLEFUND]('" + CategoryId + "','" + TermId + "','" + DegreeId + "','" + Percentage + "') from tblMOUCategoryFund where CategoryId='" + CategoryId + "' and ayyear in ( select top 1 termyear from cdb..tblterm where termid= '" + TermId + "') and DegreeId='" + DegreeId + "' and Percentage='" + Percentage + "'", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = null;
            da = new SqlDataAdapter(cmd.CommandText, conn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(GetMouFund);
            conn.Close();
            return GetMouFund;
        }
        catch
        {
            return GetMouFund;
        }
    }


    public decimal GetTotalFees(int DegreeId, int TermId, double Percentage)
    {
        DataTable GetMouFund = new DataTable();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TPSCON"].ToString());
            conn.Open();
            if (DegreeId == 8) DegreeId = 6;
            if (DegreeId == 7) DegreeId = 1;
            SqlCommand cmd = new SqlCommand("select top 1  dhs from  tbl_Fee_Percentage_Master where  Degreeid='" + DegreeId + "' and Termid='" + TermId + "'  and Percentage ='" + Percentage + "'", conn);
             cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = null;
            da = new SqlDataAdapter(cmd.CommandText, conn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(GetMouFund);
            conn.Close();
            return decimal.Parse(GetMouFund.Rows[0][0].ToString());
        }
        catch
        {
            return decimal.Parse(GetMouFund.Rows[0][0].ToString());
        }
    }
    public DataTable GetFinalFees(int DegreeId, string TermId ,string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@degreeid", DegreeId);
        param[1] = new SqlParameter("@term", TermId);
        param[2] = new SqlParameter("@schoolcode", schoolcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[DISPLAYFEEMAIN]");
        return ds.Tables[0];
    }

    public static int InsertCategory(String Category, String SubCategory, int CreatedId, bool IsActive, bool isMOU, string mac, bool issharjah)
    {
        try
        {
            Int32 newcatId = 0;
            // string sql = "  Insert into tblMOUCategory(Category,SubCategory,CreatedId,CreatedDate,Isactive, ISMOU, CreatedIp  ) values " +
            //              "  (@Category,@subcategory,@createdid,GETDATE(),@isactive, @Ismou, @Mac );" +
            //              "  SELECT CAST(scope_identity() AS int)";
            // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            // conn.Open();
            // SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[SP_GETMOUCATEGORY_DETAILS]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@subcategory", SubCategory);
            cmd.Parameters.AddWithValue("@createdid", CreatedId);
            cmd.Parameters.AddWithValue("@isactive", IsActive);
            cmd.Parameters.AddWithValue("@Ismou", isMOU);
            cmd.Parameters.AddWithValue("@Mac", mac);
            cmd.Parameters.AddWithValue("@issharjah", issharjah);
            newcatId = (Int32)cmd.ExecuteScalar();
            return (int)newcatId;
        }
        catch (Exception e)
        {
            return 0;
        }
    }


    //public static int check_mou_exist(int catid, int degreetypeid, int termid, string acyear, float percentage, double totalfund)
    //{
    //    try
    //    {
    //        Int32 newcatId = 0;
    //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand("[SP_INSERT_MOU_APPROVAl]", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@CatId", catid);
    //        cmd.Parameters.AddWithValue("@Degreeid", degreetypeid);
    //        cmd.Parameters.AddWithValue("@termid", termid);
    //        cmd.Parameters.AddWithValue("@acFyear", acyear);
    //        cmd.Parameters.AddWithValue("@percentage", percentage);
    //        cmd.Parameters.AddWithValue("@Totalfund", totalfund);
    //        newcatId = (Int32)cmd.ExecuteScalar();
    //        return (int)newcatId;
    //    }
    //    catch (Exception e)
    //    {
    //        return 0;
    //    }
    //}
    // updated by pratheeba on 20Feb2016 
 
    public DataTable check_mou_exist(int catid, int degreetypeid, float percentage , int yearId)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@catid", catid);
        param[1] = new SqlParameter("@degreetypeid", degreetypeid);
        param[2] = new SqlParameter("@percentage", percentage);
        param[3] = new SqlParameter("@yearId", yearId);
        DataSet ds = da.getDataByParam(param, "[SP_CHECKMOUEXIST]");
        return ds.Tables[0];
    }


    public string  InsertMouApproval(int sno, int empid, string mac)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
        conn.Open();
        SqlCommand cmd = new SqlCommand("[SP_INSERT_MOU_APPROVAl]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Sno", sno);
        cmd.Parameters.AddWithValue("@Approvedby", empid);
        cmd.Parameters.AddWithValue("@Mac", mac);
        using (conn)
            cmd.ExecuteNonQuery();
        conn.Close();
        return "0";
    }


    public string Insertdetailsmaster(int catid, int Degreetypeid, int termid, int AcadYrId, string acyear, float percentage, int stdalloted, int subcategoryid, double approvefund, int createdby, String CreatedIp, bool isactive, string fromyear, string Toyear, string filename , double Totalfund)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[SP_addDetailsmaster]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CatId", catid);
            cmd.Parameters.AddWithValue("@Degreeid", Degreetypeid);
            cmd.Parameters.AddWithValue("@termid", termid);
            cmd.Parameters.AddWithValue("@AcadyrId", AcadYrId);
            cmd.Parameters.AddWithValue("@Acyear", acyear);
            cmd.Parameters.AddWithValue("@percentage", percentage);
            cmd.Parameters.AddWithValue("@stdalloted", stdalloted);
            cmd.Parameters.AddWithValue("@SubcategoryId", subcategoryid);
            cmd.Parameters.AddWithValue("@ApprovedFund", approvefund);
            cmd.Parameters.AddWithValue("@Createdby", createdby);
            cmd.Parameters.AddWithValue("@CreatedIp", CreatedIp);
            cmd.Parameters.AddWithValue("@isactive", isactive);
            cmd.Parameters.AddWithValue("@FromYear", fromyear);
            cmd.Parameters.AddWithValue("@Toyear", Toyear);
            cmd.Parameters.AddWithValue("@FileName", filename);
            cmd.Parameters.AddWithValue("@TotalFund", Totalfund);

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


    public string InsertCpdCourseCalendar(string courseschedule, DateTime FromDate, DateTime Todate, string FromTime, string ToTime, bool Sunday, bool monday, bool Tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool finalize, string createdby, DateTime createdDate, string createdIp , string remarks, string Ayear, int semesterId , int termid)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[SP_ADD_COURSECALENDER]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Course_Schedule", courseschedule);
            cmd.Parameters.AddWithValue("@cs_Fromdate", FromDate);
            cmd.Parameters.AddWithValue("@cs_Todate", Todate);
            cmd.Parameters.AddWithValue("@fromtime", FromTime);
            cmd.Parameters.AddWithValue("@Totime", ToTime);
            cmd.Parameters.AddWithValue("@Sunday", Sunday);
            cmd.Parameters.AddWithValue("@Monday", monday);
            cmd.Parameters.AddWithValue("@Tuesday", Tuesday);
            cmd.Parameters.AddWithValue("@Wednesday", wednesday);
            cmd.Parameters.AddWithValue("@Thursday", thursday);
            cmd.Parameters.AddWithValue("@Friday", friday);
            cmd.Parameters.AddWithValue("@Saturday", saturday);
            cmd.Parameters.AddWithValue("@Finalize", finalize);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.Parameters.AddWithValue("@CreatedDate", createdDate);
            cmd.Parameters.AddWithValue("@CreatedIp", createdIp);
            cmd.Parameters.AddWithValue("@Remarks", remarks);
            cmd.Parameters.AddWithValue("@Ayear", Ayear);
            cmd.Parameters.AddWithValue("@semester_id", semesterId);
            cmd.Parameters.AddWithValue("@termid", termid);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "CalendarId";
        }
        catch (Exception e)
        {
            return "error";
        }
    }


    public DataTable getSubcategory(string category)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Category", category);
        // param[1] = new SqlParameter("@Category", Category);
        DataSet ds = da.getDataByParam(param, "[SP_MOUSUBCAT]");
        return ds.Tables[0];
    }

    public DataTable GetFundDetails(int catid)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Categoryid", catid);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[GetCategoryfund_1]");
            return ds.Tables[0];
        }
        catch
        { return null; }
    }



    public string UpdateCategory(Int32 Sno, Int32 categoryId, String Category, String SubCategory, Int32 acadyearId, string AcFyear, string AcTyear, Int32 degreeid, float percentage, float totalfund, float approvedfund, Int32 studalloted, string UpdatedId, bool isactive, bool ismou, bool isdetailsactive, DateTime Updateddate, int Renewal, bool issharjah)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("[UpdateCategoryDetails_test]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SNO", Sno);
            cmd.Parameters.AddWithValue("@categoryID", categoryId);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@SubCategory", SubCategory);
            cmd.Parameters.AddWithValue("@acadyear", acadyearId);
            cmd.Parameters.AddWithValue("@acFyear", AcFyear);
            cmd.Parameters.AddWithValue("@acTyear", AcTyear);
            cmd.Parameters.AddWithValue("@degreeId", degreeid);
            cmd.Parameters.AddWithValue("@percentage", percentage);
            cmd.Parameters.AddWithValue("@TotalFund", totalfund);
            cmd.Parameters.AddWithValue("@ApprovedFund", approvedfund);
            cmd.Parameters.AddWithValue("@studalloted", studalloted);
            cmd.Parameters.AddWithValue("@MAC", GetMacAddress());
            cmd.Parameters.AddWithValue("@updatedid", UpdatedId);
            cmd.Parameters.AddWithValue("@isactive", isactive);
            cmd.Parameters.AddWithValue("@ismou", ismou);
            cmd.Parameters.AddWithValue("@isdetailsactive", isdetailsactive);
            cmd.Parameters.AddWithValue("@renewal", Renewal);
            cmd.Parameters.AddWithValue("@Issharjah", issharjah);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "Result";
        }
        catch
        {
            return "error";
        }
    }


    public DataTable GetCategoryDetails()
    {
        try
        {
            //SqlParameter[] param = new SqlParameter[4];
            //param[0] = new SqlParameter("@Category", Category);
            //param[1] = new SqlParameter("@subcategory", SubCategory);
            //param[2] = new SqlParameter("@createdid", CreatedId);
            //param[3] = new SqlParameter("@isactive", IsActive);

            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam("[GetCategoryDetails]");
            return ds.Tables[0];
        }
        catch

        { return null; }
    }
    //public DataTable getcategorygrid(int Categoryid)
    //{
    //    DataAccessLayer da = new DataAccessLayer();
    //    SqlParameter[] param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@Categoryid", Categoryid);
    //    DataSet ds = da.getDataByParam(param, "GetCategoryGrid");
    //    return
    //    ds.Tables[0];

    //}

    public DataTable getcategorygrid(int sno, bool ismou)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Sno", sno);
        param[1] = new SqlParameter("@ismou", ismou);
        DataSet ds = da.getDataByParam(param, "[GetCategoryGrid_Test]");
        return ds.Tables[0];
    }


    public DataTable getToemailId()
    {
        DataAccessLayer da = new DataAccessLayer();
       // SqlParameter[] param = new SqlParameter[1];
        //param[0] = new SqlParameter("@empno", empno);
        DataSet ds = da.getDataByParam("[Sp_gettosendMailId]");
        return   ds.Tables[0];
    }

    public void Deletecategory(int Id)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@DetailsID", Id);       
        DataSet ds = da.getDataByParam(param, "DeleteCategory");

    } 

    public DataTable getcategory(string type)
    {
        
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@type", type);       
        DataSet ds = da.getDataByParam(param,"[GetCategory_test]");
        return ds.Tables[0];
    }


    public DataTable getscat(int catid)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Category_id", catid);        
        DataSet ds = da.getDataByParam(param, "[SP_MOUSUBCAT]");
        return ds.Tables[0];
    }

    public DataTable GetCategoryTerm()
    {
        try
        {
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam("[GetCatTerm]");
            return ds.Tables[0];
        }
        catch
        { return null; }
    }

    public DataTable GetAcademicYear()
    {
        try
        {
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam("[GetAcadYear]");
            return ds.Tables[0];
        }
        catch
        { return null; }
    }
   

    public DataTable getpercentage(int acyearid, int degid)
    {
        DataAccessLayer da = new DataAccessLayer();
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@acadyrId", acyearid);
        param[1] = new SqlParameter("@degreeid", degid);
        // param[1] = new SqlParameter("@Category", Category);
        DataSet ds = da.getDataByParam(param, "[sp_percentage]");
        return ds.Tables[0];
    }

    public DataTable getpercentage1()
    {
        DataAccessLayer da = new DataAccessLayer();
        //  SqlParameter[] param = new SqlParameter[2];
        //  param[0] = new SqlParameter("@acadyrId", acyearid);
        //  param[1] = new SqlParameter("@degreeid", degid);
        //  param[1] = new SqlParameter("@Category", Category);
        DataSet ds = da.getDataByParam("[Sp_SelPercentage]");
        return ds.Tables[0];
    }

    public DataTable GetCategoryDetails(string cattext, string subcatText)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Categorytext", cattext);
            param[1] = new SqlParameter("@Subcategorytext", subcatText);
            DataAccessLayer da = new DataAccessLayer();
            DataSet ds = da.getDataByParam(param, "[GetCategoryDetails_1]");
            return ds.Tables[0];
        }
        catch
        { return null; }
    }


    public string UpdateStudentDetailsMyCallnew(int Id, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
         string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
         string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
         string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
         string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
         string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion, string IsInternationalStudent, string Event, bool TOC, int AcademicYear, string Grade)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ProcUpdateStudentMyCallNew", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@RegNo", RegNo);
            cmd.Parameters.AddWithValue("@CallDate", CallDate);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@ArabicFirstName", ArabicFisrtName);
            cmd.Parameters.AddWithValue("@ArabicMiddleName", ArabicMiddleName);
            cmd.Parameters.AddWithValue("@ArabicLastName", ArabicLastName);
            cmd.Parameters.AddWithValue("@Nationality", Nationality);
            cmd.Parameters.AddWithValue("@AttendedBy", AttendedBy);
            cmd.Parameters.AddWithValue("@ForwardedTo", ForwardedTo);
            cmd.Parameters.AddWithValue("@FormStatus", FormStatus);
            cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
            cmd.Parameters.AddWithValue("@Comment", Comment);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@ProspectStatus", ProspectStatus);
            cmd.Parameters.AddWithValue("@RefferedBy", RefferedBy);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", Email);
            cmd.Parameters.AddWithValue("@CourseType", CourseType);
            cmd.Parameters.AddWithValue("@DegreeType", DegreeType);
            cmd.Parameters.AddWithValue("@MediaSource", MediaSource);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@PoBox", PoBox);
            cmd.Parameters.AddWithValue("@ArabNonArab", ArabNonArab);
            cmd.Parameters.AddWithValue("@ISEmployeed", ISEmployeed);
            cmd.Parameters.AddWithValue("@SchoolUniversity", SchoolUniversity);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Website", Website);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@CallerCategory", CallerCategory);
            cmd.Parameters.AddWithValue("@MotherTongue", MotherTounge);
            cmd.Parameters.AddWithValue("@ProficiencyInEnglish", ProficiencyInEnglish);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@IsInternationalStudent", IsInternationalStudent);
            cmd.Parameters.AddWithValue("@Event", Event);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@TOC", TOC);
            cmd.Parameters.AddWithValue("@AcademicYear", AcademicYear);
            cmd.Parameters.AddWithValue("@updatedip", GetMacAddress());



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
    public DataSet SetStudentDetailsUpdate(int Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@LinkId", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcSetStudentNew]");
        return ds;
    }
    public DataSet GetCounsilValues(string testcode)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@testcode", testcode);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_SetAptitudeCousil]");
        return ds;
    }

    public string UpdateApptitudeCounsel(string test_code, string remarks, string cdate, string createdBy, string flag)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertAptitudeCounsel", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@test_code", test_code);
            cmd.Parameters.AddWithValue("@remarks", remarks);
            cmd.Parameters.AddWithValue("@cdate", cdate);
            cmd.Parameters.AddWithValue("@createdBy", createdBy);
            cmd.Parameters.AddWithValue("@createdIp", GetMacAddress());
            cmd.Parameters.AddWithValue("@flag", flag);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "1";
        }
        catch
        {
            return "error";
        }
    }
    public DataTable SetDropdownListAstestcode(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@id", Id);
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcgetTestCodes]");
        return ds.Tables[0];
    }

    public DataTable getFollowuprecordcount(string FilterBy, string FilterValue, string EmpId, string FromDate, string ToDate, int pageno, int pagerow,string schoolcode)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@EmpId", EmpId);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@iPageNo", pageno);
        param[6] = new SqlParameter("@iPageRecords", pagerow);
        param[7] = new SqlParameter("@schoolcode", schoolcode);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetFollowUpList1newupdatedrowcount]");
        return ds.Tables[0];
    }
    public DataTable GetFollowUpDetails4(string FilterBy, string FilterValue, string EmpId, string FromDate, string ToDate,int pageno,int pagerow)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@FilterBy", FilterBy);
        param[1] = new SqlParameter("@FilterValue", FilterValue);
        param[2] = new SqlParameter("@EmpId", EmpId);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@iPageNo", pageno);
        param[6] = new SqlParameter("@iPageRecords", pagerow);

        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[ProcGetFollowUpList1newupdated]");
        return ds.Tables[0];
    }


    public DataTable StudentEntranceResult( string regno)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@regno", regno);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[sp_DisplayEntranceresults]");
        return ds.Tables[0];
    }
    public DataTable GetMouPercentagetoc(int DegreeId, int TermId, int CategoryId)
    {
        DataTable MouPercentage = new DataTable();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(" select 0 as 'SN','Select' as  FeeWaiverType,'0' as pp,'0' as ApprovedFund union all select distinct 1 as 'SN', cast(Percentage as varchar(16)) as FeeWaiverType, Percentage as PP,ApproveFund from tblMOUCategoryFund where Percentage <= 15 and  CategoryId='" + CategoryId + "' and TermId='" + TermId + "' and DegreeId='" + DegreeId + "' order by  SN,pp asc", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = null;
            da = new SqlDataAdapter(cmd.CommandText, conn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(MouPercentage);
            conn.Close();
            return MouPercentage;
        }
        catch
        {
            return MouPercentage;
        }
    }


        public string DeletePermanent(string empId,int linkid, string dremarks)
        {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@empid", empId);
        param[1] = new SqlParameter("@linkid", linkid);

        param[2] = new SqlParameter("@dremarks", dremarks);
        param[3] = new SqlParameter("@dip", GetMacAddress());
        DataAccessLayer da = new DataAccessLayer();
        DataSet ds = da.getDataByParam(param, "[sp_PermanentDelete]");
        return ds.Tables[0].Rows[0][0].ToString();
        }


       public string CheckTOCExists(int linkid)
       {
       try
         {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("select count(*) from tbltoc  where universityname <>'' and mqptoc='false' and linkid=" + linkid, conn);
                  cmd.CommandType = CommandType.Text;
                  string  toc=cmd.ExecuteScalar().ToString();               
                  conn.Close();
                  return toc;
          }
          catch
              {
                  return "Error";
              }
          }

          public DataTable GetFollowUpDetailsexisting(string FilterBy, string FilterValue, string EmpId)
          {
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@FilterBy", FilterBy);
              param[1] = new SqlParameter("@FilterValue", FilterValue);
              param[2] = new SqlParameter("@EmpId", EmpId);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[ProcGetFollowUpListexisting]");
              return ds.Tables[0];
          }
          public int IsFollowupschedule(int empid)
          {
              int RemainingToCheck = 0;

              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  SqlCommand cmd = new SqlCommand("[sp_followupschedule]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandTimeout = 0;
                  cmd.Parameters.AddWithValue("empid", empid);
                  SqlDataReader dr = null;
                  using (conn)
                  {
                      conn.Open();
                      dr = cmd.ExecuteReader();

                      if (dr.HasRows)
                      {
                          while (dr.Read())
                          {
                              RemainingToCheck = dr.GetInt32(0);
                          }
                      }
                  }

              }
              catch
              {

              }
              return RemainingToCheck;
          }




          public int IsVisitschedule(int empid)
          {
              int RemainingToCheck = 0;

              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  SqlCommand cmd = new SqlCommand("[sp_Visitschedule]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandTimeout = 0;
                  cmd.Parameters.AddWithValue("empid", empid);
                  SqlDataReader dr = null;
                  using (conn)
                  {
                      conn.Open();
                      dr = cmd.ExecuteReader();

                      if (dr.HasRows)
                      {
                          while (dr.Read())
                          {
                              RemainingToCheck = dr.GetInt32(0);
                          }
                      }
                  }

              }
              catch
              {

              }
              return RemainingToCheck;
          }


          public string UpdateFollowUpschedule(string Id)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("UpdateFollowUpschedule", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@Id", Id);
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



          public string UpdateVisitschedule(string Id)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("UpdateVisitschedule", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@Id", Id);
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


          public DataTable GetFollowupList(int EmpId)
          {
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@empId", EmpId);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[sp_GetFollowupList]");
              return ds.Tables[0];
          }

          public DataTable SetDropdownwithparam(int Flag, string Id)
          {
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Flag", Flag);
              param[1] = new SqlParameter("@Id", Id);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[ProcSetDropdownwithparam]");
              return ds.Tables[0];
          }

          public DataTable bindgraduategrid(int empid)
          {
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@empid", empid);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[sp_displayrecordsgraduate]");
              return ds.Tables[0];
          }

          public DataTable GettocFeeWaiverSelected(string LinkId)
          {
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@linkid", LinkId);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[sp_finaltoccheck]");
              return ds.Tables[0];
          }
          public DataTable GetIsFeewaiverdatebeyond(string LinkId)
          {
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@linkid", LinkId);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[sp_checkfeewaiver_beyondenrolldates]");
              return ds.Tables[0];
          }


          public DataTable GetIsFeewaiverAllow(string LinkId, string perc)
          {
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@linkid", LinkId);
              param[1] = new SqlParameter("@perc", perc);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[getcheckfeewaiverallow]");
              return ds.Tables[0];
          }

          public DataTable getcpdcourseSchedule()
          {
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam("SP_GET_CPDCOURSE_SCHEDULE");
              return ds.Tables[0];
          }

          public DataTable getcpdCourseCalendardetails()
          {
              try
              {
                  //SqlParameter[] param = new SqlParameter[2];
                  //param[0] = new SqlParameter("@Categorytext", cattext);
                  //param[1] = new SqlParameter("@Subcategorytext", subcatText);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam("[sp_getcpdCourseCalendardetails]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }


          public string UpdateCpdCourseCalendar(int calendarid, string courseschedule, DateTime FromDate, DateTime Todate, string FromTime, string ToTime, bool Sunday, bool monday, bool Tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool finalize, string createdby, DateTime createdDate, string createdIp , string remarks, string Ayear, int semesterId , int termid)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[SP_UPDATE_COURSECALENDER]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CalendarId", calendarid);
                  cmd.Parameters.AddWithValue("@Course_Schedule", courseschedule);
                  cmd.Parameters.AddWithValue("@cs_Fromdate", FromDate);
                  cmd.Parameters.AddWithValue("@cs_Todate", Todate);
                  cmd.Parameters.AddWithValue("@fromtime", FromTime);
                  cmd.Parameters.AddWithValue("@Totime", ToTime);
                  cmd.Parameters.AddWithValue("@Sunday", Sunday);
                  cmd.Parameters.AddWithValue("@Monday", monday);
                  cmd.Parameters.AddWithValue("@Tuesday", Tuesday);
                  cmd.Parameters.AddWithValue("@Wednesday", wednesday);
                  cmd.Parameters.AddWithValue("@Thursday", thursday);
                  cmd.Parameters.AddWithValue("@Friday", friday);
                  cmd.Parameters.AddWithValue("@Saturday", saturday);
                  cmd.Parameters.AddWithValue("@Finalize", finalize);
                  cmd.Parameters.AddWithValue("@CreatedBy", createdby);
                  cmd.Parameters.AddWithValue("@CreatedDate", createdDate);
                  cmd.Parameters.AddWithValue("@CreatedIp", createdIp);
                  cmd.Parameters.AddWithValue("@Remarks", remarks);
                  cmd.Parameters.AddWithValue("@Ayear", Ayear);
                  cmd.Parameters.AddWithValue("@Semester_Id", semesterId);
                  cmd.Parameters.AddWithValue("@termId", termid);


                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CalendarId";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }

          public DataTable getcalendarcourseshed(int CalendarId)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@CALENDARID", CalendarId);
              DataSet ds = da.getDataByParam(param, "[SP_GETCALENDAR_COURSESHED]");
              return ds.Tables[0];
          }

       
          public DataTable getcpdCourseCalendardetails(string shedcourse)
          {
              try
              {
                  SqlParameter[] param = new SqlParameter[1];
                  param[0] = new SqlParameter("@shedcourse", shedcourse);
                  //param[1] = new SqlParameter("@Subcategorytext", subcatText);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam(param, "[sp_getcpdCourseCalendardetails]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }

          public string InsertCpdcoursemangement(string Acadyear, string about, string minqualification, string CarrerOpp, string Coursecontents, string course_schedule, string Examination, string Course_fee, DateTime RegisterDate, string admission_req, string Refund_policy, string General_terms, string createdBy, string createdDate, string createdIp)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[tbl_Events_management]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@Acad_Year", Acadyear);
                  cmd.Parameters.AddWithValue("@About", about);
                  cmd.Parameters.AddWithValue("@Aud_min_qualify", minqualification);
                  cmd.Parameters.AddWithValue("@carrer_opp", CarrerOpp);
                  cmd.Parameters.AddWithValue("@course_contents", Coursecontents);
                  cmd.Parameters.AddWithValue("@course_sched", course_schedule);
                  cmd.Parameters.AddWithValue("@examination", Examination);
                  cmd.Parameters.AddWithValue("@course_fee", Course_fee);
                  cmd.Parameters.AddWithValue("@register_date", RegisterDate);
                  cmd.Parameters.AddWithValue("@admissions_req", admission_req);
                  cmd.Parameters.AddWithValue("@refund_policy", Refund_policy);
                  cmd.Parameters.AddWithValue("@general_terms", General_terms);
                  cmd.Parameters.AddWithValue("@createdby", createdBy);
                  cmd.Parameters.AddWithValue("@createdDate", createdDate);
                  cmd.Parameters.AddWithValue("@createdIp", createdIp);

                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CalendarId";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }

          public string Remove_CalendarScheduleCourse(int calendarid)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[SP_REMOVE_COURSECALENDER]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@Calendar_ID", calendarid);
                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CalendarId";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }



          public string Finalize_CalendarScheduleCourse(int calendarid)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[SP_FINALIZE_COURSESHED]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CalendarId", calendarid);
                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CalendarId";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }


          public DataTable getcpdCoursemanagement()
          {
              try
              {
                  //  SqlParameter[] param = new SqlParameter[1];
                  //  param[0] = new SqlParameter("@shedcourse", shedcourse);
                  //param[1] = new SqlParameter("@Subcategorytext", subcatText);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam("[SP_CPD_COURSEMANAGEMENT]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }

          public string InsertCpdcoursemangement(string Acadyear, string about, string courseintro, string minqualification, string CarrerOpp, string Coursecontents, string course_schedule, string Examination, string Course_fee, string RegisterDate, string admission_req, string Refund_policy, string General_terms, string createdBy, DateTime createdDate, string createdIp, string schedulecourse, string datedetails, string tpscoursefee, int courseshedId, int coursefeeId)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[SP_INSERT_CPDCOURSE_MANAGEMENT]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@Acad_Year", Acadyear);
                  cmd.Parameters.AddWithValue("@About", about);
                  cmd.Parameters.AddWithValue("@CourseIntro", courseintro);
                  cmd.Parameters.AddWithValue("@Aud_min_qualify", minqualification);
                  cmd.Parameters.AddWithValue("@carrer_opp", CarrerOpp);
                  cmd.Parameters.AddWithValue("@course_contents", Coursecontents);
                  cmd.Parameters.AddWithValue("@course_sched", course_schedule);
                  cmd.Parameters.AddWithValue("@examination", Examination);
                  cmd.Parameters.AddWithValue("@course_fee", Course_fee);
                  cmd.Parameters.AddWithValue("@register_date", RegisterDate);
                  cmd.Parameters.AddWithValue("@admissions_req", admission_req);
                  cmd.Parameters.AddWithValue("@refund_policy", Refund_policy);
                  cmd.Parameters.AddWithValue("@general_terms", General_terms);
                  cmd.Parameters.AddWithValue("@createdby", createdBy);
                  cmd.Parameters.AddWithValue("@createdDate", createdDate);
                  cmd.Parameters.AddWithValue("@createdIp", createdIp);
                  cmd.Parameters.AddWithValue("@schedulecourse", schedulecourse);
                  cmd.Parameters.AddWithValue("@datedetails", datedetails);
                  cmd.Parameters.AddWithValue("@tpscoursefee", tpscoursefee);
                  cmd.Parameters.AddWithValue("@courseShedId", courseshedId);
                  cmd.Parameters.AddWithValue("@courseFeeId", coursefeeId);

                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CalendarId";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }

          public string Remove_CourseManagement(int CPDid)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[sp_Remove_CourseManagement]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CPDid ", CPDid);
                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CPDid";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }

          public string Finalize_CPDManagement(int CPDid)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[SP_FINALIZE_CPDMANAGEMENT]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CPDid", CPDid);
                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CalendarId";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }


          public string UpdateCpdManagement(int CPDid, string Acadyear, string about, string courseintro, string minqualification, string CarrerOpp, string Coursecontents, string course_schedule, string Examination, string Course_fee, DateTime RegisterDate, string admission_req, string Refund_policy, string General_terms, string createdBy, DateTime createdDate, string createdIp, string schedulecourse, string Datedetails, string tpscoursefee, int courseshedId, int courseFeeId)
          {
              try
              {
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("[SP_UPDATE_CPDCOURSE_MANAGEMENT]", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CPDid", CPDid);
                  cmd.Parameters.AddWithValue("@Acad_Year", Acadyear);
                  cmd.Parameters.AddWithValue("@About", about);
                  cmd.Parameters.AddWithValue("@CourseIntro", courseintro);
                  cmd.Parameters.AddWithValue("@Aud_min_qualify", minqualification);
                  cmd.Parameters.AddWithValue("@carrer_opp", CarrerOpp);
                  cmd.Parameters.AddWithValue("@course_contents", Coursecontents);
                  cmd.Parameters.AddWithValue("@course_sched", course_schedule);
                  cmd.Parameters.AddWithValue("@examination", Examination);
                  cmd.Parameters.AddWithValue("@course_fee", Course_fee);
                  cmd.Parameters.AddWithValue("@register_date", RegisterDate);
                  cmd.Parameters.AddWithValue("@admissions_req", admission_req);
                  cmd.Parameters.AddWithValue("@refund_policy", Refund_policy);
                  cmd.Parameters.AddWithValue("@general_terms", General_terms);
                  cmd.Parameters.AddWithValue("@createdby", createdBy);
                  cmd.Parameters.AddWithValue("@createdDate", createdDate);
                  cmd.Parameters.AddWithValue("@createdIp", createdIp);
                  cmd.Parameters.AddWithValue("@Schedulecourse", schedulecourse);
                  cmd.Parameters.AddWithValue("@Datedetails", Datedetails);
                  cmd.Parameters.AddWithValue("@tpscoursefee", tpscoursefee);
                  cmd.Parameters.AddWithValue("@courseshedId", courseshedId);
                  cmd.Parameters.AddWithValue("@courseFeeId", courseFeeId);
                  using (conn)
                      cmd.ExecuteNonQuery();
                  conn.Close();
                  return "CPDid";
              }
              catch (Exception e)
              {
                  return "error";
              }
          }

          public DataTable getCPDEdit(int CPDid)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@CPDid", CPDid);
              DataSet ds = da.getDataByParam(param, "[SP_GETEDIT_CPDMANGEMENT]");
              return ds.Tables[0];
          }

          public DataTable GetCourseFee(string Acyear)
          {
              try
              {
                  DataAccessLayer da = new DataAccessLayer();
                  SqlParameter[] param = new SqlParameter[1];
                  param[0] = new SqlParameter("@Acyear", Acyear);
                  DataSet ds = da.getDataByParam(param,"[SP_COURSE_FEE]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }


          public DataTable InsertStudentreversal(int id, string remarks, int userid)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[4];
              param[0] = new SqlParameter("@id", id);
              param[1] = new SqlParameter("@remarks", remarks);
              param[2] = new SqlParameter("@createdip", GetMacAddress());
              param[3] = new SqlParameter("@createdby", userid);
              DataSet ds = da.getDataByParam(param, "[sp_studentdetails_correction]");
              return ds.Tables[0];
          }
          public DataTable ISMOUNOUPercExist(int submouid, string perc, int degreeid, int termid)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[4];
              param[0] = new SqlParameter("@submouid", submouid);
              param[1] = new SqlParameter("@perc", perc);
              param[2] = new SqlParameter("@degreeid", degreeid);
              param[3] = new SqlParameter("@termid", termid);
              DataSet ds = da.getDataByParam(param, "[sp_CheckMouNoNmouPercExists]");
              return ds.Tables[0];
          }

          public DataTable getTotalFund (int subcatid)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Subcatid", subcatid);
              DataSet ds = da.getDataByParam(param, "[SP_GETTOTALFUND]");
              return ds.Tables[0];
          }


          public DataTable GetSemester(string AYId)
          {             
              //parameter added by shihab to resolve the web error.
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@AYEAR", AYId);
              DataSet ds = da.getDataByParam(param, "SP_GETSEMESTER");
              return ds.Tables[0];
          }

          public DataTable getschedulecourse(int Semester_Id)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Semester_Id", Semester_Id);
              DataSet ds = da.getDataByParam(param, "[SP_GETSCHEDULECOURSE]");
              return ds.Tables[0];
          }

          public DataTable getFaculty(int Semester_Id)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Semester_Id", Semester_Id);
              DataSet ds = da.getDataByParam(param, "[SP_GETFACULTY]");
              return ds.Tables[0];
          }

          public DataTable GetYear()
          {
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam("[SP_GETACADYEAR]");
              return ds.Tables[0];
          }

          public DataTable getTermName(string Acadyear)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@ACYear",Acadyear);
              DataSet ds = da.getDataByParam(param, "[SP_GETTERMNAME]");
              return ds.Tables[0];
          }

          public DataTable getMaxStudents(int termid, string courseschedule)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Termid", termid );
              param[1] = new SqlParameter("@Course_Schedule", courseschedule);
              DataSet ds = da.getDataByParam(param, "SP_MAX_SEATS");
              return ds.Tables[0];
          }

          public DataTable getMinStudents(int termid, string courseschedule)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Termid", termid);
              param[1] = new SqlParameter("@Course_Schedule", courseschedule);
              DataSet ds = da.getDataByParam(param, "SP_MIN_SEATS");
              return ds.Tables[0];
          }


          public DataTable getCPDTypes()
          {
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam("SP_GETCPDTYPES");
              return ds.Tables[0];
          }


          public static int Insertcpdmasterdetails(string acadyearid, int termid, int semesterId, int courseId, int FacultyId, int targetstudents, int achievedstudents)
          {
              try
              {
                  Int32 MasterId = 0;
                  string sql = "Sp_INSERT_CPDMASTER_DETAILS";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@AcadyearId", acadyearid);
                  cmd.Parameters.AddWithValue("@Termid", termid);
                  cmd.Parameters.AddWithValue("@semesterId", semesterId);
                  cmd.Parameters.AddWithValue("@courseId", courseId);
                  cmd.Parameters.AddWithValue("@facultyId", FacultyId);
                  cmd.Parameters.AddWithValue("@target_students", targetstudents);
                  cmd.Parameters.AddWithValue("@Achived_students", achievedstudents);

                  MasterId = (Int32)cmd.ExecuteScalar();
                  return (int)MasterId;
              }
              catch (Exception e)
              {
                  return 0;
              }
          }



          public DataTable ShowCPDMasterDetails()
          {
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam("SP_SHOW_CPDACTIVITIES");
              return ds.Tables[0];
          }

          public DataTable ShowCPDStatus()
          {
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam("SP_GETSTATUS");
              return ds.Tables[0];
          }

          public DataTable ShowCPDResponsibility()
          {
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam("SP_GETRESPONSIBILITY");
              return ds.Tables[0];
          }



          public static int InsertCpdSubmasterDetails(int master_id, string Activities, int Status_Id, int Response_id, string Enteredby, string EnteredIp, int cpdtype)
          {
              try
              {
                  Int32 SubmasterId = 0;
                  string sql = "SP_INSERT_CPD_SUBMASTER_DETAILS";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@Master_Id", master_id);
                  cmd.Parameters.AddWithValue("@Activities", Activities);
                  cmd.Parameters.AddWithValue("@Status_Id", Status_Id);
                  cmd.Parameters.AddWithValue("@Response_Id", Response_id);
                  cmd.Parameters.AddWithValue("@Enteredby", Enteredby);
                  cmd.Parameters.AddWithValue("@EnteredIp", EnteredIp);
                  cmd.Parameters.AddWithValue("@Cpdtype", cpdtype);
                  SubmasterId = (Int32)cmd.ExecuteScalar();
                  return (int)SubmasterId;
              }
              catch (Exception e)
              {
                  return 0;
              }
           }


          public DataTable getcpdmasterdetailsgrid()
          {
              try
              {                 
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam("[SP_GETMASTER_DETAILS]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }


          public DataTable GetSemesterCPD(string AYEAR)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@AYEAR", AYEAR);
              DataSet ds = da.getDataByParam(param, "SP_GETSEMESTER");
              return ds.Tables[0];
          }
          public DataTable getCourseFeeDetails(int CourseFeeId)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@FEEID", CourseFeeId);
              DataSet ds = da.getDataByParam(param, "[SP_COURSEFEE_DETAILS]");
              return ds.Tables[0];
          }

          public DataTable GetMOUBalance(int SubcatId, string ayyear, int degreetypeId)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@Subcategory", SubcatId);
              param[1] = new SqlParameter("@ayyear", ayyear);
              param[2] = new SqlParameter("@DegreeTypeID", degreetypeId);

              DataSet ds = da.getDataByParam(param, "[SP_MOU_BALANCE]");
              return ds.Tables[0];
          }

          public static float Updatenewtotalfund(int SubCategoryid, float totalfund)
          {
              try
              {
                  float totalfund1 = 0;
                  string sql = "SP_UPDATENEWTOTALFUND";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@SUBCATEGORYID", SubCategoryid);
                  cmd.Parameters.AddWithValue("@totalFund", totalfund);
                  totalfund1 = (float)cmd.ExecuteScalar();
                  return (float)totalfund1;
              }
              catch (Exception e)
              {
                  return 0;
              }
          }

          public DataTable getupdatedtotalfund(int subcategoryId)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@subcategoryId", subcategoryId);
              DataSet ds = da.getDataByParam(param, "[SP_getUpdatedTotalFund]");
              return ds.Tables[0];
          }


          // Added by Pratheeba N on 16Feb2016

          public DataTable GetPercentageamount(int Degreeid, string percentage,string ayyear)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@DEGREEID", Degreeid);
              param[1] = new SqlParameter("@PERCENTAGE", percentage);
              param[2] = new SqlParameter("@ayyear",ayyear);
              DataSet ds = da.getDataByParam(param, "[SP_GETPERCENTAGE_AMOUNT]");
              return ds.Tables[0];
          }

          //Added By Ms.Pratheeba For changeGroupname page  on 01Feb2016

          public DataTable GetMarktingActiveEmployee()
          {
              try
              {
                  //SqlParameter[] param = new SqlParameter[2];
                  //param[0] = new SqlParameter("@Categorytext", cattext);
                  //param[1] = new SqlParameter("@Subcategorytext", subcatText);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam("[SP_GETMARKETING_ACTIVE_EMP]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }

          public DataTable GetCurrentGroup(string Empid)
          {
              try
              {
                  SqlParameter[] param = new SqlParameter[1];
                  param[0] = new SqlParameter("@EMPID", Empid);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam(param, "[SP_GETCURRENTGROUP]");
                  return ds.Tables[0];
              }
              catch
              {
                  return null;
              }
          }

          public DataTable GetActiveEMSGroupNationality()
          {
              try
              {
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam("[SP_GETEMSACTIVENATION]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }

          public DataTable GetActiveEMSState()
          {
              try
              {
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam("[SP_GETEMSACTIVESTATE]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }


          public static int UpdateGroupname(int Empid, string groupname, int stateId, bool followupmail, bool ReportAccess, string modifiedby, string modifiedIp)
          {
              try
              {
                  int id = 0;
                  string sql = "SP_UPDATEGROUP_NAME";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@EMPID", Empid);
                  cmd.Parameters.AddWithValue("@GROUPNAME", groupname);
                  cmd.Parameters.AddWithValue("@STATEID", stateId);
                  cmd.Parameters.AddWithValue("@FOLLOWUPMAIL", followupmail);
                  cmd.Parameters.AddWithValue("@REPORTACCESS", ReportAccess);
                  cmd.Parameters.AddWithValue("@MODIFIEDBY", modifiedby);
                  cmd.Parameters.AddWithValue("@MODIFIEDIP", modifiedIp);
                  id = (int)cmd.ExecuteScalar();
                  return (int)Empid;
              }
              catch (Exception e)
              {
                  return 0;
              }
          }

          //Added by Ms.Pratheeba For change User  Page on 01Feb2016

          public DataTable GetMarktingActiveToEmployee(int EmpId)
          {
              try
              {
                  SqlParameter[] param = new SqlParameter[1];
                  param[0] = new SqlParameter("@EMPID", EmpId);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam(param, "[SP_GETMARKETINGTOEMPLOYEE]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }


          public DataTable FillGridMarketingStudents(int EmpId)
          {
              try
              {
                  SqlParameter[] param = new SqlParameter[1];
                  param[0] = new SqlParameter("@EMPID", EmpId);
                  DataAccessLayer da = new DataAccessLayer();
                  DataSet ds = da.getDataByParam(param, "[SP_GETMARKETINGSTUDENTS]");
                  return ds.Tables[0];
              }
              catch
              { return null; }
          }


          //Added by pratheeba N on 22Feb2016

          public DataTable getincrFromyear(int sno)
          {
              DataAccessLayer da = new DataAccessLayer();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Sno", sno);
              DataSet ds = da.getDataByParam(param, "[SP_GETINCRYEAR]");
              return ds.Tables[0];
          }


         //Added by pratheeba N on 29Feb2016 for page changeuser.aspx 
          public static int Transferusername(int FromId, int toempid)
          {
              try
              {
                  Int32 MasterId;
                  string sql = "[sp_ChangerecordsEmscms]";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@fromempid", FromId);
                  cmd.Parameters.AddWithValue("@toempid", toempid);
                  MasterId = (Int32)cmd.ExecuteScalar();
                  return (int)MasterId;
              }
              catch (Exception e)
              {
                  return 0;
              }
          }
 //Added By Shihab on 30-MAR-2016.
          public int InsertAgentDetails(string AgencyName, string AgentName,string State,int Country,string Remarks,
              string Phone, string Email,string Website,string DateofAgreement,string Validity,int Target, int UserId)
          {
              try
              {
                  Int32 count = 0;
                  string sql = "Sp_InsertAgentDetails";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@AgencyName", AgencyName);
                  cmd.Parameters.AddWithValue("@AgentName", AgentName);
                  cmd.Parameters.AddWithValue("@State", State);
                  cmd.Parameters.AddWithValue("@Country", Country);
                  cmd.Parameters.AddWithValue("@Remarks", Remarks);
                  cmd.Parameters.AddWithValue("@Phone", Phone);
                  cmd.Parameters.AddWithValue("@Email", Email);
                  cmd.Parameters.AddWithValue("@Website", Website);
                  cmd.Parameters.AddWithValue("@DateofAgreement", DateofAgreement);
                  cmd.Parameters.AddWithValue("@Validity", Validity);
                  cmd.Parameters.AddWithValue("@Target", Target);
                  cmd.Parameters.AddWithValue("@CreatedBy", UserId);
                  cmd.Parameters.AddWithValue("@CreatedIp", GetIpAddress());
                  cmd.Parameters.AddWithValue("@CreatedMacAddress", GetMacAddress());
                  count = (Int32)cmd.ExecuteNonQuery();
                  return (int)count;
              }
              catch (Exception e)
              {
                  return 0;
              }
          }

          public DataTable GetAgentDetails(int Id, string Operation)
          {

              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Id", Id);
              param[1] = new SqlParameter("@Operation", Operation);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[Sp_GetAgentDetails]");
              return ds.Tables[0];
          }

          public int UpdateAgentDetails(int AgentId, string AgencyName, string AgentName, string State, int Country, string Remarks,
              string Phone, string Email, string Website, string DateofAgreement, string Validity, int Target, int UserId, string Operation)
          {
              try
              {
                  Int32 count = 0;
                  string sql = "Sp_UpdateAgentDetails";
                  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
                  conn.Open();
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@AgentId", AgentId);
                  cmd.Parameters.AddWithValue("@AgencyName", AgencyName);
                  cmd.Parameters.AddWithValue("@AgentName", AgentName);
                  cmd.Parameters.AddWithValue("@State", State);
                  cmd.Parameters.AddWithValue("@Country", Country);
                  cmd.Parameters.AddWithValue("@Remarks", Remarks);
                  cmd.Parameters.AddWithValue("@Phone", Phone);
                  cmd.Parameters.AddWithValue("@Email", Email);
                  cmd.Parameters.AddWithValue("@Website", Website);
                  cmd.Parameters.AddWithValue("@DateofAgreement", DateofAgreement);
                  cmd.Parameters.AddWithValue("@Validity", Validity);
                  cmd.Parameters.AddWithValue("@Target", Target);
                  cmd.Parameters.AddWithValue("@ModifiedBy", UserId);
                  cmd.Parameters.AddWithValue("@ModifiedIp", GetIpAddress());
                  cmd.Parameters.AddWithValue("@ModifiedMacAddress", GetMacAddress());
                  cmd.Parameters.AddWithValue("@Operation", Operation);
                
                  count = (Int32)cmd.ExecuteNonQuery();
                  return (int)count;
              }
              catch (Exception e)
              {
                  return 0;
              }
          }

   public DataTable GetMediaSource(int Id,string MediaSource, string Operation)
          {

              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@Id", Id);
              param[1] = new SqlParameter("@MediaSource", MediaSource);
              param[2] = new SqlParameter("@Operation", Operation);
              DataAccessLayer da = new DataAccessLayer();
              DataSet ds = da.getDataByParam(param, "[Sp_GetMediaSource]");
              return ds.Tables[0];
          }

   public int InsertBoardName(string BoardName, bool Active, int UserId)
   {
       try
       {
           Int32 count = 0;
           string sql = "Sp_InsertBoardName";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@BoardName", BoardName);
           cmd.Parameters.AddWithValue("@Active", Active);
           cmd.Parameters.AddWithValue("@CreatedBy", UserId);
           cmd.Parameters.AddWithValue("@CreatedIPAddress", GetIpAddress());
           cmd.Parameters.AddWithValue("@CreatedMacAddress", GetMacAddress());
           count = (Int32)cmd.ExecuteNonQuery();
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }

   public DataTable GetBoardName(int BoardId, string Operation)
   {

       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@BoardId", BoardId);
       param[1] = new SqlParameter("@Operation", Operation);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[Sp_GetBoardName]");
       return ds.Tables[0];
   }

   public int UpdateBoardName(int BoardId, string BoardName, bool Active, int UserId)
   {
       try
       {
           Int32 count = 0;
           string sql = "Sp_UpdateBoardName";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@BoardId", BoardId);
           cmd.Parameters.AddWithValue("@BoardName", BoardName);
           cmd.Parameters.AddWithValue("@Active", Active);
           cmd.Parameters.AddWithValue("@ModifiedBy", UserId);
           cmd.Parameters.AddWithValue("@ModifiedIPAddress", GetIpAddress());
           cmd.Parameters.AddWithValue("@ModifiedMacAddress", GetMacAddress());
           count = (Int32)cmd.ExecuteNonQuery();
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }

   //Added By Shihab on 06-MAR-2016.
   //To get Program by link id with term greater than or equal to May-2016 (53). 
   public int GetProgramByLinkId(int LinkId)
   {
       int Count = 0;
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@LinkId", LinkId);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_GetProgramByLinkId]");
       Count = ds.Tables[0].Rows.Count;
       return Count;
   }

   public DataTable GetCourseForSCS(int TermId, string DegreeType, string CddCode = null)
   {
       SqlParameter[] param = new SqlParameter[3];
       param[0] = new SqlParameter("@TermId", TermId);
       param[1] = new SqlParameter("@DegreeType", DegreeType);
       param[2] = new SqlParameter("@CddCode", CddCode);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_GetCourseForSCS]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }

   public DataTable GetExistSCSProgramCourses(int LinkId)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@LinkId", LinkId);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_GetSCSProgramCourses]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }

   public int InsertSCSProgramCourses(String xmlData)
   {
       try
       {
           Int32 count = 0;
           string sql = "sp_InsertSCSProgramCourses";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@xmlString", xmlData);

           count = (Int32)cmd.ExecuteNonQuery();
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }

   public int DeleteSCSProgramCourses(int LinkId, string Operation)
   {
       try
       {
           Int32 count = 0;
           string sql = "sp_DeleteSCSProgramCourses";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LinkId", LinkId);
           cmd.Parameters.AddWithValue("@Operation", Operation);

           count = (Int32)cmd.ExecuteNonQuery();
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }

   //Added by SHIHAB 29-MAR-2016 
   //Summary : To Sharjah HRD

   public int InsertSharjahHRD(string txtSharjahHRD, bool Active, int UserId)
   {
       try
       {
           Int32 count = 0;
           string sql = "Sp_InsertSharjahHRD";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@SHJSubcategory", txtSharjahHRD);
           cmd.Parameters.AddWithValue("@Isactive", Active);
           cmd.Parameters.AddWithValue("@CreatedBy", UserId);
           cmd.Parameters.AddWithValue("@CreatedIPAddress", GetIpAddress());
           count = (Int32)cmd.ExecuteNonQuery();
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }


   public DataTable GetCOECReportsList(int createdby)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@createdby", createdby);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_getCoecReportsMaster]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }
   public DataTable GetCOECReportsListcount(int createdby)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@createdby", createdby);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_GetTotalCOECreports]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }
   public int SaveEmailSendingLog(string ToAddress, string FromAddress, string Subject, string BodyDesc, int CreatedBy, string Operation , string CC)
   {
       try
       {
           Int32 count = 0;
           string sql = "Sp_SaveEmailSendingLog";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ToAddress", ToAddress);
           cmd.Parameters.AddWithValue("@FromAddress", FromAddress);
           cmd.Parameters.AddWithValue("@Subject", Subject);
           cmd.Parameters.AddWithValue("@BodyDesc", BodyDesc);
           cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedIP", GetIpAddress());
           cmd.Parameters.AddWithValue("@Operation", Operation);
           cmd.Parameters.AddWithValue("@CC", CC);
           count = (Int32)cmd.ExecuteNonQuery();
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }

   public DataTable GetCOECReportsMailLogs(int createdby,int operation)
   {
       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@createdby", createdby);
       param[1] = new SqlParameter("@operation", operation);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_ViewCOECMAilLogs]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }


   public DataTable InsertGenerateInputs(int Prevterm, int term, int userid)
   {
       SqlParameter[] param = new SqlParameter[4];
       param[0] = new SqlParameter("@prevterm", Prevterm);
       param[1] = new SqlParameter("@term", term);
       param[2] = new SqlParameter("@ip", GetMacAddress());
       param[3] = new SqlParameter("@id", userid);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_InsertCOECGeneratedInput]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }


   public DataTable InsertCOECnationwise_Tilldatesummery(int eyear, int bbaweekdaytotal, int bbaweekendtotal, int mbaweekdaytotal, int mbaweekendtotal, string asofDate, int createdby, string operation, string term)
   {
       SqlParameter[] param = new SqlParameter[10];
       param[0] = new SqlParameter("@EYear", eyear);
       param[1] = new SqlParameter("@BBaweekday_Total", bbaweekdaytotal);
       param[2] = new SqlParameter("@BBaweekend_Total", bbaweekendtotal);
       param[3] = new SqlParameter("@MBaweekday_Total", mbaweekdaytotal);
       param[4] = new SqlParameter("@MBaweekend_Total", mbaweekendtotal);
       param[5] = new SqlParameter("@asofdate", asofDate);
       param[6] = new SqlParameter("@createdby", createdby);
       param[7] = new SqlParameter("@operation", operation);
       param[8] = new SqlParameter("@termname", term);
       param[9] = new SqlParameter("@createdip", GetMacAddress());
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_InsertCOECnationwise_Tilldatesumm]");

       if (ds != null)
           return ds.Tables[0];
       else
           return null;
   }

   public DataTable InsertStudentMailVerifyLogs(int Id, int userid, string mailid, string operation)
   {
       try
       {

           SqlParameter[] param = new SqlParameter[5];
           param[0] = new SqlParameter("@linkId", Id);
           param[1] = new SqlParameter("@mailid", mailid);
           param[2] = new SqlParameter("@createdid", userid);
           param[3] = new SqlParameter("@createdip", GetMacAddress());
           param[4] = new SqlParameter("@operation", operation);
          
           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam(param, "[sp_InsertStudentMailVerifyLogs]");

           if (ds != null)
               return ds.Tables[0];
           else
               return null;

       }
       catch
       {
           return null;
       }

   }


   public string GetNationality(int LinkId)
   {
       string MobileNo = "";
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("select top 1 nationality from tblstudent where LinkId=@LinkId and [Status]='True'", conn);
           cmd.CommandType = CommandType.Text;
           cmd.Parameters.AddWithValue("@LinkId", LinkId);
           SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               MobileNo = dr[0].ToString();
           }
           conn.Close();
           return MobileNo;
       }
       catch
       {
           return MobileNo;
       }
   }

   public string InertStudentCityDetails(int LinkId, string cityname,string COR)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("ProcInsertStudentCityname", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Linkid", LinkId);
           cmd.Parameters.AddWithValue("@Cityname", cityname);
           cmd.Parameters.AddWithValue("@COR", COR);

           using (conn)
               cmd.ExecuteNonQuery();
           conn.Close();
           return "RegisterNo";
       }
       catch (Exception ex)
       {
           return "";
       }

   }




   public string  InsertStudentDetailsCMSNEW(int LinkId, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
      string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
      string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
      string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
      string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
      string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth, string BloodGroup, string Religion,
       string IsInternationalStudent, string forwardtype, bool aptitude,
       string cityname, string cor, string Event, bool TOC, int AcademicYear, string Grade, string schoolcode)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("ProcInsertStudentnew", conn);
           SqlParameter[] param = new SqlParameter[55];
           cmd.CommandType = CommandType.StoredProcedure;
           param[0] = new SqlParameter("@Linkid", LinkId);
           param[1] = new SqlParameter("@RegNo", RegNo);
           param[2] = new SqlParameter("@CallDate", CallDate);
           param[3] = new SqlParameter("@Gender", Gender);
           param[4] = new SqlParameter("@Title", Title);
           param[5] = new SqlParameter("@FirstName", FirstName);
           param[6] = new SqlParameter("@MiddleName", MiddleName);
           param[7] = new SqlParameter("@LastName", LastName);
           param[8] = new SqlParameter("@ArabicFirstName", ArabicFisrtName);
           param[9] = new SqlParameter("@ArabicMiddleName", ArabicMiddleName);
           param[10] = new SqlParameter("@ArabicLastName", ArabicLastName);
           param[11] = new SqlParameter("@Nationality", Nationality);
           param[12] = new SqlParameter("@AttendedBy", AttendedBy);
           param[13] = new SqlParameter("@ForwardedTo", ForwardedTo);
           param[14] = new SqlParameter("@FormStatus", FormStatus);
           param[15] = new SqlParameter("@StudentStatus", StudentStatus);
           param[16] = new SqlParameter("@Comment", Comment);
           param[17] = new SqlParameter("@Remarks", Remarks);
           param[18] = new SqlParameter("@ProspectStatus", ProspectStatus);
           param[19] = new SqlParameter("@RefferedBy", RefferedBy);
           param[20] = new SqlParameter("@MobileNo", MobileNo);
           param[21] = new SqlParameter("@EmailID", Email);
           param[22] = new SqlParameter("@CourseType", CourseType);
           param[23] = new SqlParameter("@DegreeType", DegreeType);
           param[24] = new SqlParameter("@MediaSource", MediaSource);
           param[25] = new SqlParameter("@CreatedBy", CreatedBy);
           param[26] = new SqlParameter("@CompanyName", CompanyName);
           param[27] = new SqlParameter("@Designation", Designation);
           param[28] = new SqlParameter("@Telephone", Telephone);
           param[29] = new SqlParameter("@Fax", Fax);
           param[30] = new SqlParameter("@PoBox", PoBox);
           param[31] = new SqlParameter("@ArabNonArab", ArabNonArab);
           param[32] = new SqlParameter("@ISEmployeed", ISEmployeed);
           param[33] = new SqlParameter("@SchoolUniversity", SchoolUniversity);
           param[34] = new SqlParameter("@Industry", Industry);
           param[35] = new SqlParameter("@Website", Website);
           param[36] = new SqlParameter("@Address", Address);
           param[37] = new SqlParameter("@City", City);
           param[38] = new SqlParameter("@CallerCategory", CallerCategory);
           param[39] = new SqlParameter("@MotherTongue", MotherTounge);
           param[40] = new SqlParameter("@ProficiencyInEnglish", ProficiencyInEnglish);
           param[41] = new SqlParameter("@DOB", DateOfBirth);
           param[42] = new SqlParameter("@BloodGroup", BloodGroup);
           param[43] = new SqlParameter("@Religion", Religion);
           param[44] = new SqlParameter("@IsInternationalStudent", IsInternationalStudent);
           param[45] = new SqlParameter("@forwardtype", forwardtype);
           param[46] = new SqlParameter("@aptitude", aptitude);
           param[47] = new SqlParameter("@ip", GetMacAddress());
           param[48] = new SqlParameter("@Cityname", cityname);
           param[49] = new SqlParameter("@COR", cor);
           param[50] = new SqlParameter("@Event", Event);
           param[51] = new SqlParameter("@TOC", TOC);
           param[52] = new SqlParameter("@AcademicYear", AcademicYear);
           param[53] = new SqlParameter("@Grade", Grade);
           param[54] = new SqlParameter("@schoolcode", schoolcode);
                 


           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam(param, "[ProcInsertStudentnew]");

           if (ds != null)
               return ds.Tables[0].Rows[0][0].ToString();
           else
               return null;
       }
       catch (Exception ex)
       {
           return "error";
       }
   }

   public int InsertUpdateAirticketDetails(int airid, int nationality, string currency, double amount, string fromdate, string todate, int min, int max, string Remarks,
     int UserId, string Operation)
   {
       try
       {
           int count = 0;
           string sql = "Sp_Insert_UpdateAirticketDetails";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Airid", airid);
           cmd.Parameters.AddWithValue("@Country", nationality);
           cmd.Parameters.AddWithValue("@currency", currency);
           cmd.Parameters.AddWithValue("@amount", amount);
           cmd.Parameters.AddWithValue("@fromdate", fromdate);
           cmd.Parameters.AddWithValue("@todate", todate);
           cmd.Parameters.AddWithValue("@min", min);
           cmd.Parameters.AddWithValue("@max", max);
           cmd.Parameters.AddWithValue("@Remarks", Remarks);

           cmd.Parameters.AddWithValue("@createdBy", UserId);
           cmd.Parameters.AddWithValue("@CreatedIp", GetMacAddress());
           cmd.Parameters.AddWithValue("@Operation", Operation);

           count = int.Parse(cmd.ExecuteScalar().ToString());
           return (int)count;
       }
       catch (Exception e)
       {
           return 0;
       }
   }
   public DataTable GetAirticketDetails(int Id, string Operation)
   {

       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@Id", Id);
       param[1] = new SqlParameter("@Operation", Operation);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[Sp_GetAirticketDetails]");
       return ds.Tables[0];
   }
   public DataTable InsertAirticket_Eligible(string LinkId, string flag)
   {
       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@LinkId", LinkId);
       param[1] = new SqlParameter("@flag", flag);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_CheckAirticket_Eligible]");
       return ds.Tables[0];
   }
   public DataTable Getmorescdetails (int Id, string Operation)
   {

       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@id", Id);
       param[1] = new SqlParameter("@Operation", Operation);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[Sp_ProcSCMore]");
       return ds.Tables[0];
   }

   public DataTable InsertProgrammoreSC(string LinkId, string ProgramType, string DegreeType, string CourseType, string Term, string Shift, DateTime ShortFromDate,
      DateTime ShortToDate, string Reading, string Writing, string Listing, string Speaking, string  percentage,string feewaiver,double fees,double netfees, int createdby)
   {
      
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("ProcInsertProgramSCmore", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter[] param = new SqlParameter[17];
           param[0] = new SqlParameter("@LinkId", LinkId);

           param[1] = new SqlParameter("@ProgramType", ProgramType);
           param[2] = new SqlParameter("@DegreeType", DegreeType);
           param[3] = new SqlParameter("@CourseType", CourseType);
           param[4] = new SqlParameter("@Term", Term);
           param[5] = new SqlParameter("@Shift", Shift);
           param[6] = new SqlParameter("@ShortFromDate", ShortFromDate);
           param[7] = new SqlParameter("@ShortToDate", ShortToDate);
           param[8] = new SqlParameter("@Reading", Reading);
           param[9] = new SqlParameter("@Writing", Writing);
           param[10] = new SqlParameter("@Listing", Listing);
           param[11] = new SqlParameter("@Speaking", Speaking);
           param[12] = new SqlParameter("@percentage", percentage);
           param[13] = new SqlParameter("@feewaiver", feewaiver);
           param[14] = new SqlParameter("@fees", fees);
           param[15] = new SqlParameter("@netfees", netfees);
           param[16] = new SqlParameter("@createdby", createdby);
    
           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam(param, "[ProcInsertProgramSCmore]");
           return ds.Tables[0];
     
   }

   public string InsertFeeGroupSCmore(string LinkId, string ObjectName,int id )
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("InsertfeegroupSCmore", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LinkId", LinkId);
           cmd.Parameters.AddWithValue("@ObjectName", ObjectName);
           cmd.Parameters.AddWithValue("@id", id);
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

   public string InsertFeeGroupSCmoreDebits(string Student_Id)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("InsertEMSCMSPIstudentwise", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Student_Id", Student_Id);
                  
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
   public DataSet SetProgramSC(int Id)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@Id",Id);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[ProcSetProgramSC]");
       return ds;
   }
   public DataTable SetDropdownListAsDegreeTypeperc(int Flag, int Id)
   {
       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@Flag", Flag);
       param[1] = new SqlParameter("@Id", Id);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[ProcSetDropdownAsDegreeType_perc]");
       return ds.Tables[0];
   }

   public DataTable GetStudentDetails_Offer(string FilterBy, string FilterValue, int Type, string EmpId)
   {
       try
       {
           SqlParameter[] param = new SqlParameter[4];
           param[0] = new SqlParameter("@FilterBy", FilterBy);
           param[1] = new SqlParameter("@FilterValue", FilterValue);
           param[2] = new SqlParameter("@Type", Type);
           param[3] = new SqlParameter("@EmpId", EmpId);
           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam(param, "[ProcGetStudent_OfferLetter]");
           return ds.Tables[0];
       }
       catch

       { return null; }
   }
   public string InsertOfferLetter(DataTable DT)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("SP_Offerletter", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Details", DT);
           cmd.Parameters.AddWithValue("@CreatedIP", GetMacAddress());
           using (conn)
               cmd.ExecuteNonQuery();
           conn.Close();
           return "RegisterNo";
       }
       catch (Exception ex)
       {
           return "";
       }

   }

   public DataTable GetTerm()
   {
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam("[sp_Term]");
       return ds.Tables[0];
   }

   public DataTable InsertOnlineImport(int empid, string Id)
   {
       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@empid", empid);
       param[1] = new SqlParameter("@ids", Id);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_ImportCMSrecords]");
       return ds.Tables[0];
   }

   public DataSet GetOnlinedetailsIndividual(string Id)
   {
       SqlParameter[] param = new SqlParameter[1];
     
       param[0] = new SqlParameter("@ids", Id);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_displayrecordsonline_idwise]");
       return ds;
   }

   //Added by Pratheeba for security clerance screen //

   public DataSet SetStudentsDetails_SecurityClearance(int LinkId)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@LinkId", LinkId);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[ProcSetStudentdetail_SecurityClearance]");
       return ds;
   }



   public string Insert_Security_Personal_Details(int LinkId, string Register_No, string Student_Name, string Religion, string Doctrine, string POB, DateTime DOB, string Current_Nationality, string previous_Nationality, string created_by, string created_Ip)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_INSERT_SECURITY_PERSONAL_INFO]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LINKID", LinkId);
           cmd.Parameters.AddWithValue("@REGISTER_NO", Register_No);
           cmd.Parameters.AddWithValue("@STUDENT_NAME", Student_Name);
           cmd.Parameters.AddWithValue("@RELIGION", Religion);
           cmd.Parameters.AddWithValue("@DOCTRINE", Doctrine);
           cmd.Parameters.AddWithValue("@POB", POB);
           cmd.Parameters.AddWithValue("@DOB", DOB);
           cmd.Parameters.AddWithValue("@CURRENT_NATIONALITY", Current_Nationality);
           cmd.Parameters.AddWithValue("@PREVIOUS_NATIONALITY", previous_Nationality);
           cmd.Parameters.AddWithValue("@CREATEDBY", created_by);
           cmd.Parameters.AddWithValue("@CREATED_IP", created_Ip);

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




   public string Insert_Security_Qualification_Details(int LinkId, string Register_No, string Type_Of_Qualification, string Languages_Known)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_INSERT_SECURITY_QUALIFICATION_INFO]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LINKID", LinkId);
           cmd.Parameters.AddWithValue("@REGISTER_NO", Register_No);
           cmd.Parameters.AddWithValue("@TYPEOFQUALIFICATION", Type_Of_Qualification);
           cmd.Parameters.AddWithValue("@LANGUAGES_KNOWN", Languages_Known);
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





   public string Insert_Security_Marital_Details(int LinkId, string Register_No, string SpouseName, string nationality, string SpousePob, DateTime SpouseDOB)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_INSERT_SECURITY_MARITAL_STATUS]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LINKID", LinkId);
           cmd.Parameters.AddWithValue("@REGISTRATION_NO", Register_No);
           cmd.Parameters.AddWithValue("@SPOUSE_NAME", SpouseName);
           cmd.Parameters.AddWithValue("@SPOUSE_NATIONALITY", nationality);
           cmd.Parameters.AddWithValue("@SPOUSE_POB", SpousePob);
           cmd.Parameters.AddWithValue("@SPOUSE_DOB", SpouseDOB);
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



   public string Insert_Security_Children_Info(int LinkId, string Register_No, int ChildrensNo)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_INSERT_SECURITY_CHILDREN_INFO]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LINKID", LinkId);
           cmd.Parameters.AddWithValue("@REGISTRATION_NO", Register_No);
           cmd.Parameters.AddWithValue("@CHILDREN_NO", ChildrensNo);

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



   public string Insert_Security_Parent_Info(int LinkId, string Register_No, string Fathersname, string FatherNationality, string FatherPob, DateTime FatherDOB, string MotherName, string MotherNationality, string MotherPOB, DateTime MotherDOB)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_INSERT_SECURITY_PARENT_INFO]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LINKID", LinkId);
           cmd.Parameters.AddWithValue("@REGISTRATION_NO", Register_No);
           cmd.Parameters.AddWithValue("@FATHER_NAME", Fathersname);
           cmd.Parameters.AddWithValue("@FATHER_NATIONALITY", FatherNationality);
           cmd.Parameters.AddWithValue("@FATHER_POB", FatherPob);
           cmd.Parameters.AddWithValue("@FATHER_DOB", FatherDOB);
           cmd.Parameters.AddWithValue("@MOTHER_NAME", MotherName);
           cmd.Parameters.AddWithValue("@MOTHER_NATIONALITY", MotherNationality);
           cmd.Parameters.AddWithValue("@MOTHER_POB", MotherPOB);
           cmd.Parameters.AddWithValue("@MOTHER_DOB", MotherDOB);

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




   public string Insert_Security_Contact_Info(int LINKID, string REGISTRATION_NO, string MOBILE_NO, string RESIDENCE_NO, string EMAILID, string WEBSITE, string TWITTER, string FACEBOOK, string MILITARY_EXP,
     string MILITARY_COUNTRY, string TYPE_OF_SERVICE, string MILITARY_RANK, string DURATION, string CONTACTPERSON_NAME, string CONTACT_NATIONALITY, string CONTACT_WORKPLACE, string CONTACT_MOBILE_NO, string VISITED_COUNTRY1,
     string VISITED_COUNTRY2, string VISITED_COUNTRY3, string VISITED_COUNTRY4, string VISITED_COUNTRY5)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_INSERT_SECURITY_CONTACT_INFO]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LINKID", LINKID);
           cmd.Parameters.AddWithValue("@REGISTRATION_NO", REGISTRATION_NO);
           cmd.Parameters.AddWithValue("@RESIDENCE_NO", RESIDENCE_NO);
           cmd.Parameters.AddWithValue("@MOBILE_NO", MOBILE_NO);
           cmd.Parameters.AddWithValue("@EMAILID", EMAILID);
           cmd.Parameters.AddWithValue("@WEBSITE", WEBSITE);
           cmd.Parameters.AddWithValue("@TWITTER", TWITTER);
           cmd.Parameters.AddWithValue("@FACEBOOK", FACEBOOK);
           cmd.Parameters.AddWithValue("@MILITARY_EXP", MILITARY_EXP);
           cmd.Parameters.AddWithValue("@MILITARY_COUNTRY", MILITARY_COUNTRY);
           cmd.Parameters.AddWithValue("@TYPE_OF_SERVICE", TYPE_OF_SERVICE);
           cmd.Parameters.AddWithValue("@MILITARY_RANK", MILITARY_RANK);
           cmd.Parameters.AddWithValue("@DURATION", DURATION);
           cmd.Parameters.AddWithValue("@CONTACTPERSON_NAME", CONTACTPERSON_NAME);
           cmd.Parameters.AddWithValue("@CONTACT_NATIONALITY", CONTACT_NATIONALITY);
           cmd.Parameters.AddWithValue("@CONTACT_WORKPLACE", CONTACT_WORKPLACE);
           cmd.Parameters.AddWithValue("@CONTACT_MOBILE_NO", CONTACT_MOBILE_NO);
           cmd.Parameters.AddWithValue("@VISITED_COUNTRY1", VISITED_COUNTRY1);
           cmd.Parameters.AddWithValue("@VISITED_COUNTRY2", VISITED_COUNTRY2);
           cmd.Parameters.AddWithValue("@VISITED_COUNTRY3", VISITED_COUNTRY3);
           cmd.Parameters.AddWithValue("@VISITED_COUNTRY4", VISITED_COUNTRY4);
           cmd.Parameters.AddWithValue("@VISITED_COUNTRY5", VISITED_COUNTRY5);


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

   public DataTable IsSecurityClearance_AlreadyExists(int LinkId)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@LINKID", LinkId);
       DataSet ds = da.getDataByParam(param, "[SP_SECURITYCLEARANCE_ALREADYEXISTS]");
       return ds.Tables[0];
   }
   public DataTable CheckAyYearApproval(String LinkId)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@LINKID", LinkId);
       DataSet ds = da.getDataByParam(param, "[SP_CheckAyYearApproval]");
       return ds.Tables[0];
   }

   public DataSet GetClassOrientaion(string LinkId)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@Linkid", LinkId);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[sp_GetClassOrientation]");
       return ds;
   }
   public DataTable BindCalenderDropdown(string Operation, int EmpID, string CalName, int AY, String Date)
   {
       SqlParameter[] param = new SqlParameter[5];
       param[0] = new SqlParameter("@Operation", Operation);
       param[1] = new SqlParameter("@EmpID", EmpID);
       param[2] = new SqlParameter("@CalName", CalName);
       param[3] = new SqlParameter("@AY", AY);
       param[4] = new SqlParameter("@Date", Date);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParamAdmin(param, "SP_DisplayCalenderName");
       if (ds != null && ds.Tables.Count > 0)
           return ds.Tables[0];
       else
           return null;
   }

   public DataTable GetAcYear()
   {
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.CalendargetDataByParam("[SP_ACYEAR]");
       return ds.Tables[0];
   }

   public DataTable GetExhibition(int ID = 0)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@ID", ID);
       DataSet ds = da.getDataByParam(param, "[SP_getExhibition]");
       return ds.Tables[0];
   }
   public DataTable GetMonthName()
   {
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.CalendargetDataByParam("[SP_MonthName]");
       return ds.Tables[0];
   }
   public DataTable GetExhibition(string Ayear, int Month)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@ACYear", Ayear);
       param[1] = new SqlParameter("@Month", Month);
       DataSet ds = da.CalendargetDataByParam(param, "[SP_LoadExhibition]");
       return ds.Tables[0];
   }

   public DataTable GetExbhibitionDate(int SPID)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@SPID", SPID);
       DataSet ds = da.CalendargetDataByParam(param, "[SP_LoadExhibition_DATE]");
       return ds.Tables[0];
   }
   public int InsertExhibition(int ID = 0, int UniqueID = 0, string Ayear = "", int Month = 0, string EventTitle = "", DateTime? Date = null, String Venue = "",
            string RequiedStaff = "", string Stand = "", string CreatedBy = "", String IP = "", String Operation = "")
   {
       try
       {
           Int32 MasterId = 0;
           string sql = "SP_Exhibition";
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CDBConnectionString2"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ID", ID);
           cmd.Parameters.AddWithValue("@UniqueID", UniqueID);
           cmd.Parameters.AddWithValue("@Ayear", Ayear);
           cmd.Parameters.AddWithValue("@Month", Month);
           cmd.Parameters.AddWithValue("@EventTitle", EventTitle);
           cmd.Parameters.AddWithValue("@Date", Date);
           cmd.Parameters.AddWithValue("@Venue", Venue);
           cmd.Parameters.AddWithValue("@RequiedStaff", RequiedStaff);
           cmd.Parameters.AddWithValue("@Stand", Stand);
           cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
           cmd.Parameters.AddWithValue("@IP", IP);
           cmd.Parameters.AddWithValue("@Operation", Operation);

           MasterId = (Int32)cmd.ExecuteScalar();
           return (int)MasterId;
       }
       catch (Exception e)
       {
           return 0;
       }
   }


   public DataTable GetExbhibitionDatetime(int SPID)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@SPID", SPID);
       DataSet ds = da.CalendargetDataByParam(param, "[SP_LoadExhibition_DATETIME]");
       return ds.Tables[0];
   }

   public DataTable GetEmp()
   {
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam("[SP_EMP]");
       return ds.Tables[0];
   }


   public DataTable GetFaresandEvents()
   {
       try
       {
           // SqlParameter[] param = new SqlParameter[4];
           //param[0] = new SqlParameter("@FilterBy", FilterBy);
           //param[1] = new SqlParameter("@FilterValue", FilterValue);
           //param[2] = new SqlParameter("@Type", Type);
           //param[3] = new SqlParameter("@EmpId", EmpId);
           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam("[SP_FARESANDEVENTS]");
           return ds.Tables[0];
       }
       catch

       { return null; }
   }



   public string INSERT_FARESANDEVENTS(int ID, string ENTRYTYPE, string ACADYEAR, string MONTH, string TITLE, DateTime STARTDATE, DateTime ENDDATE
        , string FROMTIME, string TOTIME, string EVENT_TYPE, string REMARKS, string PARTICIPATION_FEE, string PAYMENT_STATUS, string LOCATION, string REPRESENTATIVE,
      string FORMS_COLLECTOR, string REPORT_SUBMISSION, string SUBMISSION_REMARKS, string OPERATION, string CREATEDBY, string CREATEDIP)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("[SP_TB_FARESANDEVENTS]", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ID", ID);
           cmd.Parameters.AddWithValue("@ENTRYTYPE", ENTRYTYPE);
           cmd.Parameters.AddWithValue("@ACADYEAR", ACADYEAR);
           cmd.Parameters.AddWithValue("@MONTH", MONTH);
           cmd.Parameters.AddWithValue("@TITLE", TITLE);
           cmd.Parameters.AddWithValue("@STARTDATE", STARTDATE);
           cmd.Parameters.AddWithValue("@ENDDATE", ENDDATE);
           cmd.Parameters.AddWithValue("@FROMTIME", FROMTIME);
           cmd.Parameters.AddWithValue("@TOTIME", TOTIME);
           cmd.Parameters.AddWithValue("@EVENT_TYPE", EVENT_TYPE);
           cmd.Parameters.AddWithValue("@REMARKS", REMARKS);
           cmd.Parameters.AddWithValue("@PARTICIPATION_FEE", PARTICIPATION_FEE);
           cmd.Parameters.AddWithValue("@PAYMENT_STATUS", PAYMENT_STATUS);
           cmd.Parameters.AddWithValue("@LOCATION", LOCATION);
           cmd.Parameters.AddWithValue("@REPRESENTATIVE", REPRESENTATIVE);
           cmd.Parameters.AddWithValue("@FORMS_COLLECTOR", FORMS_COLLECTOR);
           cmd.Parameters.AddWithValue("@REPORT_SUBMISSION", REPORT_SUBMISSION);
           cmd.Parameters.AddWithValue("@SUBMISSION_REMARKS", SUBMISSION_REMARKS);
           cmd.Parameters.AddWithValue("@OPERATION", OPERATION);
           cmd.Parameters.AddWithValue("@CREATEDBY", CREATEDBY);
           cmd.Parameters.AddWithValue("@CREATEDIP", CREATEDIP);

           using (conn)
               cmd.ExecuteNonQuery();
           conn.Close();
           return "Success";
       }
       catch
       {
           return "error";
       }
   }




   public DataTable GETFARESANDEVENTS(int ID)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@ID", ID);

       DataSet ds = da.getDataByParam(param, "[SP_GETFARESANDEVENTS]");
       return ds.Tables[0];
   }
   public DataTable InsertLicenseRenewal(string CourseType, DateTime ValidFrom, DateTime ValidTo, string Description, string Remarks,
   int CreatedBy, string Operation, int LicenseID, byte[] File = null, string FileName = "", String FIleExtension = "")
   {
       SqlParameter[] param = new SqlParameter[12];
       param[0] = new SqlParameter("@CourseType", CourseType);
       param[1] = new SqlParameter("@ValidFrom", ValidFrom);
       param[2] = new SqlParameter("@ValidTo", ValidTo);
       param[3] = new SqlParameter("@Description", Description);
       param[4] = new SqlParameter("@Remarks", Remarks);
       param[5] = new SqlParameter("@CreatedBy", CreatedBy);
       param[6] = new SqlParameter("@Operation", Operation);
       param[7] = new SqlParameter("@LicenseID", LicenseID);
       param[8] = new SqlParameter("@CreatedIP", GetIpAddress());
       param[9] = new SqlParameter("@File", File);
       param[10] = new SqlParameter("@FileName", FileName);
       param[11] = new SqlParameter("@FileExtension", FIleExtension);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "SP_INSERT_LICENSERENEWAL");
       if (ds != null && ds.Tables.Count > 0)
           return ds.Tables[0];
       else
           return null;
   }
   public DataTable Insert_MKTPLANNING_MOU(string Operation, string Category, string SubCategory, int CategoryID,
    int CreatedBy, int ID, int AcYearID)
   {
       SqlParameter[] param = new SqlParameter[8];
       param[0] = new SqlParameter("@Operation", Operation);
       param[1] = new SqlParameter("@Category", Category);
       param[2] = new SqlParameter("@SubCategory", SubCategory);
       param[3] = new SqlParameter("@CategoryID", CategoryID);
       param[4] = new SqlParameter("@CreatedBy", CreatedBy);
       param[5] = new SqlParameter("@ID", ID);
       param[6] = new SqlParameter("@IPAddress", GetIpAddress());
       param[7] = new SqlParameter("@AcYearID", AcYearID);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "SP_MKTPLANNING_MOU");
       if (ds != null && ds.Tables.Count > 0)
           return ds.Tables[0];
       else
           return null;

   }


   public DataTable GetFinalFeesintegrated(int DegreeId, string TermId)
   {
       SqlParameter[] param = new SqlParameter[2];
       param[0] = new SqlParameter("@degreeid", DegreeId);
       param[1] = new SqlParameter("@term", TermId);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[DISPLAYFEEMAINIntegrated]");
       return ds.Tables[0];
   }


   public DataTable GetTOCdetails(int DegreeId, int TermId, string schoolcode)
   {
       SqlParameter[] param = new SqlParameter[3];
       param[0] = new SqlParameter("@degreetype", DegreeId);
       param[1] = new SqlParameter("@term", TermId);
       param[2] = new SqlParameter("@schoolcode", schoolcode);
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[SP_TOCDetails_ALL]");
       return ds.Tables[0];
   }

   public DataTable GetTOCdetailsbystud(string studid)
   {
       SqlParameter[] param = new SqlParameter[1];
       param[0] = new SqlParameter("@regno", studid);
           
       DataAccessLayer da = new DataAccessLayer();
       DataSet ds = da.getDataByParam(param, "[SP_TOCDetails]");
       return ds.Tables[0];
   }


   public string UpdateStudentDetailsnew(int Id, string RegNo, DateTime CallDate, int Gender, int Title, string FirstName,
           string MiddleName, string LastName, string ArabicFisrtName, string ArabicMiddleName, string ArabicLastName, string Nationality,
           string AttendedBy, string ForwardedTo, string ProspectStatus, string Comment, string Remarks, string FormStatus, string StudentStatus, string RefferedBy,
           string MobileNo, string Email, string CourseType, string DegreeType, string MediaSource, string CreatedBy, string CompanyName, string Designation,
           string Telephone, string Fax, string PoBox, string ArabNonArab, string ISEmployeed, string SchoolUniversity, string Industry, string Website, string Address,
           string City, string CallerCategory, string MotherTounge, string ProficiencyInEnglish, DateTime DateOfBirth,
       string BloodGroup, string Religion, string IsInternationalStudent, string forwardtype, bool aptitude, string cityname, 
       string cor, string Event, bool TOC, int AcademicYear, string Grade,string schoolcode)
   
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("ProcUpdateStudent_new", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter[] param = new SqlParameter[54];
           cmd.CommandType = CommandType.StoredProcedure;
           param[0] = new SqlParameter("@Id", Id);
           param[1] = new SqlParameter("@RegNo", RegNo);
           param[2] = new SqlParameter("@CallDate", CallDate);
           param[3] = new SqlParameter("@Gender", Gender);
           param[4] = new SqlParameter("@Title", Title);
           param[5] = new SqlParameter("@FirstName", FirstName);
           param[6] = new SqlParameter("@MiddleName", MiddleName);
           param[7] = new SqlParameter("@LastName", LastName);
           param[8] = new SqlParameter("@ArabicFirstName", ArabicFisrtName);
           param[9] = new SqlParameter("@ArabicMiddleName", ArabicMiddleName);
           param[10] = new SqlParameter("@ArabicLastName", ArabicLastName);
           param[11] = new SqlParameter("@Nationality", Nationality);
           param[12] = new SqlParameter("@AttendedBy", AttendedBy);
           param[13] = new SqlParameter("@ForwardedTo", ForwardedTo);
           param[14] = new SqlParameter("@FormStatus", FormStatus);
           param[15] = new SqlParameter("@StudentStatus", StudentStatus);
           param[16] = new SqlParameter("@Comment", Comment);
           param[17] = new SqlParameter("@Remarks", Remarks);
           param[18] = new SqlParameter("@ProspectStatus", ProspectStatus);
           param[19] = new SqlParameter("@RefferedBy", RefferedBy);
           param[20] = new SqlParameter("@MobileNo", MobileNo);
           param[21] = new SqlParameter("@EmailID", Email);
           param[22] = new SqlParameter("@CourseType", CourseType);
           param[23] = new SqlParameter("@DegreeType", DegreeType);
           param[24] = new SqlParameter("@MediaSource", MediaSource);
           param[25] = new SqlParameter("@CreatedBy", CreatedBy);
           param[26] = new SqlParameter("@CompanyName", CompanyName);
           param[27] = new SqlParameter("@Designation", Designation);
           param[28] = new SqlParameter("@Telephone", Telephone);
           param[29] = new SqlParameter("@Fax", Fax);
           param[30] = new SqlParameter("@PoBox", PoBox);
           param[31] = new SqlParameter("@ArabNonArab", ArabNonArab);
           param[32] = new SqlParameter("@ISEmployeed", ISEmployeed);
           param[33] = new SqlParameter("@SchoolUniversity", SchoolUniversity);
           param[34] = new SqlParameter("@Industry", Industry);
           param[35] = new SqlParameter("@Website", Website);
           param[36] = new SqlParameter("@Address", Address);
           param[37] = new SqlParameter("@City", City);
           param[38] = new SqlParameter("@CallerCategory", CallerCategory);
           param[39] = new SqlParameter("@MotherTongue", MotherTounge);
           param[40] = new SqlParameter("@ProficiencyInEnglish", ProficiencyInEnglish);
           param[41] = new SqlParameter("@DOB", DateOfBirth);
           param[42] = new SqlParameter("@BloodGroup", BloodGroup);
           param[43] = new SqlParameter("@Religion", Religion);
           param[44] = new SqlParameter("@IsInternationalStudent", IsInternationalStudent);
         param[45] = new SqlParameter("@ip", GetMacAddress());
           param[46] = new SqlParameter("@aptitude", aptitude);
          param[47] = new SqlParameter("@Cityname", cityname);
           param[48] = new SqlParameter("@COR", cor);
           param[49] = new SqlParameter("@Event", Event);
           param[50] = new SqlParameter("@TOC", TOC);
           param[51] = new SqlParameter("@AcademicYear", AcademicYear);
           param[52] = new SqlParameter("@Grade", Grade);

           param[53] = new SqlParameter("@schoolcode", schoolcode);

           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam(param, "[ProcUpdateStudent_new]");

           if (ds != null)
               return ds.Tables[0].Rows[0][0].ToString();
           else
               return null;
           //using (conn)
           //    cmd.ExecuteNonQuery();
           //conn.Close();
           //return "RegisterNo";
       }
       catch
       {
           return "error";
       }
   }



   public string InsertToeflenglishspeaker(string LinkId, bool EnglishSpeaker,  string userid)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
           conn.Open();
           SqlCommand cmd = new SqlCommand("ProcInsertToeflEnglishspeaker", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@LinkId", LinkId);
           cmd.Parameters.AddWithValue("@EnglishSpeaker", EnglishSpeaker);
         
           cmd.Parameters.AddWithValue("@createdip", GetMacAddress());
           cmd.Parameters.AddWithValue("@createdid", userid);
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


   public DataTable GetMarktingAllEmployee()
   {
       try
       {
           //SqlParameter[] param = new SqlParameter[2];
           //param[0] = new SqlParameter("@Categorytext", cattext);
           //param[1] = new SqlParameter("@Subcategorytext", subcatText);
           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam("[SP_GETMARKETING_ALL_EMP]");
           return ds.Tables[0];
       }
       catch
       { return null; }
   }
   public DataTable GetStudentDetailsnew(string FilterBy, string FilterValue, int Type, string EmpId,string schoolcode)
   {
       try
       {
           SqlParameter[] param = new SqlParameter[5];
           param[0] = new SqlParameter("@FilterBy", FilterBy);
           param[1] = new SqlParameter("@FilterValue", FilterValue);
           param[2] = new SqlParameter("@Type", Type);
           param[3] = new SqlParameter("@EmpId", EmpId);
           param[4] = new SqlParameter("@schoolcode", schoolcode);
           DataAccessLayer da = new DataAccessLayer();
           DataSet ds = da.getDataByParam(param, "[ProcGetStudent_Active]");
           return ds.Tables[0];
       }
       catch

       { return null; }
   }


   public DataTable InsertFollowupGraduation(int id,int ayyear,int semid,int createdby,string studid,string flag)
   {
       DataAccessLayer da = new DataAccessLayer();
       SqlParameter[] param = new SqlParameter[7];
       param[0] = new SqlParameter("@id", id);
       param[1] = new SqlParameter("@ayyear", ayyear);
       param[2] = new SqlParameter("@semid", semid);
       
       param[3] = new SqlParameter("@createdby", createdby);
         param[4] = new SqlParameter("@createdip", GetMacAddress());
         param[5] = new SqlParameter("@newstudid", studid);
         param[6] = new SqlParameter("@flag", flag);
         DataSet ds = da.getDataByParam(param, "[sp_Insert_FollowupGraduation]");
       return ds.Tables[0];
   }
  

    }



