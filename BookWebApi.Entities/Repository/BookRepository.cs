using System;
using System.Collections.Generic;
using System.Linq;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookWebApi.EntityFrameworkCore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly WebApiBookDbContext _db;

        public BookRepository(WebApiBookDbContext context)
        {
            _db = context;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            var books = _db.Books
                .Include(book => book.Authors)
                .ToList();

            return books;
        }

        public Book GetBook(int? id)
        {
            if (id < 0)
                throw new ArgumentException("Id was enter incorrect");
 
                var bookResult =_db.Books.Include(book => book.Authors).SingleOrDefault(book => book.Id == id);
                return bookResult;

        }


        public void AddBook(Book book)
        {
            try
            {
                _db.Books.Add(book);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public void UpdateBook(Book book,int? bookId)
        {
            if (bookId < 0)
                throw new ArgumentException("Id was enter incorrect");
            var updatedBook = _db.Books.SingleOrDefault(b => b.Id == bookId);
            if (updatedBook != null)
            {
                updatedBook.IsDeleted = book.IsDeleted;
                updatedBook.Title = book.Title;
                updatedBook.YearOfPublish = book.YearOfPublish;
            }
            else throw new ArgumentNullException("Book was not found");

            _db.Books.Update(updatedBook);
        }

        public void DeleteBook(int? id)
        {
            if (id < 0)
                throw new ArgumentException("Id was enter incorrect");
            var book = _db.Books.SingleOrDefault(b => b.Id == id);

            if(book == null)
                throw new ArgumentNullException("Book was not found");
            _db.Books.Remove(book);

            
        }
    }
}