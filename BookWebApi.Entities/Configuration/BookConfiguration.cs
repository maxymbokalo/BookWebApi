using BookWebApi.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWebApi.EntityFrameworkCore.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasMany(p => p.Authors)
                .WithOne(p => p.Book)
                .HasForeignKey(p => p.BookId);
            builder.ToTable("Books");

            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}