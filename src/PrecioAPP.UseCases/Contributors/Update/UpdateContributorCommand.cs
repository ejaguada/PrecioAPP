namespace PrecioAPP.UseCases.Contributors.Update;

public record UpdateBusinessCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
