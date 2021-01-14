using ApiServer.Models;
namespace ApiServer.Dtos
{
    public class StudentReadDto : DomainEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string stuCode { get; set; }
    }
}