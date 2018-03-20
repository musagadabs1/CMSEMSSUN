using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.NetworkInformation;

public partial class Pages_Exhibition : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    Label L;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLAyear.DataSource = s.GetAcYear();
            DDLAyear.DataTextField = "YEAR";
            DDLAyear.DataValueField = "YEAR";
            DDLAyear.DataBind();
            LoadGrid();
        }
    }

    private void LoadGrid()
    {
        GrdExhibition.DataSource = s.GetExhibition(0);
        GrdExhibition.DataBind();
    }

    private void LoadMonth()
    {
        DDlMonth.DataSource = s.GetMonthName();
        DDlMonth.DataTextField = "MonthName";
        DDlMonth.DataValueField = "ID";
        DDlMonth.DataBind();
        LoadExhibition();
    }
    protected void DDLExp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearData();
        DataTable Dt = s.GetExbhibitionDate(Convert.ToInt32(DDLExp.SelectedValue) );
        TxtDate.Text = Dt.Rows[0][0].ToString();
    }

    private void LoadExhibition()
    {
        DDLExp.DataSource = s.GetExhibition(DDLAyear.SelectedValue, Convert.ToInt32(DDlMonth.SelectedValue));
        DDLExp.DataTextField = "EventTitle";
        DDLExp.DataValueField = "Cal_UniqueID";
        DDLExp.DataBind();
    }
    protected void DDlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadExhibition();
        ClearData();
    }
    protected void DDLAyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMonth();
        LoadExhibition();
        ClearData();
    }


    public void ClearData()
    {
        TxtDate.Text = "";
        TxtReqStaff.Text = "";
        TxtStand.Text = "";
        TxtVenue.Text = "";
       
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        try
        {

            String IPAddress = GetMacAddress();
            DateTime Date = DateTime.Parse(TxtDate.Text);

            int Result = s.InsertExhibition(0, Convert.ToInt32(DDLExp.SelectedValue), DDLAyear.SelectedValue.ToString(), Convert.ToInt32(DDlMonth.SelectedValue), DDLExp.SelectedItem.Text, Date, TxtVenue.Text, TxtReqStaff.Text, TxtStand.Text, Session["EMPID"].ToString(), IPAddress, "Insert");
            ClearData();
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Successfully');", true);
        }
        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + Ex.ToString() + "');", true);
        }
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

    protected void EditExhibition(object sender, EventArgs e)
    {
        LinkButton lnkEdit = (LinkButton)sender;       
        SetData(Convert.ToInt32 (lnkEdit.CommandArgument));
        BtnUpdate.Visible = true;
        BtnSave.Visible = false;
      
    }
    protected void DeleteExhibition(object sender, EventArgs e)
    {

        try
        {

            LinkButton lnkRemove = (LinkButton)sender;
            String IPAddress = GetMacAddress();
            int Result = s.InsertExhibition(Convert.ToInt32(lnkRemove.CommandArgument), 0, "", 0, "", DateTime.Now, "", "", "", Session["EMPID"].ToString(), IPAddress, "Delete");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted Successfully');", true);
            LoadExhibition();
            LoadGrid();
        }
        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + Ex.ToString() + "');", true);
        }
    }

    public void SetData( int ID)
    {
       
       DataTable DT = s.GetExhibition(ID);
       DDLAyear.SelectedValue = DT.Rows[0]["AYEAR"].ToString();
       LoadMonth();
       DDlMonth.SelectedValue = DT.Rows[0]["Month"].ToString();

       LoadExhibition();
       DDLExp.SelectedValue = DT.Rows[0]["UniqueID"].ToString();
       TxtDate.Text  = DT.Rows[0]["Date"].ToString();
       TxtVenue.Text = DT.Rows[0]["Venue"].ToString();
       TxtReqStaff.Text = DT.Rows[0]["RequiredStaff"].ToString();
       TxtStand.Text = DT.Rows[0]["Stand"].ToString();
       TxtID.Text =Convert .ToString( ID);
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            String IPAddress = GetMacAddress();
            DateTime Date = DateTime.Parse(TxtDate.Text);
            if (TxtID.Text != "")
            {
                int Result = s.InsertExhibition(Convert.ToInt32(TxtID.Text), Convert.ToInt32(DDLExp.SelectedValue), DDLAyear.SelectedValue.ToString(), Convert.ToInt32(DDlMonth.SelectedValue), DDLExp.SelectedItem.Text, Date, TxtVenue.Text, TxtReqStaff.Text, TxtStand.Text, Session["EMPID"].ToString(), IPAddress, "Update");
            }
            ClearData();
            TxtID.Text = "";
            BtnUpdate.Visible = false;
            BtnSave.Visible = true;
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated Successfully');", true);
        }

        catch (Exception Ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+Ex.ToString() +"');", true);
        }
    }
 
}