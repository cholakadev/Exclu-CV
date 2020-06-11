namespace exclucv.Controllers
{
    using exclucv.DAL.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;

    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ExclucvDbContext _context;

        public UploadController(ExclucvDbContext context)
        {
            this._context = context;
        }

        [Route("profile")]
        [HttpPost, DisableRequestSizeLimit]
        // POST: api/upload/profile
        public IActionResult UploadProfilePicture()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var userId = this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == "UserID").Value;

                    foreach (var user in this._context.ApplicationUsers)
                    {
                        if (user.Id == userId)
                        {
                            user.ProfileImage = dbPath;
                        }
                    }

                    this._context.SaveChanges();

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }
    }
}
