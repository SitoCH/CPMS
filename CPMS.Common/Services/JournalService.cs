using System.Collections.Generic;
using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;

namespace CPMS.Common.Services
{
    public interface IJournalService
    {
        List<Journal> GetAllByIntervention(int intervention);

        Journal Get(int journalId);

        List<JournalEntry> GetJournalEntries(int interventionId, int journalId);

        List<JournalEntryChannel> GetChannels();

        Journal Add(Journal journal);
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

        public Journal Get(int journalId)
        {
            return _context.Journals.SingleOrDefault(x => x.Id == journalId);
        }

        public List<JournalEntry> GetJournalEntries(int interventionId, int journalId)
        {
            var intervention = _context.Interventions.SingleOrDefault(x => x.Id == interventionId);
            if (journalId == 0)
            {
                return intervention.Journals.SelectMany(x => x.JournalEntries).ToList();
            }

            return intervention.Journals.Where(x => x.Id == journalId).SelectMany(x => x.JournalEntries).ToList();
        }

        public List<JournalEntryChannel> GetChannels()
        {
            return _context.JournalEntryChannels.ToList();
        }

        public Journal Add(Journal journal)
        {
            var newJournal = _context.Journals.Add(journal);
            _context.SaveChanges();
            return newJournal.Entity;
        }
    }
}
