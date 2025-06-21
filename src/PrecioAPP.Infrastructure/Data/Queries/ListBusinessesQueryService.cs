using PrecioAPP.UseCases.Businesses.List;
using PrecioAPP.UseCases.Businesses;

namespace PrecioAPP.Infrastructure.Data.Queries;

public class ListBusinessesQueryService(AppDbContext _db) : IListBusinessesQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<BusinessDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<BusinessDTO>(
      $"SELECT Id, Name, Description, Address, Longitude, Latitude, Phone, Email, Website, LogoURL FROM Businesses") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
