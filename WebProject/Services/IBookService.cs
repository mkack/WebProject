using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.DTO;

namespace WebProject.Services
{
    public interface IBookService
    {
        BookDTO Get(Guid id);

        IEnumerable<BookDTO> GetBooks();

        void Add(BookDTO book);

        void Remove(Guid id);

        void Update(Guid id, BookDTO book);
    }
}
