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
        private readonly IHubContext<InterventionHub> _interventionHub;
        private readonly IJournalService _journalService;
        private readonly IMapper _mapper;

        public JournalsController(IJournalService journalService,
            IMapper mapper,
            IInterventionService interventionService,
            IHubContext<InterventionHub> interventionHub)
        {
            _journalService = journalService;
            _mapper = mapper;
            _interventionService = interventionService;
            _interventionHub = interventionHub;
        }

        [HttpGet("{interventionId}")]
        public ActionResult<List<JournalDto>> GetJournals(int interventionId)
        {
            return _mapper.Map<List<JournalDto>>(_journalService.GetAllByIntervention(interventionId));
        }

        [HttpPut("/Journals/{interventionId}")]
        public async void AddJournal(int interventionId, JournalDto journalDto)
        {
            var newJournal = _mapper.Map<Journal>(journalDto);
            newJournal.InterventionId = interventionId;
            _journalService.Add(newJournal);
            await _interventionHub.Clients.All.SendAsync("journalUpdated", interventionId, newJournal.Id);
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
                    ChannelIcon = x.JournalEntryChannel.Icon,
                    Person = x.Person,
                    Direction = x.Direction
                }).OrderByDescending(x => x.DateTime).ToArray()
            };
        }

        [HttpGet("/Journals/Channels/")]
        public ActionResult<List<JournalEntryChannelDto>> GetChannels()
        {
            return _mapper.Map<List<JournalEntryChannelDto>>(_journalService.GetChannels());
        }
    }
}
