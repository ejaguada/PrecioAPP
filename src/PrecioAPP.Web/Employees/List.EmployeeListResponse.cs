using PrecioAPP.UseCases.Employees;

namespace PrecioAPP.Web.Employees;

public class EmployeeListResponse
{
  public List<EmployeeRecord> Employees { get; set; } = new();
} 
