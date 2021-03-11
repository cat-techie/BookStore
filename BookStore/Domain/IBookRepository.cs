using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookRepository
    {
        Book[] GetAllByISBN(string isbn);
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
        Book GetById(int id);
        Book[] GetAllByIDs(IEnumerable<int> bookIDs);
        Book[] GetAllBooks();
    }
}
