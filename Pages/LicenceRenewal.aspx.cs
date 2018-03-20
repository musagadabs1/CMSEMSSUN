using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Pages_LicenceRenewal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearData(); 
        }
    }
    public void ClearData()
    {
        LoadDropdown();
        BindGrid();
        BtnSave.Text = "SAVE";
        txtDescription.Text = "";
        txtRemarks.Text = "";
        txtValidFrom.Text = "";
        txtValidTo.Text = "";
    }
    public void LoadDropdown()
    {
        StudentRegistrationDAL s = new StudentRegistrationDAL();
        DrpCourseType.DataSource = s.SetDropdownListCDB(120);
        DrpCourseType.DataTextField = "CourseType";
        DrpCourseType.DataValueField = "CourseType";
        DrpCourseType.DataBind();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtValidFrom.Text == "")
        {
            LblDisplayMessage.Text = "Please select ValidFrom Date";
            return;
        }
        if (txtValidTo.Text == "")
        {
            LblDisplayMessage.Text = "Please select ValidTo Date";
            return;
        }


        byte[] FileName = ReadFileDocument();

        string FileName1 = "";
        string Extension = "";
        int i = 0;
        try
        {

            string s = DOC_AsyncDocUPload.PostedFile.FileName;
            string[] words = s.Split('.');
            foreach (string word in words)
            {
                if (i == 0)
                    FileName1 = word;
                else
                    Extension = "." + word;
                i++;
            }
        }
        catch
        {


        }

         string[] stringdate1 = new string[3];
         stringdate1 = txtValidFrom.Text.Split('/');
         DateTime Startdate1 = new DateTime(Convert.ToInt32(stringdate1[2]), Convert.ToInt32(stringdate1[1]), Convert.ToInt32(stringdate1[0]));

         string[] stringdate2 = new string[3];
         stringdate2 = txtValidTo.Text.Split('/');
          DateTime Enddate1 = new DateTime(Convert.ToInt32(stringdate2[2]), Convert.ToInt32(stringdate2[1]), Convert.ToInt32(stringdate2[0]));
          StudentRegistrationDAL S = new StudentRegistrationDAL();
          DataTable Dtb = new DataTable();
          if (TxtID.Text.Length == 0)
          {
             
             
               Dtb = S.InsertLicenseRenewal(DrpCourseType.SelectedValue, Startdate1, Enddate1, txtDescription.Text.Trim(), txtRemarks.Text.Trim(),
                  int.Parse(Session["EmpId"].ToString()), "INSERT", 0, FileName, FileName1, Extension);

               if (Dtb.Rows.Count > 0 && Dtb != null)
               {
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data saved succesfully!!');", true);
               }
          }
          else
          {
               Dtb = S.InsertLicenseRenewal(DrpCourseType.SelectedValue, Startdate1, Enddate1, txtDescription.Text.Trim(), txtRemarks.Text.Trim(),
                int.Parse(Session["EmpId"].ToString()), "UPDATE", Convert.ToInt32(TxtID.Text), FileName, FileName1, Extension);
               if (Dtb.Rows.Count > 0 && Dtb != null)
               {
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Updated succesfully!!');", true);
               }
          }
          ClearData(); 
    }
    public void BindGrid()
    {
        StudentRegistrationDAL S = new StudentRegistrationDAL();
        DataTable Dtb = S.InsertLicenseRenewal(DrpCourseType.SelectedValue, DateTime.Now, DateTime.Now, txtDescription.Text.Trim(), txtRemarks.Text.Trim(),
                0, "SELECT", 0);
        GrvGrid.DataSource = Dtb;
        GrvGrid.DataBind();
    }
    protected void GrvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void GrvGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        StudentRegistrationDAL S = new StudentRegistrationDAL();
        if (e.CommandName == "EditRow")
        {
            DataTable Dtb = S.InsertLicenseRenewal(DrpCourseType.SelectedValue, DateTime.Now, DateTime.Now, txtDescription.Text.Trim(), txtRemarks.Text.Trim(),
                0, "BYID", Convert.ToInt32(e.CommandArgument));
            if (Dtb.Rows.Count > 0)
            {
                DrpCourseType.SelectedValue = Dtb.Rows[0]["CourseType"].ToString();
                txtValidFrom.Text = Convert.ToDateTime(Dtb.Rows[0]["ValidFrom"]).ToString("dd/MM/yyyy");
                txtValidTo.Text = Convert.ToDateTime(Dtb.Rows[0]["ValidTo"]).ToString("dd/MM/yyyy");
                txtDescription.Text = Dtb.Rows[0]["Description"].ToString();
                txtRemarks.Text = Dtb.Rows[0]["Remarks"].ToString();
                TxtID.Text = Dtb.Rows[0]["LicenseID"].ToString();
                BtnSave.Text = "UPDATE";
            }
        }

        if (e.CommandName.Equals("Download"))
        {
            try
            {

                String FileName = "", Extension = "";
                byte[] excelContents;
                DataTable Dtb = S.InsertLicenseRenewal(DrpCourseType.SelectedValue, DateTime.Now, DateTime.Now, txtDescription.Text.Trim(), txtRemarks.Text.Trim(),
               0, "BYID", Convert.ToInt32(e.CommandArgument));


                if (Dtb.Rows.Count != 0)
                {
                    FileName = Dtb.Rows[0]["FileName"].ToString();
                    Extension = Dtb.Rows[0]["FileExtension"].ToString();
                    excelContents = (byte[])Dtb.Rows[0]["FileDetails"];
                    byte[] fileData = excelContents;
                    Response.ClearContent();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + '.' + Extension);
                    BinaryWriter bw = new BinaryWriter(Response.OutputStream);
                    bw.Write(fileData);
                    bw.Close();
                    Response.ContentType = ReturnExtension(Extension);
                    Response.End();
                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Couln't find the Documents!!');", true);
              //  Response.End();
            }
        }
    }
    private string ReturnExtension(string fileExtension)
    {
        fileExtension = fileExtension.ToLower();
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".docx":
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xlsx":
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
    byte[] ReadFileDocument()
    {
        byte[] fileData = null;
        try
        {
            DOC_AsyncDocUPload.SaveAs(Server.MapPath("../UploadDocs/" + DOC_AsyncDocUPload.PostedFile.FileName));
            DirectoryInfo dirinfo = new DirectoryInfo(Server.MapPath(DOC_AsyncDocUPload.PostedFile.FileName));
            FileStream st = new FileStream(Server.MapPath("../UploadDocs/" + DOC_AsyncDocUPload.PostedFile.FileName), FileMode.Open);
            fileData = new byte[st.Length];
            st.Read(fileData, 0, (int)st.Length);
            st.Close();
            return fileData;
        }
        catch
        {
            return fileData;
        }
    }
}