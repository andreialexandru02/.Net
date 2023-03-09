using AndreiAlexandru42.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AndreiAlexandru42.Controllers
{
    public class GiftCardsController : Controller
    {
        private readonly AppDbContext db;
        public GiftCardsController(AppDbContext context)
        {
            db = context;
        }

       
        public IActionResult Index()
        {
            //MOTORUL DE CAUTARE
            
            //var gifcard = db.GiftCards.Include("Category");
            //var search = "";
            //// MOTOR DE CAUTARE
            //if (Convert.ToString(HttpContext.Request.Query["search"]) !=
            //null)
            //{
            //    search =
            //    Convert.ToString(HttpContext.Request.Query["search"]).Trim();
            //    List<int> GiftCardsIds = db.GiftCards.Where
            //                                            (
            //                                            gif => gif.DataExp.Contains(search)
            //                                            && gif.Procent.Contains(search)
            //                                            ).Select(a => a.Id).ToList();
           





        var giftcards = db.GiftCards.Include("Brand");
            
            
            ViewBag.GiftCards = giftcards;
            return View();
        }
        public ActionResult Show(int id)
        {
            GiftCard giftcard = db.GiftCards.Include("Brand")
                               .Where(gif => gif.Id == id)
                               .First();

            ViewBag.GiftCard = giftcard;

            ViewBag.Brand = giftcard.Brand;

            return View();
        }
        [NonAction]
        public IEnumerable<SelectListItem> GetAllBrands()
        {
            var selectList = new List<SelectListItem>();

           
            var brands = from br in db.Brands
                             select br;

            
            foreach (var brand in brands)
            {
              
                selectList.Add(new SelectListItem
                {
                    Value = brand.Id.ToString(),
                    Text = brand.Nume.ToString()
                });
            }
           
            return selectList;
        }
        public IActionResult New()
        {
            var brands = from br in db.Brands
                             select br;

            ViewBag.Brands = brands;

            return View();
        }

        [HttpPost]
        public IActionResult New(GiftCard giftcard)
        {
            var brands = from br in db.Brands
                         select br;

            ViewBag.Brands = brands;
            if (ModelState.IsValid)
            {
                db.GiftCards.Add(giftcard);
                db.SaveChanges();
                TempData["message"] = "Giftcardul a fost adaugat";
                return RedirectToAction("Index");
            }
            else
            {
                return View(giftcard);
            }
        }
        public IActionResult Edit(int id)
        {
            GiftCard giftcard = db.GiftCards.Include("Brand")
                                         .Where(gif => gif.Id == id)
                                         .First();

            ViewBag.GiftCard = giftcard;
            ViewBag.Brand = giftcard.Brand;

            var brands = from brd in db.Brands
                             select brd;

            ViewBag.Brands = brands;

            return View();
        }

        
        [HttpPost]
        public IActionResult Edit(int id, GiftCard requestGiftCard)
        {
            GiftCard giftcard = db.GiftCards.Find(id);

            try
            {
                {
                    giftcard.Denumire = requestGiftCard.Denumire;
                    giftcard.Descriere = requestGiftCard.Descriere;
                    giftcard.DataExp = requestGiftCard.DataExp;
                    giftcard.DataExp = requestGiftCard.DataExp;
                    giftcard.BrandId = requestGiftCard.BrandId;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            catch (Exception)
            {
                ViewBag.GiftCard = requestGiftCard;
                return RedirectToAction("Index", id);
                // return View(requestGiftCard);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            GiftCard giftcard = db.GiftCards.Find(id);
            db.GiftCards.Remove(giftcard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
