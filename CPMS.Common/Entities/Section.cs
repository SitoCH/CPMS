using System.Collections.Generic;

namespace CPMS.Common.Entities
{
    public class Section
    {
        public int Id { get; set; }
          
        public string Name { get; set; }
        
        public List<Group> Groups { get; set; }
        
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}