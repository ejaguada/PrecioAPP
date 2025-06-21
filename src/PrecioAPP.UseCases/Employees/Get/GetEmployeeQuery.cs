namespace PrecioAPP.UseCases.Employees.Get;

public record GetEmployeeQuery(int EmployeeId) : IQuery<Result<EmployeeDTO>>;
