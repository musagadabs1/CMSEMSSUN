using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class DataAccessLayer1
{
    private string connection;
	public DataAccessLayer1()
	{
		//
		// TODO: Add constructor logic here
        connection = null;
        //this.connection = "Data Source=xclusive21;Initial Catalog=cooperative;Integrated Security=True;";
        this.connection = ConfigurationManager.ConnectionStrings["SkyLineErp"].ToString();
		//
	}

    public bool isInsert(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return false;
    }
    public DataSet getDataByParam(string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }

    public DataSet getDataByParam(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlDataAdapter dataAdapter = null;
        DataSet ds = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            dataAdapter = new SqlDataAdapter(strStoreProcedure, con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            int i = param.Length;
            for (int j = 0; j < i; j++)
                dataAdapter.SelectCommand.Parameters.Add(param[j]);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            dataAdapter.Fill(ds);
            if (ds != null && ds.Tables.Count > 0)
                return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
            dataAdapter.Dispose();
            ds.Dispose();
        }
        return null;
    }
    public bool isDelete(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return false;
    }

    public bool isUpdate(SqlParameter[] param, string strStoreProcedure)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return false;
    }
    public int getResultByParam(SqlParameter[] param, string strStoreProcedure, string strOutput)
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        int result = 0;
        try
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(strStoreProcedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int i = param.Length;
            for (int j = 0; j < i; j++)
                cmd.Parameters.Add(param[j]);
            cmd.ExecuteScalar();
            result = Convert.ToInt32(cmd.Parameters[strOutput].Value.ToString());
            return result;
        }
        catch (SqlException e)
        {
            System.Console.Write(e.Message);
        }
        finally
        {
            cmd.Dispose();
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
        return result;
    }
}