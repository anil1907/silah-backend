using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;


namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("BaseDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        services.AddScoped<IProductListingRepository, ProductListingRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        return services;
    }
}
