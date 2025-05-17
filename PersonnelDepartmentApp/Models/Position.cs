using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartmentApp.Models
{
    /// Клас для зберігання інформації про посаду
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public string Requirements { get; set; }
    }
}
