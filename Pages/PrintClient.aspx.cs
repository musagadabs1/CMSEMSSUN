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
using System.IO;
using CrystalDecisions.Shared;
using System.Net;

public partial class Pages_PrintClient : System.Web.UI.Page
{
    ReportDocument rptStudent = new ReportDocument();
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rptStudent.Close();
        rptStudent.Dispose();
        GC.Collect();
    }
    protected void DownloadFile(string filePath)
    {

        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filePath);
        //Response.WriteFile(Server.MapPath("~\\Pages\\PrintableDocument\\"+filePath));
        //Response.End();

        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;

        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        response.AddHeader("Content-Disposition", "attachment;filename="+filePath);
        byte[] data = req.DownloadData(Server.MapPath("~\\Pages\\PrintableDocument\\" + filePath));
        response.BinaryWrite(data);
        response.End();      


        //Response.TransmitFile(filePath);


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            string path = "";
         
            //string UName = Session["UName"].ToString();
            string LinkId = "";
            try
            {
                LinkId = Session["LinkId"].ToString();
            }
            catch
            {
                LinkId = s.GetLinkId(Session["Id"].ToString());
            }
            string UName = Request.QueryString["UName"].ToString();

           

            if (UName.Contains(".pdf"))
            {
                 if (UName.Contains("NBAD"))
                      DownloadFile(UName);
                       
                 else
                Response.Redirect("PrintableDocument/" + UName, false);
            }
            else
            {
                if  (UName == "FS")
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(28, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        path = "~/Report/fee.rpt";
                        path = Server.MapPath(path);
                        rptStudent.Load(path);
                        rptStudent.SetParameterValue("@term", ro["TermName"].ToString());
                        rptStudent.SetParameterValue("@degreeid", ro["DegreeId"].ToString());
                        rptStudent.SetParameterValue("@type", ro["Type"].ToString());
                        rptStudent.SetParameterValue("@typeid", ro["Fees_Category_Id"].ToString());
                    }
                }
                else  if (UName == "FW")
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(28, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        path = "~/Report/feescholership.rpt";
                        path = Server.MapPath(path);
                        rptStudent.Load(path);
                        rptStudent.SetParameterValue("@term", ro["TermName"].ToString());
                        rptStudent.SetParameterValue("@degreeid", ro["DegreeId"].ToString());
                        rptStudent.SetParameterValue("@type", ro["Type"].ToString());
                        rptStudent.SetParameterValue("@typeid", ro["Fees_Category_Id"].ToString());
                                          }
                }
// PLEASE CHECK IT
                else if (UName == "FO")
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(29, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        path = "~/Report/feesAIPC.rpt";
                        path = Server.MapPath(path);
                        rptStudent.Load(path);
                        rptStudent.SetParameterValue("@term", ro["TermName"].ToString());
                        rptStudent.SetParameterValue("@degreeid", ro["DegreeId"].ToString());
                        rptStudent.SetParameterValue("@type", ro["Fees_Category_Id"].ToString());
                    }
                }             

                else if (UName == "MQP")
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(30, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        path = "~/Report/feeMQP.rpt";
                        path = Server.MapPath(path);
                        rptStudent.Load(path);
                        rptStudent.SetParameterValue("@term", ro["TermName"].ToString());
                        rptStudent.SetParameterValue("@degreeid", ro["DegreeId"].ToString());
                        rptStudent.SetParameterValue("@type", UName);
                        rptStudent.SetParameterValue("@typeid", ro["Fees_Category_Id"].ToString());
                    }
                }
                else if (UName == "MC")
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(39, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        path = "~/Report/feeMISC.rpt";
                        path = Server.MapPath(path);
                        rptStudent.Load(path);

                        rptStudent.SetParameterValue("@term", ro["TermName"].ToString());
                        rptStudent.SetParameterValue("@degreeid", ro["DegreeId"].ToString());
                        rptStudent.SetParameterValue("@typeid", ro["Fees_Category_Id"].ToString());
                    }
                }

                else
                {
                string RegNo = s.GetRegNo(LinkId);
                path = "~/Report/" + UName + ".rpt";
                path = Server.MapPath(path);
                rptStudent.Load(path);
                if ((UName == "ENROLLMENTFORM") || (UName.Contains("hostel_application")) || (UName == "local_guardian_visa_application") || (UName == "Student_Visa_Processing_request_Form") || (UName == "Student_personal_details_visa_applcation"))
                    rptStudent.SetParameterValue("@LinkId", LinkId);
                else if ((UName == "CpdEventsReportMain"))
                {  
                      DataTable dtt = s.SetDropdownListAsDegreeType(40, int.Parse(LinkId));
                        foreach (DataRow ro in dtt.Rows)
                        {
                            rptStudent.SetParameterValue("@AcadYear", ro["termyear"].ToString());
                            rptStudent.SetParameterValue("@Shed_Course",  ro["Degree_Id"].ToString());                         
                        }
                 }
                else if ((UName == "RPT_INSTRUCTION"))
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(40, int.Parse(LinkId));
                  
                        foreach (DataRow ro in dtt.Rows)
                        {
                            rptStudent.SetParameterValue("@AYID", ro["ayid"].ToString());


                            string degreetype;
                            if (int.Parse(ro["degreetype_id"].ToString()) == 8)
                                degreetype = "6";

                            else if (int.Parse(ro["degreetype_id"].ToString()) == 7)
                                degreetype = "1";
                            else
                                degreetype = ro["degreetype_id"].ToString();

                            rptStudent.SetParameterValue("@DegId", degreetype);
                        }
                }
                else if ((UName == "RefundPolicy"))
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(40, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        rptStudent.SetParameterValue("@AYID", ro["ayid"].ToString());

                        string degreetype;
                        if (int.Parse(ro["degreetype_id"].ToString()) == 8)
                            degreetype = "6";

                        else if (int.Parse(ro["degreetype_id"].ToString()) == 7)
                            degreetype = "1";
                        else
                            degreetype = ro["degreetype_id"].ToString();

                        rptStudent.SetParameterValue("@ProgramID", degreetype);
                        rptStudent.SetParameterValue("@TypeID", ro["typeid"].ToString());
                    }
                }
                else if ((UName == "MktCheckListReport"))
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(40, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        rptStudent.SetParameterValue("@AcYearID", ro["ayid"].ToString());
                       
                    }
                }
                else if ((UName == "RefundPolicy - MQP"))
                {
                    DataTable dtt = s.SetDropdownListAsDegreeType(40, int.Parse(LinkId));
                    foreach (DataRow ro in dtt.Rows)
                    {
                        rptStudent.SetParameterValue("@AYID", ro["ayid"].ToString());

                        string degreetype;
                        degreetype = "8";
                        rptStudent.SetParameterValue("@ProgramID", degreetype);
                        rptStudent.SetParameterValue("@TypeID", ro["typeid"].ToString());
                    }
                }
                else
                    rptStudent.SetParameterValue("@registerid", LinkId);
                }
                rptStudent.SetDatabaseLogon("software", "DelFirMENA$idea");
                CrystalReportViewer1.Visible = false;
                CrystalReportViewer1.ReportSource = rptStudent;
                CrystalReportViewer1.DataBind();
                CrystalReportViewer1.HasCrystalLogo = false;
                CrystalReportViewer1.HasDrilldownTabs = false;
                CrystalReportViewer1.HasDrillUpButton = false;
                CrystalReportViewer1.HasGotoPageButton = true;
                CrystalReportViewer1.HasPageNavigationButtons = true;
               
                CrystalReportViewer1.HasRefreshButton = false;
                CrystalReportViewer1.HasSearchButton = false;
                CrystalReportViewer1.HasToggleGroupTreeButton = false;
                CrystalReportViewer1.HasToggleParameterPanelButton = false;
             
                CrystalReportViewer1.BackColor = System.Drawing.Color.White;
                              
                //stream1 = null;
                //ExportOptions ex = rptStudent.ExportOptions;
                //ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                //ExportRequestContext x = new ExportRequestContext();
                //x.ExportInfo = ex;
                //stream1 = (System.IO.MemoryStream)rptStudent.FormatEngine.ExportToStream(x);
                //Response.Clear();
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(stream1.ToArray());
                //Response.End();
                //stream1.Close();




                System.IO.Stream oStream = null;
                byte[] byteArray = null;
                oStream = rptStudent.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rptStudent.Close();
                rptStudent.Dispose();



             
               }
        }
        catch (Exception ex)
        {
             Response.Write (ex.ToString());

        }
    }
   
}


            

    // public void SendReports(string ReportName,  string PdfFile)
    //    {
    //        ReportDocument cryRpt;
    //        cryRpt = new ReportDocument();
    //        string Path = Server.MapPath(Convert.ToString(ReportName));
    //        Path = Path.Substring(0, Path.LastIndexOf('\\'));
    //        Path = Path.Substring(0, Path.LastIndexOf('\\'));
    //        Path = Path + "\\ReportFiles\\" + Convert.ToString(ReportName);
    //        cryRpt.Load(Path);
    //        cryRpt.SetDataSource(source);
    //        string pdfFile = "c:\\" + PdfFile;
    //        try
    //        {
    //            ExportOptions CrExportOptions;
    //            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
    //            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
    //            CrDiskFileDestinationOptions.DiskFileName = pdfFile;
    //            CrExportOptions = cryRpt.ExportOptions;
    //            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
    //            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
    //            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
    //            CrExportOptions.FormatOptions = CrFormatTypeOptions;
    //            cryRpt.Export();
               
    //                        }
    //        catch (Exception ex)
    //        {

    //        }


    //    }
    //}


   