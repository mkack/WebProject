using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        
        public BookRepository(BookContext context) 
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book Get(Guid id) => _context.Books.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Book> GetBooks() => _context.Books.ToList();

        public void Remove(Guid id)
        {
            var book = Get(id);

            if (book == null)
                throw new ArgumentNullException("Book not found");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void Update(Guid id, Book book)
        {
            /*var bookToUpdate = _context.Books.SingleOrDefault(x => x.Id == id);

            if (bookToUpdate == null)
                throw new ArgumentNullException("Book not found");
*/
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
