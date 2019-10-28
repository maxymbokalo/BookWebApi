using System;
using System.Collections.Generic;
using System.Linq;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.EntityFrameworkCore.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly WebApiBookDbContext _db;

        public AuthorRepository(WebApiBookDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Author> GetAllBookAuthors()
        {
            var authors = from author in _db.Authors
                select author;

            return authors.ToList();
        }

        public Author GetBookAuthor(int? id)
        {
            if(id<0)
                throw new ArgumentException("Id was enter incorrect");

                return _db.Authors.SingleOrDefault(author => author.Id == id);
        }

        public void AddBookAuthor(Author author)
        {
            try
            {
                if (author != null)
                {
                    _db.Authors.Add(author);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void UpdateBookAuthor(Author author,int? authorId)
        {
            if (authorId < 0)
                throw new ArgumentException("Id was enter incorrect");

            var updatedAuthor = _db.Authors.SingleOrDefault(a => a.Id == authorId);
            if (updatedAuthor != null)
            {
                updatedAuthor.IsDeleted = author.IsDeleted;
                updatedAuthor.FirstName = author.FirstName;
                updatedAuthor.LastName = author.LastName;
            }
            else throw new ArgumentNullException("Author was not found");

            _db.Authors.Update(updatedAuthor);
        }



        public void DeleteBookAuthor(int? id)
        {
            if (id < 0)
                throw new ArgumentException("Id was enter incorrect");
            try
            {
                var deletedAuthor = _db.Authors.SingleOrDefault(a => a.Id == id);
                if(deletedAuthor!=null)
                    _db.Authors.Remove(deletedAuthor);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}