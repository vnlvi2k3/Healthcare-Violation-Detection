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
}
