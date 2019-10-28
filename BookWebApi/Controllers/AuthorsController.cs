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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorServ)
        {
            authorService = authorServ;

        }

        [HttpGet("/books/authors")]
        public ActionResult<IEnumerable<JsonResult>> List()
        {
            var authors = authorService.GetAllBookAuthors();
            return Ok(authors);
        }

        [HttpGet("/books/authors/{authorId:int}")]
        public ActionResult<JsonResult> GetBookAuthor(int authorId)
        {
            var author = authorService.GetBookAuthor(authorId);
            return Ok(author);
        }


        [HttpPost("/books/createbookrequestmodel/authors")]
        public ActionResult<JsonResult> AddAuthor([FromBody] Author model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            authorService.AddBookAuthor(model);
             
            return Ok("Author succsesfully added");
        }

        [HttpPut("/books/updatebookrequestmodel/authors/{authorId:int}")]
        public ActionResult<JsonResult> UpdateAuthor([FromBody]Author model, int authorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            authorService.UpdateBookAuthor(model,authorId);

            return Ok($"Author with id={authorId}, was successfully updated ");
        }
        [HttpDelete("/books/authors/{authorId:int}")]
        public ActionResult<JsonResult> DeleteAuthor(int authorId)
        {
            authorService.DeleteBookAuthor(authorId);

            return NoContent();
        }
    }
}