using System;
using CPMS.Common.Entities;

namespace CPMS.Web.Dtos
{
    public class NewJournalEntryDto
    {
        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public JournalEntryDirection Direction { get; set; }

        public int JournalEntryChannelId { get; set; }
    }
}
