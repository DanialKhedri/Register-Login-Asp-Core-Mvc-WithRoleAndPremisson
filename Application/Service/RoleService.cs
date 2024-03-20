using Application.DTOs;
using Application.IService;
using Domain.Entities.Role;
using Domain.Entities.SelectedRole;
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




        #region DeleteRolesofUserById

        public void DeleteRolesofUserById(int UserId)
        {
            _iRoleRepository.DeleteRolesofUserById(UserId);


        }

        #endregion

        #region ChangeRoleOfUserById

        public void AddSelectedRole(List<int> selectedRole, EditUserDto User)
        {
            foreach (int item in selectedRole)
            {
                SelectedRole TempselectedRole = new SelectedRole
                {
                    UserId = User.Id,
                    RoleId = item,
                };

                _iRoleRepository.AddSelectedRole(TempselectedRole);
            }
           
        }






        #endregion

        #region SaveChange
        public void SaveChange()
        {

            _iRoleRepository.SaveChange();
        }

        #endregion
    }
}
