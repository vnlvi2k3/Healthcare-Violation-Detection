using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;

namespace MyCompanyName.AbpZeroTemplate.MyDocument
{
    [Table("PbDocuments")]
    public class Document : FullAuditedEntity
    {
        [Required]
        [MaxLength(255)]
        public virtual string title { get; set; } // tiêu đề


        [Required]
        [MaxLength(20)]
        public virtual string code { get; set; } // số hiệu văn bản (e.g: 2401/QĐ-BGDĐT, 4433/BYT-KCB)

        [Required]
        public virtual string docType { get; set; } // loại văn bản

        [Required]
        public virtual DateTime publishDate { get; set; } // ngày ban hành

        [Required]
        public virtual DateTime validation { get; set; } // ngày hiệu lực

        [Required]
        public virtual DateTime expiration { get; set; } // ngày hết hiệu lực

        [Required]
        [MaxLength(255)]
        public virtual string publishPlace { get; set; } // nơi ban hành

        [Required]
        [MaxLength(255)]
        public virtual string recipient { get; set; } // người nhận

        [Required]
        [MaxLength(50)]
        public virtual string approver { get; set; } // người duyệt

        [Required]
        [MaxLength(50)]
        public virtual string signer { get; set; } // người ký

        [Required]
        public virtual string status { get; set; } // trạng thái

        [Required]
        [MaxLength(1000)]
        public virtual string description { get; set; } // trích yếu

        [Required]
        public virtual string fullText { get; set; } // toàn văn (tên file.pdf)


        public virtual bool published { get; set; }


        public virtual bool approved { get; set; }

        public virtual string medical_product { get; set; }

        public virtual string province { get; set; }

        public virtual bool showed { get; set; }

        [ForeignKey("DVKCBId")]
        //public virtual User User { get; set; }
        public virtual long DVKCBId { get; set; }
    }
}
