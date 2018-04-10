using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Diagnostics;
using System.Threading;




public partial class Pages_COECReportmail : System.Web.UI.Page
{
   
    string[] BBAWeekdaypdfs;
    string[] BBAWeekendpdfs;
    string[] BBAWeekdaypdfspath; 
    string[] BBAWeekendpdfspath ;
    string[] MBAWeekdaypdfs ;
    string[] MBAWeekendpdfs;
    string[] MBAWeekdaypdfspath; 
    string[] MBAWeekendpdfspath ;
    string[] connationpdf = new string[1];
    string[] connationpdfpath = new string[1];
    string[] constatpdf= new string[1];
    string[] constatpdfpath = new string[1];
   
    string[] Overallpdfs;
    string[] Overallpdfspath;
    int flag = 0;
    int errorflag = 0;
    string errormess;
    int attlength = 0;

    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmess.Visible = true;
        errorflag = 0;
        if (Session["EmpId"] == null || Session["EmpId"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }

        if ((Session["EMPID"].ToString() == "1636") || (Session["EMPID"].ToString() == "918") || (Session["EMPID"].ToString() == "1620"))
        {


            if (!Page.IsPostBack)
            {
                try
                {
                    StudentRegistrationDAL s = new StudentRegistrationDAL();

                    pnlview.Visible = false;
                    pnlpopup.Visible = false;

                    ddlTerm.DataSource = s.SetDropdownListCDB(115);
                    ddlTerm.DataTextField = "Term";
                    ddlTerm.DataValueField = "TermId";
                    ddlTerm.DataBind();

                    ddlprevious.DataSource = s.SetDropdownListCDB(116);
                    ddlprevious.DataTextField = "Term";
                    ddlprevious.DataValueField = "TermId";
                    ddlprevious.DataBind();
                    lblmess.Text = "";
                    lblmess.ForeColor = System.Drawing.Color.Blue;
                    loadarray();
                    StudentRegistrationDAL SDAL = new StudentRegistrationDAL();
                    DataTable dt1 = SDAL.GetCOECReportsMailLogs(0, 2);
                    lblmaildate.Text = dt1.Rows[0][0].ToString();
                    


                }

                catch (Exception ex)
                {
                }
            }
        }
        else
        {
            Response.Redirect("login.aspx");

        }
    }
    protected void brnCloseInvoice_Click(object sender, EventArgs e)
    {
        pnlpopup.Visible = false;
    }

 protected void   loadarray()


    {
        lblmess.Visible = true;  
     StudentRegistrationDAL s = new StudentRegistrationDAL();
        DataTable dt = s.GetCOECReportsListcount(0);
        foreach (DataRow row in dt.Rows)
        {
            if (int.Parse(row["degreetype"].ToString()) == 1)
            {
                BBAWeekdaypdfs = new string[int.Parse(row["count1"].ToString())];
                BBAWeekdaypdfspath = new string[int.Parse(row["count1"].ToString())];

            }

            if (int.Parse(row["degreetype"].ToString()) == 7)
            {
                BBAWeekendpdfs = new string[int.Parse(row["count1"].ToString())];
                BBAWeekendpdfspath = new string[int.Parse(row["count1"].ToString())];

            }
            if (int.Parse(row["degreetype"].ToString()) == 6)
            {
                MBAWeekdaypdfs = new string[int.Parse(row["count1"].ToString())];
                MBAWeekdaypdfspath = new string[int.Parse(row["count1"].ToString())];

            }
            if (int.Parse(row["degreetype"].ToString()) == 8)
            {
                MBAWeekendpdfs = new string[int.Parse(row["count1"].ToString())];
                MBAWeekendpdfspath = new string[int.Parse(row["count1"].ToString())];

            }

            if (int.Parse(row["degreetype"].ToString()) == 0)
            {
                Overallpdfs = new string[int.Parse(row["count1"].ToString())];
                Overallpdfspath = new string[int.Parse(row["count1"].ToString())];

            }


        }



}


    protected void createreport(string reprotname, int degreetype,string order,string FilePath,bool issameparam,int single)
    {
        try
        {

            if ((degreetype != -3) && (degreetype != -4) &&  (degreetype !=-5))
            {
                string reportnamerpt = reprotname + ".rpt";

                string reprotnamepdf = order + reprotname + ".pdf";

                System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
                string Path = Server.MapPath(reportnamerpt);
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path.Substring(0, Path.LastIndexOf('\\'));
                Path = Path + "\\Report\\Testems\\" + reportnamerpt;
                myReportDocument.Load(Path);

                if (issameparam == false)
                {
                    if (degreetype == -1 || degreetype == -2) degreetype = 0;
                    myReportDocument.SetParameterValue("@TermId", ddlTerm.SelectedValue);
                    myReportDocument.SetParameterValue("@DegreeType", degreetype);
                    if (reprotname == "CancellationAndPostponementEnrollmentStatistics")
                    {
                        myReportDocument.SetParameterValue("@Fromdate", txtFromDate.Text);
                    }
                    else
                        myReportDocument.SetParameterValue("@Fromdate", null);

                    myReportDocument.SetParameterValue("@Todate", null);

                    myReportDocument.SetParameterValue("@AYYear", null);
                }






                else
                {
                    myReportDocument.SetParameterValue("@FromTermId", ddlprevious.SelectedValue);
                    myReportDocument.SetParameterValue("@ToTermId", ddlTerm.SelectedValue);
                }

                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");


                //stream1 = null;
                //ExportOptions ex = myReportDocument.ExportOptions;
                //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                //ExportRequestContext x = new ExportRequestContext();
                //x.ExportInfo = ex;
                //stream1 = (System.IO.MemoryStream)myReportDocument.FormatEngine.ExportToStream(x);
                //byte[] content = stream1.ToArray();
                //newly added
                System.IO.Stream oStream = null;
                byte[] byteArray = null;
                oStream = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                byte[] content = byteArray;

                if (System.IO.Directory.Exists(Server.MapPath("~" + FilePath + reprotnamepdf)))
                {
                    try
                    {
                        System.IO.Directory.Delete(Server.MapPath("~" + FilePath + reprotnamepdf), true);
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine(E.Message);
                    }
                }
                // Write out PDF from memory stream. 
                using (FileStream fs = File.Create(Server.MapPath("~" + FilePath + reprotnamepdf)))
                {
                    fs.Write(content, 0, (int)content.Length);
                }


            }
        }


        catch (Exception Ex)
        {
            lblmess.Text = "Try again";
            pnlview.Visible = false;
            errorflag = 1;
            errormess = reprotname+Ex.ToString();
            return;
        }




    }

    protected void LoadReport()
    {
       
          errorflag = 0;
        lblmess.Visible = true;
        if (ddlprevious.SelectedValue == ddlTerm.SelectedValue)
        {
            lblmess.Text = "Previous Term  and Current Term should not be same ";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (ddlTerm.SelectedValue == "0")
        {
            lblmess.Text = "Select Current term";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;

        }
        if (ddlprevious.SelectedValue == "0")
        {
            lblmess.Text = "Select Previous term";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (txtFromDate.Text == "")
        {
            lblmess.Text = "Select Date";
            lblmess.ForeColor = System.Drawing.Color.Red;
            return;
        }
        loadarray();
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

              try
        {

            StudentRegistrationDAL s = new StudentRegistrationDAL();
            DataTable dt1 = s.InsertGenerateInputs(int.Parse(ddlprevious.SelectedValue), int.Parse(ddlTerm.SelectedValue), int.Parse(Session["EmpId"].ToString()));
              
                  DataTable dt = s.GetCOECReportsList(0);
                  int i=0,j=0,k=0,l=0,m=0,n=0,p=0;
            foreach (DataRow row in dt.Rows)
            {               
                if (int.Parse(row["degreetype"].ToString()) == 1)
                {
                    BBAWeekdaypdfs[i] = row["Reportname"].ToString() + row["Extension"].ToString();
                    BBAWeekdaypdfspath[i] = Server.MapPath("~" + row["FilePath"].ToString() + row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                   i = i + 1;
                            
                }
                 if (int.Parse(row["degreetype"].ToString()) == 7)
                {
                    BBAWeekendpdfs[j] = row["Reportname"].ToString() + row["Extension"].ToString();
                    BBAWeekendpdfspath[j] = Server.MapPath("~" + row["FilePath"].ToString() +  row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                  j = j + 1;
                            
                }
                 if (int.Parse(row["degreetype"].ToString()) == 6)
                {
                    MBAWeekdaypdfs[k] = row["Reportname"].ToString() + row["Extension"].ToString();
                    MBAWeekdaypdfspath[k] = Server.MapPath("~" + row["FilePath"].ToString() +  row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                  k = k+ 1;
                            
                }
                 if (int.Parse(row["degreetype"].ToString()) == 8)
                {
                    MBAWeekendpdfs[l] = row["Reportname"].ToString() + row["Extension"].ToString();
                    MBAWeekendpdfspath[l] = Server.MapPath("~" + row["FilePath"].ToString() +  row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                    l = l + 1;
                            
                }
                 if (int.Parse(row["degreetype"].ToString()) == 0)
                 {
                     Overallpdfs[m] = row["Reportname"].ToString() + row["Extension"].ToString();
                     Overallpdfspath[m] = Server.MapPath("~" + row["FilePath"].ToString() + row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                     m = m+ 1;

                 }
                 if (int.Parse(row["degreetype"].ToString()) == -1)
                 {
                     connationpdf[n] = row["Reportname"].ToString() + row["Extension"].ToString();
                     connationpdfpath[n] = Server.MapPath("~" + row["FilePath"].ToString() + row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                     n = n+ 1;

                 }
                 if (int.Parse(row["degreetype"].ToString()) == -2)
                 {
                     constatpdf[p] = row["Reportname"].ToString() + row["Extension"].ToString();
                     constatpdfpath[p] = Server.MapPath("~" + row["FilePath"].ToString() + row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                    p =p + 1;

                 }

                 createreport(row["Reportname"].ToString(), int.Parse(row["degreetype"].ToString()), row["orderno"].ToString(), row["FilePath"].ToString(),bool.Parse(row["IsparamDifferent"].ToString()),0);
                 if (errorflag == 1)
                 {
                     pnlview.Visible = false;
                     lblmess.Text = "Try Again"+ errormess;
                     return;
                 }
          
            }

                       
           
           
            //Process[] myProcess = Process.GetProcessesByName("AcroRd32");
            //for (int g = 0; i < myProcess.Length; i++)
            //{
            //    if (myProcess[g].MainWindowTitle.Contains("BBAWEEKDAY.pdf"))
            //    {
            //        myProcess[g].CloseMainWindow();
            ////        Thread.Sleep(300);
            //    }
            //}
              string date1 =DateTime.Today.ToString("yyyyMMdd");

              string path =Server.MapPath("~\\TempFiles\\")+date1;
              if (!Directory.Exists(path))
              {
                  Directory.CreateDirectory(path);
              }


                MergeFiles(Server.MapPath("~\\TempFiles\\"+date1+"\\"+ddlTerm.SelectedItem.Text + "-BBA-Weekday.pdf"), BBAWeekdaypdfspath, this);
                MergeFiles(Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-BBA-Weekend.pdf"), BBAWeekendpdfspath, this);
                MergeFiles(Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-MBA-Weekday.pdf"), MBAWeekdaypdfspath, this);
                MergeFiles(Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-MBA-Weekend.pdf"), MBAWeekendpdfspath, this);
                MergeFiles(Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Overall.pdf"), Overallpdfspath, this);

                MergeFiles(Server.MapPath("~\\TempFiles\\"  +date1 + "\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Comparatitive-Enrollment-Statistics.pdf"), constatpdfpath, this);
                pnlview.Visible = true;
                lblmess.ForeColor = System.Drawing.Color.Blue;
                lblmess.Font.Size = 9;
                 lblmess.Text = "Reports generated successfully. Dear user before sending the mail kindly verify the reports. Do not send the reports without verification of the data";
                 
         


        }
        catch (Exception Ex)
        {
             Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Close Open PDF');</script>");
             pnlview.Visible = false;
            //Response.Write(Ex.Message);

        }
    }

    /// <summary>
    /// Merge the PDF Files to one single file
    /// </summary>
    /// <param name="destinationFile">Destination File</param>
    /// <param name="sourceFiles">Files need to Merge</param>
    public static void MergeFiles(string outputPdfPath, string[] lstFiles, System.Web.UI.Page pg)
    {
        PdfReader reader = null;
        Document sourceDocument = null;
        PdfCopy pdfCopyProvider = null;
        PdfImportedPage importedPage;
        sourceDocument = new Document();
        pdfCopyProvider = new PdfCopy(sourceDocument,
        new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
        sourceDocument.Open();
        try
        {
            for (int f = 0; f < lstFiles.Length ; f++)
            {
              
          
         reader = new PdfReader(lstFiles[f]);
                int pages = reader.NumberOfPages;
                //Add pages of current file
              

                    for (int i = 1; i <= pages; i++)
                    {
                        try
                        {
                            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                            pdfCopyProvider.AddPage(importedPage);
                        }
                        catch
                        {

                        }
                        
                    }


               
                reader.Close();
            }
            sourceDocument.Close();
        }
        catch (Exception ex)
        {
            //throw ex;
          
           pg.ClientScript.RegisterStartupScript(pg.GetType(), "alert", "<script>alert('Close open PDF or Try Again Later !!!');</script>");
           
            return;

            

        }
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        LoadReport();
        btnviewfile_Click(sender, e);
    }
    protected void btnviewgenerated_Click(object sender, EventArgs e)
    { 
        
                  try
            {
                lblmess.Text = "";
                lblmess.ForeColor = System.Drawing.Color.Blue;
                      if (txtFromDate.Text=="")
                      {
                          lblmess.Text = "Please select date for previously generated Report (option available from 19-01-2017)";
                          lblmess.ForeColor = System.Drawing.Color.Red;
                              return;

                      }
                      if (ddlTerm.SelectedValue == "0")
                      {
                          lblmess.Text = "Select Current Term";
                          lblmess.ForeColor = System.Drawing.Color.Red;
                          return;
                      }
                pnlview.Visible = true;
                     
                StudentRegistrationDAL SDAL = new StudentRegistrationDAL();
                DataTable dt1 = SDAL.GetCOECReportsMailLogs(0, 3);
              //ddlTerm.SelectedValue = dt1.Rows[0][1].ToString();
              //  btnviewfile_Click(sender, e);

                string str = null;
                string[] strArr = null;
                  str = txtFromDate.Text;
             
                strArr = str.Split('/');

                if (strArr[0].Length == 1)
                {
                    strArr[0] = strArr[0].PadLeft(2, '0');
                }
                if (strArr[1].Length == 1)
                {
                    strArr[1] = strArr[1].PadLeft(2, '0');
                }
                string date1 = strArr[2] + strArr[0] + strArr[1];


                string path = Server.MapPath("~\\TempFiles\\") + date1;
                if (!Directory.Exists(path))
                {
                    lblmess.Text = "No file Exists";
                    lblmess.ForeColor = System.Drawing.Color.Red;
                    pnlview.Visible = false;
                    return;
                }  

                hypbbaweek.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-BBA-Weekday.pdf";
                hypbbaweekend.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-BBA-Weekend.pdf";
                hypmbaweek.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-MBA-Weekday.pdf";
                hypmbaweekend.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-MBA-Weekend.pdf";
                hyperall.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Overall.pdf";
                hyperstat.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Comparatitive-Enrollment-Statistics.pdf";
       
            }
            catch
            {
                lblmess.Text = "Try Again";
                pnlview.Visible = false;

            }
       
    }
    protected void btnMailLogs_Click(object sender, EventArgs e)
    {
      StudentRegistrationDAL SDAL = new StudentRegistrationDAL();
      gridmail.DataSource = SDAL.GetCOECReportsMailLogs(0,1);
      gridmail.DataBind();
      pnlpopup.Visible = true;
    }
   
 
    protected void btnviewfile_Click(object sender, EventArgs e)
    {



        string date1 = DateTime.Today.ToString("yyyyMMdd");
       
        txtSubject.Text = "ENROLLMENT STATISTCS & COMPARITIVE ENROLLMENT STATISTCS - "+ ddlTerm.SelectedItem.Text.ToUpper()+" - BBA & MBA - WEEKDAY & WEEKEND BATCH – UPDATES";

        hypbbaweek.NavigateUrl = "~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-BBA-Weekday.pdf";
        hypbbaweekend.NavigateUrl = "~\\TempFiles\\" + date1 + "\\"  +ddlTerm.SelectedItem.Text + "-BBA-Weekend.pdf";
        hypmbaweek.NavigateUrl = "~\\TempFiles\\" +date1+"\\"+ ddlTerm.SelectedItem.Text + "-MBA-Weekday.pdf";
        hypmbaweekend.NavigateUrl = "~\\TempFiles\\" +date1+"\\"+ ddlTerm.SelectedItem.Text + "-MBA-Weekend.pdf";
        hyperall.NavigateUrl = "~\\TempFiles\\"+date1+"\\"+  ddlTerm.SelectedItem.Text + "-Consolidated-Overall.pdf";
              hyperstat.NavigateUrl = "~\\TempFiles\\" +date1+"\\"+ ddlTerm.SelectedItem.Text + "-Consolidated-Comparatitive-Enrollment-Statistics.pdf";
       

    }

    protected void chkcoec_checked(object sender, EventArgs e)
    {
        if (chkcoec.Checked == true)
        {
            txtCC.Enabled = false;
            txtTo.Enabled = false;
            txtCC.Text = "";
            txtTo.Text = "itsun@skylineuniversity.ac.ae";


        }
        else
        {
            txtCC.Enabled = true;
            txtTo.Enabled = true;
        }


    }

    protected void btnsend_Click(object sender, EventArgs e)
    {
        StudentRegistrationDAL SDAL = new StudentRegistrationDAL();
        try
                    {
                        string date1 = DateTime.Today.ToString("yyyyMMdd");
                        string[] attachment = new string[1];

                        if (chkcoec.Checked == true)
                        {
                           
                             attachment = new string[1];
                             attachment[0] = Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Overall.pdf");
                           
                            attlength = 1;
                        }
                        else
                        {
                            attachment = new string[5];

                            attachment[0] = Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-BBA-Weekday.pdf");
                            attachment[1] = Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-BBA-Weekend.pdf");
                            attachment[2] = Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-MBA-Weekday.pdf");
                            attachment[3] = Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-MBA-Weekend.pdf");
                           // attachment[4] = Server.MapPath("~\\TempFiles\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Nationality-Wise.pdf");
                            attachment[4] = Server.MapPath("~\\TempFiles\\" + date1 + "\\" + ddlTerm.SelectedItem.Text + "-Consolidated-Comparatitive-Enrollment-Statistics.pdf");
                            attlength = 5;

                        }

                        string CC = "";
            string to = txtTo.Text.Replace(";", ", ");
            if (txtCC.Text == "")
            {
                CC = "";
            }
            else
            {
                CC = txtCC.Text.Replace(";", ", ");
            }
            string subject = txtSubject.Text;
            string body = editor.Content;
            bool IsSent = SendEmail1.SendEmailwithAttach("admissions@skylineuniversity.ac.ae", to, subject, body, CC, attachment, attlength);
            if (IsSent)
            {
                int count = SDAL.SaveEmailSendingLog(to, "admissions@skylineuniversity.ac.ae", subject, body, Convert.ToInt32(Session["EmpId"].ToString()), "INSERT",txtCC.ToString());
                ClearData();
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent successfully with all the reports.');", true);
            }
            else
            {
                lblMesag.Text = "Please try again later...!";
                lblMesag.ForeColor = System.Drawing.Color.Red;
            }


        }
        catch
        {
            lblmess.Text = "Close PDF or Try Again";
            pnlview.Visible = false;
            

        }
    }
        public void ClearData()
    {
        //txtTo.Text = "";
        //txtCC.Text = "";
        lblMesag.Text = "";
        //txtSubject.Text = "";
        editor.Content = "";
    }

    }