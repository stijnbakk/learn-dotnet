using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyFirstRazorApp.Data;
using MyFirstRazorApp.Models;

namespace MyFirstRazorApp.Pages.categories
{
    public class edit : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category? Category { get; set; }


        public edit(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if(id != null || id != 0)
            {
                Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            }
            
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return NotFound();
        }
    }
}