using CityEventsAPI.Domain.Entities;
using CityEventsAPI.Domain.Repositories;
using CityEventsAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CityEventsAPIDbContext _db;

        public UserRepository(CityEventsAPIDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.ApiUser_Email == email && x.ApiUser_Password == password);
        }
    }
}
