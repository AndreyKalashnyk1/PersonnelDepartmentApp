using System;
using System.Collections.Generic;
using System.Linq;
using PersonnelDepartmentApp.Models;

namespace PersonnelDepartmentApp.Services
{
    /// <summary>
    /// Клас для роботи зі списком співробітників.
    /// </summary>
    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeService()
        {
            // Можна ініціалізувати тестовими даними або пустим списком
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Знайти та оновити співробітника
            var existing = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                var index = employees.IndexOf(existing);
                employees[index] = employee;
            }
        }

        public List<Employee> SearchEmployees(Func<Employee, bool> predicate)
        {
            return employees.Where(predicate).ToList();
        }

        // Інші методи, наприклад, завантаження і збереження з Excel — додаємо пізніше
    }
}
