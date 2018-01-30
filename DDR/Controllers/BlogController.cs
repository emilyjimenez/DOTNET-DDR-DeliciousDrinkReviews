using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using DDR.Models;
using DDR.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDR.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Posts.ToList());
        }

        public IActionResult Details(int id)
        {
            var model= _db.Posts
                           .Include(p => p.Comments)
                           .FirstOrDefault(posts => posts.PostId == id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post newPost)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newPost.User = currentUser;
            _db.Posts.Add(newPost);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult CreateComment(int id)
        {
            CommentOnPost commentonpost = new CommentOnPost(id);
            return View(commentonpost);
        }

        [HttpPost]
        public IActionResult CreateComment(CommentOnPost comment)
        {
            Comment newComment = new Comment();
            newComment.CommentId = comment.CommentId;
            newComment.UserName = comment.UserName;
            newComment.Content = comment.Content;
            newComment.PostId = comment.CurrentPostId;

            _db.Comments.Add(newComment);
            _db.SaveChanges();

            return RedirectToAction("Details", "Blog", new { id = comment.CurrentPostId});
        }
    }
}
