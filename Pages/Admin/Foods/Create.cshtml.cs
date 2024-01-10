using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.Foods
{

    public class CreateModel : PageModel
    {
        public readonly ApplicationDBContext _db;
        //This binds all properties used in EF models
        [BindProperty]
        public FoodType FoodType { get; set; }

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;            
        }
        public void OnGet()
        {
        }
               
        public async Task<IActionResult> OnPost()
        {
            //Adding Custom Error Message to Model State
            
            if(ModelState.IsValid)
            {
                await _db.FoodType.AddAsync(FoodType);
                await _db.SaveChangesAsync();
                TempData["success"] = "Food Type Created successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
