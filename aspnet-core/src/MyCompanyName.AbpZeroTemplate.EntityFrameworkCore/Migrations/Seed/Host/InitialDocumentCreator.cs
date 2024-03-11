using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.MyDocument;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;


namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    internal class InitialDocumentCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialDocumentCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var doc0 = _context.Documents.FirstOrDefault(p => p.title == "document0");
            if (doc0 == null)
            {
                _context.Documents.Add(
                    new Document
                    {
                        Id = 1,
                        title = "document0",
                        description = "This is doc0",
                        DVKCBId = 12345,
                        code = "24680",
                    }) ;
            }

            var doc1 = _context.Documents.FirstOrDefault(p => p.title == "document1");
            if (doc1 == null)
            {
                _context.Documents.Add(
                    new Document
                    {
                        Id = 2,
                        title = "document1",
                        description = "This is doc1",
                        DVKCBId = 67890,
                        code = "13579",
                    }) ;
            }
        }
    }
}
