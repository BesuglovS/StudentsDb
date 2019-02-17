using System.Collections.Generic;
using System.IO;

namespace StudentsDb.Export
{
    public static class TextFileUtil
    {
        public static void CreateOrEmptyFile(string filename)
        {
            var sw = new StreamWriter(filename);
            sw.Close();
        }

        public static void WriteString(string filename, string line)
        {
            var sw = new StreamWriter(filename, true);
            sw.WriteLine(line);
            sw.Close();
        }

        public static void WriteStringList(string filename, List<string> lines)
        {
            var sw = new StreamWriter(filename, true);
            foreach (string line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }

        public static List<string> ReadFileInStringList(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                var result = new List<string>();
                string line;                
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }

                return result;
            }
        }
    }
}
