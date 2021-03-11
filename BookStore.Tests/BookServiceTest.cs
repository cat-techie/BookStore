using BookStore.Domain;
using BookStore.Models;
using Moq;
using System;
using Xunit;

namespace BookStore.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void IsISBN_WithNull_ReturnFalse()
        {
            bool actual = BookService.IsISBN(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsISBN_WithBlankWtring_ReturnFalse()
        {
            bool actual = BookService.IsISBN("    ");

            Assert.False(actual);
        }

        [Fact]
        public void IsISBN_WithInvalidISBN_ReturnFalse()
        {
            bool actual = BookService.IsISBN("ISBN 123123");

            Assert.False(actual);
        }

        [Fact]
        public void IsISBN_WithISBN10_ReturnTrue()
        {
            bool actual = BookService.IsISBN("IsBn 123-456-891 7");

            Assert.True(actual);
        }

        [Fact]
        public void IsISBN_WithISBN13_ReturnTrue()
        {
            bool actual = BookService.IsISBN("IsBn 123-4567-891 069");

            Assert.True(actual);
        }

        [Fact]
        public void IsISBN_WithTrashStart_ReturnFalse()
        {
            bool actual = BookService.IsISBN("Buba 123-456-891 69 ayaya");

            Assert.False(actual);
        }

        [Fact]
        public void GetAllByQuery_WithISBN_CallGetAllByISBN()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByISBN(It.IsAny<string>()))
                              .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            BookService bookService = new BookService(bookRepositoryStub.Object);
            var validISBN = "ISBN 12345-67890";
            
            var actual = bookService.GetAllByQuery(validISBN);

            Assert.Collection(actual, book => Assert.Equal(1, book.ID));
        }

        [Fact]
        public void GetAllByQuery_WithAuthorOrTitle_GetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByISBN(It.IsAny<string>()))
                              .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            BookService bookService = new BookService(bookRepositoryStub.Object);
            var invalidISBN = "12345-67890";

            var actual = bookService.GetAllByQuery(invalidISBN);

            Assert.Collection(actual, book => Assert.Equal(2, book.ID));
        }
    }
}
