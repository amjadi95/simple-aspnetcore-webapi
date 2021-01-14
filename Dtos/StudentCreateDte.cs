using ApiServer.Models;
namespace ApiServer.Dtos
{
    public class StudentCreateDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string stuCode { get; set; }
    }
}