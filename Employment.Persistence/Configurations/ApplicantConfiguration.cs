using Employment.Domain.Entities;
using Employment.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Persistence.Configurations
{
    internal sealed class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable(TableNames.Applicants);

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.ResumeUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasMany(a => a.Applications)
                .WithOne(ap => ap.Applicant)
                .HasForeignKey(ap => ap.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.CreatedOnUtc)
                .IsRequired();

            builder.Property(a => a.ModifiedOnUtc)
                .IsRequired(false);

            builder.HasIndex(a => a.UserId);
            builder.HasIndex(a => a.ResumeUrl);
        }
    }
}
