namespace PrecioAPP.UseCases.Products.Create;

/// <summary>
/// Create a new Product.
/// </summary>
/// <param name="Name"></param>
public record CreateProductCommand(string Name, string Description, string Barcode, string Brand, string ImageUrl, string Unit) : Ardalis.SharedKernel.ICommand<Result<int>>;
