using CrudCustomers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCustomers.DataContext.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(e => e.Customer)
                .WithMany(c => c.Emails)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}

