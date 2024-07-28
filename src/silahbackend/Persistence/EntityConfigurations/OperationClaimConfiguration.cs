using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Provinces.Constants;
using Application.Features.Districts.Constants;
using Application.Features.Brands.Constants;
using Application.Features.Models.Constants;
using Application.Features.ProductTypes.Constants;
using Application.Features.ProductListings.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Categories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Provinces CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ProvincesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProvincesOperationClaims.Read },
                new() { Id = ++lastId, Name = ProvincesOperationClaims.Write },
                new() { Id = ++lastId, Name = ProvincesOperationClaims.Create },
                new() { Id = ++lastId, Name = ProvincesOperationClaims.Update },
                new() { Id = ++lastId, Name = ProvincesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Districts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Read },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Write },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Create },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Update },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Brands CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ProductTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ProductTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProductTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = ProductTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = ProductTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = ProductTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = ProductTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ProductListings CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ProductListingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProductListingsOperationClaims.Read },
                new() { Id = ++lastId, Name = ProductListingsOperationClaims.Write },
                new() { Id = ++lastId, Name = ProductListingsOperationClaims.Create },
                new() { Id = ++lastId, Name = ProductListingsOperationClaims.Update },
                new() { Id = ++lastId, Name = ProductListingsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Brands CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Brands CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
