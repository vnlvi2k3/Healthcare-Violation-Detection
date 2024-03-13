using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.IDocument
{
    public interface IDocumentAppService : IApplicationService
    {
        Task DeleteDocument(EntityDto input);

        Task RestoreDocument(int input);
    }
}
