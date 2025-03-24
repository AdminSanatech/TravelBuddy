using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelBuddy_Web.Data;
using TravelBuddy_Web.Helpers;
using TravelBuddy_Web.Models;

namespace TravelBuddy_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
        public async Task<IActionResult> Register(string firstName, string lastName, string email, string password, string rePassword)
        {
            if (password != rePassword)
            {
                TempData["Error"] = "Passwords do not match!";
                return RedirectToAction("Index", "Home");
            }

            // Check if email already exists
            if (_context.Users.Any(u => u.Email == email))
            {
                TempData["Error"] = "Email is already in use!";
                return RedirectToAction("Index", "Home");
            }

           
            var passwordHash =  PasswordHelper.HashPassword(password);


            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = passwordHash,
               
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Registration successful! You can now log in.";
            return RedirectToAction("Index", "Home");
        }

      
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                TempData["Error"] = "Invalid credentials!";
                return RedirectToAction("Index", "Home");
            }

            // Validate Password
            bool isValidPassword = PasswordHelper.VerifyPassword(password, user.PasswordHash);
            if (!isValidPassword)
            {
                TempData["Error"] = "Invalid credentials!";
                return RedirectToAction("Index", "Home");
            }

            // Store user session
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("Dashboard", "Home"); // Redirect to Dashboard after login
        }

        // 🌟 Logout Action
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
