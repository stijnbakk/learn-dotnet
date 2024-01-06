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
    public class delete : PageModel
    {

        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public delete(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            if(id==null || id == 0 ){
                return NotFound();
            }
            Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");

        //     public IActionResult Delete(int? id)
        // {
        //     if(id==null || id==0)
        //     {
        //         return NotFound();
        //     }
        //     Category? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id ==id);
        //     if(categoryFromDb == null){
        //         return NotFound();
        //     }
        //     _db.Categories.Remove(categoryFromDb);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index", "Category");
        // }

        }
    }
}