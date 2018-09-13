using System;

namespace CPMS.Common.Entities
{
    public class JournalEntry
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public JournalEntryDirection Direction { get; set; }

        public int JournalId { get; set; }
        public virtual Journal Journal { get; set; }

        public int JournalEntryChannelId { get; set; }
        public virtual JournalEntryChannel JournalEntryChannel { get; set; }
    }
}
