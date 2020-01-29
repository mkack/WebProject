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

        public ValidationResultDTO Add(BookDTO book)
        {
            var bookInRepo = _bookRepository.GetByTitle(book.Title);
            if (bookInRepo != null)
            {
                return new ValidationResultDTO
                {
                    IsSuccess = false,
                    Message = $"Book with title: {book.Title} already exist.",
                };
            } 

            var mappedBook = _mapper.Map<BookDTO, Book>(book);
            _bookRepository.Add(mappedBook);

            return new ValidationResultDTO
            {
                IsSuccess = true,
                Message = $"Book {book.Author} {book.Title} successfully added.",
            };
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

        public ValidationResultDTO Remove(Guid id)
        {
            var bookInRepo = _bookRepository.GetAsNoTracking(id);

            if (bookInRepo == null)
            {
                return new ValidationResultDTO
                {
                    IsSuccess = false,
                    Message = $"Book not exist.",
                };
            }

            _bookRepository.Remove(id);

            return new ValidationResultDTO
            {
                IsSuccess = true,
                Message = $"Book successfully removed.",
            };
        }

        public ValidationResultDTO Update(Guid id, BookDTO book)
        {
            var existingTitle = _bookRepository.GetByTitle(book.Title);

            if (existingTitle != null && existingTitle.Id != id)
            {
                return new ValidationResultDTO
                {
                    IsSuccess = false,
                    Message = $"Book with title {book.Title} already exists in db.",
                };
            }

            var bookInRepo = _bookRepository.GetAsNoTracking(id);
                        
            if (bookInRepo.Author == book.Author &&
                bookInRepo.Title == book.Title &&
                bookInRepo.Descrtiption == book.Descrtiption &&
                bookInRepo.BookType == book.BookType)
            {
                return new ValidationResultDTO
                {
                    IsSuccess = false,
                    Message = "Nothing to change."
                };
            }

            _bookRepository.Update(id, _mapper.Map<BookDTO, Book>(book));

            return new ValidationResultDTO
            {
                IsSuccess = true,
                Message = $"Book {book.Author} {book.Title} successfully updated.",
            };
        }
    }
}
