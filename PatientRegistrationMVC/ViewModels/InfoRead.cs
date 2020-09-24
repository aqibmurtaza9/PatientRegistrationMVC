using PatientRegistrationMVC.Models.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PatientRegistrationMVC.ViewModels
{
    public class InfoRead
    {
        SqlConnection con = new SqlConnection(AppSetting.ConnectionString());

        //public string MR_No { get; set; }
        //public DataTable INFOREAD()
        //{

        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "Pro_Profile";
        //    cmd.Connection = con;
        //    cmd.Parameters.AddWithValue("@Mode", "INFOREAD");
        //    cmd.Parameters.AddWithValue("@Mr_No",MR_No);

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    con.Close();
        //    con.Dispose();

        //    return ds.Tables[0];

        //}

        //public string DataTableToJSON(DataTable table)
        //{
        //    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        Dictionary<string, object> dict = new Dictionary<string, object>();
        //        foreach (DataColumn col in table.Columns)
        //        {
        //            dict[col.ColumnName] = row[col];
        //        }
        //        list.Add(dict);
        //    }

        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    serializer.MaxJsonLength = int.MaxValue;

        //    return serializer.Serialize(list);
        //}
    }
}