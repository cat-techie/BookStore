using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming", "D. Knuth", "ISBN 12312-31231"),
            new Book(2, "Refactoring", "M. Fowler", "ISBN 12313-31232"),
            new Book(3, "C Programming Language", "B. Kernighan", "ISBN 12314-31233")
        };

        public Book[] GetAllByISBN(string isbn)
        {
            return books.Where(book => book.ISBN == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titleOrAuthor) ||
                                       book.Author.Contains(titleOrAuthor))
                               .ToArray();
        }


    }
}
