using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team4NetCoreCAProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppData appData;
        public LoginController(AppData appdata)
        {
            this.appData= appData;
        }
        //declares the appData
        public IActionResult Index()
        {
            return View();
        }
        // Should link this and store this in an SQL server
        public IActionResult Authenticate(string username, string password)
        {
            User user = appData.Users.Find(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                ViewData["username"] = username;
                ViewData["errMsg"] = " no such user or incorrect password";

                return View("Index");
            }
            else
            {
                user.SessionID = Guid.NewGuid().ToString();
                Response.Cookies.Append("sessionID", user.SessioId);

                return RedirectToAction("Index", "Office");
            }
        }

        }
    }
}
