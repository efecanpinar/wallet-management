using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.DTOs
{
    public class CreatePortfolioDto
    {
        [DisplayName("Portföy Adı")]
        public string PortfolioName { get; set; }
        public int UserId { get; set; }
    }
}
