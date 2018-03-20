using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_ProformaInvoice : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Setup s = new Setup();
                string Id = Request.QueryString["Id"].ToString();
              //  s.GenerateStudentProformaInvoice(1, Id);
                LoadGrid(Id);
            }
            catch
            {
            }
        }
    }
    public void LoadGrid(string Id)
    {
        Setup s = new Setup();
        GridFee_Group_Acedamic_Details.DataSource = s.GenerateStudentProformaInvoice(1, Id);
        GridFee_Group_Acedamic_Details.DataBind();
    }
    protected void GridFee_Group_Acedamic_Details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int proformaid = int.Parse(e.CommandArgument.ToString());

        Setup s = new Setup();
        DataTable dt = s.IsExists(proformaid);
        foreach (DataRow ro in dt.Rows)
        {
            if (e.CommandName == "Approve2")
            {
                if (ro["Approve1"].ToString() != "True")
                {
                    Response.Write("<script Language='JavaScript'> alert('Please Click on Approve 1 First!')</script>");
                    return;
                }
            }
            if (e.CommandName == "Approve3")
            {
                if (ro["Approve1"].ToString() != "True")
                {
                    Response.Write("<script Language='JavaScript'> alert('Please Click on Approve 1 First!')</script>");
                    return;
                }
                else if (ro["Approve2"].ToString() != "True")
                {
                    Response.Write("<script Language='JavaScript'> alert('Please Click on Approve 2 First!')</script>");
                    return;
                }
            }
        }
        if (e.CommandName == "Approve1")
        {
            string msg = s.UpdateProformaApproval(proformaid, 1);
            lblMessage.Text = msg;
        }
        if (e.CommandName == "Approve2")
        {
            string msg = s.UpdateProformaApproval(proformaid, 2);
            lblMessage.Text = msg;

        }
        if (e.CommandName == "Approve3")
        {
            string msg = s.UpdateProformaApproval(proformaid, 3);
            lblMessage.Text = msg;
        }
        if (e.CommandName == "post")
        {
            string msg = s.UpdatePostInvoice(proformaid);
            lblMessage.Text = msg;
            Response.Write("<script Language='JavaScript'> alert('Sucessfully Posted!')</script>");
        }
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            LoadGrid(Id);
        }
        catch
        {
        }
        //load_proforma_grid(HdnStudid.Value);
    }
    protected void GridFee_Group_Acedamic_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

            //Label lblPInvoiceId = (Label)e.Row.Cells[e.Row.RowIndex].FindControl("Proformaid");

            //int Id = int.Parse(lblPInvoiceId.Text);
            //Button btnPost = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnPost");
            //Setup s = new Setup();
            //DataTable dt = s.IsExists(Id);
            //foreach (DataRow ro in dt.Rows)
            //{
            //    if (ro["Approve1"].ToString() == "True")
            //    {
            //        Button btnApprove1 = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnApprove1");
            //        btnApprove1.Enabled = false;
            //        btnApprove1.Text = "Approved";
            //        btnApprove1.BackColor = System.Drawing.Color.Green;
            //        btnApprove1.ForeColor = System.Drawing.Color.White;
            //    }
            //    else
            //    {
            //        Button btnApprove1 = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnApprove1");
            //        btnApprove1.Enabled = true;
            //        btnApprove1.Text = "Approve";
            //        btnApprove1.BackColor = System.Drawing.Color.Red;
            //        btnApprove1.ForeColor = System.Drawing.Color.White;
            //    }
            //    if (ro["Approve2"].ToString() == "True")
            //    {
            //        Button btnApprove2 = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnApprove2");
            //        btnApprove2.Enabled = true;
            //        btnApprove2.Text = "Approved";
            //        btnApprove2.BackColor = System.Drawing.Color.Green;
            //        btnApprove2.ForeColor = System.Drawing.Color.White;
            //    }
            //    else
            //    {
            //        Button btnApprove2 = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnApprove2");
            //        btnApprove2.Enabled = true;
            //        btnApprove2.Text = "Approve";
            //        btnApprove2.BackColor = System.Drawing.Color.Red;
            //        btnApprove2.ForeColor = System.Drawing.Color.White;
            //    }
            //    if (ro["Approve3"].ToString() == "True")
            //    {
            //        Button btnApprove3 = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnApprove3");
            //        btnApprove3.Enabled = true;
            //        btnApprove3.Text = "Approved";
            //        btnApprove3.BackColor = System.Drawing.Color.Green;
            //        btnApprove3.ForeColor = System.Drawing.Color.White;
            //    }
            //    else
            //    {
            //        Button btnApprove3 = (Button)e.Row.Cells[e.Row.RowIndex].FindControl("btnApprove3");
            //        btnApprove3.Enabled = true;
            //        btnApprove3.Text = "Approve";
            //        btnApprove3.BackColor = System.Drawing.Color.Red;
            //        btnApprove3.ForeColor = System.Drawing.Color.White;
            //    }
            //    if (ro["Approve1"].ToString() == "True" && ro["Approve2"].ToString() == "True" && ro["Approve3"].ToString() == "True")
            //    {
            //        btnPost.Enabled = true;
            //        btnPost.Text = "Post";
            //        btnPost.BackColor = System.Drawing.Color.Green;
            //        btnPost.ForeColor = System.Drawing.Color.White;
            //    }
            //    else
            //    {
            //        btnPost.Enabled = false;
            //        btnPost.Text = "Post";
            //        btnPost.BackColor = System.Drawing.Color.Red;
            //        btnPost.ForeColor = System.Drawing.Color.White;
            //    }
            //    foreach (DataRow ro1 in dt.Rows)
            //    {
            //        if (ro["inv_id"].ToString() == "")
            //        {
            //            btnPost.BackColor = System.Drawing.Color.Red;
            //            btnPost.Enabled = true;
            //            btnPost.Text = "Post";
            //        }
            //        else
            //        {
            //            btnPost.BackColor = System.Drawing.Color.Green;
            //            btnPost.Enabled = false;
            //            btnPost.Text = "Posted";
            //        }
            //    }
            //}
        //}

    }
    protected void lbGoBack_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string LinkId = s.GetLinkIdByRegNo(Request.QueryString["Id"].ToString());
        Response.Redirect(string.Format("StudentRegistration.aspx?Id={0}", LinkId), false);
    }
}