using System.Collections.Generic;
using System.Linq;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;

namespace PersonnelDepartmentApp.Services
{
    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();
        private FileService fileService = new FileService();

        public EmployeeService()
        {
            // Завантажуємо працівників з Excel-файлу під час ініціалізації сервісу
            employees = fileService.LoadEmployeesFromExcel();
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = GetNextEmployeeId();
            employees.Add(employee);
            SaveEmployees();
        }

        public void EditEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                int index = employees.IndexOf(employee);
                employees[index] = updatedEmployee;
                SaveEmployees();
            }
        }

        public void DeleteEmployee(int id)
        {
            employees.RemoveAll(e => e.Id == id);
            SaveEmployees();
        }

        public void SaveEmployees()
        {
            fileService.SaveEmployeesToExcel(employees);
        }

        public int GetNextEmployeeId()
        {
            return employees.Count == 0 ? 1 : employees.Max(e => e.Id) + 1;
        }
    }
}
