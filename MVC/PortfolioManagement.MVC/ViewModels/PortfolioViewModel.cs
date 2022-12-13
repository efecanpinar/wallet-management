using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;

namespace PortfolioManagement.MVC.ViewModels
{
    public class PortfolioViewModel
    {
        public CreatePortfolioDto createPortfolioDto { get; set; }
        public bool CheckPortfolioPartial { get; set; } = false;
        public List<Portfolio> UserPortfolioes { get; set; }
        public int PortfolioId { get; set; }
        public List<CreateTransactionDto> Coins { get; set; }
        public CreateTransactionDto CreateTransactionDto { get; set; }
        public List<CoinWalletJoin> CoinWallets { get; set; }
    }
}
