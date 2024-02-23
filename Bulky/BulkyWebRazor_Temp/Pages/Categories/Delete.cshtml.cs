using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            }
        }

        public IActionResult OnPost()
        {
            Category? category = _db.Categories.FirstOrDefault(u => u.CategoryId == Category.CategoryId);
            if (category == null)
            {
                return Page();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToPage("Index");

        }
    }
}
