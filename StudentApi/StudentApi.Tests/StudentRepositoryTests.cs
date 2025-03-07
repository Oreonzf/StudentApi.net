using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository;
using Xunit;

namespace WebApplication1.Tests;

public class StudentRepositoryTests : IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly StudentRepository _repository;

    public StudentRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);

        _repository = new StudentRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public async Task GetAllStudentsAsync_ShouldReturnAllStudents()
    {
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Nome = "Rafael",
                Sobrenome = "Cavalcante",
                Matricula = "123",
                Telefone = "11987654321"
            },
            new Student
            {
                Id = 2,
                Nome = "Maria",
                Sobrenome = "Silva",
                Matricula = "456",
                Telefone = "11987654322"
            }
        };

        await _context.Students.AddRangeAsync(students);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllStudentsAsync();

        Assert.Equal(2, result.Count());
        Assert.Contains(result, s => s.Nome == "Rafael" && s.Telefone == "11987654321");
        Assert.Contains(result, s => s.Nome == "Maria" && s.Telefone == "11987654322");
    }

    [Fact]
    public async Task GetStudentByIdAsync_ShouldReturnStudent()
    {
        var student = new Student
        {
            Id = 1,
            Nome = "Rafael",
            Sobrenome = "Cavalcante",
            Matricula = "123",
            Telefone = "11987654321"
        };

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
            
        var result = await _repository.GetStudentByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Rafael", result.Nome);
        Assert.Equal("11987654321", result.Telefone);
    }

    [Fact]
    public async Task CreateStudentAsync_ShouldAddStudent()
    {
        var student = new Student
        {
            Id = 1,
            Nome = "Rafael",
            Sobrenome = "Cavalcante",
            Matricula = "123",
            Telefone = "11987654321"
        };

        var result = await _repository.CreateStudentAsync(student);

        var savedStudent = await _context.Students.FindAsync(1L);
        Assert.NotNull(savedStudent);
        Assert.Equal("Rafael", savedStudent.Nome);
        Assert.Equal("11987654321", savedStudent.Telefone);
    }

    [Fact]
    public async Task DeleteStudentAsync_ShouldRemoveStudent()
    {
        var student = new Student
        {
            Id = 1,
            Nome = "Rafael",
            Sobrenome = "Cavalcante",
            Matricula = "123",
            Telefone = "11987654321"
        };

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        var result = await _repository.DeleteStudentAsync(1L);

        var deletedStudent = await _context.Students.FindAsync(1L);
        Assert.Null(deletedStudent);
        Assert.True(result);
    }
}