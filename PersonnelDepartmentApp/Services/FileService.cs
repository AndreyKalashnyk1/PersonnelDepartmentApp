using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using PersonnelDepartmentApp.Models;

namespace PersonnelDepartmentApp.Services
{
    public static class FileService
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Excel", "employees.xlsx");

        public static List<Employee> LoadEmployeesFromExcel()
        {
            var employees = new List<Employee>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено: " + filePath);
                return employees;
            }

            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split('\t'); // Розділювач табуляція

                try
                {
                    var employee = new Employee
                    {
                        Id = int.Parse(data[0]),
                        LastName = data[1],
                        FirstName = data[2],
                        MiddleName = data[3],
                        BirthDate = DateTime.ParseExact(data[4], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        PassportNumber = data[5],
                        HireDate = DateTime.ParseExact(data[9], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        TerminationDate = string.IsNullOrWhiteSpace(data[10]) ? (DateTime?)null : DateTime.ParseExact(data[10], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        Salary = decimal.Parse(data[11])
                    };
                    employees.Add(employee);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка завантаження рядка {i + 1}: {ex.Message}");
                }
            }

            return employees;
        }
    }
}
