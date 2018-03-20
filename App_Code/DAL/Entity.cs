using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Configuration;


/// <summary>
/// Summary description for Entity
/// </summary>
public class Entity
{
	public Entity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    SqlConnection SqlConn;
    
    #region OpenConnection
    private void OpenConnection()
    {
        string strConnection;

        strConnection = WebConfigurationManager.ConnectionStrings["TPSCon"].ConnectionString;

            SqlConn = new SqlConnection(strConnection);
            SqlConn.Open();
   
     

    }
    #endregion

    #region ExecuteData
    public int ExecuteData(SqlCommand SqlCmd)
    {
        int intResult = 0;
        try
        {            
            OpenConnection();
            SqlCmd.Connection = SqlConn;
            intResult = SqlCmd.ExecuteNonQuery();
            SqlConn.Close();
            return intResult;
        }
        catch (Exception ex)
        {
            if (SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Close();
            }
            return intResult;
        }
    }
    #endregion

    #region RetrieveData
    public DataTable RetrieveData(string strQry)
    {
        DataTable dtRet = new DataTable();
        try
        {
            OpenConnection();
            SqlDataAdapter adp = new SqlDataAdapter(strQry, SqlConn);
            adp.Fill(dtRet);
            SqlConn.Close();
            return dtRet;
        }
        catch (Exception ex)
        {
            if (SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Close();
            }
            return dtRet;
        }
    }
    #endregion

    #region RetrieveData
    public DataTable RetrieveData(SqlCommand SqlCmd)
    {
        DataTable dtRet = new DataTable();
        try
        {
            OpenConnection();
            SqlCmd.Connection = SqlConn;
            SqlDataAdapter adp = new SqlDataAdapter(SqlCmd);
            adp.Fill(dtRet);
            SqlConn.Close();
            return dtRet;
        }
        catch (Exception ex)
        {

            if (SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Close();
            }
            return dtRet;
        }
    }
    #endregion

    #region RetrieveDataSet
    public DataSet RetrieveDataSet(SqlCommand SqlCmd)
    {
        DataSet dsRet = new DataSet();
        try
        {
            OpenConnection();
            SqlCmd.Connection = SqlConn;
            SqlDataAdapter adp = new SqlDataAdapter(SqlCmd);
            adp.Fill(dsRet);
            SqlConn.Close();
            return dsRet;
        }
        catch (Exception ex)
        {

            if (SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Close();
            }
            return dsRet;
        }
    }
    #endregion
    #region isnumeric
    public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
    {
        Double result;
        return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
    }
    #endregion


   


}

