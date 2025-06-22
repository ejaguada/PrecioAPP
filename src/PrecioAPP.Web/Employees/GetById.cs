using PrecioAPP.UseCases.Employees.Get;

namespace PrecioAPP.Web.Employees;

/// <summary>
/// Get an Employee by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Employee record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetEmployeeByIdRequest, EmployeeRecord>
{
  public override void Configure()
  {
    Get(GetEmployeeByIdRequest.Route);
  }

  public override async Task HandleAsync(GetEmployeeByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetEmployeeQuery(request.EmployeeId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new EmployeeRecord(result.Value.Id, result.Value.UserId, result.Value.FullName, result.Value.BusinessId, result.Value.Role);
    }
  }
}
