using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.EntityFrameworkCore.Models
{
    public class Author
    {
        public bool IsDeleted { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
    }
}