using StudentsDb.Command;
using StudentsDb.Container;
using StudentsDb.Faculties;
using StudentsDb.Report;
using StudentsDb.Specialities;
using StudentsDb.Students;
using System;
using Unity;

namespace StudentsDb
{
    public class MainWindowViewModel : BindableBase
    {
        private FacultiesViewModel _facultiesViewModel = ContainerHelper.Container.Resolve<FacultiesViewModel>();
        private SpecialitiesViewModel _specialitiesViewModel = ContainerHelper.Container.Resolve<SpecialitiesViewModel>();
        private StudentsViewModel _studentsViewModel= ContainerHelper.Container.Resolve<StudentsViewModel>();
        private ReportViewModel _reportViewModel = ContainerHelper.Container.Resolve<ReportViewModel>();

        private BindableBase _currectViewModel;
        public BindableBase CurrectViewModel {
            get { return _currectViewModel; }
            set { SetProperty(ref _currectViewModel, value); }
        }

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(onNav);
            onNav("faculties");
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private async void onNav(string destination)
        {
            switch (destination)
            {
                case "faculties":
                    await _facultiesViewModel.LoadDataLists();
                    CurrectViewModel = _facultiesViewModel;
                    break;
                case "specialities":
                    await _specialitiesViewModel.LoadDataLists();
                    CurrectViewModel = _specialitiesViewModel;
                    break;
                case "students":
                    await _studentsViewModel.LoadDataLists();
                    CurrectViewModel = _studentsViewModel;
                    break;
                case "report":
                    await _reportViewModel.LoadReportData();
                    CurrectViewModel = _reportViewModel;
                    break;
                default:
                    throw new ArgumentException("Invalid navigation path.");
            }
        }
    }
}
