using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.IDocument;
using MyCompanyName.AbpZeroTemplate.MyDocument;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.DocumentService
{
    public class DocumentAppService : AbpZeroTemplateAppServiceBase, IDocumentAppService
    {
        private readonly IRepository<Document> _documentRepository;

        public DocumentAppService(IRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Document_DeleteRestore)]

        public async Task DeleteDocument(EntityDto input)
        {
            await _documentRepository.DeleteAsync(input.Id);

        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Document_DeleteRestore)]
        public async Task RestoreDocument(EntityDto input)
        {
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var document = await _documentRepository.GetAsync(input.Id);
                document.IsDeleted = false;
                await _documentRepository.UpdateAsync(document);
            }
        }
    }
}
