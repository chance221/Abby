using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.Categories
{
    //Binds all properteis used in EF models
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }

        public EditModel(IUnitOfWork db)
        {
            _unitOfWork = db;            
        }
        public void OnGet( int id )
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u =>u.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            //Adding Custom Error Message to Model State
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "Custom Error Message Goes Here");
            }
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Update(Category);
                _unitOfWork.Save();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
