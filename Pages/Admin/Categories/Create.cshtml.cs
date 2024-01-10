using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.Categories
{

    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(IUnitOfWork db)
        {
            _unitOfWork = db;            
        }
        public void OnGet()
        {
        }

        
        //Can do this with the bind property tag in razor pages.
        //Usually have to paSS IN
        public async Task<IActionResult> OnPost()
        {
            //Adding Custom Error Message to Model State
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "Custom Error Message Goes Here");
            }
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Add(Category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
