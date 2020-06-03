using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using RazorBookList.Model;

namespace RazorBookList.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] // it is automatically provides book propertys on post method
        public Book Book { get; set; }
        public void OnGet() //get handeler
        {

        }
       
        public async Task<IActionResult> OnPost()//post handler
        {
            //server side validation
            if (ModelState.IsValid) //it will check all property conditions
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync(); //data will push to db
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
