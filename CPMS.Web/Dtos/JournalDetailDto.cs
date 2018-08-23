using System.Collections.Generic;

namespace CPMS.Web.Dtos
{
    public class JournalDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public InterventionDto Intervention { get; set; }

        public List<JournalEntryDto> Entries { get; set; }
    }
}
