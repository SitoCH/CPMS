using System;

namespace CPMS.Web.Dtos
{
    public class JournalEntryDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Text { get; set; }

        public string ChannelIcon { get; set; }

        public string JournalName { get; set; }
    }
}
