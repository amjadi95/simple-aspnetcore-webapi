using System.Collections.Generic;
using ApiServer.Data;
using ApiServer.Dtos;
using ApiServer.Models;

namespace ApiServer.Services
{
    public interface IStudentService : IGenericRepo<Student>
    {
        StudentReadDto AddStudent(StudentCreateDto student);
        bool DeleteStudent(int id);
        Student GetStudentById(int id);
        IEnumerable<StudentReadDto> GetAllStudent();
        StudentReadDto UpdateStudent( int id,StudentUpdateDto student);
    }
}