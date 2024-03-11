using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.VanBanPhapLyservice
{
    public interface IVanBanPhapLyAppService : IApplicationService
    {
        ListResultDto<VanBanPhapLyListDto> GetVanBanPhapLy(GetVanBanPhapLyInput input);
    }
}
