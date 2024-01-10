using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.Foods
{
    //Binds all properteis used in EF models
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly ApplicationDBContext _db;
        
        public FoodType FoodType { get; set; }

        public EditModel(ApplicationDBContext db)
        {
            _db = db;            
        }
        public void OnGet( int id )
        {
            FoodType = _db.FoodType.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
           
            if(ModelState.IsValid)
            {
                _db.FoodType.Update(FoodType);
                await _db.SaveChangesAsync();
                TempData["success"] = "Food Type Edited Successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
