using ApiServer.Models;
namespace ApiServer.Dtos
{
    public class StudentReadDto : DomainEntity
    {
        public string lastName { get; set; }
        public string stuCode { get; set; }
    }
}