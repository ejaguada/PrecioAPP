namespace PrecioAPP.UseCases.Employees.List;

public record ListEmployeesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<EmployeeDTO>>>;
