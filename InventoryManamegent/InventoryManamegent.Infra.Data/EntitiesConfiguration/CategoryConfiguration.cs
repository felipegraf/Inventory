using InventoryManamegent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManamegent.Infra.Data.EntitiesConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Cnpj).HasMaxLength(14).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(99).IsRequired();
        }
    }
}
