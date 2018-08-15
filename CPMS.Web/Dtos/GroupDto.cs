using System.Collections.Generic;

namespace CPMS.Web.Dtos
{
    public class GroupDto
    {
        public string Name { get; set; }

        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();

        public List<MemberDto> Members { get; set; } = new List<MemberDto>();
    }
}
