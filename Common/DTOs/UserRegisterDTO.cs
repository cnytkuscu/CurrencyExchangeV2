using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class UserRegisterDTO : BaseDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OwnerName { get; set; }
        public string Mail { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
