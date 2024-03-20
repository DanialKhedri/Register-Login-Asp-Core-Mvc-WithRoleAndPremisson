using Application.DTOs;
using Domain.Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IRoleService
    {
        public Task<List<Role>> GetListofRoles();

        public void DeleteRolesofUserById(int UserId);

        public void AddSelectedRole(List<int> selectedRole, EditUserDto User);

        public void SaveChange();

    }
}
