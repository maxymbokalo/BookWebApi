using System.Collections.Generic;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.EntityFrameworkCore.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllBookAuthors();
        Author GetBookAuthor(int? id);
        void AddBookAuthor(Author item);
        void UpdateBookAuthor(Author item,int? authorId);
        void DeleteBookAuthor(int? authorId);
    }
}