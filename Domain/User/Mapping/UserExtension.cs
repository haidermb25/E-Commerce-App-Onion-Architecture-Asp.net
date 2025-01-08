using Domain.User.Dto.Request;
using Domain.User.Dto.Response;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Mapping
{
    public static class UserExtension
    {
        public static UserResponseDto MapToResponseDto(this Model.Entities.User user)
        {
            return new UserResponseDto()
            {
                userId=user.userId,
                userName=user.userName,
                Email=user.Email,
                Password=user.passwordHash,
                roleId=user.RoleId
            };
        }

        public static List<UserResponseDto> MapToResponseDto(this List<Model.Entities.User> user)
        {
            return user.Select(MapToResponseDto).ToList();  
        }

        public static Model.Entities.User Map(this CreateUserRequestDto dto)
        {
            return new Model.Entities.User()
            {
                userName = dto.userName,
                Email = dto.Email,
                passwordHash=dto.Password,
                RoleId=dto.roleId,
                createdAt=DateTime.UtcNow,
            };
        }

        public static Model.Entities.User Map(this Model.Entities.User user,UpdateUserRequestDto dto)
        {
            if (!dto.userName.IsNullOrEmpty()) 
            {
                user.userId = dto.userId;
            }
            if (!dto.userName.IsNullOrEmpty())
            {
                user.userName = dto.userName;    
            }
            if(!dto.email.IsNullOrEmpty())
            {
                user.Email= dto.email;   
            }
            if (!dto.password.IsNullOrEmpty())
            {
                user.passwordHash = dto.password;
            }
            if (!dto.roleId.ToString().IsNullOrEmpty())
            {
                user.RoleId = dto.roleId;
            } 
            return user;    
        }
    }
}
