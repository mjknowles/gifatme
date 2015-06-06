using GifAtMe.Common.UnitOfWork;
using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Domain.Entities.User;
using GifAtMe.Repository.Contexts;
using GifAtMe.Repository.DatabaseModels;
using GifAtMe.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.Repositories
{
    public class UserRepository : GenericDomainTypeRepository<User, UserDb>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork, IGifAtMeContextFactory dbContextFactory)
            : base(unitOfWork, dbContextFactory)
        {
        }

        public User GetAppUserIdBySlackUserId(string slackUserId)
        {
            return _context.Users.Where(u => u.SlackUserId.Equals(slackUserId, StringComparison.OrdinalIgnoreCase)).SingleOrDefault().ConvertToDomain();
        }
    }
}
