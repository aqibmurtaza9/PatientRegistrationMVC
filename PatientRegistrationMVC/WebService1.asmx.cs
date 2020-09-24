using PatientRegistrationMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using PatientRegistrationMVC.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace PatientRegistrationMVC
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        

        [WebMethod]
        public string HelloWorld()
        {

            return "Hello World";
        }

        [WebMethod]
        public void inforead()
        {
            DataTable dt = new DataTable();
            ModelClass obj = new ModelClass();
            dt = obj.INFOREAD();

            var fields = obj.DataTableToJSON(dt);
            Context.Response.Write(fields);
            
           
        }
      

        [WebMethod]
        public void viewinfo(string mr)
        {
            DataTable dt = new DataTable();
           ModelClass cls = new ModelClass();

            cls.Mr_No = Convert.ToInt32(mr);

            dt = cls.VIEWINFO();

            var fields = cls.DataTableToJSON(dt);

            Context.Response.Write(fields);
         }

        [WebMethod]
        public void orderlist()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["lab"].ConnectionString);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT [Id]
                                                            ,[Procedure]
                                                          ,[Amount]
                                                      FROM[dbo].[Tbl_OrderTest]", con);

            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<string>[] list = new List<string>[ds.Tables[0].Rows.Count];

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list[i] = new List<string>();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {

                        list[i].Add(ds.Tables[0].Rows[i][k].ToString());
                    }

                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(list));
            }

        }


        //}

    }
}
