using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (IsISBN(query))
            {
                return bookRepository.GetAllByISBN(query);
            }

            return bookRepository.GetAllByTitleOrAuthor(query);
        }

        internal static bool IsISBN(string checkedStr)
        {
            if (checkedStr is null)
            {
                return false;
            }


            checkedStr = checkedStr.Replace("-", "")
                                   .Replace(" ", "")
                                   .ToUpper();

            return Regex.IsMatch(checkedStr, "^ISBN\\d{10}(\\d{3})?$");
        }
    }
}
