using PatientRegistrationMVC.Models.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientRegistrationMVC.ViewModels.Account
{
    public class AccountViewModel
    {
        public static List<SelectListItem> GetAllRoles(int roleId)
        { 
            List<SelectListItem> roles = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd=new SqlCommand("pro_RolesGetRolesByRoleId ",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@RoleId",roleId );
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Value = reader["RoleName"].ToString();
                        item.Text = reader["RoleName"].ToString();
                        roles.Add(item);

                    }
                }
            }

           return roles;
        }


    }
}