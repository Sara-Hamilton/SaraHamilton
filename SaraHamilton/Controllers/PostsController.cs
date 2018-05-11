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
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Posts.Include(post => post.Comments));
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            post.User = currentUser;
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var postToEdit = _db.Posts.FirstOrDefault(x => x.PostId == id);
            return View(postToEdit);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            _db.Entry(post).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Details(int id)
        {
            var allUsers = await _userManager.Users.ToListAsync();
            var data =  _db.Posts.Include(post => post.Comments).Include(post => post.User).FirstOrDefault(x => x.PostId == id);
            return View("Details", data);
        }
    }
}
