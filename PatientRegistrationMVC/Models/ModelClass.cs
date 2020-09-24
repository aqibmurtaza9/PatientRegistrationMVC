using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Script.Serialization;

namespace PatientRegistrationMVC.Models
{
    public class ModelClass
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=lab;Integrated Security=True");
        /// <summary>
        /// Info Registration 
        /// </summary>


        public int Mr_No { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Guardian { get; set; }
        public string Mobile_No { get; set; }
        public string Home_contact { get; set; }
        public int Martial_Status { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }

        public string Maker_Date_time { get; set; }
        /// <summary>
        /// Add Order
        /// </summary>
        public string TestCode { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Urgent { get; set; }
        public string Instruction { get; set; }
        /// <summary>
        /// Bill
        /// </summary>
        public int TotalAmount { get; set; }

        public int BalanceAmount { get; set; }
        public int PaidAmount { get; set; }

        public string Procedure { get; set; }
        public int Fees { get; set; }
        public int INVOICE_NO { get; set; }

        public string DataTableToJSON(DataTable table)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = int.MaxValue;

            return serializer.Serialize(list);
        }


        public string  INSERT()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pro_patient_reg";
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@Mode", "INSERT");
               //  cmd.Parameters.AddWithValue("@Mr_No", Mr_No);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Guardian", Guardian);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Mobile_No", Mobile_No);
                cmd.Parameters.AddWithValue("@Home_Contact", Home_contact);
                cmd.Parameters.AddWithValue("@Martial_Status", Martial_Status);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@CNIC", CNIC);
                cmd.Parameters.AddWithValue("@Address", Address);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                return  dt.Rows[0][0].ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string INSERTMASTER()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "pro_request_master";
                cmd.Parameters.AddWithValue("@Mode", "INSERT");
                cmd.Parameters.AddWithValue("@Mr_No", Mr_No);
                cmd.Parameters.AddWithValue("@Total_Amount", TotalAmount);
                cmd.Parameters.AddWithValue("@Balance_Amount", BalanceAmount);
                cmd.Parameters.AddWithValue("@Paid_Amount", PaidAmount);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void INSERTDETAIL()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pro_request_detail";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Mode", "INSERT");
                cmd.Parameters.AddWithValue("@Mr_No", Mr_No);
                cmd.Parameters.AddWithValue("@Invoice_No", INVOICE_NO);
                cmd.Parameters.AddWithValue("@Test_Code", TestCode);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Urgent_Type", Urgent);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable READ()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pro_requestinfo";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Mode", "READ");
            cmd.Parameters.AddWithValue("@Mr_No", Mr_No);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();

            return ds.Tables[0];


        }
       
       
        public void UPDATE()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pro_patient_reg";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Mode", "UPDATE");
                cmd.Parameters.AddWithValue("@Mr_No", Mr_No);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Guardian", Guardian);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Mobile_No", Mobile_No);
                cmd.Parameters.AddWithValue("@Home_Contact", Home_contact);
                cmd.Parameters.AddWithValue("@Martial_Status", Martial_Status);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@CNIC", CNIC);
                cmd.Parameters.AddWithValue("@Address", Address);

                //cmd.Parameters.AddWithValue("@Test_Code", TestCode);
                //cmd.Parameters.AddWithValue("@Quantity", Quantity);
                //cmd.Parameters.AddWithValue("@Urgent_Type", Urgent);
                //cmd.Parameters.AddWithValue("@Amount", Amount);

                //cmd.Parameters.AddWithValue("@Total_Amount", TotalAmount);
                //cmd.Parameters.AddWithValue("@Balance_Amount", BalanceAmount);
                //cmd.Parameters.AddWithValue("@Paid_Amount", PaidAmount);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable INFOREAD()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "pro_requestinfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Mode", "INFOREAD");
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            

            return ds;

        }
        public DataTable VIEWINFO()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "pro_requestinfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Mode", "VIEWINFO");
            cmd.Parameters.AddWithValue("@Mr_No", Mr_No);
           

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            return dt;

        }
       


    }
}