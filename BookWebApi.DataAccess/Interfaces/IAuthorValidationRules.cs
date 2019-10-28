using BookWebApi.EntityFrameworkCore.Models;
using FluentValidation.Results;

namespace BookWebApi.DataAccess.Interfaces
{
    public interface IAuthorValidationRules
    {
        ValidationResult Validate(Author instance);
    }
}