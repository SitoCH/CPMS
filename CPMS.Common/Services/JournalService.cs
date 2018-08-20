using System.Collections.Generic;
using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;

namespace CPMS.Common.Services
{
    public interface IJournalService
    {
        List<Journal> GetAllByIntervention(int intervention);
    }

    public class JournalService : IJournalService
    {
        private readonly DataContext _context;

        public JournalService(DataContext context)
        {
            _context = context;
        }

        public List<Journal> GetAllByIntervention(int intervention)
        {
            return _context.Journals.Where(x => x.InterventionId == intervention).ToList();
        }
    }
}
