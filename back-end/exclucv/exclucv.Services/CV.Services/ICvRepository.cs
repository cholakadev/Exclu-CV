namespace exclucv.Services.CV.Services
{
    using exclucv.DAL.Models;
    using System.Collections.Generic;

    public interface ICvRepository
    {
        IEnumerable<CvModel> GetAllCvs();

        CvModel GetCv(int id);

        CvModel Update(CvModel updatedCv);

        void Create(CvModel newCv);

        void Delete(int id);

        IEnumerable<CvViewModel> ByUser(string userId);
    }
}
