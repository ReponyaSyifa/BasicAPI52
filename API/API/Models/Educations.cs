using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_m_educations")]
    public class Educations
    {
        [Key]
        public string EducationId { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        [JsonIgnore]
        public virtual Universities Universities { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profilings> Profilings { get; set; }
    }

    //cukup bikin 1 repository
    //1 interface
    //1 controller
    //repository pattern/ generic repository pattern
    //ngoding sekali, selanjutnya tinggal ngewarisin aja class parent nya
}
