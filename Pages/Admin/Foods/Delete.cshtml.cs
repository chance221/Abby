using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.Foods
{
    //Binds all properteis used in EF models
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly IUnitOfWork _unitOfWork;
        
        public FoodType FoodType { get; set; }

        public DeleteModel(IUnitOfWork db)
        {
            _unitOfWork = db;            
        }
        public void OnGet( int id )
        {
            FoodType = _unitOfWork.FoodType
                .GetFirstOrDefault(f => f.Id == id);
        }
                
        public async Task<IActionResult> OnPost()
        {  
            var foodFoundFromDb = _unitOfWork.FoodType
                .GetFirstOrDefault(f => f.Id == FoodType.Id);

            if (foodFoundFromDb != null )
            {
                _unitOfWork.FoodType
                    .Remove(foodFoundFromDb);

                _unitOfWork
                    .Save();

                TempData["success"] = "Food Type Deleted successfully";
                
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
