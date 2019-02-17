using StudentsDb.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Interfaces
{
    public interface IFacultyRepository
    {
        Task<List<Faculty>> GetFacultiesAsync();
        Task<List<Faculty>> GetFilteredFacultiesAsync(Expression<Func<Faculty, bool>> condition);
        Task<Faculty> GetFacultyAsync(int id);
        Task<Faculty> AddFacultyAsync(Faculty faculty);
        Task<IEnumerable<Faculty>> AddFacultiesAsync(IEnumerable<Faculty> faculties);
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(int facultyId);
        Task DeleteFacultyWithSpecialitiesAndStudentsAsync(int facultyId);
        Task DeleteFacultiesAsync(IEnumerable<Faculty> faculties);
    }
}
