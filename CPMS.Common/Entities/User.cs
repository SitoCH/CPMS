namespace CPMS.Common.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
