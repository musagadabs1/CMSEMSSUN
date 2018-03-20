//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Services;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Data;

//[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
////[System.Web.Script.Services.ScriptService]
//public class AutoComlete : System.Web.Services.WebService
//{

//    public AutoComlete () {

//        //Uncomment the following line if using designed components 
//        //InitializeComponent(); 
//    }

//    [WebMethod]

//    public string[] GetCompletionList(string prefixText, int count)
//    {
//        if (count == 0)
//        {
//            count = 10;
//        }
//        Random random = new Random();
//        List<string> items = new List<string>(count);

//        for (int i = 0; i < count; i++)
//        {
//            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SkyLineConnection"].ToString());
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("select FirstName+' '+MiddleName+' '+LastName as Name from tblStudent where status='true' and FirstName + ' ' + MiddleName + ' ' + LastName like '%'+'"+prefixText+"'+'%'", connection);
//            cmd.CommandType = System.Data.CommandType.Text;
//            SqlDataAdapter da = new SqlDataAdapter(cmd);
//            DataTable dt = new DataTable();
//            da.Fill(dt);
//            connection.Close();
//            foreach (DataRow ro in dt.Rows)
//            {
//                items.Add(ro[0].ToString());
//            }            
//        }
//        return items.ToArray();
//    }    
//}
