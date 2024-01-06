using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstTodoApp.Data;
using MyFirstTodoApp.Models;

namespace MyFirstTodoApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;


    public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Fetch list of tasks from DB
        List<Todo> objTodoList = _db.Todos.ToList();
        // Return list to view
        return View(objTodoList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Todo obj)
    {
        if(ModelState.IsValid){
            _db.Todos.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Edit(int? id)
    {
        if(id==null || id==0)
        {
            return NotFound();
        }

        Todo? todoFromDb = _db.Todos.FirstOrDefault(u => u.Id == id);
        if(todoFromDb == null){
            return NotFound();
        }
        return View(todoFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Todo obj)
    {
        if(ModelState.IsValid){
            _db.Todos.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(obj);
    }

     public IActionResult Delete(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Todo? categoryFromDb = _db.Todos.FirstOrDefault(u=>u.Id ==id);
            if(categoryFromDb == null){
                return NotFound();
            }
            _db.Todos.Remove(categoryFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
