using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.DTOs
{
    public class UserAddDto
    {
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [DisplayName("Şifre")]
        public string UserPassword { get; set; }
    }
}
