using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
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

        public ActionController(IGenericRepo<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }


        [Route("/AddStudent")]
        [HttpPost("student")]
        public ActionResult<Student> AddStudent(Student student)
        {
            var stu = _studentRepo.Add(student);
            
            return Ok(_studentRepo.SaveChanges()? stu : null);
        }

        [Route("/getAllStudents")]
        [HttpGet]
        public ActionResult<Student>  GetAllStudents()
        {
            
            return Ok(_studentRepo.GetAll());
        }
        [Route("/getStudentById/{id}")]
        [HttpGet("id")]
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
        public ActionResult<Student> UpdateStudent(int id,Student student)
        {
            
            if( id == student.id)
            {
                
            }
            var updatedStudent = _studentRepo.Update(student);

            try
            {
                _studentRepo.SaveChanges();
                return Ok(student);
            }
            catch (System.Exception)
            {
                
               return NotFound();
            }
           
        }
    }
}