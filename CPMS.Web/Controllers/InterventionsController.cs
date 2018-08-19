using System.Collections.Generic;
using AutoMapper;
using CPMS.Common.Entities;
using CPMS.Common.Services;
using CPMS.Web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Web.Controllers
{
    [Authorize, ApiController, Route("[controller]")]
    public class InterventionsController : ControllerBase
    {
        private readonly IInterventionService _interventionService;
        private readonly IMapper _mapper;

        public InterventionsController(IInterventionService interventionService, IMapper mapper)
        {
            _interventionService = interventionService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<InterventionDto>> GetInterventions()
        {
            return _mapper.Map<List<InterventionDto>>(_interventionService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<InterventionDetailDto> GetIntervention(int id)
        {
            return new InterventionDetailDto
            {
                Intervention = _mapper.Map<InterventionDto>(_interventionService.Get(id))
            };
        }

        [HttpPut]
        public void AddIntervention(InterventionDto interventionDto)
        {
            var newIntervention = _mapper.Map<Intervention>(interventionDto);
            _interventionService.Add(newIntervention);
        }
    }
}
