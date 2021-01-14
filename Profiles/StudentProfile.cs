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
            CreateMap<StudentReadDto,Student>();  
            CreateMap<StudentCreateDto,Student>();  
            CreateMap<StudentUpdateDto,Student>();  

        }
    }
}