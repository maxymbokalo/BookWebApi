using BookWebApi.EntityFrameworkCore.Models;
using FluentValidation.Results;

namespace BookWebApi.DataAccess.Interfaces
{
    public interface IBookValidationRules
    {
        ValidationResult Validate(Book instance);
    }
}