using System;
using System.Linq;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.DataAccess.Validation;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using FluentValidation;

namespace BookWebApi.DataAccess.Services
{
    public class BookValidator : IBookValidator
    {
        private IBookRepository repository { get; }
        private readonly IBookValidationRules bookValidationRules;

        public BookValidator(IBookRepository repo, IBookValidationRules bookValidation)
        {
            repository = repo;
            bookValidationRules = bookValidation;
        }

        public bool IsBookExist(Book model)
        {
            return repository.GetAllBooks().Any(a => a.Title == model.Title);
 
        }

        public bool BookNotFound(Book model)
        {
            return model == null;
        }

        public IBookValidator ValidateBookId(int? bookId)
        {
            if (bookId.HasValue)
            {
                throw new ValidationException("Please enter author id");
            }

            return this;
        }

        public IBookValidator Validate(Book model)
        {
            var validationResult = bookValidationRules.Validate(model);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (IsBookExist(model))
            {
                throw new InvalidOperationException("Book is already exists");
            }

            if (BookNotFound(model))
                throw new ArgumentNullException();

            return this;
        }
    }
}