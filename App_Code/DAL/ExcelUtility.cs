using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for ExcelUtility
/// </summary>
public class ExcelUtility
{
    public static string ToExcel(object dataSource)
    {
        GridView grid = new GridView { DataSource = dataSource };
        grid.DataBind();

        StringBuilder sb = new StringBuilder();
        foreach (TableCell cell in grid.HeaderRow.Cells)
            sb.Append(string.Format("\"{0}\",", cell.Text));
        sb.Remove(sb.Length - 1, 1);
        sb.AppendLine();

        foreach (GridViewRow row in grid.Rows)
        {
            foreach (TableCell cell in row.Cells)
                sb.Append(string.Format("\"{0}\",", cell.Text.Trim().Replace("&nbsp;", string.Empty)));
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
        }
        ExportToExcel(sb.ToString());
        return "";
    }

    public static void ExportToExcel(string data)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Report.csv");
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.Write(data);
        HttpContext.Current.Response.End();
    }

    public static string ToExcel1(object dataSource)
    {
        GridView grid = new GridView { DataSource = dataSource };
        grid.DataBind();

        DataTable Dt = (DataTable)grid.DataSource;
        ExportToExcel1(Dt);
        return "";
    }

    public static void ExportToExcel1(DataTable table)
    {

        GridView grid = new GridView { DataSource = table };
        grid.DataBind();

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
        //am getting my grid's column headers
        int columnscount = grid.Columns.Count;

        if (columnscount > 0)
        {
            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(grid.Columns[j].HeaderText.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
        }
        else
        {

            foreach (DataColumn column in table.Columns)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(column.ColumnName);
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
        }

        HttpContext.Current.Response.Write("</TR>");
        foreach (DataRow row in table.Rows)
        {//write in new row
            HttpContext.Current.Response.Write("<TR>");
            for (int i = 0; i < table.Columns.Count; i++)
            {


                //HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write("<style>  .txt " + "\r\n" + " {mso-style-parent:style0;mso-number-format:\"" + @"\@" + "\"" + ";} " + "\r\n" + "</style>");
                HttpContext.Current.Response.Write("<Td class='txt'>");
                HttpContext.Current.Response.Write(row[i].ToString());
                HttpContext.Current.Response.Write("</Td>");
            }

            HttpContext.Current.Response.Write("</TR>");
        }
        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();

    }
}