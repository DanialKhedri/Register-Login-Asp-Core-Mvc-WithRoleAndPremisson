using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class User
    {
        #region Properties
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsSuperAdmin { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string? UserAvatar { get; set; } = null;
        #endregion


        #region Navigation Properties
        public ICollection<SelectedRole.SelectedRole> SelectedRoles { get; set; }

        #endregion
    }
}
