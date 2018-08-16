using CPMS.Common.Services;
using CPMS.Web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IInterventionService _interventionService;

        public DashboardController(IUserService userService, IInterventionService interventionService)
        {
            _userService = userService;
            _interventionService = interventionService;
        }

        [HttpGet]
        public ActionResult<DashboardDto> GetDashboard()
        {
            return new DashboardDto
            {
                Users = _userService.Count(),
                Interventions = _interventionService.Count()
            };
        }
    }
}
