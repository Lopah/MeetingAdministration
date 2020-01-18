using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasAnnotation("MinLength", new { Length = 2, ErrorMessage = $"The name of the room has to have atleast 2 characters." })
                .HasMaxLength(100);

            builder.Property(x => x.Code)
                .HasAnnotation("MinLength", new { Length = 5, ErrorMessage = $"The code of the room has to have atleast 5 characters." })
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasAnnotation("MinLength", new { Length = 10, ErrorMessage = $"The description of the room has to have atleast 10 characters." })
                .HasMaxLength(300);
        }
    }
}
