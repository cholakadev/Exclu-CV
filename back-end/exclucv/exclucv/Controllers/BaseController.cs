namespace exclucv.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        protected string GetUserId()
        {
            return this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == "UserID").Value;
        }
    }
}
