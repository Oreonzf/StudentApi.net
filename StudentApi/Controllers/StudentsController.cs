using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
    {
        var students = await _studentRepository.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(long id)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpGet("matricula/{matricula}")]
    public async Task<ActionResult<Student>> GetStudentByMatricula(string matricula)
    {
        var student = await _studentRepository.GetStudentByMatriculaAsync(matricula);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
    {
        var createdStudent = await _studentRepository.CreateStudentAsync(student);
        return Ok(createdStudent);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Student>> UpdateStudent(long id, [FromBody] Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }

        var updatedStudent = await _studentRepository.UpdateStudentAsync(student);
        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(long id)
    {
        var result = await _studentRepository.DeleteStudentAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}