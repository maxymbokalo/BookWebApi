using BookWebApi.DataAccess.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using FluentValidation;

namespace BookWebApi.DataAccess.Validation
{
    public class BookValidationRules : AbstractValidator<Book>,IBookValidationRules
    {
        public BookValidationRules()
        {
            RuleFor(book => book.Id).NotNull();
            RuleFor(book => book.Title).Length(0, 30).NotNull().WithMessage("Enter title");
            RuleFor(book => book.YearOfPublish).InclusiveBetween(0, 2025).NotNull().WithMessage("Enter yearOfPublish");
        }
    }
}