using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Repository;

public class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        // Remove Include for Telefones
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(long id)
    {
        // Remove Include for Telefones
        return await context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student?> GetStudentByMatriculaAsync(string matricula)
    {
        // Remove Include for Telefones
        return await context.Students.FirstOrDefaultAsync(s => s.Matricula == matricula);
    }

    public async Task<Student> CreateStudentAsync(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> UpdateStudentAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
        return student;
    }

    public async Task<bool> DeleteStudentAsync(long id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
        {
            return false;
        }

        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return true;
    }
}