using Employment.Domain.Entities;
using Employment.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Persistence.Configurations
{
    internal sealed class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.ToTable(TableNames.Vacancies);

            builder.HasKey(c => c.Id);

            builder.HasOne(v => v.Employer)
                .WithMany(e => e.Vacancies)
                .HasForeignKey(v => v.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(v => v.Location)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(v => v.MaxApplications)
                .IsRequired();

            builder.Property(v => v.ExpiryDate)
                .IsRequired();

            builder.Property(v => v.Status)
                .IsRequired();

            builder.Property(v => v.CreatedOnUtc)
                .IsRequired();

            builder.Property(v => v.ModifiedOnUtc)
                .IsRequired(false);

            builder.HasIndex(v => v.EmployerId);
            builder.HasIndex(v => v.Title);
            builder.HasIndex(v => v.ExpiryDate);
        }
    }
}
