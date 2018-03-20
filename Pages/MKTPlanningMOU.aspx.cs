using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Pages_MKTPlanningMOU : System.Web.UI.Page
{
    StudentRegistrationDAL S = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateDropDown();
        }
    }
    protected void PopulateDropDown()
    {

        DrpCategory.DataSource = S.getcategory("Scholarship");
        DrpCategory.DataTextField = "Category";
        DrpCategory.DataValueField = "id";
        DrpCategory.DataBind();
        DrpCategory.Items.Insert(0, new ListItem("SELECT", "0"));

        DrpAcyear.DataSource = S.GetAcademicYear();
        DrpAcyear.DataTextField = "Accadyear_Desc";
        DrpAcyear.DataValueField = "acyear_id";
        DrpAcyear.DataBind();

    }
    protected void BindGrid()
    {
        DataTable Dtb = S.Insert_MKTPLANNING_MOU("SUBCATEGORY", DrpCategory.SelectedItem.Text, "", 0, 0, 0, Convert.ToInt32(DrpAcyear.SelectedValue));
        GrvGrid.DataSource = Dtb;
        GrvGrid.DataBind();
    }
    protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
     protected void GrvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox Chkadd = (CheckBox)e.Row.FindControl("chkRow");
            CheckBox ChkDelete = (CheckBox)e.Row.FindControl("chkDelete");
            HiddenField HdnValue = (HiddenField)e.Row.FindControl("HdnValue");
            if (Convert.ToInt32(HdnValue.Value) == 1)
            {
                ChkDelete.Enabled = true;
                Chkadd.Enabled = false;
                e.Row.BackColor = System.Drawing.Color.LightBlue;
            }
            else
            {
                ChkDelete.Enabled = false;
                Chkadd.Enabled = true;
            }
        }
    }
     protected void GrvGrid_RowCommand(object sender, GridViewCommandEventArgs e)
     {
     }
     protected void BtnSave_Click(object sender, EventArgs e)
     {
         if  (Convert.ToInt32(DrpAcyear.SelectedValue)==0)
         {
             LblDisplayMessage.Text = "Please select Academic year !!";
             return;
         }
         else if (Convert.ToInt32(DrpCategory.SelectedValue) == 0)
         {
             LblDisplayMessage.Text = "Please select Category!!";
             return;
         }
         save();
     }
     public void save()
     {

          int countsave = 0;
          int countDelete = 0;
          foreach (GridViewRow row in GrvGrid.Rows)
          {
              CheckBox chk = (CheckBox)row.FindControl("chkRow");
              CheckBox chkDelete = (CheckBox)row.FindControl("chkDelete");
              HiddenField HdnCategoryID=(HiddenField)row.FindControl("HdnCategoryID");
              Label lblSubcategory=(Label)row.FindControl("lblSubcategory");
              HiddenField HdnPlanningID = (HiddenField)row.FindControl("HdnPlanningID");
              if (chk.Checked == true)
              {
                  DataTable Dtb = S.Insert_MKTPLANNING_MOU("INSERT", DrpCategory.SelectedItem.Text, lblSubcategory.Text, Convert.ToInt32(HdnCategoryID.Value), int.Parse(Session["EmpId"].ToString()), 0, Convert.ToInt32(DrpAcyear.SelectedValue));
                  countsave++;
              }
              if (chkDelete.Checked == true)
              {
                  DataTable Dtb = S.Insert_MKTPLANNING_MOU("DELETE", DrpCategory.SelectedItem.Text, lblSubcategory.Text, Convert.ToInt32(HdnCategoryID.Value), int.Parse(Session["EmpId"].ToString()), Convert.ToInt32(HdnPlanningID.Value), Convert.ToInt32(DrpAcyear.SelectedValue));
                  countDelete++;
              }
          }

          if (countsave == 0 && countDelete==0)
              LblDisplayMessage.Text = "Please select data !!";
          else
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data saved succesfully!!');", true);
              BindGrid();
          }

        
     }
     protected void DrpAcyear_SelectedIndexChanged(object sender, EventArgs e)
     {
         BindGrid();
     }
}