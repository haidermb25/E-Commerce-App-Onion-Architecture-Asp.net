using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Dto.Response
{
    public class UserResponseDto
    {
        public required int userId {  get; set; }
        public required string userName {  get; set; }   
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int roleId { get; set; }
    }
}
