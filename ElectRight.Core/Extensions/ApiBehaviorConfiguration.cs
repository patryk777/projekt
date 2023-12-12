using ElectRight.Core.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ElectRight.Core.Extensions;
public static class ApiBehaviorConfiguration
{
    private const string ValidationError = "ValidationError";

    public static void Configure(this ApiBehaviorOptions options)
    {
        options.InvalidModelStateResponseFactory = ErrorHandlingResponseFactory;
    }

    private static Func<ActionContext, IActionResult> ErrorHandlingResponseFactory =>
        context =>
        {
            var errors = new List<ValidationError>();
            foreach (var (property, entry) in context.ModelState)
            {
                errors.AddRange(entry.Errors.Select(error => new ValidationError(property, error.ErrorMessage)));
            }

            var error = new ErrorResponse(ValidationError, string.Empty, string.Empty, errors);

            return new BadRequestObjectResult(error);
        };
}
