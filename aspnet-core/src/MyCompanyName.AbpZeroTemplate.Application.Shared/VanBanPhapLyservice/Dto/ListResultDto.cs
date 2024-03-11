using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

public class GetVanBanPhapLyInput
{
    public string Filter { get; set; }
}

public class VanBanPhapLyListDto : FullAuditedEntityDto
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string EmailAddress { get; set; }
}

