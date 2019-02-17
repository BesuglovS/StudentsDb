using StudentsDb.Database;
using StudentsDb.Report;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Concrete
{
    public class ReportRepository : IReportRepository
    {
        public async Task<ObservableCollection<ReportItem>> GetReport()
        {
            using (DatabaseContext DbContext = new DatabaseContext())
            {
                var FacultyNameByIdDict = (await DbContext.Faculties.ToListAsync())
                .ToDictionary(f => f.FacultyId, f => f.Name);

                var students = await DbContext.Students.Include(st => st.Specialty.Faculty).ToListAsync();

                var data = students.GroupBy(s => s.AdmissionYear)
                    .ToDictionary(
                        sc => sc.Key,
                        sc => sc.GroupBy(sg => sg.Specialty.Faculty.FacultyId)
                            .ToDictionary(syg => syg.Key, syg => syg.Count())
                );

                var result = new List<ReportItem>();

                var bigTotal = 0;

                foreach (var YearData in data)
                {
                    var year = YearData.Key;
                    var yearTotal = 0;

                    foreach (var YearFacultyData in YearData.Value)
                    {
                        var newReportItem = new ReportItem
                        {
                            Year = year.ToString(),                            
                            Faculty = FacultyNameByIdDict[YearFacultyData.Key],
                            StudentsCount = YearFacultyData.Value,
                            YearTotal = false
                        };
                        result.Add(newReportItem);

                        yearTotal += YearFacultyData.Value;
                    }

                    var totalReportItem = new ReportItem
                    {
                        Year = year.ToString(),
                        Faculty = "Итого",
                        StudentsCount = yearTotal,
                        YearTotal = true
                    };
                    result.Add(totalReportItem);

                    bigTotal += yearTotal;
                }

                result = result
                    .OrderBy(ri => ri.Year)
                    .ThenBy(ri => ri.YearTotal)
                    .ThenBy(ri => ri.Faculty)
                    .ToList();

                var bigTotalReportItem = new ReportItem
                {
                    Year = "Итого",
                    Faculty = "",
                    StudentsCount = bigTotal,
                    YearTotal = true
                };
                result.Add(bigTotalReportItem);

                return new ObservableCollection<ReportItem>(result);
            }
        }
    }
}
