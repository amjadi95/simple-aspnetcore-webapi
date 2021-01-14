using System.ComponentModel.DataAnnotations;

namespace ApiServer.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }
        public string enteranceYear { get; set; }
    }
}