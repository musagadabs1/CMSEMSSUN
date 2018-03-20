using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Text;

public partial class Pages_Onlineregistraiontransfer : System.Web.UI.Page
{
     private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["EMPID1"] = Session["EMPID"].ToString();
                //dsDetails.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();

                //dsDetails.Update();


                Session["option1"] = "1".ToString();
                lblmsg.Text = "";
                          
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
       
    }
 


    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
        RegExp.Replace("/", "");
        // Highlight keywords by calling the 
        //delegate each time a keyword is found.
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
    }

    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //  Set the value of the SearchString so it gets
        Label1.Text = "";
        SearchString = txtSearch.Text;
    }

    protected void chkall_checkedchanged(object sender, EventArgs e)
    {
        if (chkall.Checked == false)
            Session["EMPID1"] = Session["EMPID"].ToString();
        else
            Session["EMPID1"] = "0";

        dsDetails.UpdateParameters["empid"].DefaultValue = Session["EMPID1"].ToString();

        dsDetails.Update();


    }
     
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        txtSearch.Text = "";
        SearchString = "";
        gvDetails.DataBind();
        lblmsg.Text = "";
    }
    protected void btnview_Click(object sender, ImageClickEventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        Response.Redirect("OnlineImportedView.aspx");
       
    }


    protected void btnimport_Click(object sender, ImageClickEventArgs e)
    {
        lblmsg.Text = "";
        Label1.Text = "";
        DataTable Result=null;
        StudentRegistrationDAL s = new StudentRegistrationDAL();


        try
        {
            if ((Session["EMPID"].ToString() == null) || (Session["EMPID"].ToString() == ""))
            {

                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "if(!alert('Session Expired!Login Again')){self.close();}", true);
                HTMLHelper.jsAlertAndRedirect(this, "Session Expired!Login Again", "../login.aspx");

            }
            foreach (GridViewRow gr in gvDetails.Rows)
            {
                HiddenField HdId = (HiddenField)gr.FindControl("hdnid");
                CheckBox chk = (CheckBox)gr.FindControl("chkApprove");
                if (chk.Checked == true)
                {
                    Result = s.InsertOnlineImport(int.Parse(Session["EMPID"].ToString()),HdId.Value);
                   
                }

            }
            if (Result.Rows[0][0].ToString() == "1".ToString())
            {
                Label1.Visible= true;
   
                Label1.Text = "Data Saved Sucessfully.";
                Label1.ForeColor = System.Drawing.Color.Blue;

                try
                {
                    dsDetails.Update();
                }
                catch(Exception ex)
                {

                }

                gvDetails.DataBind();
            }


            else  if (Result.Rows[0][0].ToString() == "0".ToString())
            {
                Label1.Visible = true;

                Label1.Text = "Data Already Imported to CMS.";
                Label1.ForeColor = System.Drawing.Color.Green;

                try
                {
                    dsDetails.Update();
                }
                catch (Exception ex)
                {

                }

                gvDetails.DataBind();
            }


        }
        catch    
        {
            Label1.Text = Result.Rows[0][0].ToString() +"Try Again! .";
            Label1.ForeColor = System.Drawing.Color.Red;
        }

      
    }



    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
           


                if (e.CommandName == "ShowPopup")
                {
                    LinkButton btndetails = (LinkButton)e.CommandSource;
                    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                         
                }
                     
            }
        catch
        {

        }
        }

   




           //  Response.Redirect(string.Format("FollowUp.aspx?Id={0}", Id), false);


    protected void popup_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        string ids = gvDetails.DataKeys[gRow.RowIndex].Value.ToString();
        grdids.DataSource = s.GetOnlinedetailsIndividual(ids);
        grdids.DataBind();

        this.ModalPopupExtender1.Show();
    }
      
    

   
    
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;

    }

   

  
    
}