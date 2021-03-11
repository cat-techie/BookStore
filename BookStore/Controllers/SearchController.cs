using BookStore.Domain;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;

        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(string query)
        {
            if (query is null)
            {
                return Redirect("~/Home/Index");
            }

            var books = bookService.GetAllByQuery(query);

            return View(books);
        }
    }
}
