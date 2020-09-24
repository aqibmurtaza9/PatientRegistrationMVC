using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PatientRegistrationMVC.Models.General
{
    public class AppSetting
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["lab"].ConnectionString;
        }
    }


}