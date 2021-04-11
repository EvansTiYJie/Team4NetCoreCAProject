using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Team4NetCoreCAProject.Db;
using Team4NetCoreCAProject.Models;


namespace Team4NetCoreCAProject.Controllers
{
    public class HomeController : Controller


    {
        private readonly Database db;

        public HomeController(Database db)
        {
            this.db = db;
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult UpdateCart([FromBody] UpdateCartInput input)
        {
            Session session = db.Sessions.FirstOrDefault(x => x.Id == Request.Cookies["sessionId"]);

            //check whether the user has a cart before
            Cart existingCart = db.Carts.FirstOrDefault(x => (x.UserId == session.UserId));

            // <1> don't have cart(never shop before)
            if (existingCart == null)
            {
                //create a new cart
                Cart newCart = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = session.UserId  //set newCart.UserId = session.UserId
                };

                db.Add(newCart);
                db.SaveChanges();


                //Add product into cart
                CartDetail newCartDetail = new CartDetail
                {
                    CartId = newCart.Id, //Id of newCart
                    ProductId = int.Parse(input.ProductId),
                    UserId = session.UserId,
                    Quantity = 1 //assume add 1 at each time
                };

                db.Add(newCartDetail);
                db.SaveChanges();

                //count number of products in cart
                ViewData["numberOfProductsInCart"] = newCart.CartDetails.ToList().Sum(x => x.Quantity); //?
            }

            // <2> have existing cart     
            else
            {
                //retrieve cart detail of existing cart
                List<CartDetail> existingCartDetails = existingCart.CartDetails.ToList();

                //check wheter the selected product is in cart before
                CartDetail cartDetailWithThisProduct = existingCartDetails.Find(x => x.ProductId == int.Parse(input.ProductId));

                //<1>the product doesn't exist
                if (cartDetailWithThisProduct == null)
                {
                    CartDetail newCartDetail = new CartDetail
                    {
                        CartId = existingCart.Id,
                        ProductId = int.Parse(input.ProductId),
                        UserId = session.UserId,
                        Quantity = 1
                    };

                    
                    db.Add(newCartDetail);
                    db.SaveChanges();

                    ViewData["numberOfProductsInCart"] = existingCart.CartDetails.ToList().Sum(x => x.Quantity);

                }


                //<2>the product exists
                else
                {
                    cartDetailWithThisProduct.Quantity++;
                    db.SaveChanges();

                    ViewData["numberOfProductsInCart"] = existingCart.CartDetails.ToList().Sum(x => x.Quantity);
                }
                
            }

            return Json(new { status = "success", cartNumber = ViewData["numberOfProductsInCart"].ToString() }); //?

        }
    }
}
