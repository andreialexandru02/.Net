using Microsoft.AspNetCore.Mvc;
using _12_dec_2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using _12_dec_2022.Data;

namespace _12_dec_2022.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationDbContext> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
