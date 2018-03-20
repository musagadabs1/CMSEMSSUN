using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_OrientationAttendance : System.Web.UI.Page
{
    StudentRegistrationDAL objS = new StudentRegistrationDAL();
    Attendance objA = new Attendance();
    string Intake;
    DataTable dt = new DataTable();
    DataTable dtIsExist = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadForm();
        }
    }

    public void LoadForm()
    {
        ddlDegree.AutoPostBack = true;
        chkNew.AutoPostBack = true;
        chkPrevious.AutoPostBack = true;
        btnLoadStudentsDetails.Enabled = true;

        ddlTerm.Enabled = true;
        ddlDegree.Enabled = true;
        chkNew.Enabled = true;
        chkPrevious.Enabled = true;
        chkNew.Checked = false;
        chkPrevious.Checked = false;

        BindTerm();
        BindDegree();
        ClearGrid();
        BindOrientationAttendanceList();
    }

    public void BindTerm()
    {
        ddlTerm.DataSource = null;
        ddlTerm.DataBind();
        ddlTerm.Items.Clear();
        ddlTerm.Items.Insert(0, new ListItem("SELECT", "0"));
        ddlTerm.DataSource = objS.SetDropdownListCDB(59);
        ddlTerm.DataTextField = "Term";
        ddlTerm.DataValueField = "TermID";
        ddlTerm.DataBind();
    }

    public void BindDegree()
    {
        ddlDegree.DataSource = null;
        ddlDegree.DataBind();
        ddlDegree.DataSource = objS.SetDropdownListCDB(124);
        ddlDegree.DataTextField = "Description";
        ddlDegree.DataValueField = "Id";
        ddlDegree.DataBind();
    }

    public void ClearGrid()
    {
        gvStudentDetails.DataSource = null;
        gvStudentDetails.DataBind();
        BtnSave.Visible = false;
        BtnCancel.Visible = false;
        hdnOperation.Value = "INSERT";
    }

    public void BindOrientationAttendanceList()
    {
        dt = null;
        dt = OrientationAttendence(0,"", 0, 0, 0, "", 0, "SELECT", null);
        gvOrientationAttendanceList.DataSource = dt;
        gvOrientationAttendanceList.DataBind();
    }

    public void BindCommencementCalender(string Intake = "", int TermId = 0, int DegreeType = 0)
    {
        ddlCommencementCalender.DataSource = objA.GetCommencementCalender(Intake, TermId, DegreeType);
        ddlCommencementCalender.DataTextField = "ClassStartDate";
        ddlCommencementCalender.DataValueField = "Id";
        ddlCommencementCalender.DataBind();
    }

    public DataTable OrientationAttendence(int Id = 0, string Intaketype = "", int TermId = 0, int Degreetype = 0, int ShiftId = 0, string AttendenceDate = ""
                                        , int CreatedBy = 0, string Operation = "", DataTable Details = null)
    {
        DataTable objdt = new DataTable();
        objdt = objA.OrientationAttendence(Id, Intake, TermId, Degreetype,ShiftId, AttendenceDate, CreatedBy, Operation, Details);
        return objdt;
    }

    protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkNew.Checked && chkPrevious.Checked || !chkNew.Checked && !chkPrevious.Checked)
            Intake = "N,O";
        else if (chkNew.Checked)
            Intake = "N";
        else if (chkPrevious.Checked)
            Intake = "O";

        BindCommencementCalender(Intake, Convert.ToInt32(ddlTerm.SelectedValue), Convert.ToInt32(ddlDegree.SelectedValue));
        ClearGrid();
    }

    protected void chkPrevious_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNew.Checked && chkPrevious.Checked || !chkNew.Checked && !chkPrevious.Checked)
            Intake = "N,O";
        else if (chkPrevious.Checked)
            Intake = "O";
        else if (chkNew.Checked)
            Intake = "N";

        BindCommencementCalender(Intake, Convert.ToInt32(ddlTerm.SelectedValue), Convert.ToInt32(ddlDegree.SelectedValue));
        ClearGrid();
    }

    protected void chkNew_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNew.Checked && chkPrevious.Checked || !chkNew.Checked && !chkPrevious.Checked)
            Intake = "N,O";
        else if (chkNew.Checked)
            Intake = "N";
        else if (chkPrevious.Checked)
            Intake = "O";

        ClearGrid();
    }

    protected void btnLoadStudentsDetails_Click(object sender, EventArgs e)
    {
        if (chkNew.Checked && chkPrevious.Checked || !chkNew.Checked && !chkPrevious.Checked)
            Intake = "N,O";
        else if (chkNew.Checked)
            Intake = "N";
        else if (chkPrevious.Checked)
            Intake = "O";

        DataTable dt = new DataTable();
        dt = null;

        string AttendenceDate = "";
        if (chkIsNeedtoPopulate.Checked)
            AttendenceDate = txtAttendenceDate.Text.ToString();

        hdnOperation.Value = "LOAD";

        dt = OrientationAttendence(0,Intake, Convert.ToInt32(ddlTerm.SelectedValue), Convert.ToInt32(ddlDegree.SelectedValue),0, AttendenceDate, int.Parse(Session["EmpId"].ToString()), hdnOperation.Value.ToString(), dt);
        gvStudentDetails.DataSource = dt;
        gvStudentDetails.DataBind();

        if (dt.Rows.Count > 0)
        {
            BtnSave.Visible = true;
            BtnCancel.Visible = true;
        }
        else
        {
            BtnSave.Visible = false;
            BtnCancel.Visible = false;
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrientationAttendance.aspx");
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (hdnOperation.Value != "UPDATE")
        {
            hdnOperation.Value = "INSERT";
        }

        if (chkNew.Checked && chkPrevious.Checked || !chkNew.Checked && !chkPrevious.Checked)
            Intake = "N,O";
        else if (chkNew.Checked)
            Intake = "N";
        else if (chkPrevious.Checked)
            Intake = "O";

        int status = 0;

        dt.Columns.Add("Id");
        dt.Columns.Add("DegreeCode");
        dt.Columns.Add("LinkID");        
        dt.Columns.Add("Stud_ID");
        dt.Columns.Add("student_name");
        dt.Columns.Add("Shift_ID");
        dt.Columns.Add("shift_desc");
        dt.Columns.Add("AttendenceDate");
        dt.Columns.Add("IsAttendented");

        Label LblId;
        Label LblDegree;
        Label LblLinkID;      
        Label LblStudID;
        Label LblName;
        Label LblShift;
        Label LblShiftID;
        TextBox TxtAttendenceDate;
        CheckBox ChkAttendented;

        foreach (GridViewRow row in gvStudentDetails.Rows)
        {
            DataRow dr = dt.NewRow();
            LblId = (Label)row.FindControl("LblId");
            LblDegree = (Label)row.FindControl("LblDegree");
            LblLinkID = (Label)row.FindControl("LblLinkID");
            LblStudID = (Label)row.FindControl("LblStudID");
            LblName = (Label)row.FindControl("LblName");
            LblShiftID = (Label)row.FindControl("LblShiftID");
            LblShift = (Label)row.FindControl("LblShift");
            TxtAttendenceDate = (TextBox)row.FindControl("TxtAttendenceDate");
            ChkAttendented = (CheckBox)row.FindControl("ChkAttendented");

            if(hdnOperation.Value == "INSERT")
                dr["Id"] = 0;
            else
                dr["Id"] = LblId.Text;
            
            dr["DegreeCode"] = LblDegree.Text;
            dr["LinkID"] = LblLinkID.Text;
            dr["Stud_ID"] = LblStudID.Text;
            dr["student_name"] = LblName.Text;
            dr["Shift_ID"] = LblShiftID.Text;
            dr["shift_desc"] = LblShift.Text;
            dr["AttendenceDate"] = TxtAttendenceDate.Text;
            dr["IsAttendented"] = ChkAttendented.Checked ? "1" : "0";

            dt.Rows.Add(dr);
        }

        string AttendenceDate = "";
        if (chkIsNeedtoPopulate.Checked)
            AttendenceDate = txtAttendenceDate.Text.ToString();
        
        dt = OrientationAttendence(0, Intake, Convert.ToInt32(ddlTerm.SelectedValue), Convert.ToInt32(ddlDegree.SelectedValue), 0,AttendenceDate, int.Parse(Session["EmpId"].ToString()), hdnOperation.Value.ToString(), dt);
        status = Convert.ToInt32(dt.Rows[0]["Id"]);

        if (status > 0)
        {
            if (hdnOperation.Value == "INSERT")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Sucessfully Saved!');window.location='OrientationAttendance.aspx';</script>");
            }
            else if (hdnOperation.Value == "UPDATE")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Sucessfully Updated!');window.location='OrientationAttendance.aspx';</script>");
            }
            LoadForm();
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('Try Again!');window.location='OrientationAttendance.aspx';</script>");
        }

    }

    protected void gvOrientationAttendanceList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');
        int TermId = Convert.ToInt32(arg[0]);
        int DegreeType = Convert.ToInt32(arg[1]);
        string Intake = Convert.ToString(arg[2]);
        int ShiftId = 0;// Convert.ToInt32(arg[3]);

        bool PreviousIntake = false;
        bool NewIntake = false;

        string[] argIntake = new string[2];
        argIntake = Intake.Split(',');

        if (argIntake.Length > 1)
        {
            PreviousIntake = argIntake[0] == "N" ? true : false;
            NewIntake = argIntake[1] == "O" ? true : false;
        }
        else
        {
            if (argIntake[0].Trim() == "N")
            {
                NewIntake = true;
            }
            else if (argIntake[0].Trim() == "O")
            {
                PreviousIntake = true;
            }
        }

        if (e.CommandName == "Edit")
        {
            hdnOperation.Value = "UPDATE";
            try
            {
                dt = null;
                dt = OrientationAttendence(0,"", TermId, DegreeType,ShiftId, "", 0, "EDIT", dt);
                gvStudentDetails.DataSource = dt;
                gvStudentDetails.DataBind();

                if (dt.Rows.Count > 0)
                {
                    BtnSave.Visible = true;
                    BtnCancel.Visible = true;
                    gvStudentDetails.Columns[8].Visible = true;
                }
                else
                {
                    BtnSave.Visible = false;
                    BtnCancel.Visible = false;
                    gvStudentDetails.Columns[8].Visible = false;
                }

                ddlDegree.AutoPostBack = false;
                chkNew.AutoPostBack = false;
                chkPrevious.AutoPostBack = false;

                BindTerm();
                ddlTerm.SelectedValue = TermId.ToString();
                BindDegree();
                ddlDegree.SelectedValue = DegreeType.ToString();
                chkNew.Checked = NewIntake;
                chkPrevious.Checked = PreviousIntake;

                chkNew.Enabled = false;
                chkPrevious.Enabled = false;
                ddlTerm.Enabled = false;
                ddlDegree.Enabled = false;
                btnLoadStudentsDetails.Enabled = false;

            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Try Again!');window.location='OrientationAttendance.aspx';</script>");
                hdnOperation.Value = "";
            }
        }        
    }

    protected void gvOrientationAttendanceList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOrientationAttendanceList.EditIndex = e.NewEditIndex;
        BindOrientationAttendanceList();
    }

    protected void gvStudentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');
        int TermId = Convert.ToInt32(arg[0]);
        int DegreeType = Convert.ToInt32(arg[1]);
        int Id = Convert.ToInt32(arg[2]);
        int ShiftId = Convert.ToInt32(arg[3]);

        if (e.CommandName == "Delete")
        {
            hdnOperation.Value = "DELETE";
            try
            {
                int status = 0;
                if (TermId != 0 && DegreeType != 0)
                {
                    dt = null;
                    dt = OrientationAttendence(Id, "", TermId, DegreeType,ShiftId, "", int.Parse(Session["EmpId"].ToString()), hdnOperation.Value.ToString(), dt);
                    status = Convert.ToInt32(dt.Rows[0]["Id"]);
                }

                if (status != 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Record deleted successfully!');window.location='OrientationAttendance.aspx';</script>");
                    LoadForm();
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Try Again!');window.location='OrientationAttendance.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Try Again!');window.location='OrientationAttendance.aspx';</script>");
            }
        }
    }

    protected void gvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}