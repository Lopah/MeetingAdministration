using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingAdministration.Data.Configurations
{
    public class MeetingCentreConfiguration : IEntityTypeConfiguration<MeetingCentre>
    {
        public void Configure(EntityTypeBuilder<MeetingCentre> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(300);

            builder.HasMany(r => r.MeetingRooms).WithOne(r => r.MeetingCentre);
        }
    }
}
