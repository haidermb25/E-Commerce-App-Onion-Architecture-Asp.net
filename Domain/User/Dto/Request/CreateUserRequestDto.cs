using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Dto.Request
{
    public class CreateUserRequestDto
    {
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public required int roleId { get; set; }
    }
}
