using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.User
{
    public interface IUserRepository
    {
        User GetAppUserIdBySlackUserId(string slackUserId);
    }
}
