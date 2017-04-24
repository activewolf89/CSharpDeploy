using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bright_Ideas.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bright_Ideas.Controllers
    {
        public class Bright_IdeasController: Controller
        {
                private Bright_IdeasPlannerContext _context;
 
                public Bright_IdeasController(Bright_IdeasPlannerContext context)
                {
                    _context = context;
                }
            [HttpGet]
            [Route("Bright_Ideas")]
            
            public IActionResult Bright_Ideas()
            {
                if(HttpContext.Session.GetInt32("user_id") == null)
                {
                    return RedirectToAction("Index","Home");
                }
                List<Post> listOfPosts = _context.Post
                .Include(p => p.User)
                .Include(l => l.LikeList)
                .OrderByDescending(z => z.LikeList.Count)
                .ToList(); 
                ViewBag.listOfPosts = listOfPosts;
                ViewData["Result"] = TempData["Result"];
                ViewData["user_id"] = (int)HttpContext.Session.GetInt32("user_id");
                ViewData["FirstName"] = HttpContext.Session.GetString("Name");
                return View();
            }
            [HttpPost]
            [Route("postidea")]
            public IActionResult postidea(string postdata)
            {
                if(HttpContext.Session.GetInt32("user_id") == null)
                {
                    return RedirectToAction("Index","Home");
                }
                if(postdata == null)
                {
                    TempData["Result"] = "Post has to contain some value";
                }
                else 
                {
                     Post aPost = new Post{
                        Idea = postdata,
                        UserId = (int)HttpContext.Session.GetInt32("user_id"),
                        created_at = DateTime.Now 
                     };
                     _context.Add(aPost);
                     _context.SaveChanges();
                     
                }
                return RedirectToAction("Bright_Ideas");
            }
            [HttpGet]
            [Route("users/{user_id}")]
            public IActionResult individualuser(int user_id)
            {
                if(HttpContext.Session.GetInt32("user_id") == null)
                {
                    return RedirectToAction("Index","Home");
                }
                User myUser =_context.User
                .Include(p => p.ListPosts)
                .Include(l => l.LikeList)
                .SingleOrDefault(u => u.UserId == user_id);
                ViewBag.myUser = myUser; 
                return View();
            }
            [HttpGet]
            [Route("like/{post_id}")]
            public IActionResult likeapost(int post_id)
            {
                Like aLike = new Like{
                    PostId = post_id,
                    UserId = (int)HttpContext.Session.GetInt32("user_id"),
                    created_at = DateTime.Now
                };
                _context.Add(aLike);
                _context.SaveChanges();
                return RedirectToAction("Bright_Ideas");
            }
            [HttpGet]
            [Route("Bright_Ideas/{a_post_id}")]
            public IActionResult individualbrightidea(int a_post_id)
            {
                Post aPost = _context.Post.SingleOrDefault(post => post.PostId == a_post_id);
                ViewBag.aPost = aPost;
                // List<Like>likeList = _context.Like 
                // .Include(l => l.User)
                // .Where(p => p.PostId == post_id)
                // .ToList();
                // ViewBag.likeList = likeList;
                List<User> listOfUser = _context.User
                .Include(user => user.LikeList)
                .ToList();
                ViewBag.listOfUser = listOfUser;
                return View();
            }
            [HttpGet]
            [Route("delete/{delete_post_id}")]
            public IActionResult delete(int delete_post_id)
            {
                Post deletePost = _context.Post.SingleOrDefault(p => p.PostId == delete_post_id);
                _context.Remove(deletePost);
                _context.SaveChanges();
                return RedirectToAction("Bright_Ideas");
            }
        }
    }