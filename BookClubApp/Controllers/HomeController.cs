using BookClub.Memory.Repositories;
using BookClub.Memory;
using BookClubApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookClub.Memory.Repositories.internals;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using BookClub.Models.Entities;

namespace BookClubApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginService _loginService;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, LoginService loginService, IUserRepository userRepository)
        {
            _logger = logger;
            _loginService = loginService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username)
        {
            _loginService.CreateUserIfNotExists(username);
            var user = _userRepository.GetUserByName(username).Result;
            HttpContext.Session.SetString("username", user.Name);

            return RedirectToAction("Welcome");
        }

        public IActionResult Welcome()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}