using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Application.DTOs
{
    public class EditUserDto
    {
        #region Properties
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string? UserAvatarOriginal { get; set; } = null;

        public IFormFile UserAvatar { get; set; } = null;

       public List<int> UserSelectedRoles { get; set; }

        #endregion
    }
}
