using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartmentApp.Models
{
    /// Клас для зберігання інформації про підрозділ
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Head { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

}
