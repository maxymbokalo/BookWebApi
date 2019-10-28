using AutoMapper;
using AutoMapper.Configuration;
using BookWebApi.DataAccess.DTO;
using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.DataAccess.Mapping
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<BookDto, Book>();
            CreateMap<AuthorDto, Author>();
        }
    }
}