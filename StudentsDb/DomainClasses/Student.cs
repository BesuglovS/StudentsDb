using StudentsDb.Specialities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsDb.DomainClasses
{
    public class Student : INotifyPropertyChanged
    {
        private int studentId;
        [Key]
        public int StudentId
        {
            get
            {
                return studentId;
            }
            set
            {
                if (studentId != value)
                {
                    studentId = value;
                    RaisePropertyChanged("StudentId");
                }
            }
        }

        private string fio;
        [Required]
        public string Fio
        {
            get
            {
                return fio;
            }
            set
            {
                if (fio != value)
                {
                    fio = value;
                    RaisePropertyChanged("Fio");
                }
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (address != value)
                {
                    address = value;
                    RaisePropertyChanged("Address");
                }
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }

        private int admissionYear;
        public int AdmissionYear
        {
            get
            {
                return admissionYear;
            }
            set
            {
                if (admissionYear != value)
                {
                    admissionYear = value;
                    RaisePropertyChanged("AdmissionYear");
                }
            }
        }

        private int specialityId;
        public int SpecialityId
        {
            get
            {
                return specialityId;
            }
            set
            {
                if (specialityId != value)
                {
                    specialityId = value;
                    RaisePropertyChanged("SpecialityId");
                }
            }
        }

        private Specialty specialty;
        [ForeignKey("SpecialityId")]
        public Specialty Specialty
        {
            get
            {
                return specialty;
            }
            set
            {
                if (specialty != value)
                {
                    specialty = value;
                    RaisePropertyChanged("Specialty");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CopyProperties(Student source)
        {
            Fio = source.Fio;
            Address = source.Address;
            Phone = source.Phone;
            AdmissionYear = source.AdmissionYear;

            specialityId = source.specialityId;
            Specialty = source.Specialty;
        }
    }
}
