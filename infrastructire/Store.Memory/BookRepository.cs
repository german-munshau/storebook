﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12345-25341", "D. Knuth", "Art of Programming","lorem apsum lorem apsum lorem apsum lorem apsum lorem apsum ",7.19m),
            new Book(2, "ISBN 12345-25342", "M. Fowler", "Refactoring","lorem apsum lorem apsum lorem apsum lorem apsum lorem apsum ",2.19m),
            new Book(3,"ISBN 12345-25343", "B. Kernigan", "C Programming Language","lorem apsum lorem apsum lorem apsum lorem apsum lorem apsum ",10.19m)
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.ToLower().Contains(query.ToLower()) || book.Author.ToLower().Contains(query.ToLower())).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
