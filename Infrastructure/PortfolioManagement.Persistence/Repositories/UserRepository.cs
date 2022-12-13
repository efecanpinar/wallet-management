using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces.Repository;
using PortfolioManagement.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> SignInUser(User user)
        {

            var result = await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName.Equals(user.UserName) && x.UserPassword.Equals(user.UserPassword));
            if (result != null)
            {
                return result.Id;
            }
            return -1;
        }
    }
}
