using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstMvcApp.Data;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Controllers
{
    // [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db, ILogger<CategoryController> logger)
        {
            _db = db;
            _logger = logger; 
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name.ToLower()==obj.DisplayOrder.ToString()){
                ModelState.AddModelError("Name", "The Display order cannot exactly match the name");
            }
            
            if(obj.Name.ToLower() =="test"){
                ModelState.AddModelError("Name", "'Test' is an invalid value");
            }

            if(ModelState.IsValid){
                _db.Categories.Add(obj);
                _db.SaveChanges();
                
                return RedirectToAction("Index","Category");
            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id ==id);
            if(categoryFromDb == null){
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name.ToLower()==obj.DisplayOrder.ToString()){
                ModelState.AddModelError("Name", "The Display order cannot exactly match the name");
            }
            
            if(obj.Name.ToLower() =="test"){
                ModelState.AddModelError("Name", "'Test' is an invalid value");
            }

            if(ModelState.IsValid){
                // _db.Categories.Add(obj);
                _db.Categories.Update(obj);
                _db.SaveChanges();
                
                return RedirectToAction("Index","Category");
            }
            return View(obj);
            
        }

        public IActionResult Delete(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id ==id);
            if(categoryFromDb == null){
                return NotFound();
            }
            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}