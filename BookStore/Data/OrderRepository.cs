using BookStore.Domain;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new List<Order>();
        public Order Create()
        {
            int nextID = orders.Count + 1;
            var order = new Order(nextID, new OrderItem[0]);

            orders.Add(order);

            return order;
        }

        public Order GetByID(int id)
        {
            return orders.Single(order => order.ID == id);
        }

        public void Update(Order order)
        {
            
        }
    }
}
