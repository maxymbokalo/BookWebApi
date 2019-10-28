using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.EntityFrameworkCore.Models
{
    public class Book
    {
        public bool IsDeleted { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfPublish { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
