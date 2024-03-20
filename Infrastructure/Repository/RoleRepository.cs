using Domain.Entities.Role;
using Domain.IRepository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {


        #region Ctor

        private readonly DataContext _Context;

        public RoleRepository(DataContext dataContext)
        {
            _Context = dataContext;
        }

        #endregion

        #region GetListOfRole
        public async Task<List<Role>> GetListOfRoles()
        {

            return _Context.Roles.ToList();

        }
        #endregion
    }
}
