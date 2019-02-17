using StudentsDb.Command;
using StudentsDb.Export;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDb.Report
{
    public class ReportViewModel : BindableBase
    {
        private IReportRepository _repo;
        public ReportViewModel(IReportRepository repo)
        {
            _repo = repo;

            ExportCommand = new RelayCommand(OnExport);

            LoadReportData();

            SelectedExportTypeId = 1;
        }

        public RelayCommand ExportCommand { get; private set; }

        private async void OnExport()
        {
            var reportItems = await _repo.GetReport();
            var exportType = ExportType.All.FirstOrDefault(et => et.Id == SelectedExportTypeId);

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Students";
            dlg.DefaultExt = exportType.DefaultExt;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.Filter = exportType.Name + "|" + exportType.DefaultExt;

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results
            if (!result.HasValue || result == false)
            {
                return;
            }

            string filename = dlg.FileName;


            switch (SelectedExportTypeId)
            {
                case ExportType.txtId:
                    ExportToTxtFile(filename, reportItems);
                    break;
                case ExportType.csvId:
                    ExportToCsvFile(filename, reportItems);
                    break;
            }
        }

        private void ExportToTxtFile(string filename, IEnumerable<ReportItem> reportItems)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = "\t";
            var exportStrings = new List<string>();
            exportStrings.Add("Year" + separator + "Faculty" + separator + "StudentsCount");
            foreach (var reportItem in reportItems)
            {
                exportStrings.Add(reportItem.Year + separator + reportItem.Faculty + separator + reportItem.StudentsCount);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private void ExportToCsvFile(string filename, IEnumerable<ReportItem> reportItems)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = ",";
            var exportStrings = new List<string>();
            exportStrings.Add("Year" + separator + "Faculty" + separator + "StudentsCount");
            foreach (var reportItem in reportItems)
            {
                exportStrings.Add(reportItem.Year + separator + reportItem.Faculty + separator + reportItem.StudentsCount);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private ObservableCollection<ReportItem> _reportData;
        public ObservableCollection<ReportItem> ReportData
        {
            get { return _reportData; }
            set { SetProperty(ref _reportData, value); }
        }
        public ReportItem SelectedReportItem { get; set; }

        public List<ExportType> ExportTypes { get; set; } = ExportType.All;

        private int _selectedExportTypeId;
        public int SelectedExportTypeId
        {
            get { return _selectedExportTypeId; }
            set { SetProperty(ref _selectedExportTypeId, value); }
        }

        public async Task LoadReportData()
        {
            ReportData = await _repo.GetReport();
        }
    }
}
