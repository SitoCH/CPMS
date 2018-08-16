namespace CPMS.Web.Dtos
{
    public class GroupDto
    {
        public string Name { get; set; }

        public GroupDto[] Children { get; set; }

        public MemberDto[] Members { get; set; }
    }
}
