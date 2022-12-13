using PortfolioManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Abstractions
{
    public interface ITransactionService
    {
        Task<bool> ManageTransaction(CreateTransactionDto addCoinDto, int instancePortfolioId);
        Task AddTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId);
    }
}
