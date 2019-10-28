using System;
using System.Collections.Generic;
using AutoMapper;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.DataAccess.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IBookValidator bookValidator;
        private readonly IBookRepository repository;

        public BookService(IMapper map, IBookValidator validator, IBookRepository repo)
        {
            mapper = map;
            bookValidator = validator;
            repository = repo;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books =
                mapper.Map<IEnumerable<Book>, List<BookDto>>(repository.GetAllBooks());
            return books;
        }

        public BookDto GetBook(int? id)
        {
            bookValidator.ValidateBookId(id);
            var book = mapper.Map<BookDto>(repository.GetBook(id));
            return book;
        }

        public void AddBook(Book item)
        {
            bookValidator.Validate(item);
            repository.AddBook(item);
        }

        public void UpdateBook(Book item, int? bookId)
        {
            bookValidator
                .Validate(item)
                .ValidateBookId(bookId);

            var author = repository.GetBook(bookId);

            if (bookValidator.BookNotFound(author))
            {
                throw new NullReferenceException();
            }

            repository.UpdateBook(item,bookId);
        }

        public void DeleteBook(int? id)
        {
            bookValidator.ValidateBookId(id);
            repository.DeleteBook(id);
        }
    }
}