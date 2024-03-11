using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace MyCompanyName.AbpZeroTemplate.LegalText
{
    [Table("PbVanBanPhapLy")]
    public class VanBanPhapLy : FullAuditedEntity
    {
        public const int MaxNameLength = 32;
        public const int MaxSurnameLength = 32;
        public const int MaxEmailAddressLength = 255;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string name { get; set; }

        [Required]
        [MaxLength(MaxSurnameLength)]
        public virtual string surname { get; set; }

        [MaxLength(MaxEmailAddressLength)]
        public virtual string emailAddress { get; set; }
    }
}
