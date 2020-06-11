using EventService.BLL.Interfaces;
using EventService.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSevice.Api.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public IEnumerable<EventDto> GetAll() =>
            eventService.GetAll();

        [HttpPost]
        public void Create(EventDto eventDto) =>
            eventService.Create(eventDto);

        [HttpPut]
        public void UpdateEvent(EventDto eventDto) =>
            eventService.Update(eventDto);

        [HttpDelete]
        public void DeleteEvent(int id) =>
            eventService.Remove(id);
    }
}
