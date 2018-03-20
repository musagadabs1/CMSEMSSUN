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
using System.Text.RegularExpressions;

public partial class Pages_SeatAllocations : System.Web.UI.Page
{
    StudentRegistrationDAL s = new StudentRegistrationDAL();
    string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.MaintainScrollPositionOnPostBack = true;  

        chkIsActive.Enabled = false;
        if (!IsPostBack)
        {
            try
            {
                string hh = Session["EMPID"].ToString();
                if (Session["EMPID"].ToString() != "918")
                {
                    btn_save_approval.Visible = false;
                }
                else
                {
                    btn_save_approval.Visible = true;
                }

                if (Session["EMPID"].ToString() == "10079")
                {
                    btn_save_approval.Visible = true;
                }
                DataTable dt = s.getTotalFund(Convert.ToInt16(DDL_Subcat.SelectedItem.Value));
                if (dt.Rows.Count > 0)
                {
                    txt_totalFund.Text = dt.Rows[0]["totalfund"].ToString();
                }                
                try
                {
                    ddl_Fyr.DataSource = s.GetAcademicYear();
                    ddl_Fyr.DataTextField = "Accadyear_Desc";
                    ddl_Fyr.DataValueField = "acyear_id";
                    ddl_Fyr.DataBind();

                    ddl_Tyr.DataSource = s.GetAcademicYear();
                    ddl_Tyr.DataTextField = "Accadyear_Desc";
                    ddl_Tyr.DataValueField = "acyear_id";
                    ddl_Tyr.DataBind();
                }
                catch
                {
                }
                lblbal.Visible = false;
                btnupdate.Visible = false;
                Button1.Visible = true;
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
    protected void radbt1_click(object sender, EventArgs e)
    {
        if (rad_but1.Checked == true)
        {
            ddlcategory.Visible = true;
            DDL_Subcat.Visible = true;
            txt_newcat.Visible = false;
            txtsub.Visible = false;
            link_add.Visible = true;
            link_subcat.Visible = true;

            ddlcategory.DataSource = s.getcategory(rad_but1.Text);
            ddlcategory.DataTextField = "Category";
            ddlcategory.DataValueField = "id";
            ddlcategory.DataBind();

            int catid = Convert.ToInt16(ddlcategory.SelectedItem.Value);
            DDL_Subcat.DataSource = s.getscat(catid);
            DDL_Subcat.DataTextField = "Subcategory";
            DDL_Subcat.DataValueField = "id";
            DDL_Subcat.DataBind();

            ddl_Fyr.SelectedIndex = -1;
            ddl_Tyr.SelectedIndex = -1;
            ddl_degtype.SelectedIndex = -1;
            txt_totalFund.Text = "0";
            ddl_percentage.SelectedIndex = -1;
            txt_af.Text = "0";
            txt_std_allocated.Text = "1";
            lblbal.Visible = false;
            lbl_balance.Visible = false;
            txt_newtotalfnd.Visible = false;
            btn_tf_save.Visible = false;

            Bindgrid();
            chkisMou.Checked = true;
            chkisMou.Enabled = false;
            lbl_app.Visible = false;
            lblmsg.Visible = false;
        }
    }
    protected void btn_savenewtotalfund(object sender, EventArgs e)
    {
        int subcategoryId = Convert.ToInt16(DDL_Subcat.SelectedItem.Value);
        float totalfund   = Convert.ToSingle(txt_newtotalfnd.Text);
        float Result      = StudentRegistrationDAL.Updatenewtotalfund(subcategoryId, totalfund);
        int subcatid      = Convert.ToInt16(DDL_Subcat.SelectedItem.Value);
        string ayyear     = Convert.ToString(ddl_Fyr.SelectedItem.Text);
        int degreetypeid  = Convert.ToInt16(ddl_degtype.SelectedItem.Value);
        DataTable dt1     = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
        if (dt1.Rows.Count > 0)
        {
            btnupdate.Visible = false;
            lbl_balance.Visible = true;
            lbl_balance.Text = dt1.Rows[0]["Balance"].ToString();
        }
        if (lbl_balance.Text == "0")
        {
              btnupdate.Visible = false;
              txt_newtotalfnd.Visible = true;
              btn_tf_save.Visible = true;
        }
        DataTable dt = s.getupdatedtotalfund(subcategoryId);
        if (dt.Rows.Count > 0)
        {
            txt_totalFund.Text = dt.Rows[0]["totalfund"].ToString();
        }
        else
        {
            txt_totalFund.Text = "0";
        }
        txt_newtotalfnd.Visible = false;
        btn_tf_save.Visible = false;
        //string ss = lbl_balance.Text;
        //if (ss.Contains("-"))
        //{
        //    Response.Write("<script LANGUAGE='JavaScript'>alert('Dear User,You have entered less amount !!!!!!!!') </script>");
        //    //btnupdate.Visible = true;
        //    txt_newtotalfnd.Text = "";
        //    txt_newtotalfnd.Visible = true;
        //    btn_tf_save.Visible = true;
        //    return ;
        //}
        txt_newtotalfnd.Text = "";
        DataTable dtab = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
        if (dtab.Rows.Count > 0)
        {
            float TAF1 = Convert.ToSingle(dtab.Rows[0]["TotalApprovedfund"].ToString());
            if (Convert.ToSingle(txt_totalFund.Text) <= TAF1)
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('Dear User,You have entered less amount !!!!!!!!') </script>");
                txt_newtotalfnd.Visible = true;
                btn_tf_save.Visible = true;
                M1.Show();
            }
        }

    }
    protected void radbut2_click(object sender, EventArgs e)
    {
        if (rad_but2.Checked == true)
        {
            ddlcategory.DataSource = s.getcategory(rad_but2.Text);
            ddlcategory.DataTextField = "Category";
            ddlcategory.DataValueField = "id";
            ddlcategory.DataBind();
            int catid = Convert.ToInt16(ddlcategory.SelectedItem.Value);
            DDL_Subcat.DataSource = s.getscat(catid);
            DDL_Subcat.DataTextField = "Subcategory";
            DDL_Subcat.DataValueField = "id";
            DDL_Subcat.DataBind();
            ddlcategory.Visible = true;
            DDL_Subcat.Visible = true;
            txt_newcat.Visible = false;
            txtsub.Visible = false;
            link_add.Visible = true;
            link_subcat.Visible = true;
            ddl_Fyr.SelectedIndex = -1;
            ddl_Tyr.SelectedIndex = -1;
            ddl_degtype.SelectedIndex = -1;
            txt_totalFund.Text = "0";
            ddl_percentage.SelectedIndex = -1;
            txt_af.Text = "0";
            txt_std_allocated.Text = "1";
            lblbal.Visible = false;
            lbl_balance.Visible = false;
            txt_newtotalfnd.Visible = false;
            btn_tf_save.Visible = false;
            Bindgrid();
            chkisMou.Checked = false;
            chkisMou.Enabled = false;
            lbl_app.Visible  = false;
            lblmsg.Visible   = false;
        }
    }
    protected void ddlcategory_selectedindexchanged(object sender, EventArgs e)
    {
        try
        {
            {
                int catid = Convert.ToInt16(ddlcategory.SelectedItem.Value);
                DDL_Subcat.DataSource = s.getscat(catid);
                DDL_Subcat.DataTextField = "Subcategory";
                DDL_Subcat.DataValueField = "id";
                DDL_Subcat.DataBind();
                lblmsg.Visible = false;
                DataTable dt = s.getTotalFund(Convert.ToInt16(DDL_Subcat.SelectedItem.Value));
                if (dt.Rows.Count > 0)
                {
                    txt_totalFund.Text = dt.Rows[0]["totalfund"].ToString();
                }     
                ddl_Fyr.SelectedIndex = -1;
                ddl_Tyr.SelectedIndex = -1;
                ddl_degtype.SelectedIndex = -1;
                txt_totalFund.Text = "0";
                ddl_percentage.SelectedIndex = -1;
                txt_af.Text = "0";
                txt_std_allocated.Text = "1";
                lblbal.Visible = false;
                lbl_balance.Visible = false;
                txt_newtotalfnd.Visible = false;
                btn_tf_save.Visible = false;
                Bindgrid();
                chkisMou.Checked = true;
                chkisMou.Enabled = false;
                lbl_app.Visible = false;
                lblmsg.Visible = false;
            }
        }
        catch
        {
        }
    }
    protected void ddl_Subcategoryindexchanged(object sender, EventArgs e)
    {
        ddl_Fyr.SelectedIndex = -1;
        ddl_Tyr.SelectedIndex = -1;
        ddl_degtype.SelectedIndex = -1;
        txt_totalFund.Text = "0";
        ddl_percentage.SelectedIndex = -1;
        txt_af.Text = "0";
        txt_std_allocated.Text = "1";
        lblbal.Visible = false;
        lbl_balance.Visible = false;
        txt_newtotalfnd.Visible = false;
        btn_tf_save.Visible = false;
        Bindgrid();
        chkisMou.Checked = true;
        chkisMou.Enabled = false;
        lbl_app.Visible = false;
        lblmsg.Visible = false;
    }
    protected void ddldegree_selectedindex_changed(object sender, EventArgs e)
    {
        try
        {
            txt_std_allocated.Text = "1";
            DataTable dt = s.getTotalFund(Convert.ToInt16(DDL_Subcat.SelectedItem.Value));
            if (dt.Rows.Count > 0)
            {
                txt_totalFund.Text = dt.Rows[0]["totalfund"].ToString();
            }
            lbl_balance.Visible = true;
            lblbal.Visible = true;

            int subcatid = Convert.ToInt16(DDL_Subcat.SelectedItem.Value);
            string ayyear = Convert.ToString(ddl_Fyr.SelectedItem.Text);
            int degreetypeid = Convert.ToInt16(ddl_degtype.SelectedItem.Value);
            DataTable dt1 = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
            if (dt1.Rows.Count > 0)
            {
                // btnupdate.Visible = true;
                lbl_balance.Text = dt1.Rows[0]["Balance"].ToString();
            }
            else
            {
                lblbal.Visible = false;
                lbl_balance.Visible = false;
            }
            string ss = lbl_balance.Text;
            if (lbl_balance.Text == "0")
            {
                DataTable dtab = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
                if (dtab.Rows.Count > 0)
                {
                    user_ack.Text = "Dear User , Total approved fund is equals to AED: " + dtab.Rows[0]["TotalApprovedfund"].ToString() + ", So Please enter the amount greater than Total Approved Fund !!! ";
                }               
                txt_newtotalfnd.Visible = true;
                btn_tf_save.Visible = true;
                M1.Show();
            }            
            else  if (ss.Contains("-"))
           {
            //Response.Write("<script LANGUAGE='JavaScript'>alert('Dear User,You have entered less amount !!!!!!!!') </script>");
            //btnupdate.Visible = true;
                DataTable dtab = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
                if (dtab.Rows.Count > 0)
                {
                    user_ack.Text = "Dear User , Total approved fund is equals to AED: " + dtab.Rows[0]["TotalApprovedfund"].ToString() + ", So Please enter the amount greater than Total Approved Fund !!! ";
                }
            M1.Show();
            txt_newtotalfnd.Text = "";
            txt_newtotalfnd.Visible = true;
            btn_tf_save.Visible = true;            
          }
            int acyrid = Convert.ToInt16(ddl_Fyr.SelectedItem.Value);
            int degid = Convert.ToInt16(ddl_degtype.SelectedItem.Value);
            ddl_percentage.DataSource = s.getpercentage(acyrid, degid);
            ddl_percentage.DataTextField = "Percentage";
            ddl_percentage.DataValueField = "Percentage";
            ddl_percentage.DataBind();
            ddl_percentage.Items.Insert(0, "---Select---");
           // double Approvfund = double.Parse(txt_totalFund.Text) * (double.Parse(ddl_percentage.SelectedValue)) / 100;
            double Approvfund = 0;
            txt_af.Text = Convert.ToString(Approvfund);
           
        }
        catch
        {
        }
    }
    protected void ddlpercen_selectedindex_changed(object sender, EventArgs e)
    {       
        int degreetypeid = Convert.ToInt16(ddl_degtype.SelectedItem.Value);
        string percentage = Convert.ToString(ddl_percentage.SelectedItem.Value);
        DataTable dtperamount = s.GetPercentageamount(degreetypeid, percentage,ddl_Fyr.SelectedItem.Text);
        if (dtperamount.Rows.Count > 0)
        {
            percen_Amt.Text = dtperamount.Rows[0]["DHS"].ToString();
        }
     // double Approvfund = double.Parse(txt_totalFund.Text) * ((double.Parse(ddl_percentage.SelectedValue)) / 100 ) * Convert.ToInt16(txt_std_allocated.Text) ;
        double Approvfund = double.Parse(percen_Amt.Text) * Convert.ToInt16(txt_std_allocated.Text);
        txt_af.Text = Convert.ToString(Approvfund);
    }
    private void Bindgrid()
    {        
        gvTOC.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        txtSearch.Text = "";
        SearchString = "";
        gvTOC.DataBind();
    }
    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Replace("(", "|").Replace(")", "|").Trim(), RegexOptions.IgnoreCase);
        RegExp.Replace("/", "");
        // Highlight keywords by calling the 
        //delegate each time a keyword is found.
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
    }
    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }
    protected void button_search(object sender, EventArgs e)
    {
        lbl_app.Visible = false;
        lblmsg.Visible = false;
        rad_but1.Checked = false;
        rad_but2.Checked = false;
        txt_newcat.Visible = false;
        txtsub.Visible = false;
        ddlcategory.Visible = true;
        ddlcategory.SelectedIndex = -1;
        DDL_Subcat.Visible = true;
        DDL_Subcat.SelectedIndex = -1;
        txt_newcat.Text = "";
        txtsub.Text = "";
        ddl_Fyr.SelectedIndex = -1;
        ddl_Tyr.SelectedIndex = -1;
        ddl_degtype.SelectedIndex = -1;
        txt_totalFund.Text = "";
        ddl_percentage.SelectedIndex = -1;
        txt_af.Text = "";
        txt_std_allocated.Text = "1";
        chkisMou.Checked = false;
        chkisMou.Enabled = true;       
        //Set the value of the SearchString so it gets
        SearchString = txtSearch.Text;
    }
    int Result = 0;
    protected void Button1_Click(object sender, EventArgs e)
    {
        //int Result = d.InsertCategory(ddlcategory.SelectedValue, txtsub.Text, int.Parse(Session["EMPID"].ToString()), chkIsActive.Checked
        string category = "";
        string subcategory = "";
        if (txt_newcat.Text != "")
        {
            category = txt_newcat.Text;
        }
        else
        {
            category = ddlcategory.SelectedItem.Text;
        }

        if (txtsub.Text != "")
        {
            subcategory = txtsub.Text;
        }
        else
        {
            subcategory = DDL_Subcat.SelectedItem.Text;
        }
        bool activestate = true;
        bool isactive = true;
        if (chkIsActive.Checked == true)
        {
            activestate = true;
        }
        else
        {
            activestate = false;
        }
        bool ismouactive;
        if (rad_but1.Checked == true)
        {
            ismouactive = true; //chkisMou.Checked;
        }
        else
        {
            ismouactive = false; // chkisMou.Checked;
        }

        bool issharjah;

        if (chk_IsSharjah.Checked == true)
        {
            issharjah = true;
        }
        else
        {
            issharjah = false;
        }
        string fromyear = Convert.ToString(ddl_Fyr.SelectedItem.Text);
        string Toyear = Convert.ToString(ddl_Fyr.SelectedItem.Text); // Changed ddl_Tyr as ddl_fyr as per requirement by Ms.Meena
        double TotalFund = Convert.ToDouble(txt_totalFund.Text);
        Result = StudentRegistrationDAL.InsertCategory(category, subcategory, int.Parse(Session["EMPID"].ToString()), isactive, ismouactive, GetMacAddress(), issharjah);
        int degtype = Convert.ToInt16(ddl_degtype.SelectedValue);
        int termid = 0;
        int AcadYrId = Convert.ToInt16(ddl_Fyr.SelectedItem.Value);
        string Acyear = "0";
        float percentage = Convert.ToSingle(ddl_percentage.SelectedValue);
        int stdallocated = Convert.ToInt16(txt_std_allocated.Text);
        int subcategoryid = Result;
        double approvedfund = Convert.ToDouble(txt_af.Text.ToString());
        int empid = Convert.ToInt16(Session["EmpId"].ToString());
        string mac = GetMacAddress();
        //bool isactive = true;
        string rep_cat = category.Replace("'\'", "'-'");
        string rep_subcat = subcategory.Replace("'\'", "'-'");
        if (fileUpload1.HasFile)
        {
            //create the path to save the file to
            var dir = @"D:\MOUSETUP\FILES\" + rep_cat + "'\'" + rep_subcat;  // folder location 
            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);
            string fileName = Path.Combine(dir, fileUpload1.FileName);
            //save the file to our local path
            fileUpload1.SaveAs(fileName);
        }
        string filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
        DataTable dtmou = s.check_mou_exist(Convert.ToInt32(Result), degtype, percentage, AcadYrId);
        if (dtmou.Rows.Count > 0)
        {
            lblmsg.Visible = false;
            Response.Write("<script LANGUAGE='JavaScript'>alert('Dear User, Kindly be informed that you had already entered the given data!!!!!!!!')</script>");
            return ;
        }
        // else
        // {
        //int subcatid = Convert.ToInt16(DDL_Subcat.SelectedItem.Value);
        //string ayyear = Convert.ToString(ddl_Fyr.SelectedItem.Text);
        //int degreetypeid = Convert.ToInt16(ddl_degtype.SelectedItem.Value);
        //string ss = lbl_balance.Text;
        //if (lbl_balance.Text == "0")
        //{
        //    DataTable dtab = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
        //    if (dtab.Rows.Count > 0)
        //    {
        //        user_ack.Text = "Dear User , Total approved fund is equals to AED: " + dtab.Rows[0]["TotalApprovedfund"].ToString() + ", So Please enter the amount greater than Total Approved Fund !!! ";
        //    }
        //    txt_newtotalfnd.Visible = true;
        //    btn_tf_save.Visible = true;
        //    M1.Show();
        //}
        //else if (ss.Contains("-"))
        //{
        //    //Response.Write("<script LANGUAGE='JavaScript'>alert('Dear User,You have entered less amount !!!!!!!!') </script>");
        //    //btnupdate.Visible = true;
        //    DataTable dtab = s.GetMOUBalance(subcatid, ayyear, degreetypeid);
        //    if (dtab.Rows.Count > 0)
        //    {
        //        user_ack.Text = "Dear User , Total approved fund is equals to AED: " + dtab.Rows[0]["TotalApprovedfund"].ToString() + ", So Please enter the amount greater than Total Approved Fund !!! ";
        //    }
        //    M1.Show();
        //    txt_newtotalfnd.Text = "";
        //    txt_newtotalfnd.Visible = true;
        //    btn_tf_save.Visible = true;
        //    return;
        //}
        else
        {
            int res = Convert.ToInt32(Result);
            s.Insertdetailsmaster(Convert.ToInt32(Result), degtype, termid, AcadYrId, Acyear, percentage, stdallocated, Result, approvedfund, empid, mac, activestate, fromyear, Toyear, filename, TotalFund);
            lblmsg.Visible = true;
            lblmsg.Text = "Successfully Inserted!!!";
            lblmsg.Style.Add("color", "Green");
            lblmsg.Style.Add("Font-size", "10px");
            lblmsg.Style.Add("font-weight", "bold");
            Bindgrid();
            btnupdate.Visible = false;
            DataTable dt = s.getToemailId();
            string toemail = "";
            if (dt.Rows.Count > 0)
            {
                toemail = dt.Rows[0]["OfficeMail"].ToString();
            }
            string Mesag = "";
            string newcat = "";
            string Subcat = "";
            if (txt_newcat.Text != "")
            {
                newcat = txt_newcat.Text;
            }
            else
            {
                newcat = ddlcategory.SelectedItem.Text;
            }

            if (txtsub.Text != "")
            {
                Subcat = txtsub.Text;
            }
            else
            {
                Subcat = DDL_Subcat.SelectedItem.Text;
            }
            string Fn = "";
            if (fileUpload1.FileName.ToString() == "")
            {
                Fn = "No Files";
            }
            else
            {
                Fn = fileUpload1.FileName.ToString();
            }
            string radchk = "";
            if (rad_but1.Checked == true)
            {
                radchk = rad_but1.Text;
            }
            else
            {
                radchk = rad_but2.Text;
            }

            Mesag = "Dear Sir, " + "<br/>";
            Mesag = Mesag + "Please find the Scholarship/Feewaiver details for your Approval." + "<br/>";
            Mesag = Mesag + "<table align='center' border='1'>";
            Mesag = Mesag + "<tr><td>Category:</td><td>" + radchk + "-" + newcat + "</td></tr>"; //+ ddlTitle.SelectedItem.Text + " " + Name;
            Mesag = Mesag + "<tr><td>Sub Category:</td><td>" + Subcat + "</td></tr>";
            Mesag = Mesag + "<tr><td>Academic Year:</td><td>" + ddl_Fyr.SelectedItem.Text + "</td></tr>";
           // Mesag = Mesag + "<tr><td>To Year:</td><td>" + ddl_Tyr.SelectedItem.Text + "</td></tr>";
            Mesag = Mesag + "<tr><td>Degree Type:</td><td>" + ddl_degtype.SelectedItem.Text + "</td></tr>";
            Mesag = Mesag + "<tr><td>Total Fund :</td><td>" + txt_totalFund.Text + "</td></tr>";
            Mesag = Mesag + "<tr><td>Percentage:</td><td>" + ddl_percentage.SelectedItem.Text + "</td></tr>";
            Mesag = Mesag + "<tr><td>Alloted Fund:</td><td>" + txt_af.Text + "</td></tr>";
            Mesag = Mesag + "<tr><td>No Of Students Allocated:</td><td>" + txt_std_allocated.Text + "</td></tr>";
            Mesag = Mesag + "<tr><td>Uploded-File:</td><td>" + Fn + "</td></tr></table>";
            Mesag = Mesag + "<table><tr><td>" + "Best Regards,";
            Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
            Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College" + "</td></tr></table>";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
            //Mesag = Mesag + "</td></tr><tr><td>" +  txtAttendedBy.Text;
            //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
            //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
            //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
            //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
            //Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";
            //mail-->  SendEmails.SendEmail2("Software@skylineuniversity.ac.ae", toemail, "Scholarship/Feewaiver Approval", Mesag, "Software@skylineuniversity.ac.ae");
            //SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
            // }
        }
    }
    protected void GvTOC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRow")
        {
            chk_renewal.Checked = false;
            pnl_Renewal.Visible = true;
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            HiddenField1.Value = Convert.ToString(arg[0]);
            HiddenField3.Value = Convert.ToString(arg[1]);
            DataTable dt = s.getcategorygrid(Convert.ToInt32(HiddenField1.Value), Convert.ToBoolean(HiddenField3.Value));            
            string checkitm = "";
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ISMOU"].ToString() == "True")
                {
                    rad_but1.Checked = true;
                    checkitm = rad_but1.Text;
                    string gg = dt.Rows[0]["ISMOU"].ToString();
                }
                else
                {
                    rad_but2.Checked = true;
                    checkitm = rad_but2.Text;
                    string gg = dt.Rows[0]["ISMOU"].ToString();
                }
                ddlcategory.Items.Clear();
                ddlcategory.DataSource = s.getcategory(checkitm);
                ddlcategory.DataTextField = "Category";
                ddlcategory.DataValueField = "id";
                ddlcategory.DataBind();
                ddlcategory.SelectedValue = dt.Rows[0]["Id"].ToString();
                int catid = Convert.ToInt16(ddlcategory.SelectedItem.Value);
                DDL_Subcat.DataSource = s.getscat(catid);
                DDL_Subcat.DataTextField = "Subcategory";
                DDL_Subcat.DataValueField = "id";
                DDL_Subcat.DataBind();
                DDL_Subcat.SelectedValue = dt.Rows[0]["SubcatId"].ToString();
                // txtsub.Text = dt.Rows[0]["SubCategory"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["Isactive"]) == true)
                {
                    chkIsActive.Checked = true;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
                //ddl_Acadyr.SelectedValue = dt.Rows[0]["acadYearId"].ToString();                
                ddl_Fyr.SelectedItem.Text  = dt.Rows[0]["FromYear"].ToString(); //getting f_year Id as acadyearid for percentage selection
                ddl_Fyr.SelectedItem.Value = dt.Rows[0]["acadYearId"].ToString();
                ddl_Tyr.SelectedItem.Text  = dt.Rows[0]["ToYear"].ToString();
                ddl_degtype.SelectedValue  = dt.Rows[0]["DegreeId"].ToString();
                int acyrid = Convert.ToInt16(dt.Rows[0]["acadYearId"].ToString());
                int degid  = Convert.ToInt16(ddl_degtype.SelectedItem.Value);
                txt_totalFund.Text = dt.Rows[0]["TotalFund"].ToString();
                //ddl_percentage.DataSource = s.getpercentage1();
                //ddl_percentage.DataTextField = "Percentage";
                //ddl_percentage.DataValueField = "Percentage";
                //ddl_percentage.DataBind();
                ddl_percentage.DataSource = s.getpercentage(acyrid, degid);
                ddl_percentage.DataTextField = "Percentage";
                ddl_percentage.DataValueField = "Percentage";
                ddl_percentage.DataBind();
                ddl_percentage.SelectedValue = dt.Rows[0]["Percentage"].ToString();
                percen_Amt.Text = dt.Rows[0]["PercenAmt"].ToString();
                txt_af.Text = dt.Rows[0]["ApproveFund"].ToString();
                txt_std_allocated.Text = dt.Rows[0]["StdAlloted"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["IsMOU"]) == true)
                {
                    chkisMou.Checked = true;
                }
                else
                {
                    chkisMou.Checked = false;
                }

                if(Convert.ToBoolean(dt.Rows[0]["IsSharjahGov"].ToString()) == true)
                {
                    chk_IsSharjah.Checked = true;
                }
                else
                {
                    chk_IsSharjah.Checked = false;
                }

            }
            lblmsg.Visible = false;
            Button1.Visible = false;
            btnupdate.Visible = true;
        }
        if (e.CommandName == "DeleteRow")
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            HiddenField1.Value = Convert.ToString(e.CommandArgument);
            d.Deletecategory(Convert.ToInt32(HiddenField1.Value));
            lblmsg.Text = "Successfully Changed the state as Inactive";
        }
        Bindgrid();
    }
    protected void chk_renewal_Checked_Changed(object sender, EventArgs e)
    {
         DataTable dt = s.getincrFromyear(Convert.ToInt32(HiddenField1.Value));
         if (chk_renewal.Checked)
         {
             if (dt.Rows.Count > 0)
             {
                 ddl_Fyr.SelectedItem.Value = dt.Rows[0]["IncrYearID"].ToString();
                 ddl_Fyr.SelectedItem.Text = dt.Rows[0]["IncrYear"].ToString();
             }
         }
         else
         {
             ddl_Fyr.SelectedItem.Value = dt.Rows[0]["AcadYearId"].ToString();
             ddl_Fyr.SelectedItem.Text = dt.Rows[0]["FromYear"].ToString();
         }
         //else
         //{
         //    ddl_Fyr.SelectedItem.Value = dt.Rows[0]["AcadYearId"].ToString();
         //    ddl_Fyr.SelectedItem.Text = dt.Rows[0]["FromYear"].ToString();
         //}
      //  int incr = Convert.ToInt16(ddl_Fyr.SelectedItem.Value);
      //  int a = 1;
      //  ddl_Fyr.SelectedItem.Value = Convert.ToString(Convert.ToInt16(incr) + a);
    } 
    protected void gvgvTOC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnked     = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkdel    = (LinkButton)e.Row.FindControl("lnkdelete");
            CheckBox   chkapp    = (CheckBox)e.Row.FindControl("chk_approval");
            DataRow    row       = ((DataRowView)e.Row.DataItem).Row;
            Label lblapprovetext = (Label)e.Row.FindControl("lbl_app");
            String gg            = Session["EMPID"].ToString();
            if (Session["EMPID"].ToString() != "918" )
            {
                chkapp.Enabled = false;
                chkapp.Visible = false;
            }
            //if (Session["EMPID"].ToString() == "10079")
            //{
            //    chkapp.Enabled = true;
            //    chkapp.Visible = true;
            //}
            if (lblapprovetext.Text == "Approved")
            {
                e.Row.BackColor = System.Drawing.Color.LightGreen;
                lnked.Enabled  = false;
                lnked.Visible  = false;
                lnkdel.Enabled = false;
                lnkdel.Visible = false;
                chkapp.Enabled = false;
                chkapp.Visible = false;
            }
        }
    }
    protected void gvTOC_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL d = new StudentRegistrationDAL();
        int hidfield = Convert.ToInt16(HiddenField1.Value);
        int catid = Convert.ToInt16(DDL_Subcat.SelectedValue);
        string cattext = Convert.ToString(ddlcategory.SelectedItem.Text);
        string subcattext  = Convert.ToString(DDL_Subcat.SelectedItem.Text);
        int acadyear       = Convert.ToInt16(ddl_Fyr.SelectedItem.Value);
        string AcFyear     = Convert.ToString(ddl_Fyr.SelectedItem.Text);
        string AcTyear     = Convert.ToString(ddl_Fyr.SelectedItem.Text); // no need to save to year as per requirement given by Ms.Meena
        int degtype        = Convert.ToInt16(ddl_degtype.SelectedValue);
        float percentage   = Convert.ToSingle(ddl_percentage.SelectedValue);
        float totalfund    = Convert.ToSingle(txt_totalFund.Text);
        //float Approvfund = Convert.ToInt16(txt_totalFund.Text) * Convert.ToSingle(ddl_percentage.SelectedValue) / 100;
        //float appfund    = Convert.ToSingle(txt_totalFund.Text) * (Convert.ToSingle(ddl_percentage.SelectedValue) / 100) * (Convert.ToInt16(txt_std_allocated.Text));
        //float appfund    = Convert.ToSingle(percen_Amt.Text) * Convert.ToInt16(txt_std_allocated.Text);
        float appfund      = Convert.ToSingle(txt_af.Text.ToString());
        int  stdalloted    = Convert.ToInt16(txt_std_allocated.Text);
        string empid       = Convert.ToString(Session["EMPID"].ToString());
        //bool isactive = chkIsActive.Checked;  -- updated by Pratheeba for making isactive always true for main category 
        bool isactive = true;
        bool ismouactive = chkisMou.Checked;
        bool isdetactive = false;
        int Renewal = 0;
        string radchk = "";
        string modification = "";
        if (chk_renewal.Checked)
        {
            Renewal = 1;
            modification = "renewed";
        }
        else
        {
            Renewal = 0;
            modification = "updated";
        }

        bool issharjah;
        if (chk_IsSharjah.Checked == true)
        {
            issharjah = true;
        }
        else
        {
            issharjah = false;
        }
        string Result = d.UpdateCategory(hidfield, catid, cattext, subcattext, acadyear, AcFyear, AcTyear, degtype, percentage, totalfund, appfund, stdalloted, empid, isactive, ismouactive, isdetactive, DateTime.Now, Renewal, issharjah);
        lblmsg.Visible = true;
        lblmsg.Text = "Successfully Updated!!!";
        lblmsg.Style.Add("color", "Green");
        lblmsg.Style.Add("Font-size", "10px");
        lblmsg.Style.Add("font-weight", "bold");
        DataTable dt = s.getToemailId();
        string toemail = "";
        if (dt.Rows.Count > 0)
        {
            toemail = dt.Rows[0]["OfficeMail"].ToString();
        }
        string Mesag = "";
        string newcat = "";
        string Subcat = "";
        if (rad_but1.Checked == true)
        {
            radchk = rad_but1.Text;
        }
        else
        {
            radchk = rad_but2.Text;
        }
        string newcat1 = "";
        string Subcat1 = "";
        if (txt_newcat.Text != "")
        {
            newcat1 = txt_newcat.Text;
        }
        else
        {
            newcat1 = ddlcategory.SelectedItem.Text;
        }

        if (txtsub.Text != "")
        {
            Subcat1 = txtsub.Text;
        }
        else
        {
            Subcat1 = DDL_Subcat.SelectedItem.Text;
        }
        string Fn = "";
        if (fileUpload1.FileName.ToString() == "")
        {
            Fn = "No Files";
        }
        else
        {
            Fn = fileUpload1.FileName.ToString();
        }

        Mesag = "Dear Sir, " + "<br/>";
        Mesag = Mesag + "Please find the "+modification+" Scholarship/Feewaiver details for your Approval." + "<br/>";
        Mesag = Mesag + "<table align='center' border='1'>";
        Mesag = Mesag + "<tr><td>Category:</td><td>" + radchk + "-" + newcat1 + "</td></tr>"; //+ ddlTitle.SelectedItem.Text + " " + Name;
        Mesag = Mesag + "<tr><td>Sub Category:</td><td>" + Subcat1 + "</td></tr>";
        Mesag = Mesag + "<tr><td>Academic Year:</td><td>" + ddl_Fyr.SelectedItem.Text + "</td></tr>";
        // Mesag = Mesag + "<tr><td>To Year:</td><td>" + ddl_Tyr.SelectedItem.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Degree Type:</td><td>" + ddl_degtype.SelectedItem.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Total Fund :</td><td>" + txt_totalFund.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Percentage:</td><td>" + ddl_percentage.SelectedItem.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Alloted Fund:</td><td>" + txt_af.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>No Of Students Allocated:</td><td>" + txt_std_allocated.Text + "</td></tr>";
        Mesag = Mesag + "<tr><td>Uploded-File:</td><td>" + Fn + "</td></tr></table>";
        Mesag = Mesag + "<table><tr><td>" + "Best Regards,";
        Mesag = Mesag + "</td></tr><tr><td>" + "Marketing & Admissions Dept";
        Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College" + "</td></tr></table>";
        //Mesag = Mesag + "</td></tr><tr><td>" + "Best regards,";
        //Mesag = Mesag + "</td></tr><tr><td>" +  txtAttendedBy.Text;
        //Mesag = Mesag + "</td></tr><tr><td>" + "Skyline University College";
        //Mesag = Mesag + "</td></tr><tr><td>" + "University City of Sharjah, Sharjah";
        //Mesag = Mesag + "</td></tr><tr><td>" + "P.O. Box: 1797, Sharjah, U.A.E";
        //Mesag = Mesag + "</td></tr><tr><td>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166";
        //Mesag = Mesag + "</td></tr><tr><td>" + "Email: admissions@skylineuniversity.ac.ae"; 
        //Mesag = Mesag + "</td></tr></tr></tbody></table></p><p></p>";
    //--->    SendEmails.SendEmail2("Software@skylineuniversity.ac.ae", "software@skylineuniversity.ac.ae", "Scholarship/Feewaiver Approval", Mesag, "Software@skylineuniversity.ac.ae");
        //SendEmails.SendEmail2("nitin@skylineuniversity.ac.ae", ToEmail, "Registration Follow Up", Mesag, "");
        // }
        //ddlcategory.SelectedIndex = -1;
        //DDL_Subcat.SelectedIndex = -1;
        //ddl_Fyr.SelectedIndex = -1;
        //ddl_Tyr.SelectedIndex = -1;
        //ddl_degtype.SelectedIndex = -1;
        //txt_totalFund.Text = "";
        //ddl_percentage.SelectedIndex = -1;
        //txt_af.Text = "0";
        //txt_std_allocated.Text = "0";
        //chkisMou.Checked = false; 
        Bindgrid();
        btnupdate.Visible = false;
        Button1.Visible = true;
    }
    protected void btn_save_approval_Click(object sender, EventArgs e)
    {
        int EmpId = int.Parse(Session["EMPID"].ToString());
        string mac = GetMacAddress();
        foreach (GridViewRow row in gvTOC.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hidsnovalue = (HiddenField)row.FindControl("hid_sno");
                int sno = Convert.ToInt32(hidsnovalue.Value);
                if (((CheckBox)row.FindControl("chk_approval")).Checked)
                {
                    s.InsertMouApproval(sno, EmpId, mac);
                }
            }
        }
        lbl_app.Visible = true;
        lblmsg.Visible = false;
        lbl_app.Text = "Approved Successfully";
        Bindgrid();
    }
    protected void btn_click_show(object sender, EventArgs e)
    {
        txt_newcat.Visible = true;
        ddlcategory.Visible = false;
        link_add.Visible = false;
        lblbal.Visible = false;
        lbl_balance.Visible = false;
        txt_totalFund.Text = "0";
        // to show the subcate text box 
        txtsub.Visible = true;
        DDL_Subcat.Visible = false;
        link_subcat.Visible = false;
    }
    protected void btn_click_show_subcat(object sender, EventArgs e)
    {
        txtsub.Visible = true;
        DDL_Subcat.Visible = false;
        link_subcat.Visible = false;
        lblbal.Visible = false;
        lbl_balance.Visible = false;
        txt_totalFund.Text = "0";
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
    protected void gvTOC_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvTOC.PageIndex = e.NewPageIndex;
        this.Bindgrid();
    }
    protected void gvTOC_OnSorting(object sender, EventArgs e)
    {
        divGridView.Page.SetFocus(gvTOC);
    }

}