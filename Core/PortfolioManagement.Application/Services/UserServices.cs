using PortfolioManagement.Application.Abstractions;
using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces;
using PortfolioManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(UserAddDto userAddDto)
        {
            await _unitOfWork.Users.AddAsync(new User
            {
                Name = userAddDto.Name,
                Surname = userAddDto.UserName,
                UserName = userAddDto.UserName,
                UserPassword = userAddDto.UserPassword,
                IsActive = true,
                IsDeleted = false

            });
            await _unitOfWork.SaveAsync();

        }

        public async Task<int> SignInUser(SignInUserDto signInUserDto)
        {
            return await
                _unitOfWork.Users.SignInUser(new User
                {
                    UserName = signInUserDto.UserName,
                    UserPassword = signInUserDto.UserPassword
                });

        }
    }
}