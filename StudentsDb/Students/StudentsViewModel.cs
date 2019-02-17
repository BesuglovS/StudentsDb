using StudentsDb.Command;
using StudentsDb.DomainClasses;
using StudentsDb.Export;
using StudentsDb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDb.Students
{
    public class StudentsViewModel : BindableBase
    {
        private IStudentRepository _repo;
        private ISpecialityRepository _sRepo;

        public StudentsViewModel(IStudentRepository repo, ISpecialityRepository sRepo)
        {
            _repo = repo;
            _sRepo = sRepo;

            AddCommand = new RelayCommand(OnAddStudent);
            UpdateCommand = new RelayCommand(OnUpdateStudent);
            RemoveCommand = new RelayCommand(OnRemoveStudent);
            ExportCommand = new RelayCommand(OnExport);

            SelectedStudent = new Student { StudentId = 0 };

            LoadDataLists();

            SelectedExportTypeId = 1;
        }

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand UpdateCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand ExportCommand { get; private set; }

        private async void OnAddStudent()
        {
            SelectedStudent.StudentId = 0;
            var result = await _repo.AddStudentAsync(SelectedStudent);
            Students.Add(result);
        }

        private async void OnUpdateStudent()
        {
            SelectedStudent.Specialty = Specialities.FirstOrDefault(s => s.SpecialtyId == SelectedStudent.SpecialityId);

            var result = await _repo.UpdateStudentAsync(SelectedStudent);
            var student = Students.FirstOrDefault(s => s.StudentId == SelectedStudent.StudentId);
            student.CopyProperties(SelectedStudent);
        }

        private async void OnRemoveStudent()
        {
            await _repo.DeleteStudentAsync(SelectedStudent.StudentId);
            var student = Students.FirstOrDefault(s => s.StudentId == SelectedStudent.StudentId);
            if (student != null)
            {
                Students.Remove(student);
            }
        }

        private async void OnExport()
        {
            var students = await _repo.GetStudentsWithSpecialityAsync();
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
                    ExportToTxtFile(filename, students);
                    break;
                case ExportType.csvId:
                    ExportToCsvFile(filename, students);
                    break;
            }
        }

        private void ExportToTxtFile(string filename, List<Student> students)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = "\t";
            var exportStrings = new List<string>();
            exportStrings.Add("StudentId" + separator + "Fio" + separator + "Address" + separator + "Phone" + separator + "AdmissionYear" + separator + "SpecialityId");
            foreach (var student in students)
            {
                exportStrings.Add(student.StudentId + separator + student.Fio + separator + student.Address + separator + student.Phone + separator + student.AdmissionYear + separator + student.SpecialityId);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private void ExportToCsvFile(string filename, List<Student> students)
        {
            TextFileUtil.CreateOrEmptyFile(filename);

            var separator = ",";
            var exportStrings = new List<string>();
            exportStrings.Add("StudentId" + separator + "Fio" + separator + "Address" + separator + "Phone" + separator + "AdmissionYear" + separator + "SpecialityId");
            foreach (var student in students)
            {
                exportStrings.Add(student.StudentId + separator + student.Fio + separator + student.Address + separator + student.Phone + separator + student.AdmissionYear + separator + student.SpecialityId);
            }

            TextFileUtil.WriteStringList(filename, exportStrings);
        }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students {
            get { return _students;}
            set { SetProperty(ref _students, value); }
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                if (_selectedStudent != value)
                {
                    Student studentToEdit;
                    if (value != null)
                    {
                        studentToEdit = new Student { StudentId = value.StudentId };
                        studentToEdit.CopyProperties(value);
                    }
                    else
                    {
                        studentToEdit = new Student { StudentId = 0 };
                    }

                    SetProperty(ref _selectedStudent, studentToEdit);
                }
            }
        }

        private ObservableCollection<Specialty> _specialities;
        public ObservableCollection<Specialty> Specialities
        {
            get { return _specialities; }
            set { SetProperty(ref _specialities, value); }
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
            Specialities = new ObservableCollection<Specialty>(await _sRepo.GetSpecialtiesAsync());
            Students = new ObservableCollection<Student>(await _repo.GetStudentsWithSpecialityAsync());            
        }
    }
}
