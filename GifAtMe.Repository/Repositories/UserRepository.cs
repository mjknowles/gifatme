using GifAtMe.Common.UnitOfWork;
using GifAtMe.Domain.Entities.User;
using GifAtMe.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.Repositories
{
    public class UserRepository : GenericDomainTypeRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork, IGifAtMeContextFactory dbContextFactory)
            : base(unitOfWork, dbContextFactory)
        {
        }

        public User GetAppUserIdBySlackUserId(string slackUserId)
        {
            
        }
    }
}
