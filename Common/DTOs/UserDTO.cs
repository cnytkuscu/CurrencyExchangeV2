using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{ 
    public class UserDTO : BaseDTO
    {
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        //public string CurrencyCode { get; set; }
        //public int CurrencyNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
