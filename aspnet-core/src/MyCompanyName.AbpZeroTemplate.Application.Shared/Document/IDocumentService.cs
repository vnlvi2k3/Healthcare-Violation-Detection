using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.MyDocument.DTO;

namespace MyCompanyName.AbpZeroTemplate.IDocument
{
    public interface IDocumentAppService : IApplicationService
    {
        ListResultDto<DocumentListDto> GetDocument(GetDocumentInput input);


    }
}
