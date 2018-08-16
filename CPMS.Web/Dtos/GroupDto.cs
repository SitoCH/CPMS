using System.Collections.Generic;

namespace CPMS.Web.Dtos
{
    public class GroupDto
    {
        public string Name { get; set; }

        public List<GroupDto> Children { get; set; } = new List<GroupDto>();

        public List<MemberDto> Members { get; set; } = new List<MemberDto>();
    }
}
