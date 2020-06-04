using EventService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventService.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventAction> EventActions { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().HasData(
                new University[]
                {
                    new University { Id = 1, Name = "Ivan Franko National University of Lviv", Location = "Universytetska St, 1, Lviv, L'vivs'ka oblast, 79000"},
                    new University { Id = 2, Name = "Lviv Polytechnic National University", Location = "Stepana Bandery St, 12, Lviv, Lviv Oblast, 79000"},
                    new University { Id = 3, Name = "Taras Shevchenko National University of Kyiv", Location = "Volodymyrska St, 60, Kyiv, 01033"},
                    new University { Id = 4, Name = "National Technical University of Ukraine", Location = "Peremohy Ave, 37, Kyiv, 03056"},
                    new University { Id = 5, Name = "Odessa I.I.Mechnikov National University", Location = "Dvoryans'ka St, 2, Odesa, Odessa Oblast, 65000"}
                });

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty[]
                {
                    new Faculty { Id = 1, Name = "Faculty of Applied Mathematics and Informatics", UniversityId = 1, PhoneNumber = "+38 032 239-47-27"},
                    new Faculty { Id = 2, Name = "Faculty of Mechanics and Mathematics", UniversityId = 1, PhoneNumber = "+38 032 239-41-74"}
                });

            modelBuilder.Entity<EventStatus>().HasData(
                new EventStatus[]
                {
                    new EventStatus { Id = 1, Name = "Started", Description = "The event was started" },
                    new EventStatus { Id = 2, Name = "Finished", Description = "The event was finished" },
                    new EventStatus { Id = 3, Name = "Declined", Description = "The event was declined" }
                });
        }
    }
} 
