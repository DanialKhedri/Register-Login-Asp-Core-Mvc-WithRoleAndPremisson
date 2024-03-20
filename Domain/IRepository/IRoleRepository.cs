using Domain.Entities.Role;
using Domain.Entities.SelectedRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IRoleRepository
    {

        public Task<List<Role>> GetListOfRoles();


        public void DeleteRolesofUserById(int UserId);

        public void AddSelectedRole(SelectedRole selectedRole);


        public void SaveChange();


    }
}
