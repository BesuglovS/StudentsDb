using StudentsDb.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Interfaces
{
    public interface ISpecialityRepository
    {
        Task<List<Specialty>> GetSpecialtiesAsync();
        Task<List<Specialty>> GetFilteredSpecialtiesAsync(Expression<Func<Specialty, bool>> condition);
        Task<List<Specialty>> GetSpecialtiesWithFacultyAsync();        
        Task<List<Specialty>> GetFilteredSpecialtiesWithFacultyAsync(Expression<Func<Specialty, bool>> condition);
        Task<Specialty> GetSpecialtyAsync(int id);
        Task<Specialty> GetSpecialtyWithFacultyAsync(int id);
        Task<Specialty> AddSpecialtyAsync(Specialty specialty);
        Task<IEnumerable<Specialty>> AddSpecialitiesAsync(IEnumerable<Specialty> specialilies);
        Task<Specialty> UpdateSpecialtyAsync(Specialty specialty);
        Task DeleteSpecialtyAsync(int specialtyId);
        Task DeleteSpecialtyWithStudentsAsync(int specialtyId);
        Task DeleteSpecialitiesAsync(IEnumerable<Specialty> specialities);
    }
}
