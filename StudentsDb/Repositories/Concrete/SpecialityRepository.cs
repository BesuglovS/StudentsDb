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
    public class SpecialityRepository : ISpecialityRepository
    {
        public async Task<List<Specialty>> GetSpecialtiesAsync()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Specialties.ToListAsync();
            }
        }

        public async Task<List<Specialty>> GetFilteredSpecialtiesAsync(Expression<Func<Specialty, bool>> condition)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Specialties.Where(condition).ToListAsync();
            }
        }

        public async Task<List<Specialty>> GetSpecialtiesWithFacultyAsync()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Specialties.Include(s => s.Faculty).ToListAsync();
            }
        }

        public async Task<List<Specialty>> GetFilteredSpecialtiesWithFacultyAsync(Expression<Func<Specialty, bool>> condition)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Specialties.Include(s => s.Faculty).Where(condition).ToListAsync();
            }
        }

        public async Task<Specialty> GetSpecialtyAsync(int id)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Specialties.FirstOrDefaultAsync(s => s.SpecialtyId == id);
            }
        }

        public async Task<Specialty> GetSpecialtyWithFacultyAsync(int id)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                return await DbContext.Specialties.Include(s => s.Faculty).FirstOrDefaultAsync(s => s.SpecialtyId == id);
            }
        }

        public async Task<Specialty> AddSpecialtyAsync(Specialty specialty)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                specialty.Faculty = DbContext.Faculties.FirstOrDefault(f => f.FacultyId == specialty.FacultyId);
                DbContext.Specialties.Add(specialty);
                await DbContext.SaveChangesAsync();
                return specialty;
            }
        }

        public async Task<IEnumerable<Specialty>> AddSpecialitiesAsync(IEnumerable<Specialty> specialilies)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                foreach (var specialty in specialilies)
                {
                    specialty.Faculty = DbContext.Faculties.FirstOrDefault(f => f.FacultyId == specialty.Faculty.FacultyId);
                    DbContext.Specialties.Add(specialty);
                }
                await DbContext.SaveChangesAsync();
                return specialilies;
            }
        }

        public async Task<Specialty> UpdateSpecialtyAsync(Specialty specialty)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var dbSpecialty = DbContext.Specialties.FirstOrDefault(s => s.SpecialtyId == specialty.SpecialtyId);
                if (dbSpecialty != null)
                {
                    DbContext.Entry(dbSpecialty).CurrentValues.SetValues(specialty);
                    await DbContext.SaveChangesAsync();
                    return specialty;
                }
                return null;
            }
        }

        public async Task DeleteSpecialtyAsync(int specialtyId)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var specialty = DbContext.Specialties.FirstOrDefault(s => s.SpecialtyId == specialtyId);
                if (specialty != null)
                {
                    DbContext.Specialties.Remove(specialty);
                }
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSpecialtyWithStudentsAsync(int specialtyId)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var specialtyStudents = await DbContext.Students.Where(st => st.SpecialityId == specialtyId).ToListAsync();
                DbContext.Students.RemoveRange(specialtyStudents);

                var specialty = DbContext.Specialties.FirstOrDefault(s => s.SpecialtyId == specialtyId);
                if (specialty != null)
                {
                    DbContext.Specialties.Remove(specialty);
                }
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSpecialitiesAsync(IEnumerable<Specialty> specialities)
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Specialties.RemoveRange(specialities);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task ClearTable()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                DbContext.Specialties.RemoveRange(DbContext.Specialties);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
