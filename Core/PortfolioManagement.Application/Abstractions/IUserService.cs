using PortfolioManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Abstractions
{
    public interface IUserService
    {
        Task Add(UserAddDto userAddDto);
        Task<int> SignInUser(SignInUserDto signInUserDto);
    }
}
