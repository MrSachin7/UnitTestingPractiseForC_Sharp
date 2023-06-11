using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Contracts;
using StudentApi.Dto;

namespace StudentApi.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class StudentController :ControllerBase {
    
    private readonly IStudentData _studentData;

    public StudentController(IStudentData studentData) {
        _studentData = studentData;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> AddStudent(Student student) {
        try {
            Student newStudent = await _studentData.AddStudent(student);
            return Ok(newStudent);                      
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents() {
        try {
            List<Student> students = await _studentData.GetStudents();
            return Ok(students);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

}