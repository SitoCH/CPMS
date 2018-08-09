using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;

namespace CPMS.Common.Services
{
    public interface IDatabaseSeederService
    {
        void Seed();
    }

    public class DatabaseSeederService : IDatabaseSeederService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public DatabaseSeederService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public void Seed()
        {
            if (!_context.Users.Any())
            {
                var group = new Group
                {
                    Name = "Regione X"
                };

                _context.Groups.Add(group);

                _userService.Create(new User
                {
                    Username = "admin",
                    FirstName = "-",
                    LastName = "-",
                    Group = group
                }, "admin", 1);
            }
        }
    }
}