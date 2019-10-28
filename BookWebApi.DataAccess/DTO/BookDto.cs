using System.Collections.Generic;
using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.DataAccess.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfPublish { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}