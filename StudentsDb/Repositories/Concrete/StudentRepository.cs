using StudentsDb.Database;
using StudentsDb.DomainClasses;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<List<Student>> GetStudentsAsync()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Students.ToListAsync();
            }
        }

        public async Task<List<Student>> GetFilteredStudentsAsync(Expression<Func<Student, bool>> condition)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Students.Where(condition).ToListAsync();
            }
        }       

        public async Task<List<Student>> GetStudentsWithSpecialityAsync()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Students.Include(s => s.Specialty).ToListAsync();
            }
        }

        public async Task<List<Student>> GetFilteredStudentsWithSpecialityAsync(Expression<Func<Student, bool>> condition)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Students.Include(s => s.Specialty).Where(condition).ToListAsync();
            }
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            }
        }

        public async Task<Student> GetStudentWithSpecialityAsync(int id)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Students.Include(s => s.Specialty).FirstOrDefaultAsync(s => s.StudentId == id);
            }
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                student.Specialty = DbContext.Specialties.FirstOrDefault(s => s.SpecialtyId == student.SpecialityId);
                DbContext.Students.Add(student);
                await DbContext.SaveChangesAsync();
                return student;
            }
        }

        public async Task<IEnumerable<Student>> AddStudentsAsync(IEnumerable<Student> students)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                foreach (var student in students)
                {
                    student.Specialty = DbContext.Specialties.FirstOrDefault(s => s.SpecialtyId == student.Specialty.SpecialtyId);
                    DbContext.Students.Add(student);
                }
                await DbContext.SaveChangesAsync();
                return students;
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var dbStudent = DbContext.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (dbStudent != null)
                {
                    DbContext.Entry(dbStudent).CurrentValues.SetValues(student);
                    await DbContext.SaveChangesAsync();
                    return student;
                }
                return null;
            }
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var student = DbContext.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (student != null)
                {
                    DbContext.Students.Remove(student);
                }
                await DbContext.SaveChangesAsync();
            }
        }        

        public async Task DeleteStudentsAsync(IEnumerable<Student> students)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Students.RemoveRange(students);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task ClearTable()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Students.RemoveRange(DbContext.Students);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
