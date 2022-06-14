using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // root route
    public IActionResult Index()
    {
        ViewBag.AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt);
        return View();
    }
    // *** create routes ***
    [HttpGet("new")]
    public IActionResult NewForm()
    {
        return View("new");
    }

    [HttpPost("dish/add")]
    public IActionResult AddDish(Dish newDish)
    {
        // Console.WriteLine(ModelState.IsValid);
        if(ModelState.IsValid)
        {
            // if passes validations, add to db
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else {
            return View("new");
        }
    }
    // *** read one route ***
    [HttpGet("dish/{DishId}")]
    public IActionResult OneDish(int DishId)
    {
        Dish oneDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        return View(oneDish);
    }
    // *** edit route ***
    [HttpGet("dish/edit/{DishId}")]
    public IActionResult EditDish(int DishId)
    {
        Dish dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        return View(dishToEdit);
    }
    [HttpPost("dish/update/{DishId}")]
    public IActionResult UpdateDish(int DishId, Dish newVersionOfDish)
    {
        if(ModelState.IsValid){
            Dish oldDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        oldDish.ChefName = newVersionOfDish.ChefName;
        oldDish.DishName = newVersionOfDish.DishName;
        oldDish.Calories = newVersionOfDish.Calories;
        oldDish.Tastiness = newVersionOfDish.Tastiness;
        oldDish.Description = newVersionOfDish.Description;
        oldDish.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else {
            return RedirectToAction("dish/edit/{DishId}");
        }

    }
    
    // *** delete route ***
    [HttpGet("dish/delete/{DishId}")]
    public IActionResult DeleteDish(int DishId)
    {
        Dish dishToDelete = _context.Dishes.SingleOrDefault(a => a.DishId == DishId);
        _context.Dishes.Remove(dishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
