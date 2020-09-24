using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientRegistrationMVC.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="UserName is required")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is required")]
        [Compare(otherProperty:"Password", ErrorMessage ="Password does'nt match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Role is required")]
        [UIHint("RolesComboBox")]
       public string Role { get; set; }

        
        
    }
   
   
}