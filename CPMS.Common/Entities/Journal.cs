using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.Common.Entities
{
    public class Journal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InterventionId { get; set; }
        public virtual Intervention Intervention { get; set; }

        [InverseProperty("Journal")]
        public virtual List<JournalEntry> JournalEntries { get; set; }
    }
}
