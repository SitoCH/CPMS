using System.Collections.Generic;

namespace CPMS.Common.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        public Group Parent { get; set; }

        public List<Group> Groups { get; set; }

        public List<User> Users { get; set; }
    }
}
