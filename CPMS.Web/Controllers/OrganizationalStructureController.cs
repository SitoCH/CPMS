using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CPMS.Common.EF;
using CPMS.Common.Entities;
using CPMS.Common.Migrations;
using CPMS.Common.Services;
using CPMS.Common.Utils;
using CPMS.Web.Dtos;
using CPMS.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CPMS.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrganizationalStructureController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OrganizationalStructureController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        private GroupDto ToGroupDto(Group group)
        {
            var groupDto = new GroupDto
            {
                Name = group.Name,
                Members = group.Users?.Select(x => new MemberDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList(),
                Groups = group.Groups?.Select(ToGroupDto).ToList()
            };

            return groupDto;
        }

        [HttpGet]
        public ActionResult<OrganizationalStructureDto> GetOrganizationalStructure()
        {
            return new OrganizationalStructureDto
            {
                Groups = _dataContext.Groups.Where(x => !x.ParentId.HasValue).ToList().Select(ToGroupDto).ToList()
            };
        }
    }
}
