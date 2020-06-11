namespace exclucv.Controllers
{
    using exclucv.DAL.Models;
    using exclucv.DAL.Models.MainInfo;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/main")]
    [ApiController]
    public class MainInformationController : ControllerBase
    {
        private readonly ExclucvDbContext _context;

        public MainInformationController(ExclucvDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("departments")]
        // GET : /api/main/departments
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await this._context.Departments.ToListAsync();
        }

        [HttpPost]
        [Route("departments")]
        // POST : /api/main/departments
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            this._context.Departments.Add(department);

            await this._context.SaveChangesAsync();

            return CreatedAtAction("AddDepartment", new { id = department.Id }, department);
        }

        [HttpGet]
        [Route("levels")]
        // GET : /api/main/levels
        public async Task<ActionResult<IEnumerable<Level>>> GetLevels()
        {
            return await this._context.Levels.ToListAsync();
        }

        [HttpPost]
        [Route("levels")]
        // POST : /api/main/levels
        public async Task<ActionResult<Level>> AddLevel(Level level)
        {
            this._context.Levels.Add(level);

            await this._context.SaveChangesAsync();

            return CreatedAtAction("AddLevel", new { id = level.Id }, level);
        }

        [HttpPost]
        [Route("information")]
        // POST : /api/main/information
        public async Task<ActionResult<MainInformation>> CreateMainInformation(MainInformation mainInformation)
        {
            this._context.MainInformation.Add(mainInformation);

            await this._context.SaveChangesAsync();

            return CreatedAtAction("CreateMainInformation", new { id = mainInformation.Id }, mainInformation);
        }
    }
}
