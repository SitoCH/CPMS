using System;
using CPMS.Common.Entities;

namespace CPMS.Web.Dtos
{
    public class JournalEntryDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public int ChannelId { get; set; }

        public string JournalName { get; set; }

        public string Name { get; set; }

        public JournalEntryDirection Direction { get; set; }
    }
}
