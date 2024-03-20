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
    private readonly IRoleService _IRoleService;

    public AdminController(IUserService IuserService, IRoleService IRoleService)
    {
        _IuserService = IuserService;
        _IRoleService = IRoleService;
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
        var userDTO = await _IuserService.GetEditUserDTO(UserId);

        ViewData["Roles"] = await _IRoleService.GetListofRoles();

        //Return User
        return View(userDTO);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(EditUserDto editUserDto, List<int> SelectedRoles)
    {



        bool IsSucces = await _IuserService.EditUser(editUserDto);

        if (SelectedRoles != null)
        {
            _IRoleService.DeleteRolesofUserById(editUserDto.Id);
            _IRoleService.AddSelectedRole(SelectedRoles, editUserDto);

            _IRoleService.SaveChange();
        }
       

            if (IsSucces)
        {
            return RedirectToAction(nameof(ListOfUsers));
        }
        else
        {
            return View();
        }




    }
    #endregion




}
