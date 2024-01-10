using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MenuItem> MenuItems { get; set; }
        
        public IndexModel(IUnitOfWork db)
        {
            _unitOfWork = db;        
        }
        
        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll();
        }
    }
}
