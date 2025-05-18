using Common;

namespace Domain.GeneralErrors;

public static class GeneralError
{
    public static Error Conflict(string entityType, string entityName) => Error.Conflict
      ("GeneralError.EntryExists",
      $"{entityType} - {entityName} is already in the database!");

    public static Error NoEntities(string entityType) => Error.NotFound($"{entityType}.NotFound", $"No {entityType} found in database!");

    public static Error NotFoundWithGuid(string entityType, Guid entityId) => Error.NotFound
      ($"{entityType}.NotFound",
      $"{entityType} with Id = '{entityId}' not found in database!");

    public static Error PostFailure(string entityType) => Error.Failure(
        $"{entityType}.PostFail",
        $"Post of entity: {entityType} failed!");

    public static Error UnexpectedError(string entityType) => Error.Failure(
      $"{entityType}.Ups",
      $"Operation with {entityType} failed!");
}