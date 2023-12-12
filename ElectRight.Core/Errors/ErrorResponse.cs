namespace ElectRight.Core.Errors;
public record ErrorResponse(string Error, string Details, string StackTrace, IEnumerable<ValidationError> ValidationErrors);