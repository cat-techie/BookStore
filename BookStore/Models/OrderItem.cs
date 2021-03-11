using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class OrderItem
    {
        public int BookID { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public OrderItem(int bookID, int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");

            BookID = bookID;
            Count = count;
            Price = price;
        }
    }
}
