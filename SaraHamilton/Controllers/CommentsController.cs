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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SaraHamilton.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Comments.Where(x => x.User.Id == currentUser.Id));
        }

        public async Task<IActionResult> Create(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            ViewBag.VBPostId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Comment comment = new Comment();
            comment.Body = Request.Form["body"];
            comment.PostId = int.Parse(Request.Form["postId"]);
            var routeId = int.Parse(Request.Form["postId"]);
            comment.UserId = currentUser.Id;
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
