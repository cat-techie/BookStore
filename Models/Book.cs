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

        public Book(string title)
        {
            Title = title;
        }
    }
}
