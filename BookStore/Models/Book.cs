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
        public string Author { get; }
        public string ISBN { get; }
        public string Description { get; }
        public decimal Price { get; }

        public Book(int id, string title, string author, string isbn, string description, decimal price)
        {
            ID = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            Description = description;
            Price = price;
        }
    }
}
