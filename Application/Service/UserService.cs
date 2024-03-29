﻿
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
using Application.Extensions.NameGenerator;

namespace Application.Service
{
    public class UserService : IUserService
    {

        #region Ctor

        private readonly IUserRepository _IUserRepository;

        private readonly FileSaver _FileSaver;
        public UserService(IUserRepository IUserRepository, FileSaver FileSaver)
        {
            _IUserRepository = IUserRepository;
            _FileSaver = FileSaver;
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

        public async Task<List<ListOfUserDTO>> GetListOfUsers()
        {
            //GetListOfUsers
            var user = _IUserRepository.GetListOfUser();

            //Object Mapping
            List<ListOfUserDTO> ListOfUserDto = new List<ListOfUserDTO>();
            foreach (var item in user)
            {
                ListOfUserDto.Add(new ListOfUserDTO
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Password = item.Password,
                    CreateDate = item.CreateDate,
                    UserAvatar = item.UserAvatar,
                });
            }

            //Return
            return ListOfUserDto;

        }
        #endregion


        #region GetEditUserDTO
        public async Task<EditUserDto> GetEditUserDTO(int UserId)
        {

            //Get User By Id
            User user = await _IUserRepository.GetUserById(UserId);

            //GetUserRoles

            var RolesIds = _IUserRepository.GetRoleOfUserById(UserId);

            //OjectMapping

            EditUserDto editUserDto = new EditUserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                CreateDate = user.CreateDate,
                UserAvatar = user.UserAvatar,
                UserSelectedRoles = RolesIds,
            };


            return editUserDto;
        }

        #endregion


        #region EditUser

        public async Task<bool> EditUser(EditUserDto editUserDto)
        {

            User user = new User
            {
                Id = editUserDto.Id,
                UserName = editUserDto.UserName,
                Password = editUserDto.Password,
  
            };

            #region AddImage 
            if (editUserDto.UserAvatarFormFile != null)
            {
                //Save New Image
                user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUserDto.UserAvatarFormFile.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUserDto.UserAvatarFormFile.CopyTo(stream);
                }
            }
            #endregion

            var Issucces = await _IUserRepository.EditUserDto(user);


            return Issucces;

        }


        #endregion


    }
}
