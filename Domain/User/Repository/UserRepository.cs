using Domain.User.Interface;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Model.Entities.User>> GetUsers()
        {
            var result=await _dbContext.users.ToListAsync();
            return result;
        }
        public async Task<Model.Entities.User> SaveUser(Model.Entities.User user)
        {
            if (user.userId == 0)
            {
                await _dbContext.users.AddAsync(user);
            }
            else
            {
                 _dbContext.users.Update(user);   
            }
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Model.Entities.User> FindAsync(int id)
        {
            return await _dbContext.users.FirstOrDefaultAsync(x=>x.userId==id);
        }


        public async Task<Model.Entities.User> Delete(Model.Entities.User user)
        {
           _dbContext.users.Remove(user);
            await _dbContext.SaveChangesAsync();    
            return user;    
        }
    }
}
