using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abby.Pages.Admin.MenuItems
{
    //This binds all properties used in EF models
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }


        public UpsertModel(IUnitOfWork db)
        {
            _unitOfWork = db;
            MenuItem = new MenuItem();

            
        }
        public void OnGet()
        {
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
               
        public async Task<IActionResult> OnPost()
        {
            //Adding Custom Error Message to Model State
            
            if(ModelState.IsValid)
            {
                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
                TempData["success"] = "Food Type Created successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
