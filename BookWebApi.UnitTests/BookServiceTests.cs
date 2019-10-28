using System;
using System.Collections.Generic;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Services;
using BookWebApi.EntityFrameworkCore.Models;
using BookWebApi.UnitTests.Builders;
using FluentAssertions;
using Xunit;

namespace BookWebApi.UnitTests
{
    public class BookServiceTests
    {
        private readonly BookService service;
        public BookServiceTests()
        {
            // Build Author 
            Book book = new BookBuilder()
                .WithId(1)
                .WithTitle("Hello")
                .WithYearOfPublish(2222)
                .Build();

            // Build Author list
            IEnumerable<Book> booksList = new List<Book> { book };

            // Build Author service
            service = new BookServiceBuilder()
                .WithRepositoryMock(booksList, book)
                .Build();
        }
        [Fact]
        public void CreateBook_WithValidParameters_SholdNotTrowAnyExceptions()
        {
            // Arrange
            var Book = new Book
            {
                Id = 1,
                Title = "QRQRQRQR",
                YearOfPublish = 2022
            };

            // Act
            Action comparison = () => { service.AddBook(Book); };

            // Assert
            comparison.Should().NotThrow();
        }

        [Fact]
        public void GetBook_WithValidParameters_SholdNotTrowAnyExceptions()
        {
            // Arrange

            // Act
            Action comparison = () => { service.GetBook(1); };

            // Assert
            comparison.Should().NotThrow();
        }

        [Fact]
        public void GetBook_WithValidParameters_ShouldNotBeNull()
        {
            // Arrange

            // Act
            IEnumerable<BookDto> devices = service.GetAllBooks();

            // Assert
            devices.Should().NotBeNull();
        }

        [Fact]
        public void GetAllBooks_SholdNotTrowAnyExceptions()
        {
            // Arrange

            // Act
            Action comparison = () => { service.GetAllBooks(); };

            // Assert
            comparison.Should().NotThrow();
        }
        [Fact]
        public void GetAllBooks_SholdNotBeNull()
        {
            // Arrange

            // Act
            Action comparison = () => { service.GetAllBooks(); };

            // Assert
            comparison.Should().NotBeNull();
        }
    }
}
