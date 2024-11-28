using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12345-25341", "D. Knuth", "Art of Programming"),
            new Book(2, "ISBN 12345-25342", "M. Fowler", "Refactoring"),
            new Book(3,"ISBN 12345-25343", "B. Kernigan", "C Programming Language")
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.ToLower().Contains(query.ToLower()) || book.Author.ToLower().Contains(query.ToLower())).ToArray();
        }
    }
}
