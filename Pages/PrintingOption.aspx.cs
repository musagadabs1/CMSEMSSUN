using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using com.vectramind.mobile;
using System.Text;

public partial class Pages_PrintingOption : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                rdbName.Focus();
                if (!IsPostBack)
                {
                    rdbName.Checked = true;
                    gvStudentList.DataSource = "";
                    gvStudentList.DataBind();
                    LoadDropdown();

                    StudentRegistrationDAL s = new StudentRegistrationDAL();
                    Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                    Drpschool.DataTextField = "schoolname";
                    Drpschool.DataValueField = "schoolcode";
                    Drpschool.DataBind();
                    Drpschool.SelectedValue = Session["schoolcode"].ToString();

                    Drpschool_SelectedIndexChanged(sender, e);





                }
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");

        }
    }
    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvReportList.DataSource = null;
        gvReportList.DataBind();


    }
    private void FillGridView1(int LinkId)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            gvReportList.DataSource = s.GetReportList(LinkId);
            gvReportList.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
    protected void gvReportList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "Print")
            {
                try
                {
                    string UName = e.CommandArgument.ToString();
                    string path = "";
                    string LinkId = Session["LinkId"].ToString();
                    Response.Redirect("PrintClient.aspx?UName=" + UName);

                    if (UName.Contains(".pdf"))
                    {
                        //Response.Redirect("PrintableDocument/" + UName, false);
                    }
                    else
                    {
                        StudentRegistrationDAL s = new StudentRegistrationDAL();
                        string RegNo = s.GetRegNo(LinkId);

                        path = "~/Report/" + UName + ".rpt";
                        path = Server.MapPath(path);
                        rptStudent.Load(path);
                        if (UName == "ENROLLMENTFORM")
                            rptStudent.SetParameterValue("@LinkId", LinkId);
                        else
                            rptStudent.SetParameterValue("@registerid", LinkId);
                        rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
                        CrystalReportViewer1.ReportSource = rptStudent;
                        CrystalReportViewer1.DataBind();
                        CrystalReportViewer1.HasExportButton = true;
                        CrystalReportViewer1.HasPrintButton = true;
                        CrystalReportViewer1.HasSearchButton = true;
                        CrystalReportViewer1.HasToggleGroupTreeButton = false;
                        rptStudent.PrintToPrinter(1, true, 1, 100);
                    }
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvReportList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblUName = (Label)e.Row.FindControl("lblUName");
            if (lblUName.Text == "ENROLLMENTFORM")
            {
                lblUName.ForeColor = System.Drawing.Color.Red;
            }
            PnlFileNo.Visible = true;
        }
    }

    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //ddlCallerCategory.DataSource = s.SetDropdownListCDB(8);
        //ddlCallerCategory.DataTextField = "CCName";
        //ddlCallerCategory.DataValueField = "CCId";
        //ddlCallerCategory.DataBind();
    }
    private void FillGridView()
    {
        lblMesag.Text = "";
        try
        {
            string FilterBy = "All";
            if (rdbNumber.Checked == true)
                FilterBy = "Number";
            if (rdbEmail.Checked == true)
                FilterBy = "Email";
            if (rdbName.Checked == true)
                FilterBy = "Name";
            string EmpId = "";
            EmpId = Session["EmpId"].ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            System.Data.DataTable dt = s.GetStudentDetails1(FilterBy, txtFilterValue.Text, EmpId,Drpschool.SelectedValue);
            ViewState["_ds_grid"] = dt;
            gvStudentList.DataSource = dt;
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            lblMesag.Text = "Please Fill Correct Information!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                Session["LinkId"] = Id;
                pnlPrintGrid.Visible = true;
                pnlStudentList.Visible = false;
                this.FillGridView1(int.Parse(Id));
                DataSet ds = new DataSet();
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ds = s.GetEmailDetails(Session["EMPID"].ToString(), Session["LinkId"].ToString());
                foreach (DataRow ro in ds.Tables[4].Rows)
                {
                    if (int.Parse(ro[0].ToString()) == 0)
                    {
                        btnFinalize.Visible = true;
                        pnlPrintGrid.Visible = false;
                    }
                    else
                    {
                        btnFinalize.Visible = false;
                        pnlPrintGrid.Visible = true;
                    }
                }
                txtFileNumber.ReadOnly = true;
                txtFileNumber.Text = s.GetFileNo(Session["LinkId"].ToString());
                if (txtFileNumber.Text == "")
                {
                    txtFileNumber.Text = s.GetFileNoMax();
                    btnAddFileNumber.Enabled = true;
                }
                else
                {
                    btnAddFileNumber.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvStudentList_Sorted(object sender, EventArgs e)
    {
        try
        {
            string _expression = ViewState["_expression"].ToString();
            string _direction = ViewState["_direction"].ToString();

            System.Data.DataTable _ds = (System.Data.DataTable)ViewState["_ds_grid"];

            _ds.DefaultView.Sort = _expression + " " + _direction;

            gvStudentList.DataSource = _ds.DefaultView;
            gvStudentList.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvStudentList_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string _expression = e.SortExpression;
            string _direction = e.SortDirection.ToString();

            if (ViewState["_expression"] == null) { ViewState["_expression"] = ""; }
            if (ViewState["_direction"] == null) { ViewState["_direction"] = ""; }

            string _old_expression = ViewState["_expression"].ToString();
            string _old_direction = ViewState["_direction"].ToString();

            if (_expression == _old_expression)
            {
                if (_old_direction == "Asc")
                {
                    ViewState["_direction"] = "Desc";
                }
                else
                {
                    ViewState["_direction"] = "Asc";
                }
            }
            else
            {
                ViewState["_direction"] = "Asc";
                ViewState["_expression"] = _expression;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        btnFinalize.Visible = false;
        this.FillGridView();
        pnlPrintGrid.Visible = false;
        pnlStudentList.Visible = true;
    }
    protected void btnFinalize_Click(object sender, EventArgs e)
    {
        // for email
        try
        {
            DataSet ds = new DataSet();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            lblMesag.Text = "";
            string Hostel = "";
            string Visa = "";
            string Toc = "";
            string Transportaion = "";
            StudentRegistrationDAL d = new StudentRegistrationDAL();

            s.InsertFinalize(Session["LinkId"].ToString(), Session["EMPID"].ToString(),"");
            ds = s.GetEmailDetails(Session["EMPID"].ToString(), Session["LinkId"].ToString());

            foreach (DataRow ro in ds.Tables[6].Rows)
            {
                string SRoll = ro["RegistrationNo"].ToString().ToUpper();
                if (SRoll == "")
                {
                    lblMesag.Text = "Please Click on Update in Registration!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    pnlPrintGrid.Visible = false;
                    return;
                }
            }

            try
            {
                if (ds.Tables[17].Rows[0][0].ToString() == "0")
                {
                    lblMesag.Text = "Please Fill Contact Details!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    return;
                }
                if (ds.Tables[18].Rows[0][0].ToString() == "0")
                {
                    lblMesag.Text = "Please Fill Parent Details!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    return;
                }
                if (ds.Tables[19].Rows[0][0].ToString() == "0")
                {
                    lblMesag.Text = "Please Select Media Source!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    return;
                }
            }
            catch
            {

            }
            // For Program
            if (d.GetIsProgramSelected(Session["LinkId"].ToString()) == 0)
            {
                lblMesag.Text = "Please select Program before Finilize!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                pnlPrintGrid.Visible = false;
                return;
            }
            try
            {
                // For TOEFL
                if (ds.Tables[16].Rows[0][0].ToString() == "0")
                {
                    lblMesag.Text = "Please select Entrance before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    return;
                }
            }
            catch
            {
            }
            // For Feewaiver
            if (d.GetIsFeeWaiverSelected(Session["LinkId"].ToString()) == 0)
            {
                lblMesag.Text = "Please select Feewaiver before Finilize!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                return;
            }
            // For Qualification
            if (d.GetIsQualificationSelected(Session["LinkId"].ToString()) == 0)
            {
                foreach (DataRow ro in ds.Tables[6].Rows)
                {
                    if (ro["Degree"].ToString().ToUpper() != "SHORT COURSE")
                    {
                        lblMesag.Text = "Please select Qualification before Finilize!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        pnlPrintGrid.Visible = false;
                        return;
                    }
                }
            }
            // For Passport
            if (d.GetIsPassport(Session["LinkId"].ToString()) == 0)
            {
                foreach (DataRow ro in ds.Tables[6].Rows)
                {
                    if (ro["Degree"].ToString().ToUpper() == "")
                    {
                        lblMesag.Text = "Please select program before Finilize!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        pnlPrintGrid.Visible = false;
                        return;
                    }
                    if (ro["Degree"].ToString().ToUpper() == "0")
                    {
                        lblMesag.Text = "Please select program before Finilize!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        pnlPrintGrid.Visible = false;
                        return;
                    }
                    if (ro["Degree"].ToString().ToUpper() != "SHORT COURSE")
                    {
                        lblMesag.Text = "Please fill passport details in visa info before Finilize!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        pnlPrintGrid.Visible = false;
                        return;
                    }
                }
                lblMesag.Text = "Please fill passport details in visa info before Finilize!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                pnlPrintGrid.Visible = false;
                return;
            }
            // For Work Experience
            DataTable dt = d.GetCheckFinalize(1, Session["LinkId"].ToString());
            foreach (DataRow ro in dt.Rows)
            {
                if (ro["JobSector"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Job Sector in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    pnlPrintGrid.Visible = false;
                    return;
                }
                if (ro["JobType"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Job Type in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    pnlPrintGrid.Visible = false;
                    return;
                }
                if (ro["FromMonth"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Experience Date in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    pnlPrintGrid.Visible = false;
                    return;
                }
                if (ro["FromDate"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Experience Date in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    pnlPrintGrid.Visible = false;
                    return;
                }
            }
            string RegNo = d.GetRegNo(Session["LinkId"].ToString());
            string FromEmail = ""; // tblEmpMaster from Session EmapId >> Emp Email Address
            string ToEmail = "software@skylineuniversity.ac.ae";
            string Subject = "Registration Details";
            string Body = "Message not sent of Registration No ; " + RegNo;
            string CC = "";
            string Message = "";

            //if hostel required is true >> ToEMail >> sports@skylineuniversity.ac.ae
            //if skyline Visa required is true >> ToEMail >> pro@skylineuniversity.ac.ae and cc to hrd@skylineuniversity.ac.ae
            //if TOC required is true >> ToEMail >> iroffice@skylineuniversity.ac.ae
            //if Any Undertaking required is true >> ToEMail >> administration@skylineuniversity.ac.ae
            //Final Email >> nitin@skylineuniversity.ac.ae
            Message = "Todays New Registration Details of " + RegNo + " " + Environment.NewLine;
            foreach (DataRow ro in ds.Tables[0].Rows)
            {
                FromEmail = ro[0].ToString();
            }
            try
            {
                foreach (DataRow ro in ds.Tables[6].Rows)
                {
                    string SRoll = ro["RegistrationNo"].ToString().ToUpper();
                    string SName = ro["Name"].ToString().ToUpper();
                    d.InsertInFocus(SRoll, SName);
                    d.InsertInSkyErp(SRoll, SRoll);
                }
            }
            catch
            {
                SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                d.DeleteFinalize(Session["LinkId"].ToString());
                return;
            }
            foreach (DataRow ro1 in ds.Tables[1].Rows)
            {
                if (bool.Parse(ro1[0].ToString()) == true)
                {

                    foreach (DataRow ro in ds.Tables[6].Rows)
                    {
                        if (Visa == "")
                            Visa = "No";
                        string Feewaiver = ro["FeeWaiverType"].ToString();
                        if (Feewaiver == "")
                            Feewaiver = "No Feewaiver";

                        Subject = "STUDENT APPLIED FOR HOSTEL";
                        Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                        Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR HOSTEL</font></h3>";
                        Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                        //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>HOSTEL</td><td>" + "YES";
                        Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                    }

                    Body = Message;
                    //ToEmail = "software@skylineuniversity.ac.ae";
                    ToEmail = "sports@skylineuniversity.ac.ae";
                    SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                    Message = Message + "Hostel : Yes" + Environment.NewLine;
                }
            }
            foreach (DataRow ro1 in ds.Tables[2].Rows)
            {
                if (bool.Parse(ro1[0].ToString()) == true)
                {
                    foreach (DataRow ro in ds.Tables[6].Rows)
                    {
                        if (Hostel == "")
                            Hostel = "No";
                        string Feewaiver = ro["FeeWaiverType"].ToString();
                        if (Feewaiver == "")
                            Feewaiver = "No Feewaiver";

                        Subject = "STUDENT APPLIED FOR VISA";
                        Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                        Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR VISA</font></h3>";
                        Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                        //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>VISA</td><td>" + "YES";
                        Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                    }

                    Body = Message;
                    //ToEmail = "software@skylineuniversity.ac.ae";//"pro@skylineuniversity.ac.ae";
                    ToEmail = "pro@skylineuniversity.ac.ae";
                    CC = "hrd@skylineuniversity.ac.ae";
                    SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                    Message = Message + "Visa : Yes" + Environment.NewLine;
                }
            }
            // For Administration 

            try
            {
                foreach (DataRow ro1 in ds.Tables[3].Rows)
                {
                    if (ro1[0].ToString() == "Yes")
                    {
                        foreach (DataRow ro in ds.Tables[6].Rows)
                        {
                            if (ds.Tables[23].Rows.Count != 0)
                            {
                                if (Hostel == "")
                                    Hostel = "No";
                                if (Toc == "")
                                    Toc = "No";
                                string Feewaiver = ro["FeeWaiverType"].ToString();
                                if (Feewaiver == "")
                                    Feewaiver = "No Feewaiver";

                                Subject = "STUDENT APPLIED FOR VISA LETTER/EMBASSY LETTER";
                                Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                                Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR VISA LETTER/EMBASSY LETTER</font></h3>";
                                Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();

                                Message = Message + "</td></tr><tr><td>VISA LETTER/ EMBASSY LETTER</td><td>" + ds.Tables[23].Rows[0][0].ToString().ToUpper();
                                Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                            }

                            Body = Message;
                            ToEmail = "administration@skylineuniversity.ac.ae"; //"iroffice@skylineuniversity.ac.ae";
                            //CC = "software@skylineuniversity.ac.ae";
                            SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                        }
                    }
                }
            }
            catch
            {
            }
            // Ends Here
            foreach (DataRow ro1 in ds.Tables[7].Rows)
            {
                if (bool.Parse(ro1[0].ToString()) == true)
                {
                    foreach (DataRow ro in ds.Tables[6].Rows)
                    {
                        if (Hostel == "")
                            Hostel = "No";
                        string Feewaiver = ro["FeeWaiverType"].ToString();
                        if (Feewaiver == "")
                            Feewaiver = "No Feewaiver";

                        Subject = "STUDENT APPLIED FOR TRANSPORTAION";
                        Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                        Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR TRANSPORTAION</font></h3>";
                        Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                        if (ro["Degree"].ToString().ToUpper() == "SHORT COURSE")
                        {
                            Message = Message + "</td></tr><tr><td>FROM DATE</td><td>" + DateTime.Parse(ro["ShortFromDate"].ToString()).ToShortDateString().ToUpper();
                            Message = Message + "</td></tr><tr><td>TO DATE</td><td>" + DateTime.Parse(ro["ShortToDate"].ToString()).ToShortDateString().ToUpper();
                        }
                        else
                        {
                            Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                        }
                        Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                        //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                        if (ds.Tables[24].Rows.Count != 0)
                        {
                            Message = Message + "</td></tr><tr><td>TRANSPORTAION</td><td>" + "YES";
                            Message = Message + "</td></tr><tr><td>TRANSPORT LOCATION</td><td>" + ds.Tables[24].Rows[0][0].ToString().ToUpper();
                        }
                        Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                    }

                    Body = Message;
                    ToEmail = "finance@skylineuniversity.ac.ae";//"pro@skylineuniversity.ac.ae";
                    //CC = "firoj@skylineuniversity.ac.ae"; //"hrd@skylineuniversity.ac.ae";
                    SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                    Message = Message + "Visa : Yes" + Environment.NewLine;
                }
            }

            foreach (DataRow ro1 in ds.Tables[3].Rows)
            {
                if (ro1[0].ToString() == "Yes")
                {
                    foreach (DataRow ro in ds.Tables[6].Rows)
                    {
                        if (Hostel == "")
                            Hostel = "No";
                        if (Toc == "")
                            Toc = "No";
                        string Feewaiver = ro["FeeWaiverType"].ToString();
                        if (Feewaiver == "")
                            Feewaiver = "No Feewaiver";

                        Subject = "STUDENT APPLIED FOR TOC";
                        Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                        Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR TOC</font></h3>";
                        Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                        //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>TOC</td><td>" + "YES";
                        Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                    }

                    Body = Message;
                    ToEmail = "iroffice@skylineuniversity.ac.ae"; //"iroffice@skylineuniversity.ac.ae";
                    //CC = "software@skylineuniversity.ac.ae";
                    SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                    Message = Message + "Toc : Yes" + Environment.NewLine;
                }
            }


            try
            {
                string ExamType = "";
                string ExamTime = "";
                int ExamData = 0;

                foreach (DataRow ro1 in ds.Tables[8].Rows)
                {
                    ExamData = int.Parse(ro1[0].ToString());
                    if (ro1[0].ToString() != "0")
                    {
                        if ((ro1[2].ToString()) != "")
                        {
                            if ((ro1[3].ToString()) != "")
                            {
                                ExamType = ro1[2].ToString() + "/" + ro1[3].ToString();
                            }
                            else
                            {
                                ExamType = ro1[2].ToString();
                            }
                        }
                        else
                        {
                            if ((ro1[3].ToString()) != "")
                            {
                                ExamType = ro1[3].ToString();
                            }
                            else
                            {
                                ExamType = "";
                            }
                        }
                        if ((ro1[4].ToString()) != "")
                        {
                            if ((ro1[5].ToString()) != "")
                            {
                                ExamTime = ro1[4].ToString() + "/" + ro1[5].ToString();
                            }
                            else
                            {
                                ExamTime = ro1[4].ToString();
                            }
                        }
                        else
                        {
                            if ((ro1[5].ToString()) != "")
                            {
                                ExamTime = ro1[5].ToString();
                            }
                            else
                            {
                                ExamTime = "";
                            }
                        }
                        string Val = (ro1[2].ToString() + ro1[3].ToString());
                        if (ds.Tables[20].Rows.Count != 0)
                            Val = "AA";
                        if (Val != "")
                        {
                            foreach (DataRow ro in ds.Tables[6].Rows)
                            {
                                if (Hostel == "")
                                    Hostel = "No";
                                string Feewaiver = ro["FeeWaiverType"].ToString();
                                if (Feewaiver == "")
                                    Feewaiver = "No Feewaiver";

                                Subject = "STUDENT APPLIED FOR " + ExamType.ToUpper();
                                Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                                Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR " + ExamType.ToUpper() + "</font></h3>";
                                Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                                Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                                //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                                if ((ro1[2].ToString() + ro1[3].ToString()) != "")
                                {
                                    Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + ExamType.ToUpper();
                                    Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ExamTime.ToUpper();
                                }
                            }
                            if (ds.Tables[20].Rows.Count != 0) //Personal InterView
                            {
                                ExamType = ds.Tables[20].Rows[0]["ExamType"].ToString().ToUpper();
                                if (ExamType == "Personal Interview")
                                {
                                    Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + "Personal Interview".ToUpper();
                                    Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper();
                                }
                            }
                            try
                            {
                                if (ds.Tables[26].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                {
                                    Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + "Challenge Exam".ToUpper();
                                    Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[26].Rows[0]["ExamDate"].ToString().ToUpper();
                                }
                            }
                            catch
                            {
                            }
                            Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                            Body = Message;
                            ToEmail = "examination@skylineuniversity.ac.ae";
                            SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                            SendEmails.SendEmail(FromEmail, "dean@skylineuniversity.ac.ae", Subject, Body, CC);
                            SendEmails.SendEmail(FromEmail, "amitabh@skylineuniversity.ac.ae", Subject, Body, CC);
                            Message = Message + "ENTRANCE Exam : Yes" + Environment.NewLine;
                        }
                    }
                }


                foreach (DataRow ro1 in ds.Tables[9].Rows)
                {
                    if (ds.Tables[9].Rows.Count != 0)  //if (bool.Parse(ro1[0].ToString()) == true)
                    {
                        foreach (DataRow ro in ds.Tables[6].Rows)
                        {
                            if (Hostel == "")
                                Hostel = "No";
                            string Feewaiver = ro["FeeWaiverType"].ToString();
                            if (Feewaiver == "")
                                Feewaiver = "No Feewaiver";

                            Subject = "STUDENT APPLIED FOR Feewaiver";
                            Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                            Message = Message + "<tr><td colspan=2><h3><font size=5>STUDENT APPLIED FOR Feewaiver</font></h3>";
                            Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                            if (ro["Degree"].ToString().ToUpper() == "SHORT COURSE")
                            {
                                Message = Message + "</td></tr><tr><td>FROM DATE</td><td>" + DateTime.Parse(ro["ShortFromDate"].ToString()).ToShortDateString().ToUpper();
                                Message = Message + "</td></tr><tr><td>TO DATE</td><td>" + DateTime.Parse(ro["ShortToDate"].ToString()).ToShortDateString().ToUpper();
                            }
                            else
                            {
                                Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                            }
                            Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                            //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>FEEWAIVER</td><td>" + ds.Tables[22].Rows[0][0].ToString().ToUpper();
                            Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                        }

                        Body = Message;
                        if (ds.Tables[22].Rows[0][0].ToString().ToUpper() != "No Feewaiver".ToUpper())
                        {
                            ToEmail = "finance@skylineuniversity.ac.ae";//"pro@skylineuniverrsity.ac.ae";
                            //CC = "firoj@skylineuniversity.ac.ae"; //"hrd@skylineuniverrsity.ac.ae";
                            SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                        }
                    }
                }
            }
            catch
            {
            }
            foreach (DataRow ro in ds.Tables[6].Rows)
            {
                if (ds.Tables[1].Rows.Count == 0)
                    Hostel = "No";
                else
                    Hostel = "YES";
                if (ds.Tables[2].Rows.Count == 0)
                    Visa = "No";
                else
                    Visa = "YES";
                if (ds.Tables[3].Rows.Count == 0)
                    Toc = "No";
                else
                    Toc = "YES";
                if (ds.Tables[7].Rows.Count == 0)
                    Transportaion = "No";
                else
                    Transportaion = "YES";
                string Feewaiver = ds.Tables[22].Rows[0][0].ToString().ToUpper();
                if (Feewaiver == "")
                    Feewaiver = "No Feewaiver";

                Subject = "Today's Admission Registration Details";
                Subject = Subject.ToUpper();
                Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                Message = Message + "<tr><td colspan=2><h3><font size=5>" + Subject + "</font></h3>";
                Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                if (ro["Degree"].ToString().ToUpper() == "SHORT COURSE")
                {
                    Message = Message + "</td></tr><tr><td>FROM DATE</td><td>" + DateTime.Parse(ro["ShortFromDate"].ToString()).ToShortDateString().ToUpper();
                    Message = Message + "</td></tr><tr><td>TO DATE</td><td>" + DateTime.Parse(ro["ShortToDate"].ToString()).ToShortDateString().ToUpper();
                    CC = "cpd@skylineuniversity.ac.ae,finance@skylineuniversity.ac.ae";
                }
                else
                {
                    CC = "admissions@skylineuniversity.ac.ae,asma@skylineuniversity.ac.ae,rakesh@skylineuniversity.ac.ae,finance@skylineuniversity.ac.ae";
                    Message = Message + "</td></tr><tr><td>BATCH</td><td>" + ro["TermName"].ToString().ToUpper();
                }
                Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                ////Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>FEE WAIVER</td><td>" + Feewaiver.ToUpper();
                Message = Message + "</td></tr><tr><td>STUDENT TYPE</td><td>" + ro["StudentType"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>STUDENT CATEGORY</td><td>" + ro["IsInternationalStudent"].ToString().ToUpper();
                if (ds.Tables[23].Rows.Count != 0)
                {
                    Message = Message + "</td></tr><tr><td>VISA LETTER/ EMBASSY LETTER</td><td>" + ds.Tables[23].Rows[0][0].ToString().ToUpper();
                }
                if (Hostel.ToUpper() != "NO")
                {
                    Message = Message + "</td></tr><tr><td>HOSTEL REQUIRED</td><td>" + Hostel.ToUpper();
                }
                if (Visa.ToUpper() != "NO")
                {
                    Message = Message + "</td></tr><tr><td>VISA REQUIRED</td><td>" + Visa.ToUpper();
                }
                if (Toc.ToUpper() != "NO")
                {
                    Message = Message + "</td></tr><tr><td>TOC REQUIRED</td><td>" + Toc.ToUpper();
                }
                // Newly Added
                if (ds.Tables[15].Rows.Count != 0)
                {
                    Message = Message + "</td></tr><tr><td>MEDIA SOURCE</td><td>" + ds.Tables[15].Rows[0]["MediaSource"].ToString().ToUpper();
                }
                if (Transportaion != "No")
                {
                    Message = Message + "</td></tr><tr><td>TRANSPORTAION REQUIRED</td><td>" + Transportaion.ToUpper();
                    try
                    {
                        Message = Message + "</td></tr><tr><td>TRANSPORTAION LOCATION</td><td>" + ds.Tables[24].Rows[0][0].ToString().ToUpper();
                    }
                    catch
                    {
                    }
                }
                if (ds.Tables[11].Rows.Count != 0)
                {
                    Message = Message + "</td></tr><tr><td>IS WORKING</td><td>" + "YES";
                    Message = Message + "</td></tr><tr><td>ORGANIZATION</td><td>" + ds.Tables[11].Rows[0]["Organization"].ToString().ToUpper();
                    Message = Message + "</td></tr><tr><td>DESIGNATION</td><td>" + ds.Tables[11].Rows[0]["Designation"].ToString().ToUpper();
                    Message = Message + "</td></tr><tr><td>LOCATION</td><td>" + ds.Tables[11].Rows[0]["City"].ToString().ToUpper();
                }
                else
                {
                    Message = Message + "</td></tr><tr><td>IS WORKING</td><td>" + "NO";
                }
                if (ds.Tables[12].Rows.Count != 0)
                {
                    Message = Message + "</td></tr><tr><td>QUALIFICATION</td><td>" + ds.Tables[12].Rows[0]["Qualification"].ToString().ToUpper();
                    Message = Message + "</td></tr><tr><td>UNIVERSITY / SCHOOL</td><td>" + ds.Tables[12].Rows[0]["UniversityName"].ToString().ToUpper();
                    Message = Message + "</td></tr><tr><td>CGPA/PERCENTAGE</td><td>" + ds.Tables[12].Rows[0]["CGPA"].ToString().ToUpper();
                    Message = Message + "</td></tr><tr><td>CITY</td><td>" + ds.Tables[12].Rows[0]["City"].ToString().ToUpper();
                }

                try
                {
                    if (ro["Degree"].ToString().ToUpper() != "SHORT COURSE")
                    {
                        if (ds.Tables[13].Rows.Count != 0)
                        {
                            Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + ds.Tables[13].Rows[0]["TestType"].ToString().ToUpper();
                            if (ds.Tables[13].Rows[0]["ExamDate"].ToString() != "")
                            {
                                Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[13].Rows[0]["ExamDate"].ToString().ToUpper();
                            }
                            else
                            {
                                Message = Message + "</td></tr><tr><td>STATUS OF EXAM</td><td>" + ds.Tables[13].Rows[0]["StatusOfExam"].ToString().ToUpper();
                            }
                        }
                        if (ds.Tables[20].Rows.Count != 0)
                        {
                            Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + ds.Tables[20].Rows[0]["ExamType"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper();
                        }
                        try
                        {
                            if (ds.Tables[26].Rows.Count != 0)//(ExamType == "Chalange Exam")
                            {
                                Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + "Challenge Exam".ToUpper();
                                Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[26].Rows[0]["ExamDate"].ToString().ToUpper();
                            }
                        }
                        catch
                        {
                        }
                        if (ds.Tables[14].Rows.Count != 0)
                        {
                            if (ro["Degree"].ToString().ToUpper() != "MBA" || ro["Degree"].ToString().ToUpper() != "MBA WEEKEND")
                            {
                                Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + "MATH/SAT";
                                if (ds.Tables[14].Rows[0]["ExamDate"].ToString() != "")
                                {
                                    Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[14].Rows[0]["ExamDate"].ToString().ToUpper();
                                }
                                else
                                {
                                    Message = Message + "</td></tr><tr><td>STATUS OF EXAM</td><td>" + ds.Tables[14].Rows[0]["StatusOfExamMath"].ToString().ToUpper();
                                }
                            }
                        }
                        try
                        {
                            SMSCAPI obj = new SMSCAPI();
                            string strPostResponse;
                            string OrtDate = ds.Tables[21].Rows[0][0].ToString();
                            if (OrtDate != "")
                            {
                                //strPostResponse = obj.SendSMS("", "", "+" + ds.Tables[5].Rows[0][0].ToString(), "Dear student your " + ds.Tables[20].Rows[0]["ExamType"].ToString().ToUpper() + " Exam is scheduled on " + ds.Tables[14].Rows[0]["ExamDate"].ToString().ToUpper() + " and the Orientation will be conducted on " + OrtDate + ".");
                                if (ro["Degree"].ToString().ToUpper() != "MBA" || ro["Degree"].ToString().ToUpper() != "MBA WEEKEND")
                                {
                                    strPostResponse = obj.SendSMS("", "", "+" + ds.Tables[5].Rows[0][0].ToString(), "Dear student your Math Exam is scheduled on " + (ds.Tables[14].Rows[0]["ExamDate"].ToString()) + ".");
                                }
                            }
                            else
                            {
                                strPostResponse = obj.SendSMS("", "", "+" + ds.Tables[5].Rows[0][0].ToString(), "Dear student your " + ds.Tables[20].Rows[0]["ExamType"].ToString().ToUpper() + " Exam is scheduled on " + ds.Tables[14].Rows[0]["ExamDate"].ToString().ToUpper() + ".");
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {

                }

                DataSet dtUndertaking = s.GetUndertakingDetails(Session["LinkId"].ToString());
                string UnderTaking = "";
                foreach (DataRow roww in dtUndertaking.Tables[0].Rows)
                {
                    if (UnderTaking == "")
                        UnderTaking = UnderTaking + roww["Uname"].ToString().ToString();
                    else
                        UnderTaking = UnderTaking + "," + roww["Uname"].ToString().ToString();
                }
                if (dtUndertaking.Tables[0].Rows.Count != 0)
                {
                    Message = Message + "</td></tr><tr><td>UNDER TAKING</td><td>" + UnderTaking;
                }

                // Ends Here
                Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
            }
            if (ds.Tables[6].Rows.Count != 0)
            {
                ToEmail = "nitin@skylineuniversity.ac.ae";
                Body = Message;
                SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
            }
            else
            {
                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", Subject, Body, CC);
            }

            try
            {
                foreach (DataRow ro in ds.Tables[6].Rows)
                {
                    if (ro["Degree"].ToString().ToUpper() != "SHORT COURSE")
                    {
                        DataSet dtUndertaking = s.GetUndertakingDetails(Session["LinkId"].ToString());
                        string Message1 = "";
                        string UserName = ds.Tables[6].Rows[0]["RegistrationNo"].ToString();
                        string Password = s.GetPassword(ds.Tables[6].Rows[0]["RegistrationNo"].ToString());
                        Message = "<tr><td><br /></td></tr>";
                        Message = Message + "<tr style=text-align:justify><td colspan=2>" + "Kindly note that you are required to keep in touch with SUC through your portal and official Email issued to you.  Your Username and Password is mentioned below</td></tr>";
                        Message = Message + "<tr><td><br /></td></tr>";
                        Message = Message + "<tr><td colspan=2>UserName: " + UserName + "</td></tr>";
                        Message = Message + "<tr><td colspan=2>Password: " + UserName + "</td></tr>";
                        Message = Message + "<tr><td colspan=2><br /></td></tr>";
                        Message = Message + "<tr><td colspan=2>You are guided to change your password once you log on for the first time.</td></tr>";
                        Message = Message + "<tr><td colspan=2><br /></td></tr>";
                        Message = Message + "<tr><td colspan=2>Following documents are pending from your side which should be completed within 1 week of your admission date.</td></tr>";
                        Message = Message + "<tr><td colspan=2><br /></td></tr>";
                        foreach (DataRow roww in dtUndertaking.Tables[0].Rows)
                        {
                            Message = Message + "<tr><td colspan=2>" + roww["Uname"].ToString() + "</td></tr>";
                        }
                        try
                        {
                            string ExamType = ds.Tables[14].Rows[0]["ExamType"].ToString();
                            string ExamDate = ds.Tables[14].Rows[0]["ExamDate"].ToString();
                            string ExamTime = "";
                            Message = Message + "<tr><td colspan=2><br /></td></tr>";
                            if (ro["Degree"].ToString().ToUpper().Contains("BBA"))
                                Message = Message + "<tr><td colspan=2>Your entrance exam " + ExamType + " is scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: TOEFL Navigator for TOEFL test; Mathematics placement test guide for Math Exam.</td></tr>";
                            else
                                Message = Message + "<tr><td colspan=2>Your entrance exam " + ExamType + " is scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: TOEFL Navigator for TOEFL test.</td></tr>";

                            try
                            {
                                if (ds.Tables[26].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                {
                                    Message = Message + "<tr><td colspan=2>Your Challenge exam is scheduled on " + ds.Tables[26].Rows[0]["ExamDate"].ToString().ToUpper() + " at SUC campus.</td></tr>";
                                }
                                if (ds.Tables[20].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                {
                                    Message = Message + "<tr><td colspan=2>Your Personal Interview is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + "" + ds.Tables[20].Rows[0]["ExamTime"].ToString().ToUpper() + " at SUC campus.</td></tr>";
                                }
                            }
                            catch
                            {

                            }
                        }
                        catch
                        {
                        }
                        Message = Message + "<tr><td colspan=2></td></tr>";
                        Message = Message + "<tr><td colspan=2></td></tr>";
                        Message = Message + "<tr><td colspan=2>" + "Best Regards," + "</td></tr>";
                        Message = Message + "<tr><td colspan=2>" + "Skyline University College" + "</td></tr>";
                        Message = Message + "<tr><td colspan=2>" + "University City of Sharjah, Sharjah" + "</td></tr>";
                        Message = Message + "<tr><td colspan=2>" + "P.O. Box: 1797, Sharjah, U.A.E" + "</td></tr>";
                        Message = Message + "<tr><td colspan=2>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166" + "</td></tr>";
                        Message = Message + "<tr><td colspan=2>" + "Email: admissions@skylineuniversity.ac.ae" + "</td></tr>";

                        Message = Message + "</table>";

                        if (d.GetCheckMailContact(Session["LinkId"].ToString()) != "")
                        {
                            Message1 = "<table>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2><h3><font size=5>REGISTRATION DETAILS</font></h3></td></tr>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2>" + "Dear " + ds.Tables[6].Rows[0]["Name"].ToString().ToUpper() + ", we confirm acceptance of your documents for admission of Skyline University College, kindly note that your admission is subject to completion of your admission requirement by your good self as per admission criteria explained to you during the time of admission process.</td></tr>";
                            Message = Message1 + Message;
                            //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailContact(Session["LinkId"].ToString()), "Registration Details", Message, "");
                            SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "firoj@skylineuniversity.ac.ae", "Registration Details", Message, "");
                        }
                        if (d.GetCheckMailGuardian(Session["LinkId"].ToString()) != "")
                        {
                            Message1 = "<table>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2><h3><font size=5>REGISTRATION DETAILS</font></h3></td></tr>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2>" + "Dear Guardian, we confirm acceptance of your ward's documents for admission of Skyline University College, kindly note that your ward's admission is subject to completion of your ward's admission requirement by your ward's good self as per admission criteria explained to your ward's during the time of admission process.</td></tr>";
                            Message = Message1 + Message;
                            //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailGuardian(Session["LinkId"].ToString()), "Registration Details", Message, "");
                            SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "firoj@skylineuniversity.ac.ae", "Registration Details", Message, "");
                        }
                        foreach (DataRow roww in dtUndertaking.Tables[1].Rows)
                        {
                            if (roww["StudentType"].ToString() == "1")
                            {
                                if (d.GetCheckMailParent(Session["LinkId"].ToString()) != "")
                                {
                                    Message1 = "<table>";
                                    Message1 = Message1 + "<tr style=text-align:justify><td colspan=2><h3><font size=5>REGISTRATION DETAILS</font></h3></td></tr>";
                                    Message1 = Message1 + "<tr style=text-align:justify><td colspan=2>" + "Dear Parent, we confirm acceptance of your documents for admission of Skyline University College, kindly note that your admission is subject to completion of your admission requirement by your good self as per admission criteria explained to you during the time of admission process.</td></tr>";
                                    Message = Message1 + Message;
                                    //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailParent(Session["LinkId"].ToString()), "Registration Details", Message, "");
                                    SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "firoj@skylineuniversity.ac.ae", "Registration Details", Message, "");
                                }
                            }
                        }
                        try
                        {
                            SMSCAPI obj1 = new SMSCAPI();
                            string strPostResponse1;
                            foreach (DataRow roww in dtUndertaking.Tables[0].Rows)
                            {
                                strPostResponse1 = obj1.SendSMS("", "", "+" + ds.Tables[5].Rows[0][0].ToString(), "Welcome to SUC, in order to complete the registration process sucessfully. Please submit the required document ASAP.");
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {
                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", Subject, Body, CC);
                pnlPrintGrid.Visible = false;
            }

            //for sms
            foreach (DataRow ro in ds.Tables[5].Rows)
            {
                string Mobile = ro[0].ToString();
                string result;
                string senderusername = "UName";
                string senderpassword = "Password";
                string senderid = "UId";
                com.vectramind.mobile.Service sms = new Service();
                //result = sms.SendTextMessage(senderusername, senderpassword, "Hi", 0, senderid, Mobile, 0);
            }


            btnFinalize.Visible = false;
            lblMesag.Text = "Message Sent Successfully!";
            pnlPrintGrid.Visible = true;
            FillGridView1(int.Parse(Session["LinkId"].ToString()));
            lblMesag.ForeColor = System.Drawing.Color.Blue;
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvReportList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAddFileNumber_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = s.UpdateFinalize(Session["LinkId"].ToString(), txtFileNumber.Text);
            if (Result == "RegisterNo")
            {
                lblMesag.Text = "Added Sucessfully!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMesag.Text = "Try Again!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblMesag.Text = "Try Again!";
            lblMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
}