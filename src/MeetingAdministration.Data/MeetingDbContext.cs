using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeetingAdministration.Data
{
    public class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions<MeetingDbContext> options)
            : base(options)
        {

        }
        public DbSet<MeetingCentre> MeetingCentres { get; set; }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(MeetingDbContext)));
        }
    }
}
