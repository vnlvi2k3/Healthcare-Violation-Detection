using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using MyCompanyName.AbpZeroTemplate;
using MyCompanyName.AbpZeroTemplate.LegalText;
using MyCompanyName.AbpZeroTemplate.VanBanPhapLyservice;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Extensions;

public class VanBanPhapLyAppService : AbpZeroTemplateAppServiceBase, IVanBanPhapLyAppService
{
    private readonly IRepository<VanBanPhapLy> _vanbanphaplyRepository;

    public VanBanPhapLyAppService(IRepository<VanBanPhapLy> vanbanphaplyRepository)
    {
        _vanbanphaplyRepository = vanbanphaplyRepository;
    }

    public ListResultDto<VanBanPhapLyListDto> GetVanBanPhapLy(GetVanBanPhapLyInput input)
    {
        var vanbanphaply = _vanbanphaplyRepository
            .GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                     p.Surname.Contains(input.Filter) ||
                     p.EmailAddress.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Surname)
            .ToList();

        return new ListResultDto<VanBanPhapLyListDto>(ObjectMapper.Map<List<VanBanPhapLyListDto>>(vanbanphaply));
    }
}
