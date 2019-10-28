using System.Collections.Generic;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.EntityFrameworkCore.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int? id);
        void AddBook(Book item);
        void UpdateBook(Book item, int? bookId);
        void DeleteBook(int? id);
    }
}