namespace PrecioAPP.UseCases.Businesses.Update;

public record UpdateBusinessCommand(int BusinessId, string NewName, string NewDescription, string NewAddress, int NewLongitude, int NewLatitude,  string NewEmail, string NewWebsite, string NewLogoURL) : ICommand<Result<BusinessDTO>>;
