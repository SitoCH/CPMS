using System.Collections.Generic;

namespace CPMS.Common.Entities
{
    public class Company
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Section> Sections { get; set; }
    }
}