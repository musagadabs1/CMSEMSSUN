using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_AdmissionCheckList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                DataSet ds = new DataSet();
                ds = s.GetStudentDetails1(Request.QueryString["Id"].ToString());
                                


                foreach (DataRow ro in ds.Tables[1].Rows)
                {
                    txtStudentId.Text = ro["RegistrationNo"].ToString();
                    txtName.Text = ro["Name"].ToString();
                    txtProgram.Text = ro["CourseType"].ToString();
                    txtSession.Text = ro["Shift"].ToString();
                    txtIntake.Text = ro["TermName"].ToString();
                    txtLevel.Text = "FRESHMEN";
                    txtNationality.Text = ro["NationalityName"].ToString();
                    txtFwType.Text = ro["Percentage"].ToString();
                    txtAdminRemarks.Text = ro["AdminRemarks"].ToString();
                    txtFinanceRemarks.Text = ro["FinanceRemarks"].ToString();
                    txtGeneralRemarks.Text = ro["GeneralRemarks"].ToString();
                    txtNoOfCourses.Text = ro["NoOfCourses"].ToString();
                    txtTOCAmount.Text = ro["TOCAmount"].ToString();
                    if (ro["FWAmount"].ToString() != "0")
                        txtFWAmount.Text = ro["FWAmount"].ToString();
                }
                foreach (DataRow ro in ds.Tables[0].Rows)
                {
                    if (ro["EXAM"].ToString() != "MATH" && ro["EXAM"].ToString() != "DIPLOMA")
                    {
                        lblExamType.Text = ro["EXAM"].ToString();
                        txtToeflScore.Text = ro["examstatus"].ToString()+" - "+ ro["marks"].ToString();

                    }
                    else
                    {

                        txtMathScore.Text = ro["examstatus"].ToString()+" - "+ ro["marks"].ToString();
                    }
                }
                foreach (DataRow ro in ds.Tables[2].Rows)
                {
                    if (ro["feewaivers"].ToString() == "NO FEEWAIVER")
                    {
                        lblFeewaiver.Text = "NO";
                    }
                    else
                    {
                        lblFeewaiver.Text = "YES";
                    }
                    txtFwType.Text = ro["feewaivers"].ToString();
                }
                foreach (DataRow ro in ds.Tables[3].Rows)
                {
                    lblVisaType.Text = ro["VISASTATUS"].ToString();
                }
                foreach (DataRow ro in ds.Tables[4].Rows)
                {
                    lblHostelStatus.Text = ro["HostelStatus"].ToString();
                }
                foreach (DataRow ro in ds.Tables[5].Rows)
                {
                    lblToc.Text = ro["TOCStatus"].ToString();
                }
                string DeptId = Session["DepId"].ToString();
                if (Session["DepId"].ToString() == "4")
                {
                    txtAdminRemarks.Enabled = true;
                    txtFinanceRemarks.Enabled = false;
                    txtGeneralRemarks.Enabled = false;
                }
                else if (Session["DepId"].ToString() == "2")
                {
                    txtAdminRemarks.Enabled = false;
                    txtFinanceRemarks.Enabled = true;
                    txtGeneralRemarks.Enabled = false;
                    txtFwType.Enabled = false;
                    txtNoOfCourses.Enabled = false;
                    txtProof.Enabled = false;
                    txtResultAIPC.Enabled = false;
                    txtResultIELP.Enabled = false;
                    txtScoreMaths.Enabled = false;
                    txtToeflScore.Enabled = false;
                    txtFWAmount.Enabled = false;
                    txtMathScore.Enabled = false;
                    rdbAIPC120.Enabled = false;
                    rdbAIPC190.Enabled = false;
                    rdbAIPCNA.Enabled = false;
                    chkNoIELP.Enabled = false;
                    chkNoMath.Enabled = false;
                    chkNoProof.Enabled = false;
                    chkYesIELP.Enabled = false;
                    chkYesMath.Enabled = false;
                    chkYesProof.Enabled = false;

                }
                else if (Session["DepId"].ToString() == "32")
                {
                    txtAdminRemarks.Enabled = false;
                    txtFinanceRemarks.Enabled = false;
                    txtGeneralRemarks.Enabled = true;
                    txtFwType.Enabled = false;
                    txtNoOfCourses.Enabled = false;
                    txtProof.Enabled = false;
                    txtResultAIPC.Enabled = false;
                    txtResultIELP.Enabled = false;
                    txtScoreMaths.Enabled = false;
                    txtToeflScore.Enabled = false;
                    txtFWAmount.Enabled = false;
                    txtMathScore.Enabled = false;
                    rdbAIPC120.Enabled = false;
                    rdbAIPC190.Enabled = false;
                    rdbAIPCNA.Enabled = false;
                    chkNoIELP.Enabled = false;
                    chkNoMath.Enabled = false;
                    chkNoProof.Enabled = false;
                    chkYesIELP.Enabled = false;
                    chkYesMath.Enabled = false;
                    chkYesProof.Enabled = false;



                }
                else
                {
                    txtAdminRemarks.Enabled = false;
                    txtFinanceRemarks.Enabled = false;
                    txtGeneralRemarks.Enabled = false;
                }
            }
            catch
            {
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            String Body="";
             string AIPC = "NA";
            if (rdbAIPC120.Checked == true)
                AIPC = "120 HOURS";
            else if (rdbAIPC190.Checked == true)
                AIPC = "190 HOURS";

            string Mathcrashcourse = "NA";
            if (chkYesMath.Checked == true)
                Mathcrashcourse = "YES";
            else if (chkNoMath.Checked == true)
                Mathcrashcourse = "NO";
            
            
            if   ( (int.Parse(Session["DepId"].ToString())==32) || (int.Parse(Session["DepId"].ToString())==4) ||(int.Parse(Session["DepId"].ToString())==2))
            {

                string Result = s.InsertAdminCheckList(Request.QueryString["Id"].ToString(), lblExamType.Text, txtToeflScore.Text, txtMathScore.Text, Mathcrashcourse, txtScoreMaths.Text, AIPC, txtResultAIPC.Text, chkNoIELP.Checked,
                txtResultIELP.Text, txtFwType.Text, chkYesProof.Checked, txtProof.Text, txtFWAmount.Text, lblToc.Text, txtTOCAmount.Text, txtNoOfCourses.Text, lblVisaType.Text,
                lblHostelStatus.Text, txtAdminRemarks.Text, txtFinanceRemarks.Text, txtGeneralRemarks.Text, int.Parse(Session["EmpId"].ToString()), "");
            if (Result == "Sucess")
            {
                lblMesag.Text = "Sucessfully Submitted";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
                // newlyadded for mail
               
                if (int.Parse(Session["DepId"].ToString())==4)
                {
                    Body = "Admin Checklist is completed by Admin Department for the Registration No : " + s.GetRegNo(Request.QueryString["Id"].ToString()) + " Kindly Verify the Checklist";
                    SendEmails.SendEmail("administration@skylineuniversity.ac.ae", "finance@skylineuniversity.ac.ae", "AdminChecklist Stud ID - " + s.GetRegNo(Request.QueryString["Id"].ToString()), Body, "");
                }
                if (int.Parse(Session["DepId"].ToString()) == 2)
                {
                    if (lblFeewaiver.Text == "YES")
                    {
                        Body = "Admin Checklist is completed by Finance Department for the Registration No : " + s.GetRegNo(Request.QueryString["Id"].ToString()) + " Kindly Verify the Checklist";
                        SendEmails.SendEmail("finance@skylineuniversity.ac.ae", "skyline@skylineuniversity.ac.ae", "AdminChecklist Stud ID - " + s.GetRegNo(Request.QueryString["Id"].ToString()), Body, "");
                    }
                }
                if (int.Parse(Session["DepId"].ToString()) == 32)
                {
                    Body = "Admin Checklist is completed by COEC Office for the  Registration No : " + s.GetRegNo(Request.QueryString["Id"].ToString());
                    SendEmails.SendEmail("skyline@skylineuniversity.ac.ae", "administration@skylineuniversity.ac.ae", "AdminChecklist Stud ID - "+s.GetRegNo(Request.QueryString["Id"].ToString()), Body, "");
                }

            }
            else
            {
                lblMesag.Text = "Please try again!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
            }
            else
            { 
                lblMesag.Text = "Not Authorized!";
                lblMesag.ForeColor = System.Drawing.Color.Blue;
            }
            
        }
        catch
        {
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrintOtherReport.aspx?A=" + Request.QueryString["Id"].ToString() + "&E=13", false);
    }
    protected void txtNoOfCourses_TextChanged(object sender, EventArgs e)
    {
        Int32 Value=0;
        Value=int.Parse(txtNoOfCourses.Text);
        Value = Value * 500;
        txtTOCAmount.Text = Value.ToString();

        
    }
}