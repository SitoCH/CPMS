using System;
using CPMS.Common.Entities;

namespace CPMS.Web.Dtos
{
    public class JournalEntryDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Text { get; set; }

        public string ChannelIcon { get; set; }

        public string ChannelName { get; set; }

        public string JournalName { get; set; }

        public string Person { get; set; }

        public JournalEntryDirection Direction { get; set; }
    }
}
