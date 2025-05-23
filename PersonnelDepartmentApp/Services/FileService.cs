using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using PersonnelDepartmentApp.Models;
using Word = Microsoft.Office.Interop.Word;

namespace PersonnelDepartmentApp.Services
{
    public class FileService
    {
        // Відносний шлях до файлу поруч з .exe файлом
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees1.xlsx");
        private static readonly string positionsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "positions.xlsx");
        private static readonly string departmentsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "departments.xlsx");


        // Метод завантаження даних з Excel
        public List<Employee> LoadEmployeesFromExcel()
        {
            var employees = new List<Employee>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено: " + filePath);
                return employees;
            }

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1];

                Excel.Range usedRange = worksheet.UsedRange;
                int rowCount = usedRange.Rows.Count;

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        var employee = new Employee
                        {
                            Id = int.Parse(usedRange.Cells[row, 1].Text),
                            LastName = usedRange.Cells[row, 2].Text,
                            FirstName = usedRange.Cells[row, 3].Text,
                            MiddleName = usedRange.Cells[row, 4].Text,
                            BirthDate = DateTime.Parse(usedRange.Cells[row, 5].Text),
                            PassportNumber = usedRange.Cells[row, 6].Text,
                            HireDate = DateTime.Parse(usedRange.Cells[row, 7].Text),
                            TerminationDate = string.IsNullOrWhiteSpace(usedRange.Cells[row, 8].Text)
                                ? (DateTime?)null
                                : DateTime.Parse(usedRange.Cells[row, 8].Text),
                            Salary = decimal.Parse(usedRange.Cells[row, 9].Text),
                            DepartmentId = string.IsNullOrWhiteSpace(usedRange.Cells[row, 10].Text)
                                ? (int?)null
                                : int.Parse(usedRange.Cells[row, 10].Text),
                            PositionId = string.IsNullOrWhiteSpace(usedRange.Cells[row, 11].Text)
                                ? (int?)null
                                : int.Parse(usedRange.Cells[row, 11].Text)
                        };

                        employees.Add(employee);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка обробки рядка {row}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження файлу: {ex.Message}");
            }
            finally
            {
                workbook?.Close(false);
                excelApp?.Quit();
            }

            return employees;
        }


        // Метод для збереження даних в Excel
        public void SaveEmployeesToExcel(List<Employee> employees)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = workbook.Sheets[1];

                // Заголовки
                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Прізвище";
                worksheet.Cells[1, 3].Value = "Ім'я";
                worksheet.Cells[1, 4].Value = "По батькові";
                worksheet.Cells[1, 5].Value = "Дата народження";
                worksheet.Cells[1, 6].Value = "Номер паспорта";
                worksheet.Cells[1, 7].Value = "Дата прийняття";
                worksheet.Cells[1, 8].Value = "Дата звільнення";
                worksheet.Cells[1, 9].Value = "Зарплата";
                worksheet.Cells[1, 10].Value = "Підрозділ ID"; // нова колонка
                worksheet.Cells[1, 11].Value = "Посада ID"; // нова колонка


                // Дані
                int row = 2;
                foreach (Employee employee in employees)
                {
                    worksheet.Cells[row, 1].Value = employee.Id;
                    worksheet.Cells[row, 2].Value = employee.LastName;
                    worksheet.Cells[row, 3].Value = employee.FirstName;
                    worksheet.Cells[row, 4].Value = employee.MiddleName;
                    worksheet.Cells[row, 5].Value = employee.BirthDate.ToString("dd.MM.yyyy");
                    worksheet.Cells[row, 6].Value = employee.PassportNumber;
                    worksheet.Cells[row, 7].Value = employee.HireDate.ToString("dd.MM.yyyy");
                    worksheet.Cells[row, 8].Value = employee.TerminationDate?.ToString("dd.MM.yyyy") ?? "";
                    worksheet.Cells[row, 9].Value = employee.Salary.ToString("F2");
                    worksheet.Cells[row, 10].Value = employee.DepartmentId?.ToString() ?? ""; // нове поле
                    worksheet.Cells[row, 11].Value = employee.PositionId?.ToString() ?? "";
                    row++;
                }

                // Зберігаємо
                workbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження файлу: {ex.Message}");
            }
            finally
            {
                workbook?.Close(false);
                excelApp?.Quit();
            }
        }
        public List<Department> LoadDepartmentsFromExcel()
        {
            var departments = new List<Department>();
            string path = departmentsFilePath;
            if (!File.Exists(path)) return departments;

            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Open(path);
            var sheet = workbook.Sheets[1];
            var range = sheet.UsedRange;
            int rowCount = range.Rows.Count;

            for (int row = 2; row <= rowCount; row++)
            {
                departments.Add(new Department
                {
                    Id = int.Parse(range.Cells[row, 1].Text),
                    Name = range.Cells[row, 2].Text
                });
            }

            workbook.Close(false);
            excelApp.Quit();

            return departments;
        }
        public void SaveDepartmentsToExcel(List<Department> departments)
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var sheet = workbook.Sheets[1];

            sheet.Cells[1, 1].Value = "Id";
            sheet.Cells[1, 2].Value = "Назва";

            int row = 2;
            foreach (var d in departments)
            {
                sheet.Cells[row, 1].Value = d.Id;
                sheet.Cells[row, 2].Value = d.Name;
                row++;
            }

            workbook.SaveAs(departmentsFilePath);
            workbook.Close(false);
            excelApp.Quit();
        }
        public List<Position> LoadPositionsFromExcel()
        {
            var positions = new List<Position>();
            if (!File.Exists(positionsFilePath)) return positions;

            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Open(positionsFilePath);
            var sheet = workbook.Sheets[1];
            var range = sheet.UsedRange;
            int rowCount = range.Rows.Count;

            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    positions.Add(new Position
                    {
                        Id = int.Parse(range.Cells[row, 1].Text),
                        Title = range.Cells[row, 2].Text,
                        Salary = decimal.Parse(range.Cells[row, 3].Text),
                        Requirements = range.Cells[row, 4].Text
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка обробки рядка {row}: {ex.Message}");
                }
            }

            workbook.Close(false);
            excelApp.Quit();

            return positions;
        }
        public void SavePositionsToExcel(List<Position> positions)
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var sheet = workbook.Sheets[1];

            // Заголовки
            sheet.Cells[1, 1].Value = "Id";
            sheet.Cells[1, 2].Value = "Назва";
            sheet.Cells[1, 3].Value = "Зарплата";
            sheet.Cells[1, 4].Value = "Вимоги";

            int row = 2;
            foreach (var p in positions)
            {
                sheet.Cells[row, 1].Value = p.Id;
                sheet.Cells[row, 2].Value = p.Title;
                sheet.Cells[row, 3].Value = p.Salary.ToString("F2");
                sheet.Cells[row, 4].Value = p.Requirements;
                row++;
            }

            workbook.SaveAs(positionsFilePath);
            workbook.Close(false);
            excelApp.Quit();
        }
        public void GenerateOrderFromWordTemplate(string templateFileName, Dictionary<string, string> replacements,string outputPdfFileName)
        {
            string templatesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
            string templatePath = Path.Combine(templatesDir, templateFileName);
            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Шаблон не знайдено", templatePath);

            string ordersDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders");
            if (!Directory.Exists(ordersDir))
                Directory.CreateDirectory(ordersDir);

            string tempDocx = Path.Combine(ordersDir, Guid.NewGuid() + ".docx");
            string outputPdfPath = Path.Combine(ordersDir, outputPdfFileName);

            // Копируем шаблон во временный docx
            File.Copy(templatePath, tempDocx, true);

            var wordApp = new Word.Application();
            Word.Document doc = null;
            try
            {
                doc = wordApp.Documents.Open(tempDocx);

                // Замена плейсхолдеров
                foreach (var pair in replacements)
                {
                    Word.Find findObject = wordApp.Selection.Find;
                    findObject.ClearFormatting();
                    findObject.Text = pair.Key;
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = pair.Value;
                    object replaceAll = Word.WdReplace.wdReplaceAll;
                    findObject.Execute(Replace: ref replaceAll);
                }

                // Зберігаємо як PDF
                doc.SaveAs2(outputPdfPath, Word.WdSaveFormat.wdFormatPDF);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                }
                wordApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                // Удаляем временный docx
                if (File.Exists(tempDocx))
                    File.Delete(tempDocx);
            }
        }

    }
}
