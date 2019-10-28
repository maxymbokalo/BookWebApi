using System;
using System.Collections.Generic;
using System.Text;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using FluentValidation;

namespace BookWebApi.DataAccess.Validation
{
    public class AuthorValidationRules : AbstractValidator<Author>,IAuthorValidationRules
    {
        public AuthorValidationRules()
        {
            RuleFor(author => author.Id).NotNull();
            RuleFor(author => author.FirstName).Length(0, 30).NotNull().WithMessage("Please enter firstName");
            RuleFor(author => author.LastName).Length(0, 30).NotNull().WithMessage("Please enter lastName");
            RuleFor(author => author.BookId).NotNull().WithMessage("Please enter bookId");
        }
    }
}