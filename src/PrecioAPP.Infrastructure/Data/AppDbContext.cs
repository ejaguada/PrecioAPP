using PrecioAPP.Core.BusinessAggregate;
using PrecioAPP.Core.BusinessProductAggregate;
using PrecioAPP.Core.ContributorAggregate;
using PrecioAPP.Core.EmployeeAggregate;
using PrecioAPP.Core.ProductAggregate;

namespace PrecioAPP.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options,
  IDomainEventDispatcher? dispatcher) : DbContext(options)
{
  private readonly IDomainEventDispatcher? _dispatcher = dispatcher;

  public DbSet<Contributor> Contributors => Set<Contributor>();

  public DbSet<Business> Businesses => Set<Business>();

  public DbSet<Employee> Employees => Set<Employee>();

  public DbSet<Product> Products => Set<Product>();

  public DbSet<BusinessProduct> BusinessProducts => Set<BusinessProduct>();
  

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<HasDomainEventsBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();
}
