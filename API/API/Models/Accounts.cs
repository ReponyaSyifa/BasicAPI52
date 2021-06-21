using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_m_accounts")]
    public class Accounts
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }
        //[JsonIgnore]
        public virtual Profilings Profilings { get; set; }
        //[JsonIgnore]
        public virtual Employees Employees { get; set; }
    }
}
