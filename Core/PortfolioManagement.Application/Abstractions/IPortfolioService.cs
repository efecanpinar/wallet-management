using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Abstractions
{
    public interface IPortfolioService
    {
        Task AddPortfolio(CreatePortfolioDto userAddDto);
        Task<List<Portfolio>> GetAllUserPortfolios(int userId);
        public Task<List<Portfolio>> GetUserPortfolio(int portfolioId);
    }
}
