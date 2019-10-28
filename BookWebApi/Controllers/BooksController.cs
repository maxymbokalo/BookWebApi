using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;


        public BooksController(IBookService bookSrv)
        {
            bookService = bookSrv;
        }

        [HttpGet("/books")]
        public ActionResult<IEnumerable<JsonResult>> List()
        {
            var books = bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("/books/{id:int}")]
        public ActionResult<JsonResult> GetBook(int id)
        {
            var book = bookService.GetBook(id);

            return Ok(book);
        }

        [HttpPost("/books/createbookrequestmodel")]
        public ActionResult<JsonResult> AddBook([FromBody] Book model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bookService.AddBook(model);

            return Ok("Book succsesfully added");
        }

        [HttpPut("/books/updatebookrequestmodel/{id:int}")]
        public ActionResult<JsonResult> UpdateBook([FromBody]Book model,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            bookService.UpdateBook(model,id);

           return Ok($"Book with id={id}, was successfully updated! ");
        }

        [HttpDelete("/books/{id:int}")]
        public ActionResult<JsonResult> DeleteBook(int id)
        {
            bookService.DeleteBook(id);

            return NoContent();
        }
    }
}