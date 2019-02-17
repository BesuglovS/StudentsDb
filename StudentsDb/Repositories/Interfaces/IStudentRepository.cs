using StudentsDb.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<List<Student>> GetFilteredStudentsAsync(Expression<Func<Student, bool>> condition);
        Task<List<Student>> GetStudentsWithSpecialityAsync();        
        Task<List<Student>> GetFilteredStudentsWithSpecialityAsync(Expression<Func<Student, bool>> condition);        
        Task<Student> GetStudentAsync(int id);
        Task<Student> GetStudentWithSpecialityAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<IEnumerable<Student>> AddStudentsAsync(IEnumerable<Student> students);
        Task<Student> UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int studentId);
        Task DeleteStudentsAsync(IEnumerable<Student> students);
    }
}
