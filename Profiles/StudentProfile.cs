using AutoMapper;
using ApiServer.Dtos;
using ApiServer.Models;
namespace ApiServer.Profiles
{
    public class PersonsProfile : Profile
    {
        public PersonsProfile() 
        {
            CreateMap<Student,StudentReadDto>();
            
        }
    }
}