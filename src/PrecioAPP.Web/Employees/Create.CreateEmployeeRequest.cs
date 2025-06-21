using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Employees;

public class CreateEmployeeRequest
{
  public const string Route = "/Employees";

  [Required]
  public int UserId { get; set; }
  public string? FullName { get; set; }
  public int BusinessId { get; set; }
  public string? Role { get; set; }

}
