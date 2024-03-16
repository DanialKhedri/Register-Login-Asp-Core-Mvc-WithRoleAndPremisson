using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ListOfUserDTO
    {
        #region Properties
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string? UserAvatar { get; set; } = null;
        #endregion



    }
}
