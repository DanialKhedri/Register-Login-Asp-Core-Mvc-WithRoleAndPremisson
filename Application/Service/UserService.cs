
using Application.DTOs;
using Application.IService;
using Domain.Entities.User;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        //Ctor
        #region Ctor

        private readonly IUserRepository _IUserRepository;

        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

        #endregion


        //AddUser Service
        #region AddUser
        public async Task<bool> AddUser(UserDTO userDTO)
        {
        

            if (userDTO.Password == userDTO.RePassword)
            {
                //Object Mapping
                User user = new User
                {
                    UserName = userDTO.UserName,
                    Password = userDTO.Password,
                };


                //Send To Repository
                var IsSucses = await _IUserRepository.AddUserToDataBase(user);
                return IsSucses;

            }

            else
            {
                return false;
            }

        

        }

        #endregion



    }
}
