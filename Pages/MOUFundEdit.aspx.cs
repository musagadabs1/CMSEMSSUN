using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

public partial class Pages_MOUFundEdit : System.Web.UI.Page
{
    string con = ConfigurationManager.ConnectionStrings["SkyLineConnection"].ConnectionString;
    SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                {
                    ddl_moucat.DataSource = s.getcategory("O");
                    ddl_moucat.DataTextField = "Category";
                    ddl_moucat.DataValueField = "id";
                    ddl_moucat.DataBind();                    
                }
            }
            catch
            {
            }              
        }

    }

    protected void ddlSubcatLoad_selectedindexchanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            {
                string category = ddl_moucat.SelectedItem.Text.ToString();
                ddl_subcat.DataSource = s.getSubcategory(category);
                ddl_subcat.DataTextField = "Subcategory";
                ddl_subcat.DataValueField = "Subcategory";
                ddl_subcat.DataBind();
            }
        }
        catch
        {
        }
    }

    private void Bindgrid()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        int catid = Convert.ToInt32(ddl_moucat.SelectedItem.Value);
        gvTOC.DataSource = s.GetFundDetails(catid);
        gvTOC.DataBind();
    }

    protected void btn_search_moufund(object sender, EventArgs e)
    {
        Bindgrid();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTOC.EditIndex = -1;
        Bindgrid();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTOC.EditIndex = e.NewEditIndex;
        Bindgrid();
    }


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        HiddenField hidval = (HiddenField)gvTOC.Rows[e.RowIndex].FindControl("hid_sno");        
        DropDownList ddl = (DropDownList)gvTOC.Rows[e.RowIndex].FindControl("ddl_1");
        DropDownList dd2 = (DropDownList)gvTOC.Rows[e.RowIndex].FindControl("ddl_2");
        DropDownList dd3 = (DropDownList)gvTOC.Rows[e.RowIndex].FindControl("ddl_3");
        TextBox tx1 = (TextBox)gvTOC.Rows[e.RowIndex].FindControl("txt_Approvefund");    
        DateTime changeddate = Convert.ToDateTime(DateTime.Now.ToString());
        int empid = Convert.ToInt16(Session["EmpId"].ToString());
        string ip = GetMacAddress();
        sqlcon = new SqlConnection(con);
        sqlcon.Open();
        string sql = "update tblmoucategoryfund_test set degreeid='" + ddl.SelectedValue.ToString() + "',Termid='" + dd2.SelectedValue.ToString() + "',Percentage='" +
            dd3.SelectedValue.ToString() + "',Approvefund='" + tx1.Text + "', Updateddate='" + changeddate + "',Updatedby="+empid+" ,UpdatedIp='"+ip+"' where SNO='" +
            hidval.Value + "'";

        SqlCommand cmd = new SqlCommand(sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlcon;
        cmd.ExecuteNonQuery();
        sqlcon.Close();
        lblmsg.Text = "Successfully Updated";           
        gvTOC.EditIndex = -1;
        Bindgrid();
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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hidval = (HiddenField)gvTOC.Rows[e.RowIndex].FindControl("hid_no");
        string hid = hidval.Value;
        sqlcon = new SqlConnection(con);
        sqlcon.Open();
        string sql = "Delete tblmoucategoryfund_test  where SNO='" +
            hidval.Value + "'";

        SqlCommand cmd = new SqlCommand(sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlcon;
        cmd.ExecuteNonQuery();
        sqlcon.Close();
       // gvTOC.EditIndex = -1;
        Bindgrid();
    }
    

    
 
    public DataTable load_term()
    {
        DataTable dt = new DataTable();
        sqlcon = new SqlConnection(con);
        sqlcon.Open();
        string sql = " SELECT TermId,TermName,Termyear,Isactive from tblTerm where isactive=1";
        SqlCommand cmd = new SqlCommand(sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlcon;
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        sd.Fill(dt);
        return dt;        
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList dp = (DropDownList)e.Row.FindControl("ddl_2");
                DataTable dt = load_term();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem lt = new ListItem();
                    lt.Text = dt.Rows[i][1].ToString();
                    lt.Value = dt.Rows[i][0].ToString();
                    dp.Items.Add(lt);
                } 

            }

        }
    }

}