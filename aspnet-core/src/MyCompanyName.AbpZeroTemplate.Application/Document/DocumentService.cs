using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using MyCompanyName.AbpZeroTemplate.Authorization;
using Abp.Linq.Extensions;
using Abp.Extensions;
using MyCompanyName.AbpZeroTemplate.MyDocument;
using MyCompanyName.AbpZeroTemplate.IDocument;
using MyCompanyName.AbpZeroTemplate.MyDocument;
\\using MyCompanyName.AbpZeroTemplate.MyDocument.DTO;
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

        public ListResultDto<DocumentListDto> GetDocument(GetDocumentInput input)
        {
            var document = _documentRepository
                .GetAll()
                .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.title.Contains(input.Filter) ||
                     p.code.Contains(input.Filter) ||
                     p.description.Contains(input.Filter)
            )
            .OrderBy(p => p.title)
            .ThenBy(p => p.description)
            .ToList();

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
        public ListResultDto<DocumentListDto> Search(GetDocumentInput input, int option, string str_dateValid, string str_dateExpire)
        {
            var query = _documentRepository.GetAll();

            if (!input.Filter.IsNullOrEmpty())
            {
                query = query.Where(p =>
                    p.title.Contains(input.Filter) ||
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

            DateTime? dateValid = null;
            DateTime? dateExpire = null;

            if (!str_dateValid.IsNullOrEmpty())
            {
                try
                {
                    // If parsing succeeds, dateValid will contain the parsed DateTime value
                    dateValid = DateTime.Parse(str_dateValid);
                }
                catch (FormatException ex)
                {
                    // Handle the exception caused by an incorrect format in str_dateValid
                    dateValid = DateTime.MinValue;
                }
            }

            if(!str_dateExpire.IsNullOrEmpty())
            {
                try
                {
                    // If parsing succeeds, dateExpire will contain the parsed DateTime value
                    dateExpire = DateTime.Parse(str_dateExpire);
                }
                catch (FormatException ex)
                {
                    // Handle the exception caused by an incorrect format in str_dateExpire
                    dateExpire = DateTime.MinValue;
                }
            }

            switch (option)
            {
                case 1: // Advanced Search with date valid
                    if (dateValid != null && dateExpire == null)
                    {
                        query = query.Where(p => p.validation == dateValid);
                    }
                    break;
                case 2: // Advanced Search with date expire
                    if (dateExpire != null && dateValid == null)
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
    };
}
