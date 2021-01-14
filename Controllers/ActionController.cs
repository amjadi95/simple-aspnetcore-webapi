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
using ApiServer.Services;

namespace ApiServer.Controller
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        
        private readonly IStudentService _studentService ;
        

        public ActionController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [Route("/AddStudent")]
        [HttpPost("student")]
        public ActionResult<StudentReadDto> AddStudent(StudentCreateDto student)
        {
            

            var stu = _studentService.AddStudent(student);

            

            return CreatedAtAction(nameof(GetStudentById),new {id = stu.id},stu);
        }

        [Route("/getAllStudents")]
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>>  GetAllStudents()
        {
            
            return Ok(_studentService.GetAllStudent());
        }
        [Route("/getStudentById/{id}")]
        [HttpGet(Name="GetStudentById") ]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);

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
            var success = _studentService.DeleteStudent(id);
            if(!success )
            {
                return NotFound();
            }
            
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
            var stu = _studentService.UpdateStudent(id,student);

            if(stu == null)
            {
                return NotFound();
            }

            return Ok(stu);
            
           
        }
    }
}