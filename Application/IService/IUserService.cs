using Application.DTOs;
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

    }
}
