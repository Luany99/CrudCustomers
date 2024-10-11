using CrudCustomers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCustomers.DataContext.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Phones)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}

