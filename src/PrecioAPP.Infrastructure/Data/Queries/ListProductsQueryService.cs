using PrecioAPP.UseCases.Employees;
using PrecioAPP.UseCases.Employees.List;
using PrecioAPP.UseCases.Products;
using PrecioAPP.UseCases.Products.List;

namespace PrecioAPP.Infrastructure.Data.Queries;

public class ListProductsQueryService(AppDbContext _db) : IListProductsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<ProductDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<ProductDTO>(
      $"SELECT Id, Name, Description, Barcode, Brand, ImageUrl, Unit FROM Products") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
