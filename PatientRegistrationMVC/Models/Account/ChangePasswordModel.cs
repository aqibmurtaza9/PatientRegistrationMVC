using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientRegistrationMVC.Models.Account
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="Old Password is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage ="New Password is required.")]
        public string NewPassword { get; set; }


        [Required(ErrorMessage ="Confirm Password is required.")]
        [Compare(otherProperty:"NewPassword",ErrorMessage ="New Password does'nt match!")]
        public string ConfirmPassword { get; set; }
    }
}