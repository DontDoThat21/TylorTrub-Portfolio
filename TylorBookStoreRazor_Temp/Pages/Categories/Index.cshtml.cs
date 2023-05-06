using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TylorBookStoreRazor_Temp.Data;
using TylorBookStoreRazor_Temp.Models;

namespace TylorBookStoreRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly BookStoreDBContext _bookstore;
        public List<Category> CategoryList { get; set; }

        public IndexModel(BookStoreDBContext bookstore)
        {
            _bookstore = bookstore;
        }

        public void OnGet()
        {
            CategoryList = _bookstore.Categories.ToList();
        }
    }
}
