using PrecioAPP.Core.Interfaces;
using PrecioAPP.Core.Services;
using PrecioAPP.Infrastructure.Data;
using PrecioAPP.Infrastructure.Data.Queries;
using PrecioAPP.UseCases.Businesses.List;
using PrecioAPP.UseCases.Contributors.List;
using PrecioAPP.UseCases.Employees.List;
using PrecioAPP.UseCases.Products.List;


namespace PrecioAPP.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
           .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
           .AddScoped<IListContributorsQueryService, ListContributorsQueryService>()
           .AddScoped<IListBusinessesQueryService, ListBusinessesQueryService>()
           .AddScoped<IListEmployeesQueryService, ListEmployeesQueryService>()
           .AddScoped<IListProductsQueryService, ListProductsQueryService>()
           .AddScoped<IDeleteContributorService, DeleteContributorService>();


    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
