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

public class Setup
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TPSCon"].ToString());
    public Setup()
    {
    }
    public string InsertFeesItem(string Fees_Code, string Fees_Description, int Fees_Category_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFeesItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Code", Fees_Code);
            cmd.Parameters.AddWithValue("@Fees_Description", Fees_Description);
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);

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
    public string DeleteFeesItem(int Fees_Items_Id, string Fees_Code, string Fees_Description, int Fees_Category_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFeesItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Items_Id", Fees_Items_Id);
            cmd.Parameters.AddWithValue("@Fees_Code", Fees_Code);
            cmd.Parameters.AddWithValue("@Fees_Description", Fees_Description);
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);

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
    public string UpdateFeesItem(int Fees_Items_Id, string Fees_Code, string Fees_Description, int Fees_Category_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFeesItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Items_Id", Fees_Items_Id);
            cmd.Parameters.AddWithValue("@Fees_Code", Fees_Code);
            cmd.Parameters.AddWithValue("@Fees_Description", Fees_Description);
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);

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
    public string InsertFeeCategory(string Fees_Category_Desc)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFeeCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Category_Desc", Fees_Category_Desc);

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
    public string DeleteFeeCategory(int Fees_Category_id, string Fees_Category_Desc)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFeeCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);
            cmd.Parameters.AddWithValue("@Fees_Category_Desc", Fees_Category_Desc);

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
    public string UpdateFeeCategory(int Fees_Category_id, string Fees_Category_Desc)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFeeCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);
            cmd.Parameters.AddWithValue("@Fees_Category_Desc", Fees_Category_Desc);
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
    public string Delete_FeeCategory(int Fees_Category_id, string Fees_Category_Desc)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFeeCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);
            cmd.Parameters.AddWithValue("@Fees_Category_Desc", Fees_Category_Desc);
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
    public string InsertFeePeriod(string Period_Desc, DateTime Start_Date, DateTime End_Date, int OPStatus, int UID)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFeePeriod", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Period_Desc", Period_Desc);
            cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
            cmd.Parameters.AddWithValue("@End_Date", End_Date);
            cmd.Parameters.AddWithValue("@OPStatus", OPStatus);
            cmd.Parameters.AddWithValue("@UID", UID);
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
    public string UpdateFeePeriod(int Period_id, string Period_Desc, DateTime Start_Date, DateTime End_Date, int UID, int Status)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFeePeriod", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Period_id", Period_id);
            cmd.Parameters.AddWithValue("@Period_Desc", Period_Desc);
            cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
            cmd.Parameters.AddWithValue("@End_Date", End_Date);
            cmd.Parameters.AddWithValue("@UID", UID);
            cmd.Parameters.AddWithValue("@OPStatus", Status);

            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "Result";
        }
        catch
        {
            return "Error";
        }
    }
    public string DeleteFeePeriod(int Period_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFeePeriod", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Period_id", Period_id);

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
    public string InsertFeeGroupAcadyear(int Fees_Group_Id, int acyear_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFeeGroupAcadyear", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@acyear_id", acyear_id);
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


    public string InsertExternalAndFeeGroup(int Fees_Group_Id, int Ext_Group_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("[Insert_External_Fee_Group_And_Acedamic_Master]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@Ext_Group_Id", Ext_Group_Id);
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


    public string UpdateFeeGroupAcadyear(int Fees_Group_Id, int acyear_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFeeGroupAcadyear", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@acyear_id", acyear_id);
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
    public string DeleteFeeGroupAcadyear(int Fees_Group_Id, int acyear_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFeeGroupAcadyear", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@acyear_id", acyear_id);
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
    public string InsertFee_Group_Acedamic_Details(int Fees_Group_Id, int Fees_Items_Id, string Fees_Pay_Type, int Period_id_start, int Period_id_end, decimal Fees_Amount, int Level_Id, int Installment_Status, int User_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFee_Group_Acedamic_Details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@Fees_Items_Id", Fees_Items_Id);
            cmd.Parameters.AddWithValue("@Fees_Pay_Type", Fees_Pay_Type);
            cmd.Parameters.AddWithValue("@Period_id_start", Period_id_start);
            cmd.Parameters.AddWithValue("@Period_id_end", Period_id_end);
            cmd.Parameters.AddWithValue("@Fees_Amount", Fees_Amount);
            cmd.Parameters.AddWithValue("@Level_Id", Level_Id);
            cmd.Parameters.AddWithValue("@Installment_Status", Installment_Status);
            cmd.Parameters.AddWithValue("@User_Id", User_Id);

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
    public string UpdateFee_Group_Acedamic_Details(int Fees_Group_Det_Id, int Fees_Group_Id, int Fees_Items_Id, string Fees_Pay_Type, int Period_id_start, int Period_id_end, decimal Fees_Amount, int Level_Id, int Installment_Status, int User_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFee_Group_Acedamic_Details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Det_Id", Fees_Group_Det_Id);
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@Fees_Items_Id", Fees_Items_Id);
            cmd.Parameters.AddWithValue("@Fees_Pay_Type", Fees_Pay_Type);
            cmd.Parameters.AddWithValue("@Period_id_start", Period_id_start);
            cmd.Parameters.AddWithValue("@Period_id_end", Period_id_end);
            cmd.Parameters.AddWithValue("@Fees_Amount", Fees_Amount);
            cmd.Parameters.AddWithValue("@Level_Id", Level_Id);
            cmd.Parameters.AddWithValue("@Installment_Status", Installment_Status);
            cmd.Parameters.AddWithValue("@User_Id", User_Id);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "Result";
        }
        catch
        {
            return "error in Updating";
        }
    }
    public string DeleteFee_Group_Acedamic_Details(int Fees_Group_Det_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFee_Group_Acedamic_Details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Det_Id", Fees_Group_Det_Id);

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

    public string InsertFee_Group_Acedamic_Master(string Fees_Group_Desc, int acyear_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertFee_Group_Acedamic_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Desc", Fees_Group_Desc);
            cmd.Parameters.AddWithValue("@acyear_id", acyear_id);
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
    public string UpdateFee_Group_Acedamic_Master(int Fees_Group_Id, string Fees_Group_Desc, int acyear_id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFee_Group_Acedamic_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@Fees_Group_Desc", Fees_Group_Desc);
            cmd.Parameters.AddWithValue("@acyear_id", Fees_Group_Desc);

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
    public string DeleteFee_Group_Acedamic_Master(int Fees_Group_Id, string Fees_Group_Desc)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFee_Group_Acedamic_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Group_Id", Fees_Group_Id);
            cmd.Parameters.AddWithValue("@Fees_Group_Desc", Fees_Group_Desc);
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
    public string Insert_Fee_Item(string Fees_Code, string Fees_Description, int Fees_Category_id, string Chart_Of_Account_Code, int UId, int IsActive, char Ear_Ded)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert_Fee_Item", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Code", Fees_Code);
            cmd.Parameters.AddWithValue("@Fees_Description", Fees_Description);
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);
            cmd.Parameters.AddWithValue("@Chart_Of_Account_Code", Chart_Of_Account_Code);

            cmd.Parameters.AddWithValue("@User_Id", UId);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
             cmd.Parameters.AddWithValue("@Ear_Ded", Ear_Ded);
           

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

    public string Update_Fee_Item(int Fees_Items_Id, string Fees_Code, string Fees_Description, int Fees_Category_id, string Chart_Of_Account_Code, int UId, int IsActive, char Ear_Ded)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateFeeItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Items_Id", Fees_Items_Id);
            cmd.Parameters.AddWithValue("@Fees_Code", Fees_Code);
            cmd.Parameters.AddWithValue("@Fees_Description", Fees_Description);
            cmd.Parameters.AddWithValue("@Fees_Category_id", Fees_Category_id);
            cmd.Parameters.AddWithValue("@Chart_Of_Account_Code", Chart_Of_Account_Code);
            cmd.Parameters.AddWithValue("@UID", UId);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@Ear_Ded", Ear_Ded);

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
    public string Delete_Fee_Item(int Fees_Items_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteFeeItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Items_Id", Fees_Items_Id);

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
    public string Insert_Bank_Master(string Bank_Code, string BanK_Name, int UID, int IsActive)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert_Bank_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bank_Code", Bank_Code);
            cmd.Parameters.AddWithValue("@BanK_Name", BanK_Name);
            cmd.Parameters.AddWithValue("@UID", UID);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
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
    public string Update_Bank_Master(int Bank_Id, string Bank_Code, string BanK_Name, int UID, int IsActive)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update_Bank_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bank_Id", Bank_Id);
            cmd.Parameters.AddWithValue("@Bank_Code", Bank_Code);
            cmd.Parameters.AddWithValue("@BanK_Name", BanK_Name);
            cmd.Parameters.AddWithValue("@UID", UID);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
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
    public string Delete_Bank_Master(int Bank_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete_Bank_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bank_Id", Bank_Id);

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
    public string Insert_Transc_Master(string Transection_Type_Desc, int UID, int Active)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert_Transc_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transection_Type_Desc", Transection_Type_Desc);

            cmd.Parameters.AddWithValue("@UID", UID);
            cmd.Parameters.AddWithValue("@IsAtive", Active);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "Result";
        }
        catch
        {
            return "error";
        }
    }
    public string Update_Transc_Master(int Transection_Type_Id, string Transection_Type_Desc, int UID, int Active)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update_Transc_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transection_Type_Id", Transection_Type_Id);
            cmd.Parameters.AddWithValue("@Transection_Type_Desc", Transection_Type_Desc);
            cmd.Parameters.AddWithValue("@UID", UID);
            cmd.Parameters.AddWithValue("@IsActive", Active);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "Result";
        }
        catch
        {
            return "error";
        }
    }
    public string Delete_Transc_Master(int Transection_Type_Id)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete_Transc_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transection_Type_Id", Transection_Type_Id);

            cmd.ExecuteNonQuery();
            conn.Close();
            return "Result";
        }
        catch
        {
            return "error";
        }
    }

    public DataTable GetChecK_Box_data(string Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam("[GetChecK_Box_data]");
        return ds.Tables[0];
    }
    public DataTable InsertUpdateAcdYear(int id, string AcdYear, DateTime startdate, DateTime enddate, string Operation, bool IsActive)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@ID", id);
        param[1] = new SqlParameter("@AcdYear", AcdYear);
        param[2] = new SqlParameter("@StartDate", startdate);
        param[3] = new SqlParameter("@EndDate", enddate);
        param[4] = new SqlParameter("@Operation", Operation);
        param[5] = new SqlParameter("@IsActive", IsActive);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[InsertUpdateAcdYear]");
        if (ds != null)
        {
            return ds.Tables[0];
        }
        else
        {
            return null;
        }
    }

    public DataTable GetPeriodDescData(string Period_Desc)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Period_Desc", Period_Desc);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[GetPeriodDescData]");
        return ds.Tables[0];
    }
    public DataTable GetFee_Cat_Data(string Fees_Category_Desc)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Category_Desc", Fees_Category_Desc);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[GetFee_Cat_Data]");
        return ds.Tables[0];
    }
    public DataTable GetFeeGroup_Detail_Data(string Fees_Pay_Type)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Pay_Type", Fees_Pay_Type);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[GetFeeGroup_Detail_Data]");
        return ds.Tables[0];
    }
    public DataTable Get_Fees_Item_Search(string Fees_Code)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Code", Fees_Code);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Get_Fees_Item_Search]");
        return ds.Tables[0];
    }
    public DataTable Get_Bank_Master_Search(string Bank_Name)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Bank_Name", Bank_Name);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Get_Bank_Master]");
        return ds.Tables[0];
    }
    public DataTable GetFee_Period_Data(string Period_Desc)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Period_Desc", Period_Desc);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[GetFee_Period_Data]");
        return ds.Tables[0];
    }
    public DataTable GetFeeGroup_Acadyear_Data(string acyear_id)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@acyear_id", acyear_id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[GetFeeGroup_Acadyear_Data]");
        return ds.Tables[0];

    }
    public DataTable Get_Tranc_Master_Search(string Transection_Type_Desc)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Transection_Type_Desc", Transection_Type_Desc);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Get_Tranc_Master_Search]");
        return ds.Tables[0];
    }
    public DataTable Get_Fee_Group_Master_Search(string Fees_Group_Desc)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Group_Desc", Fees_Group_Desc);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Get_Fee_Group_Master_Search]");
        return ds.Tables[0];
    }
    public DataTable SetGridView(int Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetGridView]");
        return ds.Tables[0];
    }

    public DataTable SetDropDown(int Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "SetDropdown");
        return ds.Tables[0];
    }
    public DataTable SetFeeCategory(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Category_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFeeCategory]");
        return ds.Tables[0];
    }
    public DataTable SetFee_Category_search(string Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFee_Category_search]");
        return ds.Tables[0];
    }
    public DataTable Set_Bank_Master_search(string Flag)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Flag", Flag);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Set_Bank_Master_search]");
        return ds.Tables[0];
    }
    public DataTable SetFee_Period(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Period_id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFeePeriod]");
        return ds.Tables[0];
    }

    public DataTable SetFeeGroupAcadyear(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Group_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFeeGroupAcadyear]");
        return ds.Tables[0];
    }
    public DataTable SetFee_Group_Acedamic_Master(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Group_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFee_Group_Acedamic_Master]");
        return ds.Tables[0];
    }
    public DataTable SetFee_Group_Acedamic_Detail(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Group_Det_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFee_Group_Acedamic_Detail]");
        return ds.Tables[0];
    }
    public DataTable SetFeeItems(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Fees_Items_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFeeItem]");
        return ds.Tables[0];

    }
    public DataTable Set_Bank_Master(string Id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Bank_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Set_Bank_Master]");
        return ds.Tables[0];
    }
    public DataTable Set_Trancs_Master(string Id)
    {

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Transection_Type_Id", Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Set_Trancs_Master]");
        return ds.Tables[0];

    }
    public DataTable SetProformaGrid(int Flag, string Value)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Value", Value);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetProformaGridView]");
        return ds.Tables[0];
    }



    public DataTable SetViewStudentProformaForPost(int Flag, string Value)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Value", Value);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetViewStudentProformaForPost]");
        return ds.Tables[0];
    }


    public DataTable GenerateStudentProformaInvoice(int Flag, string Value)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Value", Value);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[GenerateStudentProformaInvoice]");
        return ds.Tables[0];
    }




    public DataTable SetProformaStudentGrid(int Flag, string Value)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Value", Value);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetProformaStudentGridView]");
        return ds.Tables[0];
    }

    public DataTable SetExternalGroupDropdownList(int Flag, int acyearid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@acyear_id", acyearid);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetDropDownExternalGroupDDL]");
        return ds.Tables[0];
    }

    public DataTable SetFeeGroupDropdownList(int Flag, int acyearid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@acyear_id", acyearid);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetDropDownFeeGroupDDL]");
        return ds.Tables[0];
    }

    public DataTable SetExternalGroupDetails(int Flag, int externalid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Ext_Group_Id", externalid);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetExternalGroupGridViewDetails]");
        return ds.Tables[0];
    }

    public DataTable SetExternalAndFeeGroupDetails(int Flag, int accyaerid)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@acyear_id", accyaerid);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetExternalGroupFeeGroupDetails]");
        return ds.Tables[0];
    }


    public DataTable SetFeeGroupDetails(int Flag, int Fees_Group_Id)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Flag", Flag);
        param[1] = new SqlParameter("@Fees_Group_Id", Fees_Group_Id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[SetFeeGroupGridViewDetails]");
        return ds.Tables[0];
    }



    public DataTable Ret_Student_Create_Search_Group(string qryCond)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@qryCond", qryCond);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Ret_Student_Create_Search_Group]");
        return ds.Tables[0];
    }



    public string UpdateProformaApproval(int Proforma_inv_id, int ApprovalLevel)
    {
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateProformaApproval", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Proforma_inv_id", Proforma_inv_id);
            cmd.Parameters.AddWithValue("@ApprovalLevel", ApprovalLevel);
            using (conn)
                cmd.ExecuteNonQuery();
            conn.Close();
            return "Successful";
        }
        catch
        {
            return "error";
        }
    }

    public string UpdatePostInvoice(int Proforma_inv_id)
    {
        try
        {
            SqlConnection conn5 = new SqlConnection(ConfigurationManager.ConnectionStrings["TPSCon"].ToString());
            conn5.Open();
            SqlCommand cmd = new SqlCommand("Generate_Ivoice_From_Proforma_Invoice", conn5);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Proforma_inv_id", Proforma_inv_id);
            using (conn)
                cmd.ExecuteNonQuery();
            conn5.Close();
            return "Successful";
        }
        catch
        {
            return "error";
        }
    }
    public DataTable IsExists(int Proforma_inv_id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Proforma_inv_id", Proforma_inv_id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[ProcIsExists]");
        return ds.Tables[0];
    }

    public DataTable IsInvoiceExists(string Stu_id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Stu_id", Stu_id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[IsInvoiceExists]");
        return ds.Tables[0];
    }


    public DataTable InsertUpdateAcdGroup(string id, string AcdYear, string GroupName, string Operation)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@ID", id);
        param[1] = new SqlParameter("@AcdYear", AcdYear);
        param[2] = new SqlParameter("@GroupName", GroupName);
        param[3] = new SqlParameter("@Operation", Operation);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[InsertUpdateAcdGroup]");
        if (ds != null)
        {
            return ds.Tables[0];
        }
        else
        {
            return null;
        }
    }



    public DataTable IsStuidAndStudntGroupExists(string Stu_id, int Stu_Group_id)
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Stu_id", Stu_id);
        param[1] = new SqlParameter("@Stu_Group_Id", Stu_Group_id);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[IsStuidAndStudntGroupExists]");
        return ds.Tables[0];
    }

    public DataTable Insert_StudentGroup_Details(int Ext_Group_Id, string Stu_Id, string Stu_Name, string Stu_Class)
    {



        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Ext_Group_Id", Ext_Group_Id);
        param[1] = new SqlParameter("@Stu_Id", Stu_Id);
        param[2] = new SqlParameter("@Stu_Name", Stu_Name);
        param[3] = new SqlParameter("@Stu_Class", Stu_Class);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[Insert_StudentGroup_Details]");
        if (ds != null)
        {
            return ds.Tables[0];
        }
        else
        {
            return null;
        }


    }



    public DataTable IsPeriodDescriptionExists(string Period_Desc)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Period_Desc", Period_Desc);
        DataAccessLayer2 da = new DataAccessLayer2();
        DataSet ds = da.getDataByParam(param, "[IsPeriodDescriptionExists]");
        return ds.Tables[0];
    }

   


}