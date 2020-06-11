using AutoMapper;
using EventService.BLL.Models;
using EventService.DAL.Entities;
using EventService.DAL.Interfaces;
using EventSevice.Api.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using EventServiceClass = EventService.BLL.Services.EventService;

namespace EventService.Tests
{
    public class EventControllerTest
    {
        [Fact]
        public void GetAll()
        {
            var repositoriesMock = new Mock<IGenericRepository<Event>>();
            var mockedEvents = GenerateEvents();
            repositoriesMock.Setup(repo => repo.Get()).Returns(mockedEvents);
            var mapper = new Mock<IMapper>();
            var eventService = new EventServiceClass(repositoriesMock.Object, mapper.Object);
            var eventController = new EventController(eventService);
            var result = eventController.GetAll();

            Assert.IsAssignableFrom<IEnumerable<EventDto>>(result);
            Assert.Equal(mockedEvents.Count(), result.Count());
        }

        [Fact]
        public void Create()
        {
            var repositoriesMock = new Mock<IGenericRepository<Event>>();
            var mockedEvents = GenerateEvents();
            var eventObject = new Event();
            repositoriesMock.Setup(repo => repo.Create(eventObject)).Verifiable();
            repositoriesMock.Setup(repo => repo.Get()).Returns(mockedEvents);
            var mapper = new Mock<IMapper>();
            var eventService = new EventServiceClass(repositoriesMock.Object, mapper.Object);
            var eventController = new EventController(eventService);
            eventController.Create(mapper.Object.Map<EventDto>(eventObject));
            var result = eventController.GetAll();

            Assert.Equal(mockedEvents.Count(), result.Count() );
        }

        [Fact]
        public void Remove()
        {
            var repositoriesMock = new Mock<IGenericRepository<Event>>();
            var mockedEvents = GenerateEvents();
            repositoriesMock.Setup(repo => repo.Remove(1)).Verifiable();
            repositoriesMock.Setup(repo => repo.Get()).Returns(mockedEvents);
            var mapper = new Mock<IMapper>();
            var eventService = new EventServiceClass(repositoriesMock.Object, mapper.Object);
            var eventController = new EventController(eventService);
            eventController.DeleteEvent(1);
            var result = eventController.GetAll();

            Assert.Equal(mockedEvents.Count(), result.Count());
        }

        public IEnumerable<Event> GenerateEvents() =>
            new List<Event>
            {
                new Event { Id = 1 },
                new Event { Id = 2 },
                new Event { Id = 3 },
                new Event { Id = 4 },
                new Event { Id = 5 },
            };

        private void CreateMethodMock(Event eventObject, List<Event> events) =>
            events.Add(eventObject);
    }
}
