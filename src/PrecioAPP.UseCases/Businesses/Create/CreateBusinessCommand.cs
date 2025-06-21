namespace PrecioAPP.UseCases.Businesses.Create;

/// <summary>
/// Create a new Business.
/// </summary>
/// <param name="Name"></param>
public record CreateBusinessCommand(string Name, string Description, string Address, int Longitude, int Latitude, string Phone, string Email, string Website, string LogoURL) : Ardalis.SharedKernel.ICommand<Result<int>>;
