using System;
using System.Collections.Generic;
using AutoMapper;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.DataAccess.Mapping;
using BookWebApi.DataAccess.Services;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;

namespace BookWebApi.UnitTests.Builders
{
    public class BookServiceBuilder
    {
        private readonly Mock<IBookRepository> mockRepository;
        private readonly MapperConfiguration mapperConfiguration;
        private readonly Mapper mapper;
        private Mock<IBookValidator> mockAuthorValidation;



        public BookServiceBuilder()
        {
            
            var mockRepositoryObject = new MockRepository(MockBehavior.Default);

            this.mockAuthorValidation = mockRepositoryObject.Create<IBookValidator>();
            mockRepository = mockRepositoryObject.Create<IBookRepository>();

            // Default automapper configuration
            mapperConfiguration = new MapperConfiguration(new MappingProfile());
            mapper = new Mapper(mapperConfiguration);
        }
        public BookServiceBuilder WithRepositoryMock(IEnumerable<Book> booksList, Book book)
        {
            // 'GetAll' repository mock
            this.mockRepository.Setup(x => x.GetAllBooks()).Returns(booksList.AsQueryable);


            // 'Get' repository mock
            this.mockRepository.Setup(x => x.GetBook(It.IsAny<int>())).Returns(book);

            // 'Update' repository mock
            this.mockRepository.Setup(x => x.UpdateBook(It.IsAny<Book>(), It.IsAny<int>()));

            // 'Add' repository mock
            this.mockRepository.Setup(x => x.AddBook(It.IsAny<Book>()));

            return this;
        }

        public BookService Build()
        {
            return new BookService(
                this.mapper,
                this.mockAuthorValidation.Object,
                this.mockRepository.Object);
        }
    }
}