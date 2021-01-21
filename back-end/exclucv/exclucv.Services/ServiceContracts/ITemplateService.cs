namespace exclucv.Services.ServiceContracts
{
    using System;

    public interface ITemplateService
    {
        Guid CreateTemplate(Guid userId);
        Guid CreateSummary(Guid userId);
    }
}
