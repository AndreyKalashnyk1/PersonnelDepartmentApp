using System;
using System.Collections.Generic;
using System.IO;

namespace PersonnelDepartmentApp.Utils
{
    /// Клас для роботи з файлами Excel у вигляді CSV або простого текстового формату.

    public static class ExcelHelper
    {
        /// <summary>
        /// Зчитує дані з CSV файлу та повертає список рядків.
        /// </summary>
        public static List<string[]> ReadCsv(string filePath)
        {
            var lines = new List<string[]>();

            if (!File.Exists(filePath))
                return lines;

            var allLines = File.ReadAllLines(filePath);

            foreach (var line in allLines)
            {
                // Розділяємо по комі, можна додати обробку лапок пізніше
                var fields = line.Split(',');
                lines.Add(fields);
            }

            return lines;
        }

        /// <summary>
        /// Записує дані у CSV файл.
        /// </summary>
        public static void WriteCsv(string filePath, List<string[]> data)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var row in data)
                {
                    var line = string.Join(",", row);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
