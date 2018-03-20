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
using System.Net.NetworkInformation;


public partial class Pages_SecurityClearance : System.Web.UI.Page
{

    StudentRegistrationDAL s = new StudentRegistrationDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        int LinkId = int.Parse(Request.QueryString["LinkId"].ToString());
        if (!IsPostBack)
        {
            try
            {
               
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                DataSet dt = new DataSet();
                dt = s.SetStudentsDetails_SecurityClearance(LinkId);
                foreach (DataRow ro in dt.Tables[0].Rows)
                {
                    txt_name.Text = ro["Student_Name"].ToString();
                    txt_RegisterId.Text = ro["RegistrationNo"].ToString();
                    //txt_dateofBirth.Text = ro["DOB"].ToString();
                    //txt_CurrentNationality.Text = ro["NationalityName"].ToString();
                    txt_FathersName.Text = ro["Father"].ToString();
                    txt_mothersname.Text = ro["Mother"].ToString();
                    txt_Qualification.Text = ro["Qualification"].ToString();                    
                }

                ddlPermanentCountry.DataSource = s.SetDropdownListCDB(2);
                ddlPermanentCountry.DataTextField = "NationalityName";
                ddlPermanentCountry.DataValueField = "NationalityCode";
                ddlPermanentCountry.DataBind();

                ddl_CurrentNationality.DataSource = s.SetDropdownListCDB(2);
                ddl_CurrentNationality.DataTextField = "NationalityName";
                ddl_CurrentNationality.DataValueField = "NationalityCode";
                ddl_CurrentNationality.DataBind();

                ddl_previousNationality.DataSource = s.SetDropdownListCDB(2);
                ddl_previousNationality.DataTextField = "NationalityName";
                ddl_previousNationality.DataValueField = "NationalityCode";
                ddl_previousNationality.DataBind();

                ddl_spouseNationality.DataSource = s.SetDropdownListCDB(2);
                ddl_spouseNationality.DataTextField = "NationalityName";
                ddl_spouseNationality.DataValueField = "NationalityCode";
                ddl_spouseNationality.DataBind();

                DDL_spousemartPob.DataSource = s.SetDropdownListCDB(2);
                DDL_spousemartPob.DataTextField = "NationalityName";
                DDL_spousemartPob.DataValueField = "NationalityCode";
                DDL_spousemartPob.DataBind();

                ddl_FatNationality.DataSource = s.SetDropdownListCDB(2);
                ddl_FatNationality.DataTextField = "NationalityName";
                ddl_FatNationality.DataValueField = "NationalityCode";
                ddl_FatNationality.DataBind();

                ddl_FathersPob.DataSource = s.SetDropdownListCDB(2);
                ddl_FathersPob.DataTextField = "NationalityName";
                ddl_FathersPob.DataValueField = "NationalityCode";
                ddl_FathersPob.DataBind();

                ddl_mothersNationality.DataSource = s.SetDropdownListCDB(2);
                ddl_mothersNationality.DataTextField = "NationalityName";
                ddl_mothersNationality.DataValueField = "NationalityCode";
                ddl_mothersNationality.DataBind();

                ddl_MothersPOB.DataSource = s.SetDropdownListCDB(2);
                ddl_MothersPOB.DataTextField = "NationalityName";
                ddl_MothersPOB.DataValueField = "NationalityCode";
                ddl_MothersPOB.DataBind();

                ddl_miltrycountryName.DataSource = s.SetDropdownListCDB(2);
                ddl_miltrycountryName.DataTextField = "NationalityName";
                ddl_miltrycountryName.DataValueField = "NationalityCode";
                ddl_miltrycountryName.DataBind();

                ddl_contactNationality.DataSource = s.SetDropdownListCDB(2);
                ddl_contactNationality.DataTextField = "NationalityName";
                ddl_contactNationality.DataValueField = "NationalityCode";
                ddl_contactNationality.DataBind();

                ddl_VisitedCountry.DataSource = s.SetDropdownListCDB(2);
                ddl_VisitedCountry.DataTextField = "NationalityName";
                ddl_VisitedCountry.DataValueField = "NationalityCode";
                ddl_VisitedCountry.DataBind();

                ddl_VisitedCountry2.DataSource = s.SetDropdownListCDB(2);
                ddl_VisitedCountry2.DataTextField = "NationalityName";
                ddl_VisitedCountry2.DataValueField = "NationalityCode";
                ddl_VisitedCountry2.DataBind();

                ddl_VisitedCountry3.DataSource = s.SetDropdownListCDB(2);
                ddl_VisitedCountry3.DataTextField = "NationalityName";
                ddl_VisitedCountry3.DataValueField = "NationalityCode";
                ddl_VisitedCountry3.DataBind();

                ddl_VisitedCountry4.DataSource = s.SetDropdownListCDB(2);
                ddl_VisitedCountry4.DataTextField = "NationalityName";
                ddl_VisitedCountry4.DataValueField = "NationalityCode";
                ddl_VisitedCountry4.DataBind();

                ddl_VisitedCountry5.DataSource = s.SetDropdownListCDB(2);
                ddl_VisitedCountry5.DataTextField = "NationalityName";
                ddl_VisitedCountry5.DataValueField = "NationalityCode";
                ddl_VisitedCountry5.DataBind();

            }
            catch(Exception ex)
            {
                
            }
           
        }  

    }

    protected void btn_saveClick(object sender, EventArgs e)
    {
        Int32 LinkId =  Convert.ToInt32(Request.QueryString["LinkId"].ToString());
        string Register_No = Convert.ToString(txt_RegisterId.Text);
        string Student_Name  = Convert.ToString(txt_name.Text); 
        string Religion =Convert.ToString(txt_religion.Text); 
        string Doctrine = Convert.ToString(txt_Doctrine.Text) ;
        string POB = Convert.ToString(ddlPermanentCountry.SelectedItem.Text);
        string[] stringdate4 = new string[3];

        if (txt_dateofBirth.Text != "")
        {
            stringdate4 = txt_dateofBirth.Text.Split('-');
        }
        else
        {
            stringdate4 = Convert.ToString("01-01-1990").Split('-');
        }
        DateTime Dateofbirth = new DateTime(Convert.ToInt32(stringdate4[2]), Convert.ToInt32(stringdate4[1]), Convert.ToInt32(stringdate4[0]));

        DateTime DOB = Dateofbirth ;
        string Current_Nationality = Convert.ToString(ddl_CurrentNationality.SelectedItem.Text);
        string previous_Nationality = Convert.ToString(ddl_previousNationality.SelectedItem.Text);
        string created_by = Convert.ToString(Session["EmpId"].ToString());
        string created_Ip  =GetMacAddress();

        string Type_Of_Qualification = Convert.ToString(txt_Qualification.Text);
        string Languages_Known = Convert.ToString(txt_Languages.Text);

        string spouseName = Convert.ToString(txt_Spousename.Text);
        string SpouseNationality = Convert.ToString(ddl_spouseNationality.SelectedItem.Text);
        string spousePob = Convert.ToString(DDL_spousemartPob.SelectedItem.Text);
        string[] stringdatespouse = new string[3];
        if (txt_SpouseDOB.Text != "")
        {
            stringdatespouse = txt_SpouseDOB.Text.Split('-');
        }
        else
        {
           stringdatespouse= Convert.ToString("01-01-1990").Split('-');
        }

        DateTime SpouseDateofbirth = new DateTime(Convert.ToInt32(stringdatespouse[2]), Convert.ToInt32(stringdatespouse[1]), Convert.ToInt32(stringdatespouse[0]));
        int ChildrensNo = 0;
        if (txt_Childrens.Text != "")
        {
             ChildrensNo = Convert.ToInt16(txt_Childrens.Text);
        }
        else
        {
            ChildrensNo = 0;
        }

        string Fathersname  = Convert.ToString(txt_FathersName.Text);
        string FatherNationality = Convert.ToString(ddl_FatNationality.SelectedItem.Text);
        string FatherPob = Convert.ToString(ddl_FathersPob.SelectedItem.Text);
        //DateTime FatherDOB ="";
        string[] FathersDOB = new string[3];
        if (txt_FathersDateofbirth.Text != "")
        {
            FathersDOB = txt_FathersDateofbirth.Text.Split('-');
        }
        else
        {
            FathersDOB = Convert.ToString("01-01-1990").Split('-');
        }
        DateTime FathersDateOfBirth = new DateTime(Convert.ToInt32(FathersDOB[2]), Convert.ToInt32(FathersDOB[1]), Convert.ToInt32(FathersDOB[0]));
        string MotherName = Convert.ToString(txt_mothersname.Text);
        string MotherNationality = Convert.ToString(ddl_mothersNationality.SelectedItem.Text);
        string MotherPOB = Convert.ToString(ddl_MothersPOB.SelectedItem.Text);
       
        string[] MotherDOB = new string[3];
        if (txt_MothersDob.Text != "")
        {
            MotherDOB = txt_MothersDob.Text.Split('-');
        }
        else
        {
            MotherDOB = Convert.ToString("01-01-1990").Split('-');
        }
        DateTime MothersDateOfBirth = new DateTime(Convert.ToInt32(MotherDOB[2]), Convert.ToInt32(MotherDOB[1]), Convert.ToInt32(MotherDOB[0]));

        string Mobileno = Convert.ToString(txt_ContactMobileno.Text);
        string Residence_no = Convert.ToString(txt_ResidenceNumber.Text);
        string Email_Id = Convert.ToString(txt_EmailId.Text);
        string Website = Convert.ToString(txt_Website.Text);
        string twitter = Convert.ToString(txt_Twitter.Text);
        string Facebook = Convert.ToString(txt_Facebook.Text);
        string Military_Exp = Convert.ToString(txt_Militry.Text);
        string Military_Country = Convert.ToString(ddl_miltrycountryName.SelectedItem.Text);
        string Type_Of_Service = Convert.ToString(txt_TypeOfService.Text);
        string Military_rank = Convert.ToString(txt_militryRank.Text);
        string Duration = Convert.ToString(txt_Duration.Text);
        string ContactPerson_name = Convert.ToString(txt_ContactPerson.Text);
        string Contact_Nationality = Convert.ToString(ddl_contactNationality.SelectedItem.Text);
        string contact_WorkPlace = Convert.ToString(txt_WorkPlace.Text);
        string Contact_Mobileno = Convert.ToString(txt_ContactMobileno.Text);
        string Visited_Country1 = Convert.ToString(ddl_VisitedCountry.SelectedItem.Text);
        string Visited_Country2 = Convert.ToString(ddl_VisitedCountry2.SelectedItem.Text);
        string Visited_Country3 = Convert.ToString(ddl_VisitedCountry3.SelectedItem.Text);
        string Visited_Country4 = Convert.ToString(ddl_VisitedCountry4.SelectedItem.Text);
        string Visited_Country5 = Convert.ToString(ddl_VisitedCountry5.SelectedItem.Text);

        DataTable dt = s.IsSecurityClearance_AlreadyExists(Convert.ToInt32(Request.QueryString["LinkId"].ToString()));
         if (dt.Rows.Count > 0)
         {
             lbl_showmsg.Visible = true;
             lbl_showmsg.Text = "Security Clearance already entered";
         }
         else
         {
             s.Insert_Security_Personal_Details(LinkId, Register_No, Student_Name, Religion, Doctrine, POB, Dateofbirth, Current_Nationality, previous_Nationality, created_by, created_Ip);
             s.Insert_Security_Qualification_Details(LinkId, Register_No, Type_Of_Qualification, Languages_Known);
             s.Insert_Security_Marital_Details(LinkId, Register_No, spouseName, SpouseNationality, spousePob, SpouseDateofbirth);
             s.Insert_Security_Children_Info(LinkId, Register_No, ChildrensNo);
             s.Insert_Security_Parent_Info(LinkId, Register_No, Fathersname, FatherNationality, FatherPob, FathersDateOfBirth, MotherName, MotherNationality, MotherPOB, MothersDateOfBirth);
             s.Insert_Security_Contact_Info(LinkId, Register_No, Mobileno, Residence_no, Email_Id, Website, twitter, Facebook, Military_Exp, Military_Country, Type_Of_Service,
                 Military_rank, Duration, ContactPerson_name, Contact_Nationality, contact_WorkPlace, Contact_Mobileno, Visited_Country1, Visited_Country2,
                 Visited_Country3, Visited_Country4, Visited_Country5);
             lbl_showmsg.Visible = true;
             Response.Redirect("StudentRegistration.aspx?Id=" + Request.QueryString["LinkId"].ToString());
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

}