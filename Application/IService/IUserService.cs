using Application.DTOs;
using Domain.Entities.Role;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IUserService
    {


        public Task<bool> AddUser(UserDTO userDTO);

        public Task<bool> LogIn(UserDTO userDTO);

        public Task<List<Role>> GetRoleByUserId(int UserId);

        public  Task<bool> IsAdmin(int userId);

        public Task<User> GetUserById(int UserId);


    }
}
