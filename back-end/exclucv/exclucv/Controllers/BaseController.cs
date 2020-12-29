namespace exclucv.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        protected Guid GetUserId()
        {
            var userId = this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == "UserID").Value;
            return Guid.Parse(userId);
        }
    }
}
