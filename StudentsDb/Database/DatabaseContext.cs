using StudentsDb.DomainClasses;
using StudentsDb.Exceptions;
using System.Data.Entity;
using System.Windows;

namespace StudentsDb.Database
{
    class DatabaseContext : DbContext
    {
        private static DatabaseConnectionInfo _connectionInfo;

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Student> Students { get; set; }

        public DatabaseContext() : base(GetConnectionString())
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        private static string GetConnectionString()
        {
            try
            {
                _connectionInfo = GetConnectionInfo();
            }
            catch (FetchConnectionDataException exc)
            {
                MessageBox.Show(exc.Message,"Не удалось прочитать реквизиты для подключения к базе данных", MessageBoxButton.OK);                
                return null;
            }

            if (_connectionInfo.IsSimpleConnectionString)
            {
                return _connectionInfo.ConnectionString;
            }

            return "data source=tcp:" + _connectionInfo.ConnectionServer +
                   "; Database=" + _connectionInfo.ConnectionDatabaseName +
                   "; User Id=" + _connectionInfo.ConnectionUsername +
                   "; Password=" + _connectionInfo.ConnectionPassword +
                   "; multipleactiveresultsets=True";
        }

        private static DatabaseConnectionInfo GetConnectionInfo()
        {
            var result = ConncetionInfoFetcher.GetConnectionInfoIni();
            if (result != null)
            {
                return result;
            }

            result = ConncetionInfoFetcher.GetConnectionInfoUdl();
            return result;
        }
    }
}
