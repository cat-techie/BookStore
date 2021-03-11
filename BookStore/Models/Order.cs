using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    public class Order
    {
        public int ID { get; }

        private List<OrderItem> items;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }

        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }

        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price * item.Count); }
        }

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            ID = id;

            this.items = new List<OrderItem>(items);
        }

        public void AddItem(Book book, int count)
        {
            if (book is null)
                throw new ArgumentNullException(nameof(book));

            var item = items.SingleOrDefault(x => x.BookID == book.ID);

            if (item is null)
            {
                items.Add(new OrderItem(book.ID, count, book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.ID, item.Count + count, book.Price));
            }
        }
    }
}
