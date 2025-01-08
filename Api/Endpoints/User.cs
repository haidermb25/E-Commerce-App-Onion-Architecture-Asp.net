using Core.Extensions;
using Domain.User.Dto.Request;
using Domain.User.Interface;
using Domain.User.Mapping;
using FluentResults;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Api.Endpoints
{
    public static class User
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder route)
        {
            route.MapGet("/api/users", async (IUserService service) =>
            {
                var result = await service.GetUsers();

                return result.IsSuccess
                    ? Results.Ok(result.Value.MapToResponseDto()) 
                    : Results.BadRequest(result.Errors);
            });

            route.MapPost("/api/users", async (CreateUserRequestDto dto, IUserService service) =>
            {
                var result = await service.CreateUser(dto);
                if (result.IsSuccess)
                {
                    return Results.Ok(result.Value.MapToResponseDto());
                }

                return result.MapToErrorResponse(); 
            });

            route.MapPatch("api/users", async (UpdateUserRequestDto dto, IUserService service) =>
            {
                var result = await service.UpdateUser(dto);
                if (result.IsSuccess)
                {
                    return Results.Ok(result.Value.MapToResponseDto());
                }
                return result.MapToErrorResponse();
            });
            route.MapDelete("api/users/{id}", async (int id, IUserService service) =>
            {
                var result = await service.Delete(id);
                if (result.IsSuccess)
                {
                    return Results.Ok(result.Value.MapToResponseDto());
                }
                return result.MapToErrorResponse();
            });

        }
    }
}
