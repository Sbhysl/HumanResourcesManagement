using HRManagement.Data.Entities;
using HRManagement.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data
{
    public class HRDbContext :DbContext
    {
       
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
            
        }

        public DbSet<Personel> Personels { get; set; }
        public DbSet<PublicHolidays> PublicHolidays { get; set; }
        public DbSet<PersonelOffDay> PersonelOffDays { get; set; }
        public DbSet<OffDay> OffDays { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonelMapping());
            modelBuilder.ApplyConfiguration(new PersonelOffDayMapping());
            modelBuilder.ApplyConfiguration(new OffDayMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new SuggestionMapping());
            base.OnModelCreating(modelBuilder);
          
            
        }
    }
}
