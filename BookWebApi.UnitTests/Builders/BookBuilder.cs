using BookWebApi.EntityFrameworkCore.Models;

namespace BookWebApi.UnitTests.Builders
{
    public class BookBuilder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfPublish { get; set; }

        public BookBuilder()
        {
            Id = 0;
        }

        public BookBuilder WithId(int newId)
        {
            this.Id = newId;
            return this;
        }
        public BookBuilder WithTitle(string Title)
        {
            this.Title = Title;
            return this;
        }
        public BookBuilder WithYearOfPublish(int YearOfPublish)
        {
            this.YearOfPublish = YearOfPublish;
            return this;
        }
        public Book Build()
        {
            return new Book
            {
                Id = this.Id,
                Title = this.Title,
                YearOfPublish = this.YearOfPublish,
            };
        }
    }
}