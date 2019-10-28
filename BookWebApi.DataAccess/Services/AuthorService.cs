using System;
using System.Collections.Generic;
using AutoMapper;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.DataAccess.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IMapper mapper;
        private readonly IAuthorValidator authorValidator;
        private readonly IAuthorRepository repository;

        public AuthorService(IMapper map, IAuthorValidator validator, IAuthorRepository repo)
        {
            mapper = map;
            authorValidator = validator;
            repository = repo;
        }

        public void AddBookAuthor(Author item)
        {
            authorValidator.Validate(item);
            repository.AddBookAuthor(item);
        }

        public void DeleteBookAuthor(int? authorId)
        {
            authorValidator.ValidateAuthorId(authorId);
            repository.DeleteBookAuthor(authorId);
        }

        public IEnumerable<AuthorDto> GetAllBookAuthors()
        {
            var authors =
                mapper.Map<IEnumerable<Author>, List<AuthorDto>>(repository.GetAllBookAuthors());
            return authors;
        }

        public AuthorDto GetBookAuthor(int? id)
        {
            authorValidator.ValidateAuthorId(id);
            var book = mapper.Map<AuthorDto>(repository.GetBookAuthor(id));
            return book;
        }

        public void UpdateBookAuthor(Author item, int? authorId)
        {
            authorValidator
                .Validate(item)
                .ValidateAuthorId(authorId);

            var author = repository.GetBookAuthor(authorId);

            if (authorValidator.AuthorNotFound(author))
            {
                throw new NullReferenceException();
            }

            repository.UpdateBookAuthor(item,authorId);

        }
    }
}