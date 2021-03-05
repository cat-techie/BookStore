using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int ID { get; }
        public string Title { get; }

        public Book(int id, string title)
        {
            ID = id;
            Title = title;
        }
    }
}
