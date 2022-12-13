using Microsoft.Extensions.DependencyInjection;
using PortfolioManagement.Application.Abstractions;
using PortfolioManagement.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.Interfaces;
using System.Transactions;
using PortfolioManagement.Application.Services;
using PortfolioManagement.Domain.Interfaces.Repository;
using PortfolioManagement.Persistence.Repositories;

namespace PortfolioManagement.Persistence
{
    public static class DependencyHandler
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<PortfolioManagementDbContext>(options => options.UseSqlServer("Server=localhost;Database=PortfolioManagement;User Id=sa;Password=Password1;Trusted_Connection=False;Connect Timeout=30;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=False"));

            services.AddDbContext<PortfolioManagementDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IPortfolioService, PortfolioServices>();
            services.AddScoped<IWalletService, WalletServices>();
            services.AddScoped<ICoinService, CoinServices>();
            services.AddScoped<ICoinWalletService, CoinWalletServices>();
            services.AddScoped<ITransactionService, TransactionServices>();

            services.AddScoped<HttpClient>();
        }
    }
}
