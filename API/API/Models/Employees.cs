using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public enum Gender
    {
        Male =1, Female=2
    }

    [Table("tb_m_employees")]
    public class Employees
    {
        [Key] //untuk sign sbg primary key
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        //[JsonIgnore]
        public virtual Accounts Accounts { get; set; }

        //table transaksi -> identik dengan 
        //table m -> table master
        //table 

    }
}
