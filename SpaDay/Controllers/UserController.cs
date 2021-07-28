using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("/user/index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            //User newUser = new User(username, email, password);
            // create new yser object, and verify that the password is correct
            // form submission handling code
            if (newUser.Password == verify)
            {
                ViewBag.user = newUser;
                return View("Views/User/Index.cshtml");
            }
            // ViewBag will only ever get passed to a View(), not to a Redirect. Redirect will actually trigger a route, not a view
            ViewBag.error = "Passwords do not match! passwords should match";
            ViewBag.username = newUser.Username;
            ViewBag.email = newUser.Email;
            return View("Views/User/Add.cshtml");
        }
    
        

        /*
        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(string username, string email, string password, string verify)
        {
            User newUser = new User(username, email, password);
            // create new yser object, and verify that the password is correct
            // form submission handling code
            if (newUser.Password == verify)
            {
                ViewBag.user = newUser;
                return View("Views/User/Index.cshtml");
            }
            // ViewBag will only ever get passed to a View(), not to a Redirect. Redirect will actually trigger a route, not a view
            ViewBag.error = "Passwords do not match! passwords should match";
            ViewBag.username = username;
            ViewBag.email = email;
            return View("Views/User/Add.cshtml");
        }
        */
        
    }
}
