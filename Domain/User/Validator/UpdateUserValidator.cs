using Domain.User.Dto.Request;
using Domain.User.Interface;
using FluentResults;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Validator
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserRequestDto>
    {
        private readonly IUserService _userService;
        public UpdateUserValidator(IUserService userService) 
        {
            _userService = userService;
            RuleFor(x => x.userName).NotEmpty();
            RuleFor(x => x.email).NotEmpty();
            RuleFor(x => x.userId).MustAsync(async (id, cancellation) =>userExist(id)).WithMessage("User Does not Exist");
            
        }

        //Entity to store the user value

        public Model.Entities.User? userValue { get; set; }
        public bool userExist(int id)
        {
            var userResult = _userService.FindAsync(id).Result; // Wait for the result synchronously (use with caution)
            if (userResult.IsSuccess)
            {
                userValue = userResult.Value; // Safely access the value
                return true;
            }
            else
            {
                userValue = null; // Handle the case where the user is not found
                return false;
            }
        }

    }
}
