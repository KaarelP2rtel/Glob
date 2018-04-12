using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Glob.Models;
using Glob.Data;
using HeyRed.MarkdownSharp;

namespace Glob.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {


            var md = new Markdown();


            var posts = _context.Posts.OrderByDescending(p => p.Date).ToList();
            foreach (var post in posts)
            {
                post.Content = md.Transform(post.Content);

            }

            return View(posts);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
