using System.Collections.Generic;
using AutoMapper;
using BookWebApi.DataAccess.DTO;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.DataAccess.Mapping;
using BookWebApi.DataAccess.Services;
using BookWebApi.DataAccess.Validation;
using BookWebApi.EntityFrameworkCore.Interfaces;
using BookWebApi.EntityFrameworkCore.Models;
using BookWebApi.EntityFrameworkCore.Repository;
using Moq;

namespace BookWebApi.UnitTests.Builders
{

    public class AuthorServiceBuilder
    {
        private readonly Mock<IAuthorRepository> mockRepository;
        private readonly MapperConfiguration mapperConfiguration;
        private readonly Mapper mapper;
        private Mock<IAuthorValidator> mockAuthorValidation;



        public AuthorServiceBuilder()
        {
            var mockRepositoryObject = new MockRepository(MockBehavior.Default);

            this.mockAuthorValidation = mockRepositoryObject.Create<IAuthorValidator>();

            mockRepository = mockRepositoryObject.Create<IAuthorRepository>();

            // Default automapper configuration
            mapperConfiguration = new MapperConfiguration(new MappingProfile());
            mapper = new Mapper(mapperConfiguration);
        }

        public AuthorServiceBuilder WithRepositoryMock(IEnumerable<Author> authorsList, Author author)
        {
            // 'GetAll' repository mock
            this.mockRepository.Setup(x => x.GetAllBookAuthors()).Returns(authorsList);


            // 'Get' repository mock
            this.mockRepository.Setup(x => x.GetBookAuthor(It.IsAny<int>())).Returns(author);

            // 'Update' repository mock
            this.mockRepository.Setup(x => x.UpdateBookAuthor(It.IsAny<Author>(), It.IsAny<int>()));

            // 'Add' repository mock
            this.mockRepository.Setup(x => x.AddBookAuthor(It.IsAny<Author>()));

            return this;
        }

        public AuthorService Build()
        {
            return new AuthorService(
                this.mapper,
                this.mockAuthorValidation.Object,
                this.mockRepository.Object);
        }
    }
}