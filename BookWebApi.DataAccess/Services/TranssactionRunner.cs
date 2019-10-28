using System;
using System.Data.SqlClient;
using BookWebApi.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.DataAccess.Services
{
    public class TranssactionRunner : IActionFilter
    {
        private readonly WebApiBookDbContext _dbContext;

        public TranssactionRunner(WebApiBookDbContext context)
        {
            _dbContext = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
                _dbContext.SaveChanges();
                Console.WriteLine("~DbSaveChange~");
            
        }
    }
}