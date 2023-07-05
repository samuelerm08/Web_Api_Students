using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStudents.Context;
using WebApiStudents.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApiStudents.Controllers
{
    //NAVIGATE BY ACTION NAME
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DbStudentsContext _context;
        public StudentController(DbStudentsContext context)
        {
            _context = context;
        }

        //READ ALL FROM MEMORY ONLY
        [HttpGet]
        public IEnumerable<Student> GetStudentsAtMemory()
        {
            var list = new List<Student>()
            {
                new Student()
                {
                    StudentId = 1,
                    FirstName = "Samuel",
                    LastName = "Rivera",
                    DNI = 95927110,
                    Address = "CABA",
                    Grade = 10,
                    BornDate = new DateTime(1999,07,08)
                },
                new Student()
                {
                    StudentId = 2,
                    FirstName = "Other",
                    LastName = "Other",
                    DNI = 123456,
                    Address = "CABA",
                    Grade = 8,
                    BornDate = new DateTime(2000,10,10)
                },
                new Student()
                {
                    StudentId = 3,
                    FirstName = "Other",
                    LastName = "Other",
                    DNI = 123456,
                    Address = "CABA",
                    Grade = 8,
                    BornDate = new DateTime(2001,11,09)
                },
                new Student()
                {
                    StudentId = 4,
                    FirstName = "Other",
                    LastName = "Other",
                    DNI = 09876,
                    Address = "CABA",
                    Grade = 8,
                    BornDate = new DateTime(1998,06,05)
                }
            };

            return list;
        }
        //READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var list = _context.Students.ToList();
            return Ok(list);
        }

        //READ
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Student>> GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
                return Ok(student);
            return NotFound("Student doesn't exists");
        }

        //INSERT
        [HttpPost]
        public ActionResult InsertStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data input...");
            _context.Students.Add(student);
            _context.SaveChanges();
            return new CreatedAtActionResult("GetStudentById", "Student", new { id = student.StudentId }, student);
        }
        //UPDATE
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.StudentId)
                return NotFound("Student not found...");
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(student);
        }
        //DELETE        
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = (from s in _context.Students
                           where s.StudentId == id
                           select s).SingleOrDefault();
            if (student == null)
                return NotFound("Student doesn't exists");
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok(student);

        }
    }
}
