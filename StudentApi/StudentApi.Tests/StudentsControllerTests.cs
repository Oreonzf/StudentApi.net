using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Model;
using WebApplication1.Repository;
using Xunit;

namespace WebApplication1.StudentApi.Tests;

public class StudentsControllerTests
{
    private readonly Mock<IStudentRepository> _mockRepository;
    private readonly StudentsController _controller;

    public StudentsControllerTests()
    {
        _mockRepository = new Mock<IStudentRepository>();
        _controller = new StudentsController(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllStudents_ShouldReturnAllStudents()
    {
        var students = new List<Student>
        {
            new Student { Id = 1, Nome = "Rafael", Sobrenome = "Cavalcante", Matricula = "123", Telefone = "11987654321" },
            new Student { Id = 2, Nome = "Maria", Sobrenome = "Silva", Matricula = "456", Telefone = "11987654321" }
        };

        _mockRepository.Setup(r => r.GetAllStudentsAsync()).ReturnsAsync(students);

        var result = await _controller.GetAllStudents();
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedStudents = Assert.IsType<List<Student>>(actionResult.Value);
        Assert.Equal(2, returnedStudents.Count);
    }

    [Fact]
    public async Task GetStudentById_ShouldReturnStudent()
    {
        var student = new Student { Id = 1, Nome = "Rafael", Sobrenome = "Cavalcante", Matricula = "123", Telefone = "11987654321" };

        _mockRepository.Setup(r => r.GetStudentByIdAsync(1)).ReturnsAsync(student);

        var result = await _controller.GetStudentById(1);
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedStudent = Assert.IsType<Student>(actionResult.Value);
        Assert.Equal("Rafael", returnedStudent.Nome);
    }

    [Fact]
    public async Task CreateStudent_ShouldReturnCreatedStudent()
    {
        var student = new Student { Id = 1, Nome = "Rafael", Sobrenome = "Cavalcante", Matricula = "123", Telefone = "11987654321" };

        _mockRepository.Setup(r => r.CreateStudentAsync(student)).ReturnsAsync(student);

        var result = await _controller.CreateStudent(student);
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedStudent = Assert.IsType<Student>(actionResult.Value);
        Assert.Equal("Rafael", returnedStudent.Nome);
    }

    [Fact]
    public async Task UpdateStudent_ShouldReturnUpdatedStudent()
    {
        var student = new Student { Id = 1, Nome = "Rafael", Sobrenome = "Cavalcante", Matricula = "123", Telefone = "11987654321" };

        _mockRepository.Setup(r => r.UpdateStudentAsync(student)).ReturnsAsync(student);

        var result = await _controller.UpdateStudent(1, student);
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedStudent = Assert.IsType<Student>(actionResult.Value);
        Assert.Equal("Rafael", returnedStudent.Nome);
    }

    [Fact]
    public async Task DeleteStudent_ShouldReturnNoContent()
    {
        _mockRepository.Setup(r => r.DeleteStudentAsync(1)).ReturnsAsync(true);
        var result = await _controller.DeleteStudent(1);
        Assert.IsType<NoContentResult>(result);
    }
}