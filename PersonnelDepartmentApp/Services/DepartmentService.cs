using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using PersonnelDepartmentApp.Models;

namespace PersonnelDepartmentApp.Services
{
    public class DepartmentService
    {
        private List<Department> departments = new List<Department>();
        private FileService fileService = new FileService();

        public DepartmentService()
        {
            // Завантажуємо підрозділи з Excel-файлу при ініціалізації
            departments = fileService.LoadDepartmentsFromExcel();
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }

        public void AddDepartment(Department department)
        {
            department.Id = GetNextDepartmentId();
            departments.Add(department);
            SaveDepartments();
        }

        public void EditDepartment(int id, Department updatedDepartment)
        {
            var department = departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                int index = departments.IndexOf(department);
                departments[index] = updatedDepartment;
                SaveDepartments();
            }
        }

        public void DeleteDepartment(int id)
        {
            // Удаляем подразделение с нужным Id
            departments.RemoveAll(d => d.Id == id);

            // Перенумеровываем Id у всех подразделений с Id > удалённого
            foreach (var dept in departments.Where(d => d.Id > id))
            {
                dept.Id -= 1;
            }

            SaveDepartments();
        }


        public void SaveDepartments()
        {
            fileService.SaveDepartmentsToExcel(departments);
        }

        public int GetNextDepartmentId()
        {
            return departments.Count == 0 ? 1 : departments.Max(d => d.Id) + 1;
        }

        public Department GetDepartmentById(int id)
        {
            return departments.FirstOrDefault(d => d.Id == id);
        }
        public void ReloadDepartments()
        {
            departments = fileService.LoadDepartmentsFromExcel();
        }
    }
}
