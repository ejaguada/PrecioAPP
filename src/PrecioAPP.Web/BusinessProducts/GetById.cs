using PrecioAPP.UseCases.BusinessProducts.Get;

namespace PrecioAPP.Web.BusinessProducts;

/// <summary>
/// Get a Business Product by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Business Product record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetBusinessProductByIdRequest, BusinessProductRecord>
{
  public override void Configure()
  {
    Get(GetBusinessProductByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetBusinessProductByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetBusinessProductQuery(request.BusinessProductId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new BusinessProductRecord(result.Value.Id, result.Value.BusinessId, result.Value.ProductId, result.Value.CurrentPrice, result.Value.PreviousPrice, result.Value.Stock, result.Value.IsAvailable);
    }
  }
}
