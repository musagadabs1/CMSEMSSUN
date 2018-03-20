using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;

using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using System.Data.OleDb;
using System.IO;


public partial class Pages_RptViewer : System.Web.UI.Page
{


    SqlConnection objCon = new SqlConnection();
    SqlCommand objCom = new SqlCommand();


    public string OLDServername;
    public string OLDdatabasename;


    public ReportDocument cr1 = new ReportDocument();

    public string newsqlserver;
    public string newsqldatabase;
    public string newsqluserid;
    public string newsqlpassword;

    Entity objEntity = new Entity();


    protected void Page_Init(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        //      {  
        Session["MYRPT"] = null;
        Session["newsqlserver"] = WebConfigurationManager.AppSettings["servernameinfo"];
        Session["newsqldatabase"] = WebConfigurationManager.AppSettings["Databaseinfo"];
        Session["newsqluserid"] = WebConfigurationManager.AppSettings["useridinfo"];
        Session["newsqlpassword"] = WebConfigurationManager.AppSettings["passwordinfo"];
        //}


        string rptPath = string.Empty;

        string rptp;
        string qry1;
        string tblname;
        int ReportSelector;

        ReportSelector = int.Parse(Session["ReportSelector1"].ToString());
        switch (ReportSelector)
        {


            case 1:



                rptPath = Server.MapPath("rptProformaInvoice.rpt");
                rptPath = rptPath.Substring(0, rptPath.LastIndexOf('\\'));
                rptPath = rptPath.Substring(0, rptPath.LastIndexOf('\\'));
                rptPath = rptPath + "\\Report\\" + "rptProformaInvoice.rpt";



                rptp = rptPath;

                //rptp = Server.MapPath("RptFiles\\rptProformaInvoice.rpt");
                qry1 = "Generate_Ivoice_From_Proforma_Invoice";
                tblname = "";
                proformainvoice(qry1, rptp, tblname);
                break;

            case 2:


              rptPath = Server.MapPath("rptProformaInvoice.rpt");
              rptPath = rptPath.Substring(0, rptPath.LastIndexOf('\\'));
              rptPath = rptPath.Substring(0, rptPath.LastIndexOf('\\'));
              rptPath = rptPath + "\\RptFiles\\" + "FeeGroupDetails.rpt";



              rptp = rptPath;


          //    rptp = Server.MapPath("FeeGroupDetails.rpt");
              qry1 = "SELECT *  FROM  VIEW_FEES_GROUP_DETAILS  where  acyear_id =   '" + int.Parse(Session["FeeGroupAcademicYearID"].ToString())  + "'   ";
              tblname = "VIEW_FEES_GROUP_DETAILS";
                rptshow(qry1, rptp, tblname);
                break;
           
       

            default:
                break;

        }
    }
    private void SetDBLogonForReport(ConnectionInfo myConnectionInfo, ReportDocument myReportDocument)
    {
        Tables myTables = myReportDocument.Database.Tables;
        foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables)
        {
            TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
            myTableLogonInfo.ConnectionInfo = myConnectionInfo;
            myTable.ApplyLogOnInfo(myTableLogonInfo);
        }
    }
    private void SetDBLogonForSubreports(ConnectionInfo myConnectionInfo, ReportDocument myReportDocument)
    {
        Sections mySections = myReportDocument.ReportDefinition.Sections;
        foreach (Section mySection in mySections)
        {
            ReportObjects myReportObjects = mySection.ReportObjects;
            foreach (ReportObject myReportObject in myReportObjects)
            {
                if (myReportObject.Kind == ReportObjectKind.SubreportObject)
                {
                    SubreportObject mySubreportObject = (SubreportObject)myReportObject;
                    ReportDocument subReportDocument = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName);
                    SetDBLogonForReport(myConnectionInfo, subReportDocument);
                }
            }
        }
    }

    private void rptshow(string qry, string strReportName, string tblname)
    {
        try
        {

            if (Session["MYRPT"] == null)
            {
                newsqlserver = Session["newsqlserver"].ToString();
                newsqldatabase = Session["newsqldatabase"].ToString();
                newsqluserid = Session["newsqluserid"].ToString();
                newsqlpassword = Session["newsqlpassword"].ToString();

                SqlCommand cmd = new SqlCommand(qry);
                cmd.CommandType = CommandType.Text;
                DataSet dsReport = new DataSet();
                dsReport = objEntity.RetrieveDataSet(cmd);





                if (!System.IO.File.Exists(strReportName))
                {
                    throw (new Exception("Unable to locate report file:" + strReportName));
                }


                ConnectionInfo myConnectionInfo = new ConnectionInfo();
                myConnectionInfo.ServerName = newsqlserver;
                myConnectionInfo.DatabaseName = newsqldatabase;
                myConnectionInfo.UserID = newsqluserid;
                myConnectionInfo.Password = newsqlpassword;
                //ConnectionInfo connection1;
                //ConnectionInfo connection2;
                //ConnectionInfo connection3;
                //ConnectionInfo connection4;
                //ConnectionInfo connection5;

                cr1.Load(strReportName);


                /////////////////////////////////////////////

                foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo connection1 in cr1.DataSourceConnections)
                {
                    OLDServername = connection1.ServerName;
                    OLDdatabasename = connection1.DatabaseName;
                }

                string oldServerName = OLDServername;
                string newServerName = newsqlserver;
                string oldDatabaseName = OLDdatabasename;
                string newDatabaseName = newsqldatabase;
                string userID1 = newsqluserid;
                string password1 = newsqlpassword;


                // Change the server name and database in main reports 

                foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo connection2 in cr1.DataSourceConnections)
                {
                    if ((string.Compare(connection2.ServerName, oldServerName, true) == 0 & string.Compare(connection2.DatabaseName, oldDatabaseName, true) == 0))
                    {
                        // SetConnection can also be used to set new logon and new database table 
                        cr1.DataSourceConnections[oldServerName, oldDatabaseName].SetConnection(newServerName, newDatabaseName, userID1, password1);
                    }
                }



                // Change the server name and database in subreports 

                foreach (ReportDocument subreport1 in cr1.Subreports)
                {

                    foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo connection3 in subreport1.DataSourceConnections)
                    {
                        if ((string.Compare(connection3.ServerName, oldServerName, true) == 0 & string.Compare(connection3.DatabaseName, oldDatabaseName, true) == 0))
                        {
                            // SetConnection can also be used to set new logon and new database table 
                            subreport1.DataSourceConnections[oldServerName, oldDatabaseName].SetConnection(newServerName, newDatabaseName, userID1, password1);
                        }
                    }
                }

                System.Threading.Thread.Sleep(500);
                cr1.SetDataSource(dsReport.Tables[tblname]);

                CrystalReportViewer1.HasCrystalLogo = false;
                //crpt1.ShowCloseButton = False 
                CrystalReportViewer1.DisplayGroupTree = false;



                SetDBLogonForReport(myConnectionInfo, cr1);
                //SetDBLogonForSubreports(myConnectionInfo, cr1);
                Session["MYRPT"] = cr1;


                ///////////////////////////////////////////
            }

            cr1 = (ReportDocument)Session["MYRPT"];
            
            CrystalReportViewer1.ReportSource = cr1;

            CrystalReportViewer1.DataBind();



        }
        catch
        {
        }
    }
   
    
  


    private void proformainvoice(string qry, string strReportName, string tblname)
    {
        try
        {

            if (Session["MYRPT"] == null)
            {
                newsqlserver = Session["newsqlserver"].ToString();
                newsqldatabase = Session["newsqldatabase"].ToString();
                newsqluserid = Session["newsqluserid"].ToString();
                newsqlpassword = Session["newsqlpassword"].ToString();




                if (!System.IO.File.Exists(strReportName))
                {
                    throw (new Exception("Unable to locate report file:" + strReportName));
                }


                ConnectionInfo myConnectionInfo = new ConnectionInfo();
                myConnectionInfo.ServerName = newsqlserver;
                myConnectionInfo.DatabaseName = newsqldatabase;
                myConnectionInfo.UserID = newsqluserid;
                myConnectionInfo.Password = newsqlpassword;

                cr1.Load(strReportName);


                /////////////////////////////////////////////

                foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo connection1 in cr1.DataSourceConnections)
                {
                    OLDServername = connection1.ServerName;
                    OLDdatabasename = connection1.DatabaseName;
                }

                string oldServerName = OLDServername;
                string newServerName = newsqlserver;
                string oldDatabaseName = OLDdatabasename;
                string newDatabaseName = newsqldatabase;
                string userID1 = newsqluserid;
                string password1 = newsqlpassword;


                // Change the server name and database in main reports 

                foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo connection2 in cr1.DataSourceConnections)
                {
                    if ((string.Compare(connection2.ServerName, oldServerName, true) == 0 & string.Compare(connection2.DatabaseName, oldDatabaseName, true) == 0))
                    {
                        // SetConnection can also be used to set new logon and new database table 
                        cr1.DataSourceConnections[oldServerName, oldDatabaseName].SetConnection(newServerName, newDatabaseName, userID1, password1);
                    }
                }



                // Change the server name and database in subreports 

                foreach (ReportDocument subreport1 in cr1.Subreports)
                {

                    foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo connection3 in subreport1.DataSourceConnections)
                    {
                        if ((string.Compare(connection3.ServerName, oldServerName, true) == 0 & string.Compare(connection3.DatabaseName, oldDatabaseName, true) == 0))
                        {
                            // SetConnection can also be used to set new logon and new database table 
                            subreport1.DataSourceConnections[oldServerName, oldDatabaseName].SetConnection(newServerName, newDatabaseName, userID1, password1);
                        }
                    }
                }


 



                System.Threading.Thread.Sleep(500);
                cr1.SetParameterValue(0, 1);
                cr1.SetParameterValue(1, Session["proformaStudentID"].ToString());

                //cr1.SetDataSource(dsReport.Tables[tblname]);

                CrystalReportViewer1.HasCrystalLogo = false;
                CrystalReportViewer1.DisplayGroupTree = false;



                SetDBLogonForReport(myConnectionInfo, cr1);
                //SetDBLogonForSubreports(myConnectionInfo, cr1);
                Session["MYRPT"] = cr1;


                ///////////////////////////////////////////
            }

            cr1 = (ReportDocument)Session["MYRPT"];
            //rptdispcompany();
            CrystalReportViewer1.ReportSource = cr1;

            CrystalReportViewer1.DataBind();



        }
        catch
        {
        }
    }

  


}
