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
    }
}
