using System;
using System.Collections.Generic;
using ApiServer.Data;
using ApiServer.Dtos;
using ApiServer.Models;
using AutoMapper;

namespace ApiServer.Services
{
    public class StudentService : SqlGenericRepo<Student>, IStudentService
    {
        private readonly IMapper _mapper;

        public StudentService(AppDbContext context) : base(context)
        {
        }
        public StudentService(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public StudentReadDto AddStudent(StudentCreateDto student)
        {
            var studentModel = _mapper.Map<Student>(student);
            Random random = new Random();
            studentModel.stuCode = random.Next(1000,10000).ToString();

            base.Add(studentModel);
            base.SaveChanges();

            var stuReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return stuReadDto;         
        }
        public bool DeleteStudent(int id)
        {
            var student = base.GetItemById(id);
            if(student == null)
            {
                return false;
            }
            base.Delete(student);
            base.SaveChanges();
            return true;
        }        

        public Student GetStudentById(int id)
        {
           return base.GetItemById(id);
        }

        public IEnumerable<StudentReadDto> GetAllStudent()
        {
            return _mapper.Map<IEnumerable<StudentReadDto>>(base.GetAll());
        }

        public StudentReadDto UpdateStudent( int id,StudentUpdateDto student)
        {
            var studentModel = _mapper.Map<Student>(student);
            base.Update(studentModel);

            try
            {
                base.SaveChanges();
                var stuReadDto = _mapper.Map<StudentReadDto>(studentModel);
                return stuReadDto;
            }
            catch (System.Exception)
            {
                
               return null;
            }
        }
    }
}