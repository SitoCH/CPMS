using System;

namespace CPMS.Common.Entities
{
    public class JournalEntry
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Text { get; set; }

        public int JournalId { get; set; }
        public Journal Journal { get; set; }

        public int JournalEntryChannelId { get; set; }
        public JournalEntryChannel JournalEntryChannel { get; set; }
    }
}