using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EventSevice.Api.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventResponse>> GetAll()
        {
            return
                new[]
                {
                    new EventResponse
                    {
                        Id = 1,
                        Title = "Event1",
                        Description = "SGSA gas gpA goahg hA LGha:L Gha:LS GH;LASH Gl;ASH G;LAS HG;laSH G;laS Hgl;aSH gl;aH SG",
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
                        Title = "Event2",
                        Description = "Event2 a gaskg jalg a;lg halhg ;lAH G;laSH G;lAShg ;laH g;lash g;lash g;lashg ;lasg h",
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
                        Title = "Event3",
                        Description = "aslb as; hal gla glkash glsa hglash glaj glksh gldsh glh dsgl hsdl ghs;dg h",
                        Location = "Mars plannet",
                        StartDate = DateTime.Now.Add(new TimeSpan(32, 0, 0)),
                        EndDate = DateTime.Now.Add(new TimeSpan(32, 30, 0)),
                        Status = EventStatus.Pending,
                        OrganizedUniversity = "NULP",
                        SupportPhone = "+38093512412"
                    }
                };
        }

        [HttpGet("{adminId}")]
        public ActionResult<IEnumerable<EventResponse>> GetForUser(int adminId)
        {
            return
                new[]
                {
                    new EventResponse
                    {
                        Id = 1,
                        Title = "Event1",
                        Description = "SGSA gas gpA goahg hA LGha:L Gha:LS GH;LASH Gl;ASH G;LAS HG;laSH G;laS Hgl;aSH gl;aH SG",
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
                        Title = "Event2",
                        Description = "Event2 a gaskg jalg a;lg halhg ;lAH G;laSH G;lAShg ;laH g;lash g;lash g;lashg ;lasg h",
                        Location = "Main department Universitetska 1",
                        StartDate = DateTime.Now.Add(new TimeSpan(-24, 0, 0)),
                        EndDate = DateTime.Now.Add(new TimeSpan(-23, 30, 0)),
                        Status = EventStatus.Finished,
                        OrganizedUniversity = "LNU",
                        SupportPhone = "+3809312412"
                    }
                };
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
    }
}
