using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class AccountLoginDTO : BaseDTO
    {
        [Required]
        public string AccountUsername { get; set; }
        [Required]
        public string AccountPassword { get; set; }
    }
}
