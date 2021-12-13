namespace exclucv.Business.Services
{
    using exclucv.Data.Contracts.RepositoryContracts;
    using exclucv.Services.ServiceContracts;

    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repository;

        public TemplateService(ITemplateRepository repository)
        {
            this._repository = repository;
        }

        //public Guid CreateTemplate(Guid userId)
        //{
        //    var summaryId = this.CreateSummary(userId);

        //    Template template = new Template()
        //    {
        //        TemplateId = Guid.NewGuid(),
        //        UserId = userId,
        //        SummaryId = summaryId
        //    };

        //    var templateId = this._repository.CreateTemplate(template);

        //    return templateId;
        //}
    }
}
