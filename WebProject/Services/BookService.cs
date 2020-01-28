using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.DTO;
using WebProject.Models;
using WebProject.Repository;

namespace WebProject.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void Add(BookDTO book)
        {
            var mappedBook = _mapper.Map<BookDTO, Book>(book);
            _bookRepository.Add(mappedBook);
        }

        public BookDTO Get(Guid id)
        {
            var book = _bookRepository.Get(id);

            return _mapper.Map<Book, BookDTO>(book);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var books = _bookRepository.GetBooks();

            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
        }

        public void Remove(Guid id)
        {
            _bookRepository.Remove(id);
        }

        public void Update(Guid id, BookDTO book)
        {
            _bookRepository.Update(id, _mapper.Map<BookDTO, Book>(book));
        }
    }
}
