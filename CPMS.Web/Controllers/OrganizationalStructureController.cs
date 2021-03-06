﻿using System.Linq;
using CPMS.Common.EF;
using CPMS.Common.Entities;
using CPMS.Web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Web.Controllers
{
    [Authorize, ApiController, Route("[controller]")]
    public class OrganizationalStructureController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OrganizationalStructureController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        private static GroupDto ToGroupDto(Group group)
        {
            var groupDto = new GroupDto
            {
                Name = group.Name,
                Members = group.Users.Select(x => new MemberDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToArray(),
                Children = group.Children.Select(ToGroupDto).ToArray()
            };

            return groupDto;
        }

        [HttpGet]
        public ActionResult<OrganizationalStructureDto> GetOrganizationalStructure()
        {
            return new OrganizationalStructureDto
            {
                Groups = _dataContext.Groups.Where(x => !x.ParentId.HasValue).ToList().Select(ToGroupDto).ToArray()
            };
        }
    }
}
