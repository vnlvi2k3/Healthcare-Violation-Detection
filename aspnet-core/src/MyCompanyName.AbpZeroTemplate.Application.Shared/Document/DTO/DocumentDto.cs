using Abp.Application.Services.Dto;
using System;
using Abp.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;


namespace MyCompanyName.AbpZeroTemplate.MyDocument.DTO
{
    public class GetDocumentInput
    {
        public string Filter { get; set; }
    }

    public class DocumentListDto : FullAuditedEntityDto
    {
        public  string code { get; set; }

        
        public  string title { get; set; }

       
        public  string description { get; set; }

        public  DateTime validation { get; set; }

        public  DateTime expiration { get; set; }

        public  bool published { get; set; }

        public string fullText { get; set; }

        public  bool approved { get; set; }

        public  string medical_product { get; set; }

        public  string province { get; set; }

        public  bool showed { get; set; }

        // public User User { get; set; }
        public long DVKCBId { get; set; }
    }
}
