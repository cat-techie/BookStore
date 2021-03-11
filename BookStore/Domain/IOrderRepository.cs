using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public interface IOrderRepository
    {
        Order Create();

        Order GetByID(int id);

        void Update(Order order);
    }
}
