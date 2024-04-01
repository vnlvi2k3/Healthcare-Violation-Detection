using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompanyName.AbpZeroTemplate.MyDocument.DTO
{
    public class GetDocumentInput
    {
        public string Filter { get; set; }
    }

    public class DocumentListDto : FullAuditedEntityDto
    {
        public string Title { get; set; }

        public string code { get; set; }

        public string description { get; set; }

        public DateTime validation { get; set; }

        public DateTime expiration { get; set; }

        public bool published { get; set; }

        public string fullText { get; set; }

        public bool approved { get; set; }

        public string medical_product { get; set; }

        public string province { get; set; }

        public bool showed { get; set; }
        //public User User { get; set; }
        public long DVKCBId { get; set; }
    }

    public class CreateDocumentInput
    {
        [Required]
        [MaxLength(20)]
        public virtual string title { get; set; } // tiêu đề

        [Required]
        [MaxLength(20)]
        public virtual string code { get; set; } // số hiệu văn bản (e.g: 2401/QĐ-BGDĐT, 4433/BYT-KCB)

        [MaxLength(20)]
        public virtual string docType { get; set; } // loại văn bản

        public virtual DateTime publishDate { get; set; } // ngày ban hành

        public virtual DateTime validation { get; set; } // ngày hiệu lực

        public virtual DateTime expiration { get; set; } // ngày hết hiệu lực

        [MaxLength(20)]
        public virtual string publishPlace { get; set; } // nơi ban hành

        [MaxLength(20)]
        public virtual string recipient { get; set; } // người nhận

        [MaxLength(20)]
        public virtual string approver { get; set; } // người duyệt

        [MaxLength(20)]
        public virtual string signer { get; set; } // người ký

        [MaxLength(20)]
        public virtual string status { get; set; } // trạng thái

        [MaxLength(200)]
        public virtual string description { get; set; } // trích yếu

        public virtual string fullText { get; set; } // toàn văn
    }
}
