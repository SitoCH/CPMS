﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CPMS.Common.Entities;
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
