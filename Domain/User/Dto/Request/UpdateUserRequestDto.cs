using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Dto.Request
{
    public class UpdateUserRequestDto
    {
        public int userId { get; set; }
        public string email { get; set; }   
        public string userName { get; set; }
        public string password { get; set; }    
        public int roleId { get; set; }

    }
}
