using System;
using System.Linq;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.DataAccess.Validation;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using FluentValidation;


namespace BookWebApi.DataAccess.Services
{
    public class AuthorValidator : IAuthorValidator
    {
        private IAuthorRepository repository { get; }
        private readonly IAuthorValidationRules authorValidationRules;

        public AuthorValidator(IAuthorRepository repo, IAuthorValidationRules authorValidation)
        {
            repository = repo;
            authorValidationRules = authorValidation;
        }

        public bool IsAuthorExist(Author model)
        {
            return repository.GetAllBookAuthors().Any(a => a.FirstName == model.FirstName && a.LastName == model.LastName);


        }

        public bool AuthorNotFound(Author model)
        {
            return model == null;
        }

        public IAuthorValidator ValidateAuthorId(int? authorId)
        {
            if (!authorId.HasValue)
            {
                throw new ValidationException("Please enter author id");
            }

            return this;
        }

        public IAuthorValidator Validate(Author model)
        {
            var validationResult = authorValidationRules.Validate(model);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (IsAuthorExist(model))
            {
                throw new InvalidOperationException("Author is already exists");
            }

            if(AuthorNotFound(model))
                throw new ArgumentNullException();

            return this;
        }
    }
}