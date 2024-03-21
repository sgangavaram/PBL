using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementService;
using System.Collections.Generic;
using Common.Models;


namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudents();
            if (students == null) return NotFound();
            return Ok(students);
        }

        [HttpGet]
        [Route("GetByStudentRollNo/{rollNo}")]
        public async Task<IActionResult> GetByStudentRollNo(int rollNo)
        {
            var student = await _service.GetByStudentRollNo(rollNo);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> InsertStudent([FromBody] StudentClass student)
        {
            var insertedStudent = await _service.InsertStudent(student);
            return Ok(insertedStudent);
        }

        [HttpPut]
        [Route("UpdateStudent/{rollNo}")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentClass student)
        {
            var updatedStudent = await _service.UpdateStudent(student);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete]
        [Route("DeleteStudent/{rollNo}")]
        public async Task<IActionResult> DeleteStudent(int rollNo)
        {
            var isDeleted = await _service.DeleteStudent(rollNo);
            if (!isDeleted) return NotFound();
            return Ok();
        }

        [HttpGet]
        [Route("GetStudentData")]
        public async Task<IActionResult> GetAllStudentData()
        {
            var students = await _service.GetAllStudentData();
            if (students == null) return NotFound();
            return Ok(students);
        }
    }
}
