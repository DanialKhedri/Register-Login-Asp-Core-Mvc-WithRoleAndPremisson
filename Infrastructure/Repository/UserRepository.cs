using Domain.Entities.Role;
using Domain.Entities.User;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    #region Ctor
    private readonly DataContext _Context;
    private readonly IHttpContextAccessor _IhttpContextAccessor;
    public UserRepository(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
    {
        _IhttpContextAccessor = httpContextAccessor;
        _Context = dataContext;
    }

    #endregion


    #region AddUser
    public async Task<bool> AddUserToDataBase(User user)
    {

        //Serch For Usename in Database
        var exist = _Context.Users.Any(p => p.UserName == user.UserName);

        if (!exist)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
            return true;
        }

        return false;

    }



    #endregion

    #region LogIn
    public async Task<bool> LogInUser(User User)
    {

        var user = _Context.Users.SingleOrDefault(p => p.UserName == User.UserName && p.Password == User.Password);


        if (user != null)
        {
            #region SetCoockie
            var claims = new List<Claim>

            {

            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName),

              };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimIdentity);

            var authProps = new AuthenticationProperties();
            //authProps.IsPersistent = model.RememberMe;

            await _IhttpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

            #endregion

            return true;
        }

        else
            return false;


    }
    #endregion


    #region IsAdmin

    public async Task<List<Role>> IsAdmin(int UserId)
    {
        bool IsAdmin = false;

        var Roles = _Context.SelectedRoles.Where(p => p.UserId == UserId)
                               .Select(p => p.Role)
                               .ToList();

        return Roles;
    }
    #endregion


    #region GetUserById
    public async Task<User> GetUserById(int UserId)
    {
        return _Context.Users.FirstOrDefault(p => p.Id == UserId);


    }
    #endregion

    #region GetListOfUSers

    public List<User> GetListOfUser()
    {
        //Get List

        List<User> User = _Context.Users.Where(u => !u.IsDeleted)
                             .OrderByDescending(u => u.CreateDate)
                             .Select(u => new User
                             {
                                 Id = u.Id,
                                 UserName = u.UserName,
                                 Password = u.Password,
                                 CreateDate = u.CreateDate,
                                 UserAvatar = u.UserAvatar,

                             }
                             ).ToList();

        return User;
    }
    #endregion


}