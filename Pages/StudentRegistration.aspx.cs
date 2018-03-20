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
using System.Text.RegularExpressions;

public partial class StudentRegistration : System.Web.UI.Page
{
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                DataTable dtFeeGroup = s.GetFeesItems(0, int.Parse(Request.QueryString["Id"].ToString()));
                gvAddedFeeGroup.DataSource = dtFeeGroup;
                gvAddedFeeGroup.DataBind();
                txtName.Text = s.GetName(int.Parse(Request.QueryString["Id"].ToString())).ToUpper();
                txtRegNo.Text = s.GetRegNo(Request.QueryString["Id"].ToString()).ToUpper();
                CheckAddGroup();
                pnlemsat.Visible = false;
                if (dtFeeGroup.Rows.Count == 0)
                    pnlAddedGroup.Visible = false;
                else
                    pnlAddedGroup.Visible = true;
                txtHandiCapped.Enabled = false;
                txtChronicDisease.Enabled = false;
                rdbProgramRegular.Checked = true;
                rdbHavingToeflYes.Checked = true;
                rdbMathResultNo.Checked = true;
                rdbSatScoreNo.Checked = true;
                rdbSatScoreYes.Checked = false;
                rdbResultSubmit.Checked = true;
                rdbNativeEnglishNo.Checked = true;
                try
                {
                    LoadDropdown();


                    Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                    Drpschool.DataTextField = "schoolname";
                    Drpschool.DataValueField = "schoolcode";
                    Drpschool.DataBind();
                    Drpschool.SelectedValue = Session["schoolcode"].ToString();
                    Drpschool_SelectedIndexChanged(sender, e);


                }
                catch
                {

                }
                pnlfoundation.Visible = false;
                rdbTransportationYes.Checked = false;
                rdbTransportationNo.Checked = true;
                rdbTransportationNo_CheckedChanged(sender, e);
                rdbHostelNo.Checked = true;
                rdbHostelYes.Checked = false;
                lnkContact_Click(sender, e);
                rdbSkylineVisaNo.Checked = true;
                pnlhavingSatNo.Visible = true;
                ddlTransferUniversity.SelectedValue = "No";
                ddlTransferUniversity_SelectedIndexChanged(sender, e);
                rdbNotWorking.Checked = true;
                rdbWorking.Checked = false;
                pnlExperience1.Visible = false;
                ddlToYear.Enabled = false;
                ddlCountryOfIssue.SelectedValue = "AE";
                ddlVisaType_SelectedIndexChanged(sender, e);

                SetPrograms();
                SetUndertaking();

               // ------

                     pnlContact.Visible = true;
                pnlParents.Visible = false;
                pnlProgram.Visible = false;
                pnlTransport.Visible = false;
                pnlEntrance.Visible = false;
                pnlRemarks.Visible = false;
                pnlVisa.Visible = false;
                pnlExperience.Visible = false;
                PnlFitness.Visible = false;
                PnlHostelMain.Visible = false;
                PnlMediaSourceMain.Visible = false;
                PnlFinance.Visible = false;
                PnlQualification.Visible = false;
                PnlTocMain.Visible = false;
                PnlSkylineVisaMain.Visible = false;
                PnlUndertaking.Visible = false;
                pnlPrint.Visible = false;
            //






                //gvAddGroup.DataSource = s.GetFeesItems(1, int.Parse(Request.QueryString["Id"].ToString()));
                //gvAddGroup.DataBind();
                string RegNo = s.GetRegNo(Request.QueryString["Id"].ToString());
                int Status = s.GetFinalStudentStatus(RegNo);
                if (Session["DepId"].ToString() != "4")
                {
                    try
                    {
                        if (Request.QueryString["F"].ToString() == "1")
                        {
                            if (Status != 0)
                            {
                                DisableButton();
                            }
                        }
                    }
                    catch
                    {
                        if (Status != 0)
                        {
                            DisableButton();
                        }
                    }
                }
            }
            catch
            {
                //Response.Redirect("Login.aspx", false);
            }
            try
            {
            }
            catch
            {
            }
        }

    }


    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlDegreeType.DataSource = s.SetDropdownListCDB(14, Drpschool.SelectedValue);
        ddlDegreeType.DataTextField = "Description";
        ddlDegreeType.DataValueField = "Id";
        ddlDegreeType.DataBind();
        ddlDegreeType.SelectedIndex = 1;
        ddlDegreeType_SelectedIndexChanged(sender, e);

    }


    public void DisableButton()
    {
        btnAdd.Visible = false;
        btnAddExperience.Visible = false;
        btnAddFileNumber.Visible = true;
        btnAddHostelMHistory.Visible = false;
        btnAddMHistory.Visible = false;
        btnAddNewVisa.Visible = false;
        btnDeleteNewVisa.Visible = false;
        btnAddParents.Visible = false;
        btnAddQualification.Visible = false;
        btnAddRemarks.Visible = false;
        btnAttach.Visible = false;
        btncancel.Visible = false;
        btnFinalize.Visible = false;
        btnFitness.Visible = false;
        btnMediaSource.Visible = false;
        btnProceed.Visible = false;
        btnRemove.Visible = false;
        btnSaveFinance.Visible = false;
        btnSaveProgram.Visible = false;
        btnSaveVDType.Visible = false;
        btnSubmitHostel.Visible = false;
        btnSubmitMath.Visible = false;
        btnSubmitToc.Visible = false;
        btnSubmitToefl.Visible = false;
        btnSubmitTransportation.Visible = false;
        btnSubmitVisaInfo.Visible = false;
        btnUnderTaking.Visible = false;
        btnUpdateDetails.Visible = false;
        btnUpdateExp.Visible = false;
        btnUpdateMath.Visible = false;
        btnUpdateQualification.Visible = false;
        btnUpdateRemarks.Visible = false;
        btnUpdateToc.Visible = false;
        btnDeleteTOC.Visible = false;
        btnUpdateToefl.Visible = false;
        btnDeleteToefl.Visible = false;
        btnUpdateVisa.Visible = false;
        btnDeleteTransportation.Visible = false;
        btnDeleteHostel.Visible = false;
        btnProceed.Visible = true;
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();




        ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3, 1,Drpschool.SelectedValue);
        ddlDegreeType.DataTextField = "Description";
        ddlDegreeType.DataValueField = "Id";
        ddlDegreeType.DataBind();

        ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 2, Drpschool.SelectedValue);
        ddlShift.DataTextField = "Shift";
        ddlShift.DataValueField = "Id";
        ddlShift.DataBind();


        ddlnextShift.DataSource = s.SetDropdownListAsDegreeType(4, 2, Drpschool.SelectedValue);
        ddlnextShift.DataTextField = "Shift";
        ddlnextShift.DataValueField = "Id";
        ddlnextShift.DataBind();


        ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1, int.Parse(ddlDegreeType.SelectedValue), Drpschool.SelectedValue);
        ddlCourseType.DataTextField = "Description";
        ddlCourseType.DataValueField = "Id";
        ddlCourseType.DataBind();

        lbMediaSource.DataSource = s.SetDropdownListCDB(16);
        lbMediaSource.DataTextField = "MediaSource";
        lbMediaSource.DataValueField = "Id";
        lbMediaSource.DataBind();

        ddlPlaceofBirthNation.DataSource = s.SetDropdownListCDB(2);
        ddlPlaceofBirthNation.DataTextField = "NationalityName";
        ddlPlaceofBirthNation.DataValueField = "NationalityCode";
        ddlPlaceofBirthNation.DataBind();

        ddlNationalityDetails.DataSource = s.SetDropdownListCDB(2);
        ddlNationalityDetails.DataTextField = "NationalityName";
        ddlNationalityDetails.DataValueField = "NationalityCode";
        ddlNationalityDetails.DataBind();

        if (ddlDegreeType.SelectedValue =="9") 
        {
            ddlTerm.Items.Clear();
        ddlTerm.DataSource = s.SetDropdownListCDB(600);
        ddlTerm.DataTextField = "Term";
        ddlTerm.DataValueField = "TermID";
        ddlTerm.DataBind();
        }

        else
        {
            ddlTerm.DataSource = s.SetDropdownListCDB(600);
            ddlTerm.DataTextField = "Term";
            ddlTerm.DataValueField = "TermID";
            ddlTerm.DataBind();
        }

        try
        {
            ddlDiscountType.DataSource = s.SetDropdownListCDB(75);
            ddlDiscountType.DataTextField = "FeeWaiverType";
            ddlDiscountType.DataValueField = "Id";
            ddlDiscountType.DataBind();
            if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
                ddlType.DataSource = s.SetDropdownListCDB(94);
            else
                ddlType.DataSource = s.SetDropdownListCDB(74);
            ddlType.DataTextField = "FeeWaiverType";
            ddlType.DataValueField = "Id";
            ddlType.DataBind();
        }
        catch
        {
        }

        ddlMaritalStatus.DataSource = s.SetDropdownListCDB(21);
        ddlMaritalStatus.DataTextField = "MaritialStatus";
        ddlMaritalStatus.DataValueField = "Id";
        ddlMaritalStatus.DataBind();

        ddlStudentType.DataSource = s.SetDropdownListCDB(22);
        ddlStudentType.DataTextField = "StudentType";
        ddlStudentType.DataValueField = "Id";
        ddlStudentType.DataBind();

        ddlCountry.DataSource = s.SetDropdownListCDB(2);
        ddlCountry.DataTextField = "NationalityName";
        ddlCountry.DataValueField = "NationalityCode";
        ddlCountry.DataBind();

        ddlJobSector.DataSource = s.SetDropdownListCDB(24);
        ddlJobSector.DataTextField = "JobSector";
        ddlJobSector.DataValueField = "Id";
        ddlJobSector.DataBind();

        ddlYearOfPassing.DataSource = s.SetDropdownListCDB(26);
        ddlYearOfPassing.DataTextField = "Year";
        ddlYearOfPassing.DataValueField = "Id";
        ddlYearOfPassing.DataBind();

        ddlFromYear.DataSource = s.SetDropdownListCDB(26);
        ddlFromYear.DataTextField = "Year";
        ddlFromYear.DataValueField = "Id";
        ddlFromYear.DataBind();

        ddlToYear.DataSource = s.SetDropdownListCDB(26);
        ddlToYear.DataTextField = "Year";
        ddlToYear.DataValueField = "Id";
        ddlToYear.DataBind();

        ddlFromMonth.DataSource = s.SetDropdownListCDB(25);
        ddlFromMonth.DataTextField = "Month";
        ddlFromMonth.DataValueField = "Id";
        ddlFromMonth.DataBind();

        ddlToMonth.DataSource = s.SetDropdownListCDB(39);
        ddlToMonth.DataTextField = "Month";
        ddlToMonth.DataValueField = "Id";
        ddlToMonth.DataBind();

        ddlEmirateID.DataSource = s.SetDropdownListCDB(27);
        ddlEmirateID.DataTextField = "Emirates";
        ddlEmirateID.DataValueField = "Id";
        ddlEmirateID.DataBind();

        ddlTransportation.DataSource = s.SetDropdownListCDB(27);
        ddlTransportation.DataTextField = "Emirates";
        ddlTransportation.DataValueField = "Id";
        ddlTransportation.DataBind();

        ddlEmirates.DataSource = s.SetDropdownListCDB(27);
        ddlEmirates.DataTextField = "Emirates";
        ddlEmirates.DataValueField = "Id";
        ddlEmirates.DataBind();

        ddlPortOflastentry.DataSource = s.SetDropdownListCDB(27);
        ddlPortOflastentry.DataTextField = "Emirates";
        ddlPortOflastentry.DataValueField = "Id";
        ddlPortOflastentry.DataBind();

        //ddlDesignation.DataSource = s.SetDropdownListCDB(28);
        //ddlDesignation.DataTextField = "Designation";
        //ddlDesignation.DataValueField = "Id";
        //ddlDesignation.DataBind();

        ddlPreviousNationality.DataSource = s.SetDropdownListCDB(2);
        ddlPreviousNationality.DataTextField = "NationalityName";
        ddlPreviousNationality.DataValueField = "NationalityCode";
        ddlPreviousNationality.DataBind();

        ddlNationalityForLocalGuardian.DataSource = s.SetDropdownListCDB(2);
        ddlNationalityForLocalGuardian.DataTextField = "NationalityName";
        ddlNationalityForLocalGuardian.DataValueField = "NationalityCode";
        ddlNationalityForLocalGuardian.DataBind();

        ddlMaritialStatus.DataSource = s.SetDropdownListCDB(21);
        ddlMaritialStatus.DataTextField = "MaritialStatus";
        ddlMaritialStatus.DataValueField = "Id";
        ddlMaritialStatus.DataBind();

        ddlRemarksType.DataSource = s.SetDropdownListCDB(29);
        ddlRemarksType.DataTextField = "Remarks";
        ddlRemarksType.DataValueField = "Id";
        ddlRemarksType.DataBind();

        ddlExamDateToefl.DataSource = s.SetDropdownListCDB(30);
        ddlExamDateToefl.DataTextField = "Date";
        ddlExamDateToefl.DataValueField = "Id";
        ddlExamDateToefl.DataBind();

        drpentrancetesttype.DataSource = s.SetDropdownListCDB(106);
        drpentrancetesttype.DataTextField = "TestType";
        drpentrancetesttype.DataValueField = "Typeid";
        drpentrancetesttype.DataBind();

        drpagent.DataSource = s.SetDropdownListAsDegreeType(37, 0);
        drpagent.DataTextField = "Agencyname";
        drpagent.DataValueField = "Agentid";
        drpagent.DataBind();

        //ddlExamDateIELTS.DataSource = s.SetDropdownListCDB(48);
        //ddlExamDateIELTS.DataTextField = "Date";
        //ddlExamDateIELTS.DataValueField = "Id";
        //ddlExamDateIELTS.DataBind();

        ddlMathEntranceExam.DataSource = s.SetDropdownListCDB(125);
        ddlMathEntranceExam.DataTextField = "Date";
        ddlMathEntranceExam.DataValueField = "Id";
        ddlMathEntranceExam.DataBind();
       

        try
        {
            ddlExamDateToefl.SelectedIndex = 0;
            ddlExamTimeToefl.DataSource = s.SetDropdownListAsDegreeType(41, int.Parse(ddlExamDateToefl.SelectedValue));
            ddlExamTimeToefl.DataTextField = "Date";
            ddlExamTimeToefl.DataValueField = "Id";
            ddlExamTimeToefl.DataBind();

           
        }

        catch
        {
            ddlExamTimeToefl.DataSource = s.SetDropdownListCDB(32);
            ddlExamTimeToefl.DataTextField = "Date";
            ddlExamTimeToefl.DataValueField = "Id";
            ddlExamTimeToefl.DataBind();
          
        }
        //ddlExamTimeIELTS.DataSource = s.SetDropdownListCDB(49);
        //ddlExamTimeIELTS.DataTextField = "Date";
        //ddlExamTimeIELTS.DataValueField = "Id";
        //ddlExamTimeIELTS.DataBind();
        // Orientation Date
        ddlExamDateToeflOrt.DataSource = s.SetDropdownListCDB(78);
        ddlExamDateToeflOrt.DataTextField = "Date";
        ddlExamDateToeflOrt.DataValueField = "Id";
        ddlExamDateToeflOrt.DataBind();

        ddlExamTimeToeflOrt.DataSource = s.SetDropdownListCDB(79);
        ddlExamTimeToeflOrt.DataTextField = "Date";
        ddlExamTimeToeflOrt.DataValueField = "Id";
        ddlExamTimeToeflOrt.DataBind();

        //ddlExamDateIELTSOrt.DataSource = s.SetDropdownListCDB(80);
        //ddlExamDateIELTSOrt.DataTextField = "Date";
        //ddlExamDateIELTSOrt.DataValueField = "Id";
        //ddlExamDateIELTSOrt.DataBind();

        //ddlExamTimeIELTSOrt.DataSource = s.SetDropdownListCDB(81);
        //ddlExamTimeIELTSOrt.DataTextField = "Date";
        //ddlExamTimeIELTSOrt.DataValueField = "Id";
        //ddlExamTimeIELTSOrt.DataBind();
        // Ends Here
        //ddlMathEntranceExam.DataSource = s.SetDropdownListCDB(30);
        ddlMathEntranceExam.DataSource = s.SetDropdownListCDB(125);
        ddlMathEntranceExam.DataTextField = "Date";
        ddlMathEntranceExam.DataValueField = "Id";
        ddlMathEntranceExam.DataBind();

        ddlMathEntranceExam.SelectedIndex = 0;
       try

       {
            ddlMathEntranceExamTime.DataSource = s.SetDropdownListAsDegreeType(42, int.Parse(ddlMathEntranceExam.SelectedValue));
           ddlMathEntranceExamTime.DataTextField = "Date";
           ddlMathEntranceExamTime.DataValueField = "Id";
           ddlMathEntranceExamTime.DataBind();
       }
        catch
       {
        ddlMathEntranceExamTime.DataSource = s.SetDropdownListCDB(31);
        ddlMathEntranceExamTime.DataTextField = "Date";
        ddlMathEntranceExamTime.DataValueField = "Id";
        ddlMathEntranceExamTime.DataBind();
        }
        //ddlPolicy.DataSource = s.SetDropdownListCDB(33);
        //ddlPolicy.DataTextField = "Policy";
        //ddlPolicy.DataValueField = "Id";
        //ddlPolicy.DataBind();

        ddlCountryOfIssue.DataSource = s.SetDropdownListCDB(2);
        ddlCountryOfIssue.DataTextField = "NationalityName";
        ddlCountryOfIssue.DataValueField = "NationalityCode";
        ddlCountryOfIssue.DataBind();

        ddlPermanentCountry.DataSource = s.SetDropdownListCDB(2);
        ddlPermanentCountry.DataTextField = "NationalityName";
        ddlPermanentCountry.DataValueField = "NationalityCode";
        ddlPermanentCountry.DataBind();
        LoadUndertaking();

        ddlNameOfHostel.DataSource = s.SetDropdownListCDB(38);
        ddlNameOfHostel.DataTextField = "Hostel";
        ddlNameOfHostel.DataValueField = "Id";
        ddlNameOfHostel.DataBind();

        ddlReligionForUrgentVisa.DataSource = s.SetDropdownListCDB(2);
        ddlReligionForUrgentVisa.DataTextField = "NationalityName";
        ddlReligionForUrgentVisa.DataValueField = "NationalityCode";
        ddlReligionForUrgentVisa.DataBind();

        ddlQualification.DataSource = s.SetDropdownListAsDegreeType(12, int.Parse(ddlDegreeType.SelectedValue));
        ddlQualification.DataTextField = "AcadmicName";
        ddlQualification.DataValueField = "Id";
        ddlQualification.DataBind();

        ddlEntryType.DataSource = s.SetDropdownListCDB(70);
        ddlEntryType.DataTextField = "EntryType";
        ddlEntryType.DataValueField = "Id";
        ddlEntryType.DataBind();

        ddlUniversityName.DataSource = s.SetDropdownListCDB(76);
        ddlUniversityName.DataTextField = "Desc";
        ddlUniversityName.DataValueField = "Id";
        ddlUniversityName.DataBind();

        ddlPercentage.DataSource = s.SetDropdownListCDB(87);
        ddlPercentage.DataTextField = "FeeWaiverType";
        ddlPercentage.DataValueField = "FeeWaiverType";
        ddlPercentage.DataBind();

     

        //gvTransportRate.DataSource = s.SetDropdownListCDB(42);
        //gvTransportRate.DataBind();
           LoadBoardName();
        LoadSCSAcademicYear();
        LoadSCSTerm();
    }
    public void LoadSCSAcademicYear()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //ddlSCSAcademicYear.DataSource = s.GetYear();
        //ddlSCSAcademicYear.DataTextField = "TermYear";
        //ddlSCSAcademicYear.DataValueField = "YearId";
        //ddlSCSAcademicYear.DataBind();
    }

    public void LoadSCSTerm()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //ddlSCSTerm.DataSource = s.getTermName(Convert.ToString(ddlSCSAcademicYear.SelectedValue));
        //ddlSCSTerm.DataTextField = "TermName";
        //ddlSCSTerm.DataValueField = "TermId";
        //ddlSCSTerm.DataBind();
    }
    public void LoadBoardName()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlBoardName.DataSource = s.GetBoardName(0, "SELECTALL");
        ddlBoardName.DataTextField = "BoardName";
        ddlBoardName.DataValueField = "BoardId";
        ddlBoardName.DataBind();
        ddlBoardName.Items.Insert(0, new ListItem("SELECT"));
    }
    //Added by shihab on 29-Mar-2016
    public void LoadSHarjahHRD()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlHrdDepartment.DataSource = s.SetDropdownListCDB(112);
        ddlHrdDepartment.DataTextField = "SHJSubCategory";
        ddlHrdDepartment.DataValueField = "SHJ_HRDID";
        ddlHrdDepartment.DataBind();
    }



    
    public void LoadUndertaking()
    {
        if (ddlDegreeType.SelectedIndex != 0)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = new DataTable();
            string LinkId = "0";
            try
            {
                LinkId = Request.QueryString["Id"].ToString();
            }
            catch
            {
            }
            dt = s.GetUndertakingByDegree(LinkId);

            foreach (DataRow ro in dt.Rows)
            {
                lblAllUndertaking.Items.Add(ro["Undertaking"].ToString());
            }
            lblAllUndertaking.DataBind();
        }
    }
    byte[] ReadFile()
    {
        FileUpload img = (FileUpload)fuPhoto;
        Byte[] imgByte = null;
        if (img.HasFile && img.PostedFile != null)
        {
            //To create a PostedFile
            HttpPostedFile File = fuPhoto.PostedFile;
            //Create byte Array with file len
            imgByte = new Byte[File.ContentLength];
            //force the control to load data in array
            File.InputStream.Read(imgByte, 0, File.ContentLength);
        }
        else
        {
            HttpPostedFile File = fuPhoto.PostedFile;
            imgByte = new Byte[Convert.ToInt32(File.ContentLength)];
            File.InputStream.Read(imgByte, 0, File.ContentLength);
        }
        return imgByte;
    }
    public void ResetField()
    {

        ddlTransportation.SelectedIndex = 0;
        txtExaxtLocation.Text = "";
        txtChronicDisease.Text = "";
        rdbProgramRegular.Checked = true;
        txtDiscount.Text = "";
        ddlDiscountType.SelectedIndex = 0;
        ddlEmirateID.SelectedIndex = 0;
        txtFatherName.Text = "";
        txtFaxNo.Text = "";
        txtFees.Text = "";
        txtHandiCapped.Text = "";
        chkIsDisability.Checked = false;
        txtOffPhoneNo.Text = "";
        txtPermenentAddr1.Text = "";
        txtPermenentAddr2.Text = "";
        txtPermenentCity.Text = "";
        txtPlaceofBirth.Text = "";
        ddlPlaceofBirthNation.SelectedIndex = 0;
        txtPostBoxNo.Text = "";
        txtPresentAddr1.Text = "";
        txtPresentAddr2.Text = "";
        txtPresentCity.Text = "";
        txtResPhoneNo.Text = "";
        ddlShift.SelectedIndex = 0;
        ddlnextShift.SelectedIndex = 0;
        ddlStudentType.SelectedIndex = 0;
        ddlTerm.SelectedIndex = 0;
        txtTotalFees.Text = "";
        chkChronicBool.Checked = false;
        rdbHostelYes.Checked = false;
        rdbTransportationYes.Checked = false;
        ddlMaritalStatus.SelectedIndex = 0;
        chkMedicalCertificate.Checked = false;
        chkPoliceClearnece.Checked = false;
    }
    public void ResetLabel()
    {
        lblMesagGuardian.Text = "";
        lblMesagVisa.Text = "";
        lblMesagRemarks.Text = "";
        lblMesagExperience.Text = "";
        lblVisaInfoMesag.Text = "";
        lblMesagQualification.Text = "";
        lblMesagToefl.Text = "";
        lblMesagMath.Text = "";
        lblTransportaionMesag.Text = "";
        lblMesagHostel.Text = "";
        lblProgramMesag.Text = "";
        lblTOCMesag.Text = "";
        lblMesagProgram.Text = "";
        lblFitnessMsg.Text = "";
        lblMesagContact.Text = "";
        lblMHistory.Text = "";
    }
    protected void lnkFitness_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = true;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetFitness();
        ResetLabel();
    }
    protected void lnkFinance_Click(object sender, EventArgs e)
    {
       
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = true;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetPrograms();
        LoadCourse();
        ResetLabel();
        if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
        {
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ddlDiscountType.DataSource = s.SetDropdownListCDB(75);
                ddlDiscountType.DataTextField = "FeeWaiverType";
                ddlDiscountType.DataValueField = "Id";
                ddlDiscountType.DataBind();
                ddlType.DataSource = s.SetDropdownListCDB(74);
                ddlType.DataTextField = "FeeWaiverType";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();

               


            }
            catch
            {
            }
        }
        if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
        {
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ddlDiscountType.DataSource = s.SetDropdownListCDB(86);
                ddlDiscountType.DataTextField = "FeeWaiverType";
                ddlDiscountType.DataValueField = "Id";
                ddlDiscountType.DataBind();

                ddlType.DataSource = s.SetDropdownListCDB(94);
                ddlType.DataTextField = "FeeWaiverType";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();
            }
            catch
            {
            }
        }
        if (ddlDegreeType.SelectedValue != "9")
        {
            if (ddlTransferUniversity.SelectedItem.Text == "Yes")
            {
                try
                {
                    StudentRegistrationDAL s = new StudentRegistrationDAL();
                    ddlPercentage.DataSource = s.GetMouPercentagetoc(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlType.SelectedValue));
                    ddlPercentage.DataTextField = "FeeWaiverType";
                    ddlPercentage.DataValueField = "FeeWaiverType";
                    ddlPercentage.DataBind();

                }
                catch
                {
                    ddlPercentage.Items.Clear();
                    ddlPercentage.Items.Add(new ListItem("Select", "0"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                    ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                    ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                    ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                    ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                    ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                    ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));


                }
            }
        }



        if (ddlDegreeType.SelectedValue == "9")
        {
            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ddlDiscountType.DataSource = s.SetDropdownListCDB(96);
                ddlDiscountType.DataTextField = "FeeWaiverType";
                ddlDiscountType.DataValueField = "Id";
                ddlDiscountType.DataBind();

                ddlType.DataSource = s.SetDropdownListCDB(95);
                ddlType.DataTextField = "FeeWaiverType";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();

            }
            catch
            {
            }
        }
        if (ddlDegreeType.SelectedValue == "9")
        {
            try
            {
                ddlPercentage.Items.Clear();
                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                if (ddlType.SelectedValue != "134")
                {
                    ddlPercentage.Items.Add(new ListItem("5", "5"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                }
            }
            catch
            {
            }
        }
        
        SetFinance();

        try
        {
            if (Convert.ToString(ddlDiscountType.SelectedItem.Text).Contains("SHARJAH"))
            {
                pnl_show.Visible = true;
            }

            else
            {
                pnl_show.Visible = false;
            }


            if (Convert.ToString(ddlDiscountType.SelectedItem.Text).Contains("SHARJAH HRD"))
            {
                pnl_Hrd.Visible = true;
            }

            else
            {
                pnl_Hrd.Visible = false;
            }
        }
        catch
        {

        }

        btnAddNewVisa.Enabled = true;

        try
        {
            ddlPercentage_SelectedIndexChanged(sender, e);

        }
        catch
        {

        }
        //if (ddlTransferUniversity.SelectedValue == "Yes")
        //{
        //    try
        //    {
        //    StudentRegistrationDAL s = new StudentRegistrationDAL();
        //    int tococunt  = s.GetTOCAPPLICABLE((int.Parse(Request.QueryString["Id"].ToString()));
        //    if (tococunt!=0)
        //   {
        //    btnSaveFinance.Enabled = false;
        //    lblMesagProgram.Text = "Fee Waiver greater than 15 % is not allowed for TOC case!";
        //    return;
        //    }
        //    else
        //    {
        //     btnSaveFinance.Enabled = true;
        //    }
        //    }
        //    catch
        //    {
        //    }
        //}
        //else
        //{
        //    btnSaveFinance.Enabled = true;
        //    lblMesagProgram.Text = "";
        //}
        try
        {
            StudentRegistrationDAL ss = new StudentRegistrationDAL();
            DataTable dt = new DataTable();




            dt = ss.GetFinalFees(int.Parse(ddlCourseType.SelectedValue), ddlTerm.SelectedValue, Drpschool.SelectedValue);
            txtTotalFees.Text = (dt.Rows[0][0].ToString()).ToString();

        }
        catch
        {
        }
    }
    protected void lnkHostel_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = true;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
       
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetHostel();
        SetMedicalHitory();
        ResetLabel();
    }
    protected void lnkMediaSource_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = true;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        StudentRegistrationDAL s1 = new StudentRegistrationDAL();
        drpagent.DataSource = s1.SetDropdownListAsDegreeType(37, 0);
        drpagent.DataTextField = "Agencyname";
        drpagent.DataValueField = "Agentid";
        drpagent.DataBind();
        SetMediaSource();
        try
        {
            lbMediaSource_SelectedIndexChanged(sender, e);
        }
        catch
        {

        }
        SetMediaSource();
        ResetLabel();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Media = s.GetCMSMedia(Request.QueryString["Id"].ToString());
        if (Media != "")
        {
            txtCMSMedia.Visible = true;
            lblMedia.Visible = true;
            txtCMSMedia.Text = Media;
        }
    }
    protected void lnkAcademic_Click(object sender, EventArgs e)
    {
        pnlChalangeExam.Visible = false;
        btnAddQualification.Enabled = true;
        txtCGPA.Text = "";
        txtSpecilization.Text = "";
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = true;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetPrograms();
        LoadCourse();
        SetQualification();
        ResetLabel();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        string Status = s.GetRejectedStatus(Request.QueryString["Id"].ToString());
        if (Status.Trim() == "R")
            chkRejected.Checked = true;
    }
    protected void lnkContact_Click(object sender, EventArgs e)
    {
        try
        {
            pnlContact.Visible = true;
            pnlParents.Visible = false;
            pnlProgram.Visible = false;
            pnlTransport.Visible = false;
            pnlEntrance.Visible = false;
            pnlRemarks.Visible = false;
            pnlVisa.Visible = false;
            pnlExperience.Visible = false;
            PnlFitness.Visible = false;
            PnlHostelMain.Visible = false;
            PnlMediaSourceMain.Visible = false;
            PnlFinance.Visible = false;
            PnlQualification.Visible = false;
            PnlTocMain.Visible = false;
            PnlSkylineVisaMain.Visible = false;
            PnlUndertaking.Visible = false;
            pnlPrint.Visible = false;
            SetContact();
            ResetLabel();

            try
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ddlPlaceofBirthNation.SelectedValue = s.GetNationality(int.Parse(Request.QueryString["Id"].ToString()));
                ddlPlaceofBirthNation.Enabled = false;
                

            }
            catch
            {
                ddlPlaceofBirthNation.SelectedValue = Session["N"].ToString();
               // ddlPlaceofBirthNation.Enabled = false;
            }

            if (txtMobile.Text == "")
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                txtMobile.Text = s.GetMobile(int.Parse(Request.QueryString["Id"].ToString()));//Session["M"].ToString();
                txtEmail.Text = s.GetEmail(int.Parse(Request.QueryString["Id"].ToString())); //Session["E"].ToString();
               


            }

        }
        catch
        {
        }
    }
    protected void lnkParents_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = true;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetParents();
        ResetLabel();
        if (ddlStudentType.SelectedValue == "1")
        {
            PnlParrents.Visible = true;
        }
        else
        {
            PnlParrents.Visible = false;
        }
    }
    protected void lnkPrograms_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = true;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        pnlfoundation.Visible = false;
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            int Count = s.GetInterNationStudent(Request.QueryString["Id"].ToString());
            
            if (Count == 1)
            {
                DataTable dt = s.CheckSeats(int.Parse(ddlCourseType.SelectedValue), int.Parse(ddlTerm.SelectedValue), ddlShift.SelectedValue);
                int SeatCount = int.Parse(dt.Rows[0][0].ToString());
                if (SeatCount == 0)
                {
                    ddlShift.Enabled = false;
                    ddlShift.SelectedValue = "2";
                }
                else
                {
                   ddlShift.Enabled = false;
                    ddlShift.SelectedValue = "1";
                }
                if (ddlTerm.SelectedItem.Text.Contains("MAY") || ddlTerm.SelectedItem.Text.Contains("May"))
                    ddlShift.Enabled = true;


            }
            else
            {
                ddlShift.Enabled = true;
            }
            Drpschool.SelectedIndex = 0;
            Drpschool_SelectedIndexChanged(sender, e);
            SetPrograms();
            ResetLabel();

        }
        catch
        {
        }
        if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
        {
            chkMQPCourse.Visible = false;
        }
        else
        {
            chkMQPCourse.Visible = false;
        }
    }
    protected void lnkToc_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = true;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        ddlTransferUniversity_SelectedIndexChanged(sender, e);
        SetToc();
        ResetLabel();
        try
        {
            if (int.Parse(ddlDegreeType.SelectedValue) == 6 || int.Parse(ddlDegreeType.SelectedValue) == 8)
            {
                Chkmqptoc.Visible = true;

            }
            else
            {
                Chkmqptoc.Visible = false;
            }
        }
        catch
        {
        }
    }
    protected void lnkTransport_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = true;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetTransportation();
        ResetLabel();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        gvTransportRate.DataSource = s.SetDropdownListAsDegreeType(44, int.Parse(ddlTerm.SelectedValue));
        gvTransportRate.DataBind();
    }
    protected void lnkSkylineVisa_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = true;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetSkylineVisa();
        ResetLabel();
        if (txtRelationShip.Text.StartsWith("F"))
        {
            if (txtFatherNameForVisa.Text == "")
            {
                txtFatherNameForVisa.Text = txtFatherName.Text;
            }
        }
        if (txtRelationShip.Text.StartsWith("M"))
        {
            if (txtMotherName.Text == "")
            {
                txtMotherName.Text = txtFatherName.Text;
            }
        }
        if (txtAbroadResNo.Text == "")
        {
            txtAbroadResNo.Text = txtResPhone.Text;
        }
        if (txtAbroadMobileNo.Text == "")
        {
            txtAbroadMobileNo.Text = txtMobileGuardian.Text;
        }
        if (txtAddress1Local.Text == "")
        {
            txtAddress1Local.Text = txtAddress.Text;
        }
    }
    protected void lnkVisa_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = true;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlCountryOfIssue.DataSource = s.SetDropdownListCDB(2);
        ddlCountryOfIssue.DataTextField = "NationalityName";
        ddlCountryOfIssue.DataValueField = "NationalityCode";
        ddlCountryOfIssue.DataBind();

        SetVisa();
        ResetLabel();
    }
    protected void lnkExperience_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = true;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetExperience();
        ResetLabel();
    }
    protected void lnkEntrance_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = true;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetToefl();
        SetMath();
        ResetLabel();
        CheckConditionForExamDate();

        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlEntryType.DataSource = s.SetDropdownListCDB(70);
        ddlEntryType.DataTextField = "EntryType";
        ddlEntryType.DataValueField = "Id";
        ddlEntryType.DataBind();
        //try
        //{

        //    StudentRegistrationDAL s1 = new StudentRegistrationDAL();
        //    ddlMathEntranceExam.DataSource = s1.SetDropdownListCDB(30);
        //    ddlMathEntranceExam.DataTextField = "Date";
        //    ddlMathEntranceExam.DataValueField = "Id";
        //    ddlMathEntranceExam.DataBind();

        //}

        //catch
        //{

        //}

       
        int Count = s.GetEntranceResult(Request.QueryString["Id"].ToString());
        if (Count != 0)
        {
            lblResultMessage.Text = "Result Published";
        }
        else
        {
            lblResultMessage.Text = "";
        }
        if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
        {
            pnlHideEntrance.Visible = false;
        }
        else
        {
            pnlHideEntrance.Visible = true;
        }
        try
        {
            if (ddlTestType.SelectedValue == "7")
            {
                pnlemsat.Visible = true;
            }
            else
                pnlemsat.Visible = false;
        }
            catch
        {

            }
    }
    public void CheckConditionForExamDate()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            string ptype = "T";
            try
            {
                if (drpentrancetesttype.SelectedValue == "1")
                    ptype = "T";
                if (drpentrancetesttype.SelectedValue == "2")
                    ptype = "I";
                if (drpentrancetesttype.SelectedValue == "3")
                    ptype = "IB";
                if (drpentrancetesttype.SelectedValue == "4")
                    ptype = "CA";
                if (drpentrancetesttype.SelectedValue == "5")
                    ptype = "PE";
                if (drpentrancetesttype.SelectedValue == "6")
                    ptype = "CG";
                if (drpentrancetesttype.SelectedValue == "11")
                    ptype = "IE";

            }
            catch
            {
               
                // ptype = "T";
            }

            try
            {
                DataSet ds = s.GetEntranceDateCondition(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlShift.SelectedValue), int.Parse(Request.QueryString["Id"].ToString()), ptype);
                ddlExamDateToefl.DataSource = ds.Tables[0];
                ddlExamDateToefl.DataTextField = "Date";
                ddlExamDateToefl.DataValueField = "Id";
                ddlExamDateToefl.DataBind();
                ddlExamDateToefl.SelectedIndex = 0;
            }
            catch(Exception ex)
            {

            }
            try
            {

                ddlExamTimeToefl.DataSource = s.SetDropdownListAsDegreeType(41, int.Parse(ddlExamDateToefl.SelectedValue));
                ddlExamTimeToefl.DataTextField = "Date";
                ddlExamTimeToefl.DataValueField = "Id";
                ddlExamTimeToefl.DataBind();


            }

            catch
            {
                ddlExamTimeToefl.DataSource = s.SetDropdownListCDB(32);
                ddlExamTimeToefl.DataTextField = "Date";
                ddlExamTimeToefl.DataValueField = "Id";
                ddlExamTimeToefl.DataBind();

            }










            //DataSet ds = s.GetEntranceDateCondition(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlShift.SelectedValue), int.Parse(Request.QueryString["Id"].ToString()), "T");
            //ddlExamDateToefl.DataSource = ds.Tables[0];
            //ddlExamDateToefl.DataTextField = "Date";
            //ddlExamDateToefl.DataValueField = "Id";
            //ddlExamDateToefl.DataBind();

           // DataSet ds1 = s.GetEntranceDateCondition(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlShift.SelectedValue), int.Parse(Request.QueryString["Id"].ToString()), "I");

            try
            {
                DataSet ds1 = s.GetEntranceDateCondition(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlShift.SelectedValue), int.Parse(Request.QueryString["Id"].ToString()), "M");
                ddlMathEntranceExam.DataSource = ds1.Tables[0];
                ddlMathEntranceExam.DataTextField = "Date";
                ddlMathEntranceExam.DataValueField = "Id";
                ddlMathEntranceExam.DataBind();
            }
            catch
            {
                StudentRegistrationDAL s1 = new StudentRegistrationDAL();
                ddlMathEntranceExam.DataSource = s1.SetDropdownListCDB(30);
                ddlMathEntranceExam.DataTextField = "Date";
                ddlMathEntranceExam.DataValueField = "Id";
                ddlMathEntranceExam.DataBind();

            }

            try
            {
                ddlMathEntranceExamTime.DataSource = s.SetDropdownListAsDegreeType(42, int.Parse(ddlMathEntranceExam.SelectedValue));
                ddlMathEntranceExamTime.DataTextField = "Date";
                ddlMathEntranceExamTime.DataValueField = "Id";
                ddlMathEntranceExamTime.DataBind();
            }
            catch
            {
                ddlMathEntranceExamTime.DataSource = s.SetDropdownListCDB(31);
                ddlMathEntranceExamTime.DataTextField = "Date";
                ddlMathEntranceExamTime.DataValueField = "Id";
                ddlMathEntranceExamTime.DataBind();
            }




        }
        catch
        {
        }
    }
    protected void lnkRemarks_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = true;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = false;
        SetRemarks();
        ResetLabel();
    }
    protected void lnkUnderTaking_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = true;
        pnlPrint.Visible = false;
        ResetLabel();
        SetUndertaking();
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        pnlContact.Visible = false;
        pnlParents.Visible = false;
        pnlProgram.Visible = false;
        pnlTransport.Visible = false;
        pnlEntrance.Visible = false;
        pnlRemarks.Visible = false;
        pnlVisa.Visible = false;
        pnlExperience.Visible = false;
        PnlFitness.Visible = false;
        PnlHostelMain.Visible = false;
        PnlMediaSourceMain.Visible = false;
        PnlFinance.Visible = false;
        PnlQualification.Visible = false;
        PnlTocMain.Visible = false;
        PnlSkylineVisaMain.Visible = false;
        PnlUndertaking.Visible = false;
        pnlPrint.Visible = true;
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        int Count = s.GetisFinalized(Request.QueryString["Id"].ToString());
        string Status = s.GetRejectedStatus(Request.QueryString["Id"].ToString());

        if (Status.Trim() == "R")
            chkRejected.Checked = true;
        if (Count == 0)
        {
            if (chkRejected.Checked == true)
            {
                btnFinalize.Visible = false;
            }
            else
            {
                btnFinalize.Visible = true;
            }
            //btnFinalize.Visible = true;
            pnlPrintGrid.Visible = false;
        }
        else
        {
            btnFinalize.Visible = false;
            pnlPrintGrid.Visible = true;
            FillGridView1(int.Parse(Request.QueryString["Id"].ToString()));
        }


        try
        {
            DataTable dd=s.InsertAirticket_Eligible(Request.QueryString["Id"].ToString(),"Select");
            lblairstatus.Text = dd.Rows[0][0].ToString();
        }
        catch
        {

        }
        txtFileNumber.ReadOnly = true;
        txtFileNumber.Text = s.GetFileNo(Request.QueryString["Id"].ToString());
        if (txtFileNumber.Text == "")
        {
            txtFileNumber.Text = s.GetFileNoMax();
            btnAddFileNumber.Enabled = true;
        }
        else
        {
            btnAddFileNumber.Enabled = false;
        }
        ResetLabel();
    }
    protected void chkIsDisability_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsDisability.Checked == true)
            txtHandiCapped.Enabled = true;
        else
            txtHandiCapped.Enabled = false;
    }
    protected void chkChronicBool_CheckedChanged(object sender, EventArgs e)
    {
        if (chkChronicBool.Checked == true)
            txtChronicDisease.Enabled = true;
        else
            txtChronicDisease.Enabled = false;
    }
    protected void btnAddParents_Click(object sender, EventArgs e)
    {
        // New Changes 21-05-2013
        if (ddlStudentType.SelectedValue == "1")
        {
            if (txtFatherName.Text == "")
            {
                lblMesagGuardian.Text = "Father Name required!";
                return;
            }
            if (txtMobileGuardian.Text == "")
            {
                lblMesagGuardian.Text = "Mobile No required!";
                return;
            }
            if (txtResPhone.Text == "")
            {
                lblMesagGuardian.Text = "Residence Ph No required!";
                return;
            }
        }
        // New Changes 21-05-2013
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertParents(LinkId, txtFatherName.Text, txtRelationShip.Text, txtProfession.Text, txtOrganization.Text, txtEmailGuardian.Text, txtMobileGuardian.Text,
                txtResPhone.Text, txtOffPhone.Text, txtAddress.Text, txtWebsite.Text, txtPName.Text, txtPRelationShip.Text, txtPProfession.Text, txtPOrganization.Text, txtPEmailParents.Text,
                txtPMobileParents.Text, txtPResPhone.Text, txtPOfficePhone.Text, txtAddressParents.Text, txtPWebsite.Text);
            lblMesagGuardian.Text = "Successfully Updated!!!";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
            //txtFatherName.Text = "";
            //txtRelationShip.Text = "";
            //txtProfession.Text = "";
            //txtOrganization.Text = "";
            //txtEmailGuardian.Text = "";
            //txtMobileGuardian.Text = "";
            //txtResPhone.Text = "";
            //txtOffPhone.Text = "";
            //txtAddress.Text = "";
            //txtWebsite.Text = "";
            //txtPName.Text = "";
            //txtPRelationShip.Text = "";
            //txtPProfession.Text = "";
            //txtPOrganization.Text = "";
            //txtPEmailParents.Text = "";
            //txtPMobileParents.Text = "";
            //txtPResPhone.Text = "";
            //txtPOfficePhone.Text = "";
            //txtAddressParents.Text = "";
            //txtPWebsite.Text = "";
        }
        catch
        {
            lblMesagGuardian.Text = "Please Try Again!!!";
        }
    }
    protected void btnAddNewVisa_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string StudentStatus = "In Side Nigeria.";
            string VisaType = "Visit Visa";
            if (rdbTransit.Checked == true)
                VisaType = "Transit Visa";
            else if (rdbResidence.Checked == true)
                VisaType = "Residence Visa";
            if (rdbOutSide.Checked == true)
            {
                StudentStatus = "Out Side Nigeria.";
                VisaType = "SUN Visa";
            }
            DateTime dt = new DateTime();
            if (rdbInside.Checked == true)
            {
                try
                {
                    dt = DateTime.Parse(txtVisaExpireOnYear.Text + "/" + txtVisaExpireOnMonth.Text + "/" + txtVisaExpireOnDate.Text);
                }
                catch
                {
                    lblMesagVisa.Text = "Please check VISA expire on date!!!";
                    lblMesagVisa.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                dt = DateTime.Parse("1960/01/01");
            }
            try
            {
                DateTime date1 = DateTime.Parse(txtDateOfLastEntryYear.Text + "/" + txtDateOfLastEntryMonth.Text + "/" + txtDateOfLastEntryDate.Text);
                DateTime date2 = DateTime.Parse(txtGuardianPassportValidityYear.Text + "/" + txtGuardianPassportValidityMonth.Text + "/" + txtGuardianPassportValidityDate.Text);
            }
            catch
            {
                lblMesagVisa.Text = "Please check date!!!";
                lblMesagVisa.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string fileName1 = "";
            if (fuNationalId.PostedFile != null && fuNationalId.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuNationalId.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuNationalId.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }


            string fileName2 = "";
            if (fuVisaPage.PostedFile != null && fuVisaPage.PostedFile.ContentLength > 0)
            {
                fileName2 = Path.GetFileName(fuVisaPage.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuVisaPage.PostedFile.SaveAs(Path.Combine(folder, fileName2));
            }


            string fileName3 = "";
            if (fuTenancyContract.PostedFile != null && fuTenancyContract.PostedFile.ContentLength > 0)
            {
                fileName3 = Path.GetFileName(fuTenancyContract.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuTenancyContract.PostedFile.SaveAs(Path.Combine(folder, fileName3));
            }
            DateTime PortDate;
            if (ddlPortOflastentry.SelectedIndex == 0)
            {
                lblMesagVisa.Text = "Port of Last entry Required!!!";
                lblMesagVisa.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlPortOflastentry.SelectedItem.Text == "None")
            {
                PortDate = DateTime.Parse("1990/01/01");
            }
            else
                PortDate = DateTime.Parse(txtDateOfLastEntryYear.Text + "/" + txtDateOfLastEntryMonth.Text + "/" + txtDateOfLastEntryDate.Text);
           
               StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertVisa(LinkId, rdbSkylineVisaYes.Checked, RadioButton1.Checked, StudentStatus, VisaType, dt,
                rdbUrgentVisaYes.Checked, txtFatherNameForVisa.Text, txtAbroadMobileNo.Text, txtAbroadResNo.Text, txtMotherName.Text, txtPlaceOfBirthUrgentVisa.Text, ddlReligionForUrgentVisa.SelectedValue,
                txtPlaceOfBirthPlace.Text, ddlMaritialStatus.SelectedValue, ddlPortOflastentry.SelectedValue, ddlPreviousNationality.SelectedValue, PortDate,
                txtReligion.Text, txtSpokenLanguage.Text, txtNativeLanguage.Text, txtAddress1Local.Text, txtAddress2Local.Text, txtGuardianPostalAddress.Text, txtOfficeAddress.Text,
                txtCityLocal.Text, txtStateLocal.Text, ddlEmirates.SelectedValue, ddlNationalityForLocalGuardian.SelectedValue, txtGuardianPassportNo.Text, DateTime.Parse(txtGuardianPassportValidityYear.Text+"/"+txtGuardianPassportValidityMonth.Text+"/"+txtGuardianPassportValidityDate.Text).ToShortDateString(),
                txtGuardianVisaStatus.Text, txtNationalIdLocal.Text, fileName1, txtVisaPage.Text, fileName2, txtVisa.Text, fileName3, txtGuardianVisaNo.Text, txtGuardianNameOfSponsor.Text);
            lblMesagVisa.Text = "Sucessfully Updated!!!";
            lblMesagVisa.ForeColor = System.Drawing.Color.Blue;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
            //txtVisaExpireOnYear.Text = "";
            //txtVisaExpireOnMonth.Text = "";
            //txtVisaExpireOnDate.Text = "";
            //txtFatherNameForVisa.Text = "";
            //txtAbroadMobileNo.Text = "";
            //txtAbroadResNo.Text = "";
            //txtMotherName.Text = "";
            //txtPlaceOfBirthUrgentVisa.Text = "";
            //txtReligionForUrgentVisa.Text = "";
            //txtPlaceOfBirthPlace.Text = "";
            //ddlMaritialStatus.SelectedIndex = 0;
            //ddlPortOflastentry.SelectedIndex = 0;
            //ddlPreviousNationality.SelectedIndex = 0;
            //txtDateOfLastEntryYear.Text = "";
            //txtDateOfLastEntryMonth.Text = "";
            //txtDateOfLastEntryDate.Text = "";
            //txtReligion.Text = "";
            //txtSpokenLanguage.Text = "";
            //txtNativeLanguage.Text = "";
            //txtAddress1Local.Text = "";
            //txtAddress2Local.Text = "";
            //txtGuardianPostalAddress.Text = "";
            //txtOfficeAddress.Text = "";
            //txtCityLocal.Text = "";
            //txtStateLocal.Text = "";
            //ddlEmirates.SelectedIndex = 0;
            //ddlNationalityForLocalGuardian.SelectedIndex = 0;
            //txtGuardianPassportNo.Text = "";
            //txtGuardianPassportValidity.Text = "";
            //txtGuardianVisaStatus.Text = "";
            //txtNationalIdLocal.Text = "";
            //txtVisaPage.Text = "";
            //txtVisa.Text = "";
            //txtGuardianVisaNo.Text = "";
            //txtGuardianNameOfSponsor.Text = "";
        }
        catch
        {
            lblMesagVisa.Text = "Please Try Again!!!"; 
            lblMesagVisa.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnDeleteNewVisa_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.DeleteTable(int.Parse(LinkId), 4);
            lblMesagVisa.Text = "Sucessfully Deleted!!!";
            lblMesagVisa.ForeColor = System.Drawing.Color.Blue;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
            txtVisaExpireOnYear.Text = "";
            txtVisaExpireOnMonth.Text = "";
            txtVisaExpireOnDate.Text = "";
            txtFatherNameForVisa.Text = "";
            txtAbroadMobileNo.Text = "";
            txtAbroadResNo.Text = "";
            txtMotherName.Text = "";
            txtPlaceOfBirthUrgentVisa.Text = "";
            txtPlaceOfBirthPlace.Text = "";
            ddlMaritialStatus.SelectedIndex = 0;
            ddlPortOflastentry.SelectedIndex = 0;
            ddlPreviousNationality.SelectedIndex = 0;
            txtDateOfLastEntryYear.Text = "";
            txtDateOfLastEntryMonth.Text = "";
            txtDateOfLastEntryDate.Text = "";
            txtReligion.Text = "";
            txtSpokenLanguage.Text = "";
            txtNativeLanguage.Text = "";
            txtAddress1Local.Text = "";
            txtAddress2Local.Text = "";
            txtGuardianPostalAddress.Text = "";
            txtOfficeAddress.Text = "";
            txtCityLocal.Text = "";
            txtStateLocal.Text = "";
            ddlEmirates.SelectedIndex = 0;
            ddlNationalityForLocalGuardian.SelectedIndex = 0;
            txtGuardianPassportNo.Text = "";
            txtGuardianVisaStatus.Text = "";
            txtNationalIdLocal.Text = "";
            txtVisaPage.Text = "";
            txtVisa.Text = "";
            txtGuardianVisaNo.Text = "";
            txtGuardianNameOfSponsor.Text = "";
        }
        catch
        {
            lblMesagVisa.Text = "Please Try Again!!!";
            lblMesagVisa.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnAddRemarks_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            DataSet dt = new DataSet();
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            dt = d.SetRemarks(int.Parse(Request.QueryString["Id"].ToString()));
            foreach (DataRow ro in dt.Tables[0].Rows)
            {
                if (ddlRemarksType.SelectedValue == ro["RemarksType"].ToString())
                {
                    lblMesagRemarks.Text = "This remarks type is already exists!!!";
                    lblMesagRemarks.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            string Result = d.InsertRemarks(LinkId, ddlRemarksType.SelectedValue, txtDetailsRemarks.Text);
            lblMesagRemarks.Text = "Sucessfully Added!!!";
            lblMesagRemarks.ForeColor = System.Drawing.Color.Blue;
            SetRemarks();
            ddlRemarksType.SelectedIndex = 0;
            txtDetailsRemarks.Text = ""; 
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagRemarks.Text = "Please Try Again!!!";
            lblMesagRemarks.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnAddExperience_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string TillMonth = DateTime.Now.Month.ToString();
            string TillYear = DateTime.Now.Year.ToString();
            if (ddlToMonth.SelectedItem.Text != "Till Date")
            {
                TillMonth = ddlToMonth.SelectedItem.Text;
                TillYear = ddlToYear.SelectedItem.Text;
            }
            if (DateTime.Parse(TillYear + "/" + TillMonth + "/1") < DateTime.Parse(ddlFromYear.SelectedItem.Text + "/" + ddlFromMonth.SelectedItem.Text + "/1"))
            {
                lblMesagExperience.Text = "To date should be greater than from date!!!";
                lblMesagExperience.ForeColor = System.Drawing.Color.Red;
                return;
            }

            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertExperience(LinkId, rdbWorking.Checked, txtOrganizations.Text, txtDesignation.Text, txtLocationForExperience.Text, txtCityForExperience.Text,
                    ddlJobSector.SelectedValue, ddlTypeOfJob.SelectedValue, txtJobProfile.Text, ddlFromMonth.SelectedValue, ddlFromYear.SelectedValue, ddlToMonth.SelectedValue, ddlToYear.SelectedValue);
            lblMesagExperience.Text = "Successfully Added!!!";
            lblMesagExperience.ForeColor = System.Drawing.Color.Blue;
            SetExperience();
            txtOrganizations.Text = "";
            txtDesignation.Text = "";
            txtLocationForExperience.Text = "";
            txtCityForExperience.Text = "";
            ddlJobSector.SelectedIndex = 0;
            ddlTypeOfJob.SelectedIndex = 0;
            txtJobProfile.Text = "";
            ddlFromMonth.SelectedIndex = 0;
            ddlFromYear.SelectedIndex = 0;
            ddlToMonth.SelectedIndex = 0;
            ddlToYear.SelectedIndex = 0;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagExperience.Text = "Please Try Again!!!";
            lblMesagExperience.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnAddVisaInfo_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            DateTime dt;
            try
            {
                dt = DateTime.Parse(txtFollowYear.Text + "/" + txtFollowMonth.Text + "/" + txtFollowDate.Text);
            }
            catch
            {
                dt = DateTime.Now;
            }
            DateTime dt1;
            try
            {
                dt1 = DateTime.Parse(txtYear.Text + "/" + txtMonth.Text + "/" + txtDate.Text);
            }
            catch
            {
                dt1 = DateTime.Now;
            }
            string fileName1 = "";
            if (fuTocDocument.PostedFile != null && fuTocDocument.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuTocDocument.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuTocDocument.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            if (ddlVisaType.SelectedValue != "1")
            {
                if (DateTime.Parse(txtIssueYear.Text + "/" + txtIssueMonth.Text + "/" + txtIssueDate.Text) > DateTime.Parse(txtExpireYear.Text + "/" + txtExpireMonth.Text + "/" + txtExpireDate.Text))
                {
                    lblVisaInfoMesag.Text = "Expiry date should be greater than Issue date!!!";
                    lblVisaInfoMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                dt = DateTime.Parse(txtIssueYear.Text + "/" + txtIssueMonth.Text + "/" + txtIssueDate.Text);
            }
            else
            {
                dt = DateTime.Now;
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertVisaInfo(LinkId, ddlVisaType.SelectedItem.Text, txtTypeofvisa.Text, txtSponsor.Text, txtCardNo.Text, txtPlaceOfIssue.Text, dt,
                DateTime.Parse(txtExpireYear.Text + "/" + txtExpireMonth.Text + "/" + txtExpireDate.Text), ddlCountryOfIssue.SelectedValue, fileName1);
            lblVisaInfoMesag.Text = "Successfully Added!!!";
            lblVisaInfoMesag.ForeColor = System.Drawing.Color.Blue;
            SetVisa();
            ddlVisaType.SelectedIndex = 0;
            txtTypeofvisa.Text = "";
            txtSponsor.Text = "";
            txtCardNo.Text = "";
            txtPlaceOfIssue.Text = "";
            txtIssueYear.Text = "";
            txtIssueMonth.Text = "";
            txtIssueDate.Text = "";
            txtExpireYear.Text = "";
            txtExpireMonth.Text = "";
            txtExpireDate.Text = "";
            ddlCountryOfIssue.SelectedIndex = 0; 
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblVisaInfoMesag.Text = "Please Try Again!!!";
            lblVisaInfoMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnAddQualification_Click(object sender, EventArgs e)
    {
        lblMesagQualification.Text = "";
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            if (ddlBachelorDegree.Enabled == true && ddlBachelorDegree.SelectedIndex == 0)
            {
                lblMesagQualification.Text = "Bachelor Degree is Required!";
                return;
            }
            string fileName1 = "";
            if (fuQualification.PostedFile != null && fuQualification.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuQualification.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuQualification.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Bacheclor = ddlBachelorDegree.SelectedValue;

            try
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")


                {

                    DataTable dt2 = s.GetMilitaryReqmet(Request.QueryString["Id"].ToString(), ddlYearOfPassing.SelectedItem.Text);
                    if (dt2.Rows.Count != 0)
                    {
                        if (int.Parse(dt2.Rows[0][1].ToString()) == 1)
                        {
                            
                            DataTable dt1 = s.GetMilitaryReq(Request.QueryString["Id"].ToString(), ddlYearOfPassing.SelectedItem.Text);
                            if (dt1.Rows.Count != 0)
                            {
                                if (int.Parse(dt1.Rows[0][1].ToString()) == 1)
                                {

                                    if (Chkmilitary.Checked == false)
                                    {
                                        lblMesagQualification.Text = "Please Check the option  Clearance from Military and Upload documents";
                                        lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                                        pnlmilitary.Visible = true;
                                        return;
                                    }

                                    else if (Chkmilitary.Checked == true)
                                    {
                                        if (fuQualification.HasFile == false)
                                        {
                                            lblMesagQualification.Text = "Please upload documents for Clearance from Military";
                                            lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                                            pnlmilitary.Visible = true;
                                            return;

                                        }
                                    }
                                }
                                else
                                {
                                    pnlmilitary.Visible = false;
                                }

                            }
                        }
                    }
                    else
                    {
                        pnlmilitary.Visible = false;
                    }

                }
            }

            catch
            {
                lblMesagQualification.Text = "Please Try again";
                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                return;
            }
            

            if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
                Bacheclor = ddlQualification.SelectedValue;
            if (txtSubjects.Text == "")
                txtSubjects.Text = "0";
            DataTable dt = s.GetCGPA(Request.QueryString["Id"].ToString(), Bacheclor, decimal.Parse(txtCGPA.Text), txtPercentage.Text, txtSubjects.Text, ddlYearOfPassing.SelectedItem.Text, int.Parse(ddlCourseFOrQualification.SelectedValue));
            if (dt.Rows.Count != 0)
            {
                lblMesagQualification.Text = dt.Rows[0][2].ToString();
                if (int.Parse(dt.Rows[0][1].ToString()) == 1)
                {
                    btnAddQualification.Enabled = false;
                    lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                    if (chkRejected.Checked == false)
                    {
                        if (chkSpecialApproval.Checked == false)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (txtRemarksQualification.Text == "")
                        {
                            lblMesagQualification.Text = "Remarks Required!";
                            return;
                        }
                        else
                        {
                            btnAddQualification.Enabled = true;
                        }
                    }
                    if (chkSpecialApproval.Checked == true)
                    {
                        if (txtRemarksQualification.Text == "")
                        {
                            lblMesagQualification.Text = "Remarks Required!";
                            return;
                        }
                        else
                        {
                            btnAddQualification.Enabled = true;
                        }
                    }
                }
                else
                {
                    btnAddQualification.Enabled = true;
                    lblMesagQualification.ForeColor = System.Drawing.Color.Blue;
                }
            }

            StudentRegistrationDAL d = new StudentRegistrationDAL();
            if (chkRejected.Checked == true)
            {
                d.UpdateRejectedStudent(LinkId);
                btnFinalize.Enabled = false;
            }
            else
            {
                btnFinalize.Enabled = true;
            }
            if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
            {
                if (ddlQualification.SelectedItem.Text == "High School Certificate" || ddlQualification.SelectedItem.Text == "Higher National Diploma" || ddlQualification.SelectedItem.Text == "12th Standard from UAE Secondary School Certificate" || ddlQualification.SelectedItem.Text == "12th Standard from Private Institution in the UAE" || ddlQualification.SelectedItem.Text == "12th Standard from Abroad")
                {

                }
                else
                {
                    if (d.GetQualification(LinkId, 1) == "0")
                    {
                        lblMesagQualification.Text = "12th Standard Certificate or Higher School Certificate or Higher National Diploma is mandatory!";
                        return;
                    }
                }
            } 
            if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
            {
                if (ddlQualification.SelectedItem.Text == "Bachelor Degree")
                {

                }
                else
                {
                    if (d.GetQualification(LinkId, 6) == "0")
                    {
                        lblMesagQualification.Text = "Bachelor Degree is mandatory";
                        return;
                    }
                }
            }
            if (txtCGPA.Text == "")
                txtCGPA.Text = "0";
            if(int.Parse(ddlYearOfPassing.SelectedItem.Text)>DateTime.Now.Year)
            {
                lblMesagQualification.Text = "Year of passing should not greater than current year!!!";
                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                return;
            }
            DateTime dob = s.GetDOB(Request.QueryString["Id"].ToString()); 
            int YOP = dob.AddYears(16).Year;
            if (int.Parse(ddlYearOfPassing.SelectedItem.Text) < YOP)
            {
                lblMesagQualification.Text = "Year of passing should not greater than Date of Birth!!!";
                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (int.Parse(ddlQualification.SelectedValue) == 6)
            {
                int Year = s.GetBachelorDegreeYear(Request.QueryString["Id"].ToString());
                if (Year <= int.Parse(ddlYearOfPassing.SelectedValue))
                {
                    lblMesagQualification.Text = "Year of passing should not greater than Bachelor Degree Passed Year!!!";
                    lblMesagQualification.ForeColor = System.Drawing.Color.Red; 
                    return;
                }
            }
            txtBoardName.Text = ddlBoardName.SelectedItem.Text;
            string Result = d.InsertQualification(LinkId, ddlQualification.SelectedItem.Text, txtSpecilization.Text, txtUniversityName.Text, txtBoardName.Text, txtCity.Text, ddlCountry.SelectedValue, ddlYearOfPassing.SelectedValue, txtPercentage.Text, ddlBachelorDegree.SelectedValue, ddlCourseFOrQualification.SelectedValue, chkCertificateSubmitted.Checked, decimal.Parse(txtCGPA.Text), txtSubjects.Text, chkSpecialApproval.Checked, txtRemarksQualification.Text, fileName1, Chkmilitary.Checked);
            try
            {
                if (ddlCourseFOrQualification.SelectedValue == "3")
                {
                    Result = d.InsertMQPSubjectQ(LinkId, chkMqp11.Checked, chkMqp12.Checked, chkMqp13.Checked, chkMqp14.Checked, chkMqp15.Checked, chkMqp16.Checked, chkMqp17.Checked, ddlMqpDate11.SelectedItem.Text, ddlMqpDate12.SelectedItem.Text, ddlMqpDate13.SelectedItem.Text, ddlMqpDate14.SelectedItem.Text, ddlMqpDate15.SelectedItem.Text, ddlMqpDate16.SelectedItem.Text, ddlMqpDate17.SelectedItem.Text, ddlMqpTime11.SelectedItem.Text, ddlMqpTime12.SelectedItem.Text, ddlMqpTime13.SelectedItem.Text, ddlMqpTime14.SelectedItem.Text, ddlMqpTime15.SelectedItem.Text, ddlMqpTime16.SelectedItem.Text, ddlMqpTime17.SelectedItem.Text, int.Parse(Session["EmpId"].ToString()));
                }
                else
                {
                    s.InsertOtherQualification(LinkId, int.Parse(ddlChalangeExamDate.SelectedValue), int.Parse(ddlChalangeExamTime.SelectedValue));

                }
            }
            catch
            {
            }
            lblMesagQualification.Text = "Seccessfully Added!!!";
            lblMesagQualification.ForeColor = System.Drawing.Color.Blue;
            SetQualification();
            ddlQualification.SelectedIndex = 0;
            txtSpecilization.Text = "";
            txtUniversityName.Text = "";
            txtBoardName.Text = "";
            txtCity.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlYearOfPassing.SelectedIndex = 0;
            txtPercentage.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagQualification.Text = "Please Try Again!!!";
            lblMesagQualification.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnSubmitTOEFL_Click(object sender, EventArgs e)
    {       
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            //if (rdbHavingToeflNo.Checked == true)
            //{
            //    if (rdbTofel.Checked == true && rdbIelts.Checked == true)
            //    {
            //        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
            //        lblMesagToefl.Text = "Please Select TOEFL or IELTS";
            //        return;
            //    }
            //}
            
                if (rdbHavingToeflNo.Checked == true)
                {

                    if (drpentrancetesttype.SelectedValue == "0")
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Select TOEFL or IELTS";
                        return;
                    }
                }

                else
                {
                    if (ddlTestType.SelectedIndex == 0)
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Select Test Type";
                        return;
                    }

                    if (ddlTestType.SelectedValue == "7")
                    {

                        if (txtEnglishMark.Text == "")
                        {
                            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                            lblMesagToefl.Text = "Please Select EMSAT range";
                            return;
                        }
                        if (drpemsat.SelectedIndex == -1)
                        {
                            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                            lblMesagToefl.Text = "Please Select EMSAT range";
                            return;
                        }

                    }

                    try
                    {
                        DateTime dt = DateTime.Parse(txtExamPassedOnYear.Text + "/" + txtExamPassedOnMonth.Text + "/" + txtExamPassedOnDate.Text);
                    }
                    catch
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Check Date";
                        return;
                    }
                }
                if ((ddlTestType.SelectedIndex != 0) & (rdbHavingToeflYes.Checked == true))
                {
                    if (ddlEntryType.SelectedIndex == 0)
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Select Entry Type";
                        return;
                    }
                    try
                    {
                        txtEnglish_TextChanged(sender, e);
                    }
                    catch
                    {

                    }


                }
                string ResultSubmit = "No";
                if (rdbResultSubmit.Checked == true)
                    ResultSubmit = "Yes";
                string fileName = "";
                // Check to see if a file was actually selected
                if (fuResult.PostedFile != null && fuResult.PostedFile.ContentLength > 0)
                {
                    // Get the filename and folder to write to
                    fileName = Path.GetFileName(fuResult.PostedFile.FileName);
                    string folder = Server.MapPath("~/Documents/" + LinkId + "/");

                    // Ensure the folder exists
                    Directory.CreateDirectory(folder);

                    // Save the file to the folder
                    fuResult.PostedFile.SaveAs(Path.Combine(folder, fileName));
                }

                StudentRegistrationDAL d = new StudentRegistrationDAL();
                bool outsidesuc;
                if (rdosucoutside.SelectedValue == "1")
                { outsidesuc = true; }
                else
                { outsidesuc = false; }

                string Result = d.InsertToefl(LinkId, rdbNativeEnglishYes.Checked, rdbHavingToeflNo.Checked, int.Parse(drpentrancetesttype.SelectedValue), ddlExamDateToefl.SelectedValue, ddlExamTimeToefl.SelectedValue, "0", "0", ddlTestType.SelectedValue, txtExamPassedOnYear.Text + "/" + txtExamPassedOnMonth.Text + "/" + txtExamPassedOnDate.Text, txtEnglishMark.Text, txtStatusOfExam.Text, txtListening.Text, txtReading.Text, txtWriting.Text, txtSpeaking.Text, ResultSubmit, fileName, int.Parse(ddlEntryType.SelectedValue), int.Parse(ddlExamDateToeflOrt.SelectedValue), int.Parse(ddlExamTimeToeflOrt.SelectedValue), 0, 0, chkBooks.Checked, outsidesuc, chkstatus.Checked, Session["EMPID"].ToString());
                if (Result == "RegisterNo")
                {
                    lblMesagToefl.Text = "Successfully Updated!!!";
                    lblMesagToefl.ForeColor = System.Drawing.Color.Blue;
                    //ddlExamDateToefl.SelectedIndex = 0;
                    //ddlExamTimeToefl.SelectedIndex = 0;
                    //ddlExamDateIELTS.SelectedIndex = 0;
                    //ddlExamTimeIELTS.SelectedIndex = 0;
                    ddlTestType.SelectedIndex = 0;
                    txtExamPassedOnYear.Text = "";
                    txtExamPassedOnMonth.Text = "";
                    txtExamPassedOnDate.Text = "";
                    txtEnglishMark.Text = "";
                    txtStatusOfExam.Text = "";
                    txtListening.Text = "";
                    txtReading.Text = "";
                    txtWriting.Text = "";
                    txtSpeaking.Text = "";
                    SetToefl();
                    try
                    {
                        InsertFeeGroup();
                    }
                    catch
                    {
                    }
                }
                else
                {
                    lblMesagToefl.Text = "Please Try Again";
                    lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                }
           
        }
        catch
        {
            lblMesagToefl.Text = "Please Try Again";
            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdateToefl_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        string Id = "0";
        try
        {
           Id = Session["TId"].ToString();
           LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
           
                if (rdbHavingToeflNo.Checked == true)
                {
                    if (rdbTofel.Checked == true && rdbIelts.Checked == true)
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Select TOEFL or IELTS";
                        return;
                    }
                }
                else
                {
                    if (ddlTestType.SelectedIndex == 0)
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Select Test Type";
                        return;
                    }

                    if (ddlTestType.SelectedValue == "7")
                    {

                        if (txtEnglishMark.Text == "")
                        {
                            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                            lblMesagToefl.Text = "Please Select EMSAT range";
                            return;
                        }

                        if (drpemsat.SelectedIndex == -1)
                        {
                            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                            lblMesagToefl.Text = "Please Select EMSAT range";
                            return;
                        }
                    }

                    try
                    {
                        DateTime dt = DateTime.Parse(txtExamPassedOnYear.Text + "/" + txtExamPassedOnMonth.Text + "/" + txtExamPassedOnDate.Text);
                    }
                    catch
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Check Date";
                        return;
                    }
                }
                if ((ddlTestType.SelectedIndex != 0) & (rdbHavingToeflYes.Checked == true))
                {
                    if (ddlEntryType.SelectedIndex == 0)
                    {
                        lblMesagToefl.ForeColor = System.Drawing.Color.Red;
                        lblMesagToefl.Text = "Please Select Entry Type";
                        return;
                    }

                    try
                    {
                        txtEnglish_TextChanged(sender, e);
                    }
                    catch
                    {

                    }
                }
                string ResultSubmit = "No";
                if (rdbResultSubmit.Checked == true)
                    ResultSubmit = "Yes";
                string fileName = "";
                // Check to see if a file was actually selected
                if (fuResult.PostedFile != null && fuResult.PostedFile.ContentLength > 0)
                {
                    // Get the filename and folder to write to
                    fileName = Path.GetFileName(fuResult.PostedFile.FileName);
                    string folder = Server.MapPath("~/Documents/" + LinkId + "/");

                    // Ensure the folder exists
                    Directory.CreateDirectory(folder);

                    // Save the file to the folder
                    fuResult.PostedFile.SaveAs(Path.Combine(folder, fileName));
                }
                bool outsidesuc;
                if (rdosucoutside.SelectedValue == "1")
                { outsidesuc = true; }
                else
                { outsidesuc = false; }
                StudentRegistrationDAL d = new StudentRegistrationDAL();

                string Result = d.UpdateToefl(Id, LinkId, rdbNativeEnglishYes.Checked, rdbHavingToeflNo.Checked, int.Parse(drpentrancetesttype.SelectedValue), ddlExamDateToefl.SelectedValue, ddlExamTimeToefl.SelectedValue, "0", "0", ddlTestType.SelectedValue, txtExamPassedOnYear.Text + "/" + txtExamPassedOnMonth.Text + "/" + txtExamPassedOnDate.Text, txtEnglishMark.Text, txtStatusOfExam.Text, txtListening.Text, txtReading.Text, txtWriting.Text, txtSpeaking.Text, ResultSubmit, fileName, int.Parse(ddlEntryType.SelectedValue), int.Parse(ddlExamDateToeflOrt.SelectedValue), int.Parse(ddlExamTimeToeflOrt.SelectedValue), 0, 0, chkBooks.Checked, outsidesuc, chkstatus.Checked, Session["EMPID"].ToString());
                lblMesagToefl.Text = "Successfully Updated!!!";
                lblMesagToefl.ForeColor = System.Drawing.Color.Blue;
                ddlExamDateToefl.SelectedIndex = 0;
                ddlExamTimeToefl.SelectedIndex = 0;

                ddlTestType.SelectedIndex = 0;
                txtExamPassedOnYear.Text = "";
                txtExamPassedOnMonth.Text = "";
                txtExamPassedOnDate.Text = "";
                txtEnglishMark.Text = "";
                txtStatusOfExam.Text = "";
                txtListening.Text = "";
                txtReading.Text = "";
                txtWriting.Text = "";
                txtSpeaking.Text = "";
                SetToefl();
                btnUpdateToefl.Visible = false;
                btnDeleteToefl.Visible = false;
                btnSubmitToefl.Visible = true;
                try
                {
                    InsertFeeGroup();
                }
                catch
                {
                }
           

        }
        catch
        {
            lblMesagToefl.Text = "Please Try Again";
            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnDeleteToefl_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Session["TId"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.DeleteTable(int.Parse(LinkId), 5);
            lblMesagToefl.Text = "Successfully Deleted!!!";
            lblMesagToefl.ForeColor = System.Drawing.Color.Blue;
            txtExamPassedOnYear.Text = "";
            txtExamPassedOnMonth.Text = "";
            txtExamPassedOnDate.Text = "";
            txtEnglishMark.Text = "";
            txtStatusOfExam.Text = "";
            txtListening.Text = "";
            txtReading.Text = "";
            txtWriting.Text = "";
            txtSpeaking.Text = "";
            SetToefl(); 
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
            btnUpdateToefl.Visible = false;
            btnDeleteToefl.Visible = false;
            btnSubmitToefl.Visible = true;
            SetToefl(); 
        }
        catch
        {
            lblMesagToefl.Text = "Please Try Again";
            lblMesagToefl.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnSubmitMath_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            if (rdbSatScoreYes.Checked == true)
            {
                if (txtMath.Text == "")
                {
                    lblMesagMath.ForeColor = System.Drawing.Color.Red;
                    lblMesagMath.Text = "Math Marks Required!";
                    return;
                }
                try
                {
                    DateTime dt = DateTime.Parse(txtMathPassedOnYear.Text + "/" + txtMathPassedOnMonth.Text + "/" + txtMathPassedOnDate.Text);
                }
                catch
                {
                    lblMesagMath.ForeColor = System.Drawing.Color.Red;
                    lblMesagMath.Text = "Please Check Date!";
                    return;
                }
            }
            if (rdbDiploma.Checked == true)
            {
                if (txtDiplomaRemarks.Text == "")
                {
                    lblMesagMath.ForeColor = System.Drawing.Color.Red;
                    lblMesagMath.Text = "Oops! Please fill remarks!";
                    return;
                }
            }
            

            string ResultSubmit = "No";
            if (rdbMathResultYes.Checked == true)
                ResultSubmit = "Yes";

            string fileName1 = "";
            // Check to see if a file was actually selected
            if (fuResult1.PostedFile != null && fuResult1.PostedFile.ContentLength > 0)
            {
                // Get the filename and folder to write to
                fileName1 = Path.GetFileName(fuResult1.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");

                // Ensure the folder exists
                Directory.CreateDirectory(folder);

                // Save the file to the folder
                fuResult1.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }

            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Status = "";
            try
            {
                   Status = txtMathStatus.Text.Substring(0, 4);
            }
            catch
            {
            }
            string Result = d.InsertMath(LinkId, rdbSatScoreYes.Checked, ddlMathEntranceExam.SelectedValue, ddlMathEntranceExamTime.SelectedValue, txtMath.Text, Status, txtMathPassedOnYear.Text + "/" + txtMathPassedOnMonth.Text + "/" + txtMathPassedOnDate.Text, ResultSubmit, fileName1, txtDiplomaRemarks.Text);
            lblMesagMath.Text = "Successfully Updated!!!";
            lblMesagMath.ForeColor = System.Drawing.Color.Blue;
            ddlMathEntranceExam.SelectedIndex = 0;
            ddlMathEntranceExamTime.SelectedIndex = 0;
            txtMath.Text = "";
            txtMathStatus.Text = "";            
            txtMathPassedOnYear.Text ="";
            txtMathPassedOnMonth.Text = "";
            txtMathPassedOnDate.Text = "";
            SetMath();
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagMath.Text = "Please Try Again";
            lblMesagMath.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdateMath_Click(object sender, EventArgs e)
    {
        try
        {
            InsertFeeGroup();
        }
        catch
        {
        }
        btnUpdateMath.Visible = false;
        btnSubmitMath.Visible = true;
        lblMesagMath.Text = "Successfully Updated!!!";
        lblMesagMath.ForeColor = System.Drawing.Color.Blue;
    }
    protected void btnSubmitTransportation_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertTransportation(LinkId, rdbTransportationYes.Checked, ddlTransportation.SelectedValue, txtExaxtLocation.Text);
            lblTransportaionMesag.Text = "Successfully Updated!!!";
            //ddlTransportation.SelectedIndex = 0;
            //txtExaxtLocation.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblTransportaionMesag.Text = "Please Try Again!!!";
        }
    }
    protected void btnDeleteTransportation_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.DeleteTable(int.Parse(LinkId), 2);
            lblTransportaionMesag.Text = "Successfully Deleted!!!";
            //ddlTransportation.SelectedIndex = 0;
            //txtExaxtLocation.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblTransportaionMesag.Text = "Please Try Again!!!";
        }
    }
    protected void btnSubmitMediaSource_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string MediaSource = "";
            for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
            {
                if (lbMediaSource.Items[i].Selected == true)
                {
                    MediaSource = MediaSource + lbMediaSource.Items[i].Text + ",";
                }
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertMediaSource(LinkId, MediaSource,drpagent.SelectedValue);
            lblMesagMediaSource.Text = "Successfully Updated!!!";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagMediaSource.Text = "Please Try Again!!!";
        }
    }
    protected void btnSubmitHostel_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            DateTime dt;
            try
            {
                dt = DateTime.Parse(txtYearOfHostel.Text + "/" + txtMonthOfHostel.Text + "/" + txtDateOfHostel.Text);
            }
            catch
            {
                dt = DateTime.Now;
            }
            DateTime dtTo;
            try
            {
                dtTo = DateTime.Parse(txtYearOfHostelTo.Text + "/" + txtMonthOfHostelTo.Text + "/" + txtDateOfHostelTo.Text);
            }
            catch
            {
                dtTo = DateTime.Now;
            }
            decimal Fee = 0;
            try
            {
                Fee = decimal.Parse(txtFeePaid.Text);
            }
            catch
            {
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertHostel(LinkId, rdbHostelYes.Checked, ddlNameOfHostel.SelectedValue, txtPhoneNo.Text, Fee, txtReceiptNo1.Text, dt, dtTo, 0);
            lblMesagHostel.Text = "Successfully Updated!!!";
            //txtNameOfHostel.Text = "";
            //txtPhoneNo.Text = "";
            //txtFeePaid.Text = "";
            //txtReceiptNo1.Text = "";
            //txtYearOfHostel.Text = "";
            //txtMonthOfHostel.Text = "";
            //txtDateOfHostel.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagHostel.Text = "Please Try Again!!!";
        }
    }
    protected void btnDeleteHostel_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {           
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.DeleteTable(int.Parse(LinkId), 3);
            lblMesagHostel.Text = "Successfully Deleted!!!";
            txtPhoneNo.Text = "";
            txtFeePaid.Text = "";
            txtReceiptNo1.Text = "";
            txtYearOfHostel.Text = "";
            txtMonthOfHostel.Text = "";
            txtDateOfHostel.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagHostel.Text = "Please Try Again!!!";
        }
    }
    protected void btnAddHostelMHistory_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string fileName1 = "";
            if (fuUploadDocument.PostedFile != null && fuUploadDocument.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuUploadDocument.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuUploadDocument.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertMedicalHitory(LinkId, DateTime.Parse(txtMedicalHistoryYear.Text + "/" + txtMedicalHistoryMonth.Text + "/" + txtMedicalHistoryDate.Text), txtMedicalHistory.Text, fileName1, 0);
            lblMHistory.Text = "Successfully Added!!!";
            SetMedicalHitory();
            //txtMedicalHistoryYear.Text = "";
            //txtMedicalHistoryMonth.Text = "";
            //txtMedicalHistoryDate.Text = "";
            //txtMedicalHistory.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMHistory.Text = "Please Try Again!!!";
        }
    }
    public void SetMedicalHitory()
    {
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetMedicalHistory(int.Parse(Request.QueryString["Id"].ToString()));
        gvMedicalHistory.DataSource = dt.Tables[0];
        gvMedicalHistory.DataBind();
    }
    public void CheckSeat()
    {
        if (int.Parse(ddlCourseType.SelectedValue) != 0)
        {
            if (ddlDegreeType.SelectedValue != "9")
            {
                if (ddlShift.SelectedItem.Text.Contains("MORNING"))
                    ddlShift.SelectedValue = "1";
                else if (ddlShift.SelectedItem.Text.Contains("EVENING"))
                    ddlShift.SelectedValue = "2";
                
                else if (ddlShift.SelectedItem.Text.Contains("WEEKEND"))
                    ddlShift.SelectedValue = "3";
                else if (ddlShift.SelectedItem.Text.Contains("AFTERNOON"))
                    ddlShift.SelectedValue = "4";



                StudentRegistrationDAL s = new StudentRegistrationDAL();
                DataTable dt = s.CheckSeats(int.Parse(ddlCourseType.SelectedValue), int.Parse(ddlTerm.SelectedValue), ddlShift.SelectedValue);
                foreach (DataRow ro in dt.Rows)
                {
                    try
                    {
                        if (ro[0].ToString() == "")
                        {
                            lblProgramMesag.Text = ro[0].ToString();
                            btnSaveProgram.Enabled = true;

                        }
                        else
                        {
                            if (int.Parse(ro[0].ToString()) < 1)
                            {
                                lblProgramMesag.Text = "Seat is Full, Please Choose another Course, Term or Shift!";
                                btnSaveProgram.Enabled = false;
                                return;
                            }
                            else
                            {
                                lblProgramMesag.Text = "Available Seat for " +ddlShift.SelectedItem.Text+" "+ ddlCourseType.SelectedItem.Text + " : " + ro[0].ToString();
                                btnSaveProgram.Enabled = true;
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }
        }
    }
    protected void btnSaveProgram_Click(object sender, EventArgs e)
    
    {        
        btnSaveProgram.Enabled = true;
        if (int.Parse(ddlCourseType.SelectedValue) != 0)
        {
            if (ddlDegreeType.SelectedValue != "9")
            {
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                DataTable dt = s.CheckSeats(int.Parse(ddlCourseType.SelectedValue), int.Parse(ddlTerm.SelectedValue), ddlShift.SelectedValue);
                foreach (DataRow ro in dt.Rows)
                {                    
                    try
                    {
                        if (ro[0].ToString() == "")
                        {
                            lblProgramMesag.Text = ro[0].ToString();
                            btnSaveProgram.Enabled = true;
                        }
                        else
                        {
                            try
                            {
                                if (int.Parse(ro[0].ToString()) < 2)
                                {
                                    string FromEmail = "";
                                    string ToEmail = "administration@skylineuniversity.ac.ae";
                                    string CC = "";
                                    string Subject = "Available Seat for " + ddlCourseType.SelectedItem.Text + " is full!";
                                    string Message = "Available Seat for " + ddlCourseType.SelectedItem.Text + " is full!";
                                    //SendEmails.SendEmail(FromEmail, ToEmail, Subject, Message, CC);
                                }
                            }
                            catch
                            {
                            }
                            if (int.Parse(ro[0].ToString()) < 1)
                            {
                                lblProgramMesag.Text = "Seat is Full, Please Choose another Course, Term or Shift!";
                                btnSaveProgram.Enabled = false;
                                return;
                            }
                            else
                            {
                                lblProgramMesag.Text = "Available Seat for " + ddlCourseType.SelectedItem.Text + " : " + ro[0].ToString();
                                btnSaveProgram.Enabled = true;
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }
        }

        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string Program = "Weekend";
            if (rdbProgramRegular.Checked == true)
                Program = "Week Day";
            DateTime dtFromDate;
            DateTime dtToDate;
            try
            {
                dtFromDate = DateTime.Parse(txtSCFromYear.Text + "/" + txtSCFromMonth.Text + "/" + txtSCFromDay.Text);
            }
            catch
            {
                dtFromDate = DateTime.Now;
            }
            try
            {
                dtToDate = DateTime.Parse(txtSCToYear.Text + "/" + txtSCToMonth.Text + "/" + txtSCToDay.Text);
            }
            catch
            {
                dtToDate = DateTime.Now;
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            int empid = 0;
            try
            {
          empid= int.Parse(Session["EmpId"].ToString());
            }
            catch
            {
                empid = 0;

            }

            string Result = d.InsertProgram(LinkId, Program, ddlDegreeType.SelectedValue, ddlCourseType.SelectedValue, ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text,ddlnextShift.SelectedValue.ToString(),chkintegrated.Checked,empid);
           if  (ddlCourseType.SelectedItem.Text.Contains("MQP")==true)
           {
           Result = d.InsertMQPSubject(LinkId, chkSubject1.Checked, chkSubject2.Checked, chkSubject3.Checked, chkSubject4.Checked, chkSubject5.Checked, chkSubject6.Checked, chkSubject7.Checked, int.Parse(Session["EmpId"].ToString()));
           }
            if (Result == "Sucess")
            {
                if (chkMQPCourse.Checked == true && chkNone.Checked == false)
                {
                    d.InsertMultiStudentDetails2(LinkId);
                    string Degree = "6";
                    string Course = "7";
                    if (rdbProgramWeekend.Checked == true)
                    {
                        Degree = "8";
                        Course = "25";
                    }
                    string NewDegree = "28";
                    if (chkAIPCBASIC.Checked == true)
                    {
                        NewDegree = "29";
                    }
                    if (chkAIPCAdvance.Checked == true)
                    {
                        NewDegree = "28";
                    }
                    if (chkAIPCADVANCEWith1Course.Checked == true)
                    {
                        NewDegree = "87";
                    }
                    if (chkAIPCADVANCEWith2Course.Checked == true)
                    {
                        NewDegree = "88";
                    }

                    if (Chkket.Checked == true)
                    {
                        NewDegree = "113";
                    }
                    d.InsertProgram2(LinkId, Program, Degree, Course, ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, NewDegree,ddlnextShift.SelectedValue);
                }
                else
                {
                    if (chkMQPCourse.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        string Degree = "6";
                        string Course = "7";
                        if (rdbProgramWeekend.Checked == true)
                        {
                            Degree = "8";
                            Course = "25";
                        }
                        d.InsertProgram1(LinkId, Program, Degree, Course, ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text,ddlnextShift.SelectedValue);
                    }
                    if (chkAIPCBASIC.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        d.InsertProgram1(LinkId, Program, "9", "29", ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlnextShift.SelectedValue);
                    }
                    if (chkAIPCAdvance.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        d.InsertProgram1(LinkId, Program, "9", "28", ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlnextShift.SelectedValue);
                    }
                    if (chkAIPCADVANCEWith1Course.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        d.InsertProgram1(LinkId, Program, "9", "87", ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlnextShift.SelectedValue);
                    }
                    if (chkAIPCADVANCEWith2Course.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        d.InsertProgram1(LinkId, Program, "9", "88", ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlnextShift.SelectedValue);
                    }
                    if (chkIELTSCourse.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        d.InsertProgram1(LinkId, Program, "9", "64", ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlnextShift.SelectedValue);
                    }
                    if (Chkket.Checked == true)
                    {
                        d.InsertMultiStudentDetails(LinkId);
                        d.InsertProgram1(LinkId, Program, "9", "113", ddlTerm.SelectedValue, ddlShift.SelectedValue, dtFromDate, dtToDate, ddlReading.SelectedItem.Text, ddlWriting.SelectedItem.Text, ddlListening.SelectedItem.Text, ddlSpeaking.SelectedItem.Text, ddlnextShift.SelectedValue);
                    }
                }
                lblProgramMesag.Text = "Successfully Updated!!!";
                try
                {
                    InsertFeeGroup();
                }
                catch
                {
                }
            }
            else
            {
                lblProgramMesag.Text = "Please Try Again!!!";
            }
            //ddlDegreeType.SelectedIndex = 0;
            //ddlCourseType.SelectedIndex= 0;
            //ddlTerm.SelectedIndex = 0;
            //ddlShift.SelectedIndex = 0;
        }
        catch
        {
            lblProgramMesag.Text = "Please Try Again!!!";
        }
    }
    protected void btnSaveTOC_Click(object sender, EventArgs e)
    {
        if (ddlUniversityName.SelectedIndex == 0)
        {
            lblTOCMesag.Text = "University Required!!!";
            return;
        }
        if (ddlUniversityName.SelectedItem.Text.Contains("HCT"))
        {
            if (txtCGPATOC.Text == "")
            {
                lblTOCMesag.Text = "CGPA Required!!!";
                return;
            }
        }
        txtCGPATOC_TextChanged(sender, e);        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            DateTime dt;
            try
            {
                dt = DateTime.Parse(txtFollowYear.Text + "/" + txtFollowMonth.Text + "/" + txtFollowDate.Text);
            }
            catch
            {
                dt = DateTime.Now;
            }
            DateTime dt1;
            try
            {
                dt1 = DateTime.Parse(txtYear.Text + "/" + txtMonth.Text + "/" + txtDate.Text);
            }
            catch
            {
                dt1 = DateTime.Now;
            } 
            string fileName1 = "";
            if (fuTocDocument.PostedFile != null && fuTocDocument.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuTocDocument.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuTocDocument.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertTOC(LinkId, ddlTransferUniversity.SelectedValue, ddlDocumentProcess.SelectedValue, txtUniversityNameProgram.Text, txtTotalNoOfCourse.Text,
                txtUnderTakingForToc.Text, txtUniversityAttended.Text, dt , txtFinanceDetails.Text,
                txtFeesPaid.Text, txtReceiptNo.Text, dt1, decimal.Parse(txtCGPATOC.Text), fileName1, chkCDD.Checked, chkTranscript.Checked, chkLetter.Checked, Chkmqptoc.Checked);
            lblTOCMesag.Text = "Successfully Added!!!";
            lblTOCMesag.ForeColor = System.Drawing.Color.Blue;
            SetToc();
            ddlTransferUniversity.SelectedIndex = 0;
            ddlDocumentProcess.SelectedIndex = 0;
            txtUniversityNameProgram.Text = "";
            txtTotalNoOfCourse.Text = "";
            txtUnderTakingForToc.Text = "";
            txtUniversityAttended.Text = "";
            txtFollowYear.Text = "";
            txtFollowMonth.Text = "";
            txtFollowDate.Text = "";
            txtFinanceDetails.Text = "";
            txtFeesPaid.Text = "";
            txtReceiptNo.Text = "";
            txtYear.Text = "";
            txtMonth.Text = "";
            txtDate.Text = "";
            txtCGPA.Text = ""; 
            chkCDD.Checked = false;
            chkTranscript.Checked = false;
            chkLetter.Checked = false;
            Chkmqptoc.Checked = false;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblTOCMesag.Text = "Please Try Again!!!";
        }
    }
    protected void btnSaveFinace_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            try
            {
                if ((decimal.Parse(txtFees.Text) - decimal.Parse(txtAvailableFund.Text)) < 0)
                {
                    lblMesagProgram.Text = "Fund Limit Exeeded, Please Select Another Fee Waiver!!!";
                     return;
                }


               
            }
            catch
            {
            }
                    
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            DataTable dd = d.ISMOUNOUPercExist(int.Parse(ddlDiscountType.SelectedValue), ddlPercentage.SelectedValue, int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue));

            if (dd.Rows[0][0].ToString() == "1".ToString())
            {
                var choice ="N";
                if(rad_Self.Checked )
                {
                    choice= "S";
                }
                if  (rad_Family.Checked)
                {
                    choice="F";
                }

                
                var relation ="None";
                if(choice =="N")
                {
                    relation="None";
                }
                else
                {
                    relation = Convert.ToString(ddl_Family.SelectedValue);
                }




             
                string Result = d.InsertFinace(LinkId, ddlDiscountType.SelectedValue, decimal.Parse(txtNetFees.Text), decimal.Parse(txtDiscount.Text), decimal.Parse(txtTotalFees.Text), txtRemarksPrograms.Text, chkLetterSubmitted.Checked, int.Parse(ddlType.SelectedValue), ddlPercentage.SelectedItem.Text, chkNauFees.Checked, Txtspecial.Text, Txtstud.Text, choice, relation, int.Parse(ddlHrdDepartment.SelectedValue),chkairticket.Checked);
                lblMesagProgram.Text = "Successfully Updated!!!";
                try
                {
                    DataTable dat = d.InsertAirticket_Eligible(LinkId, "Insert");
                    lblairstatus.Text = dat.Rows[0][1].ToString();
                }
                catch
                {

                }
                
                
                try
                {
                    InsertFeeGroup();
                }
                catch
                {
                }
            }
            else
            {
                lblMesagProgram.Text = "Percentage is not alloted for that type. change Percentage and Try!!!";
                return;

            }
            //ddlDiscountType.SelectedIndex = 0;
            //txtFees.Text = "";
            //txtDiscount.Text = "";
            //txtTotalFees.Text = "";
            //txtRemarksPrograms.Text = "";
        }
        catch
        {
            lblMesagProgram.Text = "Please Try Again!!!";
        }
    }
    protected void btnSaveFitness_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string fileName3 = "";
            if (fuMedicalCertificate.PostedFile != null && fuMedicalCertificate.PostedFile.ContentLength > 0)
            {
                fileName3 = Path.GetFileName(fuMedicalCertificate.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuMedicalCertificate.PostedFile.SaveAs(Path.Combine(folder, fileName3));
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertFitness(LinkId, chkIsDisability.Checked, txtHandiCapped.Text, chkChronicBool.Checked, txtChronicDisease.Text, chkPoliceClearnece.Checked, txtPoliceClearance.Text, chkMedicalCertificate.Checked, txtsubject.Text, fileName3, chkVisual.Checked, chkHearing.Checked, chkDifficulty.Checked);
            lblFitnessMsg.Text = "Successfully Updated!!!";
            //chkIsDisability.Checked = false;
            //txtHandiCapped.Text = "";
            //chkChronicBool.Checked = false;
            //txtChronicDisease.Text = "";
            //chkPoliceClearnece.Checked = false;
            //txtPoliceClearance.Text = "";
            //chkMedicalCertificate.Checked = false;
            //txtsubject.Text = "";
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblFitnessMsg.Text = "Please Try Again!!!";
        }
    }
    protected void btnInsertContact_Click(object sender, EventArgs e)
    {        
        try
        {
            FileUpload img = (FileUpload)fuPhoto;
            if (!img.HasFile)
            {
                lblMesagContact.Text = "Please Select Photo!!!";
                lblMesagContact.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        catch
        {

        }

        if (int.Parse(ddlStudentType.SelectedValue) == 0)
        {
            lblMesagContact.Text = "Please Select StudentType!!!";
            lblMesagContact.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (ddlPresentState.SelectedItem.Text == "Select")
        {
            lblMesagContact.Text = "Please Select State!!!";
            lblMesagContact.ForeColor = System.Drawing.Color.Red;
            return;
        }



        //if (int.Parse(ddlNationalityDetails.SelectedValue) == 0)
        //{
        //    lblMesagContact.Text = "Please Select Country!!!";
        //    lblMesagContact.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}

        //if (int.Parse(ddlPresentState.SelectedValue) == 0)
        //{
        //    lblMesagContact.Text = "Please Select State!!!";
        //    lblMesagContact.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}


        string LinkId = "0";
        byte[] Photo = ReadFile();
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.InsertContact(LinkId, txtPresentCity.Text, ddlPresentState.SelectedItem.Text, txtPresentAddr1.Text, txtPresentAddr2.Text, txtPostBoxNo.Text, ddlNationalityDetails.SelectedValue, ddlEmirateID.SelectedValue, txtPlaceofBirth.Text, ddlPlaceofBirthNation.SelectedValue, txtResPhoneNo.Text, txtOffPhoneNo.Text, txtMobile.Text, txtEmail.Text, txtFaxNo.Text, ddlMaritalStatus.SelectedValue, txtPermenentCity.Text, ddlPermenentState.SelectedItem.Text, ddlPermanentCountry.SelectedValue, txtPermenentAddr1.Text, txtPermenentAddr2.Text, Photo, ddlStudentType.SelectedValue);
            lblMesagContact.Text = "Successfully Updated!!!";
            SetContact(); 
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
            //txtPresentCity.Text = "";
            //txtPresentState.Text = "";
            //txtPresentAddr1.Text = "";
            //txtPresentAddr2.Text = "";
            //txtPostBoxNo.Text = "";
            //ddlNationalityDetails.SelectedIndex = 0;
            //ddlEmirateID.SelectedIndex = 0;
            //txtPlaceofBirth.Text = "";
            //ddlPlaceofBirthNation.SelectedIndex = 0;
            //txtResPhoneNo.Text = "";
            //txtOffPhoneNo.Text = "";
            //txtMobile.Text = "";
            //txtEmail.Text = "";
            //txtFaxNo.Text = "";
            //ddlMaritalStatus.SelectedIndex = 0;
            //txtPermenentCity.Text = "";
            //txtPermenentState.Text = "";
            //ddlPermanentCountry.SelectedIndex = 0;
            //txtPermenentAddr1.Text = "";
            //txtPermenentAddr2.Text = "";
            //ddlStudentType.SelectedIndex = 0;
        }
        catch
        {
            lblMesagContact.Text = "Please Try Again!!!";
        }
    }
    protected void bbtnUnderTaking_Click(object sender, EventArgs e)
    {        
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            int Count = 0;
            d.UpdateUndertaking(LinkId);
            for (int i = 0; i < lblUndertaking.Items.Count; i++)
            {
                string Result = d.InsertUndertaking(LinkId, lblUndertaking.Items[i].Text, int.Parse(Session["EMPID"].ToString()));
                Count++;
            }       
            lblMesagUnderTaking.Text = "Sucessfully Added!!!";
            //SetUndertaking();
            DataSet dt = new DataSet();
            dt = d.SetUndertaking(int.Parse(Request.QueryString["Id"].ToString()));            
            gvUndertakin.DataSource = dt.Tables[1];
            gvUndertakin.DataBind(); 
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagUnderTaking.Text = "Please Try Again!!!";
        }
    }
    public void SetUndertaking()
    {
        if (ddlDegreeType.SelectedIndex != 0)
        {
            if (lblUndertaking.Items.Count != 0)
                lblUndertaking.Items.Clear();
            if (lblAllUndertaking.Items.Count != 0)
                lblAllUndertaking.Items.Clear();
            DataSet dt = new DataSet();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (s.GetIsNewUndertaking(Request.QueryString["Id"].ToString()) != 0)
            {
                if (lblAllUndertaking.Items.Count != 0)
                    lblAllUndertaking.Items.Clear();
                LoadUndertaking();
                dt = s.SetUndertaking(int.Parse(Request.QueryString["Id"].ToString()));
                foreach (DataRow ro in dt.Tables[0].Rows)
                {
                    lblUndertaking.Items.Add(ro["UName"].ToString());
                    lblAllUndertaking.Items.Remove(ro["UName"].ToString());
                }
                if (dt.Tables[0].Rows.Count == 0)
                {
                    if (lblAllUndertaking.Items.Count != 0)
                        lblAllUndertaking.Items.Clear();
                    LoadUndertaking();
                }
                lblUndertaking.DataBind();
                gvUndertakin.DataSource = dt.Tables[1];
                gvUndertakin.DataBind();
            }
            else
            {
                if (lblAllUndertaking.Items.Count != 0)
                    lblAllUndertaking.Items.Clear();
                LoadUndertaking();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int Count = 0;
        for (int i = 0; i < lblAllUndertaking.Items.Count; i++)
        {
            if (lblAllUndertaking.Items[i].Selected)
            {
                lblUndertaking.Items.Add(lblAllUndertaking.Items[i].Text);
                lblAllUndertaking.Items.Remove(lblAllUndertaking.Items[i].Text);
                Count++;
                i--;
            }
        }
        lblAllUndertaking.DataBind();
        lblUndertaking.DataBind();
        if (Count == 0)
            lblMesagUnderTaking.Text = "Select Undertaking First!";

    }
    protected void btnViewTOC_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        Response.Redirect("http://LAPTOP-RECM1EAA\\SQLEXPRESS1/adminexam/page/Toc_Report.aspx?id=" + s.GetRegNo(Request.QueryString["Id"].ToString()), false);
    }
    protected void btnViewUnderTaking_Click(object sender, EventArgs e)
    {
        int Count = 0;
        for (int i = 0; i < lblAllUndertaking.Items.Count; i++)
        {
            if (Count == 0)
            {
                if (lblAllUndertaking.Items[i].Selected)
                {
                    Session["LinkId"] = Request.QueryString["Id"].ToString();
                    StudentRegistrationDAL s = new StudentRegistrationDAL();
                    Response.Redirect("PrintOffLine.aspx?UName=" + s.GetFileName(lblAllUndertaking.Items[i].Text), false);
                    Count++;
                    i--;
                }
            }
        }
        if (Count == 0)
            lblMesagUnderTaking.Text = "Select Undertaking First!";

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int Count = 0;
        for (int i = 0; i < lblUndertaking.Items.Count; i++)
        {
            if (lblUndertaking.Items[i].Selected)
            {
                lblAllUndertaking.Items.Add(lblUndertaking.Items[i].Text);
                lblUndertaking.Items.Remove(lblUndertaking.Items[i].Text);
                Count++;
                i--;
            }
        }
        lblAllUndertaking.DataBind();
        lblUndertaking.DataBind();
        if (Count == 0)
            lblMesagUnderTaking.Text = "Select Undertaking First!";
    }
    public void SetContact()
    {
       
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetContact(int.Parse(Request.QueryString["Id"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            txtPresentCity.Text = ro["PresentCity"].ToString();
            try
            {
                ddlNationalityDetails.SelectedValue = ro["Country"].ToString();
                ddlPresentState.DataSource = s.SetState(ddlNationalityDetails.SelectedValue);
                ddlPresentState.DataTextField = "State";
                ddlPresentState.DataValueField = "State";
                ddlPresentState.DataBind();
                ddlPresentState.SelectedValue = ro["PresentStreet"].ToString();
            }
            catch
            {
            }
            try
            {
                txtPresentAddr1.Text = ro["PresentAdd1"].ToString();
                txtPresentAddr2.Text = ro["PresentAdd2"].ToString();
                txtPostBoxNo.Text = ro["PostBoxNo"].ToString();
                ddlEmirateID.SelectedValue = ro["Emirates"].ToString();
                txtPlaceofBirth.Text = ro["PlaceOfBirth"].ToString();
                ddlPlaceofBirthNation.SelectedValue = ro["Nation"].ToString();
                txtResPhoneNo.Text = ro["PhoneRes"].ToString();
                txtOffPhoneNo.Text = ro["PhoneOff"].ToString();
                txtMobile.Text = ro["Mobile"].ToString();
                txtEmail.Text = ro["Email"].ToString();
                txtFaxNo.Text = ro["FaxNo"].ToString();
                ddlMaritalStatus.SelectedValue = ro["MaritalStatus"].ToString();
            }
            catch
            {
            }
            try
            {
                ddlPermanentCountry.SelectedValue = ro["PermanentCountry"].ToString();
                ddlPermenentState.DataSource = s.SetState(ddlPermanentCountry.SelectedValue);
                ddlPermenentState.DataTextField = "State";
                ddlPermenentState.DataValueField = "State";
                ddlPermenentState.DataBind();
                txtPermenentCity.Text = ro["PermanentCity"].ToString();
                ddlPermenentState.SelectedValue = ro["PermanentStreet"].ToString();
            }
            catch
            {

            }
            try
            {
                txtPermenentAddr1.Text = ro["PermanentAdd1"].ToString();
                txtPermenentAddr2.Text = ro["PermanentAdd2"].ToString();
                ddlStudentType.SelectedValue = ro["StudentType"].ToString();
                Img_Student.ImageUrl = "~/ShowImage/Showimage.ashx?LinkId=" + Request.QueryString["Id"].ToString();
            }
            catch
            {

            }
        }
    }
    public void SetFitness()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetFitness(int.Parse(Request.QueryString["Id"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            chkIsDisability.Checked = bool.Parse(ro["IsDisablity"].ToString());
            txtHandiCapped.Text = ro["Disablity"].ToString();
            chkChronicBool.Checked = bool.Parse(ro["IsChronicDisease"].ToString());
            txtChronicDisease.Text = ro["ChronicDeasease"].ToString();
            chkPoliceClearnece.Checked = bool.Parse(ro["IsPoliceClearance"].ToString());
            txtPoliceClearance.Text = ro["PoliceClearance"].ToString();
            chkMedicalCertificate.Checked = bool.Parse(ro["IsMedicalCertificate"].ToString());
            txtsubject.Text = ro["MedicalCertificate"].ToString();
            //fileName3 = ro["MedicalCertificateFileName"].ToString();
        }
    }
    public void SetParents()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetParents(int.Parse(Request.QueryString["Id"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            txtFatherName.Text = ro["GName"].ToString();
            txtRelationShip.Text = ro["RelationShip"].ToString();
            txtProfession.Text = ro["Profession"].ToString();
            txtOrganization.Text = ro["Organization"].ToString();
            txtEmailGuardian.Text = ro["Email"].ToString();
            txtMobileGuardian.Text = ro["Mobile"].ToString();
            txtResPhone.Text = ro["ResPhone"].ToString();
            txtOffPhone.Text = ro["OffPhone"].ToString();
            txtAddress.Text = ro["Address"].ToString();
            txtWebsite.Text = ro["Website"].ToString();
            txtPName.Text = ro["PName"].ToString();
            txtPRelationShip.Text = ro["PRelationShip"].ToString();
            txtPProfession.Text = ro["PProfession"].ToString();
            txtPOrganization.Text = ro["POrganization"].ToString();
            txtPEmailParents.Text = ro["PEmail"].ToString();
            txtPMobileParents.Text = ro["PMobile"].ToString();
            txtPResPhone.Text = ro["PResPhone"].ToString();
            txtPOfficePhone.Text = ro["POffPhone"].ToString();
            txtAddressParents.Text = ro["PAddress"].ToString();
            txtPWebsite.Text = ro["PWebsite"].ToString();
        }
    }
    public void SetMediaSource()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetMediaSource(int.Parse(Request.QueryString["Id"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            try
            {
                for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
                {
                    string[] words = ro["MediaSource"].ToString().Split(',');
                    foreach (string word in words)
                    {
                        if (lbMediaSource.Items[i].Text == word)
                        {
                            lbMediaSource.Items[i].Selected = true;
                        }
                    }
                }

                try
                {
                drpagent.SelectedValue = ro["Agentid"].ToString();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
    }
    public void SetToc()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetTOC(int.Parse(Request.QueryString["Id"].ToString()));
        if (dt.Rows.Count > 0)
        {
            ddlTransferUniversity.SelectedIndex = 0;
            pnlToc.Visible = true;
        }        
        gvTOC.DataSource = dt;
        gvTOC.DataBind();
       
    }

    protected void BtnBoardName_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL SRDAL = new StudentRegistrationDAL();
        int Count = SRDAL.InsertBoardName(txtddlBoardName.Text, chkBoardNameIsActive.Checked, int.Parse(Session["EmpId"].ToString()));
        txtddlBoardName.Text = "";
        chkBoardNameIsActive.Checked = true;
        LoadBoardName();
        MBoardNamePopup.Hide();

    }
    //Added by shihab on 29-Mar-2016
    protected void BtnSharjahHRD_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL SRDAL = new StudentRegistrationDAL();
        int Count = SRDAL.InsertSharjahHRD(txtHRDName.Text, chkHRDNameActive.Checked, int.Parse(Session["EmpId"].ToString()));
        txtHRDName.Text = "";
        chkHRDNameActive.Checked = true;
        LoadSHarjahHRD();
        MSharjahHRDPopup.Hide();

    }

    public void SetFinance()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        try
        {
            chkairticket.Visible = true;
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            DataTable dat = d.InsertAirticket_Eligible(Request.QueryString["Id"].ToString(), "Check");
            if (int.Parse(dat.Rows[0][0].ToString()) == 1)
            {
                chkairticket.Enabled = true;
                chkairticket.Checked = true;
                Lblairticket.Text = dat.Rows[0][1].ToString() + "  ( Check if eligible for Airticket ; UnCheck if not Eligible for Airticket )  ";
            }
            else if (int.Parse(dat.Rows[0][0].ToString()) == -1)
            {
                chkairticket.Enabled = false;
                chkairticket.Visible = false;
                Lblairticket.Text = dat.Rows[0][1].ToString();
            }
            else
            {
                chkairticket.Enabled = false;
                Lblairticket.Text = dat.Rows[0][1].ToString();

            }
        }
        catch
        {

        }

            

        dt = s.SetFinance(int.Parse(Request.QueryString["Id"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            try
            {
                txtNetFees.Text = (decimal.Parse(ro["Fees"].ToString())).ToString("0.00");
                txtDiscount.Text = (decimal.Parse(ro["FeeWaiver"].ToString())).ToString("0.00");
                txtTotalFees.Text = (decimal.Parse(ro["TotalFees"].ToString())).ToString("0.00");
                txtRemarksPrograms.Text = ro["Remarks"].ToString();
                chkLetterSubmitted.Checked = bool.Parse(ro["LetterSubmitted"].ToString());
                try
                {
                    LoadSHarjahHRD();
                    ddlHrdDepartment.SelectedValue = ro["SHJ_HRDID"].ToString();
                   

                }
                catch
                {

                }
                try
                {
                    if (ro["airticket"] != "")
                       Lblairticket.Text = ro["airticket"].ToString();
                    if (ro["IsAirticket"].ToString() != "")
                    {
                        chkairticket.Checked = bool.Parse(ro["IsAirticket"].ToString());
                    }

                  
                   


                    
                }
                catch
                {

                }
                try
                {

                    if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
                    {
                        try
                        {

                            ddlType.DataSource = s.SetDropdownListCDB(74);
                            ddlType.DataTextField = "FeeWaiverType";
                            ddlType.DataValueField = "Id";
                            ddlType.DataBind();

                        }
                        catch
                        {
                        }
                    }
                    if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
                    {
                        try
                        {

                            ddlType.DataSource = s.SetDropdownListCDB(94);
                            ddlType.DataTextField = "FeeWaiverType";
                            ddlType.DataValueField = "Id";
                            ddlType.DataBind();
                        }
                        catch
                        {
                        }
                    }
                    if (ddlDegreeType.SelectedValue == "9")
                    {
                        try
                        {
                            ddlType.DataSource = s.SetDropdownListCDB(95);
                            ddlType.DataTextField = "FeeWaiverType";
                            ddlType.DataValueField = "Id";
                            ddlType.DataBind();
                        }
                        catch
                        {
                        }
                    }

                    ddlType.SelectedValue = ro["catid1"].ToString();
                }
                catch
                {
                }
                try
                {
                    ddlDiscountType.SelectedValue = ro["FeeWaiverType"].ToString();
                }
                catch
                {
                }

                try
                {
                    if (ddlDegreeType.SelectedValue != "9")
                    {

                        if (chkintegrated.Checked == true)
                        {
                            DataTable dt11 = s.GetMouPercentageintegrate(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                            if (dt11.Rows.Count != 1)
                            {

                                ddlPercentage.DataSource = s.GetMouPercentageintegrate(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                                ddlPercentage.DataTextField = "FeeWaiverType";
                                ddlPercentage.DataValueField = "FeeWaiverType";
                                ddlPercentage.DataBind();

                            }
                        }
                        else
                        {


                            DataTable dt1 = s.GetMouPercentage(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                            if (dt1.Rows.Count != 1)
                            {

                                ddlPercentage.DataSource = s.GetMouPercentage(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                                ddlPercentage.DataTextField = "FeeWaiverType";
                                ddlPercentage.DataValueField = "FeeWaiverType";
                                ddlPercentage.DataBind();

                                if (s.CheckTOCExists(int.Parse(Request.QueryString["Id"].ToString())) != "0")
                                {
                                    try
                                    {
                                        ddlPercentage.DataSource = s.GetMouPercentagetoc(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                                        ddlPercentage.DataTextField = "FeeWaiverType";
                                        ddlPercentage.DataValueField = "FeeWaiverType";
                                        ddlPercentage.DataBind();

                                    }
                                    catch
                                    {
                                        ddlPercentage.Items.Clear();
                                        ddlPercentage.Items.Add(new ListItem("Select", "0"));
                                        ddlPercentage.Items.Add(new ListItem("10", "10"));
                                        ddlPercentage.Items.Add(new ListItem("15", "15"));
                                        ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                                        ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                                        ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                                        ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                                        ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                                        ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));
                                    }

                                }
                            }
                            else
                            {

                                if (s.CheckTOCExists(int.Parse(Request.QueryString["Id"].ToString())) != "0")
                                {

                                    ddlPercentage.Items.Clear();
                                    ddlPercentage.Items.Add(new ListItem("Select", "0"));
                                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                                    ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                                    ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                                    ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                                    ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                                    ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                                    ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));


                                }
                                else
                                {

                                    ddlPercentage.Items.Clear();
                                    ddlPercentage.Items.Add(new ListItem("Select", "0"));
                                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                                    ddlPercentage.Items.Add(new ListItem("25", "25"));
                                    ddlPercentage.Items.Add(new ListItem("50", "50"));
                                    ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                                    ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                                    ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                                    ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                                    ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                                    ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));
                                    ddlPercentage.Items.Add(new ListItem("100", "100"));
                                }
                            }

                        }
                    }
                    else
                    {

                        ddlPercentage.Items.Clear();
                        ddlPercentage.Items.Add(new ListItem("Select", "0"));
                        if (ddlType.SelectedValue != "134")
                        {
                            ddlPercentage.Items.Add(new ListItem("5", "5"));
                            ddlPercentage.Items.Add(new ListItem("10", "10"));
                            ddlPercentage.Items.Add(new ListItem("15", "15"));
                        }
                    }
                    ddlPercentage.SelectedValue = ro["Attr1"].ToString();
                }

                catch
                {

                    ddlPercentage.Items.Clear();
                    ddlPercentage.Items.Add(new ListItem("Select", "0"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                    ddlPercentage.Items.Add(new ListItem("25", "25"));
                    ddlPercentage.Items.Add(new ListItem("50", "50"));
                    ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                    ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                    ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                    ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                    ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                    ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));
                    ddlPercentage.Items.Add(new ListItem("100", "100"));


                }
                try
                {
                    ddlPercentage.SelectedValue = ro["Attr1"].ToString();
                }
                catch
                {

                }
                try
                {
                    if (ddlType.SelectedItem.Text.ToString().Contains("ALUMNI") || ddlType.SelectedItem.Text.ToString().Contains("SIBLINGS") || ddlType.SelectedItem.Text.ToString().Contains("BBA"))
                    {
                        Txtspecial.Text = ro["Specialtalent"].ToString();
                        Txtstud.Text = ro["RefStudID"].ToString();
                        pnlsucalum.Visible = true;
                    }
                    else
                    {
                        pnlsucalum.Visible = false;
                    }
                   
                   
                

                }
                catch
                {

                }


            }
            catch
            {
            }
        }


      



    }
    public void SetPrograms()
    {
      
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        try
        {


            ddlDegreeType.DataSource = s.SetDropdownListCDB(14, Drpschool.SelectedValue);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();

           
            dt = s.SetProgram(int.Parse(Request.QueryString["Id"].ToString()));

        }
       catch
        {

        }
        try
        {
            foreach (DataRow ro in dt.Tables[1].Rows)
            {

                Drpschool.SelectedValue = ro["schoolcode"].ToString();
                ddlDegreeType.DataSource = s.SetDropdownListCDB(14, Drpschool.SelectedValue);
                ddlDegreeType.DataTextField = "Description";
                ddlDegreeType.DataValueField = "Id";
                ddlDegreeType.DataBind();

                               ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
                LoadCourse();
                ddlCourseType.SelectedValue = ro["CourseType"].ToString();
            }
        }
        catch
        {
        }
       

        foreach (DataRow ro in dt.Tables[0].Rows)
        {
            if (ro["ProgramType"].ToString() == "Weekend")
            {
                rdbProgramWeekend.Checked = true;
                rdbProgramRegular.Checked = false;
                ProgramWekends();
            }
            else
            {
                rdbProgramWeekend.Checked = false;
                rdbProgramRegular.Checked = true;
                ProgramRegular();
            }
            Drpschool.SelectedValue = ro["schoolcode"].ToString();
            ddlDegreeType.DataSource = s.SetDropdownListCDB(14, Drpschool.SelectedValue);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
            ddlDegreeType.SelectedValue = ro["DegreeType"].ToString();
            LoadCourse();
            ddlCourseType.SelectedValue = ro["CourseType"].ToString();

            try
            {
                ddlTerm.Items.Clear();
                //ddlTerm.DataSource = s.SetDropdownListAsDegreeType(1,int.Parse(ro["Term"].ToString(),Drpschool.SelectedValue);
                //ddlTerm.DataTextField = "Term";
                //ddlTerm.DataValueField = "TermID";
                //ddlTerm.DataBind();
                //ddlTerm.SelectedValue = ro["Term"].ToString();

                ddlTerm.DataSource = s.SetDropdownListCDB(6);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();
                ddlTerm.SelectedValue = ro["Term"].ToString();



            }
            catch
            {
                ddlTerm.Items.Clear();
                ddlTerm.DataSource = s.SetDropdownListCDB(6);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();
                ddlTerm.SelectedValue = ro["Term"].ToString();
            }

            ddlShift.SelectedValue = ro["Shift"].ToString();
             txtSCFromYear.Text = (DateTime.Parse(ro["ShortFromDate"].ToString())).Year.ToString();
            txtSCFromMonth.Text = (DateTime.Parse(ro["ShortFromDate"].ToString())).Month.ToString();
            txtSCFromDay.Text = (DateTime.Parse(ro["ShortFromDate"].ToString())).Day.ToString();
            txtSCToYear.Text = (DateTime.Parse(ro["ShortToDate"].ToString())).Year.ToString();
            txtSCToMonth.Text = (DateTime.Parse(ro["ShortToDate"].ToString())).Month.ToString();
            txtSCToDay.Text = (DateTime.Parse(ro["ShortToDate"].ToString())).Day.ToString();

            try
            {
                ddlnextShift.SelectedValue = ro["Attr1"].ToString();
            }
            catch
            {

            }
            try
            {
                chkintegrated.Checked=bool.Parse(ro["attr3"].ToString());

                if (chkintegrated.Checked == true)
                    ddlDegreeType.Enabled = false;
                else
                    ddlDegreeType.Enabled = true;
            }
            catch
            {

            }

        }
        try
        {
            foreach (DataRow ro in dt.Tables[2].Rows)
            {
                ddlListening.SelectedItem.Text = ro["Listening"].ToString();
                ddlReading.SelectedItem.Text = ro["Reading"].ToString();
                ddlWriting.SelectedItem.Text = ro["Writing"].ToString();
                ddlSpeaking.SelectedItem.Text = ro["Speaking"].ToString();
            }
        }
        catch
        {
        }
        if (ddlDegreeType.SelectedValue == "9")
        {
            pnlSC.Visible = true;
            //ddlTerm.Enabled = false;
        }
        else
        {
            pnlSC.Visible = false;
            ddlTerm.Enabled = true;
        }
        try
        {
            DataSet dtMQP = new DataSet();
            dtMQP = s.SetMQPSubject(int.Parse(Request.QueryString["Id"].ToString()));
            foreach (DataRow ro in dtMQP.Tables[0].Rows)
            {
                chkSubject1.Checked = bool.Parse(ro["Subject1"].ToString());
                chkSubject2.Checked = bool.Parse(ro["Subject2"].ToString());
                chkSubject3.Checked = bool.Parse(ro["Subject3"].ToString());
                chkSubject4.Checked = bool.Parse(ro["Subject4"].ToString());
                chkSubject5.Checked = bool.Parse(ro["Subject5"].ToString());
                chkSubject6.Checked = bool.Parse(ro["Subject6"].ToString());
                chkSubject7.Checked = bool.Parse(ro["Subject7"].ToString());
            }
            string Course = ddlCourseType.SelectedItem.Text;
            if (Course.Contains("MQP") || chkMQPCourse.Checked == true)
            {
                pnlSubject.Visible = true;
            }
            else
            {
                pnlSubject.Visible = false;
            }
        }
        catch
        {
        }
    }
    public void SetTransportation()
    {
        try
        {
            DataTable dt = new DataTable();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            dt = s.SetTransportation(int.Parse(Request.QueryString["Id"].ToString()));
            foreach (DataRow ro in dt.Rows)
            {
                rdbTransportationYes.Checked = bool.Parse(ro["TransportationRequired"].ToString());
                if (rdbTransportationYes.Checked == true)
                {
                    rdbTransportationNo.Checked = false;
                    pnlTransportation.Visible = true;
                }
                else
                {
                    rdbTransportationNo.Checked = true;
                    pnlTransportation.Visible = false;
                }
                ddlTransportation.SelectedValue = ro["Transportation"].ToString();
                txtExaxtLocation.Text = ro["ExactLocation"].ToString();
            }
        }
        catch
        {
        }
    }
    public void SetHostel()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetHostel(int.Parse(Request.QueryString["Id"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            rdbHostelYes.Checked = bool.Parse(ro["IsHostelRequired"].ToString());
            ddlNameOfHostel.SelectedValue = ro["NameofHostel"].ToString();
            txtPhoneNo.Text = ro["PhoneNo"].ToString();
            txtFeePaid.Text = (decimal.Parse(ro["FeePaid"].ToString())).ToString("0.00");
            txtReceiptNo1.Text = ro["ReceiptNo"].ToString();
            txtYearOfHostel.Text = DateTime.Parse(ro["Date"].ToString()).Year.ToString();
            txtMonthOfHostel.Text = DateTime.Parse(ro["Date"].ToString()).Month.ToString();
            txtDateOfHostel.Text = DateTime.Parse(ro["Date"].ToString()).Day.ToString();
            try
            {
                txtYearOfHostelTo.Text = DateTime.Parse(ro["ToDate"].ToString()).Year.ToString();
                txtMonthOfHostelTo.Text = DateTime.Parse(ro["ToDate"].ToString()).Month.ToString();
                txtDateOfHostelTo.Text = DateTime.Parse(ro["ToDate"].ToString()).Day.ToString();
            }
            catch
            {
            }
            if (rdbHostelYes.Checked == true)
            {
                pnlHostel.Visible = true;
                rdbHostelNo.Checked = false;
            }
            else
            {
                pnlHostel.Visible = false;
                rdbHostelNo.Checked = true;
            }
        }
    }
    public void SetQualification()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetQualification(int.Parse(Request.QueryString["Id"].ToString()));        
        GvQualification.DataSource = dt;
        GvQualification.DataBind();
        if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
        {
            if (ddlQualification.SelectedValue == "1" || ddlQualification.SelectedValue == "15")
            {
                ddlBachelorDegree.Enabled = true;
                ddlBachelorDegree.SelectedIndex = 0;
                ddlCourseFOrQualification.Enabled = true;
                ddlCourseFOrQualification.SelectedIndex = 0;

            }
            else
            {
                ddlBachelorDegree.Enabled = false;
                ddlBachelorDegree.SelectedIndex = 0;
                ddlCourseFOrQualification.Enabled = false;
                ddlCourseFOrQualification.SelectedIndex = 0;
            }
        }
        else
        {
            ddlBachelorDegree.Enabled = false;
            ddlBachelorDegree.SelectedIndex = 0;
            ddlCourseFOrQualification.Enabled = false;
            ddlCourseFOrQualification.SelectedIndex = 0;
        }
    }
    public void SetExperience()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetExperience(int.Parse(Request.QueryString["Id"].ToString()));
        if (dt.Rows.Count > 0)
        {
            rdbNotWorking.Checked = false;
            rdbWorking.Checked = true;
            pnlExperience1.Visible = true;
        }
        GvExperience.DataSource = dt;
        GvExperience.DataBind();
    }
    public void SetVisa()
    {
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetVisa(int.Parse(Request.QueryString["Id"].ToString()));
        gvVisa.DataSource = dt;
        gvVisa.DataBind();
    }
    public void SetSkylineVisa()
    {
        btnAddNewVisa.Enabled = true;
        DataTable dt = new DataTable();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetSkylineVisa(int.Parse(Request.QueryString["Id"].ToString()));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow ro in dt.Rows)
            {
                rdbSkylineVisaYes.Checked = bool.Parse(ro["IsSkylineVisa"].ToString());
                RadioButton1.Checked = bool.Parse(ro["svisaletter"].ToString());
                RadioButton2.Checked = bool.Parse(ro["embasyletter"].ToString());
                RadioButton3.Checked = bool.Parse(ro["na"].ToString());

                if (rdbSkylineVisaYes.Checked == true)
                {
                    pnlother.Enabled = false;
                    btnAddNewVisa.Enabled = true;
                    btnDeleteNewVisa.Enabled = true;
                    rdbSkylineVisaNo.Checked = false;
                    btnSaveVDType.Enabled = false;
                    pnlother.Enabled = false;
                    pnlSkylineVisaYes.Visible = true;
                     rdbSkylineVisaYes.Checked = true;
                     PnlInSideVisa.Visible = true;
                     pnlSkylineVisa.Visible = true;

                }
                
                else if (rdbSkylineVisaNo.Checked == true)
                {
                    btnAddNewVisa.Enabled = false;
                    btnDeleteNewVisa.Enabled = false;
                    btnSaveVDType.Enabled = false;
                    pnlother.Enabled = true;
                    rdbSkylineVisaNo.Checked = true;
                }

            

                if (RadioButton1.Checked == true)
                {
                    btnAddNewVisa.Enabled = false;
                    btnDeleteNewVisa.Enabled = false;
                    btnSaveVDType.Enabled = true;
                    pnlother.Enabled = true;
                    RadioButton1.Checked = true;
                }
                else if (RadioButton2.Checked == true)
                {
                    btnAddNewVisa.Enabled = false;
                    btnDeleteNewVisa.Enabled = false;
                    btnSaveVDType.Enabled = true;
                    pnlother.Enabled = true;
                    RadioButton2.Checked = true;
                }

                else if ((RadioButton3.Checked == true) & (rdbSkylineVisaYes.Checked == true))
                {
                   btnAddNewVisa.Enabled = true;
                    btnDeleteNewVisa.Enabled = true;
                    btnSaveVDType.Enabled = false;
                    pnlother.Enabled = false;
                    RadioButton3.Checked = true;
                    pnlSkylineVisaYes.Visible = true;
                    rdbSkylineVisaYes.Checked = true;
                    PnlInSideVisa.Visible = true;
                    pnlSkylineVisa.Visible = true;
                }

                else if ((RadioButton3.Checked == true) & (rdbSkylineVisaYes.Checked == false))
                {
                    btnAddNewVisa.Enabled = false;
                    btnDeleteNewVisa.Enabled = true;
                    btnSaveVDType.Enabled = true;
                    pnlother.Enabled = true;
                    RadioButton3.Checked = true;


                }
                //else
                //{
                //    btnAddNewVisa.Enabled = true;
                //    btnDeleteNewVisa.Enabled = true;
                //    btnSaveVDType.Enabled = false;
                //    pnlother.Enabled =false;
                //}

                if (ro["StudentStatus"].ToString() == "Out Side U.A.E.")
                {
                    rdbOutSide.Checked = true;
                    rdbInside.Checked = false;
                }
                else
                {
                    rdbOutSide.Checked = false;
                    rdbInside.Checked = true;
                }
                if (ro["VisaType"].ToString() == "Transit Visa")
                {
                    rdbTransit.Checked = true;
                    rdbVisit.Checked = false;
                    rdbResidence.Checked = false;
                }
                else if (ro["VisaType"].ToString() == "Residence Visa")
                {
                    rdbTransit.Checked = false;
                    rdbVisit.Checked = false;
                    rdbResidence.Checked = true;
                }
                else
                {
                    rdbTransit.Checked = false;
                    rdbVisit.Checked = true;
                    rdbResidence.Checked = false;
                }
                //if (ro["VisaLetter"].ToString() == "1")
                //{
                //    RadioButton1.Checked = true;
                //    RadioButton2.Checked = false;
                //}
                //else
                //{
                //    RadioButton1.Checked = false;
                //    RadioButton2.Checked = true;
                //}
                txtVisaExpireOnYear.Text = DateTime.Parse(ro["VisaExpireOn"].ToString()).Year.ToString();
                txtVisaExpireOnMonth.Text = DateTime.Parse(ro["VisaExpireOn"].ToString()).Month.ToString();
                txtVisaExpireOnDate.Text = DateTime.Parse(ro["VisaExpireOn"].ToString()).Day.ToString();
                rdbUrgentVisaYes.Checked = bool.Parse(ro["UrgentVisaRequired"].ToString());
                txtFatherNameForVisa.Text = ro["FatherName"].ToString();
                txtAbroadMobileNo.Text = ro["AbroadMobileNo"].ToString();
                txtAbroadResNo.Text = ro["AbroadResNo"].ToString();
                txtMotherName.Text = ro["MotherName"].ToString();
                txtPlaceOfBirthUrgentVisa.Text = ro["PlaceOfBirthCity"].ToString();
                ddlReligionForUrgentVisa.SelectedValue = ro["Country"].ToString();
                txtPlaceOfBirthPlace.Text = ro["PlaceOfBirthPlace"].ToString();
                ddlMaritialStatus.SelectedValue = ro["MaritialStatus"].ToString();
                ddlPortOflastentry.SelectedValue = ro["PortOfLastEntry"].ToString();
                ddlPreviousNationality.SelectedValue = ro["PrevNationality"].ToString();
                txtDateOfLastEntryYear.Text = DateTime.Parse(ro["DateOfLastEntry"].ToString()).Year.ToString();
                txtDateOfLastEntryMonth.Text = DateTime.Parse(ro["DateOfLastEntry"].ToString()).Month.ToString();
                txtDateOfLastEntryDate.Text = DateTime.Parse(ro["DateOfLastEntry"].ToString()).Day.ToString();
                txtReligion.Text = ro["Religion"].ToString();
                txtSpokenLanguage.Text = ro["SpokenLanguage"].ToString();
                txtNativeLanguage.Text = ro["NativeLanguage"].ToString();
                txtAddress1Local.Text = ro["Address1"].ToString();
                txtAddress2Local.Text = ro["Address2"].ToString();
                txtGuardianPostalAddress.Text = ro["POBOX"].ToString();
                txtOfficeAddress.Text = ro["OfficeAddress"].ToString();
                txtCityLocal.Text = ro["City"].ToString();
                txtStateLocal.Text = ro["State"].ToString();
                ddlEmirates.SelectedValue = ro["Emirates"].ToString();
                ddlNationalityForLocalGuardian.SelectedValue = ro["Nationality"].ToString();
                txtGuardianPassportNo.Text = ro["GuardianPassportNo"].ToString();
                try
                {
                    txtGuardianPassportValidityYear.Text = DateTime.Parse(ro["PassportValidity"].ToString()).Year.ToString();
                    txtGuardianPassportValidityMonth.Text = DateTime.Parse(ro["PassportValidity"].ToString()).Month.ToString();
                    txtGuardianPassportValidityDate.Text = DateTime.Parse(ro["PassportValidity"].ToString()).Day.ToString();
                }
                catch
                {
                }
                txtGuardianVisaStatus.Text = ro["VisaStatus"].ToString();
                txtNationalIdLocal.Text = ro["NationalIdCardNo"].ToString();
                //fileName1 = ro["IdCardFileName"].ToString();
                txtVisaPage.Text = ro["VisaPage"].ToString();
                //fileName2 = ro["VisaPageFileName"].ToString();
                txtVisa.Text = ro["TenancyContact"].ToString();
                //fileName3 = ro["TenancyFileName"].ToString();
                txtGuardianVisaNo.Text = ro["VisaNo"].ToString();
                txtGuardianNameOfSponsor.Text = ro["SponsorName"].ToString();
                //if (rdbSkylineVisaYes.Checked == true)
                //{
                //    pnlSkylineVisaYes.Visible = true;
                //    pnlSkylineVisa.Visible = true;
                //    rdbSkylineVisaNo.Checked = false;
                //}
                //else
                //{
                //    pnlSkylineVisaYes.Visible = false;
                //    pnlSkylineVisa.Visible = false;
                //    rdbSkylineVisaNo.Checked = true;
                //}
                if (rdbOutSide.Checked == true)
                {
                    PnlInSideVisa.Visible = false;
                    rdbInside.Checked = false;
                }
                else
                {
                    PnlInSideVisa.Visible = true;
                    rdbInside.Checked = true;
                }
            }
        }
        else
        {
           // btnAddNewVisa.Enabled = false;
            btnDeleteNewVisa.Enabled = false;
            btnSaveVDType.Enabled = false;
        }
    }
    public void SetToefl1(string Id)
    {
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetToefl1(int.Parse(Id));
        GvToefl.DataSource = dt.Tables[1];
        GvToefl.DataBind();
        foreach (DataRow ro in dt.Tables[0].Rows)
        {
            if (bool.Parse(ro["EnglishSpeaker"].ToString()) == true)
            {
                rdbNativeEnglishYes.Checked = true;
                rdbNativeEnglishNo.Checked = false;
            }
            else
            {
                rdbNativeEnglishYes.Checked = false;
                rdbNativeEnglishNo.Checked = true;
            }
            if (bool.Parse(ro["Toefl"].ToString()) == false)
            {
                rdbHavingToeflYes.Checked = true;
                rdbHavingToeflNo.Checked = false;
            }
            else
            {
                rdbHavingToeflYes.Checked = false;
                rdbHavingToeflNo.Checked = true;
            }
            try
            {
                drpentrancetesttype.SelectedValue = ro["ToefelExamDateType"].ToString();
            }
            catch
            {
            }
           
            if (rdbNativeEnglishYes.Checked == true)
            {
                //pnlNativeSpeaker.Visible = false;
                pnlNativeSpeaker.Visible = true;
                btnSubmitToefl.Enabled = true;
            }
            else
            {
                pnlNativeSpeaker.Visible = true;
                btnSubmitToefl.Enabled = true;
            }
           
            try
            {
                ddlExamDateToefl.SelectedValue = ro["ExamDateToefl"].ToString();
                ddlExamTimeToefl.SelectedValue = ro["ExamTimeToefl"].ToString();
            }
            catch
            {
            }
           
            ddlTestType.SelectedValue = ro["TestType"].ToString();
            try
            {
                txtExamPassedOnYear.Text = (DateTime.Parse(ro["ExamPassedOn"].ToString()).Year.ToString());
                txtExamPassedOnMonth.Text = (DateTime.Parse(ro["ExamPassedOn"].ToString()).Month.ToString());
                txtExamPassedOnDate.Text = (DateTime.Parse(ro["ExamPassedOn"].ToString()).Day.ToString());
            }
            catch
            {
            }
            //if (rdbTofel.Checked == true)
            //{
            //    pnlToeflExamDate.Visible = true;
            //    pnlIeltsExamDates.Visible = false;
            //}
            //else
            //{
            //    pnlToeflExamDate.Visible = false;
            //    pnlIeltsExamDates.Visible = true;
            //}
            txtEnglishMark.Text = ro["EnglishMark"].ToString();
            txtStatusOfExam.Text = ro["StatusOfExam"].ToString();
            txtListening.Text = ro["Listening"].ToString();
            txtReading.Text = ro["Reading"].ToString();
            txtWriting.Text = ro["Writing"].ToString();
            txtSpeaking.Text = ro["Speaking"].ToString();
            if (ro["ResultSubmited"].ToString() == "Yes")
            {
                rdbResultSubmit.Checked = true;
                rdbResultSubmitNo.Checked = false;
            }
            else
            {
                rdbResultSubmit.Checked = false;
                rdbResultSubmitNo.Checked = true;
            }
            //fileName = ro["Result"].ToString();
        }
    }
    public void SetToefl()
    {
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetToefl1(int.Parse(Request.QueryString["Id"].ToString()));
        GvToefl.DataSource = dt.Tables[1];
        GvToefl.DataBind();
        //foreach (DataRow ro in dt.Tables[0].Rows)
        //{
        //    rdbNativeEnglishYes.Checked = bool.Parse(ro["EnglishSpeaker"].ToString());
        //    rdbHavingToeflNo.Checked = bool.Parse(ro["Toefl"].ToString());
        //    rdbTofel.Checked = bool.Parse(ro["ToefelExamDateType"].ToString());
        //    ddlExamDateToefl.SelectedValue = ro["ExamDateToefl"].ToString();
        //    ddlExamTimeToefl.SelectedValue = ro["ExamTimeToefl"].ToString();
        //    ddlExamDateIELTS.SelectedValue = ro["ExamDateIelts"].ToString();
        //    ddlExamTimeIELTS.SelectedValue = ro["ExamTimeIelts"].ToString();
        //    ddlTestType.SelectedValue = ro["TestType"].ToString();
        //    try
        //    {
        //        txtExamPassedOnYear.Text = (DateTime.Parse(ro["ExamPassedOn"].ToString()).Year.ToString());
        //        txtExamPassedOnMonth.Text = (DateTime.Parse(ro["ExamPassedOn"].ToString()).Month.ToString());
        //        txtExamPassedOnDate.Text = (DateTime.Parse(ro["ExamPassedOn"].ToString()).Day.ToString());
        //    }
        //    catch
        //    {
        //    }
        //    txtEnglishMark.Text = ro["EnglishMark"].ToString();
        //    txtStatusOfExam.Text = ro["StatusOfExam"].ToString();
        //    txtListening.Text = ro["Listening"].ToString();
        //    txtReading.Text = ro["Reading"].ToString();
        //    txtWriting.Text = ro["Writing"].ToString();
        //    txtSpeaking.Text = ro["Speaking"].ToString();
        //    if (ro["ResultSubmited"].ToString() == "Yes")
        //    {
        //        rdbResultSubmit.Checked = true;
        //        rdbResultSubmitNo.Checked = false;
        //    }
        //    else
        //    {
        //        rdbResultSubmit.Checked = false;
        //        rdbResultSubmitNo.Checked = true;
        //    }
        //    //fileName = ro["Result"].ToString();
        //}
    }
    protected void GvToefl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void GvToefl_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["TId"] = Id.ToString();
            SetToefl1(Id);
            SetToefl();
            btnUpdateToefl.Visible = true;
            btnDeleteToefl.Visible = true;
            btnSubmitToefl.Visible = false;
        }
        if (e.CommandName.Equals("Delete"))
        {
            string Id = e.CommandArgument.ToString();
            Session["TId"] = Id.ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
           // string Result = s.DeleteToefl(Id.ToString());
            string Result = s.DeleteTable(int.Parse(Id),5);
            if (Result == "")
            {
                string  LinkId = Request.QueryString["Id"].ToString();
                SetToefl1(LinkId);
                //SetToefl1();
                lblMesagToefl.Text = "Deleted Sucessfully!";
                lblMesagToefl.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                string LinkId = Request.QueryString["Id"].ToString();
                SetToefl1(LinkId);
                lblMesagToefl.Text = "Deleted Sucessfully!";
                lblMesagToefl.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void gvMath_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvMath_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["MId"] = Id.ToString();
            SetMath1(Id);
            SetMath();
            btnUpdateMath.Visible = true;
            btnSubmitMath.Visible = false;
        }
        if (e.CommandName.Equals("Delete001"))
        {
            string Id = e.CommandArgument.ToString();
            Session["TId"] = Id.ToString();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            //string Result = s.DeleteMath(Id.ToString());
            string Result = s.DeleteTable(int.Parse(Id), 6);
            if (Result == "")
            {
                string LinkId = Request.QueryString["Id"].ToString();
                 SetMath1(LinkId);
                //SetMath();
                lblMesagMath.Text = "Deleted Sucessfully!";
                lblMesagMath.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                string LinkId = Request.QueryString["Id"].ToString();
                lblMesagMath.Text = "Deleted Sucessfully!";
                lblMesagMath.ForeColor = System.Drawing.Color.Red;
                SetMath1(LinkId);
            }
        }
    }
    public void SetMath1(string Id)
    {
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetMath1(int.Parse(Id));
        gvMath.DataSource = dt.Tables[1];
        gvMath.DataBind();

        if (ddlDegreeType.SelectedValue == "9")
        {
            pnlSC.Visible = true;
            //ddlTerm.Enabled = false;
            pnlHideEntrance.Visible = false;
            PnlHideToefl.Visible = false;
        }
        else
        {
            pnlSC.Visible = false;
            ddlTerm.Enabled = true;
            pnlHideEntrance.Visible = true;
            PnlHideToefl.Visible = true;
        }
        if (ddlDegreeType.SelectedValue == "8")
        {
            pnlHideEntrance.Visible = false;
        }
        else if (ddlDegreeType.SelectedValue == "6")
        {
            pnlHideEntrance.Visible = false;
        }
        else
            if (ddlDegreeType.SelectedValue != "9")
            {
                pnlHideEntrance.Visible = true;
            }
        foreach (DataRow ro in dt.Tables[0].Rows)
        {
            rdbSatScoreYes.Checked = bool.Parse(ro["HavingSat"].ToString());
            ddlMathEntranceExam.SelectedValue = ro["MathExamDate"].ToString();
            ddlMathEntranceExamTime.SelectedValue = ro["MathExamTime"].ToString();
            txtMath.Text = ro["MathMark"].ToString();
            txtMathStatus.Text = ro["StatusOfExamMath"].ToString();
            try
            {
                txtMathPassedOnYear.Text = (DateTime.Parse(ro["ExamPassedOnMath"].ToString()).Year.ToString());
                txtMathPassedOnMonth.Text = (DateTime.Parse(ro["ExamPassedOnMath"].ToString()).Month.ToString());
                txtMathPassedOnDate.Text = (DateTime.Parse(ro["ExamPassedOnMath"].ToString()).Day.ToString());
            }
            catch
            {
            }
            if (ro["ResultSubmittedMath"].ToString() == "Yes")
            {
                rdbMathResultYes.Checked = true;
                rdbMathResultNo.Checked = false;
            }
            else
            {
                rdbMathResultYes.Checked = false;
                rdbMathResultNo.Checked = true;
            }
            //fileName1 = ro["ResultMath"].ToString();
        }
    }
    public void SetMath()
    {
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetMath1(int.Parse(Request.QueryString["Id"].ToString()));
        gvMath.DataSource = dt.Tables[1];
        gvMath.DataBind();

        //if (ddlDegreeType.SelectedValue == "9")
        //{
        //    pnlSC.Visible = true;
        //    ddlTerm.Enabled = false;
        //    pnlHideEntrance.Visible = false;
        //    PnlHideToefl.Visible = false;
        //}
        //else
        //{
        //    pnlSC.Visible = false;
        //    ddlTerm.Enabled = true;
        //    pnlHideEntrance.Visible = true;
        //    PnlHideToefl.Visible = true;
        //}
        //if (ddlDegreeType.SelectedValue == "8")
        //{
        //    pnlHideEntrance.Visible = false;
        //}
        //else if (ddlDegreeType.SelectedValue == "6")
        //{
        //    pnlHideEntrance.Visible = false;
        //}
        //else
        //    if (ddlDegreeType.SelectedValue != "9")
        //    {
        //        pnlHideEntrance.Visible = true;
        //    }
        //foreach (DataRow ro in dt.Tables[0].Rows)
        //{
        //    rdbSatScoreYes.Checked = bool.Parse(ro["HavingSat"].ToString());
        //    ddlMathEntranceExam.SelectedValue = ro["MathExamDate"].ToString();
        //    ddlMathEntranceExamTime.SelectedValue = ro["MathExamTime"].ToString();
        //    txtMath.Text = ro["MathMark"].ToString();
        //    txtMathStatus.Text = ro["StatusOfExamMath"].ToString();
        //    try
        //    {
        //        txtMathPassedOnYear.Text = (DateTime.Parse(ro["ExamPassedOnMath"].ToString()).Year.ToString());
        //        txtMathPassedOnMonth.Text = (DateTime.Parse(ro["ExamPassedOnMath"].ToString()).Month.ToString());
        //        txtMathPassedOnDate.Text = (DateTime.Parse(ro["ExamPassedOnMath"].ToString()).Day.ToString());
        //    }
        //    catch
        //    {
        //    }
        //    if (ro["ResultSubmittedMath"].ToString() == "Yes")
        //    {
        //        rdbMathResultYes.Checked = true;
        //        rdbMathResultNo.Checked = false;
        //    }
        //    else
        //    {
        //        rdbMathResultYes.Checked = false;
        //        rdbMathResultNo.Checked = true;
        //    }
        //    //fileName1 = ro["ResultMath"].ToString();
        //}
    }
    public void SetRemarks()
    {
        DataSet dt = new DataSet();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        dt = s.SetRemarks(int.Parse(Request.QueryString["Id"].ToString()));
        //foreach (DataRow ro in dt.Tables[0].Rows)
        //{
        //    ddlRemarksType.SelectedValue = ro["RemarksType"].ToString();
        //    txtDetailsRemarks.Text = ro["Remarks"].ToString();
        //}
        GvRemarks.DataSource = dt.Tables[1];
        GvRemarks.DataBind();
    }
    protected void gvMedicalHistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void gvMedicalHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvUndertakin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Uname = e.CommandArgument.ToString();
            string LinkId = "0";
            try
            {
                LinkId = Request.QueryString["Id"].ToString();
            }
            catch
            {
            }
            try
            {
                lblMesagUnderTaking.Text = "";
                for (int i = 0; i < gvUndertakin.Rows.Count; i++)
                {
                    GridViewRow row = gvUndertakin.Rows[i];
                    FileUpload fuUnderTaking = (FileUpload)row.FindControl("fuUnderTaking");
                    string fileName1 = "";
                    if (fuUnderTaking.PostedFile != null && fuUnderTaking.PostedFile.ContentLength > 0)
                    {
                        fileName1 = Path.GetFileName(fuUnderTaking.PostedFile.FileName);
                        string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                        Directory.CreateDirectory(folder);
                        fuUnderTaking.PostedFile.SaveAs(Path.Combine(folder, fileName1));
                        StudentRegistrationDAL d = new StudentRegistrationDAL();
                        string date1 = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                        string Result = d.UpdateUndertaking(int.Parse(LinkId), Uname, fileName1, int.Parse(Session["EmpId"].ToString()), date1);
                        lblMesagUnderTaking.Text = "Documents Uploaded Sucessfully.";
                        lblMesagUnderTaking.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblMesagUnderTaking.Text = "Select Choose File for Uploading.";
                        lblMesagUnderTaking.ForeColor = System.Drawing.Color.Red;

                    }
                }
            }
            catch
            {
                lblMesagUnderTaking.Text = "Oops! try again.";
                lblMesagUnderTaking.ForeColor = System.Drawing.Color.Blue;
            }
        }
    }
    protected void gvUndertakin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvParentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName.Equals("Modify"))
        //{
        //    string Id = e.CommandArgument.ToString();
        //    Session["ID"] = Id.ToString();
        //}
    }
    protected void gvParentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvVisa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["VId"] = Id.ToString();
            UpdateVisa();
            lblVisaInfoMesag.Text = "";
        }
        if (e.CommandName.Equals("DownLoad"))
        {
            string FileName = e.CommandArgument.ToString();
            lblVisaInfoMesag.Text = "";
            if(FileName != "")
                Response.Redirect("../Documents/" + Request.QueryString["Id"].ToString() + "/" + FileName + "", false);
        }
    }
    protected void gvVisa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
            Label lblIssueDate = (Label)e.Row.FindControl("lblIssueDate");
            lblIssueDate.Text = (DateTime.Parse(lblIssueDate.Text)).ToShortDateString();
            Label lblExpireDate = (Label)e.Row.FindControl("lblExpireDate");
            lblExpireDate.Text = (DateTime.Parse(lblExpireDate.Text)).ToShortDateString();
            LinkButton lnkDownLoad = (LinkButton)e.Row.FindControl("lnkDownLoad");
            HiddenField hdFNo = (HiddenField)e.Row.FindControl("hdFNo");
            if (hdFNo.Value == "")
                lnkDownLoad.Enabled = false;
        }
    }
    protected void GvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["QId"] = Id.ToString();
            UpdateQualification();
            lblMesagQualification.Text = "";
        } 
        if (e.CommandName.Equals("DownLoad"))
        {
            string FileName = e.CommandArgument.ToString();
            lblMesagQualification.Text = "";
            if (FileName != "")
                Response.Redirect("../Documents/" + Request.QueryString["Id"].ToString() + "/" + FileName + "", false);
        }
    }
    protected void GvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString(); 
            LinkButton lnkDownLoad = (LinkButton)e.Row.FindControl("lnkDownLoad");
            HiddenField hdFNo = (HiddenField)e.Row.FindControl("hdFNo");
            if (hdFNo.Value == "")
                lnkDownLoad.Enabled = false;
        }
    }
    protected void gvgvTOC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString(); 
            LinkButton lnkDownLoad = (LinkButton)e.Row.FindControl("lnkDownLoad");
            HiddenField hdFNo = (HiddenField)e.Row.FindControl("hdFNo");
            if (hdFNo.Value == "")
                lnkDownLoad.Enabled = false;
        }
    }
    protected void GvExperience_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["EId"] = Id.ToString();
            UpdateExperience();
            lblMesagExperience.Text = "";
        }
    }
    protected void GvExperience_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void GvRemarks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["RId"] = Id.ToString();
            UpdateRemarks();
            lblMesagRemarks.Text = "";
        }
    }
    public void UpdateRemarks()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.SetDropdownListAsDegreeType(7, int.Parse(Session["RId"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            ddlRemarksType.SelectedValue = ro["RemarksType"].ToString();
            txtDetailsRemarks.Text = ro["Remarks"].ToString();
            btnAddRemarks.Visible = false;
            btnUpdateRemarks.Visible = true;
        }
    }
    public void UpdateVisa()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.SetDropdownListAsDegreeType(11, int.Parse(Session["VId"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            if (ro["DocumentType"].ToString() == "National ID Card")
                ddlVisaType.SelectedIndex = 1;
            if (ro["DocumentType"].ToString() == "Visa")
                ddlVisaType.SelectedIndex = 2;
            if (ro["DocumentType"].ToString() == "Passport")
                ddlVisaType.SelectedIndex = 3;
            if (ro["DocumentType"].ToString() == "Driving Licence ID")
                ddlVisaType.SelectedIndex = 4;            
            //ddlVisaType.SelectedItem.Text = ro["DocumentType"].ToString();
            txtTypeofvisa.Text = ro["TypeOfVisa"].ToString();
            txtSponsor.Text = ro["Sponsor"].ToString();
            txtCardNo.Text = ro["CardNo"].ToString();
            txtPlaceOfIssue.Text = ro["PlaceOfIssue"].ToString();
            txtIssueYear.Text = DateTime.Parse(ro["DateOfIssue"].ToString()).Year.ToString();
            txtIssueMonth.Text = DateTime.Parse(ro["DateOfIssue"].ToString()).Month.ToString();
            txtIssueDate.Text = DateTime.Parse(ro["DateOfIssue"].ToString()).Day.ToString();
            txtExpireYear.Text = DateTime.Parse(ro["DateOfExpiry"].ToString()).Year.ToString();
            txtExpireMonth.Text = DateTime.Parse(ro["DateOfExpiry"].ToString()).Month.ToString();
            txtExpireDate.Text = DateTime.Parse(ro["DateOfExpiry"].ToString()).Day.ToString();
            ddlCountryOfIssue.SelectedValue = ro["CountryOfIssue"].ToString();
            btnSubmitVisaInfo.Visible = false;
            btnUpdateVisa.Visible = true;
            txtIssueDate.Enabled = true;
            txtIssueMonth.Enabled = true;
            txtIssueYear.Enabled = true;
            RequiredFieldValidator19.Enabled = true;
            if (ddlVisaType.SelectedItem.Text == "Visa")
            {
                lblCardNo.Text = "Visa No";
                lblPlaceOfIssue.Text = "Visa Place of Issue";
                lblIssueDate.Text = "Visa Date of Issue";
                lblExpireDate.Text = "Visa Date of Expiry";
                pnlVisaDetails.Visible = true;
            }
            if (ddlVisaType.SelectedItem.Text == "Passport")
            {
                lblCardNo.Text = "Passport No";
                lblPlaceOfIssue.Text = "Passport Place of Issue";
                lblIssueDate.Text = "Passport Date of Issue";
                lblExpireDate.Text = "Passport Date of Expiry";
                pnlVisaDetails.Visible = false;
            }
            if (ro["DocumentType"].ToString() == "National ID Card" || ro["DocumentType"].ToString() == "EMIRATES ID Card")
            {
                lblCardNo.Text = "Emirates ID Card No";
                lblPlaceOfIssue.Text = "Emirates ID Card Place of Issue";
                lblIssueDate.Text = "Emirates ID Card Date of Issue";
                lblExpireDate.Text = "Emirates ID Card Date of Expiry";
                RequiredFieldValidator19.Enabled = false;
                txtIssueDate.Enabled = true;
                txtIssueMonth.Enabled = true;
                txtIssueYear.Enabled =true;
                txtIssueDate.Text = "";
                txtIssueMonth.Text = "";
                txtIssueYear.Text = "";
                pnlVisaDetails.Visible = false;
            }
            if (ddlVisaType.SelectedItem.Text == "MARSOOM")
            {
                lblCardNo.Text = "Card No";
                lblPlaceOfIssue.Text = "Place of Issue";
                lblIssueDate.Text = "Date of Issue";
                lblExpireDate.Text = "Date of Expiry";
                pnlVisaDetails.Visible = false;
            }
        }
    }
    public void UpdateExperience()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.SetDropdownListAsDegreeType(10, int.Parse(Session["EId"].ToString()));        
        foreach (DataRow ro in dt.Rows)
        {
            rdbWorking.Checked = bool.Parse(ro["IsWorkExperience"].ToString());
            txtOrganizations.Text = ro["Organization"].ToString();
            txtDesignation.Text = ro["Designation"].ToString();
            txtLocationForExperience.Text = ro["Location"].ToString();
            txtCityForExperience.Text = ro["City"].ToString();
            ddlJobSector.SelectedValue = ro["JobSector"].ToString();
            ddlTypeOfJob.SelectedValue = ro["JobType"].ToString();
            txtJobProfile.Text = ro["JobProfile"].ToString();
            ddlFromMonth.SelectedValue = ro["FromMonth"].ToString();
            ddlFromYear.SelectedValue = ro["FromDate"].ToString();
            ddlToMonth.SelectedValue = ro["ToMonth"].ToString();
            ddlToYear.SelectedValue = ro["ToDate"].ToString();
            btnAddExperience.Visible = false;
            btnUpdateExp.Visible = true;
            if (ddlToMonth.SelectedIndex != 0)
                ddlToYear.Enabled = true;
            else
                ddlToYear.Enabled = false;
        }
    }
    public void UpdateQualification()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.SetDropdownListAsDegreeType(9, int.Parse(Session["QId"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            try
            {
                ddlQualification.SelectedItem.Text = ro["Qualification"].ToString();
            }
            catch
            {
            }
            txtSpecilization.Text = ro["Specilization"].ToString();
            txtUniversityName.Text = ro["UniversityName"].ToString();
            txtBoardName.Text = ro["BoardName"].ToString();

            try
            {
                ddlBoardName.SelectedItem.Text = txtBoardName.Text;


            }
            catch
            {

            }

            txtCity.Text = ro["City"].ToString();
            ddlCountry.SelectedValue = ro["Country"].ToString();
            ddlYearOfPassing.SelectedValue = ro["YearOfPass"].ToString();
            txtPercentage.Text = ro["Percentage"].ToString();
            try
            {
                chkCertificateSubmitted.Checked = bool.Parse(ro["IsCertificate"].ToString());
                Chkmilitary.Checked = bool.Parse(ro["Ismilitary"].ToString());
                ddlBachelorDegree.SelectedValue = ro["IsBusiness"].ToString();
                ddlCourseFOrQualification.SelectedValue = ro["BusinessCourse"].ToString();
                txtSubjects.Text = ro["Subject"].ToString();
                chkSpecialApproval.Checked = bool.Parse(ro["Approval"].ToString());
                txtRemarksQualification.Text = ro["Remarks"].ToString();
                if (ddlCourseFOrQualification.Text == "CHALLENGE EXAM")
                pnlChalangeExam.Visible = true;
                pnlChalange1.Visible = true;
             
                if (ddlBachelorDegree.SelectedValue != "0")
                {
                    ddlBachelorDegree.Enabled = true;

                    ddlCourseFOrQualification.Enabled = true;

                    if (ddlCourseFOrQualification.SelectedValue == "2")
                    {
                        ddlChalangeExamDate.DataSource = s.SetDropdownListCDB(69);
                        ddlChalangeExamDate.DataTextField = "Date";
                        ddlChalangeExamDate.DataValueField = "Id";
                        ddlChalangeExamDate.DataBind();
                        ddlChalangeExamTime.DataSource = s.SetDropdownListCDB(67);
                        ddlChalangeExamTime.DataTextField = "Date";
                        ddlChalangeExamTime.DataValueField = "Id";
                        ddlChalangeExamTime.DataBind();
                        pnlChalangeExam.Visible = true;
                    }
                    else if (ddlCourseFOrQualification.SelectedValue == "3")
                    {
                        ddlChalangeExamDate.DataSource = s.SetDropdownListCDB(68);
                        ddlChalangeExamDate.DataTextField = "Date";
                        ddlChalangeExamDate.DataValueField = "Id";
                        ddlChalangeExamDate.DataBind();
                        ddlChalangeExamTime.DataSource = s.SetDropdownListCDB(66);
                        ddlChalangeExamTime.DataTextField = "Date";
                        ddlChalangeExamTime.DataValueField = "Id";
                        ddlChalangeExamTime.DataBind();
                        //New For Seven Course
                        ddlMqpDate11.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate11.DataTextField = "Date";
                        ddlMqpDate11.DataValueField = "Id";
                        ddlMqpDate11.DataBind();
                        ddlMqpTime11.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime11.DataTextField = "Date";
                        ddlMqpTime11.DataValueField = "Id";
                        ddlMqpTime11.DataBind();

                        ddlMqpDate12.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate12.DataTextField = "Date";
                        ddlMqpDate12.DataValueField = "Id";
                        ddlMqpDate12.DataBind();
                        ddlMqpTime12.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime12.DataTextField = "Date";
                        ddlMqpTime12.DataValueField = "Id";
                        ddlMqpTime12.DataBind();

                        ddlMqpDate13.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate13.DataTextField = "Date";
                        ddlMqpDate13.DataValueField = "Id";
                        ddlMqpDate13.DataBind();
                        ddlMqpTime13.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime13.DataTextField = "Date";
                        ddlMqpTime13.DataValueField = "Id";
                        ddlMqpTime13.DataBind();

                        ddlMqpDate14.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate14.DataTextField = "Date";
                        ddlMqpDate14.DataValueField = "Id";
                        ddlMqpDate14.DataBind();
                        ddlMqpTime14.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime14.DataTextField = "Date";
                        ddlMqpTime14.DataValueField = "Id";
                        ddlMqpTime14.DataBind();

                        ddlMqpDate15.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate15.DataTextField = "Date";
                        ddlMqpDate15.DataValueField = "Id";
                        ddlMqpDate15.DataBind();
                        ddlMqpTime15.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime15.DataTextField = "Date";
                        ddlMqpTime15.DataValueField = "Id";
                        ddlMqpTime15.DataBind();


                        ddlMqpDate16.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate16.DataTextField = "Date";
                        ddlMqpDate16.DataValueField = "Id";
                        ddlMqpDate16.DataBind();
                        ddlMqpTime16.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime16.DataTextField = "Date";
                        ddlMqpTime16.DataValueField = "Id";
                        ddlMqpTime16.DataBind();

                        ddlMqpDate17.DataSource = s.SetDropdownListCDB(68);
                        ddlMqpDate17.DataTextField = "Date";
                        ddlMqpDate17.DataValueField = "Id";
                        ddlMqpDate17.DataBind();
                        ddlMqpTime17.DataSource = s.SetDropdownListCDB(66);
                        ddlMqpTime17.DataTextField = "Date";
                        ddlMqpTime17.DataValueField = "Id";
                        ddlMqpTime17.DataBind();
                        //Ends Here
                        pnlChalangeExam.Visible = true;
                        ddlCourseFOrQualification.SelectedValue = "3";
                    }
                    else
                        pnlChalangeExam.Visible = false;
                }
            }
            catch
            {
            }
            txtCGPA.Text = ro["CGPA"].ToString();
            btnAddQualification.Visible = false;
            btnUpdateQualification.Visible = true;
        }
        try
        {
            DataTable dttt = new DataTable();
            dttt = s.BindGrid(1);
            foreach (DataRow ro in dttt.Rows)
            {
                chkMqp11.Checked = bool.Parse(ro["Subject1"].ToString());
                chkMqp12.Checked = bool.Parse(ro["Subject2"].ToString());
                chkMqp13.Checked = bool.Parse(ro["Subject3"].ToString());
                chkMqp14.Checked = bool.Parse(ro["Subject4"].ToString());
                chkMqp15.Checked = bool.Parse(ro["Subject5"].ToString());
                chkMqp16.Checked = bool.Parse(ro["Subject6"].ToString());
                chkMqp17.Checked = bool.Parse(ro["Subject7"].ToString());
                ddlMqpDate11.SelectedItem.Text = ro["Date1"].ToString();
                ddlMqpDate12.SelectedItem.Text = ro["Date2"].ToString();
                ddlMqpDate13.SelectedItem.Text = ro["Date3"].ToString();
                ddlMqpDate14.SelectedItem.Text = ro["Date4"].ToString();
                ddlMqpDate15.SelectedItem.Text = ro["Date5"].ToString();
                ddlMqpDate16.SelectedItem.Text = ro["Date6"].ToString();
                ddlMqpDate17.SelectedItem.Text = ro["Date7"].ToString();
                ddlMqpTime11.SelectedItem.Text = ro["Time1"].ToString();
                ddlMqpTime12.SelectedItem.Text = ro["Time2"].ToString();
                ddlMqpTime13.SelectedItem.Text = ro["Time3"].ToString();
                ddlMqpTime14.SelectedItem.Text = ro["Time4"].ToString();
                ddlMqpTime15.SelectedItem.Text = ro["Time5"].ToString();
                ddlMqpTime16.SelectedItem.Text = ro["Time6"].ToString();
                ddlMqpTime17.SelectedItem.Text = ro["Time7"].ToString();
            }            
        }
        catch
        {

        }
    }
    public void UpdateTOC()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = new DataTable();
        dt = s.SetDropdownListAsDegreeType(8, int.Parse(Session["TId"].ToString()));
        foreach (DataRow ro in dt.Rows)
        {
            ddlTransferUniversity.SelectedValue = ro["TOCCase"].ToString();
            ddlDocumentProcess.SelectedValue = ro["DocumentProcess"].ToString();
            txtUniversityNameProgram.Text = ro["UniversityName"].ToString();
            txtTotalNoOfCourse.Text = ro["TotalNoOfCourse"].ToString();
            txtUnderTakingForToc.Text = ro["UnderTaking"].ToString();
            txtUniversityAttended.Text = ro["UniversityAttended"].ToString();
            txtFollowYear.Text = DateTime.Parse(ro["FollowDate"].ToString()).Year.ToString();
            txtFollowMonth.Text = DateTime.Parse(ro["FollowDate"].ToString()).Month.ToString();
            txtFollowDate.Text = DateTime.Parse(ro["FollowDate"].ToString()).Day.ToString();
            txtFinanceDetails.Text = ro["FinaceDetails"].ToString();
            txtFeesPaid.Text = ro["FeesPaid"].ToString();
            txtReceiptNo.Text = ro["ReceiptNo"].ToString();
            txtYear.Text = DateTime.Parse(ro["Date"].ToString()).Year.ToString();
            txtMonth.Text = DateTime.Parse(ro["Date"].ToString()).Month.ToString();
            txtDate.Text = DateTime.Parse(ro["Date"].ToString()).Day.ToString();
            chkCDD.Checked = bool.Parse(ro["CDD"].ToString());
            chkTranscript.Checked = bool.Parse(ro["Transcript"].ToString());
            chkLetter.Checked = bool.Parse(ro["letter"].ToString());
            Chkmqptoc.Checked = bool.Parse(ro["mqptoc"].ToString());

            try
            {


                ddlUniversityName.SelectedItem.Text = ro["UniversityName"].ToString();

            }
            catch
            {

            }



            try
            {
                txtCGPATOC.Text = (decimal.Parse(ro["CGPA"].ToString())).ToString("0.0");
            }
            catch
            {
            }
            btnSubmitToc.Visible = false;
            btnUpdateToc.Visible = true;
            btnDeleteTOC.Visible = true;
        }
    }
    protected void btnUpdateVisa_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        try
        {
            string fileName1 = "";
            DateTime dt = new DateTime();
            if (fuVisaInfo.PostedFile != null && fuVisaInfo.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuVisaInfo.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuVisaInfo.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            if (ddlVisaType.SelectedItem.Text != "National ID Card" )
            {
                if (DateTime.Parse(txtIssueYear.Text + "/" + txtIssueMonth.Text + "/" + txtIssueDate.Text) > DateTime.Parse(txtExpireYear.Text + "/" + txtExpireMonth.Text + "/" + txtExpireDate.Text))
                {
                    lblVisaInfoMesag.Text = "Expiry date should be greater than Issue date!!!";
                    lblVisaInfoMesag.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                dt = DateTime.Parse(txtIssueYear.Text + "/" + txtIssueMonth.Text + "/" + txtIssueDate.Text);
            }
            else
            {
                dt = DateTime.Now;
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.UpdateVisaInfo(Session["VId"].ToString(), ddlVisaType.SelectedItem.Text, txtTypeofvisa.Text, txtSponsor.Text, txtCardNo.Text, txtPlaceOfIssue.Text, dt,
                DateTime.Parse(txtExpireYear.Text + "/" + txtExpireMonth.Text + "/" + txtExpireDate.Text), ddlCountryOfIssue.SelectedValue, fileName1);
            lblVisaInfoMesag.Text = "Successfully Updated!!!";
            lblVisaInfoMesag.ForeColor = System.Drawing.Color.Blue;
            SetVisa();
            ddlVisaType.SelectedIndex = 0;
            txtTypeofvisa.Text = "";
            txtSponsor.Text = "";
            txtCardNo.Text = "";
            txtPlaceOfIssue.Text = "";
            txtIssueYear.Text = "";
            txtIssueMonth.Text = "";
            txtIssueDate.Text = "";
            txtExpireYear.Text = "";
            txtExpireMonth.Text = "";
            txtExpireDate.Text = "";
            ddlCountryOfIssue.SelectedIndex = 0;
            btnUpdateVisa.Visible = false;
            btnSubmitVisaInfo.Visible = true;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblVisaInfoMesag.Text = "Please Try Again!!!";
            lblVisaInfoMesag.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdateExp_Click(object sender, EventArgs e)
    {
        try
        {
            string TillMonth = DateTime.Now.Month.ToString();
            string TillYear = DateTime.Now.Year.ToString();
            if (ddlToMonth.SelectedItem.Text != "Till Date")
            {
                TillMonth = ddlToMonth.SelectedItem.Text;
                TillYear = ddlToYear.SelectedItem.Text;
            }
            if (DateTime.Parse(TillYear + "/" + TillMonth + "/1") < DateTime.Parse(ddlFromYear.SelectedItem.Text + "/" + ddlFromMonth.SelectedItem.Text + "/1"))
            {
                lblMesagExperience.Text = "Oops! To date should be greater than from date.";
                lblMesagExperience.ForeColor = System.Drawing.Color.Red;
                return;
            }

            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.UpdateExperience(Session["EId"].ToString(), rdbWorking.Checked, txtOrganizations.Text, txtDesignation.Text, txtLocationForExperience.Text, txtCityForExperience.Text,
                    ddlJobSector.SelectedValue, ddlTypeOfJob.SelectedValue, txtJobProfile.Text, ddlFromMonth.SelectedValue, ddlFromYear.SelectedValue, ddlToMonth.SelectedValue, ddlToYear.SelectedValue);
            lblMesagExperience.Text = "Successfully Updated!!!";
            lblMesagExperience.ForeColor = System.Drawing.Color.Blue;
            SetExperience();
            txtOrganizations.Text = "";
            txtDesignation.Text = "";
            txtLocationForExperience.Text = "";
            txtCityForExperience.Text = "";
            ddlJobSector.SelectedIndex = 0;
            ddlTypeOfJob.SelectedIndex = 0;
            txtJobProfile.Text = "";
            ddlFromMonth.SelectedIndex = 0;
            ddlFromYear.SelectedIndex = 0;
            ddlToMonth.SelectedIndex = 0;
            ddlToYear.SelectedIndex = 0;
            btnUpdateExp.Visible = false;
            btnAddExperience.Visible = true;
        }
        catch
        {
            lblMesagExperience.Text = "Oops! Please Try Again.";
            lblMesagExperience.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdateRemarks_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.UpdateRemarks(Session["RId"].ToString(), ddlRemarksType.SelectedValue, txtDetailsRemarks.Text);
            lblMesagRemarks.Text = "Sucessfully Updated!!!";
            lblMesagRemarks.ForeColor = System.Drawing.Color.Blue;
            SetRemarks();
            ddlRemarksType.SelectedIndex = 0;
            txtDetailsRemarks.Text = "";
            btnUpdateRemarks.Visible = false;
            btnAddRemarks.Visible = true;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagRemarks.Text = "Please Try Again!!!";
            lblMesagRemarks.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdateQualification_Click(object sender, EventArgs e)
    {
        try
        {
            string LinkId = "0";
            try
            {
                LinkId = Request.QueryString["Id"].ToString();
            }
            catch
            {
            }
            string fileName1 = "";
            if (fuQualification.PostedFile != null && fuQualification.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuQualification.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuQualification.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Bacheclor = ddlBachelorDegree.SelectedValue;


            try
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
                {
                    DataTable dt1 = s.GetMilitaryReq(Request.QueryString["Id"].ToString(), ddlYearOfPassing.SelectedItem.Text);
                    if (dt1.Rows.Count != 0)
                    {
                        if (int.Parse(dt1.Rows[0][1].ToString()) == 1)
                        {

                            if (Chkmilitary.Checked == false)
                            {
                                lblMesagQualification.Text = "Please Check the option  Clearance from Military and Upload documents";
                                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                                pnlmilitary.Visible = true;
                                return;
                            }

                            else if (Chkmilitary.Checked == true)
                            {
                                if (fuQualification.HasFile == false)
                                {
                                    lblMesagQualification.Text = "Please upload documents for Clearance from Military";
                                    lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                                    pnlmilitary.Visible = true;
                                    return;

                                }
                            }
                        }

                    }
                    else
                    {
                        pnlmilitary.Visible = false;
                    }



                }
            }

            catch
            {
                lblMesagQualification.Text = "Please Try again";
                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                return;
            }







           if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
                Bacheclor = ddlQualification.SelectedValue;
            if (txtSubjects.Text == "")
                txtSubjects.Text = "0";
            DataTable dt = s.GetCGPA(Request.QueryString["Id"].ToString(), Bacheclor, decimal.Parse(txtCGPA.Text), txtPercentage.Text, txtSubjects.Text, ddlYearOfPassing.SelectedItem.Text, int.Parse(ddlCourseFOrQualification.SelectedValue));
            
            if (dt.Rows.Count != 0)
            {
                lblMesagQualification.Text = dt.Rows[0][2].ToString();
                if (int.Parse(dt.Rows[0][1].ToString()) == 1)
                {
                    btnAddQualification.Enabled = false;
                    lblMesagQualification.ForeColor = System.Drawing.Color.Red; 
                    if (chkRejected.Checked == false)
                    {
                        return;
                    }
                    else
                    {
                        if (txtRemarksQualification.Text == "")
                        {
                            return;
                        }
                    }
                    if (chkSpecialApproval.Checked == true)
                    {
                        if (txtRemarksQualification.Text == "")
                        {
                            return;
                        }
                    }
                }
                else
                {
                    btnAddQualification.Enabled = true;
                    lblMesagQualification.ForeColor = System.Drawing.Color.Blue;
                }
            }

            if (int.Parse(ddlYearOfPassing.SelectedItem.Text) > DateTime.Now.Year)
            {
                lblMesagQualification.Text = "Year of passing should not greater than current year!!!";
                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                return;
            }
            DateTime dob = s.GetDOB(Request.QueryString["Id"].ToString());
            int YOP = dob.AddYears(16).Year;
            if (int.Parse(ddlYearOfPassing.SelectedItem.Text) < YOP)
            {
                lblMesagQualification.Text = "Year of passing should not greater than Date of Birth!!!";
                lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (int.Parse(ddlQualification.SelectedValue) == 6)
            {
                int Year = s.GetBachelorDegreeYear(Request.QueryString["Id"].ToString());
                if (Year <= int.Parse(ddlYearOfPassing.SelectedValue))
                {
                    lblMesagQualification.Text = "Year of passing should not greater than Bachelor Degree Passed Year!!!";
                    lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            if (txtCGPA.Text == "")
            {
                txtCGPA.Text = "0";
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();

            txtBoardName.Text = ddlBoardName.SelectedItem.Text;

            string Result = d.UpdateQualification(Session["QId"].ToString(), ddlQualification.SelectedItem.Text, txtSpecilization.Text, txtUniversityName.Text, txtBoardName.Text, txtCity.Text, ddlCountry.SelectedValue, ddlYearOfPassing.SelectedValue, txtPercentage.Text, ddlBachelorDegree.SelectedValue, ddlCourseFOrQualification.SelectedValue, chkCertificateSubmitted.Checked, decimal.Parse(txtCGPA.Text), txtSubjects.Text, chkSpecialApproval.Checked, txtRemarksQualification.Text, fileName1, Chkmilitary.Checked);
            try
            {
                if (ddlCourseFOrQualification.SelectedValue == "3")
                {
                    Result = d.InsertMQPSubjectQ(LinkId, chkMqp11.Checked, chkMqp12.Checked, chkMqp13.Checked, chkMqp14.Checked, chkMqp15.Checked, chkMqp16.Checked, chkMqp17.Checked, ddlMqpDate11.SelectedItem.Text, ddlMqpDate12.SelectedItem.Text, ddlMqpDate13.SelectedItem.Text, ddlMqpDate14.SelectedItem.Text, ddlMqpDate15.SelectedItem.Text, ddlMqpDate16.SelectedItem.Text, ddlMqpDate17.SelectedItem.Text, ddlMqpTime11.SelectedItem.Text, ddlMqpTime12.SelectedItem.Text, ddlMqpTime13.SelectedItem.Text, ddlMqpTime14.SelectedItem.Text, ddlMqpTime15.SelectedItem.Text, ddlMqpTime16.SelectedItem.Text, ddlMqpTime17.SelectedItem.Text, int.Parse(Session["EmpId"].ToString()));
                }
                else
                {
                    s.UpdateOtherQualification(Request.QueryString["Id"].ToString(), int.Parse(ddlChalangeExamDate.SelectedValue), int.Parse(ddlChalangeExamTime.SelectedValue));
                }
            }
            catch
            {
            }
            lblMesagQualification.Text = "Successfully Updated!!!";
            lblMesagQualification.ForeColor = System.Drawing.Color.Blue;
            SetQualification();
            ddlQualification.SelectedIndex = 0;
            txtSpecilization.Text = "";
            txtUniversityName.Text = "";
            ddlBoardName.SelectedIndex = 0;
            txtBoardName.Text = "";
            txtCity.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlYearOfPassing.SelectedIndex = 0;
            txtPercentage.Text = "";
            btnAddQualification.Visible = true;
            btnUpdateQualification.Visible = false;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblMesagQualification.Text = "Please Try Again!!!";
            lblMesagQualification.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnUpdateTOC_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlUniversityName.SelectedIndex == 0)
            {
                lblTOCMesag.Text = "University Required!!!";
                return;
            }
            if (ddlUniversityName.SelectedItem.Text.Contains("HCT"))
            {
                if (txtCGPATOC.Text == "")
                {
                    lblTOCMesag.Text = "CGPA Required!!!";
                    return;
                }
            }
            string LinkId = "0";
            try
            {
                LinkId = Request.QueryString["Id"].ToString();
            }
            catch
            {
            }
            string fileName1 = "";
            if (fuVisaInfo.PostedFile != null && fuVisaInfo.PostedFile.ContentLength > 0)
            {
                fileName1 = Path.GetFileName(fuVisaInfo.PostedFile.FileName);
                string folder = Server.MapPath("~/Documents/" + LinkId + "/");
                Directory.CreateDirectory(folder);
                fuVisaInfo.PostedFile.SaveAs(Path.Combine(folder, fileName1));
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.UpdateTOC(Session["TId"].ToString(), ddlTransferUniversity.SelectedValue, ddlDocumentProcess.SelectedValue, txtUniversityNameProgram.Text, txtTotalNoOfCourse.Text,
                txtUnderTakingForToc.Text, txtUniversityAttended.Text, DateTime.Parse(txtFollowYear.Text + "/" + txtFollowMonth.Text + "/" + txtFollowDate.Text), txtFinanceDetails.Text,
                txtFeesPaid.Text, txtReceiptNo.Text, DateTime.Parse(txtYear.Text + "/" + txtMonth.Text + "/" + txtDate.Text), decimal.Parse(txtCGPATOC.Text), fileName1, chkCDD.Checked, chkTranscript.Checked, chkLetter.Checked, Chkmqptoc.Checked);
            lblTOCMesag.Text = "Successfully Updated!!!";
            SetToc();
            ddlTransferUniversity.SelectedIndex = 0;
            ddlDocumentProcess.SelectedIndex = 0;
            txtUniversityNameProgram.Text = "";
            txtTotalNoOfCourse.Text = "";
            txtUnderTakingForToc.Text = "";
            txtUniversityAttended.Text = "";
            txtFollowYear.Text = "";
            txtFollowMonth.Text = "";
            txtFollowDate.Text = "";
            txtFinanceDetails.Text = "";
            txtFeesPaid.Text = "";
            txtReceiptNo.Text = "";
            txtYear.Text = "";
            txtMonth.Text = "";
            txtDate.Text = "";
            txtCGPA.Text = "";
            btnUpdateToc.Visible = false;
            btnDeleteTOC.Visible = false;
            btnSubmitToc.Visible = true;
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }
        }
        catch
        {
            lblTOCMesag.Text = "Oops! Please Try Again.";
            lblTOCMesag.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void ddlPortOflastentry_changed(object sender, EventArgs e)
    {
        if (int.Parse(ddlPortOflastentry.SelectedValue) == 9)
        {
            txtDateOfLastEntryDate.Text = "01";
            txtDateOfLastEntryMonth.Text = "01";
            txtDateOfLastEntryYear.Text = "1900";
        }

    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        SearchString = txtSearch.Text;
        Me4.Show();

    }
    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
        RegExp.Replace("/", "");
        // Highlight keywords by calling the 
        //delegate each time a keyword is found.
        Me4.Show();
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
       
    }

    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //  Set the value of the SearchString so it gets
        SearchString = txtSearch.Text;
        Me4.Show();
    }

    protected void gvDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        Me4.Show();
    }
    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                //Response.Redirect(string.Format("FollowUp.aspx?Id={0}", Id), false);
                Txtstud.Text = Id;
                Me4.Hide();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnksearch_click(object sender, EventArgs e)
    {
       Session["EMPID1"] = Session["EMPID"].ToString();

                
                    Session["EMPID1"] = "0";
                      //dsDetails.SelectParameters.Add("empid", Session["EMPID1"].ToString());               
          
        Me4.Show();

    }
    protected void btnDeleteTOC_Click(object sender, EventArgs e)
    {
        try
        {
            string LinkId = "0";
            try
            {
                LinkId = Request.QueryString["Id"].ToString();
            }
            catch
            {
            }
            StudentRegistrationDAL d = new StudentRegistrationDAL();
            string Result = d.DeleteTable(int.Parse(Session["TId"].ToString()) , 1);
            lblTOCMesag.Text = "Successfully Updated!!!";
            SetToc();
            ddlTransferUniversity.SelectedIndex = 0;
            ddlDocumentProcess.SelectedIndex = 0;
            txtUniversityNameProgram.Text = "";
            txtTotalNoOfCourse.Text = "";
            txtUnderTakingForToc.Text = "";
            txtUniversityAttended.Text = "";
            txtFollowYear.Text = "";
            txtFollowMonth.Text = "";
            txtFollowDate.Text = "";
            txtFinanceDetails.Text = "";
            txtFeesPaid.Text = "";
            txtReceiptNo.Text = "";
            txtYear.Text = "";
            txtMonth.Text = "";
            txtDate.Text = "";
            txtCGPA.Text = "";
            btnUpdateToc.Visible = false;
            btnDeleteTOC.Visible = false;
            btnSubmitToc.Visible = true;
            try
            {
                ddlUniversityName.SelectedIndex = -1;
            }
            catch
            {

            }
            try
            {
                InsertFeeGroup();
            }
            catch
            {
            }


        }
        catch
        {
            lblTOCMesag.Text = "Oops! Please Try Again.";
            lblTOCMesag.ForeColor = System.Drawing.Color.Red;
        }
    }




    protected void GvTOC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            
        
        
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["TId"] = Id.ToString();
            UpdateTOC();
            lblTOCMesag.Text = "";
            pnlCgpAToc.Visible = true;
            
        }
        if (e.CommandName.Equals("DownLoad"))
        {
            string FileName = e.CommandArgument.ToString();
            lblTOCMesag.Text = "";
            if (FileName != "")
                Response.Redirect("../Documents/" + Request.QueryString["Id"].ToString() + "/" + FileName + "", false);
        }
    }
    protected void GvRemarks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSN = (Label)e.Row.FindControl("lblSN");
            lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string LinkId = "0";
        try
        {
            LinkId = Request.QueryString["Id"].ToString();
        }
        catch
        {
        }
        Response.Redirect("PrintOffLine.aspx?id=1&Val=" + LinkId, false);
    }
    protected void ddlDegreeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourse();
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (ddlDegreeType.SelectedValue == "9")
        {
            try
            {
                ddlTerm.Items.Clear();
                ddlTerm.DataSource = s.SetDropdownListCDB(100);
                ddlTerm.DataTextField = "Term";
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataBind();
                ddlTerm.Enabled = true;
            }
            catch
            {
            }
        }

        if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
        {
            chkMQPCourse.Visible = false;
            chkMQPCourse.Checked = false;
        }
        else
        {
            chkMQPCourse.Visible = false;
        }
        if (ddlDegreeType.SelectedValue == "9")
        {
            pnlSC.Visible = true;
            //ddlTerm.Enabled = false;
            pnlHideEntrance.Visible = false;
            PnlHideToefl.Visible = false;
        }
        else
        {
            pnlSC.Visible = false;
            ddlTerm.Enabled = true;
            pnlHideEntrance.Visible = true;
            PnlHideToefl.Visible = true;
        }
        if (ddlDegreeType.SelectedValue == "8")
        {
            pnlHideEntrance.Visible = false;
        }
        else if (ddlDegreeType.SelectedValue == "6")
        {
            pnlHideEntrance.Visible = false;
        }
        else
            if (ddlDegreeType.SelectedValue != "9")
            {
                pnlHideEntrance.Visible = true;
            }
     
        if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
        {
            ddlType.DataSource = s.SetDropdownListCDB(94);
        }
        else
        {
            ddlType.DataSource = s.SetDropdownListCDB(74);
        }
        ddlType.DataTextField = "FeeWaiverType";
        ddlType.DataValueField = "Id";
        ddlType.DataBind();
    }
    protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            try
            {
                if (Convert.ToString(ddlDiscountType.SelectedItem.Text).Contains("SHARJAH"))
                {
                    pnl_show.Visible = true;
                }

                else
                {
                    pnl_show.Visible = false;
                }


                if (Convert.ToString(ddlDiscountType.SelectedItem.Text).Contains("SHARJAH HRD"))
                {
                    pnl_Hrd.Visible = true;
                }

                else
                {
                    ddlHrdDepartment.SelectedIndex = -1;
                    pnl_Hrd.Visible = false;
                }



                if (ddlDegreeType.SelectedValue != "9")
                {

                     if (chkintegrated.Checked == true)
                        {
                         DataTable dt11 = s.GetMouPercentageintegrate(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                        if (dt11.Rows.Count != 1)
                        {

                            ddlPercentage.DataSource = s.GetMouPercentageintegrate(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                            ddlPercentage.DataTextField = "FeeWaiverType";
                            ddlPercentage.DataValueField = "FeeWaiverType";
                            ddlPercentage.DataBind();

                        }
                     }
                        else
                        {


                    DataTable dt1 = s.GetMouPercentage(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                    if (dt1.Rows.Count != 1)
                    {

                        ddlPercentage.DataSource = s.GetMouPercentage(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                        ddlPercentage.DataTextField = "FeeWaiverType";
                        ddlPercentage.DataValueField = "FeeWaiverType";
                        ddlPercentage.DataBind();

                        if (ddlTransferUniversity.SelectedItem.Text == "Yes")
                        {
                            try
                            {
                                ddlPercentage.DataSource = s.GetMouPercentagetoc(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                                ddlPercentage.DataTextField = "FeeWaiverType";
                                ddlPercentage.DataValueField = "FeeWaiverType";
                                ddlPercentage.DataBind();

                            }
                            catch
                            {
                                ddlPercentage.Items.Clear();
                                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                                ddlPercentage.Items.Add(new ListItem("10", "10"));
                                ddlPercentage.Items.Add(new ListItem("15", "15"));
                                ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                                ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                                ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                                ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                                ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                                ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));


                            }


                        }
                    }
                    else
                    {

                        if (ddlTransferUniversity.SelectedItem.Text == "Yes")
                        {

                            ddlPercentage.Items.Clear();
                            ddlPercentage.Items.Add(new ListItem("Select", "0"));
                            ddlPercentage.Items.Add(new ListItem("10", "10"));
                            ddlPercentage.Items.Add(new ListItem("15", "15"));
                            ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                            ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                            ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                            ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                            ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                            ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));


                        }
                        else
                        {

                            ddlPercentage.Items.Clear();
                            ddlPercentage.Items.Add(new ListItem("Select", "0"));
                            ddlPercentage.Items.Add(new ListItem("10", "10"));
                            ddlPercentage.Items.Add(new ListItem("15", "15"));
                            ddlPercentage.Items.Add(new ListItem("25", "25"));
                            ddlPercentage.Items.Add(new ListItem("50", "50"));
                            ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                            ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                            ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                            ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                            ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                            ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));
                            ddlPercentage.Items.Add(new ListItem("100", "100"));
                        }
                    }
                }

                }
                else
                {

                    ddlPercentage.Items.Clear();
                    ddlPercentage.Items.Add(new ListItem("Select", "0"));
                    if (ddlType.SelectedValue != "134")
                    {
                        ddlPercentage.Items.Add(new ListItem("5", "5"));
                        ddlPercentage.Items.Add(new ListItem("10", "10"));
                        ddlPercentage.Items.Add(new ListItem("15", "15"));
                    }
                }
            }
            catch
            {

            }

            ddlPercentage_SelectedIndexChanged(sender, e);


            //DataTable dt = s.SetDropdownListAsDegreeType(5, int.Parse(ddlDiscountType.SelectedValue));
            //foreach (DataRow ro in dt.Rows)
            //{
            //txtFees.Text = "0.00";// (decimal.Parse(ro["TotalFees"].ToString())).ToString("0.00");
            ///txtDiscount.Text = "0.00"; //(decimal.Parse(ro["Discount"].ToString())).ToString("0.00");
            //txtTotalFees.Text = "0.00";//(decimal.Parse(ro["NetPayable"].ToString())).ToString("0.00");
            //txtAvailableFund.Text = "0.00";//(decimal.Parse(ro["FundAllocated"].ToString()) - decimal.Parse(ro["FundConsumed"].ToString())).ToString("0.00");
            //if (decimal.Parse(ro["FundExceed"].ToString()) < decimal.Parse(txtDiscount.Text))
            //{
            //    lblMesagProgram.Text = "There is not enough Fund for this Fee Waiver!";
            //}
            //}
            //txtDiscount.Text = (s.GetFeesAmount(int.Parse(ddlDiscountType.SelectedValue))).ToString("0.00");
            //txtTotalFees.Text = txtDiscount.Text;
            //txtAvailableFund.Text = (decimal.Parse(txtFees.Text) - (s.GetUsedFees(int.Parse(ddlDiscountType.SelectedValue)) + decimal.Parse(txtDiscount.Text))).ToString("0.00");
            //if (decimal.Parse(txtAvailableFund.Text) < 0)
            //{
            //    lblMesagProgram.Text = "There is not enough Fund for this Fee Waiver!";
            //}
        }
        catch
        {
        }
    }


    protected void rad_family_checked_changed(object sender, EventArgs e)
    {
        pnl_dropdown.Visible = true;
    }

    protected void rad_self_checked_changed(object sender, EventArgs e)
    {
        pnl_dropdown.Visible = false;

    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {           
                pnl_show.Visible = false;
            

            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetDropdownListAsDegreeType(24, int.Parse(ddlType.SelectedValue));
            ddlDiscountType.DataSource = dt;
            ddlDiscountType.DataTextField = "Description";
            ddlDiscountType.DataValueField = "id";
            ddlDiscountType.DataBind();
            //txtFees.Text = (s.GetBudget(int.Parse(ddlType.SelectedValue))).ToString("0.00");
            if (ddlDegreeType.SelectedValue != "9")
            {

                if (chkintegrated.Checked == true)
                {
                    DataTable dt11 = s.GetMouPercentageintegrate(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                    if (dt11.Rows.Count != 1)
                    {

                        ddlPercentage.DataSource = s.GetMouPercentageintegrate(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue));
                        ddlPercentage.DataTextField = "FeeWaiverType";
                        ddlPercentage.DataValueField = "FeeWaiverType";
                        ddlPercentage.DataBind();

                    }
                }
                else
                {

                    DataTable dt1 = s.GetMouPercentage(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlType.SelectedValue));
                    if (dt1.Rows.Count != 1)
                    {

                        ddlPercentage.DataSource = s.GetMouPercentage(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlType.SelectedValue));
                        ddlPercentage.DataTextField = "FeeWaiverType";
                        ddlPercentage.DataValueField = "FeeWaiverType";
                        ddlPercentage.DataBind();

                        if (ddlTransferUniversity.SelectedItem.Text == "Yes")
                        {
                            try
                            {
                                ddlPercentage.DataSource = s.GetMouPercentagetoc(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlType.SelectedValue));
                                ddlPercentage.DataTextField = "FeeWaiverType";
                                ddlPercentage.DataValueField = "FeeWaiverType";
                                ddlPercentage.DataBind();

                            }
                            catch
                            {
                                ddlPercentage.Items.Clear();
                                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                                ddlPercentage.Items.Add(new ListItem("10", "10"));
                                ddlPercentage.Items.Add(new ListItem("15", "15"));
                                ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                                ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                                ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                                ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                                ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                                ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));


                            }


                        }
                    }
                    else
                    {

                        if (ddlTransferUniversity.SelectedItem.Text == "Yes")
                        {

                            ddlPercentage.Items.Clear();
                            ddlPercentage.Items.Add(new ListItem("Select", "0"));
                            ddlPercentage.Items.Add(new ListItem("10", "10"));
                            ddlPercentage.Items.Add(new ListItem("15", "15"));
                            ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                            ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                            ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                            ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                            ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                            ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));


                        }
                        else
                        {

                            ddlPercentage.Items.Clear();
                            ddlPercentage.Items.Add(new ListItem("Select", "0"));
                            ddlPercentage.Items.Add(new ListItem("10", "10"));
                            ddlPercentage.Items.Add(new ListItem("15", "15"));
                            ddlPercentage.Items.Add(new ListItem("25", "25"));
                            ddlPercentage.Items.Add(new ListItem("50", "50"));
                            ddlPercentage.Items.Add(new ListItem("4.2", "4.2"));
                            ddlPercentage.Items.Add(new ListItem("6.25", "6.25"));
                            ddlPercentage.Items.Add(new ListItem("6.35", "6.35"));
                            ddlPercentage.Items.Add(new ListItem("7.94", "7.94"));
                            ddlPercentage.Items.Add(new ListItem("8.33", "8.33"));
                            ddlPercentage.Items.Add(new ListItem("9.21", "9.21"));
                            ddlPercentage.Items.Add(new ListItem("100", "100"));
                        }
                    }
                }
             
            }
            else
            {

                ddlPercentage.Items.Clear();
                ddlPercentage.Items.Add(new ListItem("Select", "0"));
                if (ddlType.SelectedValue != "134")
                {
                    ddlPercentage.Items.Add(new ListItem("5", "5"));
                    ddlPercentage.Items.Add(new ListItem("10", "10"));
                    ddlPercentage.Items.Add(new ListItem("15", "15"));
                }
            }

            if (ddlType.SelectedValue == "132")
                chkNauFees.Checked = true;
            else
                chkNauFees.Checked = false;


             try
            {
                if (ddlType.SelectedItem.Text.ToString().Contains("ALUMNI") || ddlType.SelectedItem.Text.ToString().Contains("SIBLINGS") || ddlType.SelectedItem.Text.ToString().Contains("BBA"))
                {
                    Txtstud.Text = "";
                    pnlsucalum.Visible = true;
                }
                    else
                                 {
                                     pnlsucalum.Visible = false ;
                                 }
               
            }
            catch
            {

            }






        }
        catch
        {
        }
    }
    protected void ddlPercentage_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMesagProgram.Text = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        try
        {

            DataTable dt = s.GetMouFund(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(ddlDiscountType.SelectedValue), double.Parse(ddlPercentage.SelectedValue));
            try
            {
                txtFees.Text = dt.Rows[0][0].ToString();

                if (txtFees.Text == "0")
                    txtFees.Text = "0";
            }
            catch
            {
                txtFees.Text = "0";
            }
            try
            {
                txtAvailableFund.Text = dt.Rows[0][1].ToString();

                if (txtAvailableFund.Text == "0")
                    txtAvailableFund.Text = "0";
            }
            catch
            {
                txtAvailableFund.Text = "0";
            }
            try
            {
                txtBalanceFund.Text = (decimal.Parse(dt.Rows[0][0].ToString()) - decimal.Parse(dt.Rows[0][1].ToString())).ToString();
            }
            catch
            {
                txtBalanceFund.Text = "0";
            }
            try
            {
                if (ddlDegreeType.SelectedValue != "9")
                {
                    txtDiscount.Text = (s.GetTotalFees(int.Parse(ddlDegreeType.SelectedValue), int.Parse(ddlTerm.SelectedValue), double.Parse(ddlPercentage.SelectedValue))).ToString();
                    if ((txtDiscount.Text == "0") && (ddlPercentage.SelectedValue != "0"))
                    {

                        lblMesagProgram.Text = "Fee Waiver is not assigned Please select other Option!";
                        return;
                    }
                }
                else
                    txtDiscount.Text = ((decimal.Parse(txtTotalFees.Text) * decimal.Parse(ddlPercentage.SelectedValue)) / 100).ToString();
                if (txtDiscount.Text == "")
                    txtDiscount.Text = "0";
            }
            catch
            {
                txtDiscount.Text = "0";
                txtNetFees.Text = (decimal.Parse(txtTotalFees.Text) - decimal.Parse(txtDiscount.Text)).ToString();
                lblMesagProgram.Text = "Fee Waiver is not assigned Please select other Option!";
                return;

            }

            txtNetFees.Text = (decimal.Parse(txtTotalFees.Text) - decimal.Parse(txtDiscount.Text)).ToString();
        }
        catch
        {
        }


        try
        {



            int tococunt = s.GetTOCAPPLICABLE(int.Parse(Request.QueryString["Id"].ToString()));
            if (ddlDiscountType.SelectedValue == "22")
            {
                if ((tococunt != 0) && (double.Parse(ddlPercentage.SelectedValue) > 25.0))
                {

                    btnSaveFinance.Enabled = false;
                    lblMesagProgram.Text = "Fee Waiver greater than 25 % is not allowed for TOC case!";
                    return;
                }
                //}
                else
                {
                    btnSaveFinance.Enabled = true;
                    lblMesagProgram.Text = "";

                }
            }
            else
            {


                if ((tococunt != 0) && (double.Parse(ddlPercentage.SelectedValue) > 15.0))
                //if (Chkmqptoc.Checked == true)
                //{
                {

                    btnSaveFinance.Enabled = false;
                    lblMesagProgram.Text = "Fee Waiver greater than 15 % is not allowed for TOC case!";
                    return;
                }
                //}
                else
                {
                    btnSaveFinance.Enabled = true;
                    lblMesagProgram.Text = "";

                }
            }

            try
            {
            DataTable df = s.GetIsFeewaiverAllow(Session["LinkId"].ToString(), ddlPercentage.SelectedValue);
            if (df.Rows[0][0].ToString() == "0".ToString())
            {
               lblMesagProgram.Text = " Scholership / Feewaiver not applicable beyond the Class Startdate.Contact COEC for appraval or Change to No-Feewaiver option!";
               lblMesagProgram.Text = "";
                return;
            }
            }
            catch
            {

            }


        }
        catch
        {
            lblMesagProgram.Text = "";
        }

     




    }



    protected void ddlNameOfHostel_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = s.SetDropdownListAsDegreeType(6, int.Parse(ddlNameOfHostel.SelectedValue));
        foreach (DataRow ro in dt.Rows)
        {
            txtPhoneNo.Text = ro["PhoneNo"].ToString();
        }
    }
    public void LoadCourse()
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            //ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1, int.Parse(ddlDegreeType.SelectedValue));
            //ddlCourseType.DataTextField = "Description";
            //ddlCourseType.DataValueField = "Id";
            //ddlCourseType.DataBind();

            ddlCourseType.DataSource = s.SetDropdownListAsDegreeType(1111, int.Parse(ddlDegreeType.SelectedValue), Drpschool.SelectedValue);
            ddlCourseType.DataTextField = "Description";
            ddlCourseType.DataValueField = "Id";
            ddlCourseType.DataBind();

            //ddlDiscountType.DataSource = s.SetDropdownListAsDegreeType(2, int.Parse(ddlDegreeType.SelectedValue));
            //ddlDiscountType.DataTextField = "FeeWaiverType";
            //ddlDiscountType.DataValueField = "Id";
            //ddlDiscountType.DataBind();

            ddlQualification.DataSource = s.SetDropdownListAsDegreeType(12, int.Parse(ddlDegreeType.SelectedValue));
            ddlQualification.DataTextField = "AcadmicName";
            ddlQualification.DataValueField = "Id";
            ddlQualification.DataBind();
        }
        catch
        {
        }
    }
    protected void rdbProgramWeekend_CheckedChanged(object sender, EventArgs e)
    {
        ProgramWekends();
    }
    public void ProgramWekends()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        chkintegrated.Checked = false;
        ddlDegreeType.Enabled = true;


        if (rdbProgramWeekend.Checked == true)
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 1);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            //ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3, 2);
            //ddlDegreeType.DataTextField = "Description";
            //ddlDegreeType.DataValueField = "Id";
            //ddlDegreeType.DataBind();
           
            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3,2, Drpschool.SelectedValue);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();

        }
        else
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 2);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlShift.SelectedValue = "1";

            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3, 1, Drpschool.SelectedValue);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();

            //ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3, 1);
            //ddlDegreeType.DataTextField = "Description";
            //ddlDegreeType.DataValueField = "Id";
            //ddlDegreeType.DataBind();
        }
    }
    protected void ddlTransferUniversity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferUniversity.SelectedValue == "No")
        {
            pnlToc.Visible = false;
            lblTOCMesag.Text = "";
            btnUpdateToc.Enabled = false;
            btnSubmitToc.Enabled = false;
        }
        else
        {
            pnlToc.Visible = true;
            btnUpdateToc.Enabled = true;
            btnSubmitToc.Enabled = true;
            lblTOCMesag.Text = "FEEWAIVER LESS THAN 15 % IS APPLICABLE FOR TOC";
        }
    }
    public void ProgramRegular()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        chkintegrated.Checked = false;
        ddlDegreeType.Enabled = true;

        if (rdbProgramWeekend.Checked == true)
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 1);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3, 2);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
        }
        else
        {
            ddlShift.DataSource = s.SetDropdownListAsDegreeType(4, 2);
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Id";
            ddlShift.DataBind();

            ddlShift.SelectedValue = "1";
            ddlDegreeType.DataSource = s.SetDropdownListAsDegreeType(3, 1);
            ddlDegreeType.DataTextField = "Description";
            ddlDegreeType.DataValueField = "Id";
            ddlDegreeType.DataBind();
        }
    }
    protected void rdbProgramRegular_CheckedChanged(object sender, EventArgs e)
    {
        ProgramRegular();
    }
    protected void rdbWorking_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbWorking.Checked == true)
            pnlExperience1.Visible = true;
        else
            pnlExperience1.Visible = false;
    }
    protected void rdbNotWorking_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbNotWorking.Checked == true)
            pnlExperience1.Visible = false;
        else
            pnlExperience1.Visible = true;
    }
    protected void rdbTransportationYes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbTransportationYes.Checked == true)
            pnlTransportation.Visible = true;
        else
            pnlTransportation.Visible = false;
    }
    protected void rdbTransportationNo_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbTransportationNo.Checked == true)
            pnlTransportation.Visible = false;
        else
            pnlTransportation.Visible = true;
    }
    protected void rdbHostelYes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbHostelYes.Checked == true)
        {
            pnlHostel.Visible = true;
            //pnlHDetails1.Visible = false;
        }
        else
        {
            pnlHostel.Visible = false;
            //pnlHDetails1.Visible = true;
        }
    }
    protected void rdbHostelNo_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbHostelNo.Checked == true)
        {
            pnlHostel.Visible = false;
            //pnlHDetails1.Visible = true;
        }
        else
        {
            pnlHostel.Visible = true;
            //pnlHDetails1.Visible = false;
        }
    }
    protected void ddlVisaType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtIssueDate.Enabled = true;
        txtIssueMonth.Enabled = true;
        txtIssueYear.Enabled = true;
        RequiredFieldValidator19.Enabled = true;
        if (ddlVisaType.SelectedItem.Text == "Visa")
        {
            lblCardNo.Text = "Visa No";
            lblPlaceOfIssue.Text = "Visa Place of Issue";
            lblIssueDate.Text = "Visa Date of Issue";
            lblExpireDate.Text = "Visa Date of Expiry";
            pnlVisaDetails.Visible = true;
            txtPlaceOfIssue.Text = "";
            txtPlaceOfIssue.Enabled = true;
        }
        else   if (ddlVisaType.SelectedItem.Text == "Passport")
        {
            lblCardNo.Text = "Passport No";
            lblPlaceOfIssue.Text = "Passport Place of Issue";
            lblIssueDate.Text = "Passport Date of Issue";
            lblExpireDate.Text = "Passport Date of Expiry";
            pnlVisaDetails.Visible = false;
            txtPlaceOfIssue.Text = "";
            txtPlaceOfIssue.Enabled = true;
        }
        else  if (ddlVisaType.SelectedItem.Text == "National ID Card" )
        {
            lblCardNo.Text = "National ID Card No";
            lblPlaceOfIssue.Text = "National ID Card Place of Issue";
            lblIssueDate.Text = "National ID Card Date of Issue";
            lblExpireDate.Text = "National ID Card Date of Expiry";
            RequiredFieldValidator19.Enabled = false;
            txtIssueDate.Enabled = true;
            txtIssueMonth.Enabled =true;
            txtIssueYear.Enabled = true;
            txtIssueDate.Text = "";
            txtIssueMonth.Text = "";
            txtIssueYear.Text = "";
            txtPlaceOfIssue.Text = "Nigeria";
            txtPlaceOfIssue.Enabled = false;
            pnlVisaDetails.Visible = false;
        }
        else
        {
            lblCardNo.Text = "Card No";
            lblPlaceOfIssue.Text = "Place of Issue";
            lblIssueDate.Text = "Date of Issue";
            lblExpireDate.Text = "Date of Expiry";
            pnlVisaDetails.Visible = false;
            txtPlaceOfIssue.Text = "";
            txtPlaceOfIssue.Enabled = true;
        }

       

    }
    protected void rdbSkylineVisaYes_CheckedChanged(object sender, EventArgs e)
    {
        chkVisaAddGroup_CheckedChanged(sender, e);
        if (rdbSkylineVisaYes.Checked == true)
        {
            pnlother.Enabled = false;
            pnlSkylineVisaYes.Visible = true;
            pnlSkylineVisa.Visible = true;
            btnAddNewVisa.Enabled = true;
            btnDeleteNewVisa.Enabled = true;
            chkVisaAddGroup_CheckedChanged(sender, e);
            btnSaveVDType.Enabled = false;
        }
        else if ((RadioButton1.Checked == true) || (RadioButton2.Checked == true) || (RadioButton3.Checked == true))
        {
            pnlSkylineVisaYes.Visible = false;
            pnlSkylineVisa.Visible = false;
            btnAddNewVisa.Enabled = false;
            btnDeleteNewVisa.Enabled = false;
            btnSaveVDType.Enabled = true;
        }

        else
        {
            pnlother.Enabled = true;
            pnlSkylineVisaYes.Visible = false;
            pnlSkylineVisa.Visible = false;
            btnAddNewVisa.Enabled = false;
            btnDeleteNewVisa.Enabled = false;
            btnSaveVDType.Enabled = false;
        }
    }
    protected void rdbSkylineVisaNo_CheckedChanged(object sender, EventArgs e)
    {
        chkVisaAddGroup_CheckedChanged(sender, e);
        if (rdbSkylineVisaNo.Checked == true)
        {
            pnlother.Enabled = true;
            pnlSkylineVisaYes.Visible = false;
            pnlSkylineVisa.Visible = false;
            btnAddNewVisa.Enabled = false;
            btnDeleteNewVisa.Enabled = false;
            btnSaveVDType.Enabled = false;
            //txtAddress1Local.Text = "SUC";
            //txtCityLocal.Text = "SHARJAH";



        }
        else if ((RadioButton1.Checked == true) || (RadioButton2.Checked == true))
        {
            pnlSkylineVisaYes.Visible = false;
            pnlSkylineVisa.Visible = false;
            btnAddNewVisa.Enabled = false;
            btnDeleteNewVisa.Enabled = false;
            btnSaveVDType.Enabled = true;


        }
        else
        {
            pnlother.Enabled = false;
            pnlSkylineVisaYes.Visible = true;
            pnlSkylineVisa.Visible = true;
            btnAddNewVisa.Enabled = true;
            btnDeleteNewVisa.Enabled = true;
            btnSaveVDType.Enabled = false;
        }
    }
    protected void rdbNativeEnglishYes_CheckedChanged(object sender, EventArgs e)
    {
     
        if (rdbNativeEnglishYes.Checked == true)
        {
            //pnlNativeSpeaker.Visible = false;
            pnlNativeSpeaker.Visible = true;
            btnSubmitToefl.Enabled = true;
           
        }
        else
        {
            pnlNativeSpeaker.Visible = true;
            btnSubmitToefl.Enabled = true;
            
        }
    }
    protected void rdbNativeEnglishNo_CheckedChanged(object sender, EventArgs e)
    {
      
        if (rdbNativeEnglishNo.Checked == true)
        {
            pnlNativeSpeaker.Visible = true;
            btnSubmitToefl.Enabled = true;
           
        }
        else
        {
            btnSubmitToefl.Enabled = true;
            pnlNativeSpeaker.Visible = false;
            
        }

    }
    protected void rdbHavingToeflYes_CheckedChanged(object sender, EventArgs e)
    {
        
        
        if (rdbHavingToeflYes.Checked == true)
        {
            pnlHavingToeflYes.Visible = true;
            pnlHavingToeflNo.Visible = false;
                    
      
        }
    }
    protected void rdbHavingToeflNo_CheckedChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (rdbHavingToeflNo.Checked == true)
        {
            pnlHavingToeflYes.Visible =false;
            pnlHavingToeflNo.Visible = true;

            drpentrancetesttype.DataSource = s.SetDropdownListCDB(106);
            drpentrancetesttype.DataTextField = "TestType";
            drpentrancetesttype.DataValueField = "Typeid";
            drpentrancetesttype.DataBind();

          
            
        }
       

    }

    protected void rdosucoutside_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      
        if (rdosucoutside.SelectedValue == "1")
        {
            txtEnglishMark.Text = "0";
            lblExamPassedOn.Text = "EXAM DATE OUTSIDE SUC";
           txtListening.Text = "0";
           pnlemsat.Visible = false;
            
           txtReading.Text = "0";
           txtWriting.Text = "0";
           txtSpeaking.Text = "0";
           txtStatusOfExam.Text = "";
           txtListening.Enabled = false;
           txtReading.Enabled = false;
           txtWriting.Enabled = false;
           txtSpeaking.Enabled = false;
           txtStatusOfExam.Text = "APPEARING EXAM OUTSIDE SUC";
        }
        else
        {
            lblExamPassedOn.Text = "Exam Passed On";
            txtListening.Enabled = true;
            txtReading.Enabled = true;
            txtWriting.Enabled = true;
            txtSpeaking.Enabled = true;
            txtStatusOfExam.Text = "";
            pnlemsat.Visible = true;
        }
    }

    protected void rdbSatScoreYes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbSatScoreYes.Checked == true)
        {
            pnlHavingSatYes.Visible = true;
            pnlhavingSatNo.Visible = false;
            pnlDiploma.Visible = false;
        }
        else
        {
            pnlHavingSatYes.Visible = false;
            pnlhavingSatNo.Visible = true;
            pnlDiploma.Visible = false;
        }
    }
    protected void rdbSatScoreNo_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbSatScoreNo.Checked == true)
        {
            pnlHavingSatYes.Visible = false;
            pnlhavingSatNo.Visible = true;
            pnlDiploma.Visible = false;
        }
        else
        {
            pnlHavingSatYes.Visible = true;
            pnlhavingSatNo.Visible = false;
            pnlDiploma.Visible = false;
        }
    }
    protected void rdbDiploma_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbDiploma.Checked == true)
        {
            pnlHavingSatYes.Visible = false;
            pnlhavingSatNo.Visible = false;
            pnlDiploma.Visible = true;
        }
        else
        {
            pnlHavingSatYes.Visible = false;
            pnlhavingSatNo.Visible = false;
            pnlDiploma.Visible = false;
        }
    }
    protected void chkPoliceClearnece_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPoliceClearnece.Checked == true)
        {
            txtPoliceClearance.ReadOnly = false;
        }
        else
            txtPoliceClearance.ReadOnly = true;
    }
    protected void lnkCopyParent_Click(object sender, EventArgs e)
    {
        if (chkCopyParent.Checked == true)
        {
            txtPermenentAddr1.Text = txtPresentAddr1.Text;
            txtPermenentAddr2.Text = txtPresentAddr2.Text;
            txtPermenentCity.Text = txtPresentCity.Text;
            try
            {

                StudentRegistrationDAL s = new StudentRegistrationDAL();
                ddlPermanentCountry.DataSource = s.SetDropdownListCDB(2);
                ddlPermanentCountry.DataTextField = "NationalityName";
                ddlPermanentCountry.DataValueField = "NationalityCode";
                ddlPermanentCountry.DataBind();
                ddlPermanentCountry.SelectedValue = ddlNationalityDetails.SelectedValue;
                ddlPermenentState.DataSource = s.SetState(ddlPermanentCountry.SelectedValue);
                ddlPermenentState.DataTextField = "State";
                ddlPermenentState.DataValueField = "State";
                ddlPermenentState.DataBind();
                //ddlPermanentCountry_SelectedIndexChanged(sender, e);
                ddlPermenentState.SelectedValue = ddlPresentState.SelectedValue;


            }

            catch
            {


            }

                      
           
        }
        else
        {
            txtPermenentAddr1.Text = "";
            txtPermenentAddr2.Text = "";
            txtPermenentCity.Text = "";
            ddlPermenentState.SelectedIndex = 0;
            ddlPermanentCountry.SelectedIndex = 0;
        }
    }
    protected void lnkCopy_Click(object sender, EventArgs e)
    {
        if (chkCopy.Checked == true)
        {
            txtPName.Text = txtFatherName.Text;
            txtPRelationShip.Text = txtRelationShip.Text;
            txtPProfession.Text = txtProfession.Text;
            txtPOrganization.Text = txtOrganization.Text;
            txtPEmailParents.Text = txtEmailGuardian.Text;
            txtPMobileParents.Text = txtMobileGuardian.Text;
            txtPResPhone.Text = txtResPhone.Text;
            txtPOfficePhone.Text = txtOffPhone.Text;
            txtPWebsite.Text = txtWebsite.Text;
            txtAddressParents.Text = txtAddress.Text;
        }
        else
        {
            txtPName.Text = "";
            txtPRelationShip.Text = "";
            txtPProfession.Text = "";
            txtPOrganization.Text = "";
            txtPEmailParents.Text = "";
            txtPMobileParents.Text = "";
            txtPResPhone.Text = "";
            txtPOfficePhone.Text = "";
            txtPWebsite.Text = "";
            txtAddressParents.Text = "";
        }
    }
    protected void btnAttach_Click(object sender, EventArgs e)
    {
    }
    protected void ddlStudentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStudentType.SelectedValue == "2")
            PnlParrents.Visible = false;
        else
            PnlParrents.Visible = true;
    }
    protected void ddlToefl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTestType.SelectedValue == "1")
            pnlSpeaking.Visible = false;
        else
            pnlSpeaking.Visible = true;
        if (ddlTestType.SelectedValue == "7")
        {
            pnlemsat.Visible = true;
            try
            {
                drpemsat.Items.Clear();

                StudentRegistrationDAL s = new StudentRegistrationDAL();
                drpemsat.DataSource = s.SetDropdownListAsDegreeType(46, int.Parse(ddlDegreeType.SelectedValue));
                drpemsat.DataTextField = "academic_track";
                drpemsat.DataValueField = "id";
                drpemsat.DataBind();
            }
            catch
            {


            }

           

        }
        else
            pnlemsat.Visible = false; 
    }


    protected void drpemsat_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEnglishMark.Text = drpemsat.SelectedText.ToString();
        txtEnglish_TextChanged(sender, e);
    }

    protected void rdbTofel_CheckedChanged(object sender, EventArgs e)
    {
        //if (rdbTofel.Checked == true)
        //{
        //    pnlToeflExamDate.Visible = true;
        //    pnlIeltsExamDates.Visible = false;
        //}
        //else
        //{
        //    pnlToeflExamDate.Visible = false;
        //    pnlIeltsExamDates.Visible = true;
        //}
    }
    protected void rdbIelts_CheckedChanged(object sender, EventArgs e)
    {
        //if (rdbIelts.Checked == true)
        //{
        //    pnlToeflExamDate.Visible = false;
        //    pnlIeltsExamDates.Visible = true;
        //}
        //else
        //{
        //    pnlToeflExamDate.Visible = true;
        //    pnlIeltsExamDates.Visible = false;
        //}
    }
    protected void rdbOutSide_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbOutSide.Checked == true)
        {
            PnlInSideVisa.Visible = false;
        }
        else
        {
            PnlInSideVisa.Visible = true;
        }
    }
    protected void rdbInside_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbInside.Checked == true)
        {
            PnlInSideVisa.Visible = true;
        }
        else
        {
            PnlInSideVisa.Visible = false;
        }
    }
    protected void txtMath_TextChanged(object sender, EventArgs e)
    {
        if (txtMath.Text != "")
        {            
            decimal Marks = 0;
            Marks = decimal.Parse(txtMath.Text);
            if (Marks < 101)
            {
                if (Marks < 60)
                {
                    txtMathStatus.Text = "Fail - Register in Preparatory MATHS Crash Course (Non-Credit Course)";
                    txtMathStatus.ForeColor = System.Drawing.Color.Red;
                    txtMathStatus.Font.Bold = true;
                }
                else
                {
                    txtMathStatus.ForeColor = System.Drawing.Color.Blue;
                    txtMathStatus.Font.Bold = true;
                    txtMathStatus.Text = "Pass";
                }
            }
            else
            {
                if (Marks < 500)
                {
                    txtMathStatus.Text = "Fail - Register in Preparatory MATHS Crash Course (Non-Credit Course)";
                    txtMathStatus.ForeColor = System.Drawing.Color.Red;
                    txtMathStatus.Font.Bold = true;
                }
                else
                {
                    txtMathStatus.ForeColor = System.Drawing.Color.Blue;
                    txtMathStatus.Font.Bold = true;
                    txtMathStatus.Text = "Pass";
                }
            }
            if (txtMathStatus.Text == "")
            {
                txtMathStatus.Text = "Oops! Please select the right program.";
                txtMathStatus.ForeColor = System.Drawing.Color.Red;
                txtMathStatus.Font.Bold = true;
            }
        }
        else
        {
            txtMathStatus.Text = "Oops! Try again later.";
            txtMathStatus.ForeColor = System.Drawing.Color.Red;
            txtMathStatus.Font.Bold = true;
        }
    }
    protected void txtEnglish_TextChanged(object sender, EventArgs e)
    {
        if (txtEnglishMark.Text != "")
        {
            decimal Marks = 0;
            try
            {
                Marks = decimal.Parse(txtEnglishMark.Text);
            }

            catch
            {

            }
            if (ddlTestType.SelectedValue == "7")
            {

               
                if (txtEnglishMark.Text == "*")
                {
                    Marks = 0;
                    txtEnglishMark.Text = "0";
                }
              
            }
           

            if (ddlTestType.SelectedValue == "7")
            {

                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA"))  // BBA
                {
                    if (Marks >= 5)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {
                        txtStatusOfExam.Text = "Fail";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;

                    }

                }


                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA"))  // MBA
                {
                    if (Marks >= 6)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {
                        txtStatusOfExam.Text = "Fail";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;

                    }

                }


            }


            if (ddlTestType.SelectedValue == "5")
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA")  )  // BBA
                {
                    if (Marks >= 36) 
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {

                        if (Marks < 36)
                        {
                            txtStatusOfExam.Text = "Fail";
                            txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                            txtStatusOfExam.Font.Bold = true;
                        }
                    }

                }



                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA"))  // BBA
                {
                    if (Marks >= 50)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {

                        if (Marks < 50)
                        {
                            txtStatusOfExam.Text = "Fail";
                            txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                            txtStatusOfExam.Font.Bold = true;
                        }
                    }

                }
            }
            if (ddlTestType.SelectedValue == "4")
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA"))  // BBA
                {
                    if (Marks >= 41)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {

                        if (Marks < 41)
                        {
                            txtStatusOfExam.Text = "Fail";
                            txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                            txtStatusOfExam.Font.Bold = true;
                        }
                    }

                }



                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA"))  // BBA
                {
                    if (Marks >= 52)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {

                        if (Marks < 52)
                        {
                            txtStatusOfExam.Text = "Fail";
                            txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                            txtStatusOfExam.Font.Bold = true;
                        }
                    }

                }
            }

           
            if (ddlTestType.SelectedValue == "3")
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA"))  // BBA
                {
                    if (Marks >= 61)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {

                        if (Marks < 61)
                        {
                            txtStatusOfExam.Text = "Fail";
                            txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                            txtStatusOfExam.Font.Bold = true;
                        }
                    }

                }



                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA"))  // BBA
                {
                    if (Marks >= 79)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else
                    {

                        if (Marks < 79)
                        {
                            txtStatusOfExam.Text = "Fail";
                            txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                            txtStatusOfExam.Font.Bold = true;
                        }
                    }

                }
            }

            if (ddlTestType.SelectedValue == "6")
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA"))  // BBA
                {
                    if (Marks >= 1 || Marks <= 2)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }

                    else if (Marks <1) 
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail!";
                    }

                }


                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA"))  // MBA
                {
                    if (Marks >= 2)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }

                    else if (Marks < 2)
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail!";
                    }

                }



            }
            if (ddlTestType.SelectedValue == "1")
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA"))  // BBA
                {
                    if (Marks >= 500)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                  
                    else if (Marks >= 425)
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Advanced Level!";
                    }
                    else if (Marks > 350)
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Basic Level!";
                    }
                    else
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "IELP";
                    }
                }
                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA")) // MBA
                {
                    if (Marks >= 550)
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }

                    else if ((Marks >= 530)  && (ddlEntryType.SelectedValue == "1" ))//directentry
                    {                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Pass";
                       
                    }

                    else if ((Marks >= 530) && (ddlEntryType.SelectedValue != "1"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail - Probational Admission!";
                    }

                    else if (Marks >= 425)
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Advanced Level!";
                    }
                    else if (Marks >= 350)
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Basic Level!";
                    }
                    else
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "IELP";
                    }
                }
            }
            if (ddlTestType.SelectedValue == "2")
            {
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA"))  // BBA
                {
                    if (Marks >= decimal.Parse("5.0"))
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                   else if (Marks >= decimal.Parse("4.0"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Advanced Level!";
                    }
                    else if (Marks >= decimal.Parse("3.5"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Basic Level!";
                    }
                    else
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "IELP";
                    }
                }
                if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8" || ddlDegreeType.Text.Contains("MBA")) // MBA
                {
                    if (Marks >= decimal.Parse("6.0"))
                    {
                        txtStatusOfExam.Text = "Pass";
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                        txtStatusOfExam.Font.Bold = true;
                    }
                    else if ((Marks == decimal.Parse("5.5")) && (ddlEntryType.SelectedValue != "1" ))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail - Probational Admission!";
                    }
                    else if ((Marks == decimal.Parse("5.5")) && (ddlEntryType.SelectedValue == "1"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Pass";
                    }
                    else if ((Marks == decimal.Parse("5.0")) && (ddlEntryType.SelectedValue != "1"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Advanced Level!";
                    }
                    else if ((Marks == decimal.Parse("5.0")) && (ddlEntryType.SelectedValue == "1"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Pass";
                    }
                    else if (Marks >= decimal.Parse("4.5")) 
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Advanced Level!";
                    }
                  
                    else if (Marks >= decimal.Parse("4.0"))
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "Fail-AIPC Basic Level!";
                    }
                    else
                    {
                        txtStatusOfExam.ForeColor = System.Drawing.Color.Red;
                        txtStatusOfExam.Font.Bold = true;
                        txtStatusOfExam.Text = "IELP";
                    }
                }
            }
            if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7" || ddlDegreeType.Text.Contains("BBA") || ddlDegreeType.Text.Contains("MBA"))
            {
                if (rdosucoutside.SelectedValue == "1")
                {
                    txtStatusOfExam.Text = "APPEARING EXAM OUTSIDE SUC";
                }
            }
            else
            {

                if (txtStatusOfExam.Text == "")
                {
                    txtMathStatus.Text = "Oops! Please select the right program.";
                    txtMathStatus.ForeColor = System.Drawing.Color.Red;
                    txtMathStatus.Font.Bold = true;
                }

            }

            if (chkstatus.Checked == true)
            {
                txtStatusOfExam.Text = "Pass";
                txtStatusOfExam.ForeColor = System.Drawing.Color.Blue;
                txtStatusOfExam.Font.Bold = true;
            }



        }
        else
        {
            txtMathStatus.Text = "Oops! Try again later.";
            txtMathStatus.ForeColor = System.Drawing.Color.Red;
            txtMathStatus.Font.Bold = true;
        }



    }
    protected void ddlToMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlToMonth.SelectedIndex == 0)
            ddlToYear.Enabled = false;
        else
            ddlToYear.Enabled = true;
    }
    protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int seat=1;
        string shiftname="";
        try
        {
            if (int.Parse(ddlCourseType.SelectedValue) != 0)
            {
                if (ddlShift.SelectedIndex != 0)
                {

                    if (ddlShift.SelectedItem.Text.Contains("MORNING"))
                        ddlShift.SelectedValue = "1";
                    else if (ddlShift.SelectedItem.Text.Contains("EVENING"))
                        ddlShift.SelectedValue = "2";

                    else if (ddlShift.SelectedItem.Text.Contains("WEEKEND"))
                        ddlShift.SelectedValue = "3";
                    else if (ddlShift.SelectedItem.Text.Contains("AFTERNOON"))
                        ddlShift.SelectedValue = "4";

                    try
                    {
                        StudentRegistrationDAL s = new StudentRegistrationDAL();
                        int Count = s.GetInterNationStudent(Request.QueryString["Id"].ToString());
                        if (Count == 1)
                        {
                            DataTable dt = s.CheckSeats(int.Parse(ddlCourseType.SelectedValue), int.Parse(ddlTerm.SelectedValue), ddlShift.SelectedValue);
                            int SeatCount = int.Parse(dt.Rows[0][0].ToString());
                            if (SeatCount == 0)
                            {
                                ddlShift.Enabled = false;
                                seat = 0;
                                shiftname = ddlShift.SelectedItem.Text;
                                ddlShift.SelectedValue = "2";
                                
                            }
                            else
                            {
                                seat = 1;
                                ddlShift.Enabled = false;
                                ddlShift.SelectedValue = "1";
                            }
                            if (ddlTerm.SelectedItem.Text.Contains("MAY") || ddlTerm.SelectedItem.Text.Contains("May"))
                                ddlShift.Enabled = true;


                        }
                        else
                        {
                            ddlShift.Enabled = true;
                        }

                       


                    }
                    catch
                    {
                    }
                    CheckSeat();
                   
                }



                //StudentRegistrationDAL s = new StudentRegistrationDAL();
                //DataTable dt = s.CheckSeats(int.Parse(ddlCourseType.SelectedValue), int.Parse(ddlTerm.SelectedValue), ddlShift.SelectedValue);
                //foreach (DataRow ro in dt.Rows)
                //{
                //    try
                //    {
                //        if (ro[0].ToString() == "")
                //        {
                //            lblProgramMesag.Text = ro[0].ToString();
                //            btnSaveProgram.Enabled = true;
                //        }
                //        else
                //        {
                //            lblProgramMesag.Text = "Available Seat for " + ddlCourseType.SelectedItem.Text + " : " + ro[0].ToString();
                //            if (int.Parse(ro[0].ToString()) < 1)
                //            {
                //                btnSaveProgram.Enabled = false;
                //            }
                //        }
                //    }
                //    catch
                //    {

                //    }
                //}
            }
            string Course = ddlCourseType.SelectedItem.Text;
            if (Course.Contains("MQP"))
            {
                pnlSubject.Visible = true;
            }
            else
            {
                pnlSubject.Visible = false;
            }
        }
        catch
        {
        }
    }
    protected void ddlNationalityDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlPresentState.DataSource = s.SetState(ddlNationalityDetails.SelectedValue);
        ddlPresentState.DataTextField = "State";
        ddlPresentState.DataValueField = "State";
        ddlPresentState.DataBind();
    }
    protected void ddlPermanentCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        ddlPermenentState.DataSource = s.SetState(ddlPermanentCountry.SelectedValue);
        ddlPermenentState.DataTextField = "State";
        ddlPermenentState.DataValueField = "State";
        ddlPermenentState.DataBind();
    }
    private void FillGridView1(int LinkId)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.GetReportList(LinkId);

            gvReportList.DataSource = dt;
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
                    ReportDocument rptStudent = new ReportDocument();
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
            Session["LinkId"] = Request.QueryString["Id"].ToString();
            if (lblUName.Text == "ENROLLMENTFORM")
            {
                lblUName.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void btnFinalize_Click(object sender, EventArgs e)
    {
        string srev = "N";
        string integrated="BBA + MBA INTEGRATED FEES";
        // for email
        try
        {

            if (chkRejected.Checked == true)
            {
                return;
            }

          
            DataSet ds = new DataSet();
            StudentRegistrationDAL s = new StudentRegistrationDAL();

            Session["LinkId"] = Request.QueryString["Id"].ToString();
            lblMesag.Text = "";
            string Hostel = "";
            string Visa = "";
            string Toc = "";
            string Transportaion = "";
            pnlPrintGrid.Visible = true;
            StudentRegistrationDAL d = new StudentRegistrationDAL();

            DataTable dta=s.CheckAyYearApproval(Session["LinkId"].ToString());
            try
            {
                if (dta.Rows.Count > 0)
                {

                    s.InsertFinalize(Session["LinkId"].ToString(), Session["EMPID"].ToString(), txtFileNumber.Text);
                }
                else
                {
                    lblMesag.Text = "AcademicYear Not Approved Contact IT/MKT Officer!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    return;

                }
            }
            catch
            {
                lblMesag.Text = "Contact IT!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
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

            // for enroll beyond feewaiver
            DataTable df = d.GetIsFeewaiverdatebeyond(Session["LinkId"].ToString());
            if (df.Rows[0][0].ToString() == "0".ToString())
            {
                lblMesag.Text = " Scholership / Feewaiver not applicable beyond the Class Startdate.Contact COEC or Change to No-Feewaiver option!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                return;
            }





            // For Program
            if (d.GetIsProgramSelected(Session["LinkId"].ToString()) == 0)
            {
                lblMesag.Text = "Please select Program before Finilize!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                return;
            }
            try
            {
                if (rdbNativeEnglishYes.Checked == false)
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
            }
            catch
            {
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
                if (ddlDegreeType.SelectedValue != "9")
                {
                    if (ds.Tables[18].Rows[0][0].ToString() == "0")
                    {
                        lblMesag.Text = "Please Fill Parent Details!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        return;
                    }
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
            // For Feewaiver
            if (d.GetIsFeeWaiverSelected(Session["LinkId"].ToString()) == 0)
            {
                lblMesag.Text = "Please select Feewaiver before Finilize!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                return;
            }
            //for toc
            try{
            DataTable dtc =d.GettocFeeWaiverSelected(Session["LinkId"].ToString());
            if (dtc.Rows[0][0].ToString() != "0".ToString())
            {
                lblMesag.Text = "Feewaiver more than 15% not allowd for TOC .(For Sharjah Hrd Feewaiver more tahn 25% Not allowed for TOC). Please change Feewaiver!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
                return;
            }
            }
            catch
            {

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
                        return;
                    }
                    if (ro["Degree"].ToString().ToUpper() == "0")
                    {
                        lblMesag.Text = "Please select program before Finilize!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        return;
                    }
                    if (ro["Degree"].ToString().ToUpper() != "SHORT COURSE")
                    {
                        lblMesag.Text = "Please fill passport details in visa info before Finilize!";
                        lblMesag.ForeColor = System.Drawing.Color.Red;
                        pnlPrintGrid.Visible = false;
                        d.DeleteFinalize(Session["LinkId"].ToString());
                        return;
                    }
                }
                lblMesag.Text = "Please fill passport details in visa info before Finilize!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
                pnlPrintGrid.Visible = false;
                d.DeleteFinalize(Session["LinkId"].ToString());
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
                    return;
                }
                if (ro["JobType"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Job Type in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    return;
                }
                if (ro["FromMonth"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Experience Date in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
                    return;
                }
                if (ro["FromDate"].ToString() == "0")
                {
                    lblMesag.Text = "Please select Experience Date in work experience before Finilize!";
                    lblMesag.ForeColor = System.Drawing.Color.Red;
                    pnlPrintGrid.Visible = false;
                    d.DeleteFinalize(Session["LinkId"].ToString());
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


            // for debitpushing

            try
            {
                s.InsertFS(Session["LinkId"].ToString());
            }
            catch
            {
                CC = "";
                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", "FSError", RegNo, CC);

            }
            try
            {
                Debitpush(RegNo);
            }
            catch
            {
                CC = "";

                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", "DebitNotpushed", RegNo, CC);
            } 

            
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
                    srev = ro["SRev"].ToString(); 


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

                      //string sreverse= (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";
                        string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Re-Activation)" : "";

                      Subject = "STUDENT APPLIED FOR HOSTEL" + sreverse;
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
                        if (ro["SRev"].ToString() == "A".ToString())
                        {
                           // Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>RE-ACTIVATION REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper(); 
                        }
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
                        //string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";
                        string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Re-Activation)" : "";
                        Subject = "STUDENT APPLIED FOR VISA" + sreverse; 
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
                        if (ro["SRev"].ToString() == "A".ToString())
                        {
                           // Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>RE-ACTIVATION REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper();
                        }
                        
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
                        //string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";
                        string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Re-Activation)" : "";
                        Subject = "STUDENT APPLIED FOR TRANSPORTATION" + sreverse;
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

                        if (ro["SRev"].ToString() == "A".ToString())
                        {
                            //Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper();
                            Message = Message + "</td></tr><tr><td>RE-ACTIVATION REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper();
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
                        string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";

                        Subject = "STUDENT APPLIED FOR TOC" + sreverse;
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
                        if (ro["SRev"].ToString() == "A".ToString())
                            Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper(); 

                        Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
                    }

                    Body = Message;
                    ToEmail = "iroffice@skylineuniversity.ac.ae"; //"iroffice@skylineuniversity.ac.ae";
                    //CC = "software@skylineuniversity.ac.ae";
                    SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                    Message = Message + "Toc : Yes" + Environment.NewLine;
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


                                string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";

                                Subject = "STUDENT APPLIED FOR VISA LETTER/EMBASSY LETTER" + sreverse;
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

                                if (ro["SRev"].ToString() == "A".ToString())
                                    Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper(); 
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
                        if(ds.Tables[20].Rows.Count != 0)
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

                                string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";

                                Subject = "STUDENT APPLIED FOR " + ExamType.ToUpper() + sreverse;
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

                                if (ro["SRev"].ToString() == "A".ToString())
                                    Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper(); 


                                if((ro1[2].ToString() + ro1[3].ToString()) != "")
                                {
                                    Message = Message + "</td></tr><tr><td>EXAM TYPE</td><td>" + ExamType.ToUpper();
                                    Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ExamTime.ToUpper();
                                }
                            }
                            if (ds.Tables[20].Rows.Count != 0)
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

                            string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Reversal)" : "";

                            Subject = "STUDENT APPLIED FOR Feewaiver" + sreverse;
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

                            if (ro["SRev"].ToString() == "A".ToString())
                                Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper(); 


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

                string sreverse = (ro["SRev"].ToString() == "A".ToString()) ? "(Re-Activation)" : "";
                Subject = "Today's Admission Registration Details" + sreverse;

                //Subject = "Today's Admission Registration Details (Reactivation)";
                Subject = Subject.ToUpper();
                Message = "<table style=background-color:#FAF1E7; text-transform:uppercase; border-color:#C67E7E; border=1><tbody>";
                Message = Message + "<tr><td colspan=2><h3><font size=5>" + Subject + "</font></h3>";
                Message = Message + "</td></tr><tr><td>REGISTRATION DATE </td><td>" + ro["CallDate"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>REFERENCE ID </td><td>" + ro["RegistrationNo"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>NAME</td><td>" + ro["Name"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>NATIONALITY</td><td>" + ro["NationalityName"].ToString().ToUpper();
                if (chkintegrated.Checked == true)
                {

                    Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper() + " - "+integrated;

                }
                else
                Message = Message + "</td></tr><tr><td>PROGRAM</td><td>" + ro["Degree"].ToString().ToUpper() ;

                Message = Message + "</td></tr><tr><td>COURSE</td><td>" + ro["Course"].ToString().ToUpper();
                Message = Message + "</td></tr><tr><td>SHIFT</td><td>" + ro["Shift"].ToString().ToUpper();
                if ((ro["Degree"].ToString().ToUpper() == "SHORT COURSE") & (ro["Course"].ToString().ToUpper() != "MQP"))
                {
                    Message = Message + "</td></tr><tr><td>FROM DATE</td><td>" + DateTime.Parse(ro["ShortFromDate"].ToString()).ToShortDateString().ToUpper();
                    Message = Message + "</td></tr><tr><td>TO DATE</td><td>" + DateTime.Parse(ro["ShortToDate"].ToString()).ToShortDateString().ToUpper();
                    CC = "cpd@skylineuniversity.ac.ae,finance@skylineuniversity.ac.ae";
                }
                else
                {
                    CC = "admissions@skylineuniversity.ac.ae,asma@skylineuniversity.ac.ae,rakesh@skylineuniversity.ac.ae,finance@skylineuniversity.ac.ae";
                   
                    Message = Message + "</td></tr><tr><td>TERM</td><td>" + ro["TermName"].ToString().ToUpper();
                }
                Message = Message + "</td></tr><tr><td>REGISTERED BY</td><td>" + ro["EmpName"].ToString().ToUpper();
                //Message = Message + "</td></tr><tr><td>INITIATED BY</td><td>" + ro["EmpName1"].ToString().ToUpper();
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
                if (ds.Tables[12].Rows.Count != 0)
                {
                    Message = Message + "</td></tr><tr><td>QUALIFICATION</td><td>" + ds.Tables[12].Rows[0]["Qualification"].ToString().ToUpper();
                    //    if (ds.Tables[25].Rows.Count != 0)
                    //{
                    //    Message = Message + "</td></tr><tr><td>BACHELOR DEGREE IN </td><td>" + ds.Tables[24].Rows.[0][0].ToString().ToUpper();
                    //    }
                    Message = Message + "</td></tr><tr><td>CGPA/PERCENTAGE</td><td>" + ds.Tables[12].Rows[0]["CGPA"].ToString().ToUpper();
                    Message = Message + "</td></tr><tr><td>UNIVERSITY / SCHOOL</td><td>" + ds.Tables[12].Rows[0]["UniversityName"].ToString().ToUpper();
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
                                if ((ds.Tables[14].Rows[0]["ExamDate"].ToString() != "") && (ds.Tables[14].Rows[0]["remarks"].ToString() == ""))
                                {
                                    Message = Message + "</td></tr><tr><td>EXAM DATE</td><td>" + ds.Tables[14].Rows[0]["ExamDate"].ToString().ToUpper();
                                }
                                else if ((ds.Tables[14].Rows[0]["ExamDate"].ToString() != "") && (ds.Tables[14].Rows[0]["remarks"].ToString() != ""))
                                {

                                    Message = Message + "</td></tr><tr><td>MATH/SAT REMARKS</td><td>" + ds.Tables[14].Rows[0]["remarks"].ToString().ToUpper();
                                }
                                else
                                {
                                    Message = Message + "</td></tr><tr><td>STATUS OF EXAM</td><td>" + ds.Tables[14].Rows[0]["StatusOfExamMath"].ToString().ToUpper();
                                }
                            }
                        }
                    }
                }
                catch
                {

                }


                try
                {
                    DataSet dtorient = s.GetClassOrientaion(Session["LinkId"].ToString());

                    if (dtorient.Tables[0].Rows.Count != 0)//(class date)
                    {
                        Message = Message + "</td></tr><tr><td>COMMENCEMENT DATE</td><td>" + dtorient.Tables[0].Rows[0]["ClassStartDate"].ToString().ToUpper();
                        Message = Message + "</td></tr><tr><td>ORIENTATION DATE</td><td>" + dtorient.Tables[0].Rows[0]["ClassOrtDate"].ToString().ToUpper() ;

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

              

                if (ro["SRev"].ToString() == "A".ToString())
                    //Message = Message + "</td></tr><tr><td>REVERSAL REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper(); 
                    Message = Message + "</td></tr><tr><td>RE-ACTIVATION REMAKS</td><td>" + ro["srremarks"].ToString().ToUpper();
                // Ends Here
                Message = Message + "</td></tr></tr></tbody></table></p><p></p>";
            }
            if (ds.Tables[6].Rows.Count != 0)
            {
                ToEmail = "nitin@skylineuniversity.ac.ae";
                Body = Message;
                SendEmails.SendEmail(FromEmail, ToEmail, Subject, Body, CC);
                try
                {
                    CC = "";
                    SendEmails.SendEmail(FromEmail, FromEmail, Subject, Body, CC);
                }
                catch
                {

                }



                SMSCAPI obj1 = new SMSCAPI();
                string strPostResponse1;
                //strPostResponse1 = obj1.SendSMS("", "", "+971556460999", "Congratulations at the successful completion of your admission process. Welcome to Skyline.  Contact the marketing officer or log on to your portal.");
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
                        
                        if (d.GetCheckMailContact(Session["LinkId"].ToString()) != "")
                        {
                            string Message1 = "";
                            string UserName = ds.Tables[6].Rows[0]["RegistrationNo"].ToString();
                            string Password = s.GetPassword(ds.Tables[6].Rows[0]["RegistrationNo"].ToString());
                            string program = ds.Tables[6].Rows[0]["Degree"].ToString();
                            Message = "<tr><td><br /></td></tr>";
                            Message = Message + "<tr style=text-align:justify><td colspan=2>" + "Kindly note that you are required to keep in touch with SUC through your portal and official Email issued to you.  Your Username and Password is mentioned below</td></tr>";
                            Message = Message + "<tr><td><br /></td></tr>";
                            Message = Message + "<tr><td colspan=2>User Name: " + UserName + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>Password: " + UserName + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>Program: " + program + "</td></tr>";
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
                                    Message = Message + "<tr><td colspan=2>Your entrance exam " + ExamType + " is scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: English or and Mathematics placement test guide exam.</td></tr>";
                                else
                                    Message = Message + "<tr><td colspan=2>Your entrance exam " + ExamType + " is scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: English placement test</td></tr>";

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

                                try
                                {
                                    DataSet dtorient = s.GetClassOrientaion(Session["LinkId"].ToString());

                                    if (dtorient.Tables[0].Rows.Count != 0)//(class date)
                                    {
                                        Message = Message + "<tr><td colspan=2>Your Class Commencement date - " + dtorient.Tables[0].Rows[0]["ClassStartDate"].ToString().ToUpper() + " and Orientation date - " +dtorient.Tables[0].Rows[0]["ClassOrtDate"].ToString().ToUpper() + ".</td></tr>";
                                    }



                                }

                                catch
                                {


                                }


                            }
                            catch
                            {
                            }
                            //Message = Message + "<tr><td colspan=2></td></tr>";
                            //Message = Message + "<tr><td colspan=2 style='color:Red;'> MENTION ABOUT ORENATATION AND DOWNLOAD OF NAVGATORS AND BOOK FOR THE ORENTATION </td></tr>";

                            Message = Message + "<tr><td colspan=2></td></tr>";
                            Message = Message + "<tr><td colspan=2></td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Best Regards," + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Skyline University College" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "University City of Sharjah, Sharjah" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "P.O. Box: 1797, Sharjah, U.A.E" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Email: admissions@skylineuniversity.ac.ae" + "</td></tr>";

                            Message = Message + "</table>";
                            Message1 = "<table>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2><h3><font size=5>ADMISSION DETAILS</font></h3></td></tr>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2>" + "Dear " + ds.Tables[6].Rows[0]["Name"].ToString().ToUpper() + ", </td></tr><tr style=text-align:justify><td colspan=2></td></tr><tr style=text-align:justify><td colspan=2>Greetings from Skyline University College (SUC)! </td></tr><tr style=text-align:justify><td colspan=2></td></tr><tr style=text-align:justify><td colspan=2>We confirm the acceptance of your documents for admission to SUC. Kindly note that your admission is subjected to completion of your admission requirement by your good self as per admission criteria explained to you during the time of admission process.</td></tr><tr style=text-align:justify><td colspan=2></td></tr>";
                            Message = Message1 + Message;
                            if (ro["SRev"].ToString() == "N".ToString())
                            {
                                SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailContact(Session["LinkId"].ToString()), "Registration Details", Message, "");
                                //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "software@skylineuniversity.ac.ae", "Registration Details", Message, "");
                                SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "lss@skylineuniversity.ac.ae", "Admission Details", Message, "");
                                SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "nitin@skylineuniversity.ac.ae", "Admission Details", Message, "");
                            }

                        }
                        if (d.GetCheckMailGuardian(Session["LinkId"].ToString()) != "")
                        {
                            string Message1 = "";
                            string UserName = ds.Tables[6].Rows[0]["RegistrationNo"].ToString();
                            string Password = s.GetPassword(ds.Tables[6].Rows[0]["RegistrationNo"].ToString());
                            string program = ds.Tables[6].Rows[0]["Degree"].ToString();
                            Message = "<tr><td><br /></td></tr>";
                            Message = Message + "<tr style=text-align:justify><td colspan=2>" + "Kindly note that you are required to keep in touch with SUC through your portal and official email issued to you.  Your Username and Password is mentioned below</td></tr>";
                            Message = Message + "<tr><td><br /></td></tr>";
                            Message = Message + "<tr><td colspan=2>User Name: " + UserName + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>Password: " + UserName + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>Program: " + program + "</td></tr>";
                            Message = Message + "<tr><td colspan=2><br /></td></tr>";
                            Message = Message + "<tr><td colspan=2>Please guide your ward to change the password once log on for the first time.</td></tr>";
                            Message = Message + "<tr><td colspan=2><br /></td></tr>";
                            Message = Message + "<tr><td colspan=2>Following documents are pending from your side which should be completed within 1 week of your ward’s admission date</td></tr>";
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
                                    Message = Message + "<tr><td colspan=2>Your Ward's entrance exam " + ExamType + " scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: English or and Mathematics placement test guide exam.</td></tr>";
                                else
                                    Message = Message + "<tr><td colspan=2>Your Ward's entrance exam " + ExamType + " scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: English placement test.</td></tr>";

                                try
                                {
                                    if (ds.Tables[26].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                    {
                                        Message = Message + "<tr><td colspan=2>Your Ward's Challenge exam is scheduled on " + ds.Tables[26].Rows[0]["ExamDate"].ToString().ToUpper() + " at SUC campus.</td></tr>";
                                    }
                                    if (ds.Tables[20].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                    {
                                        Message = Message + "<tr><td colspan=2>Your Ward's Interview is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + "" + ds.Tables[20].Rows[0]["ExamTime"].ToString().ToUpper() + " at SUC campus.</td></tr>";
                                    }
                                }
                                catch
                                {

                                }


                                try
                                {
                                    DataSet dtorient = s.GetClassOrientaion(Session["LinkId"].ToString());

                                    if (dtorient.Tables[0].Rows.Count != 0)//(class date)
                                    {
                                        Message = Message + "<tr><td colspan=2>Your Ward's Class Commencement date - " + dtorient.Tables[0].Rows[0]["ClassStartDate"].ToString().ToUpper() + " and Orientation date - " + dtorient.Tables[0].Rows[0]["ClassOrtDate"].ToString().ToUpper() + ".</td></tr>";
                                    }



                                }

                                catch
                                {


                                }



                            }
                            catch
                            {
                            }
                            //Message = Message + "<tr><td colspan=2></td></tr>";
                            //Message = Message + "<tr><td colspan=2 style='color:Red;'> MENTION ABOUT ORENATATION AND DOWNLOAD OF NAVGATORS AND BOOK FOR THE ORENTATION </td></tr>";

                            Message = Message + "<tr><td colspan=2></td></tr>";
                            Message = Message + "<tr><td colspan=2></td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Best Regards," + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Skyline University College" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "University City of Sharjah, Sharjah" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "P.O. Box: 1797, Sharjah, U.A.E" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166" + "</td></tr>";
                            Message = Message + "<tr><td colspan=2>" + "Email: admissions@skylineuniversity.ac.ae" + "</td></tr>";

                            Message = Message + "</table>";

                            Message1 = "<table>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2><h3><font size=5>ADMISSION DETAILS</font></h3></td></tr>";
                            Message1 = Message1 + "<tr style=text-align:justify><td colspan=2>" + "Dear Parent/Guardian, </td></tr><tr style=text-align:justify><td colspan=2></td></tr><tr style=text-align:justify><td colspan=2>Greetings from Skyline University College (SUC)! </td></tr><tr style=text-align:justify><td colspan=2></td></tr><tr style=text-align:justify><td colspan=2> We confirm the acceptance of your ward’s documents for admission to SUC. Kindly note that your ward’s admission is subjected to completion of his/her ward’s admission requirement by him/her as per admission criteria explained to you during the time of admission process.</td></tr><tr style=text-align:justify><td colspan=2></td></tr>";
                            Message = Message1 + Message;
                            try
                            {
                                if (ro["SRev"].ToString() == "N".ToString())
                                SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailGuardian(Session["LinkId"].ToString()), "Registration Details", Message, "");
                            }

                            catch
                            {
                                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", Subject, Body, CC);
                            }
                               //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "software@skylineuniversity.ac.ae", "Registration Details", Message, "");
                            if (ro["SRev"].ToString() == "N".ToString())
                            {
                                SendEmail1.SendEmail("admissions@skylneuniversity.ac.ae", "firoj@skylineuniversity.ac.ae", "Admission Details", Message, "");
                                SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "nitin@skylineuniversity.ac.ae", "Admission Details", Message, "");
                            }
                        }
                        if (ddlStudentType.SelectedValue == "1")
                        {
                            if (d.GetCheckMailParent(Session["LinkId"].ToString()) != "")
                            {
                                string Message1 = "";
                                string UserName = ds.Tables[6].Rows[0]["RegistrationNo"].ToString();
                                string Password = s.GetPassword(ds.Tables[6].Rows[0]["RegistrationNo"].ToString());
                                string program = ds.Tables[6].Rows[0]["Degree"].ToString();
                                Message = "<tr><td><br /></td></tr>";
                                Message = Message + "<tr style=text-align:justify><td colspan=2>" + "Kindly note that you are required to keep in touch with SUC through your portal and official email issued to you.  Your Username and Password is mentioned below</td></tr>";
                                Message = Message + "<tr><td><br /></td></tr>";
                                Message = Message + "<tr><td colspan=2>User Name: " + UserName + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>Password: " + UserName + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>Program: " + program + "</td></tr>";
                                Message = Message + "<tr><td colspan=2><br /></td></tr>";
                                Message = Message + "<tr><td colspan=2>Please guide your ward to change the password once log on for the first time.</td></tr>";
                                Message = Message + "<tr><td colspan=2><br /></td></tr>";
                                Message = Message + "<tr><td colspan=2>Following documents are pending from your side which should be completed within 1 week of your ward’s admission date</td></tr>";
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
                                        Message = Message + "<tr><td colspan=2>Your Ward's entrance exam " + ExamType + " scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: English or and Mathematics placement test guide exam.</td></tr>";
                                    else
                                        Message = Message + "<tr><td colspan=2>Your Ward's entrance exam " + ExamType + " scheduled on " + ExamDate + "" + ExamTime + " at SUC campus, You can log on to the portal to access study material: English placement test.</td></tr>";

                                    try
                                    {
                                        if (ds.Tables[26].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                        {
                                            Message = Message + "<tr><td colspan=2>Your Ward's Challenge exam is scheduled on " + ds.Tables[26].Rows[0]["ExamDate"].ToString().ToUpper() + " at SUC campus.</td></tr>";
                                        }
                                        if (ds.Tables[20].Rows.Count != 0)//(ExamType == "Chalange Exam")
                                        {
                                            Message = Message + "<tr><td colspan=2>Your Ward's Interview is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + "" + ds.Tables[20].Rows[0]["ExamTime"].ToString().ToUpper() + " at SUC campus.</td></tr>";
                                        }
                                    }
                                    catch
                                    {

                                    }


                                    try
                                    {
                                        DataSet dtorient = s.GetClassOrientaion(Session["LinkId"].ToString());

                                        if (dtorient.Tables[0].Rows.Count != 0)//(class date)
                                        {
                                            Message = Message + "<tr><td colspan=2>Your Ward's Class Commencement date - " + dtorient.Tables[0].Rows[0]["ClassStartDate"].ToString().ToUpper() + " and Orientation date - " + dtorient.Tables[0].Rows[0]["ClassOrtDate"].ToString().ToUpper() + ".</td></tr>";
                                        }



                                    }

                                    catch
                                    {


                                    }



                                }
                                catch
                                {
                                }
                                //Message = Message + "<tr><td colspan=2></td></tr>";
                                //Message = Message + "<tr><td colspan=2 style='color:Red;'> MENTION ABOUT ORENATATION AND DOWNLOAD OF NAVGATORS AND BOOK FOR THE ORENTATION </td></tr>";

                                Message = Message + "<tr><td colspan=2></td></tr>";
                                Message = Message + "<tr><td colspan=2></td></tr>";
                                Message = Message + "<tr><td colspan=2>" + "Best Regards," + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>" + "Skyline University College" + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>" + "University City of Sharjah, Sharjah" + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>" + "P.O. Box: 1797, Sharjah, U.A.E" + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>" + "Tel. : 971-6-5441155, Fax.: 971-6-5441166" + "</td></tr>";
                                Message = Message + "<tr><td colspan=2>" + "Email: admissions@skylineuniversity.ac.ae" + "</td></tr>";

                                Message = Message + "</table>";

                                Message1 = "<table>";
                                Message1 = Message1 + "<tr style=text-align:justify><td colspan=2><h3><font size=5>ADMISSION DETAILS</font></h3></td></tr>";
                                Message1 = Message1 + "<tr style=text-align:justify><td colspan=2>" + "Dear Parent/Guardian, </td></tr><tr style=text-align:justify><td colspan=2></td></tr><tr style=text-align:justify><td colspan=2>Greetings from Skyline University College (SUC)! </td></tr><tr style=text-align:justify><td colspan=2></td></tr><tr style=text-align:justify><td colspan=2> We confirm the acceptance of your ward’s documents for admission to SUC. Kindly note that your ward’s admission is subjected to completion of his/her ward’s admission requirement by him/her as per admission criteria explained to you during the time of admission process.</td></tr><tr style=text-align:justify><td colspan=2></td></tr>";
                                Message = Message1 + Message;
                                try
                                {
                                    if (ro["SRev"].ToString() == "N".ToString())
                                    {
                                        SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailParent(Session["LinkId"].ToString()), "Registration Details", Message, "");

                                    }
                                    }
                                catch
                                {
                                    SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", Subject, Body, CC);

                                }
                                //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "software@skylineuniversity.ac.ae", "Registration Details", Message, "");
                                if (ro["SRev"].ToString() == "N".ToString())

                                SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "firoj@skylineuniversity.ac.ae", "Admission Details", Message, "");
                            }
                        }
                        try
                        {
                            SMSCAPI obj1 = new SMSCAPI();
                            string strPostResponse1;

                            if (srev.ToString() == "N".ToString())
                            {

                                foreach (DataRow roww in dtUndertaking.Tables[0].Rows)
                                {
                                    strPostResponse1 = obj1.SendSMS("", "", "+" + txtMobile.Text, "Welcome to SUC! In order to complete the registration process successfully, please submit the required document as soon as possible. For More information contact the marketing officer.");
                                    //strPostResponse1 = obj1.SendSMS("", "", "+971556460999", "Welcome to SUC! In order to complete the registration process successfully, please submit the required document as soon as possible. For More information contact the marketing officer.");
                                }
                                if (dtUndertaking.Tables[0].Rows.Count == 0)
                                {
                                    strPostResponse1 = obj1.SendSMS("", "", "+" + txtMobile.Text, "Congratulations!!! Welcome to Skyline University College.  Your registration process is successfully completed. For More information contact the marketing officer");
                                    //strPostResponse1 = obj1.SendSMS("", "", "+971556460999", "Congratulations!!! Welcome to Skyline University College.  Your registration process is successfully completed. For More information contact the marketing officer");
                                }
                            }
                        }
                        catch
                        {
                            SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", Subject, Body, CC);

                        }
                    }
                }
                // For Testing
                if (ddlStudentType.SelectedValue == "1") // dependent
                {
                    //SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", d.GetCheckMailParent(Session["LinkId"].ToString()), "Registration Details", "Thank you for registration", "");
                        if (srev.ToString() == "N".ToString())
                                           
                    {
                        SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "firoj@skylineuniversity.ac.ae", "Admission Details", "Thank you for Admission", "");
                        SendEmail1.SendEmail("admissions@skylineuniversity.ac.ae", "nitin@skylineuniversity.ac.ae", "Admission Details", "Thank you for Admission", "");
                    }
                }
                //Ends Here
            }
            catch
            {
                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", Subject, Body, CC);
            }
            //for sms
            try
            {
                SMSCAPI obj = new SMSCAPI();
                string strPostResponse;
                if (srev.ToString() == "N".ToString())
                {
                    if (ds.Tables[20].Rows.Count != 0)
                    {
                        string ExamType = ds.Tables[20].Rows[0]["ExamType"].ToString().ToUpper();
                        if (ExamType == "Personal Interview")
                        {
                            strPostResponse = obj.SendSMS("", "", "+" + txtMobile.Text, "Dear student your placement test is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + ". For More information contact the marketing officer or log on to your portal ");
                            //strPostResponse = obj.SendSMS("", "", "+971556460999", "Dear student your placement test is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + ". For More information contact the marketing officer or log on to your portal ");
                        }
                        if (ExamType == "Chalange Exam")
                        {
                            strPostResponse = obj.SendSMS("", "", "+" + txtMobile.Text, "Dear student your Challange Exam is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + ". For More information contact the marketing officer or log on to your portal");
                            //strPostResponse = obj.SendSMS("", "", "+971556460999", "Dear student your Challange Exam is scheduled on " + ds.Tables[20].Rows[0]["ExamDate"].ToString().ToUpper() + ". For More information contact the marketing officer or log on to your portal");
                        }
                    }
                }
                string OrtDate = "";
                string OrtTime = "";
                if (GvToefl.Rows.Count != 0)
                {
                    if (rdbHavingToeflNo.Checked == true)
                    {
                        string ExamType = "";
                        string ExamDate = "";

                        ExamDate = ddlExamDateToefl.SelectedItem.Text;
                        ExamType = drpentrancetesttype.SelectedItem.Text;
                        if (ddlExamDateToeflOrt.SelectedIndex != 0)
                            OrtDate = ddlExamDateToeflOrt.SelectedItem.Text;
                        if (ddlExamTimeToeflOrt.SelectedIndex != 0)
                            OrtTime = ddlExamTimeToeflOrt.SelectedItem.Text;

                        if (btnFinalize.Visible == false)
                        {
                            if (srev.ToString() == "N".ToString())
                            {
                                if (OrtDate != "")
                                {
                                    strPostResponse = obj.SendSMS("", "", "+" + txtMobile.Text, "Dear student your " + ExamType + " Exam is scheduled on " + ExamDate + " and the Orientation will be conducted on " + OrtDate + ". For More information contact the marketing officer or log on to your portal ");
                                    //strPostResponse = obj.SendSMS("", "", "+971556460999", "Dear student your " + ExamType + " Exam is scheduled on " + ExamDate + " and the Orientation will be conducted on " + OrtDate + ". For More information contact the marketing officer or log on to your portal ");
                                }
                                else
                                {
                                    strPostResponse = obj.SendSMS("", "", "+" + txtMobile.Text, "Dear student your " + ExamType + " Exam is scheduled on " + ExamDate + ". For More information contact the marketing officer or log on to your portal ");
                                    //strPostResponse = obj.SendSMS("", "", "+971556460999", "Dear student your " + ExamType + " Exam is scheduled on " + ExamDate + ". For More information contact the marketing officer or log on to your portal ");
                                }
                            }
                        }
                    }
                }
                foreach (DataRow ro in ds.Tables[5].Rows)
                {
                    //string Mobile = ro[0].ToString();
                    //string result;
                    //string senderusername = "UName";
                    //string senderpassword = "Password";
                    //string senderid = "UId";
                    //com.vectramind.mobile.Service sms = new Service();
                    //result = sms.SendTextMessage(senderusername, senderpassword, "Hi", 0, senderid, Mobile, 0);
                }
            }
            catch
            {
                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", "CheckSMS", Body, CC);

            }
            //try
            //{
            //    s.InsertFS(Session["LinkId"].ToString());
            //    Proceed(); 
            //}
            //catch
            //{
            //}
            btnFinalize.Visible = false;
            pnlPrintGrid.Visible = true;
            FillGridView1(int.Parse(Session["LinkId"].ToString()));
            lblMesag.Text = "Message Sent Successfully!";
            lblMesag.ForeColor = System.Drawing.Color.Blue;
            DisableButton();
            btnProceed.Text = "View Report";

          
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvReportList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMesagQualification.Text = "";
        btnAddQualification.Enabled = true;
        txtCGPA.Text = "";
        if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
        {
            if (ddlQualification.SelectedValue == "1" || ddlQualification.SelectedValue == "15")
            {
                ddlBachelorDegree.Enabled = true;
                ddlBachelorDegree.SelectedIndex = 0;
                ddlCourseFOrQualification.Enabled = true;
                ddlCourseFOrQualification.SelectedIndex = 0;
            }
            else
            {
                ddlBachelorDegree.Enabled = false;
                ddlBachelorDegree.SelectedIndex = 0;
                ddlCourseFOrQualification.Enabled = false;
                ddlCourseFOrQualification.SelectedIndex = 0;
            }
        }
        else
        {
            ddlBachelorDegree.Enabled = false;
            ddlBachelorDegree.SelectedIndex = 0;
            ddlCourseFOrQualification.Enabled = false;
            ddlCourseFOrQualification.SelectedIndex = 0;
        }
    }
    protected void txtCGPA_TextChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Bacheclor = ddlBachelorDegree.SelectedValue;
          
            if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
                Bacheclor = ddlQualification.SelectedValue;
            if (txtSubjects.Text == "")
                txtSubjects.Text = "0";
            if (Bacheclor == "23" || Bacheclor == "24" || Bacheclor == "BE" || Bacheclor == "NBE")
            {
                DataTable dt = s.GetCGPA(Request.QueryString["Id"].ToString(), Bacheclor, decimal.Parse(txtCGPA.Text), txtPercentage.Text, txtSubjects.Text, ddlYearOfPassing.SelectedItem.Text, int.Parse(ddlCourseFOrQualification.SelectedValue));
                if (dt.Rows.Count != 0)
                {
                    lblMesagQualification.Text = dt.Rows[0][2].ToString();
                    if (int.Parse(dt.Rows[0][1].ToString()) == 1)
                    {
                        btnAddQualification.Enabled = false;
                        lblMesagQualification.ForeColor = System.Drawing.Color.Red;
                        //txtCGPA.Text = "";
                    }
                    else
                    {
                        btnAddQualification.Enabled = true;
                        lblMesagQualification.ForeColor = System.Drawing.Color.Blue;
                        //txtCGPA.Text = "";
                    }
                    ddlCourseFOrQualification.SelectedValue = dt.Rows[0][3].ToString();
                    ddlCourseFOrQualification_SelectedIndexChanged(sender, e);
                    if (ddlCourseFOrQualification.Text == "CHALLENGE EXAM")
                    {
                        pnlChalangeExam.Visible = true;
                        pnlChalange1.Visible = true;
                    }

                }
            }
            else
            {
                btnAddQualification.Enabled = true;
                ddlCourseFOrQualification_SelectedIndexChanged(sender, e);
            }
        }
        catch
        {
            lblMesagQualification.Text = "Please Enter Correct Inputs!";
            lblMesagQualification.ForeColor = System.Drawing.Color.Red;
        }
    
    }
    protected void gvAddGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            //string Id = e.CommandArgument.ToString();
            //Session["RId"] = Id.ToString();

            //StudentRegistrationDAL s = new StudentRegistrationDAL();
            //s.InsertAddedFeeGroup(Request.QueryString["Id"].ToString(), int.Parse(Id));
            //gvAddedFeeGroup.DataSource = s.GetFeesItems(0,int.Parse(Request.QueryString["Id"].ToString()));
            //gvAddedFeeGroup.DataBind();
            //if (gvAddedFeeGroup.Rows.Count == 0)
            //    pnlAddedGroup.Visible = false;
            //else
            //    pnlAddedGroup.Visible = true;

            //ModalPopupExtender1.Hide();
        }
    }
    protected void gvAddedFeeGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Modify"))
        {
            string Id = e.CommandArgument.ToString();
            Session["RId"] = Id.ToString();
            ModalPopupExtender1.Hide();
        }
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string RegNo = s.GetRegNo(Request.QueryString["Id"].ToString());
            if (btnProceed.Text != "Proceed")
            {
                Response.Redirect("ViewInvoice.aspx?Id=" + RegNo, false);
                btnProceed.Enabled = true;
            }
            else
            {
                if (!s.CheckAddGroup(Request.QueryString["Id"].ToString()))
                {
                    int FeeCategoryID = 0;
                    try
                    {
                        DataTable dtt = s.SetDropdownListAsDegreeType(28, int.Parse(Request.QueryString["Id"].ToString()));
                        FeeCategoryID = int.Parse(dtt.Rows[0]["Fees_Category_Id"].ToString());
                    }
                    catch
                    {
                    }

                    s.UpdateAddedFeeGroup(Request.QueryString["Id"].ToString());
                    string Result = "";
                    for (int i = 0; i < gvAddedFeeGroup.Rows.Count; i++)
                    {
                        GridViewRow row = gvAddedFeeGroup.Rows[i];
                        HiddenField hdFeeGroupId = (HiddenField)row.FindControl("hdFeeGroupId");
                        HiddenField hdTypeId = (HiddenField)row.FindControl("hdTypeId");
                        HiddenField hddetailsid = (HiddenField)row.FindControl("hddetailid");
                        Result = s.InsertEMSCMSPI(int.Parse(hdTypeId.Value), RegNo, int.Parse(ddlTerm.SelectedValue), int.Parse(hdFeeGroupId.Value), "", int.Parse(Session["EMPID"].ToString()), FeeCategoryID,int.Parse(hddetailsid.Value) );
                    }
                    if (Result == "Sucess")
                    {
                        Response.Redirect("ViewInvoice.aspx?Id=" + RegNo, false);
                        btnProceed.Enabled = true;
                        btnProceed.Text = "View Report";
                    }
                }
                else
                {
                    btnProceed.Text = "View Report";
                }
            }
        }
        catch
        {
        }
    }


    // for bulkdebit push


    protected void Debitpush(string RegNo)
    {
        try
        {

            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string Result = "";

            Result = s.InsertEMSCMSPIbulk(RegNo);

            if (Result == "Sucess")
            {
                //Response.Redirect("ViewInvoice.aspx?Id=" + RegNo, false);
                btnProceed.Enabled = true;
                btnProceed.Text = "View Report";
            }

            else
            {
                string CC = "";
                string Body = RegNo;
                string FromEmail = "";
                SendEmails.SendEmail(FromEmail, "software@skylineuniversity.ac.ae", "Debitnotpushed", Body, CC);

            }
        }
        catch
        {
        }
    }



    protected void Proceed()
    {
        try
        {
            if (btnFinalize.Visible == true)
            {
                return;
            }
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string RegNo = s.GetRegNo(Request.QueryString["Id"].ToString());
            if (btnProceed.Text != "Proceed")
            {
                Response.Redirect("ViewInvoice.aspx?Id=" + RegNo, false);
                btnProceed.Enabled = true;
            }
            else
            {
                if (!s.CheckAddGroup(Request.QueryString["Id"].ToString()))
                {
                    int FeeCategoryID = 0;
                    try
                    {
                        DataTable dtt = s.SetDropdownListAsDegreeType(28, int.Parse(Request.QueryString["Id"].ToString()));
                        FeeCategoryID = int.Parse(dtt.Rows[0]["Fees_Category_Id"].ToString());
                    }
                    catch
                    {
                    }
                    s.UpdateAddedFeeGroup(Request.QueryString["Id"].ToString());
                    string Result = "";
                    //for (int i = 0; i < gvAddedFeeGroup.Rows.Count; i++)
                    //{
                    //    GridViewRow row = gvAddedFeeGroup.Rows[i];
                    //    HiddenField hdFeeGroupId = (HiddenField)row.FindControl("hdFeeGroupId");
                    //    HiddenField hdTypeId = (HiddenField)row.FindControl("hdTypeId");
                    //    HiddenField hddetailid = (HiddenField)row.FindControl("hddetailid");
                    //    Result = s.InsertEMSCMSPI(int.Parse(hdTypeId.Value), RegNo, int.Parse(ddlTerm.SelectedValue), int.Parse(hdFeeGroupId.Value), "", int.Parse(Session["EMPID"].ToString()), FeeCategoryID, int.Parse(hddetailid.Value));
                    //}
                    //if (Result == "Sucess")
                    //{
                    //    //Response.Redirect("ViewInvoice.aspx?Id=" + RegNo, false);
                    //    btnProceed.Enabled = true;
                    //    btnProceed.Text = "View Report";
                    //}
                }
                else
                {
                    btnProceed.Text = "View Report";
                }
            }
        }
        catch
        {
        }
    }
    public void CheckAddGroup()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (s.CheckAddGroup(Request.QueryString["Id"].ToString()))
        {
            btnProceed.Text = "View Report";
        }
    }
    decimal Total = 0;
    protected void gvAddedFeeGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Total = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            if (lblAmount.Text != "")
            {
                Total = Total + decimal.Parse(lblAmount.Text);
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFooterUName = (Label)e.Row.FindControl("lblFooterUNamea");
            lblFooterUName.Text = Total.ToString();
        }
    }
    protected void chkSpecialApproval_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSpecialApproval.Checked == false)
        {
            btnAddQualification.Enabled = false;
            lblMesagQualification.Text = "";
        }
        else
        {
            chkRejected.Checked = false;
            btnAddQualification.Enabled = true;
            lblMesagQualification.Text = "";
        }
    }
    protected void chkRejected_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRejected.Checked == true)
        {
            btnAddQualification.Enabled = true;
            lblMesagQualification.Text = "";
            chkSpecialApproval.Checked = false;
        }
        else
        {
            btnAddQualification.Enabled = false;
            lblMesagQualification.Text = "";
        }
    }
    protected void btnAddFileNumber_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            Session["LinkId"] = Request.QueryString["Id"].ToString();
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
    protected void ddlBachelorDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCGPA.Text = "";
        if (ddlBachelorDegree.SelectedValue == "NBE")
        {
            ddlCourseFOrQualification.Enabled = false;
            ddlCourseFOrQualification.SelectedIndex = 0;
        }
        else if (ddlBachelorDegree.SelectedValue == "BE")
        {
            ddlCourseFOrQualification.Enabled = true;
        }
    }
    protected void ddlCourseFOrQualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCGPA.Text = "";
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        if (ddlCourseFOrQualification.SelectedValue == "2")
        {
            ddlChalangeExamDate.DataSource = s.SetDropdownListCDB(69);
            ddlChalangeExamDate.DataTextField = "Date";
            ddlChalangeExamDate.DataValueField = "Id";
            ddlChalangeExamDate.DataBind();
            ddlChalangeExamTime.DataSource = s.SetDropdownListCDB(67);
            ddlChalangeExamTime.DataTextField = "Date";
            ddlChalangeExamTime.DataValueField = "Id";
            ddlChalangeExamTime.DataBind();
            pnlChalangeExam.Visible = true;
            pnlChalange1.Visible = false;
            pnlChalange2.Visible = true;
        }
        else if (ddlCourseFOrQualification.SelectedValue == "3")
        {
            ddlChalangeExamDate.DataSource = s.SetDropdownListCDB(68);
            ddlChalangeExamDate.DataTextField = "Date";
            ddlChalangeExamDate.DataValueField = "Id";
            ddlChalangeExamDate.DataBind();
            ddlChalangeExamTime.DataSource = s.SetDropdownListCDB(66);
            ddlChalangeExamTime.DataTextField = "Date";
            ddlChalangeExamTime.DataValueField = "Id";
            ddlChalangeExamTime.DataBind();
            pnlChalangeExam.Visible = true;
            pnlChalange1.Visible = true;
            pnlChalange2.Visible = false;
            //New For Seven Course
            ddlMqpDate11.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate11.DataTextField = "Date";
            ddlMqpDate11.DataValueField = "Id";
            ddlMqpDate11.DataBind();
            ddlMqpTime11.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime11.DataTextField = "Date";
            ddlMqpTime11.DataValueField = "Id";
            ddlMqpTime11.DataBind();

            ddlMqpDate12.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate12.DataTextField = "Date";
            ddlMqpDate12.DataValueField = "Id";
            ddlMqpDate12.DataBind();
            ddlMqpTime12.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime12.DataTextField = "Date";
            ddlMqpTime12.DataValueField = "Id";
            ddlMqpTime12.DataBind();

            ddlMqpDate13.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate13.DataTextField = "Date";
            ddlMqpDate13.DataValueField = "Id";
            ddlMqpDate13.DataBind();
            ddlMqpTime13.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime13.DataTextField = "Date";
            ddlMqpTime13.DataValueField = "Id";
            ddlMqpTime13.DataBind();

            ddlMqpDate14.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate14.DataTextField = "Date";
            ddlMqpDate14.DataValueField = "Id";
            ddlMqpDate14.DataBind();
            ddlMqpTime14.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime14.DataTextField = "Date";
            ddlMqpTime14.DataValueField = "Id";
            ddlMqpTime14.DataBind();

            ddlMqpDate15.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate15.DataTextField = "Date";
            ddlMqpDate15.DataValueField = "Id";
            ddlMqpDate15.DataBind();
            ddlMqpTime15.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime15.DataTextField = "Date";
            ddlMqpTime15.DataValueField = "Id";
            ddlMqpTime15.DataBind();


            ddlMqpDate16.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate16.DataTextField = "Date";
            ddlMqpDate16.DataValueField = "Id";
            ddlMqpDate16.DataBind();
            ddlMqpTime16.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime16.DataTextField = "Date";
            ddlMqpTime16.DataValueField = "Id";
            ddlMqpTime16.DataBind();

            ddlMqpDate17.DataSource = s.SetDropdownListCDB(68);
            ddlMqpDate17.DataTextField = "Date";
            ddlMqpDate17.DataValueField = "Id";
            ddlMqpDate17.DataBind();
            ddlMqpTime17.DataSource = s.SetDropdownListCDB(66);
            ddlMqpTime17.DataTextField = "Date";
            ddlMqpTime17.DataValueField = "Id";
            ddlMqpTime17.DataBind();
            //Ends Here
        }
        else
            pnlChalangeExam.Visible = false;
    }
    protected void ddlYearOfPassing_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCGPA.Text = "";
    }
    protected void chkVisaAddGroup_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbSkylineVisaYes.Checked == true)
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            int FeeGroupId = s.GetVisaFeeGroup(Request.QueryString["Id"].ToString());
            int TypeId = 8;
            AddFeeGroup(FeeGroupId, TypeId);
            
        }
        else
        {

        }
    }
    public void AddFeeGroup(int FeeGroupId, int TypeId)
    {
        //StudentRegistrationDAL s = new StudentRegistrationDAL();
        ////s.InsertAddedFeeGroup(Request.QueryString["Id"].ToString(), FeeGroupId, TypeId);
        //gvAddedFeeGroup.DataSource = s.GetFeesItems(0, int.Parse(Request.QueryString["Id"].ToString()));
        //gvAddedFeeGroup.DataBind();
        //if (gvAddedFeeGroup.Rows.Count == 0)
        //    pnlAddedGroup.Visible = false;
        //else
        //    pnlAddedGroup.Visible = true;
    }
    public void InsertFeeGroup()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        //s.InsertAddedFeeGroup(Request.QueryString["Id"].ToString(), FeeGroupId, TypeId);
        s.InsertFeeGroup(Request.QueryString["Id"].ToString(), "StudentRegistration.aspx");
        gvAddedFeeGroup.DataSource = s.GetFeesItems(0, int.Parse(Request.QueryString["Id"].ToString()));
        gvAddedFeeGroup.DataBind();
        if (gvAddedFeeGroup.Rows.Count == 0)
            pnlAddedGroup.Visible = false;
        else
            pnlAddedGroup.Visible = true;
    }
    protected void btnSaveVDType_Click(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            Session["LinkId"] = Request.QueryString["Id"].ToString();
            string Result = s.InsertOtherVisaDetails(Session["LinkId"].ToString(), RadioButton1.Checked, RadioButton2.Checked);
            if (Result == "RegisterNo")
            {
                lblMesagVisa.Text = "Added Sucessfully!";
                lblMesagVisa.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMesagVisa.Text = "Try Again!";
                lblMesagVisa.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblMesagVisa.Text = "Try Again!";
            lblMesagVisa.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlUniversityName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUniversityName.SelectedIndex != 0)
            {
                txtUniversityNameProgram.Text = ddlUniversityName.SelectedItem.Text;
                txtCGPATOC_TextChanged(sender, e);
            }
            else
                txtUniversityNameProgram.Text = "";
            if (ddlUniversityName.SelectedItem.Text == "Others")
            {
                txtUniversityNameProgram.Text = "";
                pnlOtherUniversity.Visible = true;
            }
            else
                pnlOtherUniversity.Visible = false;
        }
        catch
        {
        }
    }
    protected void txtCGPATOC_TextChanged(object sender, EventArgs e)
    {
        lblTOCMesag.Text = "";
        pnlCgpAToc.Visible = false;
        if (ddlUniversityName.SelectedItem.Text.Contains("HCT"))
        {
            txtCGPATOC.Enabled = true;
            if (txtCGPATOC.Text != "")
            {
                DateTime dtt = DateTime.Now.AddDays(2);
                txtFollowYear.Text = dtt.Year.ToString();
                txtFollowMonth.Text = dtt.Month.ToString();
                txtFollowDate.Text = dtt.Day.ToString();
                if (ddlDegreeType.SelectedValue == "1" || ddlDegreeType.SelectedValue == "7")
                {
                    if (decimal.Parse(txtCGPATOC.Text) < 2)
                    {
                        btnSubmitToc.Enabled = false;
                        btnUpdateToc.Enabled = false;
                        lblTOCMesag.Text = "CGPA should be greater than or equal to 2.0! Sorry Not eligible for TOC";
                        lblTOCMesag.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        btnSubmitToc.Enabled = true;
                        btnUpdateToc.Enabled = true;
                        pnlCgpAToc.Visible = true;
                        return;
                    }
                }
                else if (ddlDegreeType.SelectedValue == "6" || ddlDegreeType.SelectedValue == "8")
                {
                    if (decimal.Parse(txtCGPATOC.Text) < 2)
                    {
                        btnSubmitToc.Enabled = false;
                        btnUpdateToc.Enabled = false;
                        lblTOCMesag.Text = "CGPA should be greater than or equal to 2.0! Sorry Not eligible for TOC";
                        lblTOCMesag.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        btnSubmitToc.Enabled = true;
                        btnUpdateToc.Enabled = true;
                        pnlCgpAToc.Visible = true;
                        return;
                    }
                }
                else
                {
                    btnSubmitToc.Enabled = true;
                    btnUpdateToc.Enabled = true;
                    pnlCgpAToc.Visible = true;
                    return;
                }
            }
            else
            {

            }
        }
        else if (ddlUniversityName.SelectedItem.Text.Contains("AJMAN"))
        {
            if (decimal.Parse(txtCGPATOC.Text) < 4)
            {
                btnSubmitToc.Enabled = false;
                btnUpdateToc.Enabled = false;
                lblTOCMesag.Text = "CGPA should be greater than or equal to 4.0! Sorry Not eligible for TOC";
                lblTOCMesag.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                btnSubmitToc.Enabled = true;
                btnUpdateToc.Enabled = true;
                pnlCgpAToc.Visible = true;
                return;
            }
        }
        else
        {
            btnSubmitToc.Enabled = true;
            btnUpdateToc.Enabled = true;
            pnlCgpAToc.Visible = true;
            txtCGPATOC.Enabled = true;
            return;
        }
    }

    protected void drpentrancetesttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnlHavingToeflYes.Visible = false;
            StudentRegistrationDAL s = new StudentRegistrationDAL();

           
            //ddlExamDateToefl.DataSource = s.SetDropdownListAsDegreeType(32, int.Parse(drpentrancetesttype.SelectedValue.ToString()));
            //ddlExamDateToefl.DataTextField = "Date";
            //ddlExamDateToefl.DataValueField = "Id";
            //ddlExamDateToefl.DataBind();

            CheckConditionForExamDate();


            //ddlExamTimeToefl.DataSource = s.SetDropdownListAsDegreeType(33, int.Parse(drpentrancetesttype.SelectedValue.ToString()));
            //ddlExamTimeToefl.DataTextField = "Date";
            //ddlExamTimeToefl.DataValueField = "Id";
            //ddlExamTimeToefl.DataBind();

         



            DataTable dt = s.SetDropdownListAsDegreeType(5, int.Parse(ddlDiscountType.SelectedValue));
            // Orientation Date
            try
            {
                ddlExamTimeToeflOrt.Items.Clear();
                ddlExamDateToeflOrt.DataSource = s.SetDropdownListAsDegreeType(35, int.Parse(drpentrancetesttype.SelectedValue.ToString()));
                ddlExamDateToeflOrt.DataTextField = "Date";
                ddlExamDateToeflOrt.DataValueField = "Id";
                ddlExamDateToeflOrt.DataBind();
                ddlExamDateToeflOrt.SelectedIndex = 0;
                try
                {

                    ddlExamTimeToeflOrt.DataSource = s.SetDropdownListAsDegreeType(41, int.Parse(ddlExamDateToeflOrt.SelectedValue));
                    ddlExamTimeToeflOrt.DataTextField = "Date";
                    ddlExamTimeToeflOrt.DataValueField = "Id";
                    ddlExamTimeToeflOrt.DataBind();
                    ddlExamTimeToeflOrt.SelectedIndex = 0;
                }
                catch
                {
                    ddlExamTimeToeflOrt.DataSource = s.SetDropdownListAsDegreeType(36, int.Parse(drpentrancetesttype.SelectedValue.ToString()));
                    ddlExamTimeToeflOrt.DataTextField = "Date";
                    ddlExamTimeToeflOrt.DataValueField = "Id";
                    ddlExamTimeToeflOrt.DataBind();
                }
            }
            catch
            {

            }


        }
        catch
        {

        }
    }

    protected void  ddlExamDateToefl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt = s.SetDropdownListAsDegreeType(5, int.Parse(ddlDiscountType.SelectedValue));

            try
            {

                ddlExamTimeToefl.DataSource = s.SetDropdownListAsDegreeType(41, int.Parse(ddlExamDateToefl.SelectedValue));
                ddlExamTimeToefl.DataTextField = "Date";
                ddlExamTimeToefl.DataValueField = "Id";
                ddlExamTimeToefl.DataBind();


            }

            catch
            {
                ddlExamTimeToefl.DataSource = s.SetDropdownListAsDegreeType(33, int.Parse(drpentrancetesttype.SelectedValue.ToString()));
                ddlExamTimeToefl.DataTextField = "Date";
                ddlExamTimeToefl.DataValueField = "Id";
                ddlExamTimeToefl.DataBind();

            }


            // Orientation Date
            //ddlExamDateToeflOrt.DataSource = s.SetDropdownListCDB(78);
            //ddlExamDateToeflOrt.DataTextField = "Date";
            //ddlExamDateToeflOrt.DataValueField = "Id";
            //ddlExamDateToeflOrt.DataBind();
           
            // Ends Here
        }
        catch
        {
        }
    }
  
    protected void chkMQPCourse_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMQPCourse.Checked == false)
        {
            pnlSubject.Visible = false;
        }
        else
        {
            pnlSubject.Visible = true;
        }
    }
    protected void chkIELTSCourse_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIELTSCourse.Checked == true)
            pnlSC.Visible = true;
        else
            pnlSC.Visible = false;
    }
    protected void Chkmilitary_CheckedChanged(object sender, EventArgs e)
    {
        if (Chkmilitary.Checked == true)
        {
            
            btnAddQualification.Enabled = true;
            
            btnUpdateQualification.Enabled = true;




                    }
    }
    protected void GvToefl_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    public void showresult(object sender, EventArgs e)
    {

        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = s.StudentEntranceResult(s.GetRegNo(Request.QueryString["Id"].ToString()));
        grdentrance.DataSource = dt;
        grdentrance.DataBind();
        ModalPopupExtender2.Show();
    }
    protected void lbMediaSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            drpagent.Items.Clear();
            string MediaSource = "";
            for (int i = 0; i < lbMediaSource.Items.Count - 1; i++)
            {
                if (lbMediaSource.Items[i].Selected == true)
                {
                    MediaSource = MediaSource + lbMediaSource.Items[i].Text + ",";
                    if (lbMediaSource.Items[i].Text.Contains("NIGERIA AGENT") || lbMediaSource.Items[i].Text.Contains("Nigeria Agent"))
                    {
                                                StudentRegistrationDAL s = new StudentRegistrationDAL();
                        drpagent.DataSource = s.SetDropdownListAsDegreeType(34, 33);
                        drpagent.DataTextField = "AgencyName";
                        drpagent.DataValueField = "Agentid";
                        drpagent.DataBind();
                    }
                    if (lbMediaSource.Items[i].Text.Contains("Pakistan Agent") || lbMediaSource.Items[i].Text.Contains("PAKISTAN AGENT"))
                    {
                                                StudentRegistrationDAL s = new StudentRegistrationDAL();
                        drpagent.DataSource = s.SetDropdownListAsDegreeType(34, 31);
                        drpagent.DataTextField = "AgencyName";
                        drpagent.DataValueField = "Agentid";
                        drpagent.DataBind();
                    }

                    if (lbMediaSource.Items[i].Text.Contains("TAJIKISTAN AGENT") || lbMediaSource.Items[i].Text.Contains("Tajikistan Agent"))
                    {
                        StudentRegistrationDAL s = new StudentRegistrationDAL();
                        drpagent.DataSource = s.SetDropdownListAsDegreeType(34, 34);
                        drpagent.DataTextField = "AgencyName";
                        drpagent.DataValueField = "Agentid";
                        drpagent.DataBind();
                    }

                    if (lbMediaSource.Items[i].Text.Contains("MOROCCO AGENT") || lbMediaSource.Items[i].Text.Contains("Morocco Agent"))
                    {
                        StudentRegistrationDAL s = new StudentRegistrationDAL();
                        drpagent.DataSource = s.SetDropdownListAsDegreeType(34, 32);
                        drpagent.DataTextField = "AgencyName";
                        drpagent.DataValueField = "Agentid";
                        drpagent.DataBind();
                    }

                
                }
            }
        }
        catch
        {
        }

    }

    protected void ddlMathEntranceExam_changed(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            ddlMathEntranceExamTime.DataSource = s.SetDropdownListAsDegreeType(42, int.Parse(ddlMathEntranceExam.SelectedValue));
            ddlMathEntranceExamTime.DataTextField = "Date";
            ddlMathEntranceExamTime.DataValueField = "Id";
            ddlMathEntranceExamTime.DataBind();

        }

        catch
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            ddlMathEntranceExamTime.DataSource = s.SetDropdownListCDB(31);
            ddlMathEntranceExamTime.DataTextField = "Date";
            ddlMathEntranceExamTime.DataValueField = "Id";
            ddlMathEntranceExamTime.DataBind();

        }

    }

    protected void btn_Load_Security_Clearance(object sender, EventArgs e)
    {
        Response.Redirect("SecurityClearance.aspx?LinkId=" + Request.QueryString["Id"].ToString());
    }

    protected void chkintegrated_CheckedChanged(object sender, EventArgs e)
    {
        if (chkintegrated.Checked == true)
        {
            if (rdbProgramRegular.Checked == true)
                ddlDegreeType.SelectedValue = "1";

            if (rdbProgramWeekend.Checked == true)
                ddlDegreeType.SelectedValue = "7";

            ddlDegreeType.Enabled = false;
            ddlDegreeType_SelectedIndexChanged(sender, e);

        }
        else
            ddlDegreeType.Enabled = true;



    }


}