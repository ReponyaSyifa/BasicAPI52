using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_m_universities")]
    public class Universities
    {
        [Key]
        public string UniId { get; set; }
        public string UniName { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Educations> Educations { get; set; }
    }
}
