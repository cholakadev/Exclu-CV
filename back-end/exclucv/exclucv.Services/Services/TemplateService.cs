using exclucv.DAL.Entities;
using exclucv.Repository.RepositoryContracts;
using exclucv.Services.ServiceContracts;
using System;

namespace exclucv.Services.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repository;

        public TemplateService(ITemplateRepository repository)
        {
            this._repository = repository;
        }

        public Guid CreateSummary(Guid userId)
        {
            Summary summary = new Summary()
            {
                SummaryId = Guid.NewGuid()
            };

            var summaryId = this._repository.CreateSummary(summary);

            return summaryId;
        }

        public Guid CreateTemplate(Guid userId)
        {
            var summaryId = this.CreateSummary(userId);

            Template template = new Template()
            {
                TemplateId = Guid.NewGuid(),
                UserId = userId,
                SummaryId = summaryId
            };

            var templateId = this._repository.CreateTemplate(template);

            return templateId;
        }
    }
}
