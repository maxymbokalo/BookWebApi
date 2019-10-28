using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.UnitTests.Builders
{
    public class AuthorBuilder
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookId { get; set; }

        public AuthorBuilder()
        {
            Id = 0;
        }

        public AuthorBuilder WithId(int newId)
        {
            this.Id = newId;
            return this;
        }
        public AuthorBuilder WithName(string FirstName,string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            return this;
        }
        public AuthorBuilder WithBookId(int newId)
        {
            this.BookId = newId;
            return this;
        }
        public Author Build()
        {
            return new Author
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BookId = this.BookId
            };
        }

    }
}