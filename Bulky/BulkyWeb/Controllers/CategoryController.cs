using Bulky.DataAccess.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    public readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        var objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        /*if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name","The Display Order cannot exactly match the Name.");
        }

        if (obj.Name.ToLower( )== "test")
        {
            ModelState.AddModelError("","Test is an invalid value");
        }*/
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully"; 
            return RedirectToAction("Index");
        }

        return View();
    }
    
    public IActionResult Edit(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }

        Category categoryToDb = _db.Categories.Find(id);
        if (categoryToDb == null)
        {
            return NotFound();
        }
        return View(categoryToDb);
        
    }
    
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category update successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }

        var category = _db.Categories.Find(id);
        if (category != null)
        {
            return View(category);
        }
        
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Delete(Category obj) 
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index");
        }

        return View();
    }
}