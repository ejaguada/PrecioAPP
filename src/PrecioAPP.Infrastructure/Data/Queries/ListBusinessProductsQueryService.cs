using PrecioAPP.UseCases.BusinessProducts;
using PrecioAPP.UseCases.BusinessProducts.List;
using PrecioAPP.UseCases.Contributors;
using PrecioAPP.UseCases.Contributors.List;

namespace PrecioAPP.Infrastructure.Data.Queries;

public class ListBusinessProductsQueryService(AppDbContext _db) : IListBusinessProductsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<BusinessProductDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<BusinessProductDTO>(
      $"SELECT Id, BusinessId, ProductId, CurrentPrice, PreviousPrice, Stock, IsAvailable FROM BusinessProducts") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
