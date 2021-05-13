using HRManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Data.Mapping
{
    class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd().UseIdentityColumn(1,1);
            builder.Property(a => a.Adress).IsRequired(false);
            builder.Property(a => a.CompanyName).IsRequired(false);
            builder.Property(a => a.Logo).IsRequired(false);

            builder.HasMany<Suggestion>(a => a.Suggestions)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyID);



        }
    }
}
