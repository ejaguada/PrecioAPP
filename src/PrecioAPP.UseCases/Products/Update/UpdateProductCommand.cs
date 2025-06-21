namespace PrecioAPP.UseCases.Products.Update;

public record UpdateProductCommand(int ProductId, string NewName, string NewDescription, string NewBarcode, string NewBrand, string NewImageUrl, string NewUnit) : ICommand<Result<ProductDTO>>;
