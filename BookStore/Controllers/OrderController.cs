using BookStore.Domain;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult AddItem(int id)
        {
            Order order;

            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                order = orderRepository.GetByID(cart.OrderID);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.ID);
            }

            var book = bookRepository.GetById(id);
            order.AddItem(book, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetByID(cart.OrderID);
                OrderModel model = Map(order);

                return View(model);
            }
            return View("Empty");
        }

        public OrderModel Map(Order order)
        {
            var bookIDs = order.Items.Select(item => item.BookID);
            var books = bookRepository.GetAllByIDs(bookIDs);
            var itemModels = from item in order.Items
                             join book in books on item.BookID equals book.ID
                             select new OrderItemModel
                             {
                                 BookID = book.ID,
                                 Title = book.Title,
                                 Author = book.Author,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                ID = order.ID,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }
    }
}

