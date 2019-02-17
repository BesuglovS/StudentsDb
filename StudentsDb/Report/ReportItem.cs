using System.ComponentModel;

namespace StudentsDb.Report
{
    public class ReportItem : INotifyPropertyChanged
    {
        private string year;
        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                if (year != value)
                {
                    year = value;
                    RaisePropertyChanged("Year");
                }
            }
        }

        private string faculty;
        public string Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                if (faculty != value)
                {
                    faculty = value;
                    RaisePropertyChanged("Faculty");
                }
            }
        }        

        private int studentCount;
        public int StudentsCount
        {
            get
            {
                return studentCount;
            }
            set
            {
                if (studentCount != value)
                {
                    studentCount = value;
                    RaisePropertyChanged("StudentsCount");
                }
            }
        }

        private bool yearTotal;
        public bool YearTotal
        {
            get
            {
                return yearTotal;
            }
            set
            {
                if (yearTotal != value)
                {
                    yearTotal = value;
                    RaisePropertyChanged("YearTotal");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
