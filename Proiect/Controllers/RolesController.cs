using Microsoft.AspNetCore.Mvc;
using _12_dec_2022.Models;
using _12_dec_2022.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace _12_dec_2022.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationDbContext> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
