using Domain.Entities.User;
using Domain.IRepository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        //Ctor
        #region Ctor
        private readonly DataContext _Context;

        public UserRepository(DataContext dataContext)
        {
            _Context = dataContext;
        }

        #endregion


        //AddUserRepository
        #region AddUser
        public async Task<bool> AddUserToDataBase(User user)
        {

            //Serch For Usename in Database
            var exist = _Context.Users.Any(p => p.UserName == user.UserName);

            if (!exist)
            {
                _Context.Users.Add(user);
                return true;
            }

            return false;

        }

        #endregion



    }
}
