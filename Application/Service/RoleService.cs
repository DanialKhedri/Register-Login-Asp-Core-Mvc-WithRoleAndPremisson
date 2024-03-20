using Application.IService;
using Domain.Entities.Role;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RoleService : IRoleService
    {

        #region Ctor
        private readonly IRoleRepository _iRoleRepository;


        public RoleService(IRoleRepository IroleRepository)
        {

            _iRoleRepository = IroleRepository;
        }
        #endregion

        #region GetListofRoles

        public async Task<List<Role>> GetListofRoles()
        {
            return await _iRoleRepository.GetListOfRoles();


        }



        #endregion
    }
}
