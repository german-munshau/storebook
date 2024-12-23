﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        //[Fact]
        //public void GetAllByQuery_WithIsIsbn_CallsGetAllByIsbn()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();
        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
        //        .Returns(new[] { new Book(1, "", "", "","",0m) });

        //    bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
        //        .Returns(new[] { new Book(2, "", "", "","",0m) });

        //    var bookService = new BookService(bookRepositoryStub.Object);

        //    var validIsbn = "ISBN 12345-67890";

        //    var actual = bookService.GetAllByQuery(validIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(1, book.Id));


        //}

        //[Fact]
        //public void GetAllByQuery_WithAuthor_CallsGetAllByIsbn()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();
        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
        //        .Returns(new[] { new Book(1, "", "", "","",0m) });

        //    bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
        //        .Returns(new[] { new Book(2, "", "", "","",0m) });

        //    var bookService = new BookService(bookRepositoryStub.Object);

        //    var invalidIsbn = "xxxISBN 12345-67890";

        //    var actual = bookService.GetAllByQuery(invalidIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        //}

        [Fact]
        public void GetAllByQuery_WithIsIsbn_CallsGetAllByIsbn()
        {

            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;
            
            var bookRepository = new StubBookRepository();
            var bookService = new BookService(bookRepository);

            bookRepository.ResulOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "","","","",0m),
            };

            bookRepository.ResulOfGetAllByAuthor = new[]
            {
                new Book(idOfAuthorSearch, "","","","",0m),
            };

            var books = bookService.GetAllByQuery("ISBN 12345-6789-0");

            Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByIsbn()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;

            var bookRepository = new StubBookRepository();
            var bookService = new BookService(bookRepository);

            bookRepository.ResulOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "","","","",0m),
            };

            bookRepository.ResulOfGetAllByAuthor = new[]
            {
                new Book(idOfAuthorSearch, "","","","",0m),
            };

            var books = bookService.GetAllByQuery("xxxISBN 12345-6789-0");

            Assert.Collection(books, book => Assert.Equal(idOfAuthorSearch, book.Id));
        }

    }
}
