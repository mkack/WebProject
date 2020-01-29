using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Repository
{
    public interface IBookRepository
    {
        Book Get(Guid Id);

        Book GetAsNoTracking(Guid id);

        Book GetByTitle(string title);

        IEnumerable<Book> GetBooks();

        void Add(Book book);

        void Remove(Guid id);

        void Update(Guid id, Book book);
    }
}
