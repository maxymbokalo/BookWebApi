using System;
using System.Collections.Generic;
using BookWebApi.DataAccess.DTO;
using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.DataAccess.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        BookDto GetBook(int? id);
        void AddBook(Book item);
        void UpdateBook(Book item, int? bookId);
        void DeleteBook(int? id);
    }
}