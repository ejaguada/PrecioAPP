using PrecioAPP.UseCases.Contributors;
using PrecioAPP.UseCases.Businesses;
using PrecioAPP.UseCases.Businesses.List;
using PrecioAPP.Web.Businesses;
using PrecioAPP.UseCases.BusinessProducts.List;
using PrecioAPP.UseCases.BusinessProducts;

namespace PrecioAPP.Web.BusinessProducts;

/// <summary>
/// List all Business Products
/// </summary>
/// <remarks>
/// List all business products - returns a BusinessProductListResponse containing the Business Products.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<BusinessProductListResponse>
{
  public override void Configure()
  {
    Get("/BusinessProducts");
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListBusinessProductsQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new BusinessProductListResponse
      {
        BusinessProducts = result.Value.Select(bp => new BusinessProductRecord(
          bp.Id,
          bp.BusinessId,
          bp.ProductId,
          bp.CurrentPrice,
          bp.PreviousPrice,
          bp.Stock,
          bp.IsAvailable)).ToList()
      };
    }
  }
}
