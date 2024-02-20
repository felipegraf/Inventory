using InventoryManamegent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManamegent.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Description).HasMaxLength(99).IsRequired();
            builder.Property(p => p.Asset).IsRequired();
            builder.Property(p => p.CreationAt).IsRequired();
            builder.Property(p => p.ExpirationAt).IsRequired();
        }

    }
}
