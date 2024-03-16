using Application.DTOs;
using Application.Extensions;
using Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Register_Login_Asp_Core_Mvc_WithRoleAndPremisson.Areas.ActionFilterAttributes;

namespace Register_Login_Asp_Core_Mvc_WithRoleAndPremisson.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
[Authorize]
[CheckUserIsAdmin]
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
        return View();
    }

    #endregion

    #region ListOfUsers
    [HttpGet]
    public async Task<IActionResult> ListOfUsers()
    {
        //Get List 
        List<ListOfUserDTO> userDTOList = await _IuserService.GetListOfUsers();
        //Pass To View

        return View(userDTOList);

    }

    #endregion


    #region EditUser
    [HttpGet]
    public async Task<IActionResult> EditUser(int UserId)
    {
        //Get UserById

        //Return User
        return View();
    }

    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser()
    {
        return View();
    }
    #endregion




}
