using Application.DTOs;
using Application.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LogInAspcoreMVC.Areas.SitePanel.Controllers
{
    public class UserController : Controller
    {

        //Ctor
        #region Ctor
        private readonly IUserService _IUserService;

        public UserController(IUserService IUserService)
        {
            _IUserService = IUserService;

        }

        #endregion

        //Index action
        #region Index
        [Area("SitePanel")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        #endregion
        
        //Register Actions
        #region Register

        [Area("SitePanel")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [Area("SitePanel")]
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var isSucces = await _IUserService.AddUser(userDTO);

            if (isSucces)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["Message"] = "Is Not Succes";
            return View();


        }

        #endregion


        
        //LogIn Actions




        //LogOut Action


    }
}
