using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyFirstRazorApp.Data;
using MyFirstRazorApp.Models;

namespace MyFirstRazorApp.Pages
{
    public class Categories : PageModel
    {
        private readonly ApplicationDbContext _db;

        public List<Category>? CategoryList { get; set; }

        public Categories(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}