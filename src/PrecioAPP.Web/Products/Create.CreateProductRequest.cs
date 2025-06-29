﻿using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Products;

public class CreateProductRequest
{
  public const string Route = "/Products";

  [Required]
  public string? Name { get; set; }
  public string? Description { get; set; }
  public string? Barcode { get; set; }
  public string? Brand { get; set; }
  public string? ImageUrl { get; set; }
  public string? Unit { get; set; }

}
