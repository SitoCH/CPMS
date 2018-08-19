using System.Collections.Generic;
using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;

namespace CPMS.Common.Services
{
    public interface IInterventionService
    {
        int Count();

        List<Intervention> GetAll();

        Intervention Get(int id);

        void Add(Intervention newIntervention);
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

        public List<Intervention> GetAll()
        {
            return _context.Interventions.ToList();
        }

        public Intervention Get(int id)
        {
            return _context.Interventions.SingleOrDefault(x => x.Id == id);
        }

        public void Add(Intervention intervention)
        {
            _context.Interventions.Add(intervention);
            _context.SaveChanges();
        }
    }
}
