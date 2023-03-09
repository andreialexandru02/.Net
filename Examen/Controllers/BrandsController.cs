using AndreiAlexandru42.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndreiAlexandru42.Controllers
{
    public class BrandsController : Controller
    {
        private readonly AppDbContext db;

        public BrandsController(AppDbContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            var brands = from brand in db.Brands
                             orderby brand.Nume
                             select brand;
            ViewBag.Brands = brands;
            return View();
        }
        public ActionResult Show(int id)
        {
            Brand brand = db.Brands.Find(id);
            ViewBag.Brand = brand;
            return View();
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Brand br)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(br);
                db.SaveChanges();
                TempData["message"] = "Categoria a fost adaugata";
                return RedirectToAction("Index");
            }

            else
            {
                return View(br);
            }
        }
    }
}
