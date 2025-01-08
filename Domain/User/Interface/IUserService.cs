using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Domain.User.Dto.Request;

namespace Domain.User.Interface
{
    public interface IUserService
    {
       
        Task<Result<List<Model.Entities.User>>> GetUsers();

        Task<Result<Model.Entities.User>> CreateUser(CreateUserRequestDto dto);

        Task<Result<Model.Entities.User>> UpdateUser(UpdateUserRequestDto dto);

        Task<Result<Model.Entities.User>> FindAsync(int id);

        Task<Result<Model.Entities.User>> Delete(int id);


    }
}
