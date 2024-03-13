using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.MyDocument;
using MyCompanyName.AbpZeroTemplate.MyDocument.DTO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;
using System.Text;
using Abp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Abp.Collections.Extensions;

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
        public async Task RestoreDocument(int input)
        {
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var document = await _documentRepository.GetAsync(input);
                document.IsDeleted = false;
                await _documentRepository.UpdateAsync(document);
            }
        }

        public ListResultDto<DocumentListDto> GetDocument(GetDocumentInput input)
        { 
            var document = _documentRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.title.Contains(input.Filter) ||
                         p.code.Contains(input.Filter) ||
                         p.description.Contains(input.Filter) ||
                         p.fullText.Contains(input.Filter) ||
                         p.medical_product.Contains(input.Filter) ||
                         p.province.Contains(input.Filter) ||
                         p.validation.ToString().Contains(input.Filter) ||
                         p.expiration.ToString().Contains(input.Filter) ||
                         p.published.ToString().Contains(input.Filter) ||
                         p.approved.ToString().Contains(input.Filter) ||
                         p.showed.ToString().Contains(input.Filter))

                .OrderBy(p => p.title)
                .ThenBy(p => p.code)
                .ThenBy(p => p.description)
                .ThenBy(p => p.fullText)
                .ThenBy(p => p.medical_product)
                .ThenBy(p => p.province)
                .ThenBy(p => p.validation)
                .ThenBy(p => p.expiration)
                .ThenBy(p => p.published)
                .ThenBy(p => p.approved)
                .ToList();

            return new ListResultDto<DocumentListDto>(ObjectMapper.Map<List<DocumentListDto>>(document));
        }

        [HttpGet]
        public ListResultDto<DocumentListDto> Search(GetDocumentInput input, int option, DateTime? dateValid, DateTime? dateExpire)
        {
            var query = _documentRepository.GetAll();

            if (!input.Filter.IsNullOrEmpty())
            {
                query = query.Where(p =>
                    p.code.Contains(input.Filter) ||
                    p.description.Contains(input.Filter) ||
                    p.fullText.Contains(input.Filter) ||
                    p.medical_product.Contains(input.Filter) ||
                    p.province.Contains(input.Filter) ||
                    p.validation.ToString().Contains(input.Filter) ||
                    p.expiration.ToString().Contains(input.Filter) ||
                    p.published.ToString().Contains(input.Filter) ||
                    p.approved.ToString().Contains(input.Filter) ||
                    p.showed.ToString().Contains(input.Filter));
            }

            switch (option)
            {
                case 1: // Advanced Search with date valid
                    if (dateValid != null)
                    {
                        query = query.Where(p => p.validation == dateValid);
                    }
                    break;
                case 2: // Advanced Search with date expire
                    if (dateExpire != null)
                    {
                        query = query.Where(p => p.expiration == dateExpire);
                    }
                    break;
                case 3: // Advanced Search with both date valid and date expire
                    if (dateValid != null && dateExpire != null)
                    {
                        query = query.Where(p => p.validation == dateValid && p.expiration == dateExpire);
                    }
                    break;
                default:
                    break;
            }

            // Order the results
            query = query.OrderBy(p => p.title)
                         .ThenBy(p => p.code)
                         .ThenBy(p => p.description)
                         .ThenBy(p => p.fullText)
                         .ThenBy(p => p.medical_product)
                         .ThenBy(p => p.province)
                         .ThenBy(p => p.validation)
                         .ThenBy(p => p.expiration)
                         .ThenBy(p => p.published)
                         .ThenBy(p => p.approved);

            var document = query.ToList();

            return new ListResultDto<DocumentListDto>(ObjectMapper.Map<List<DocumentListDto>>(document));
        }

    }
}
