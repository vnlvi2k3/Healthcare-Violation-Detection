using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.MyDocument.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.MyDocument
{
    public interface IDocumentAppService:IApplicationService
    {
        ListResultDto<DocumentListDto> GetDocument(GetDocumentInput input);

        //ListResultDto<DocumentListDto> Search(GetDocumentInput input, int option = 0, DateTime? dateValid = null, DateTime? dateExpire = null);

        Task DeleteDocument(EntityDto input);

        Task RestoreDocument(int input);

        ListResultDto<DocumentListDto> Search(GetDocumentInput input, int option = 0, string str_dateValid = "", string str_dateExpire = "");
    }
}
