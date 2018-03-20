using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using Microsoft.CSharp;
using System.Text;
/// <summary>
/// Summary description for DBHandler
/// </summary>
public class DBHandler
{
    private string _constr;
    SqlDataAdapter adaptor;

    public string FirstName { get; set; }
    public string ConnectionString { get { _constr = ConfigurationManager.ConnectionStrings["SkyLineConnection"].ConnectionString; return _constr; } set { _constr = value; } }

    public SqlDataReader CreateReader(string Strsql)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            

            con.ConnectionString = this.ConnectionString;
            con.Open();
            SqlDataReader Rd;
            SqlCommand cmd = new SqlCommand(Strsql, con);
            Rd = cmd.ExecuteReader();
            //con.Close();
            return Rd;

        }
        catch (Exception ex)
        {
            return null;
            throw ex;

        }
        //    //Added By nisha
        //finally
        //{
        //    if (con.State.Equals("Open"))
        //        con.Close();
        //    con.Dispose();
        //}
    }


    public object GetResult(string Strsql, bool IsStoredProcedure = false, ArrayList pa = null, ArrayList pv = null)
    {
        SqlConnection con = new SqlConnection();
        try
        {
           
            object Result;
            con.ConnectionString = this.ConnectionString;
            con.Open();
            SqlDataReader Rd;
            SqlCommand cmd = new SqlCommand(Strsql, con);
            if (IsStoredProcedure == true)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int count = 0; count < pa.Count; count++)
                {
                    // pa[count] = pv[count];
                    cmd.Parameters.AddWithValue(pa[count].ToString(), pv[count]);
                }
            }

            Rd = cmd.ExecuteReader();
            Rd.Read();
            if (Rd.HasRows)
            {
                Result = Rd[0];
            }
            else { Result = ""; }
            con.Close();
            return Result;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
            //Added by nisha
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
    }



    public void CreateDataTable(DataTable DT, string StrSql, bool IsStoredProcedure = false, ArrayList pa = null, ArrayList pv = null)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            DT.Rows.Clear();
          
            con.ConnectionString = this.ConnectionString;
            con.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(StrSql ,con);
            adaptor.SelectCommand.CommandTimeout = 5000;

            if (IsStoredProcedure == true)
            {
                adaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                for (int count = 0; count < pa.Count; count++)
                {
                   // pa[count] = pv[count];
                    adaptor.SelectCommand.Parameters.AddWithValue(pa[count].ToString(), pv[count]);
                }
            }
            adaptor.Fill(DT);
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //Added by nisha
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
    }


    void ExecuteSP(string Strsql, bool Isstoredprocdure = true, ArrayList pa = null, ArrayList pv = null)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            
            SqlCommand com = new SqlCommand();
            con.ConnectionString = this.ConnectionString;
            con.Open();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = Strsql;
            for (int count = 0; count < pa.Count; count++)
            {
                com.Parameters.AddWithValue(pa[count].ToString(), pv[count]);
            }
            com.ExecuteScalar();
            con.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        //Added by nisha
        finally
        {
            if (con.State.Equals("Open"))
                con.Close();
            con.Dispose();
        }
    }


    public string getxml( DataTable table, string RootName)
    {
        StringBuilder XMLString = new StringBuilder();
        if (string.IsNullOrEmpty(RootName)) {
            table.TableName = "DataTable";
        }
        else
        {
            table.TableName = RootName;
        }
        XMLString.AppendFormat("<{0}>", table.TableName);
        DataColumnCollection tablecolumns = table.Columns;
        foreach (DataRow row in table.Rows) 
        {
            XMLString.AppendFormat("<RowData>");
            foreach (DataColumn column in table.Columns)
            {
               // XMLString.AppendFormat("<{1}><{0}><{1}>", row[column].ToString(), column.ColumnName);
                XMLString.AppendFormat("<{1}>{0}</{1}>", row[column].ToString(), column.ColumnName);
            }
            XMLString.AppendFormat("</RowData>");
        }
        XMLString.AppendFormat("</{0}>", table.TableName);
        return XMLString.ToString();
    }


    public string addroot(string xml, string myroot = "myroot") {
        xml = "<" + myroot + ">" + xml + "</" + myroot + ">";
        return xml;
    }

    public void CreateDataTable_TPS(DataTable DT, string StrSql, bool IsStoredProcedure = false, ArrayList pa = null, ArrayList pv = null)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            DT.Rows.Clear();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["TPSCON"].ToString(); 
            con.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(StrSql, con);

            if (IsStoredProcedure == true)
            {
                adaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                for (int count = 0; count < pa.Count; count++)
                {
                    // pa[count] = pv[count];
                    adaptor.SelectCommand.Parameters.AddWithValue(pa[count].ToString(), pv[count]);
                }
            }
            adaptor.Fill(DT);
            con.Close();
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
        }
    }


    public void CreateDataTableCalender(DataTable DT, string StrSql, bool IsStoredProcedure = false, ArrayList pa = null, ArrayList pv = null)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-RECM1EAA\\SQLEXPRESS;Initial Catalog=DB_SkylineCalendarEvents; User ID=software; Password=DelFirMENA$idea;");
        try
        {
            DT.Rows.Clear();
         
            //con.ConnectionString = this.ConnectionString;
            con.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(StrSql, con);
            adaptor.SelectCommand.CommandTimeout = 5000;

            if (IsStoredProcedure == true)
            {
                adaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (pa != null)
                {
                    for (int count = 0; count < pa.Count; count++)
                    {
                        // pa[count] = pv[count];
                        adaptor.SelectCommand.Parameters.AddWithValue(pa[count].ToString(), pv[count]);
                    }
                }
            }
            adaptor.Fill(DT);
            con.Close();
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
        }
    }

}