using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_SendBatch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindListBox();
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Attendance a = new Attendance();
        DataTable dtBatch = new DataTable("dtBatch");
        dtBatch.Columns.Add("Batch");        
        for (int i = 0; i < chkSelectedList.Items.Count; i++)
        {
            DataRow dr = dtBatch.NewRow();
            dr["Batch"] = chkSelectedList.Items[i].Text;
            dtBatch.Rows.Add(dr);            
        }
        Session["dtBatch"] = dtBatch;
        Response.Redirect("SendMail.aspx", false);
    }
    protected void btnMoveRight_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkSelectList.Items.Count; i++)
        {
            if (chkSelectList.Items[i].Selected)
            {
                chkSelectedList.Items.Add(chkSelectList.Items[i].Text);
                chkSelectList.Items.Remove(chkSelectList.Items[i].Text);
            }
        }        
    }
    protected void btnMoveLeft_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkSelectedList.Items.Count; i++)
        {
            if (chkSelectedList.Items[i].Selected)
            {
                chkSelectList.Items.Add(chkSelectedList.Items[i].Text);
                chkSelectedList.Items.Remove(chkSelectedList.Items[i].Text);
            }
        }
    }
    public void BindListBox()
    {
        Attendance a = new Attendance();
        lbLevel.DataSource = a.GetLevel();
        lbLevel.DataTextField = "Level";
        lbLevel.DataValueField = "Level";
        lbLevel.DataBind();
    }
    protected void lbLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Attendance a = new Attendance();
        chkSelectList.DataSource = a.GetAllBatches(lbLevel.SelectedValue, lbTiming.SelectedValue, Session["EMPID"].ToString());
        chkSelectList.DataTextField = "batchcode";
        chkSelectList.DataValueField = "batchcode";
        chkSelectList.DataBind();
    }
    protected void lbTiming_SelectedIndexChanged(object sender, EventArgs e)
    {
        Attendance a = new Attendance();
        chkSelectList.DataSource = a.GetAllBatches(lbLevel.SelectedValue, lbTiming.SelectedValue, Session["EMPID"].ToString());
        chkSelectList.DataTextField = "batchcode";
        chkSelectList.DataValueField = "batchcode";
        chkSelectList.DataBind();
    }
}