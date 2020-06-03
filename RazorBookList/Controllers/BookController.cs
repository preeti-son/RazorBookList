using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorBookList.Model;

namespace RazorBookList.Controllers
{
     [Route("api/book")]  //used to call controller API's
     [ApiController]   //API controller 
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll() //
        {
            return Json(new { data = _db.Book.ToList() });
        }
    }
}