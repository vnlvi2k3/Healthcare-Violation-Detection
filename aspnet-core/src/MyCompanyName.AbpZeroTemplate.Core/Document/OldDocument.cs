using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.MyDocument;
//using MyCompanyName.AbpZeroTemplate.Documents;

namespace MyCompanyName.AbpZeroTemplate.MyDocument
{
    [Table("PbOldDocuments")]
    public class OldDocument : FullAuditedEntity
    {

        [Required]
        [MaxLength(20)]
        public virtual string code { get; set; }

        [Required]
        [MaxLength(20)]
        public virtual string title { get; set; }

        [MaxLength(200)]
        public virtual string description { get; set; }

        public virtual DateTime validation { get; set; }

        public virtual DateTime expiration { get; set; }

        public virtual bool published { get; set; }

        public virtual string fullText { get; set; }

        public virtual bool approved { get; set; }

        public virtual string medical_product { get; set; }

        public virtual string province { get; set; }

        public virtual bool showed { get; set; }

        [ForeignKey("DVKCBId")]
        public virtual User User { get; set; }
        public virtual long? DVKCBId { get; set; }

        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }
        public virtual int DocumentId { get; set; }
    }
}
