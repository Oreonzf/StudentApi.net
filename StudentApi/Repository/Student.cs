using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(long id);
        Task<Student> GetStudentByMatriculaAsync(string matricula);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(long id);
    }
}