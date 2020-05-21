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
    }
}
