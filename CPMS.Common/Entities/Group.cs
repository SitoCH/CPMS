using System.Collections.Generic;

namespace CPMS.Common.Entities
{
    public class Group
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int SectionId { get; set; }
        public Section Section { get; set; }
        
        public List<User> Users { get; set; }
    }
}