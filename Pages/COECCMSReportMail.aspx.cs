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


public partial class Pages_COECCMSReportMail : System.Web.UI.Page
{
  
  
    string[] connationpdfcms = new string[1];
    string[] connationpdfpathcms = new string[1];


    string[] connationpdfcmsrange = new string[1];
    string[] connationpdfpathcmsrange = new string[1];
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

        if ((Session["EMPID"].ToString() == "1636") || (Session["EMPID"].ToString() == "918"))
        {


            if (!Page.IsPostBack)
            {
                try
                {
                    StudentRegistrationDAL s = new StudentRegistrationDAL();

                    pnlview.Visible = false;
                    pnlpopup.Visible = false;

                  
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
            if (int.Parse(row["degreetype"].ToString()) == -3)
            {
                connationpdfcms = new string[int.Parse(row["count1"].ToString())];
                connationpdfpathcms = new string[int.Parse(row["count1"].ToString())];

            }
            if (int.Parse(row["degreetype"].ToString()) == -4)
            {
                connationpdfcmsrange = new string[int.Parse(row["count1"].ToString())];
                connationpdfpathcmsrange = new string[int.Parse(row["count1"].ToString())];

            }
            

        }



}


    protected void createreport(string reprotname, int degreetype,string order,string FilePath,bool issameparam,int single)
    {
        try
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
                    degreetype = 0;
                    myReportDocument.SetParameterValue("@TermId", 0);
                    myReportDocument.SetParameterValue("@DegreeType", degreetype);

                    if (reprotname == "ConsolidateddailyCMSreport")
                    {
                        myReportDocument.SetParameterValue("@Fromdate", Txtcmsdate.Text);
                        myReportDocument.SetParameterValue("@Todate", Txtcmsdate.Text);

                    }
                    if (reprotname == "ConsolidateddaterangeCMSreport")
                    {
                        myReportDocument.SetParameterValue("@Fromdate", txtFromDate.Text);
                        myReportDocument.SetParameterValue("@Todate", txtToDate.Text);

                    }



                    myReportDocument.SetParameterValue("@AYYear", null);
                }








                myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");


                //stream1 = null;
                //ExportOptions ex = myReportDocument.ExportOptions;
                //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                //ExportRequestContext x = new ExportRequestContext();
                //x.ExportInfo = ex;
                //stream1 = (System.IO.MemoryStream)myReportDocument.FormatEngine.ExportToStream(x);





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


        catch (Exception Ex)
        {
            lblmess.Text = "Try again";
            pnlview.Visible = false;
            errorflag = 1;
            errormess = Ex.ToString();
            return;
        }




    }

    protected void LoadReport()
    {
       
          errorflag = 0;
        lblmess.Visible = true;
       
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
            DataTable dt1 = s.InsertGenerateInputs(0, 0, int.Parse(Session["EmpId"].ToString()));
              
                  DataTable dt = s.GetCOECReportsList(1);
                  int i=0,j=0,k=0,l=0,m=0,n=0,p=0;
            foreach (DataRow row in dt.Rows)
            {               
               
                 if (int.Parse(row["degreetype"].ToString()) == -3)
                 {
                     connationpdfcms[p] = row["Reportname"].ToString() + row["Extension"].ToString();
                     connationpdfpathcms[p] = Server.MapPath("~" + row["FilePath"].ToString() + row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                    p =p + 1;

                 }
                 if (int.Parse(row["degreetype"].ToString()) == -4)
                 {
                     connationpdfcmsrange[i] = row["Reportname"].ToString() + row["Extension"].ToString();
                     connationpdfpathcmsrange[i] = Server.MapPath("~" + row["FilePath"].ToString() + row["orderno"].ToString() + row["Reportname"].ToString() + row["Extension"].ToString());
                    i =i + 1;

                 }
                 createreport(row["Reportname"].ToString(), int.Parse(row["degreetype"].ToString()), row["orderno"].ToString(), row["FilePath"].ToString(),bool.Parse(row["IsparamDifferent"].ToString()),0);
                 if (errorflag == 1)
                 {
                     pnlview.Visible = false;
                     lblmess.Text = "Try Again"+ errormess;
                     return;
                 }
          
            }



            MergeFiles(Server.MapPath("~\\TempFiles\\" + getdateformat(txtFromDate.Text) + "-" + getdateformat(txtToDate.Text) + "-Consolidated-DaterangeCMS.pdf"), connationpdfpathcmsrange, this);
            MergeFiles(Server.MapPath("~\\TempFiles\\" + getdateformat(Txtcmsdate.Text) + "-Consolidated-CMS.pdf"), connationpdfpathcms, this);
            

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
       
    }
    protected void btnMailLogs_Click(object sender, EventArgs e)
    {
      StudentRegistrationDAL SDAL = new StudentRegistrationDAL();
      gridmail.DataSource = SDAL.GetCOECReportsMailLogs(0,1);
      gridmail.DataBind();
      pnlpopup.Visible = true;
    }
    protected string getdateformat(string datetinput)
    {

        string[] dateinput = datetinput.Split('/');
        int year, month, day;

        int.TryParse(dateinput[0], out day);
        int.TryParse(dateinput[1], out month);
        int.TryParse(dateinput[2], out year);

        string d1 = dateinput[1];
        string m1 = dateinput[0];
        string y1 = dateinput[2];
            string datef = d1 + "-" + m1 + "-" + y1;

            return datef;
    }
 
    protected void btnviewfile_Click(object sender, EventArgs e)
    {





        txtSubject.Text = "CMS REPORTS";
        Hyperconsolidaterange.NavigateUrl = "~\\TempFiles\\" + getdateformat(txtFromDate.Text) + "-" + getdateformat(txtToDate.Text) + "-Consolidated-DaterangeCMS.pdf";

        Hyperconsolidate.NavigateUrl = "~\\TempFiles\\" + getdateformat(Txtcmsdate.Text) + "-Consolidated-CMS.pdf";

     

    }

    protected void chkcoec_checked(object sender, EventArgs e)
    {
        if (chkcoec.Checked == true)
        {
            txtCC.Enabled = false;
            txtTo.Enabled = false;
            txtCC.Text = "";
            txtTo.Text = "nitin@skylineuniversity.ac.ae";


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
                        string[] attachment = new string[1];

                       
                             attachment = new string[2];
                             attachment[0] = Server.MapPath("~\\TempFiles\\" + getdateformat(txtFromDate.Text)+"-"+getdateformat(txtToDate.Text) + "-Consolidated-DaterangeCMS.pdf");
                             attachment[1] = Server.MapPath("~\\TempFiles\\" + getdateformat(Txtcmsdate.Text) + "-Consolidated-CMS.pdf");
                            attlength = 2;
                       
                       

                       
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