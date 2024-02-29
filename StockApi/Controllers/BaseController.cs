using Microsoft.AspNetCore.Mvc;
namespace TradeAPI.Controllers
{
    public class BaseController: ControllerBase
    {
       
        protected HttpContext HttpContext => ControllerContext.HttpContext;
        protected string LoggedInUserId => HttpContext.Request.Headers["user_id"];

    }
}
