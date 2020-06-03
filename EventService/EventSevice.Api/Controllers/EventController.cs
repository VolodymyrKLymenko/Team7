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
        private readonly ILogger<EventController> _logger;

        // TODO delete this. Only for mocking endpoint purpose
        private static int EventCounter = 100;

        private static List<EventResponse> events = new List<EventResponse>
        {
            new EventResponse
            {
                Id = 1,
                Title = "ЩО? ДЕ? КОЛИ?",
                Description = "ЩО? ДЕ? КОЛИ? А святкування до Дня Університету тривають… 12 жовтня в рамках цього у Львівському університеті відбулась, мабуть, найамбітніша і найочікуваніша гра «Що? Де? Коли?». В поєдинку зійшлись команди ректорату та студентського самоврядування. ",
                Location = "Main department Universitetska 1",
                StartDate = DateTime.Now.Add(new TimeSpan(48, 0, 0)),
                EndDate = DateTime.Now.Add(new TimeSpan(48, 50, 0)),
                Status = EventStatus.Pending,
                OrganizedUniversity = "LNU",
                SupportPhone = "+3809312412"
            },
            new EventResponse
            {
                Id = 2,
                Title = "КВЕСТ ДЛЯ ПЕРШОКУРСНИКІВ",
                Description = "Кожен першокурсник з нетерпінням очікує моменту посвяти в студенти. Цей своєрідний обряд дозволяє повністю усвідомити усю атмосферу університетського життя та поринути в неї. Креативні організатори намагаються якнайкраще відобразити усі привілеї студентського життя, створивши найдрайвовішу вечірку та різноманітні додатки до неї. ",
                Location = "Main department Universitetska 1",
                StartDate = DateTime.Now.Add(new TimeSpan(-24, 0, 0)),
                EndDate = DateTime.Now.Add(new TimeSpan(-23, 30, 0)),
                Status = EventStatus.Finished,
                OrganizedUniversity = "LNU",
                SupportPhone = "+3809312412"
            },
            new EventResponse
            {
                Id = 3,
                Title = "ФАНТАСТИЧНІ МАНДРИ",
                Description = "28 вересня у приміщенні Львівського національного університету імені Івана Франка відбулася зустріч з українським письменником-фантастом Максом Кідруком. В аудиторії яблуку ніде впасти. Ні-ні, до гарячої пори іспитів, модулів і заліків ще часу вдосталь. Причиною такого «ажіотажу» стала зустріч з Максом Кідруком. ",
                Location = "NULP main department",
                StartDate = DateTime.Now.Add(new TimeSpan(32, 0, 0)),
                EndDate = DateTime.Now.Add(new TimeSpan(32, 30, 0)),
                Status = EventStatus.Pending,
                OrganizedUniversity = "NULP",
                SupportPhone = "+38093512412"
            }
        };



        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventResponse>> GetAll()
        {
            return events.ToArray();
        }

        [HttpGet("{adminId}")]
        public ActionResult<IEnumerable<EventResponse>> GetForUser(int adminId)
        {
            return events.Where(e => e.OrganizedUniversity == "LNU").ToArray();
        }

        public class EventResponse
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string OrganizedUniversity { get; set; }
            public string SupportPhone { get; set; }
            public EventStatus Status { get; set; }
        }

        public enum EventStatus { Pending = 1, Finished, Cancelled }

        [HttpPost]
        public ActionResult<EventResponse> CreateEvent(CreateEventRequest request)
        {
            var newResponse =
                new EventResponse
                {
                    Id = EventCounter++,
                    Title = request.Title,
                    Description = request.Description,
                    Location = request.Location,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Status = EventStatus.Pending,
                    OrganizedUniversity = "LNU",
                    SupportPhone = "+3809312412"
                };

            var newList = new List<EventResponse> { newResponse };
            newList.AddRange(events);

            events = newList;

            return newResponse;
;
        }

        public class CreateEventRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Location { get; set; }
        }

        [HttpPut("{eventId}")]
        public ActionResult<EventResponse> UpdateEvent(int eventId, UpdateEventRequest request)
        {
            var index = events.FindIndex(e => e.Id == eventId);

            events[index].Description = request.Description;
            events[index].Location = request.Location;
            events[index].StartDate = request.StartDate;
            events[index].EndDate = request.EndDate;

            return
                new EventResponse
                {
                    Id = 2,
                    Title = request.Title,
                    Description = request.Description,
                    Location = request.Location,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Status = EventStatus.Pending,
                    OrganizedUniversity = "LNU",
                    SupportPhone = "+3809312412"
                };
        }

        public class UpdateEventRequest
        {
            public int EventId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Location { get; set; }
        }
    }
}
