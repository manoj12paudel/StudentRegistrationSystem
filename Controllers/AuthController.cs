using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace StudentRegestrationSystem.Controllers
{
    public class AuthController : Controller
    {
        public ViewResult Signup()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        public ViewResult Regestration ()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }

       

     
        public ViewResult Remove()
        {
            return View();
        }
        public ViewResult Removestudent()
        {
            return View();
        }
        public ViewResult SearchStudent()
        {
            return View();
        }
        public ViewResult Courses()
        {
            return View();
        }
        public ViewResult Payment()
        {
            return View();
        }
    }
}
