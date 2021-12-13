namespace exclucv.Controllers
{
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _service;

        public UploadController(IUploadService service)
        {
            this._service = service;
        }

        [Route("profileImage")]
        [HttpPost, DisableRequestSizeLimit]
        // POST: api/upload/profileImage
        public IActionResult UploadProfilePicture()
        {
            try
            {
                var file = Request.Form.Files[0];

                var userId = this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == "UserID").Value;
                var imagePath = this._service.UploadProfileImage(Guid.Parse(userId), file);

                return Ok(new { imagePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
