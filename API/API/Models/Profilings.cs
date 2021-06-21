using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_m_profilings")]
    public class Profilings
    {
        [Key]
        public string NIK { get; set; }
        [JsonIgnore]
        public virtual Educations Educations { get; set; }
        [JsonIgnore]
        public virtual Accounts Accounts { get; set; }
    }
}
