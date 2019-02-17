using StudentsDb.DomainClasses;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Tests.Faculties
{
    public class FacultyRepositoryMock : IFacultyRepository
    {
        private List<Faculty> Data = new List<Faculty>();
        private int maxId = 0;

        public FacultyRepositoryMock()
        {
            var f1 = new Faculty { Name = "Факультет математики и компьютерных наук" };
            var f2 = new Faculty { Name = "Философский факультет" };
            var f3 = new Faculty { Name = "Химико - биологический факультет" };
            var f4 = new Faculty { Name = "Экономический факультет" };
            var f5 = new Faculty { Name = "Юридический факультет" };
            var f6 = new Faculty { Name = "Факультет международных отношений" };
            var f7 = new Faculty { Name = "Факультет управления" };
            var f8 = new Faculty { Name = "Факультет искусств" };
            var f9 = new Faculty { Name = "Факультет туризма" };

            AddFacultiesAsync(new List<Faculty> { f1, f2, f3, f4, f5, f6, f7, f8, f9 });
        }

        public async Task<IEnumerable<Faculty>> AddFacultiesAsync(IEnumerable<Faculty> faculties)
        {
            foreach (var faculty in faculties)
            {
                faculty.FacultyId = ++maxId;
                Data.Add(faculty);
            }

            return faculties; 
        }

        public async Task<Faculty> AddFacultyAsync(Faculty faculty)
        {
            faculty.FacultyId = ++maxId;
            Data.Add(faculty);

            return faculty;
        }

        public async Task DeleteFacultiesAsync(IEnumerable<Faculty> faculties)
        {
            foreach (var faculty in faculties)
            {
                Data.Remove(faculty);
            }
        }

        public async Task DeleteFacultyAsync(int facultyId)
        {
            var faculty = Data.FirstOrDefault(f => f.FacultyId == facultyId);
            if (faculty != null)
            {
                Data.Remove(faculty);
            }
        }

        public async Task DeleteFacultyWithSpecialitiesAndStudentsAsync(int facultyId)
        {
            var faculty = Data.FirstOrDefault(f => f.FacultyId == facultyId);
            if (faculty != null)
            {
                Data.Remove(faculty);
            }
        }

        public async Task<List<Faculty>> GetFacultiesAsync()
        {
            return Data;
        }

        public async Task<Faculty> GetFacultyAsync(int id)
        {
            return Data.FirstOrDefault(f => f.FacultyId == id);
        }

        public async Task<List<Faculty>> GetFilteredFacultiesAsync(Expression<Func<Faculty, bool>> condition)
        {
            return Data.Where(condition.Compile()).ToList();
        }

        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            var result = Data.FirstOrDefault(f => f.FacultyId == faculty.FacultyId);
            if (result != null)
            {
                result.CopyProperties(faculty);
            }

            return result;
        }
    }
}
