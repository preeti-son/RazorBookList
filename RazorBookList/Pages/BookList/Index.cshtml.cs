using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBookList.Model;
// we can extract application db context i.e inside dependancy container and injected on to page 
//if it is not presrnt then create oject and then dispose it 
namespace RazorBookList.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)//getting using dependancy injection
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task<IActionResult> OnPostDelete(int id)  // coz we are directing to same page
        {
            var book = await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();//Async: let u run mutiple task at a time util it is awaited

        }

       

    }
}