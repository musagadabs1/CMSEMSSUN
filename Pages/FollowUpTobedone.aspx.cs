using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Pages_FollowUpTobedone : System.Web.UI.Page
{
    ReportDocument myReportDocument = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            StudentRegistrationDAL s = new StudentRegistrationDAL();
            if (!IsPostBack)
            {

                if (Session["EMPID"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    ddlemp.DataSource = s.SetDropdownListAsDegreeType(38, int.Parse(Session["EMPID"].ToString()));
                    ddlemp.DataTextField = "Name";
                    ddlemp.DataValueField = "empid";
                    ddlemp.DataBind();
                    try
                    {
                        if (ddlemp.Items.FindByValue(Session["EMPID"].ToString()) != null)

                            ddlemp.SelectedValue = Session["EMPID"].ToString();
                        else
                            ddlemp.SelectedValue = "0";



                    }
                    catch
                    {
                        ddlemp.SelectedValue = "0";
                    }


                    ddlStudentStatus.DataSource = s.LoadCaller();
                    ddlStudentStatus.DataTextField = "CallerStatus";
                    ddlStudentStatus.DataValueField = "Id";
                    ddlStudentStatus.DataBind();


                    pnlReportViwer.Visible = false;




                    //ddlCountry.DataSource = s.SetDropdownListCDB(2);
                    //ddlCountry.DataTextField = "NationalityName";
                    //ddlCountry.DataValueField = "NationalityCode";
                    //ddlCountry.DataBind();
                    if (Session["GroupName"].ToString() != "UAE")
                    {
                        ddlCountry.SelectedValue = Session["GroupName"].ToString();
                        ddlCountry.Enabled = false;
                    }
                }
                if (IsPostBack)
                {
                    //btnSubmit_Click(sender, e);
                }
            }
        }
        catch
        {
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
        string Path = "";
        if (RbtStatistics.Checked == true)
        {
            Path = Server.MapPath("~/Report/Followuptobedone-satistics.rpt");
        }
        else
        {
            Path = Server.MapPath("~/Report/Followuptobedone_Detail.rpt");
        }

        myReportDocument.Load(Path);
        myReportDocument.SetParameterValue("@flag", ChkDate.Checked == true ? 1 : 0);
        myReportDocument.SetParameterValue("@fromdate", ChkDate.Checked == false ? DateTime.Now :Report(txtFromDate.Text));
        myReportDocument.SetParameterValue("@todate", ChkDate.Checked == false ? DateTime.Now : Report(txtToDate.Text));
        myReportDocument.SetParameterValue("@groupcode", ddlCountry.SelectedValue);
        myReportDocument.SetParameterValue("@empid", ddlemp.SelectedValue);
        myReportDocument.SetParameterValue("@callerstatus", ddlStudentStatus.SelectedValue);
        //myReportDocument.SetParameterValue("@SemID", drpSemester.SelectedValue);
        myReportDocument.SetDatabaseLogon("software", "DelFirMENA$idea");
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.HasExportButton = true;
        CrystalReportViewer1.HasPrintButton = true;
        CrystalReportViewer1.HasSearchButton = true;
        CrystalReportViewer1.HasToggleGroupTreeButton = false;

        System.IO.Stream oStream = null;
        byte[] byteArray = null;
        oStream = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        byteArray = new byte[oStream.Length];
        oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(byteArray);
        Response.Flush();
        Response.Close();
        myReportDocument.Close();
        myReportDocument.Dispose();



    }

    public DateTime Report(string Date)
    {
        string[] Cfrom = new string[3];
        DateTime CfromDate = DateTime.Now;
       
        if (Date != "")
        {
            Cfrom = Date.Split('/');
            CfromDate = new DateTime(Convert.ToInt32(Cfrom[2]), Convert.ToInt32(Cfrom[1]), Convert.ToInt32(Cfrom[0]));
        }
        return CfromDate;
    }
    protected void RbtDetails_CheckedChanged(object sender, EventArgs e)
    {
        ChkDate.Checked = false;
    }

}