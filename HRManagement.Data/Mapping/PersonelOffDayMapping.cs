using HRManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Data.Mapping
{
    public class PersonelOffDayMapping : IEntityTypeConfiguration<PersonelOffDay>
    {
        public void Configure(EntityTypeBuilder<PersonelOffDay> builder)
        {
            builder.HasKey(a => new { a.PersonelID, a.OffDayID });
            builder.HasOne(a => a.Personel)
                .WithMany(b => b.PersonelOffDays)
                .HasForeignKey(a => a.PersonelID);
            builder.HasOne(a => a.OffDay)
                .WithMany(b => b.PersonelOffDays)
                .HasForeignKey(a => a.OffDayID);
        }
    }
}
