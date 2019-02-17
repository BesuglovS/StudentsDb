using StudentsDb.Repositories.Interfaces;
using StudentsDb.Tests.Faculties;

using Unity;
using Unity.Lifetime;

namespace StudentsDb.Container
{
    public static class ContainerMockHelper
    {
        private static IUnityContainer _container;
        public static IUnityContainer Container
        {
            get { return _container; }
        }

        static ContainerMockHelper()
        {
            _container = new UnityContainer();
            _container.AddExtension(new Diagnostic());
            _container.RegisterType<IFacultyRepository, FacultyRepositoryMock>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<ISpecialityRepository, SpecialityRepositoryMock>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IStudentRepository, StudentRepositoryMock>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IReportRepository, ReportRepositoryMock>(new ContainerControlledLifetimeManager());
        }
    }
}
