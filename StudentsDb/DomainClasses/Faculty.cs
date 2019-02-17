using StudentsDb.Specialities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentsDb.DomainClasses
{
    public class Faculty : INotifyPropertyChanged
    {
        private int facultyId;
        [Key]
        public int FacultyId
        {
            get
            {
                return facultyId;
            }
            set
            {
                if (facultyId != value)
                {
                    facultyId = value;
                    RaisePropertyChanged("FacultyId");
                }                
            }
        }

        private string name;
        [Required]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }                
            }
        }

        private ICollection<Specialty> specialities;
        public virtual ICollection<Specialty> Specialities
        {
            get
            {
                return specialities;
            }
            set
            {
                if (specialities != value)
                {
                    specialities = value;
                    RaisePropertyChanged("Specialities");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CopyProperties(Faculty source)
        {
            Name = source.name;
        }
    }
}
