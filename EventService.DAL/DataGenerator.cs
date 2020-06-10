using System;
using System.Linq;
using EventService.DAL.Context;
using EventService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.DAL
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {
                // Look for any board games.
                if (context.Events.Any())
                {
                    return;   // Data was already seeded
                }

                context.Events.AddRange(
                    new Event
                    {
                        Id = 1,
                        Title = "ЩО? ДЕ? КОЛИ?",
                        Description = "ЩО? ДЕ? КОЛИ? А святкування до Дня Університету тривають… 12 жовтня в рамках цього у Львівському університеті відбулась, мабуть, найамбітніша і найочікуваніша гра «Що? Де? Коли?». В поєдинку зійшлись команди ректорату та студентського самоврядування. ",
                        Location = "Main department Universitetska 1",
                        StartDateTime = DateTime.Now.Add(new TimeSpan(48, 0, 0)),
                        FinishDateTime = DateTime.Now.Add(new TimeSpan(48, 50, 0)),
                        EventStatus =
                            new EventStatus
                            {
                                Description = "Waiting for beggining",
                                Id = 1,
                                Name = "Pending"
                            },
                        EventStatusId = 1,
                        Faculty =
                            new Faculty
                            {
                                Id = 1,
                                Name = "Applied Mathematic",
                                PhoneNumber = "+3809.....",
                                University =
                                    new University
                                    {
                                        Id = 1,
                                        Location = "Main department Universitetska 1",
                                        Name = "LNU"
                                    },
                                UniversityId = 1
                            },
                        FacultyId = 1
                    },
                    new Event
                    {
                        Id = 2,
                        Title = "КВЕСТ ДЛЯ ПЕРШОКУРСНИКІВ",
                        Description = "Кожен першокурсник з нетерпінням очікує моменту посвяти в студенти. Цей своєрідний обряд дозволяє повністю усвідомити усю атмосферу університетського життя та поринути в неї. Креативні організатори намагаються якнайкраще відобразити усі привілеї студентського життя, створивши найдрайвовішу вечірку та різноманітні додатки до неї. ",
                        Location = "Main department Universitetska 1",
                        StartDateTime = DateTime.Now.Add(new TimeSpan(-24, 0, 0)),
                        FinishDateTime = DateTime.Now.Add(new TimeSpan(-23, 30, 0)),
                        EventStatus =
                            new EventStatus
                            {
                                Description = "Event is finished",
                                Id = 2,
                                Name = "Passed"
                            },
                        EventStatusId = 2,
                        Faculty =
                            new Faculty
                            {
                                Id = 2,
                                Name = "Physician faculty",
                                PhoneNumber = "+3808.....",
                                UniversityId = 1
                            },
                        FacultyId = 2
                    },
                    new Event
                    {
                        Id = 3,
                        Title = "ФАНТАСТИЧНІ МАНДРИ",
                        Description = "28 вересня у приміщенні Львівського національного університету імені Івана Франка відбулася зустріч з українським письменником-фантастом Максом Кідруком. В аудиторії яблуку ніде впасти. Ні-ні, до гарячої пори іспитів, модулів і заліків ще часу вдосталь. Причиною такого «ажіотажу» стала зустріч з Максом Кідруком. ",
                        Location = "Main department Universitetska 1",
                        StartDateTime = new DateTime(2019, 9, 28, 12, 30, 0),
                        FinishDateTime = new DateTime(2019, 9, 28, 14, 30, 0),
                        EventStatusId = 2,
                        Faculty =
                            new Faculty
                            {
                                Id = 3,
                                Name = "Biological faculty",
                                PhoneNumber = "+3807.....",
                                UniversityId = 1
                            },
                        FacultyId = 3
                    });

                context.SaveChanges();
            }
        }
    }
}
