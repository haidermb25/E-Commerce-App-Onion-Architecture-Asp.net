using Domain.User.Dto.Request;
using Model.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Interface
{
    public interface IUserRepository
    {
        Task<List<Model.Entities.User>> GetUsers();

        Task<Model.Entities.User> SaveUser(Model.Entities.User user);

        Task<Model.Entities.User> FindAsync(int id);

        Task<Model.Entities.User> Delete(Model.Entities.User user);
    }
}
