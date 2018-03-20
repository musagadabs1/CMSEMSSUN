using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Pages_Followupschedulelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.FillGridView(1);
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                Drpschool.DataSource = s.SetDropdownListAsDegreeType(50, 1, Session["schoolcode"].ToString());
                Drpschool.DataTextField = "schoolname";
                Drpschool.DataValueField = "schoolcode";
                Drpschool.DataBind();
                Drpschool.SelectedValue = Session["schoolcode"].ToString();

                Drpschool_SelectedIndexChanged(sender, e);
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");

        }
    }

    protected void Drpschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvStudentList.DataSource = null;
        gvStudentList.DataBind();

    }
    //private void FillGridView(int pageIndex)
    //{
    //    try
    //    {
    //        StudentRegistrationDAL s = new StudentRegistrationDAL();
    //        gvStudentList.DataSource = s.GetFollowupList(int.Parse(Session["EmpId"].ToString()), pageIndex, 10,);
    //        gvStudentList.DataBind();

         
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    private void FillGridView(int pageIndex)
    {
       
            string constring = ConfigurationManager.ConnectionStrings["SkyLineConnection"].ConnectionString;
              
        using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetFollowupList_Paging", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@schoolcode", Drpschool.SelectedValue);
                        cmd.Parameters.AddWithValue("@empid", int.Parse(Session["EmpId"].ToString()));
                        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                        cmd.Parameters.AddWithValue("@PageSize", 20);
                        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                        con.Open();
                        IDataReader idr = cmd.ExecuteReader();
                        gvStudentList.DataSource = idr;
                        gvStudentList.DataBind();
                        idr.Close();
                        con.Close();
                        try
                        {
                            int recordCount = int.Parse(Session["fcount"].ToString());
                            this.PopulatePager(recordCount, pageIndex);
                        }
                        catch
                        {
                            int recordCount = 1;
                            this.PopulatePager(recordCount, pageIndex);

                        }

                    }
                }

                catch
                {


                }
                finally
                {
                    if (con.State.Equals("Open"))
                        con.Close();
                }




        }
      
       
    }


    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / 20);
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
            pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        this.FillGridView(1);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.FillGridView(pageIndex);
    }
    protected void gvStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblSN = (Label)e.Row.FindControl("lblSN");
            //lblSN.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Modify"))
            {
                string Id = e.CommandArgument.ToString();
                StudentRegistrationDAL s = new StudentRegistrationDAL();
                //string Result = s.InsertAttendCall(Id);
                //Response.Redirect(string.Format("FollowUp.aspx?Id={0}", Id), false);

                              int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                              GridViewRow row = gvStudentList.Rows[index];

                              HiddenField hn1 = (HiddenField)gvStudentList.Rows[index].FindControl("hdnid");
                  HiddenField hn2 = (HiddenField)gvStudentList.Rows[index].FindControl("hdnstud");
               if (hn2.Value=="4")
                   Response.Redirect("Followupexistingstud.aspx?Id=" + int.Parse(hn1.Value) + "&A=" + "F", false);
               else
                
                Response.Redirect("FollowUp.aspx?Id=" + int.Parse(hn1.Value) + "&A=" + "F", false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}