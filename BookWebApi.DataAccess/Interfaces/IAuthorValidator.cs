using System;
using BookWebApi.DataAccess.DTO;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.DataAccess.Interfaces
{
    public interface IAuthorValidator
    {
        bool IsAuthorExist(Author model);
        bool AuthorNotFound(Author model);
        IAuthorValidator ValidateAuthorId(int? authorId);
        IAuthorValidator Validate(Author model);
    }
}