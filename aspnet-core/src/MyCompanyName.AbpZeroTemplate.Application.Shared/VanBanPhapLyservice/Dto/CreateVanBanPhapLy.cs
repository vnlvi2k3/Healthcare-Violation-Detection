using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.VanBanPhapLyservice.Dto
{
    public class CreateVanBanPhapLyInput
    {
        [Required]
        [MaxLength(VanBanPhapLyConsts.MaxNameLength)]
        public string name { get; set; }

        [Required]
        [MaxLength(VanBanPhapLyConsts.MaxSurnameLength)]
        public string surname { get; set; }

        [EmailAddress]
        [MaxLength(VanBanPhapLyConsts.MaxEmailAddressLength)]
        public string emailAddress { get; set; }
    }

}
