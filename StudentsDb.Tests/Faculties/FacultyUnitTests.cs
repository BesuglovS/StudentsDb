using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Container;
using StudentsDb.DomainClasses;
using StudentsDb.Faculties;
using Unity;

namespace StudentsDb.Tests.Faculties
{
    [TestClass]
    public class FacultyUnitTests
    {
        [TestMethod]
        public void FacultiesCount()
        {
            var facultiesViewModel = ContainerMockHelper.Container.Resolve<FacultiesViewModel>();
            var faclutiesCount = facultiesViewModel.Faculties.Count;            

            Assert.IsTrue(faclutiesCount == 9);
        }

        [TestMethod]
        public void FacultyAdd()
        {
            var facultyName = "Факультет лени";
            var facultiesViewModel = ContainerMockHelper.Container.Resolve<FacultiesViewModel>();

            facultiesViewModel.SelectedFaculty = new Faculty { Name = facultyName };
            (facultiesViewModel.AddCommand as ICommand).Execute(null);

            Assert.IsTrue(facultiesViewModel.Faculties[9].Name == facultyName);
        }

        [TestMethod]
        public void FacultyUpdate()
        {
            var facultyName = "Факультет лени";
            var facultiesViewModel = ContainerMockHelper.Container.Resolve<FacultiesViewModel>();
            var facultyToUpdate = facultiesViewModel.Faculties.FirstOrDefault(f => f.Name == "Экономический факультет");
            facultyToUpdate.Name = facultyName;

            facultiesViewModel.SelectedFaculty = facultyToUpdate;
            (facultiesViewModel.UpdateCommand as ICommand).Execute(null);

            Assert.IsTrue(
                facultiesViewModel.Faculties.FirstOrDefault(f => f.FacultyId == facultyToUpdate.FacultyId).Name == facultyName);
        }

        [TestMethod]
        public void FacultyDelete()
        {
            var facultiesViewModel = ContainerMockHelper.Container.Resolve<FacultiesViewModel>();
            var firstFacultyName = facultiesViewModel.Faculties[0].Name;
            
            facultiesViewModel.SelectedFaculty = facultiesViewModel.Faculties[0];
            (facultiesViewModel.RemoveCommand as ICommand).Execute(null);

            Assert.IsFalse(facultiesViewModel.Faculties.Any(f => f.Name == firstFacultyName));
        }
    }
}
