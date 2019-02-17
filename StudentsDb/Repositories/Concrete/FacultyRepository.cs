using StudentsDb.Database;
using StudentsDb.DomainClasses;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Concrete
{
    public class FacultyRepository : IFacultyRepository
    {
        public async Task<List<Faculty>> GetFacultiesAsync()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Faculties.ToListAsync();
            }
        }

        public async Task<List<Faculty>> GetFilteredFacultiesAsync(Expression<Func<Faculty, bool>> condition)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Faculties.Where(condition).ToListAsync();
            }
        }

        public async Task<Faculty> GetFacultyAsync(int id)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Faculties.FirstOrDefaultAsync(f => f.FacultyId == id);
            }
        }

        public async Task<Faculty> AddFacultyAsync(Faculty faculty)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Faculties.Add(faculty);
                await DbContext.SaveChangesAsync();
                return faculty;
            }
        }

        public async Task<IEnumerable<Faculty>> AddFacultiesAsync(IEnumerable<Faculty> faculties)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Faculties.AddRange(faculties);
                await DbContext.SaveChangesAsync();
                return faculties;
            }
        }

        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var dbFaculty = DbContext.Faculties.FirstOrDefault(f => f.FacultyId == faculty.FacultyId);
                if (dbFaculty != null)
                {
                    DbContext.Entry(dbFaculty).CurrentValues.SetValues(faculty);
                    await DbContext.SaveChangesAsync();
                    return faculty;
                }
                return null;
            }
        }

        public async Task DeleteFacultyAsync(int facultyId)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var faculty = DbContext.Faculties.FirstOrDefault(f => f.FacultyId == facultyId);
                if (faculty != null)
                {
                    DbContext.Faculties.Remove(faculty);
                    await DbContext.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteFacultyWithSpecialitiesAndStudentsAsync(int facultyId)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var facultySpecialities = await DbContext.Specialties.Where(s => s.FacultyId == facultyId).ToListAsync();

                foreach (var facultySpeciality in facultySpecialities)
                {
                    var specialtyStudents = await DbContext.Students
                        .Where(st => st.SpecialityId == facultySpeciality.SpecialtyId)
                        .ToListAsync();
                    DbContext.Students.RemoveRange(specialtyStudents);

                    DbContext.Specialties.Remove(facultySpeciality);
                }

                var faculty = DbContext.Faculties.FirstOrDefault(f => f.FacultyId == facultyId);
                if (faculty != null)
                {
                    DbContext.Faculties.Remove(faculty);
                    await DbContext.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteFacultiesAsync(IEnumerable<Faculty> faculties)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Faculties.RemoveRange(faculties);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task ClearTable()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Faculties.RemoveRange(DbContext.Faculties);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
