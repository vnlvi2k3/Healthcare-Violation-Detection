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
<<<<<<< HEAD
            var douglas = _context.VanBanPhapLys.FirstOrDefault(p => p.emailAddress == "douglas.adams@fortytwo.com");

            if (douglas == null)
            {
                _context.VanBanPhapLys.Add(
                    new VanBanPhapLy
                    {
                        name = "Douglas",
                        surname = "Adams",
                        emailAddress = "douglas.adams@fortytwo.com"
                    });
            }

            var asimov = _context.VanBanPhapLys.FirstOrDefault(p => p.emailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.VanBanPhapLys.Add(
                    new VanBanPhapLy
                    {
                        name = "Isaac",
                        surname = "Asimov",
                        emailAddress = "isaac.asimov@foundation.org"
                    });
            }
        }
    }
}
