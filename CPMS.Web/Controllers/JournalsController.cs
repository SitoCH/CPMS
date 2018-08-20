using System.Collections.Generic;
using AutoMapper;
using CPMS.Common.Entities;
using CPMS.Common.Services;
using CPMS.Web.Dtos;
using CPMS.Web.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CPMS.Web.Controllers
{
    [Authorize, ApiController, Route("[controller]")]
    public class JournalsController : ControllerBase
    {
        private readonly IJournalService _journalService;
        private readonly IMapper _mapper;

        public JournalsController(IJournalService journalService, IMapper mapper)
        {
            _journalService = journalService;
            _mapper = mapper;
        }

        [HttpGet("{intervention}")]
        public ActionResult<List<JournalDto>> GetJournals(int intervention)
        {
            return _mapper.Map<List<JournalDto>>(_journalService.GetAllByIntervention(intervention));
        }
    }
}
