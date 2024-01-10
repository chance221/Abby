using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.DataAccess.Repository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.Categories
{
    //Binds all properteis used in EF models
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        
        public void OnGet( int id )
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
        }

        
        public async Task<IActionResult> OnPost()
        {
                      
            var categoryFoundFromDb = _unitOfWork.Category.GetFirstOrDefault(t => t.Id == Category.Id);
            if(categoryFoundFromDb != null )
            {
                //The remove needs the full object from the db. 
                _unitOfWork.Category.Remove(categoryFoundFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToPage("Index");
            }
                
            return Page();
        }
    }
}
