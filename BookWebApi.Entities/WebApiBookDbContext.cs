using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BookWebApi.EntityFrameworkCore.Configuration;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.EntityFrameworkCore
{
    public class WebApiBookDbContext : DbContext
    {
        private readonly IDbInitializer _dbInitializer;

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public WebApiBookDbContext(DbContextOptions options, IDbInitializer dbInitializer)
            :base(options)
        {
            _dbInitializer = dbInitializer;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            _dbInitializer.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
           
        }
        
    }
}
