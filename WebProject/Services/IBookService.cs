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

        ValidationResultDTO Add(BookDTO book);

        ValidationResultDTO Remove(Guid id);

        ValidationResultDTO Update(Guid id, BookDTO book);
    }
}
