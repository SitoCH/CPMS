using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.Common.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual Group Parent { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<Group> Children { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
