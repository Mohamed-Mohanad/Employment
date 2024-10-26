using Employment.Domain.Entities;
using Employment.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Persistence.Configurations
{
    internal sealed class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable(TableNames.Employers);

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.CreatedOnUtc)
                .IsRequired();

            builder.Property(e => e.ModifiedOnUtc)
                .IsRequired(false);

            builder.HasIndex(e => e.UserId);
            builder.HasIndex(e => e.CompanyId);
        }
    }
}
