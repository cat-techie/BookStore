using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public int OrderID { get; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart(int orderID)
        {
            OrderID = orderID;
            TotalCount = 0;
            TotalPrice = 0m;
        }
    }
}
