using LeatherShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeatherShop.Controllers
{
    public class OrdersController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {
            var orders = from order in db.Orders
                           select order;

            ViewBag.Orders = orders;
            if (TempData.ContainsKey("message"))
            {
                ViewBag.Message = TempData["message"];
            }
            return View();
        }

        public ActionResult Show(int id)
        {
            
            Order order = db.Orders.Find(id);

            var product = from prod in db.Products
                          where prod.ProductID == order.ProductID
                          select prod;

            ViewBag.OrderedProduct = product;
            ViewBag.Order = order;
            return View();
        }
        //[Route("Orders/New/{ProdId}")]
        public ActionResult New(int id)

        {
            //Console.WriteLine("PRODUSUL NOUMARUL DE COMANDA " + id);
            
            var product = (from prod in db.Products
                          where prod.ProductID == id
                          select prod).First();

            ViewBag.OrderedProduct = product;
            return View();

        }
        [HttpPost]
        public IActionResult New(Order order)
        {

            //var stock = (from prod in db.Products
            //    where prod.ProductID == order.ProductID
            //    select prod.AvailableStock).First();
            Product product = db.Products.Find(order.ProductID);
            if (ModelState.IsValid && product.AvailableStock >= order.NumberOfProducts)
            {
                //Console.WriteLine("HELLO");
                product.AvailableStock -= order.NumberOfProducts;
                db.Orders.Add(order);
                db.SaveChanges();
                TempData["message"] = "Comanda a fost plasată";
                return Redirect("/Orders/Index");
                // return Redirect("/Orders/Show/" + order.ProductID);
                //return Redirect("/Home/Index");
            }
            else
            {
               // Console.WriteLine("NO HELLO");
                TempData["message"] = "Comanda nu a putut fi plasată";
                //return Redirect("Orders/Show/" + order.ProductID);
                return Redirect("/Orders/New/"+order.ProductID);
            }

        }
    }
}
