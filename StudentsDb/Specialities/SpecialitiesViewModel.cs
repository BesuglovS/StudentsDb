using StudentsDb.Command;
using StudentsDb.DomainClasses;
using StudentsDb.Export;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsDb.Specialities
{
    public class SpecialitiesViewModel : BindableBase
    {
        private ISpecialityRepository _repo;
        private IFacultyRepository _fRepo;
        private IStudentRepository _sRepo;

        public SpecialitiesViewModel(ISpecialityRepository repo, IFacultyRepository fRepo, IStudentRepository sRepo)
        {
            _repo = repo;
            _fRepo = fRepo;
            _sRepo = sRepo;

            AddCommand = new RelayCommand(OnAddSpecialty);
            UpdateCommand = new RelayCommand(OnUpdateSpecialty);
            RemoveCommand = new RelayCommand(OnRemoveSpecialty);
            ExportCommand = new RelayCommand(OnExport);

            SelectedSpeciality = new Specialty { SpecialtyId = 0 };

            LoadDataLists();

            SelectedExportTypeId = 1;
        }

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand ExportCommand { get; private set; }

        private async void OnAddSpecialty()
        {
            SelectedSpeciality.SpecialtyId = 0;

            var allSpecialities = await _repo.GetSpecialtiesAsync();            
            if (allSpecialities.Any(s => 
                s.Name == SelectedSpeciality.Name && 
                s.FacultyId == SelectedSpeciality.FacultyId))
            {
                MessageBox.Show("Специальность с таким именем уже существует на этом факультете.", "Ошибка");
                return;
            }

            var result = await _repo.AddSpecialtyAsync(SelectedSpeciality);
            Specialities.Add(result);
        }

        private async void OnUpdateSpecialty()
        {
            SelectedSpeciality.Faculty = Faculties.FirstOrDefault(f => f.FacultyId == SelectedSpeciality.FacultyId);

            var result = await _repo.UpdateSpecialtyAsync(SelectedSpeciality);
            var specialty = Specialities.FirstOrDefault(s => s.SpecialtyId == SelectedSpeciality.SpecialtyId);            
            specialty.CopyProperties(SelectedSpeciality);            
        }

        private async void OnRemoveSpecialty()
        {
            var specialityStudents = await _sRepo.GetFilteredStudentsAsync(st => 
                st.SpecialityId == SelectedSpeciality.SpecialtyId);
            if (specialityStudents.Count > 0)
            {
                var result = MessageBox.Show(
                    "Вы точно хотите удалить специальность вместе с прикреплёнными студентами?", 
                    "К этой специальности прикреплены студенты.", 
                    MessageBoxButton.YesNo);

                switch (result)
                {                   
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        return;
                    default:
                        return;
                }
            }

            await _repo.DeleteSpecialtyWithStudentsAsync(SelectedSpeciality.SpecialtyId);
            var specialty = Specialities.FirstOrDefault(s => s.SpecialtyId == SelectedSpeciality.SpecialtyId);
            if (specialty != null)
            {
                Specialities.Remove(specialty);
            }
        }

        private async void OnExport()
        {
            var specialities = await _repo.GetSpecialtiesWithFacultyAsync();
            var exportType = ExportType.All.FirstOrDefault(et => et.Id == SelectedExportTypeId);

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Specialities";
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
                    ExportToTxtFile(filename, specialities);
                    break;
                case ExportType.csvId:
                    ExportToCsvFile(filename, specialities);
                    break;
            }
        }

        private void ExportToTxtFile(string filename, List<Specialty> specialities)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = "\t";
            var exportStrings = new List<string>();
            exportStrings.Add("SpecialtyId" + separator + "Name" + separator + "FacultyId");
            foreach (var speciality in specialities)
            {
                exportStrings.Add(speciality.SpecialtyId + separator + speciality.Name + separator + speciality.FacultyId);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private void ExportToCsvFile(string filename, List<Specialty> specialities)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = ",";
            var exportStrings = new List<string>();
            exportStrings.Add("SpecialtyId" + separator + "Name" + separator + "FacultyId");
            foreach (var speciality in specialities)
            {
                exportStrings.Add(speciality.SpecialtyId + separator + speciality.Name + separator + speciality.FacultyId);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private ObservableCollection<Specialty> _specialities;
        public ObservableCollection<Specialty> Specialities {
            get { return _specialities; }
            set { SetProperty(ref _specialities, value); }
        }

        private Specialty _selectedSpeciality;
        public Specialty SelectedSpeciality {
            get
            {
                return _selectedSpeciality;
            }
            set
            {
                if (_selectedSpeciality != value)
                {
                    Specialty specialtyToEdit;
                    if (value != null)
                    {
                        specialtyToEdit = new Specialty { SpecialtyId = value.SpecialtyId };
                        specialtyToEdit.CopyProperties(value);
                    }
                    else
                    {
                        specialtyToEdit = new Specialty { SpecialtyId = 0 };
                    }

                    SetProperty(ref _selectedSpeciality, specialtyToEdit);                    
                }
            }
        }
        private ObservableCollection<Faculty> _faculties;
        public ObservableCollection<Faculty> Faculties
        {
            get { return _faculties; }
            set { SetProperty(ref _faculties, value); }
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
            Faculties = new ObservableCollection<Faculty>(await _fRepo.GetFacultiesAsync());
            Specialities = new ObservableCollection<Specialty>(await _repo.GetSpecialtiesWithFacultyAsync());
        }       
    }
}
