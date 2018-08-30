using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.Common.Entities
{
    public class Intervention
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        [InverseProperty("Intervention")]
        public virtual List<Journal> Journals { get; set; }
    }
}
