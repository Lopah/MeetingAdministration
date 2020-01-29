using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingAdministration.Data.Configurations
{
    public class MeetingRoomConfiguration : IEntityTypeConfiguration<MeetingRoom>
    {
        public void Configure(EntityTypeBuilder<MeetingRoom> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Code)
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(300);

            builder.Property(x => x.Capacity)
                .HasMaxLength(100);

            builder.HasOne(e => e.MeetingCentre).WithMany(r => r.MeetingRooms);
        }
    }
}
