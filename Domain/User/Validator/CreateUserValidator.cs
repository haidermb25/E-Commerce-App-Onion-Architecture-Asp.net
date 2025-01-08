using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using Domain.User.Dto.Request;


namespace Domain.User.Validator
{
    public class CreateUserValidator:AbstractValidator<CreateUserRequestDto>
    {
      public CreateUserValidator() 
        {
            RuleFor(x=>x.userName).NotEmpty();
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty().MinimumLength(8);
        }  
    }
}
