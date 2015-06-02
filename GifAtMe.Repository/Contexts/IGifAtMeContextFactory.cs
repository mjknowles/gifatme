using System.Data.Entity;

namespace GifAtMe.Repository.Contexts
{
    public interface IGifAtMeContextFactory
    {
        GifAtMeContext Create();
    }
}