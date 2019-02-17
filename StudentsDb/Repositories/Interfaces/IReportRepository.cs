using StudentsDb.Report;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StudentsDb.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<ObservableCollection<ReportItem>> GetReport();
    }
}
