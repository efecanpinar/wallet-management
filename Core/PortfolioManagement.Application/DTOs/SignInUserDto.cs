using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.DTOs
{
    public class SignInUserDto
    {
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        public string UserPassword { get; set; }
    }
}
