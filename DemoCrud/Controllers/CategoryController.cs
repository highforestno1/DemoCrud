using DemoCrud.Data;
using DemoCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoCrud.Controllers
{
    public class CategoryController : Controller
    {

        public readonly FirstCrudContext _context;
        public CategoryController(FirstCrudContext context)
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

            List<Category> categories = _context.Categories.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(categories);
        }
        public IActionResult Details(long Id)
        {

            Category categories = _context.Categories.Where(p => p.Id == Id).FirstOrDefault();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Category Category = _context.Categories.Where(p => p.Id == id).FirstOrDefault();
            return View(Category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(long Id)
        {
            Category category = _context.Categories.Where(p => p.Id == Id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Attach(category);
            _context.Entry(category).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }

}
