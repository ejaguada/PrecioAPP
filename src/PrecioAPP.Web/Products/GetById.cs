using PrecioAPP.UseCases.Products.Get;

namespace PrecioAPP.Web.Products;

/// <summary>
/// Get a Product by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Product record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetProductByIdRequest, ProductRecord>
{
  public override void Configure()
  {
    Get(GetProductByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetProductByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetProductQuery(request.ProductId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ProductRecord(
        result.Value.Id,
        result.Value.Name,
        result.Value.Description,
        result.Value.Barcode,
        result.Value.Brand,
        result.Value.ImageUrl,
        result.Value.Unit);
    }
  }
}
