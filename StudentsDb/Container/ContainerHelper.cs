using StudentsDb.Repositories.Concrete;
using StudentsDb.Repositories.Interfaces;
using Unity;
using Unity.Lifetime;

namespace StudentsDb.Container
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        public static IUnityContainer Container
        {
            get { return _container; }
        }

        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IFacultyRepository, FacultyRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISpecialityRepository, SpecialityRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IStudentRepository, StudentRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IReportRepository, ReportRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
