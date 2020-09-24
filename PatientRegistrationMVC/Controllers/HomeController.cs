using PatientRegistrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PatientRegistrationMVC.Controllers
{
    public class HomeController : Controller 
    {
         
        [Authorize]
        public ActionResult Bill_Payment( )
        {

            return View();


        }



        [Authorize]
        public ActionResult All_Patient()
        {
            return View();
        }

        [Authorize]
        public ActionResult Registration()
        {
            return View();
        }

       



        public  JsonResult insert(
                               string mrno,
                                string name,
                                string guardian,
                                string gender,
                                string mobile,
                                string home,
                                string status,
                                string dob,
                                string email,
                                string city,
                                string cnic,
                                string address
        //                           string qty,
        ///string testcode,
        //                    string amount,
        //                    string urgent,
        //                   
                               )
      


        {
            ModelClass cls = new ModelClass();
            //cls.Mr_No = Convert.ToInt32(mrno);
            cls.Name = name;
            cls.Guardian = guardian;
            cls.Gender = Convert.ToInt32(gender);
            cls.Mobile_No = mobile;
            cls.Home_contact = home;
            cls.Martial_Status = Convert.ToInt32(status);
            cls.DOB = Convert.ToDateTime(dob);
            cls.Email = email;
            cls.City = city;
            cls.CNIC = cnic;
            cls.Address = address;

            //cls.TestCode = testcode;
            //cls.Quantity = Convert.ToInt32(qty);
            //cls.Amount = Convert.ToInt32(amount);
            //cls.Urgent = urgent;

            //cls.TotalAmount = Convert.ToInt32(totalamount);
            //cls.PaidAmount = Convert.ToInt32(paid);
            //cls.BalanceAmount = Convert.ToInt32(balance);
          var a =  cls.INSERT();


            return Json(a,JsonRequestBehavior.AllowGet);


        }

        public JsonResult insertmaster(
                              string mrno,
                               string totalamount,
                                string balance,
                                string paid

                             )



        {
            ModelClass cls = new ModelClass();

            cls.Mr_No = Convert.ToInt32(mrno);
            cls.TotalAmount = Convert.ToInt32(totalamount);
            cls.PaidAmount = Convert.ToInt32(paid);
            cls.BalanceAmount = Convert.ToInt32(balance);
            var a = cls.INSERTMASTER();


            return Json(a, JsonRequestBehavior.AllowGet);

        }




        public JsonResult insertdetail(string mrno,string invoice,string testcode, string qty, string amount,string urgent)
        {
            ModelClass cls = new ModelClass();

            cls.Mr_No = Convert.ToInt32(mrno);
            cls.INVOICE_NO = Convert.ToInt32(invoice);
            cls.TestCode = testcode;
            cls.Quantity = Convert.ToInt32(qty);
            cls.Amount = decimal.Parse(amount);
            cls.Urgent = urgent;
            cls.INSERTDETAIL();

            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
        public JsonResult update(
                                  int mrno,
                                string name,
                                string guardian,
                                string gender,
                                string mobile,
                                string home,
                                string status,
                                string dob,
                                string email,
                                string city,
                                string cnic,
                                string address
                                //string testcode,
                                //string qty,
                                //string amount,
                                //string urgent,
                                //string totalamount,
                                //string balance,
                                //string paid
            )


        {
            ModelClass cls = new ModelClass();
            cls.Mr_No = mrno;
            cls.Name = name;
            cls.Guardian = guardian;
            cls.Gender = Convert.ToInt32(gender);
            cls.Mobile_No = mobile;
            cls.Home_contact = home;
            cls.Martial_Status = Convert.ToInt32(status);
            cls.DOB = Convert.ToDateTime(dob);
            cls.Email = email;
            cls.City = city;
            cls.CNIC = cnic;
            cls.Address = address;

            //cls.TestCode = testcode;
            //cls.Quantity = Convert.ToInt32(qty);
            //cls.Amount = Convert.ToInt32(amount);
            //cls.Urgent = urgent;

            //cls.TotalAmount = Convert.ToInt32(totalamount);
            //cls.PaidAmount = Convert.ToInt32(paid);
            //cls.BalanceAmount = Convert.ToInt32(balance);
            cls.UPDATE();


            return Json("OK", JsonRequestBehavior.AllowGet);



        }

        //public JsonResult viewinfo(string mr)


        //{
        //    ModelClass cls = new ModelClass();
        //    cls.Mr_No = mr;

        //    cls.VIEWINFO();


        //    return Json("OK", JsonRequestBehavior.AllowGet);

        //}
    }
}

    