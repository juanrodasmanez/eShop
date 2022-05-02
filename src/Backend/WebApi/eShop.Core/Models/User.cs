using eShop.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
