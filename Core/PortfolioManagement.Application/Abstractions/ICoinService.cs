using PortfolioManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Abstractions
{
    public interface ICoinService
    {
        Task<int> AddCoin(CreateTransactionDto addCoinDto);
    }
}
