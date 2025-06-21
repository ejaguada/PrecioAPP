using PrecioAPP.Core.BusinessAggregate;
using PrecioAPP.Core.EmployeeAggregate;

namespace PrecioAPP.UseCases.Employees.Update;

public class UpdateEmployeeHandler(IRepository<Employee> _repository)
  : ICommandHandler<UpdateEmployeeCommand, Result<EmployeeDTO>>
{
  public async Task<Result<EmployeeDTO>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
  {
    var existingEmployee = await _repository.GetByIdAsync(request.EmployeeId, cancellationToken);
    if (existingEmployee == null)
    {
      return Result.NotFound();
    }

    existingEmployee.UpdateFullName(request.NewFullName!);
    existingEmployee.UpdateBusinessId(request.NewBusinessId);
    existingEmployee.UpdateRole(request.NewRole!);

    await _repository.UpdateAsync(existingEmployee, cancellationToken);

    return new EmployeeDTO(
      existingEmployee.Id,
      existingEmployee.UserId,
      existingEmployee.FullName,
      existingEmployee.BusinessId,
      existingEmployee.Role
    );
  }
}
