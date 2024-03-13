using Application.Extensions;
using Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Register_Login_Asp_Core_Mvc_WithRoleAndPremisson.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class AdminController : Controller
    {

        #region Ctor

        private readonly IUserService _IuserService;

        public AdminController(IUserService IuserService)
        {
            _IuserService = IuserService;
        }

        #endregion

        #region Index
      
        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();

            bool IsAdmin = await _IuserService.IsAdmin(userId);

            if (IsAdmin)
            {
                return View();
            }

            else
            {
                return NotFound();
            }
          
        }

        #endregion


    }
}
