using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.DataAccess.Mapping;
using BookWebApi.DataAccess.Services;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using BookWebApi.UnitTests.Builders;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BookWebApi.UnitTests
{
    public class AuthorServiceTests
    {
        private readonly AuthorService service;
        public AuthorServiceTests()
        {
            // Build Author 
            Author author = new AuthorBuilder()
                .WithId(1)
                .WithName("Hello", "World")
                .WithBookId(1)
                .Build();

            // Build Author list
            IEnumerable<Author> authorsList = new List<Author> { author };

            // Build Author service
            service = new AuthorServiceBuilder()
                .WithRepositoryMock(authorsList,author)
                .Build();
        }
        [Fact]
        public void CreateAuthor_WithValidParameters_SholdNotTrowAnyExceptions()
        {
            // Arrange
            var Author = new Author
            {
                Id = 1,
                FirstName = "Hello",
                LastName = "World",
                BookId = 2
            };

            // Act
            Action comparison = () => { service.AddBookAuthor(Author); };

            // Assert
            comparison.Should().NotThrow();
        }

        [Fact]
        public void GetAuthor_WithValidParameters_SholdNotTrowAnyExceptions()
        {
            // Arrange

            // Act
            Action comparison = () => { service.GetBookAuthor(1); };

            // Assert
            comparison.Should().NotThrow();
        }

        [Fact]
        public void GetAuthor_WithValidParameters_ShouldNotBeNull()
        {
            // Arrange

            // Act
            IEnumerable<AuthorDto> devices = service.GetAllBookAuthors();

            // Assert
            devices.Should().NotBeNull();
        }

        [Fact]
        public void GetAllAuthors_SholdNotTrowAnyExceptions()
        {
            // Arrange

            // Act
            Action comparison = () => { service.GetAllBookAuthors(); };

            // Assert
            comparison.Should().NotThrow();
        }
        [Fact]
        public void GetAllAuthor_SholdNotBeNull()
        {
            // Arrange

            // Act
            Action comparison = () => { service.GetAllBookAuthors(); };

            // Assert
            comparison.Should().NotBeNull();
        }

    }

}
