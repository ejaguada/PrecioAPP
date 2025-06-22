using PrecioAPP.UseCases.BusinessProducts.Get;
using PrecioAPP.UseCases.BusinessProducts.Update;

namespace PrecioAPP.Web.BusinessProducts;

/// <summary>
/// Update an existing Business Product.
/// </summary>
/// <remarks>
/// Update an existing Business Product by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateBusinessProductRequest, UpdateBusinessProductResponse>
{
  public override void Configure()
  {
    Put(UpdateBusinessProductRequest.Route);
  }

  public override async Task HandleAsync(
    UpdateBusinessProductRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateBusinessProductCommand(request.BusinessId, request.ProductId, request.CurrentPrice, request.PreviousPrice, request.Stock, request.IsAvailable), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetBusinessProductQuery(request.BusinessProductId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateBusinessProductResponse(new BusinessProductRecord(dto.Id, dto.BusinessId, dto.ProductId, dto.CurrentPrice, dto.PreviousPrice, dto.Stock, dto.IsAvailable));
      return;
    }
  }
}
