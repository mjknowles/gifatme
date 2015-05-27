using System.Data.Entity;

namespace GifAtMe.Repository.Contexts
{
    public interface IDbContextFactory
    {
        DbContext Create();
    }
}