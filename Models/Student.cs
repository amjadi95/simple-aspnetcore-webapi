using System.ComponentModel.DataAnnotations;
using System;

namespace ApiServer.Models
{
    public class Student : DomainEntity
    {
        public Student() 
        {
            createdDate = DateTime.Now;
        }

        [Required]
        public string firstName { get; set; }  

        [Required]
        public string lastName { get; set; }
        public string stuCode { get; set; }

        public string enteranceYear { get; set; }
        
        public DateTime createdDate { get; set; }
       
    }
}