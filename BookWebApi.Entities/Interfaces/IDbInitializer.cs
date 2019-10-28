using Microsoft.EntityFrameworkCore;

namespace BookWebApi.EntityFrameworkCore.Interfaces
{
    public interface IDbInitializer
    {
        void Seed(ModelBuilder modelBuilder);
    }
}