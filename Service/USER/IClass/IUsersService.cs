using Model.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.USER.IClass
{
    public interface IUsersService
    {
        Task<Response> AddUsersAsync(User user);
    }
}
