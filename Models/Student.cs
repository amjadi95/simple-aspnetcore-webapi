using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class Student : DomainEntity
    {
        [Required]
        public string firstName { get; set; }  

        [Required]
        public string lastName { get; set; }

        [Required]
        public string stuCode { get; set; }

        public string enteranceYear { get; set; }
       
    }
}