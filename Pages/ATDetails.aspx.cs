
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Data.SqlClient;
public partial class Pages_ATDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string linkid="",examtype="" ,estatus="";
            try
            {
              linkid=Request.QueryString["id"].ToString();
              examtype=Request.QueryString["type"].ToString();
               estatus = Request.QueryString["status"].ToString();
               imgapp.Visible = false;
            }
            catch
            {
                Response.Redirect("ATSearch.aspx");

            }
            FillGridView(linkid, examtype);
        }


    }


    private void FillGridView(string linkid, string examtype)
    {
        try
        {
            if (Session["pop"] != "1")
            {

                Label1.Text = "";
            }


            string EmpId = "";
            EmpId = Session["EmpId"].ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            System.Data.DataTable dt = s.GetStudentDetailsAptitude(linkid,examtype);
            ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();


        }
        catch
        {
        }

    }

    protected void imgapp_Click()
    {
        try
        {
            StudentRegistrationDAL app = new StudentRegistrationDAL();
            string message = "";
            string createdip;

            createdip = app.GetMacAddress();

            foreach (GridViewRow ro in gvStudentList.Rows)
            {
                CheckBox chkactivate = (CheckBox)ro.FindControl("chkactiveaptitude");
                CheckBox chkdeactiveapp = (CheckBox)ro.FindControl("chkdeactiveapp");
                RadioButtonList rr = (RadioButtonList)ro.FindControl("rdocounsel");

                int Empid;
                try
                {
                    Empid = int.Parse(Session["EMPID"].ToString());
                }

                catch
                {
                    Empid = 0;
                }
                HiddenField hklinkid = (HiddenField)ro.FindControl("hklinkid");
                HiddenField hktc = (HiddenField)ro.FindControl("hktc");
               Label drptestcode = (Label)ro.FindControl("drptestcode");
                hktc.Value = drptestcode.Text;
                try
                {

                    if (rr.SelectedValue == "NO")
                    {
                        message = app.UpdateApptitudeCounsel(hktc.Value.ToString(), "NA", "2014-01-01", Session["empid"].ToString(), "D");
                    }

                }
                catch
                {

                }

                //if (chkactivate.Checked == true)
                //{
                //    message = app.ActivateAptitude(int.Parse(hklinkid.Value), 1, Empid, createdip);
                //}
                //if (chkdeactiveapp.Checked == true)
                //{
                //    message = app.ActivateAptitude(int.Parse(hklinkid.Value), 0, Empid, createdip);

                //}
                if (message == "1")
                {
                    Label1.Text = "Data Submitted Sucessfully.";
                    Label1.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    Label1.Text = "Please Try Again.";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }


            }
        }
        catch
        {

        }
    }

    protected void BTNSEARCH_CLICKED(object sender, EventArgs e)
    {
        Response.Redirect("ATSearch.aspx", false);

    }


    protected void lnkview_clicked(object sender, EventArgs e)
    {
           imgapp.Visible = false;
            Label1.Text = "";
            LinkButton list = (LinkButton)sender;
            GridViewRow rv = (GridViewRow)list.Parent.Parent;
            GridViewRow gvrow = (GridViewRow)list.NamingContainer;

            string s = (gvrow.FindControl("hdntc") as HiddenField).Value;
            Lbltestcode2.Text = s;

            int idx = rv.RowIndex;
            try
            {
                  StudentRegistrationDAL app = new StudentRegistrationDAL();
                    DataSet ds;
                    ds = app.GetCounsilValues(s);
                    txtremarks.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtSCFromDay.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtSCFromMonth.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtSCFromYear.Text = ds.Tables[0].Rows[0][3].ToString();
                    lblmess.Text = "";
                    this.ModalPopupExtender1.Show();
                      
               
            }
            catch
            {
            }
    

    }

    protected void rdocounsel_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            imgapp.Visible = false;
            Label1.Text = "";
            RadioButtonList list = (RadioButtonList)sender;
            GridViewRow rv = (GridViewRow)list.Parent.Parent;
            GridViewRow gvrow = (GridViewRow)list.NamingContainer;

            string s = (gvrow.FindControl("hdntc") as HiddenField).Value;


            int idx = rv.RowIndex;
                 if (list.SelectedValue == "YES")
            {
                hdntestcode.Value = s;
                Lbltestcode2.Text = hdntestcode.Value.ToString();
                if (s == "")
                    this.ModalPopupExtender1.Hide();
                else
                {
                    txtremarks.Text = "";
                    txtSCFromDay.Text = "";
                    txtSCFromMonth.Text = "";
                    txtSCFromYear.Text = "";

                    lblmess.Text = "";
                    if (Session["flag"] != "1")
                        this.ModalPopupExtender1.Show();
                    else
                    {

                        list.Items[1].Enabled = false;

                        list.Items[2].Enabled = false;
                        list.SelectedValue = "o";
                    }
                }
            }

            if (list.SelectedValue == "NO")
            {
                imgapp_Click();

            }

        }
        catch
        {

        }


    }
    protected void btncancel_click(object sender, EventArgs e)
    {
        // FillGridView(1, iPageRecords);
        this.ModalPopupExtender1.Hide();
    }
    protected void btnupdate_click(object sender, EventArgs e)
    {

        StudentRegistrationDAL app = new StudentRegistrationDAL();
        string message;
        int ff;
        ff = 0;
        lblmess.Text = "";
        try
        {
            if (int.Parse(txtSCFromDay.Text) > 31)
            {
                lblmess.Text = "Enter Valid Day";
                lblmess.ForeColor = System.Drawing.Color.Red;
                ff = 1; this.ModalPopupExtender1.Show();
            }
        }
        catch
        {
            lblmess.Text = "Enter Valid Day"; ff = 1;
            lblmess.ForeColor = System.Drawing.Color.Red;
            this.ModalPopupExtender1.Show();
        }


        try
        {
            if (int.Parse(txtSCFromMonth.Text) > 12)
            {
                lblmess.Text = "Enter Valid Month"; ff = 1;
                lblmess.ForeColor = System.Drawing.Color.Red; this.ModalPopupExtender1.Show();



            }
        }
        catch
        {
            lblmess.Text = "Enter Valid Month";
            lblmess.ForeColor = System.Drawing.Color.Red; ff = 1; this.ModalPopupExtender1.Show();

        }

        try
        {
            if (int.Parse(txtSCFromYear.Text) > int.Parse(DateTime.Now.Year.ToString()))
            {
                lblmess.Text = "Enter Valid Year";
                lblmess.ForeColor = System.Drawing.Color.Red; ff = 1; this.ModalPopupExtender1.Show();



            }
        }
        catch
        {
            lblmess.Text = "Enter Valid Year";
            lblmess.ForeColor = System.Drawing.Color.Red; ff = 1; this.ModalPopupExtender1.Show();

        }


        try
        {
            DateTime date1 = new DateTime(int.Parse(txtSCFromYear.Text), int.Parse(txtSCFromMonth.Text), int.Parse(txtSCFromDay.Text), 0, 0, 0);
            DateTime date2 = new DateTime(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Day.ToString()), 12, 0, 0);

            int result = DateTime.Compare(date1, date2);
            if (result > 0)
            {
                lblmess.Text = "Counseled date Should not be the Future Date";
                lblmess.ForeColor = System.Drawing.Color.Red; ff = 1; this.ModalPopupExtender1.Show();



            }
        }
        catch
        {
            lblmess.Text = "Counseled date Should not be the Future Date";
            lblmess.ForeColor = System.Drawing.Color.Red; ff = 1; this.ModalPopupExtender1.Show();

        }


        {
            try
            {
                if (ff != 1)
                {
                    string cdate = txtSCFromYear.Text + "/" + txtSCFromMonth.Text + "/" + txtSCFromDay.Text;
                    message = app.UpdateApptitudeCounsel(Lbltestcode2.Text, txtremarks.Text, cdate, Session["empid"].ToString(), "I");


                    if (message == "1")
                    {
                        Label1.Text = "Data Submitted Sucessfully.";
                        Label1.ForeColor = System.Drawing.Color.Blue;
                        Session["pop"] = "1";
                       this.ModalPopupExtender1.Hide();
                        Session["cflag"] = "1";
                         string linkid="",examtype="" ,estatus="";
            try
            {
              linkid=Request.QueryString["id"].ToString();
              examtype=Request.QueryString["type"].ToString();
               estatus = Request.QueryString["status"].ToString();
               imgapp.Visible = false;
            }
            catch
            {
              

            }
            FillGridView(linkid, examtype);
                
                  
                    }
                    else
                    {
                        lblmess.Text = "Please Try Again.";
                        lblmess.ForeColor = System.Drawing.Color.Red;
                        this.ModalPopupExtender1.Show();
                    }
                }
            }
            catch
            {
                lblmess.Text = "Session Expired. Login Again .";
                Label1.ForeColor = System.Drawing.Color.Red;
            }


        }

    }


    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
                        try
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkview");
                RadioButtonList rc = (RadioButtonList)e.Row.FindControl("rdocounsel");
                HiddenField hdn= (HiddenField)e.Row.FindControl("hdntc");
                if (hdn.Value == "")
                {
                    rc.Enabled = false;
                    lnk.Enabled = false;

                }
                   if (rc.SelectedItem.Value=="YES")
                   {
                        rc.Enabled = false;
                     
                   }

                   if (rc.SelectedItem.Value == "NO")
                   {
                       lnk.Enabled = false;

                   }
                                
                //if (Session["cflag"] == "1")
                //{
                //    rc.SelectedValue = "YES";
                    
                //}
                //else
                //{
                //    rc.SelectedValue = "NO";
                //}
            }
            catch
            {
            }

          
        }
    }


    protected void chkactiveaptitude_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

             imgapp.Visible = false;
             


            RadioButton rc2 = (RadioButton)sender;
            GridViewRow gvrow = (GridViewRow)rc2.NamingContainer;
            GridViewRow rv = (GridViewRow)rc2.Parent.Parent;
            if (rc2.Checked == true) 
                imgapp.Visible = true;
       }
        catch
        {
        }
    }

    protected void chkdeactiveap_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            imgapp.Visible = false;



            RadioButton rc2 = (RadioButton)sender;
            GridViewRow gvrow = (GridViewRow)rc2.NamingContainer;
            GridViewRow rv = (GridViewRow)rc2.Parent.Parent;
            if (rc2.Checked == true)
                imgapp.Visible = true;
        }
        catch
        {
        }
    }


    protected void gvStudentList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}