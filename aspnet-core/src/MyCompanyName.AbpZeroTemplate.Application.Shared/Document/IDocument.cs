using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.MyDocument.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.MyDocument
{
    public interface IDocumentAppService:IApplicationService
    {
        ListResultDto<DocumentListDto> GetDocument(GetDocumentInput input);
    }
}
