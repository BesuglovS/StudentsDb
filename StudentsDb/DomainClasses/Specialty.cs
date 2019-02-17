using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsDb.DomainClasses
{
    public class Specialty : INotifyPropertyChanged
    {
        private int specialtyId;
        [Key]
        public int SpecialtyId {
            get
            {
                return specialtyId;
            }
            set
            {
                if (specialtyId != value)
                {
                    specialtyId = value;
                    RaisePropertyChanged("SpecialtyId");
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

        private int facultyId;        
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

        private Faculty faculty;
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty
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

        private ICollection<Student> students;
        public virtual ICollection<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (students != value)
                {
                    students = value;
                    RaisePropertyChanged("Students");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CopyProperties(Specialty source)
        {
            Name = source.name;

            facultyId = source.facultyId;
            Faculty = source.Faculty;
        }
    }
}
