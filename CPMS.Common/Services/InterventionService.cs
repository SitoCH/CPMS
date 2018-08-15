using System.Linq;
using CPMS.Common.EF;

namespace CPMS.Common.Services
{
    public interface IInterventionService
    {
        int Count();
    }

    public class InterventionService : IInterventionService
    {
        private readonly DataContext _context;

        public InterventionService(DataContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Interventions.Count();
        }
    }
}
