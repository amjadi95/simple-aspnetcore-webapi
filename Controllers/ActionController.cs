using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Http;
using System.Net;
using ApiServer.Models;
using ApiServer.Data;
using ApiServer.Dtos;
using AutoMapper;

namespace ApiServer.Controller
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        
        private readonly IGenericRepo<Student> _studentRepo ;
        private readonly IMapper _mapper;

        public ActionController(IGenericRepo<Student> studentRepo,IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }


        [Route("/AddStudent")]
        [HttpPost("student")]
        public ActionResult<StudentReadDto> AddStudent(StudentCreateDto student)
        {
            var studentModel = _mapper.Map<Student>(student);
            Random random = new Random();
            studentModel.stuCode = random.Next(1000,10000).ToString();

            _studentRepo.Add(studentModel);
            _studentRepo.SaveChanges();

            var stuReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtAction(nameof(GetStudentById),new {id = stuReadDto.id},stuReadDto);
        }

        [Route("/getAllStudents")]
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>>  GetAllStudents()
        {
            
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(_studentRepo.GetAll()));
        }
        [Route("/getStudentById/{id}")]
        [HttpGet(Name="GetStudentById") ]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentRepo.GetItemById(id);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        [Route("/deletestudent/{id}")]
        [HttpDelete("id")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentRepo.GetItemById(id);
            if(student == null)
            {
                return NotFound();
            }
            _studentRepo.Delete(student);
            _studentRepo.SaveChanges();
            return NoContent();

        }
        [Route("/updatestudent/{id}")]
        [HttpPut("id")]
        public ActionResult<StudentReadDto> UpdateStudent(int id,StudentUpdateDto student)
        {
            
            if( id != student.id)
            {
                return BadRequest();
            }
            var studentModel = _mapper.Map<Student>(student);
            _studentRepo.Update(studentModel);

            try
            {
                _studentRepo.SaveChanges();
                var stuReadDto = _mapper.Map<StudentReadDto>(studentModel);
                return Ok(stuReadDto);
            }
            catch (System.Exception)
            {
                
               return NotFound();
            }
           
        }
    }
}