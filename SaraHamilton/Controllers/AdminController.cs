using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SaraHamilton.Models;
using SaraHamilton.Data;

namespace SaraHamilton.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View();
        }

        // AJAX method for creating a new post
        [HttpPost]
        public async Task<IActionResult> NewPost(string newTitle, string newContent)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Post newPost = new Post(newTitle, newContent);
            newPost.User = currentUser;
            _db.Posts.Add(newPost);
            _db.SaveChanges();
            return Json(newPost);
        }

        public IActionResult ShowAllPosts()
        {
            var allPostsList = _db.Posts;
            return Json(allPostsList);
        }
    }
}
