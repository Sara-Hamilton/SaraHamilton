using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaraHamilton.Models;

namespace SaraHamilton.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GitHub()
        {
            var userRepos = GitHubRepos.GetGitHubRepos().Take(3);
            return View(userRepos);
        }
    }
}
