using Microsoft.AspNetCore.Mvc;
using _12_dec_2022.Models;
using Microsoft.AspNetCore.Authorization;
using _12_dec_2022.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _12_dec_2022.Controllers
{
    [Authorize]
    public class RepliesController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationDbContext> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public RepliesController(ApplicationDbContext context)
        {
            db = context;
        }

        public ActionResult New()

        {

            Reply reply = new Reply();
            //reply.Thrd = GetAllThreads();
            return View(reply);

        }

        [HttpPost]
        public IActionResult New(Reply rpl)
        {
            rpl.Date = DateTime.Now;
            // rpl.Thrd = GetAllThreads();
            
            if (ModelState.IsValid)
            {
                //Console.WriteLine("hello");
                db.Replies.Add(rpl);
                db.SaveChanges();
                TempData["message"] = "Reply-ul a fost adaugata";
                return Redirect("/Threads/" + rpl.IdThread);
            }

            else
            {
                Console.WriteLine("NO hello");
                return Redirect("/Threads/" + rpl.IdThread);
            }

        }
        //public ActionResult New()

        //{

        //    Reply reply = new Reply();
        //    reply.thread = GetAllthreads();
        //    // thread.Categ = category;
        //    return View(reply);

        //}

        //[HttpPost]
        //public ActionResult New(Reply rpl)
        //{
        //    rpl.Date = DateTime.Now;


        //    if (ModelState.IsValid)
        //    {
        //        db.Replies.Add(rpl);
        //        db.SaveChanges();
        //        TempData["message"] = "Reply-ul a fost adaugata";
        //        return RedirectToAction("Index");
        //    }

        //    else
        //    {
        //        return View(rpl);
        //    }
        //}
        // Adaugarea unui comentariu asociat unui articol in baza de date


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
        public IActionResult Delete(int id)
        {
            Reply rpl = db.Replies.Find(id);
            db.Replies.Remove(rpl);
            db.SaveChanges();
            return Redirect("/Threads/Show/" + rpl.IdThread);
        }

        

        public IActionResult Edit(int id)
        {
            Reply rpl = db.Replies.Find(id);

            return View(rpl);
        }

        [HttpPost]
        public IActionResult Edit(int id, Reply requestReply)
        {
            Reply rpl = db.Replies.Find(id);

            if (ModelState.IsValid)
            {

                rpl.Content = requestReply.Content;

                db.SaveChanges();

                return Redirect("/Threads/Show/" + rpl.IdThread);
            }
            else
            {
                return View(requestReply);
            }

        }

    }
}

