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
using MyCompanyName.AbpZeroTemplate.VanBanPhapLyservice.Dto;

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
                p => p.name.Contains(input.Filter) ||
                     p.surname.Contains(input.Filter) ||
                     p.emailAddress.Contains(input.Filter)
            )
            .OrderBy(p => p.name)
            .ThenBy(p => p.surname)
            .ToList();

        return new ListResultDto<VanBanPhapLyListDto>(ObjectMapper.Map<List<VanBanPhapLyListDto>>(vanbanphaply));
    }

    public async Task CreateVanBanPhapLy(CreateVanBanPhapLyInput input)
    {
        var vanbanphaply = ObjectMapper.Map<VanBanPhapLy>(input);
        await _vanbanphaplyRepository.InsertAsync(vanbanphaply);
    }
}
