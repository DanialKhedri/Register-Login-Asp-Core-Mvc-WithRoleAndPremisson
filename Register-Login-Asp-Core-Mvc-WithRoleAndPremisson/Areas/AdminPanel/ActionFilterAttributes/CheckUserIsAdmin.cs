using Application.Extensions;
using Application.IService;
using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Register_Login_Asp_Core_Mvc_WithRoleAndPremisson.Areas.ActionFilterAttributes
{
    public class CheckUserIsAdmin : ActionFilterAttribute
    {

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            //Get Service with httpcontext
            IUserService Service = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));

            int userId = context.HttpContext.User.GetUserId();

            User user = await Service.GetUserById(userId);

            //Check IsAdmin
            bool isadmin = await Service.IsAdmin(userId); 

            //Check Is SuperAdmin
            if (user.IsSuperAdmin)     
                isadmin = true;
        



            if (isadmin == false)
            {
                context.HttpContext.Response.Redirect("/");
            }

            base.OnActionExecuting(context);
        }


    }

}
