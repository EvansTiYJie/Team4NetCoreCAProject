using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team4NetCoreCAProject.Controllers
{
    public class LoginController : Controller

    /*privately readonly Database db;

    public LoginController(Database db)
    {
        this.db = db;
    }*/
    {
        
        public IActionResult Index()
        {
            ViewData["Is_Login"] = "menu_highlight";
            ViewData["Title"] = "Login";
            //
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
                ViewData["Is_Login"] = "menu_highlight";
                return View("Index");
            }
            else
            {
                user.SessionID = Guid.NewGuid().ToString();
                //UserId = user.Id;
               

                Response.Cookies.Append("sessionID", user.SessioId);
                //wtf is timestamp
                Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                //Redirects them to a page we desire? Prolly store
                //return RedirectToAction("Index", "Office");
            };
            // db.Sessions. add(session); 
            // To be configured in the database
            // db.SaveChanges();

            //I think this whole part is just guest ID 
            string currentGuestId = Request.Cookies["guestID"];
            User currentGuestUser = db.Users.FirstOrDefault(x => x.Id == currentGuestId);
            // Cart guestCart = Carts.FirstOrDefault(x=> x.UserId == currentGuestUser.Id);
            
            // if guest user did have items in the cart

            if (guestCart != null)
            {
                //CartDetails
                List<CartDetails> guestCartDetails = guestCartDetails.CartDetails.ToList();

                //    Cart existingcart = db.Cast.FirstOrDefault(x =>x.UserId == user.Id);
                {
                    foreach (CartDetails cd1 in guestCartDetails)
                    {
                        if(cd1.ProductId == cd2.ProductId)
                        {
                            cd1.Quantity = cd1.Quantity + cd2.Quantity;
                            // product in cart made while guest isn't logged in is combined into user'existing car
                            //remove this product/
                            //db.Remove(cd2)
                            //dd.SaveChanges()
                            break;
                        }
                    }
                }    
            
            
            
            
            
            
            
            }



        }

        }
    }
}
