using BookStore.Data;
using BookStore.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookStore.Tests
{
    public class OrderTest
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculatesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }

        [Fact]
        public void OrderAddItem_WithNullBook_ThrowsArgumentNullException()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Throws<ArgumentNullException>(() => order.AddItem(null, 4));
        }

/*        [Fact]
        public void OrderAddItem_WithNewItem_AddItemInOrder()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1, 3, 10m),
            });

            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetById(It.IsAny<int>()))
                  .Returns(new Book(9, "", "", "", "", 111m));

            Book book = (Book)bookRepositoryStub.Object;

            order.AddItem(book, 3);

            OrderItem orderItem = order.Items.Count;

        }*/
    }
}
