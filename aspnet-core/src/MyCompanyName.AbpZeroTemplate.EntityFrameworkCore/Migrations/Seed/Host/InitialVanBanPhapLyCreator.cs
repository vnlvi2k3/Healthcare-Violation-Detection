using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.LegalText;
using System.Linq;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialVanBanPhapLyCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialVanBanPhapLyCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.VanBanPhapLys.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.VanBanPhapLys.Add(
                    new VanBanPhapLy
                    {
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com"
                    });
            }

            var asimov = _context.VanBanPhapLys.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.VanBanPhapLys.Add(
                    new VanBanPhapLy
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org"
                    });
            }
        }
    }
}
