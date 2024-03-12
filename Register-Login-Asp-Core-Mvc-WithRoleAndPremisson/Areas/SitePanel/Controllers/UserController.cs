using Application.DTOs;
using Application.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace LogInAspcoreMVC.Areas.SitePanel.Controllers
{
    public class UserController : Controller
    {

        #region Ctor
        private readonly IUserService _IUserService;

        public UserController(IUserService IUserService)
        {
            _IUserService = IUserService;

        }

        #endregion


        #region Index
        [Area("SitePanel")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        #endregion


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



        #region LogIn
        [Area("SitePanel")]
        [HttpGet]
        public async Task<IActionResult> LogIn()
        {

            return View();
        }

        [Area("SitePanel")]
        [HttpPost]
        public async Task<IActionResult> logIn(UserDTO userDTO)
        {

            var Issucces = await _IUserService.LogIn(userDTO);

            if (Issucces)
                return RedirectToAction(nameof(Index));


            TempData["Message"] = "UserName Or Password Is Wrong";
            return View();

        }



        #endregion



        #region LogOut

        [Area("SitePanel")]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        [Area("SitePanel")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Shop()
        {
            return View();
        }
    }
}
