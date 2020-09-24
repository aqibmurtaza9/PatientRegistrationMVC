using PatientRegistrationMVC.Models;
using PatientRegistrationMVC.Models.Account;
using PatientRegistrationMVC.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace PatientRegistrationMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login() 
        {

            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = WebSecurity.Login(loginModel.UserName, loginModel.Password);

                if (isAuthenticated )
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];

                    if (returnUrl == null)
                    {
                       return RedirectToAction("Bill_Payment", "Home");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnUrl));
                    }

                }
            else
            {
                ModelState.AddModelError("","User Name or Password are not invalid");
            }

            }
        
            return View();
        }

        public ActionResult SignOut()
        {
            WebSecurity.Logout();

            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Manager")]
        public ActionResult Register()
        {
            GetRolesForCurrentUser();

            return View();
        }

        private void GetRolesForCurrentUser()
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Administrator"))
            {

                ViewBag.RoleId = (int)Role.Administrator;
            }

            else
            {
                ViewBag.RoleId = (int)Role.NoRole;

            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public ActionResult Register(RegisterModel registerModel)
        {
            GetRolesForCurrentUser();

            if (ModelState.IsValid)
            {
                bool isExists =    WebSecurity.UserExists(registerModel.UserName);            
                     
                if(isExists)
                {
                    ModelState.AddModelError("UserName","User Name is already Exists.");
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(registerModel.UserName,registerModel.Password, new { 
                        FullName=registerModel.FullName, Email=registerModel.Email});
                    Roles.AddUserToRole(registerModel.UserName,registerModel.Role);

                    return RedirectToAction("Bill_Payment","Home");
                }
            }
            return View();
        }



        [HttpGet,Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost, Authorize,ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
              bool isPasswordChanged=  WebSecurity.ChangePassword(WebSecurity.CurrentUserName,changePasswordModel.OldPassword,changePasswordModel.NewPassword);

                if (isPasswordChanged)
                {
                    return RedirectToAction("Bill_Payment", "Home");
                }
                else
                {
                    ModelState.AddModelError("OldPassword","Old Password is incorrect!");
                }
            }
            return View();
        }
    

        

    }
}