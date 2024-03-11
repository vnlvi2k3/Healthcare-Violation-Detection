using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.VanBanPhapLyservice.Dto;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.VanBanPhapLyservice
{
    public interface IVanBanPhapLyAppService : IApplicationService
    {
        ListResultDto<VanBanPhapLyListDto> GetVanBanPhapLy(GetVanBanPhapLyInput input);

        Task CreateVanBanPhapLy(CreateVanBanPhapLyInput input);

    }
}
