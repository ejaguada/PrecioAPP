using PrecioAPP.Core.EmployeeAggregate;

namespace PrecioAPP.UseCases.Employees.Create;

public class CreateEmployeeHandler(IRepository<Employee> _repository)
  : ICommandHandler<CreateEmployeeCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateEmployeeCommand request,
    CancellationToken cancellationToken)
  {
    var newEmployee = new Employee(request.UserId, request.FullName, request.BusinessId, request.Role);
    var createdItem = await _repository.AddAsync(newEmployee, cancellationToken);

    return createdItem.Id;
  }
}
