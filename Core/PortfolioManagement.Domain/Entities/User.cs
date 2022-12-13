using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities
{
    public class User : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string UserPassword { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; }

    }
}
