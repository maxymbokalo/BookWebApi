using System;
using System.Collections.Generic;
using BookWebApi.DataAccess.DTO;
using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.DataAccess.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllBookAuthors();
        AuthorDto GetBookAuthor(int? id);
        void AddBookAuthor(Author item);
        void UpdateBookAuthor(Author item, int? authorId);
        void DeleteBookAuthor(int? authorId);
    }
}