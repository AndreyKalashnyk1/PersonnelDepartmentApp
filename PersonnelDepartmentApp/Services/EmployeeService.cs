using System;
using System.Collections.Generic;
using System.Linq;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Utils;

namespace PersonnelDepartmentApp.Services
{
    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();

        public List<Employee> GetEmployees()
        {
            if (employees.Count == 0)
            {
                // Завантажуємо дані з Excel, якщо список порожній
                employees = FileService.LoadEmployeesFromExcel();
            }
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            SaveEmployees();
        }

        public void EditEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.Find(e => e.Id == id);
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
            //FileService.SaveEmployeesToExcel(employees);
        }

        public int GetNextEmployeeId()
        {
            if (employees.Count == 0) return 1;
            return employees.Max(e => e.Id) + 1;
        }

    }
}
