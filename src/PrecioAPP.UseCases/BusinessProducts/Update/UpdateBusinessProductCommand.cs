namespace PrecioAPP.UseCases.BusinessProducts.Update;

public record UpdateBusinessProductCommand(int BusinessProductId, int NewProductId, decimal NewCurrentPrice, decimal NewPreviousPrice, int NewStock, bool NewIsAvailable) : ICommand<Result<BusinessProductDTO>>;
