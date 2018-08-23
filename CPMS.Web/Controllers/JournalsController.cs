using System.Collections.Generic;
using System.Linq;
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
        private readonly IInterventionService _interventionService;
        private readonly IJournalService _journalService;
        private readonly IMapper _mapper;

        public JournalsController(IJournalService journalService, IMapper mapper, IInterventionService interventionService)
        {
            _journalService = journalService;
            _mapper = mapper;
            _interventionService = interventionService;
        }

        [HttpGet("{intervention}")]
        public ActionResult<List<JournalDto>> GetJournals(int intervention)
        {
            return _mapper.Map<List<JournalDto>>(_journalService.GetAllByIntervention(intervention));
        }

        [HttpGet("/Journals/Detail/{interventionId}/{journalId}")]
        public ActionResult<JournalDetailDto> GetJournalDetail(int interventionId, int journalId)
        {
            var id = 0;
            var name = string.Empty;
            InterventionDto intervention;
            if (journalId > 0)
            {
                var journal = _journalService.Get(journalId);
                id = journal.Id;
                name = journal.Name;
                intervention = _mapper.Map<InterventionDto>(journal.Intervention);
            }
            else
            {
                intervention = _mapper.Map<InterventionDto>(_interventionService.Get(interventionId));
            }

            return new JournalDetailDto
            {
                Id = id,
                Name = name,
                Intervention = intervention,
                Entries = _journalService.GetJournalEntries(interventionId, journalId).Select(x => new JournalEntryDto
                {
                    Id = x.Id,
                    JournalName = x.Journal.Name,
                    Text = x.Text,
                    DateTime = x.DateTime,
                    ChannelIcon = x.JournalEntryChannel.Icon
                }).OrderByDescending(x => x.DateTime).ToList()
            };
        }

        [HttpGet("/Journals/Channels/")]
        public ActionResult<List<JournalEntryChannelDto>> GetChannels()
        {
            return _mapper.Map<List<JournalEntryChannelDto>>(_journalService.GetChannels());
        }
    }
}
