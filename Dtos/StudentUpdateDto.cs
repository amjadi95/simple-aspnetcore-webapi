using System.ComponentModel.DataAnnotations;
using ApiServer.Models;
namespace ApiServer.Dtos
{
    public class StudentUpdateDto 
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        public string enteranceYear { get; set; }
    }
}