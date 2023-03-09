using Microsoft.AspNetCore.Mvc;
using _12_dec_2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using _12_dec_2022.Data;

namespace _12_dec_2022.Controllers
{
    [Authorize]

    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationDbContext> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public CategoriesController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }

            var categories = from category in db.Categories
                             orderby category.CategoryName
                             select category;
            ViewBag.Categories = categories;

            ViewBag.Threads = GetAllThreads();
            return View();
            
        }
        
        public ActionResult Show(int id)
        {
            ViewBag.Threads = GetAllThreads();
            Category category = db.Categories.Find(id);
            return View(category);
               
        }
        [HttpPost]
        public IActionResult Show([FromForm] Category category)
        {
            ViewBag.Threads = GetAllThreads();
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return Redirect("/Categories/Show/" + category.IdCategory);
            }

            else
            {
                Category cat = category;

               
                return View(cat);
            }
        }
        [NonAction]
        public IEnumerable<SelectListItem> GetAllThreads()
        {
            
            var selectList = new List<SelectListItem>();

            
            var threads = from thr in db.Threads
                             select thr;

            foreach (var thread in threads)
            {
                
                selectList.Add(new SelectListItem
                {
                    Value = thread.IdThread.ToString(),
                    Text = thread.Content.ToString()
                });
            }

            return selectList;
        }

        [HttpPost]
        public ActionResult New(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                TempData["message"] = "Categoria a fost adaugata";
                return RedirectToAction("Index");
            }

            else
            {
                return View(cat);
            }
        }

        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(int id, Category requestCategory)
        {
            Category category = db.Categories.Find(id);

            if (ModelState.IsValid)
            {

                category.CategoryName = requestCategory.CategoryName;
                db.SaveChanges();
                TempData["message"] = "Categoria a fost modificata!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(requestCategory);
            }
        }



        public ActionResult New()

        {
            return View();
        
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            TempData["message"] = "Categoria a fost stearsa";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
