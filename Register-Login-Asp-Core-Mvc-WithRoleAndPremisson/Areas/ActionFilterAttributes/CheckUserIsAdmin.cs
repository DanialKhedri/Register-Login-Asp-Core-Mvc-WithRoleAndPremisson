using Application.Extensions;
using Application.IService;
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

            bool isadmin = await Service.IsAdmin(userId);

            if (isadmin == false)
            {
                context.HttpContext.Response.Redirect("/");
            }

            base.OnActionExecuting(context);
        }


    }

}
