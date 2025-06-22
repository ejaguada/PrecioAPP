namespace PrecioAPP.UseCases.BusinessProducts.Create;

/// <summary>
/// Create a new Business Product.
/// </summary>
/// <param name="Name"></param>
public record CreateBusinessProductCommand(int BusinessId, int ProductId, decimal CurrentPrice, decimal PreviousPrice, int Stock, bool IsAvailable) : Ardalis.SharedKernel.ICommand<Result<int>>;
