using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductListingConfiguration : IEntityTypeConfiguration<ProductListing>
{
    public void Configure(EntityTypeBuilder<ProductListing> builder)
    {
        builder.ToTable("ProductListings").HasKey(pl => pl.Id);

        builder.Property(pl => pl.Id).HasColumnName("Id").IsRequired();
        builder.Property(pl => pl.Title).HasColumnName("Title").IsRequired();
        builder.Property(pl => pl.Price).HasColumnName("Price").IsRequired();
        builder.Property(pl => pl.PriceCurrency).HasColumnName("PriceCurrency").IsRequired();
        builder.Property(pl => pl.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(pl => pl.Description).HasColumnName("Description").IsRequired();
        builder.Property(pl => pl.Status).HasColumnName("Status").IsRequired();
        builder.Property(pl => pl.NewOrUsed).HasColumnName("NewOrUsed").IsRequired();
        builder.Property(pl => pl.LicenseStatus).HasColumnName("LicenseStatus").IsRequired();
        builder.Property(pl => pl.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(pl => pl.DistrictId).HasColumnName("DistrictId").IsRequired();
        builder.Property(pl => pl.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(pl => pl.TypeId).HasColumnName("TypeId").IsRequired();
        builder.Property(pl => pl.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(pl => pl.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(pl => pl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pl => pl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pl => pl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pl => !pl.DeletedDate.HasValue);
    }
}