using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartmentApp.Models
{
    /// Клас для зберігання інформації про освіту
    public class Education
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }
        public string Institution { get; set; }
        public DateTime GraduationYear { get; set; }
    }
}
