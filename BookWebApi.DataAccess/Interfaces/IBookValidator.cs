using System;
using BookWebApi.DataAccess.DTO;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.DataAccess.Interfaces
{
    public interface IBookValidator
    {
        bool IsBookExist(Book model);
        bool BookNotFound(Book model);
        IBookValidator ValidateBookId(int? authorId);
        IBookValidator Validate(Book model);
    }
}