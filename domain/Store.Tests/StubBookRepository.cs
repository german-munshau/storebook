using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    class StubBookRepository : IBookRepository
    {
        public Book[] ResulOfGetAllByIsbn {get; set;}

        public Book[] ResulOfGetAllByAuthor { get; set; }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            throw new NotImplementedException();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResulOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return ResulOfGetAllByAuthor;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
