using System.Collections.Generic;
using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;

namespace CPMS.Common.Services
{
    public interface IInterventionService
    {
        int Count();

        List<Intervention> GetInterventions();

        Intervention GetIntervention(int id);
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

        public List<Intervention> GetInterventions()
        {
            return _context.Interventions.ToList();
        }

        public Intervention GetIntervention(int id)
        {
            return _context.Interventions.SingleOrDefault(x => x.Id == id);
        }
    }
}
