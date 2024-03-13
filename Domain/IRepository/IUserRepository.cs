using Domain.Entities.Role;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IUserRepository
    {

        Task<bool> AddUserToDataBase(User user);

        Task<bool> LogInUser(User user);

        Task<List<Role>> IsAdmin(int UserId);



    }
}
