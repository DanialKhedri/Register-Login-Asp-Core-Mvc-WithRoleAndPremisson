
using Application.DTOs;
using Application.IService;
using Application.Security;
using Domain.Entities.Role;
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


        #region Ctor

        private readonly IUserRepository _IUserRepository;

        public UserService(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

        #endregion

        #region AddUser
        public async Task<bool> AddUser(UserDTO userDTO)
        {


            if (userDTO.Password == userDTO.RePassword)
            {
                //Object Mapping
                User user = new User
                {
                    UserName = userDTO.UserName,
                    Password = PasswordHasher.EncodePasswordMd5(userDTO.Password),
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


        #region LogIn

        public async Task<bool> LogIn(UserDTO userDTO)
        {
            //object mapping

            User user = new User
            {
                UserName = userDTO.UserName,
                Password = PasswordHasher.EncodePasswordMd5(userDTO.Password),
            };


            //Send object to repository and recive result

            bool IsSucces = await _IUserRepository.LogInUser(user);

            if (IsSucces)
                return true;
            else
                return false;


        }

        #endregion


        #region GetUserId
        public Task<User> GetUserById(int UserId)
        {

            return _IUserRepository.GetUserById(UserId);


        }
        #endregion


        #region GetRoleByUserId
        public async Task<List<Role>> GetRoleByUserId(int UserId)
        {
            return await _IUserRepository.IsAdmin(UserId);
        }
        #endregion


        #region IsAdmin
        public async Task<bool> IsAdmin(int userId)
        {
            List<Role> Roles = await GetRoleByUserId(userId);

            bool Premission = false;

            foreach (var item in Roles)
            {
                if (item.RoleUniqueName == "Admin")
                {
                    Premission = true;
                }
            }

            return Premission;

        }

        #endregion

        #region GetListOfUser

        public async Task<List<EditUserDTO>> GetListOfUsers()
        {
            //GetListOfUsers
            var user = _IUserRepository.GetListOfUser();

            //Object Mapping
            List<EditUserDTO> editUserDTOs = new List<EditUserDTO>();
            foreach (var item in user)
            {
                editUserDTOs.Add(new EditUserDTO
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Password = item.Password,
                    CreateDate = item.CreateDate,
                    UserAvatar = item.UserAvatar,
                });
            }

            //Return
            return editUserDTOs;

        }
        #endregion
    }
}
