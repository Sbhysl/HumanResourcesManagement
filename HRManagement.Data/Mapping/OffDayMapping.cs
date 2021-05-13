using HRManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Mapping
{
    public class OffDayMapping : IEntityTypeConfiguration<OffDay>
    {
        public void Configure(EntityTypeBuilder<OffDay> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.StartDate).IsRequired(false);
            builder.Property(a => a.EndDate).IsRequired(false);
            builder.Property(a => a.OffDayLimit).IsRequired(false);

        }
    }
}
