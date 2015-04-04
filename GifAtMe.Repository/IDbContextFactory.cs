using System.Data.Entity;

namespace GifAtMe.Repository
{
    public interface IDbContextFactory
    {
        DbContext Create();
    }
}