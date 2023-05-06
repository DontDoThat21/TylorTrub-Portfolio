using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TylorBookStoreRazor_Temp.Data;
using TylorBookStoreRazor_Temp.Models;

namespace TylorBookStoreRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly BookStoreDBContext _bookstore;
        public Category Category { get; set; }

        public CreateModel(BookStoreDBContext bookstore)
        {
            _bookstore = bookstore;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _bookstore.Categories.Add(Category);
            _bookstore.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
