using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Employees;

public class UpdateEmployeeRequest
{
  public const string Route = "/Employees/{EmployeeId:int}";
  public static string BuildRoute(int employeeId) => Route.Replace("{EmployeeId:int}", employeeId.ToString());

  public int EmployeeId { get; set; }
  public string? FullName { get; set; }
  public int BusinessId { get; set; }
  public string? Role { get; set; }
}
