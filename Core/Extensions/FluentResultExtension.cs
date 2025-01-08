using Core.Errors;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http; 

namespace Core.Extensions
{
    public static class FluentResultExtension
    {
        public static List<string> Messages(this FluentResults.Result result)
        {
            var errors = result.Errors.Select(x => x switch
            {
                DomainValidationError e => e.Errors.Select(x => x.ErrorMessage),
                _ => new[] { x.Message }
            }).ToList();
            return errors.SelectMany(x => x).ToList();
        }

        public static List<string> Messages<T>(this FluentResults.Result<T> result)
        {
            var errors = result.Errors.Select(x => x switch
            {
                DomainValidationError e => e.Errors.Select(x => x.ErrorMessage),
                _ => new[] { x.Message }
            }).ToList();
            return errors.SelectMany(x => x).ToList();
        }

        public static IResult MapToErrorResponse<T>(this FluentResults.Result<T> result)
        {
            if (result.HasError<DomainValidationError>() && result.HasError<DomainPrimaryEntityNotFoundError>())
            {
                throw new InvalidOperationException("Expecting to handle both validation and " +
                    "primary entity not found errors at the same time is impractical." +
                    $" Try using {nameof(SecondaryEntityNotFoundError)} instead.");
            }

            if (result.HasError<DomainPrimaryEntityNotFoundError>())
            {
                var error = result.Errors.OfType<DomainPrimaryEntityNotFoundError>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.NotFound(errorDocument); // Ensure Results is accessible
            }
            else if (result.HasError<DomainNotFoundErrorDocument>())
            {
                var error = result.Errors.OfType<DomainNotFoundErrorDocument>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.NotFound(errorDocument);
            }
            else if (result.HasError<DomainForbiddenErrorDocument>())
            {
                var error = result.Errors.OfType<DomainForbiddenErrorDocument>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.Forbidden,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.StatusCode((int)HttpStatusCode.Forbidden);
            }
            else if (result.HasError<DomainUnauthorizedErrorDocument>())
            {
                var error = result.Errors.OfType<DomainUnauthorizedErrorDocument>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.Unauthorized,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.Unauthorized();
            }
            else
            {
                var errors = result.Errors.Where(x => x.GetType() != typeof(DomainPrimaryEntityNotFoundError)).ToList();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = HttpStatusCode.BadRequest.ToString(),
                };

                foreach (var error in errors)
                {
                    errorDocument.AddError(error);
                }

                return Results.BadRequest(errorDocument);
            }
        }


        public static IResult MapToErrorResponse(this FluentResults.Result result)
        {
            if (result.HasError<DomainValidationError>() && result.HasError<DomainPrimaryEntityNotFoundError>())
            {
                throw new InvalidOperationException("Expecting to handle both validation and " +
                    "primary entity not found errors at the same time is impractical." +
                    $" Try using {nameof(SecondaryEntityNotFoundError)} instead.");
            }

            if (result.HasError<DomainPrimaryEntityNotFoundError>())
            {
                var error = result.Errors.OfType<DomainPrimaryEntityNotFoundError>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.NotFound(errorDocument); // Ensure Results is accessible
            }
            else if (result.HasError<DomainNotFoundErrorDocument>())
            {
                var error = result.Errors.OfType<DomainNotFoundErrorDocument>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.NotFound(errorDocument);
            }
            else if (result.HasError<DomainForbiddenErrorDocument>())
            {
                var error = result.Errors.OfType<DomainForbiddenErrorDocument>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.Forbidden,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.StatusCode((int)HttpStatusCode.Forbidden);
            }
            else if (result.HasError<DomainUnauthorizedErrorDocument>())
            {
                var error = result.Errors.OfType<DomainUnauthorizedErrorDocument>().First();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.Unauthorized,
                    Title = error.Type,
                };
                errorDocument.AddError(error);
                return Results.Unauthorized();
            }
            else
            {
                var errors = result.Errors.Where(x => x.GetType() != typeof(DomainPrimaryEntityNotFoundError)).ToList();
                var errorDocument = new DomainErrorDocument
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = HttpStatusCode.BadRequest.ToString(),
                };

                foreach (var error in errors)
                {
                    errorDocument.AddError(error);
                }

                return Results.BadRequest(errorDocument);
            }
        }
    }
}
