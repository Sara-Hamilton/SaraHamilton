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

        [HttpPost]
        public async Task<IActionResult> NewPost(string newTitle, string newContent)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Post newPost = new Post(title: newTitle, content: newContent);
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

        [HttpPost]
        public IActionResult DeletePost(int postId)
        {
            var postToDelete = _db.Posts.FirstOrDefault(x => x.PostId == postId);
            if (postToDelete == null)
            {
                return Json(postToDelete);
            }
            else
            {
                _db.Remove(postToDelete);
                _db.SaveChanges();
                return Json(postToDelete);
            }
        }

    }
}
