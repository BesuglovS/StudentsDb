using System.Collections.Generic;

namespace StudentsDb.Export
{
    public class ExportType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultExt { get; set; }

        public const int txtId = 1;
        public const int csvId = 2;

        public static ExportType txt = new ExportType { Id = txtId, Name = "Текстовый файл (*.txt)", DefaultExt = ".txt" };
        public static ExportType csv = new ExportType { Id = csvId, Name = "Значения, разделённые запятыми (*.csv)", DefaultExt=".csv" };

        public static List<ExportType> All = new List<ExportType> {txt, csv};
    }
}
