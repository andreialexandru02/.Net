using Microsoft.AspNetCore.Mvc;
using _12_dec_2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using _12_dec_2022.Data;

namespace _12_dec_2022.Controllers
{
    [Authorize]
    public class ThreadsController : Controller
    {



        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        //public ThreadsController(ApplicationDbContext context)
        //{
        //    db = context;
        //}

        public ThreadsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //Crearea unui thread nou
        [Authorize(Roles = "Editor,Admin")]
        public ActionResult New()

        {

            Models.Thread thread = new Models.Thread();
            thread.Categ = GetAllCategories();
            // thread.Categ = category;
            return View(thread);

        }

        [HttpPost]//("/{category}")]
        public ActionResult New(Models.Thread thr)//, Models.Category category)
        {
            thr.Date = DateTime.Now;
            thr.Categ = GetAllCategories();
            thr.IdUser = _userManager.GetUserId(User);
            //thr.Categ = (IEnumerable<SelectListItem>?)category;

            if (ModelState.IsValid)
            {
                db.Threads.Add(thr);
                db.SaveChanges();
                TempData["message"] = "Threadul a fost adaugata";
                return RedirectToAction("Index");
            }

            else
            {
                return View(thr);
            }
        }



        public IActionResult Index()
        {
            var thr = db.Threads.Include("Category");
            ViewBag.Threads = thr;

            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }

            var thrs = from thread in db.Threads
                       orderby thread.Date
                       select thread;
            ViewBag.Categories = thrs;

            return View();
        }
        //public IActionResult Index()
        //{
        //    var threads = db.Threads.Include("Category");
        //    // ViewBag.OriceDenumireSugestiva
        //    ViewBag.Threads = threads;

        //    if (TempData.ContainsKey("message"))
        //    {
        //        ViewBag.Message = TempData["message"];
        //    }

        //    return View();
        //}

        [NonAction]
        public IEnumerable<SelectListItem> GetAllCategories()
        {
            // generam o lista de tipul SelectListItem fara elemente
            var selectList = new List<SelectListItem>();

            // extragem toate categoriile din baza de date
            var categories = from cat in db.Categories
                             select cat;

            // iteram prin categorii
            foreach (var category in categories)
            {
                // adaugam in lista elementele necesare pentru dropdown
                // id-ul categoriei si denumirea acesteia
                selectList.Add(new SelectListItem
                {
                    Value = category.IdCategory.ToString(),
                    Text = category.CategoryName.ToString()
                });
            }

            return selectList;
        }
        public ActionResult IndexNou()
        {
            return View();
        }


        public ActionResult Show(int id)
        {
            // Models.Thread thread = db.Threads.Find(id);
            ViewBag.Replies = GetAllReplies();
            Models.Thread thread = db.Threads.Include("Category")//.Include("Reply")
                               .Where(thr => thr.IdThread == id)
                               .First();
            return View(thread);
        }
        //[HttpPost]
        //public IActionResult Show([FromForm] Reply reply)
        //{
        //    ViewBag.Replies = GetAllReplies();
        //    reply.Date = DateTime.Now;
        //    if (ModelState.IsValid)
        //    {
        //        db.Replies.Add(reply);
        //        db.SaveChanges();
        //        return Redirect("/Threads/Show/" + reply.IdThread);
        //    }

        //    else
        //    {
        //        Models.Thread thr = db.Threads.Include("Category")//.Include("Reply-uri")
        //                       .Where(thr => thr.IdThread == reply.IdThread)
        //                       .First();

        //        //return Redirect("/Articles/Show/" + comm.ArticleId);

        //        return View(thr);
        //    }
        //}

        public ActionResult Edit(int id)
        {
            Models.Thread thread = db.Threads.Find(id);

            return View(thread);
        }
        [HttpPost]
        public ActionResult Edit(int id, Models.Thread requestThread)
        {
            Models.Thread thread = db.Threads.Find(id);


            if (ModelState.IsValid)
            {

                thread.Content = requestThread.Content;
                thread.IdCategory = requestThread.IdCategory;
                db.SaveChanges();
                TempData["message"] = "Threadul a fost modificat!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Threadul nu a fost modificat!";
                return View(requestThread);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Models.Thread thread = db.Threads.Find(id);
            db.Threads.Remove(thread);
            db.SaveChanges();
            TempData["message"] = "Articolul a fost sters";
            return RedirectToAction("Index");
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllReplies()
        {

            var selectList = new List<SelectListItem>();


            var replies = from rpl in db.Replies
                          select rpl;

            foreach (var reply in replies)
            {

                selectList.Add(new SelectListItem
                {
                    Value = reply.IdThread.ToString(),
                    Text = reply.Content.ToString()
                });
            }

            return selectList;
        }
        [HttpPost]
        public IActionResult Show([FromForm] Reply reply)
        {
            reply.Date = DateTime.Now;
             //  reply.UserId = _userManager.GetUserId(User);
            
            if (ModelState.IsValid)
            {
                //Console.WriteLine("BAAAAAAAAAAAA");
                db.Replies.Add(reply);
                db.SaveChanges();
                return Redirect("/Threads/Show/" + reply.IdThread);
            }

            else
            {
                //Console.WriteLine("maaaaaaaaaaaaa");
                Models.Thread thr = db.Threads.Include("Category").Include("Replies")
                              .Where(thr => thr.IdThread == reply.IdThread)
                              .First();

                return Redirect("/Threads/Show/" + thr.IdThread);

                //  SetAccessRights();

                return View(thr);
            }

        }
    }
}
