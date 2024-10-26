using Employment.Domain.Entities;
using Employment.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Persistence.Configurations
{
    internal sealed class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable(TableNames.Applications);

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Vacancy)
                .WithMany(v => v.Applications)
                .HasForeignKey(a => a.VacancyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Applicant)
                .WithMany(ap => ap.Applications)
                .HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.CreatedOnUtc)
                .IsRequired();

            builder.Property(a => a.ModifiedOnUtc)
                .IsRequired(false);

            builder.HasIndex(a => a.VacancyId);
            builder.HasIndex(a => a.ApplicantId);
        }
    }
}
