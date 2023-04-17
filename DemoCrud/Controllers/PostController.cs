using DemoCrud.Data;
using DemoCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrud.Controllers
{
    public class PostController : Controller
    {
        public readonly FirstCrudContext _context;
        public PostController(FirstCrudContext context)
        {
            _context = context;
        }
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;

            if (pg < 1)
                pg = 1;

            int recsCount = _context.Categories.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            List<Post> posts = _context.Posts.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(posts);
        }
        public IActionResult Details(long Id)
        {

            Post posts = _context.Posts.Where(p => p.Id == Id).FirstOrDefault();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Post Posts = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            return View(Posts);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            _context.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

      
        [HttpGet]
        public IActionResult Delete(long Id)
        {
            Post post = _context.Posts.Where(p => p.Id == Id).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public IActionResult Delete(Post post)
        {
            _context.Attach(post);
            _context.Entry(post).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

       

        
    }
}
