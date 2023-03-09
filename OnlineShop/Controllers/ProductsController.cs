using LeatherShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeatherShop.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {

            var products = from product in db.Products
                           orderby product.Name
                           select product;

            ViewBag.Products = products;
            return View();

        }
        public ActionResult Show(int id)
        {
            Console.WriteLine("PRODUSUL NOUMARUL " + id);
            Product product = db.Products.Find(id);
            ViewBag.Product = product;
            return View();
        }

      
  
    }
}
