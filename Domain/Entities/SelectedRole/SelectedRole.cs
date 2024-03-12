using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace Domain.Entities.SelectedRole
{
    public class SelectedRole
    {

        #region Properties
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        #endregion


        #region Navigation Properties

        public User.User User;

        public Role.Role Role;

        #endregion

    }
}
