using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class AccountHistory : BaseEntity
    {
        public string ProcessType { get; set; }
        public string Definition { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
