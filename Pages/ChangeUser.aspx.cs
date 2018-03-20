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

public partial class Pages_ChangeUser : System.Web.UI.Page
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
                    ddl_FromEmployee.DataSource = s.GetMarktingAllEmployee();
                    ddl_FromEmployee.DataTextField = "EMPNAME";
                    ddl_FromEmployee.DataValueField = "EMPID";
                    ddl_FromEmployee.DataBind(); 
                }
            }
            catch
            {
            }
        }
    }

    protected void ddl_FromEmployeeselectedindex_Changed(object sender, EventArgs e)
    {
        ddl_toEmployee.DataSource = s.GetMarktingActiveToEmployee(Convert.ToInt16(ddl_FromEmployee.SelectedItem.Value));
        ddl_toEmployee.DataTextField = "EMPNAME";
        ddl_toEmployee.DataValueField = "EMPID";
        ddl_toEmployee.DataBind();
        bindgrid1();
    }

    protected void ddl_toEmployeeselectedindex_Changed(object sender, EventArgs e)
    {
        bindgrid2();
    }

    protected void bindgrid1()
    {
        GridShow1.DataSource = s.FillGridMarketingStudents(Convert.ToInt16(ddl_FromEmployee.SelectedItem.Value));
        GridShow1.DataBind();
    }

    protected void bindgrid2()
    {
        GridShow2.DataSource = s.FillGridMarketingStudents(Convert.ToInt16(ddl_toEmployee.SelectedItem.Value));
        GridShow2.DataBind();
    }

    protected void btn_Transfer_Click(object sender, EventArgs e)
    {
       // StudentRegistrationDAL d = new StudentRegistrationDAL();
        foreach (GridViewRow row in GridShow1.Rows)
        {
            HiddenField hidvalue = (HiddenField)row.FindControl("hid_Empid1");
            int FromId = Convert.ToInt16(ddl_FromEmployee.SelectedItem.Value);
            int ToId = Convert.ToInt16(ddl_toEmployee.SelectedItem.Value);

            if (row.RowType == DataControlRowType.DataRow)
            {
                if (((CheckBox)row.FindControl("chk_approval")).Checked)
                {
                    int Result = StudentRegistrationDAL.Transferusername(FromId, ToId);
                    lbl_ack.Visible = true;
                }
            }
        }
    }

}