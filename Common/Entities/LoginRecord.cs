using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class LoginRecord : BaseEntity
    {
        public string LoginIP { get; set; }
        public string LoginLocation { get; set; }
        public DateTime LoginDate { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
