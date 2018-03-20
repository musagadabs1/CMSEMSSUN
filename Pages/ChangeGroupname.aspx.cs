using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Configuration;

public partial class Pages_ChangeGroupname : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["EMPID"].ToString() == "918")
                {
                   
                    ddl_Empname.DataSource     = s.GetMarktingActiveEmployee();
                    ddl_Empname.DataTextField  = "EMPNAME";
                    ddl_Empname.DataValueField = "EMPID";
                    ddl_Empname.DataBind();

                    ddl_Group.DataSource       = s.GetActiveEMSGroupNationality();
                    ddl_Group.DataTextField    = "NationalityCode";
                    ddl_Group.DataValueField   = "NationalityCode";
                    ddl_Group.DataBind();

                    ddl_state.DataSource = s.GetActiveEMSState();
                    ddl_state.DataTextField = "State";
                    ddl_state.DataValueField = "ID";
                    ddl_state.DataBind();



                }
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void ddl_EmpName_Selectedindex_Changed(object sender, EventArgs e)
    {
        string empid = Convert.ToString(ddl_Empname.SelectedItem.Value);
        DataTable dt = s.GetCurrentGroup(empid);
        if (dt.Rows.Count > 0)
        {
            lbl_currentgroup.Text = dt.Rows[0]["GROUPNAME"].ToString();
            lbl_states.Text = dt.Rows[0]["State"].ToString();
        }
        lblmsg.Visible = false;
    }
    

    protected void Grid_Details_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("Ddl_group"); 
        }
    }

    protected void btn_update(object sender, EventArgs e)
    {
        int result = 0;
        int empid = Convert.ToInt16(ddl_Empname.SelectedItem.Value);
        string groupname = Convert.ToString(ddl_Group.SelectedItem.Value);
        int stateId = Convert.ToInt16(ddl_state.SelectedValue);
        bool followupmail;
        if (Rad_but1.SelectedValue == "1")
        {
            followupmail = true;
        }
        else
        {
            followupmail = false;
        }

        bool ReportAccess;
        if (Rad_but2.SelectedValue == "1")
        {
            ReportAccess = true;
        }
        else
        {
            ReportAccess = false;
        }

        result = StudentRegistrationDAL.UpdateGroupname(empid, groupname, stateId, followupmail, ReportAccess,Session["EMPID"].ToString(), GetMacAddress());
        lblmsg.Visible = true;
        lblmsg.Text = "Successfully Updated!!!";

        string empid1 = Convert.ToString(ddl_Empname.SelectedItem.Value);
        DataTable dt = s.GetCurrentGroup(empid1);

        if (dt.Rows.Count > 0)
        {
            lbl_currentgroup.Text = dt.Rows[0]["GROUPNAME"].ToString();
        }

        ddl_Empname.SelectedIndex = -1;
        ddl_Group.SelectedIndex = -1;
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

}