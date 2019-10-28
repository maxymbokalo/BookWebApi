using System;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.EntityFrameworkCore
{
    public class DbInitializer :IDbInitializer
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            InitializeDb(modelBuilder);
        }

        public void InitializeDb(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    IsDeleted = false,
                    Id = 1,
                    Title = "The Mahabharata Secret",
                    YearOfPublish = 2015,
                },
                new Book
                {
                    IsDeleted = false,
                    Id = 2,
                    Title = "The Alexander Secret: Book 1 of the Mahabharata Quest Series",
                    YearOfPublish = 2011,
                },
                new Book
                {
                    IsDeleted = false,
                    Id = 3,
                    Title = "The Mini Sequel to The Alexander Secret: A Secret Revealed ",
                    YearOfPublish = 2009,
                },
                new Book
                {
                    IsDeleted = false,
                    Id = 4,
                    Title = "The Secret of the Druids",
                    YearOfPublish = 2019,
                });

            modelBuilder.Entity<Author>().HasData(
                new
                {
                    IsDeleted = false,
                    Id = 1,
                    BookId = 2,
                    FirstName = "Daniel",
                    LastName = "Howard"
                },
                new
                {
                    IsDeleted = false,
                    Id = 2,
                    BookId = 2,
                    FirstName = "Rose",
                    LastName = "Smith"
                });
        }
    }
}
