using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_m_accountrole")]
    public class AccountRole
    {
        public virtual Accounts Accounts { get; set; }
        public string AccountsId { get; set; }
        public virtual Roles Roles { get; set; }
        public int RolesId { get; set; }
    }
}
