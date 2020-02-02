using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingAdministration.Data.Configurations
{
    public class MeetingsPlanningConfiguration : IEntityTypeConfiguration<MeetingsPlanning>
    {
        public void Configure(EntityTypeBuilder<MeetingsPlanning> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Customer)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.MeetingRoom).WithOne(r => r.MeetingsPlanning)
                .IsRequired();

            builder.Property(e => e.TimeFrom)
                .IsRequired();

            builder.Property(e => e.TimeTo)
                .IsRequired();

            builder.Property(e => e.Note)
                .HasMaxLength(300);
        }
    }
}