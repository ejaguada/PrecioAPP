
using PrecioAPP.UseCases.Products.List;


namespace PrecioAPP.Web.Products;

/// <summary>
/// List all Products
/// </summary>
/// <remarks>
/// List all products - returns a ProductListResponse containing the Products.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<ProductListResponse>
{
  public override void Configure()
  {
    Get("/Products");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListProductsQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new ProductListResponse
      {
        Products = result.Value.Select(c => new ProductRecord(c.Id, c.Name, c.Description, c.Barcode, c.Brand, c.ImageUrl, c.Unit)).ToList()
      };
    }
  }
}
