using HRManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Mapping
{
    public class PersonelMapping : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.HasIndex(a => a.Mail).IsUnique();
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.Mail).IsRequired();
            builder.Property(a => a.Password).IsRequired();
            //builder.Property(a => a.OffDay).IsRequired(false);
            //builder.Property(a => a.OffDayID).IsRequired(false);
            //builder.Property(a=>a.)


            builder.HasOne(a => a.Company).WithMany(a => a.Personels).HasForeignKey(a => a.CompanyID);
        }
    }
}
