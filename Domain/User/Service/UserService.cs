using Core.Errors;
using Domain.User.Dto.Request;
using Domain.User.Interface;
using Domain.User.Mapping;
using Domain.User.Repository;
using Domain.User.Validator;
using FluentResults;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Service
{
    public class UserService(IUserRepository repository):IUserService
    {

        public async Task<Result<List<Model.Entities.User>>> GetUsers()
        {
            var users=await repository.GetUsers();

            if (users == null || !users.Any())
            {
                return Result.Fail("No user Found");
            }

            return Result.Ok(users);
        }


        

        public async Task<Result<Model.Entities.User>> CreateUser(CreateUserRequestDto dto)
        {
            var validator=new CreateUserValidator();
            var result =await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return Result.Fail(new DomainValidationError(result.Errors));
            }
            return Result.Ok(await repository.SaveUser(dto.Map()));
        }

        public async Task<Result<Model.Entities.User>> UpdateUser(UpdateUserRequestDto dto)
        {
            var validator = new UpdateUserValidator(this);
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                // Collect the error messages from validation
                return Result.Fail(new DomainPrimaryEntityNotFoundError($"User not Found"));
            }
            var userResult=validator.userValue;
           
            return Result.Ok(await repository.SaveUser(userResult.Map(dto)));
        }


        public async Task<Result<Model.Entities.User>> FindAsync(int id)
        {
            var user = await repository.FindAsync(id);
            if(user is null)
            {
                return Result.Fail(new DomainPrimaryEntityNotFoundError($"User with {id} not found"));
            }
            return Result.Ok(user);
        }


        public async Task<Result<Model.Entities.User>> Delete(int id)
        {
            var userResult=await FindAsync(id);
            if (userResult.IsFailed)
            {
                return Result.Fail(userResult.Errors.First().Message);
            }
            return Result.Ok(await repository.Delete(userResult.Value));
        }
    }
}

