using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);
    }
}
