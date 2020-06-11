namespace exclucv.Services.CV.Services
{
    using exclucv.DAL.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CvRepository : ICvRepository
    {
        private readonly ExclucvDbContext _context;

        public CvRepository(ExclucvDbContext context)
        {
            this._context = context;
        }

        public void Create(CvModel newCv)
        {
            this._context.CVs.Add(newCv);
        }

        public void Delete(int id)
        {
            var cv = this._context.CVs.Find(id);

            this._context.Remove(cv);
        }

        public IEnumerable<CvModel> GetAllCvs()
        {
            throw new System.NotImplementedException();
        }

        public CvModel GetCv(int id)
        {
            throw new System.NotImplementedException();
        }

        public CvModel Update(CvModel updatedCv)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CvViewModel> ByUser(string userId)
        {
            return this._context
            .CVs
            .Where(c => c.ApplicationUserId == userId)
            .Select(c => new CvViewModel
            {
                Id = c.Id,
                DateOfCreation = c.DateOfCreation,
                MainInformation = c.MainInformation,
                Skill = c.Skill,
                Education = c.Education,
                WorkExperience = c.WorkExperience
            })
            .ToList();
        }
    }
}
