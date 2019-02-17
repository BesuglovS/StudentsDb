using StudentsDb.Command;
using StudentsDb.DomainClasses;
using StudentsDb.Export;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDb.Faculties
{
    public class FacultiesViewModel : BindableBase
    {
        private IFacultyRepository _repo;
        public FacultiesViewModel(IFacultyRepository repo)
        {
            _repo = repo;

            AddCommand = new RelayCommand(OnAddFaculty);
            UpdateCommand = new RelayCommand(OnUpdateFaculty);
            RemoveCommand = new RelayCommand(OnRemoveFaculty);
            ExportCommand = new RelayCommand(OnExport);

            SelectedFaculty = new Faculty { FacultyId = 0 };

            LoadDataLists();

            SelectedExportTypeId = 1;
        }

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand ExportCommand { get; private set; }

        private async void OnAddFaculty()
        {
            SelectedFaculty.FacultyId = 0;
            var result = await _repo.AddFacultyAsync(SelectedFaculty);
            Faculties.Add(result);
        }

        private async void OnUpdateFaculty()
        {
            var result = await _repo.UpdateFacultyAsync(SelectedFaculty);
            var faculty = Faculties.FirstOrDefault(f => f.FacultyId == SelectedFaculty.FacultyId);
            faculty.CopyProperties(SelectedFaculty);
        }

        private async void OnRemoveFaculty()
        {
            await _repo.DeleteFacultyWithSpecialitiesAndStudentsAsync(SelectedFaculty.FacultyId);
            var faculty = Faculties.FirstOrDefault(f => f.FacultyId == SelectedFaculty.FacultyId);
            if (faculty != null)
            {
                Faculties.Remove(faculty);
            }
        }

        private async void OnExport()
        {
            var faculties = await _repo.GetFacultiesAsync();
            var exportType = ExportType.All.FirstOrDefault(et => et.Id == SelectedExportTypeId);

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Faculties"; 
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
                    ExportToTxtFile(filename, faculties);
                    break;
                case ExportType.csvId:
                    ExportToCsvFile(filename, faculties);
                    break;
            }            
        }

        private void ExportToTxtFile(string filename, List<Faculty> faculties)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = "\t";
            var exportStrings = new List<string>();
            exportStrings.Add("FacultyId" + separator + "Name");
            foreach (var faculty in faculties)
            {
                exportStrings.Add(faculty.FacultyId + separator + faculty.Name);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private void ExportToCsvFile(string filename, List<Faculty> faculties)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = ",";
            var exportStrings = new List<string>();
            exportStrings.Add("FacultyId" + separator + "Name");
            foreach (var faculty in faculties)
            {
                exportStrings.Add(faculty.FacultyId + separator + faculty.Name);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private ObservableCollection<Faculty> _faculties;
        public ObservableCollection<Faculty> Faculties
        {
            get { return _faculties; }
            set { SetProperty(ref _faculties, value); }
        }

        private Faculty _selectedFaculty;
        public Faculty SelectedFaculty {
            get
            {
                return _selectedFaculty;
            }
            set
            {
                if (_selectedFaculty != value)
                {
                    Faculty facultyToEdit;
                    if (value != null)
                    {
                        facultyToEdit = new Faculty { FacultyId = value.FacultyId };
                        facultyToEdit.CopyProperties(value);
                    }
                    else
                    {
                        facultyToEdit = new Faculty { FacultyId = 0 };
                    }
                                        
                    SetProperty(ref _selectedFaculty, facultyToEdit);
                }
            }
        }


        public List<ExportType> ExportTypes { get; set; } = ExportType.All;

        private int _selectedExportTypeId;
        public int SelectedExportTypeId
        {
            get { return _selectedExportTypeId; }
            set { SetProperty(ref _selectedExportTypeId, value); }
        }

        public async Task LoadDataLists()
        {
            Faculties = new ObservableCollection<Faculty>(await  _repo.GetFacultiesAsync());
        }
    }
}
